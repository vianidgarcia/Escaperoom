namespace JuegoEscaperoom
{
    partial class FrmPausa
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
            btnSalir = new Button();
            btnGuardar = new Button();
            btnContinuar = new Button();
            lblPuntaje = new Label();
            lblInventarioResumen = new Label();
            lblHabitacion = new Label();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Maroon;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Dogica", 9F);
            btnSalir.ForeColor = SystemColors.ControlLightLight;
            btnSalir.Location = new Point(65, 219);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(162, 38);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "Salir al Menu";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalirMenu_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Maroon;
            btnGuardar.FlatStyle = FlatStyle.Popup;
            btnGuardar.Font = new Font("Dogica", 9F);
            btnGuardar.ForeColor = SystemColors.ControlLightLight;
            btnGuardar.Location = new Point(65, 161);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(162, 38);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Partida";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.Maroon;
            btnContinuar.FlatStyle = FlatStyle.Popup;
            btnContinuar.Font = new Font("Dogica", 9F);
            btnContinuar.ForeColor = SystemColors.ControlLightLight;
            btnContinuar.Location = new Point(65, 105);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(162, 38);
            btnContinuar.TabIndex = 7;
            btnContinuar.Text = "Continuar Partida";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // lblPuntaje
            // 
            lblPuntaje.AutoSize = true;
            lblPuntaje.Font = new Font("MS UI Gothic", 11F);
            lblPuntaje.ForeColor = Color.FromArgb(64, 0, 0);
            lblPuntaje.Location = new Point(12, 282);
            lblPuntaje.Name = "lblPuntaje";
            lblPuntaje.Size = new Size(55, 15);
            lblPuntaje.TabIndex = 6;
            lblPuntaje.Text = "Puntaje";
            // 
            // lblInventarioResumen
            // 
            lblInventarioResumen.Font = new Font("MS UI Gothic", 11F);
            lblInventarioResumen.ForeColor = Color.FromArgb(64, 0, 0);
            lblInventarioResumen.Location = new Point(14, 40);
            lblInventarioResumen.Name = "lblInventarioResumen";
            lblInventarioResumen.Size = new Size(267, 46);
            lblInventarioResumen.TabIndex = 5;
            lblInventarioResumen.Text = "Inventario";
            // 
            // lblHabitacion
            // 
            lblHabitacion.Font = new Font("MS UI Gothic", 11F);
            lblHabitacion.ForeColor = Color.FromArgb(64, 0, 0);
            lblHabitacion.Location = new Point(12, 12);
            lblHabitacion.Name = "lblHabitacion";
            lblHabitacion.Size = new Size(269, 19);
            lblHabitacion.TabIndex = 10;
            lblHabitacion.Text = "habitacion";
            // 
            // FrmPausa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(293, 312);
            Controls.Add(lblHabitacion);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(btnContinuar);
            Controls.Add(lblPuntaje);
            Controls.Add(lblInventarioResumen);
            Name = "FrmPausa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPausa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalir;
        private Button btnGuardar;
        private Button btnContinuar;
        private Label lblPuntaje;
        private Label lblInventarioResumen;
        private Label lblHabitacion;
    }
}