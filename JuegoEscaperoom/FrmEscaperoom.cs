using JuegoEscaperoom.EscapeRoomPOO;
using JuegoEscaperoom.JuegoEscaperoomS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JuegoEscaperoom
{
    public partial class FrmEscaperoom : Form
    {
        private EstadoJuego estado = new();
        private List<Acertijo> acertijosActuales = new();
        private bool cambiosSinGuardar = false;
        private string textoDialogoCompleto = "";
        private int charDialogo = 0;
        private EscenaHabitacion escenaActual;

        public FrmEscaperoom(bool cargarPartida)
        {
            InitializeComponent();
            CargarImagenPersonaje();
            if (cargarPartida)
                CargarPartida();
            else
                IniciarPartidaNueva();
        }

        private void IniciarPartidaNueva()
        {
            estado = new EstadoJuego();
            CargarHabitacion(Habitacion.Cuarto);
            MostrarDialogoAnimado("¿Donde estoy? Todo parece una pesadilla... debo salir de aquí.");
        }
        private void CargarHabitacion(Habitacion hab)
        {
            var acertijos = BancoPreguntas.ObtenerAcertijosPorHabitacion(hab);
            escenaActual = new EscenaHabitacion(CargarImagenFondo(hab));

            foreach (var acertijo in acertijos)
            {
                if (estado.ObjetosResueltos.Contains(acertijo.NombreObjeto))
                {
                    acertijo.MarcarComoResuelto();
                }
                else
                {
                    acertijo.AlResolver += (itemRecompensa) =>
                    {
                        ManejarExitoAcertijo(acertijo, itemRecompensa);
                    };
                }

                Rectangle area = MapaCoordenadas.ObtenerArea(hab, acertijo.NombreObjeto);
                escenaActual.RegistrarObjeto(acertijo, area);
            }

            pbxEscena.Image = escenaActual.Fondo;
            ActualizarUI();
            estado.CambiarHabitacion(hab);
            ActualizarInventarioVisual();
        }

        private void CargarPartida()
        {
            var guardado = PersistenciaPartida.CargarPartida();
            if (guardado == null)
            {
                MessageBox.Show("No se pudo cargar la partida. Iniciando nueva.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                IniciarPartidaNueva();
                return;
            }

            estado = guardado;
            CargarHabitacion(estado.HabitacionActual);
            ActualizarUI();
            ActualizarInventarioVisual();
            MostrarDialogoAnimado("Retomando donde lo dejé...\nAquí están mis notas.");
        }

        private void ManejarExitoAcertijo(Acertijo acertijo, string recompensa)
        {
            estado.RegistrarObjetoResuelto(acertijo.NombreObjeto);
            estado.SumarPuntos(100);

            if (!string.IsNullOrEmpty(recompensa))
            {
                estado.AgregarAlInventario(recompensa);
                MostrarDialogoAnimado($"¡He encontrado: {recompensa}!");
                ActualizarInventarioVisual();
            }
            else
            {
                MostrarDialogoAnimado($"He resuelto el acertijo: {acertijo.NombreObjeto}.");
            }

            // Lógica de navegación: Si el acertijo lleva a otra habitación
            if (acertijo.HabitacionDestino.HasValue)
            {
                MostrarDialogoAnimado($"¡Progreso! Se ha desbloqueado el acceso a: {acertijo.HabitacionDestino}");
                CargarHabitacion(acertijo.HabitacionDestino.Value);
            }

            // Caso especial de victoria final
            if (acertijo.NombreObjeto == "Puerta Final")
            {
                MessageBox.Show("¡La puerta de salida se ha desbloqueado! ¡He escapado!", "¡Felicidades!");
                ReiniciarJuego();
            }

            ActualizarUI();
            cambiosSinGuardar = true;
        }

        private void pbxEscena_MouseClick(object sender, MouseEventArgs e)
        {
            var acertijo = escenaActual.GetAcertijoEnPunto(e.Location);

            if (acertijo != null)
            {
                if (acertijo.Resuelto)
                {
                    MostrarDialogoAnimado($"Ya revisé {acertijo.NombreObjeto}. No hay nada más aquí.");
                    return;
                }

                if (!string.IsNullOrEmpty(acertijo.ItemRequerido) && !estado.Inventario.Contains(acertijo.ItemRequerido))
                {
                    MostrarDialogoAnimado($"Parece bloqueado... Necesito [{acertijo.ItemRequerido}].");
                    return;
                }

                using (var frm = new FrmPregunta(acertijo))
                {
                    frm.ShowDialog();
                }
            }
        }

        private Image CargarImagenFondo(Habitacion hab)
        {
            // Busca la imagen en los recursos según el nombre del Enum
            return (Image)Properties.Resources.ResourceManager.GetObject(hab.ToString());
        }

        private void CargarImagenPersonaje()
        {
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "personaje_icon.png");
            if (File.Exists(ruta))
            {
                pbxIconoPersonaje.Image = Image.FromFile(ruta);
                pbxIconoPersonaje.BackColor = Color.Transparent;
                pbxIconoPersonaje.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

       

        public void MostrarDialogoAnimado(string texto)
        {
            tmrDialogo.Stop();
            textoDialogoCompleto = texto;
            charDialogo = 0;
            lblDialogo.Text = "";
            tmrDialogo.Start();
        }

        private void tmrDialogo_Tick(object sender, EventArgs e)
        {
            if (charDialogo < textoDialogoCompleto.Length)
            {
                lblDialogo.Text += textoDialogoCompleto[charDialogo];
                charDialogo++;
            }
            else
            {
                tmrDialogo.Stop();
            }
        }

        private void ActualizarInventarioVisual()
        {
            flpInventario.Controls.Clear();

            foreach (string nombreItem in estado.Inventario)
            {
                PictureBox icono = new PictureBox
                {
                    Size = new Size(50, 50),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Margin = new Padding(5),
                    Cursor = Cursors.Help,
                    BackColor = Color.FromArgb(50, 50, 50)
                };

                var img = (Image)Properties.Resources.ResourceManager.GetObject(nombreItem);

                if (img != null)
                {
                    icono.Image = img;
                }

                ToolTip tip = new ToolTip();
                tip.SetToolTip(icono, nombreItem);

                flpInventario.Controls.Add(icono);
            }
        }

        private void ActualizarUI()
        {
            lblPuntaje.Text = $"Puntaje: {estado.Puntaje}";
            lblInventario.Text = "Inventario: " + string.Join(", ", estado.Inventario);
        }

        // Botón de Pausa
        private void btnPausa_Click(object sender, EventArgs e)
        {
            using (var frmPausa = new FrmPausa(estado, this))
            {
                frmPausa.ShowDialog();
                ActualizarUI(); // Por si guardó o cambió algo
            }
        }

        private void ReiniciarJuego()
        {
            DialogResult reiniciar = MessageBox.Show("¿Deseas jugar de nuevo?", "Reinicio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reiniciar == DialogResult.Yes)
            {
                IniciarPartidaNueva();
                ActualizarInventarioVisual();
            }
            else
            {
                this.Close();
            }
        }



        private void FrmEscaperoom_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!cambiosSinGuardar) return;

            var resultado = MessageBox.Show(
                "Vas a cerrar el Escape Room sin haber guardado.\n\n" +
                "¿Quieres guardar el progreso?",
                "¿Guardar partida?",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    PersistenciaPartida.GuardarPartida(estado);
                    cambiosSinGuardar = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; // no cerramos si falló el guardado
                }
            }
            else if (resultado == DialogResult.Cancel)
            {
                e.Cancel = true; // el usuario canceló el cierre
            }
        }
    }
}
