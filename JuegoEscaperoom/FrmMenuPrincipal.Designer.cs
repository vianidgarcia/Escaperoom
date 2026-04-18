namespace JuegoEscaperoom
{
    partial class FrmMenuPrincipal
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
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            btnNueva = new Button();
            btnCargar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Press Start 2P", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(20, 10, 64);
            lblTitulo.Location = new Point(26, 26);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(344, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Escaperoom";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("MS UI Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = SystemColors.GrayText;
            lblSubtitulo.Location = new Point(106, 60);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(184, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "¡Ayuda!, no he dormido nada";
            // 
            // btnNueva
            // 
            btnNueva.BackColor = Color.Maroon;
            btnNueva.FlatAppearance.BorderColor = Color.White;
            btnNueva.FlatAppearance.BorderSize = 0;
            btnNueva.FlatStyle = FlatStyle.Popup;
            btnNueva.Font = new Font("Dogica", 9F);
            btnNueva.ForeColor = SystemColors.ControlLightLight;
            btnNueva.Location = new Point(112, 100);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(168, 40);
            btnNueva.TabIndex = 2;
            btnNueva.Text = "Nueva Partida";
            btnNueva.UseVisualStyleBackColor = false;
            btnNueva.Click += btnNueva_Click;
            // 
            // btnCargar
            // 
            btnCargar.BackColor = Color.Maroon;
            btnCargar.FlatAppearance.BorderColor = Color.White;
            btnCargar.FlatStyle = FlatStyle.Popup;
            btnCargar.Font = new Font("Dogica", 9F);
            btnCargar.ForeColor = SystemColors.ControlLightLight;
            btnCargar.Location = new Point(112, 149);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(168, 40);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "Cargar Partida";
            btnCargar.UseVisualStyleBackColor = false;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Maroon;
            btnSalir.FlatAppearance.BorderColor = Color.White;
            btnSalir.FlatStyle = FlatStyle.Popup;
            btnSalir.Font = new Font("Dogica", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ControlLightLight;
            btnSalir.Location = new Point(112, 198);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(168, 40);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(398, 263);
            Controls.Add(btnSalir);
            Controls.Add(btnCargar);
            Controls.Add(btnNueva);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmMenuPrincipal";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmMenuPrincipal";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Button btnNueva;
        private Button btnCargar;
        private Button btnSalir;
    }
}