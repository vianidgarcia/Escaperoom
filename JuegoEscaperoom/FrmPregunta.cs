using JuegoEscaperoom.EscapeRoomPOO;
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
    public partial class FrmPregunta : Form
    {
        private readonly Acertijo acertijo;
        private int tiempoRestante = 30; // Tiempo por defecto

        public FrmPregunta(Acertijo acertijo)
        {
            InitializeComponent();
            this.acertijo = acertijo;

            // Configurar UI inicial
            this.Text = $"Inspeccionando: {this.acertijo.NombreObjeto}";
            lblPregunta.Text = this.acertijo.Pregunta;
            lblIntentos.Text = $"Intentos: {this.acertijo.Intentos}";
            btnPista.Visible = false; // Solo mostrar después de algunos intentos

        }

        private void FrmPregunta_Load(object sender, EventArgs e)
        {
            tmrCuentaRegresiva.Start();
            txtRespuesta.Focus();
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            Validar();
        }
        private void Validar()
        {
            string respuestaUsuario = txtRespuesta.Text;
            if (string.IsNullOrWhiteSpace(respuestaUsuario))
            {
                MessageBox.Show("Por favor, ingresa una respuesta antes de validar.", "Campo vacío",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRespuesta.Focus();
                return;
            }

            // Usamos el método Resolver que ya definimos en la clase base
            if (this.acertijo.Resolver(respuestaUsuario))
            {
                tmrCuentaRegresiva.Stop();
                MessageBox.Show("¡Excelente! Has descifrado el acertijo.", "Correcto",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK; // Indica éxito al FrmEscaperoom
                this.Close();
            }
            else
            {
                lblIntentos.Text = $"Intentos: {this.acertijo.Intentos}";
                MessageBox.Show("Esa no parece ser la respuesta...", "Incorrecto",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtRespuesta.Clear();
                txtRespuesta.Focus();

                // Si lleva muchos intentos, podrías habilitar el botón de pista automáticamente
                if (this.acertijo.Intentos >= 2) btnPista.Visible = true;
            }
        }

        private void btnPista_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Pista: {this.acertijo.Pista}", "Ayuda",
                            MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


        private void tmrCuentaRegresiva_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            lblTimer.Text = $"Tiempo: {tiempoRestante}s";

            if (tiempoRestante <= 5) lblTimer.ForeColor = Color.Red;

            if (tiempoRestante <= 0)
            {
                tmrCuentaRegresiva.Stop();
                MessageBox.Show("¡Se acabó el tiempo! El objeto se ha bloqueado.", "Tiempo agotado",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void txtRespuesta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita el "ding" del sistema
                Validar();
            }
        }
    }
}
