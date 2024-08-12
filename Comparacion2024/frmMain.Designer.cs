
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
			this.label5 = new System.Windows.Forms.Label();
			this.pictureStencil = new System.Windows.Forms.PictureBox();
			this.picturePasta2 = new System.Windows.Forms.PictureBox();
			this.picturePasta1 = new System.Windows.Forms.PictureBox();
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
			this.updateTimer = new System.Windows.Forms.Timer(this.components);
			this.pictureCOM = new System.Windows.Forms.PictureBox();
			this.label8 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label9 = new System.Windows.Forms.Label();
			this.pictureCiclos = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvCarga)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvActions)).BeginInit();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureStencil)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picturePasta2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picturePasta1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureCOM)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureCiclos)).BeginInit();
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
			this.menuStrip1.Size = new System.Drawing.Size(882, 24);
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
			this.groupBox1.Controls.Add(this.tableLayoutPanel2);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(0, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(882, 71);
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
			this.dgvCarga.Location = new System.Drawing.Point(12, 179);
			this.dgvCarga.Name = "dgvCarga";
			this.dgvCarga.Size = new System.Drawing.Size(867, 198);
			this.dgvCarga.TabIndex = 5;
			this.dgvCarga.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCarga_CellFormatting_1);
			// 
			// dgvActions
			// 
			this.dgvActions.BackgroundColor = System.Drawing.Color.White;
			this.dgvActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvActions.Location = new System.Drawing.Point(12, 383);
			this.dgvActions.Name = "dgvActions";
			this.dgvActions.Size = new System.Drawing.Size(867, 152);
			this.dgvActions.TabIndex = 6;
			this.dgvActions.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvActions_CellFormatting);
			// 
			// groupBox2
			// 
			this.groupBox2.BackColor = System.Drawing.Color.Gray;
			this.groupBox2.Controls.Add(this.tableLayoutPanel1);
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
			this.groupBox2.Location = new System.Drawing.Point(0, 94);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(882, 85);
			this.groupBox2.TabIndex = 7;
			this.groupBox2.TabStop = false;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(3, 32);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(40, 13);
			this.label5.TabIndex = 20;
			this.label5.Text = "Pasta1";
			// 
			// pictureStencil
			// 
			this.pictureStencil.Location = new System.Drawing.Point(115, 3);
			this.pictureStencil.Name = "pictureStencil";
			this.pictureStencil.Size = new System.Drawing.Size(39, 26);
			this.pictureStencil.TabIndex = 19;
			this.pictureStencil.TabStop = false;
			// 
			// picturePasta2
			// 
			this.picturePasta2.Location = new System.Drawing.Point(59, 3);
			this.picturePasta2.Name = "picturePasta2";
			this.picturePasta2.Size = new System.Drawing.Size(39, 26);
			this.picturePasta2.TabIndex = 18;
			this.picturePasta2.TabStop = false;
			// 
			// picturePasta1
			// 
			this.picturePasta1.Location = new System.Drawing.Point(3, 3);
			this.picturePasta1.Name = "picturePasta1";
			this.picturePasta1.Size = new System.Drawing.Size(40, 26);
			this.picturePasta1.TabIndex = 17;
			this.picturePasta1.TabStop = false;
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
			this.lblMonitor.Location = new System.Drawing.Point(351, 28);
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
			// updateTimer
			// 
			this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
			// 
			// pictureCOM
			// 
			this.pictureCOM.Location = new System.Drawing.Point(3, 3);
			this.pictureCOM.Name = "pictureCOM";
			this.pictureCOM.Size = new System.Drawing.Size(41, 29);
			this.pictureCOM.TabIndex = 23;
			this.pictureCOM.TabStop = false;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(3, 35);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(37, 13);
			this.label8.TabIndex = 24;
			this.label8.Text = "  COM";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
			this.tableLayoutPanel1.Controls.Add(this.picturePasta1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.picturePasta2, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.pictureStencil, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label6, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label9, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.label7, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.pictureCiclos, 3, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(667, 16);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.64865F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.35135F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(212, 66);
			this.tableLayoutPanel1.TabIndex = 23;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(59, 32);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Pasta2";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(115, 32);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 13);
			this.label7.TabIndex = 22;
			this.label7.Text = "Stencil";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
			this.tableLayoutPanel2.Controls.Add(this.pictureCOM, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.label8, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(832, 16);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(47, 52);
			this.tableLayoutPanel2.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(165, 32);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Ciclos";
			// 
			// pictureCiclos
			// 
			this.pictureCiclos.Location = new System.Drawing.Point(165, 3);
			this.pictureCiclos.Name = "pictureCiclos";
			this.pictureCiclos.Size = new System.Drawing.Size(39, 26);
			this.pictureCiclos.TabIndex = 23;
			this.pictureCiclos.TabStop = false;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(882, 540);
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
			((System.ComponentModel.ISupportInitialize)(this.pictureStencil)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picturePasta2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picturePasta1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureCOM)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureCiclos)).EndInit();
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
		private System.Windows.Forms.PictureBox pictureStencil;
		private System.Windows.Forms.PictureBox picturePasta2;
		private System.Windows.Forms.PictureBox picturePasta1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Timer updateTimer;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox pictureCOM;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.PictureBox pictureCiclos;
		private System.Windows.Forms.Label label9;
	}
}