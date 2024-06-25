
namespace Comparacion2024
{
    partial class frmMain
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.administrarUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.estacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.compararToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.baseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.Alarma = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvCarga = new System.Windows.Forms.DataGridView();
			this.dgvActions = new System.Windows.Forms.DataGridView();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.lblMonitor = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.lvlbeeper = new System.Windows.Forms.Label();
			this.lblcycle = new System.Windows.Forms.Label();
			this.lblBypass = new System.Windows.Forms.Label();
			this.lblCiclos = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarga)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.compararToolStripMenuItem,
            this.baseDeDatosToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(800, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
			// 
			// archivoToolStripMenuItem
			// 
			this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.administrarUsuariosToolStripMenuItem,
            this.estacionToolStripMenuItem});
			this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
			this.archivoToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
			this.archivoToolStripMenuItem.Text = "Configuracion";
			this.archivoToolStripMenuItem.Click += new System.EventHandler(this.archivoToolStripMenuItem_Click);
			// 
			// cargarToolStripMenuItem
			// 
			this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
			this.cargarToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.cargarToolStripMenuItem.Text = "Cargar";
			this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
			// 
			// administrarUsuariosToolStripMenuItem
			// 
			this.administrarUsuariosToolStripMenuItem.Name = "administrarUsuariosToolStripMenuItem";
			this.administrarUsuariosToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.administrarUsuariosToolStripMenuItem.Text = "Administrar Usuarios";
			this.administrarUsuariosToolStripMenuItem.Click += new System.EventHandler(this.administrarUsuariosToolStripMenuItem_Click);
			// 
			// estacionToolStripMenuItem
			// 
			this.estacionToolStripMenuItem.Name = "estacionToolStripMenuItem";
			this.estacionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.estacionToolStripMenuItem.Text = "Estacion";
			this.estacionToolStripMenuItem.Click += new System.EventHandler(this.estacionToolStripMenuItem_Click);
			// 
			// compararToolStripMenuItem
			// 
			this.compararToolStripMenuItem.Name = "compararToolStripMenuItem";
			this.compararToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
			this.compararToolStripMenuItem.Text = "Comparar";
			this.compararToolStripMenuItem.Click += new System.EventHandler(this.compararToolStripMenuItem_Click);
			// 
			// baseDeDatosToolStripMenuItem
			// 
			this.baseDeDatosToolStripMenuItem.Name = "baseDeDatosToolStripMenuItem";
			this.baseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
			this.baseDeDatosToolStripMenuItem.Text = "Base de Datos";
			this.baseDeDatosToolStripMenuItem.Click += new System.EventHandler(this.baseDeDatosToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Alarma
			// 
			this.Alarma.Enabled = true;
			this.Alarma.Interval = 1000;
			this.Alarma.Tick += new System.EventHandler(this.Alarma_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.Orange;
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(0, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(800, 61);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(-39, -67);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(279, 189);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 5;
			this.pictureBox1.TabStop = false;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(246, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(19, 25);
			this.label1.TabIndex = 4;
			this.label1.Text = "-";
			this.label1.Click += new System.EventHandler(this.label1_Click);
			// 
			// dgvCarga
			// 
			this.dgvCarga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvCarga.BackgroundColor = System.Drawing.Color.White;
			this.dgvCarga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCarga.Location = new System.Drawing.Point(12, 164);
			this.dgvCarga.Name = "dgvCarga";
			this.dgvCarga.Size = new System.Drawing.Size(776, 213);
			this.dgvCarga.TabIndex = 5;
			this.dgvCarga.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCarga_CellFormatting_1);
			// 
			// dgvActions
			// 
			this.dgvActions.BackgroundColor = System.Drawing.Color.White;
			this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvActions.Location = new System.Drawing.Point(12, 383);
			this.dgvActions.Name = "dgvActions";
			this.dgvActions.Size = new System.Drawing.Size(776, 152);
			this.dgvActions.TabIndex = 6;
			this.dgvActions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActions_CellFormatting);
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Gray;
			this.groupBox2.Controls.Add(this.pictureBox3);
			this.groupBox2.Controls.Add(this.pictureBox2);
			this.groupBox2.Controls.Add(this.lblMonitor);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.lvlbeeper);
			this.groupBox2.Controls.Add(this.lblcycle);
			this.groupBox2.Controls.Add(this.lblBypass);
			this.groupBox2.Controls.Add(this.lblCiclos);
			this.groupBox2.Location = new System.Drawing.Point(0, 81);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(800, 68);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Yellow;
			this.pictureBox3.Location = new System.Drawing.Point(6, 35);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(10, 27);
			this.pictureBox3.TabIndex = 16;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
			this.pictureBox2.Location = new System.Drawing.Point(6, 10);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(10, 27);
			this.pictureBox2.TabIndex = 15;
			this.pictureBox2.TabStop = false;
			// 
			// lblMonitor
			// 
			this.lblMonitor.AutoSize = true;
			this.lblMonitor.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblMonitor.Location = new System.Drawing.Point(394, 16);
			this.lblMonitor.Name = "lblMonitor";
			this.lblMonitor.Size = new System.Drawing.Size(301, 40);
			this.lblMonitor.TabIndex = 14;
			this.lblMonitor.Text = "MONITOREANDO";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Gray;
			this.label4.Location = new System.Drawing.Point(273, 52);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(72, 13);
			this.label4.TabIndex = 13;
			this.label4.Text = "HABILITAR";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Gray;
			this.label3.Location = new System.Drawing.Point(273, 29);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 13);
			this.label3.TabIndex = 12;
			this.label3.Text = "HABILITAR";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Gray;
			this.label2.Location = new System.Drawing.Point(273, 10);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "HABILITAR";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			this.label2.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
			// 
			// lvlbeeper
			// 
			this.lvlbeeper.AutoSize = true;
			this.lvlbeeper.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lvlbeeper.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lvlbeeper.ForeColor = System.Drawing.Color.Gray;
			this.lvlbeeper.Location = new System.Drawing.Point(165, 29);
			this.lvlbeeper.Name = "lvlbeeper";
			this.lvlbeeper.Size = new System.Drawing.Size(56, 13);
			this.lvlbeeper.TabIndex = 10;
			this.lvlbeeper.Text = "BEEPER";
			// 
			// lblcycle
			// 
			this.lblcycle.AutoSize = true;
			this.lblcycle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblcycle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblcycle.ForeColor = System.Drawing.Color.Gray;
			this.lblcycle.Location = new System.Drawing.Point(165, 52);
			this.lblcycle.Name = "lblcycle";
			this.lblcycle.Size = new System.Drawing.Size(89, 13);
			this.lblcycle.TabIndex = 10;
			this.lblcycle.Text = "PARAR-CICLO";
			// 
			// lblBypass
			// 
			this.lblBypass.AutoSize = true;
			this.lblBypass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.lblBypass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBypass.ForeColor = System.Drawing.Color.Gray;
			this.lblBypass.Location = new System.Drawing.Point(165, 10);
			this.lblBypass.Name = "lblBypass";
			this.lblBypass.Size = new System.Drawing.Size(63, 13);
			this.lblBypass.TabIndex = 9;
			this.lblBypass.Text = "KEYLOCK";
			this.lblBypass.Click += new System.EventHandler(this.lblBypass_Click);
			// 
			// lblCiclos
			// 
			this.lblCiclos.AutoSize = true;
			this.lblCiclos.Font = new System.Drawing.Font("MS Reference Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCiclos.Location = new System.Drawing.Point(16, 16);
			this.lblCiclos.Name = "lblCiclos";
			this.lblCiclos.Size = new System.Drawing.Size(38, 40);
			this.lblCiclos.TabIndex = 8;
			this.lblCiclos.Text = "0";
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(800, 540);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.dgvActions);
			this.Controls.Add(this.dgvCarga);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "frmMain";
			this.Text = "EBT";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.SizeChanged += new System.EventHandler(this.frmMain_SizeChanged);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarga)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActions)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compararToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrarUsuariosToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer Alarma;
		private System.Windows.Forms.ToolStripMenuItem estacionToolStripMenuItem;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvCarga;
		private System.Windows.Forms.DataGridView dgvActions;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label lvlbeeper;
		private System.Windows.Forms.Label lblcycle;
		private System.Windows.Forms.Label lblBypass;
		private System.Windows.Forms.Label lblCiclos;
		private System.Windows.Forms.Label lblMonitor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.ToolStripMenuItem baseDeDatosToolStripMenuItem;
	}
}