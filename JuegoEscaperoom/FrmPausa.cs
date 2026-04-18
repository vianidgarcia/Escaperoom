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
    public partial class FrmPausa : Form
    {
        private readonly EstadoJuego estado;
        private readonly Form frmPadre;

        // Propiedad para que el FrmEscapeRoom sepa si hubo un guardado exitoso
        public bool PartidaGuardada { get; private set; } = false;

        public FrmPausa(EstadoJuego estado, Form frmPadre)
        {
            this.estado = estado;
            this.frmPadre = frmPadre;
            InitializeComponent();
            ConfigurarEsteticaPausa();
        }

        private void ConfigurarEsteticaPausa()
        {
            lblPuntaje.Text = $"Puntos de Lógica: {estado.Puntaje}";
            lblHabitacion.Text = $"Ubicación: {estado.HabitacionActual}";

            // Actualizar lista de inventario rápida
            ActualizarMiniInventario();
        }

        private void ActualizarMiniInventario()
        {
            if (estado.Inventario.Count == 0)
            {
                lblInventarioResumen.Text = "Sin pistas u objetos.";
            }
            else
            {
                lblInventarioResumen.Text = "Objetos: " + string.Join(" | ", estado.Inventario);
            }
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Invocamos el servicio de guardado que ya tienes
                PersistenciaPartida.GuardarPartida(estado);

                PartidaGuardada = true;
                MessageBox.Show("Progreso de la investigación guardado.", "Sistema",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalirMenu_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("¿Seguro que quieres volver al menú? Se perderá el progreso no guardado.",
                "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (res == DialogResult.Yes)
            {
                // Cerramos la pausa y forzamos el cierre del juego para volver al menú principal
                this.DialogResult = DialogResult.Abort;
                frmPadre.Close();
            }
        }
    }
}
