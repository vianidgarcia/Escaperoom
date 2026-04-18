namespace JuegoEscaperoom
{
    partial class FrmIntro
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
            pnlDialogo = new Panel();
            btnContinuar = new Button();
            lblDialogo = new Label();
            lblNombre = new Label();
            pbxPersonaje = new PictureBox();
            tmrTexto = new System.Windows.Forms.Timer(components);
            pnlDialogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxPersonaje).BeginInit();
            SuspendLayout();
            // 
            // pnlDialogo
            // 
            pnlDialogo.BackColor = Color.LightCoral;
            pnlDialogo.Controls.Add(btnContinuar);
            pnlDialogo.Controls.Add(lblDialogo);
            pnlDialogo.Controls.Add(lblNombre);
            pnlDialogo.Location = new Point(12, 285);
            pnlDialogo.Name = "pnlDialogo";
            pnlDialogo.Size = new Size(776, 154);
            pnlDialogo.TabIndex = 2;
            // 
            // btnContinuar
            // 
            btnContinuar.BackColor = Color.Maroon;
            btnContinuar.FlatStyle = FlatStyle.Popup;
            btnContinuar.Font = new Font("Dogica", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnContinuar.ForeColor = SystemColors.ControlLightLight;
            btnContinuar.Location = new Point(636, 100);
            btnContinuar.Name = "btnContinuar";
            btnContinuar.Size = new Size(126, 41);
            btnContinuar.TabIndex = 2;
            btnContinuar.Text = "Continuar";
            btnContinuar.UseVisualStyleBackColor = false;
            btnContinuar.Click += btnContinuar_Click;
            // 
            // lblDialogo
            // 
            lblDialogo.AutoSize = true;
            lblDialogo.Font = new Font("MS UI Gothic", 13F);
            lblDialogo.ForeColor = Color.FromArgb(64, 0, 0);
            lblDialogo.Location = new Point(18, 53);
            lblDialogo.Name = "lblDialogo";
            lblDialogo.Size = new Size(63, 18);
            lblDialogo.TabIndex = 1;
            lblDialogo.Text = "Dialogo";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Press Start 2P", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombre.ForeColor = Color.FromArgb(64, 0, 0);
            lblNombre.Location = new Point(14, 15);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(301, 13);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Protagonista genérico";
            // 
            // pbxPersonaje
            // 
            pbxPersonaje.Location = new Point(30, 12);
            pbxPersonaje.Name = "pbxPersonaje";
            pbxPersonaje.Size = new Size(237, 414);
            pbxPersonaje.SizeMode = PictureBoxSizeMode.Zoom;
            pbxPersonaje.TabIndex = 3;
            pbxPersonaje.TabStop = false;
            // 
            // tmrTexto
            // 
            tmrTexto.Interval = 35;
            tmrTexto.Tick += tmrTexto_Tick;
            // 
            // FrmIntro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.GhostWhite;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlDialogo);
            Controls.Add(pbxPersonaje);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmIntro";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Introducción";
            Load += FrmIntro_Load;
            pnlDialogo.ResumeLayout(false);
            pnlDialogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxPersonaje).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDialogo;
        private Button btnContinuar;
        private Label lblDialogo;
        private Label lblNombre;
        private PictureBox pbxPersonaje;
        private System.Windows.Forms.Timer tmrTexto;
    }
}