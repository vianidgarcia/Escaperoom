namespace JuegoEscaperoom
{
    partial class FrmEscaperoom
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
            pbxEscena = new PictureBox();
            pnlDialogo = new Panel();
            pbxIconoPersonaje = new PictureBox();
            lblDialogo = new Label();
            btnPausa = new Button();
            tmrDialogo = new System.Windows.Forms.Timer(components);
            flpInventario = new FlowLayoutPanel();
            pnlInventario = new Panel();
            lblInventario = new Label();
            lblPuntaje = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxEscena).BeginInit();
            pnlDialogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoPersonaje).BeginInit();
            pnlInventario.SuspendLayout();
            SuspendLayout();
            // 
            // pbxEscena
            // 
            pbxEscena.Location = new Point(7, 35);
            pbxEscena.Name = "pbxEscena";
            pbxEscena.Size = new Size(794, 450);
            pbxEscena.SizeMode = PictureBoxSizeMode.Zoom;
            pbxEscena.TabIndex = 0;
            pbxEscena.TabStop = false;
            pbxEscena.MouseClick += pbxEscena_MouseClick;
            // 
            // pnlDialogo
            // 
            pnlDialogo.BorderStyle = BorderStyle.FixedSingle;
            pnlDialogo.Controls.Add(pbxIconoPersonaje);
            pnlDialogo.Controls.Add(lblDialogo);
            pnlDialogo.Location = new Point(19, 398);
            pnlDialogo.Name = "pnlDialogo";
            pnlDialogo.Size = new Size(768, 75);
            pnlDialogo.TabIndex = 3;
            // 
            // pbxIconoPersonaje
            // 
            pbxIconoPersonaje.Location = new Point(6, 6);
            pbxIconoPersonaje.Name = "pbxIconoPersonaje";
            pbxIconoPersonaje.Size = new Size(60, 60);
            pbxIconoPersonaje.TabIndex = 2;
            pbxIconoPersonaje.TabStop = false;
            // 
            // lblDialogo
            // 
            lblDialogo.AutoSize = true;
            lblDialogo.Font = new Font("MS UI Gothic", 13F);
            lblDialogo.Location = new Point(72, 11);
            lblDialogo.Name = "lblDialogo";
            lblDialogo.Size = new Size(63, 18);
            lblDialogo.TabIndex = 1;
            lblDialogo.Text = "Dialogo";
            // 
            // btnPausa
            // 
            btnPausa.BackColor = Color.Maroon;
            btnPausa.FlatStyle = FlatStyle.Popup;
            btnPausa.Font = new Font("Dogica", 9F);
            btnPausa.ForeColor = SystemColors.ControlLightLight;
            btnPausa.Location = new Point(904, 7);
            btnPausa.Name = "btnPausa";
            btnPausa.Size = new Size(87, 23);
            btnPausa.TabIndex = 4;
            btnPausa.Text = "Pausa";
            btnPausa.UseVisualStyleBackColor = false;
            btnPausa.Click += btnPausa_Click;
            // 
            // tmrDialogo
            // 
            tmrDialogo.Interval = 25;
            tmrDialogo.Tick += tmrDialogo_Tick;
            // 
            // flpInventario
            // 
            flpInventario.Location = new Point(12, 38);
            flpInventario.Name = "flpInventario";
            flpInventario.Size = new Size(145, 390);
            flpInventario.TabIndex = 5;
            // 
            // pnlInventario
            // 
            pnlInventario.BackColor = Color.Brown;
            pnlInventario.Controls.Add(flpInventario);
            pnlInventario.Controls.Add(lblInventario);
            pnlInventario.Location = new Point(815, 36);
            pnlInventario.Name = "pnlInventario";
            pnlInventario.Size = new Size(178, 449);
            pnlInventario.TabIndex = 4;
            // 
            // lblInventario
            // 
            lblInventario.AutoSize = true;
            lblInventario.Font = new Font("Press Start 2P", 9.75F, FontStyle.Bold);
            lblInventario.ForeColor = SystemColors.ControlLightLight;
            lblInventario.Location = new Point(10, 13);
            lblInventario.Name = "lblInventario";
            lblInventario.Size = new Size(147, 13);
            lblInventario.TabIndex = 1;
            lblInventario.Text = "Inventario";
            // 
            // lblPuntaje
            // 
            lblPuntaje.AutoSize = true;
            lblPuntaje.Font = new Font("MS UI Gothic", 13F);
            lblPuntaje.Location = new Point(12, 10);
            lblPuntaje.Name = "lblPuntaje";
            lblPuntaje.Size = new Size(60, 18);
            lblPuntaje.TabIndex = 5;
            lblPuntaje.Text = "Puntos";
            // 
            // FrmEscaperoom
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(1000, 491);
            Controls.Add(lblPuntaje);
            Controls.Add(pnlInventario);
            Controls.Add(btnPausa);
            Controls.Add(pnlDialogo);
            Controls.Add(pbxEscena);
            Name = "FrmEscaperoom";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmEscaperoom";
            FormClosing += FrmEscaperoom_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pbxEscena).EndInit();
            pnlDialogo.ResumeLayout(false);
            pnlDialogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxIconoPersonaje).EndInit();
            pnlInventario.ResumeLayout(false);
            pnlInventario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxEscena;
        private Panel pnlDialogo;
        private Label lblDialogo;
        private Button btnPausa;
        private System.Windows.Forms.Timer tmrDialogo;
        private FlowLayoutPanel flpInventario;
        private Panel pnlInventario;
        private Label lblInventario;
        private PictureBox pbxIconoPersonaje;
        private Label lblPuntaje;
    }
}