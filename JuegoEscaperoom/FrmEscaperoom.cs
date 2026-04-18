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
            estado.HabitacionActual = "Cuarto"; // Iniciamos en el cuarto
            CargarHabitacion(Habitacion.Cuarto);
            MostrarDialogoAnimado("¿Donde estoy? Todo parece una pesadilla... debo salir de aquí.");
        }
        private void CargarHabitacion(Habitacion hab)
        {
            estado.HabitacionActual = hab.ToString();
            var zonasViejas = pbxHabitacion.Controls.OfType<PictureBox>().ToList();
            foreach (var zona in zonasViejas) zona.Dispose();

            pbxHabitacion.Image = (Image)Properties.Resources.ResourceManager.GetObject(hab.ToString());

            acertijosActuales = BancoPreguntas.ObtenerAcertijosPorHabitacion(hab);

            foreach (var acertijo in acertijosActuales)
            {
                CrearBotonInteractivo(acertijo);
            }

            ActualizarUI();
        }

        private void CrearBotonInteractivo(Acertijo acertijo)
        {
            PictureBox pb = new PictureBox();
            pb.Bounds = acertijo.AreaInteractiva;
            pb.BackColor = Color.Transparent;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Cursor = Cursors.Hand;
            pb.Parent = pbxHabitacion;
            pb.Tag = acertijo;

            // Evento Click
            pb.Click += (s, e) =>
            {
                Acertijo a = (Acertijo)((PictureBox)s).Tag;
                ProcesarClickEnObjeto(a);
            };

            pbxHabitacion.Controls.Add(pb);
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


            // Parseamos el enum desde el string guardado
            // Enum.TryParse es seguro — no lanza excepción si el valor no existe
            if (!Enum.TryParse(estado.HabitacionActual, out Habitacion hab))
                hab = Habitacion.Cuarto;

            CargarHabitacion(hab);
            ActualizarUI();
            ActualizarInventarioVisual();
            MostrarDialogoAnimado("Retomando donde lo dejé...\nAquí están mis notas.");
        }

        private void CrearZonaInspeccion(int x, int y, int w, int h, string mensaje)
        {
            PictureBox zona = new PictureBox();
            zona.Size = new Size(w, h);
            zona.Location = new Point(x, y);
            zona.BackColor = Color.Transparent;
            zona.Parent = pbxHabitacion;

            zona.Click += (s, e) => MessageBox.Show(mensaje, "Inspeccionando...");
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

        private void pbxHabitacion_MouseClick(object sender, MouseEventArgs e)
        {
            // Esto te mostrará un mensaje con las coordenadas exactas de donde hiciste clic
            // Úsenlo para saber qué valores poner en CrearZonaInteractiva
            MessageBox.Show($"X: {e.X}, Y: {e.Y}");
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


        private void ProcesarClickEnObjeto(Acertijo acertijo)
        {
            if (acertijo.Resuelto)
            {
                MostrarDialogoAnimado($"Ya revisé: {acertijo.NombreObjeto}. No hay nada más de interés aquí.");
                return;
            }

            if (!string.IsNullOrEmpty(acertijo.ItemRequerido) && !estado.Inventario.Contains(acertijo.ItemRequerido))
            {
                MostrarDialogoAnimado($"Parece que está bloqueado... Necesito algo como: [{acertijo.ItemRequerido}].");
                return;
            }

            using (var frmPregunta = new FrmPregunta(acertijo))
            {
                if (frmPregunta.ShowDialog() == DialogResult.OK)
                {
                    ProcesarExito(acertijo);
                }
            }
        }

        private void ProcesarExito(Acertijo acertijo)
        {
            estado.Puntaje += 100;

            if (!string.IsNullOrEmpty(acertijo.ItemRecompensa))
            {
                estado.Inventario.Add(acertijo.ItemRecompensa);
                MostrarDialogoAnimado($"¡He encontrado un objeto clave! Añadido al inventario: {acertijo.ItemRecompensa}");
                ActualizarInventarioVisual();
            }
            else
            {
                MostrarDialogoAnimado($"He resuelto el misterio del {acertijo.NombreObjeto}.");
            }

            ActualizarUI();
            cambiosSinGuardar = true;


            switch (acertijo.NombreObjeto)
            {
                case "Computadora":
                    MessageBox.Show("¡El sistema se ha desbloqueado! Se escucha el pestillo de la puerta de la Cocina.", "Progreso");
                    CargarHabitacion(Habitacion.Cocina);
                    break;
                case "Grifo goteante":
                    MessageBox.Show("¡El grifo se ha desprendido! Se escucha un 'click' en la puerta de la Biblioteca.", "Progreso");
                    CargarHabitacion(Habitacion.Biblioteca);
                    break;
                case "Libro de Cuero":
                    MessageBox.Show("¡El camino a la puerta principal se ha abierto!");
                    CargarHabitacion(Habitacion.Salida);
                    break;
                case "Puerta Final":
                    MessageBox.Show("¡La puerta de salida se ha desbloqueado! ¡He escapado!", "¡Felicidades!");
                    ReiniciarJuego();
                    break;

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
