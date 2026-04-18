namespace JuegoEscaperoom
{
    partial class FrmPregunta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblPregunta = new Label();
            lblTimer = new Label();
            lblIntentos = new Label();
            txtRespuesta = new TextBox();
            btnValidar = new Button();
            btnPista = new Button();
            tmrCuentaRegresiva = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // lblPregunta
            // 
            lblPregunta.Font = new Font("MS UI Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPregunta.ForeColor = Color.FromArgb(64, 0, 0);
            lblPregunta.Location = new Point(22, 82);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(337, 60);
            lblPregunta.TabIndex = 0;
            lblPregunta.Text = "Pregunta";
            // 
            // lblTimer
            // 
            lblTimer.AutoSize = true;
            lblTimer.Font = new Font("MS UI Gothic", 10F);
            lblTimer.ForeColor = Color.FromArgb(64, 0, 0);
            lblTimer.Location = new Point(11, 10);
            lblTimer.Name = "lblTimer";
            lblTimer.Size = new Size(49, 14);
            lblTimer.TabIndex = 1;
            lblTimer.Text = "Tiempo";
            // 
            // lblIntentos
            // 
            lblIntentos.AutoSize = true;
            lblIntentos.Font = new Font("MS UI Gothic", 10F);
            lblIntentos.ForeColor = Color.FromArgb(64, 0, 0);
            lblIntentos.Location = new Point(308, 10);
            lblIntentos.Name = "lblIntentos";
            lblIntentos.Size = new Size(54, 14);
            lblIntentos.TabIndex = 2;
            lblIntentos.Text = "Intentos";
            // 
            // txtRespuesta
            // 
            txtRespuesta.Location = new Point(18, 162);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(343, 23);
            txtRespuesta.TabIndex = 3;
            txtRespuesta.KeyDown += txtRespuesta_KeyDown;
            // 
            // btnValidar
            // 
            btnValidar.BackColor = Color.Maroon;
            btnValidar.FlatStyle = FlatStyle.Popup;
            btnValidar.Font = new Font("Dogica", 9F);
            btnValidar.ForeColor = SystemColors.ControlLightLight;
            btnValidar.Location = new Point(263, 215);
            btnValidar.Name = "btnValidar";
            btnValidar.Size = new Size(98, 32);
            btnValidar.TabIndex = 4;
            btnValidar.Text = "Validar";
            btnValidar.UseVisualStyleBackColor = false;
            btnValidar.Click += btnValidar_Click;
            // 
            // btnPista
            // 
            btnPista.BackColor = Color.Maroon;
            btnPista.FlatStyle = FlatStyle.Popup;
            btnPista.Font = new Font("Dogica", 9F);
            btnPista.ForeColor = SystemColors.ControlLightLight;
            btnPista.Location = new Point(18, 215);
            btnPista.Name = "btnPista";
            btnPista.Size = new Size(75, 32);
            btnPista.TabIndex = 5;
            btnPista.Text = "Pista";
            btnPista.UseVisualStyleBackColor = false;
            btnPista.Click += btnPista_Click;
            // 
            // tmrCuentaRegresiva
            // 
            tmrCuentaRegresiva.Interval = 1000;
            tmrCuentaRegresiva.Tick += tmrCuentaRegresiva_Tick;
            // 
            // FrmPregunta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(381, 267);
            Controls.Add(btnPista);
            Controls.Add(btnValidar);
            Controls.Add(txtRespuesta);
            Controls.Add(lblIntentos);
            Controls.Add(lblTimer);
            Controls.Add(lblPregunta);
            Name = "FrmPregunta";
            Text = "FrmPregunta";
            Load += FrmPregunta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblPregunta;
        private Label lblTimer;
        private Label lblIntentos;
        private TextBox txtRespuesta;
        private Button btnValidar;
        private Button btnPista;
        private System.Windows.Forms.Timer tmrCuentaRegresiva;
    }
}