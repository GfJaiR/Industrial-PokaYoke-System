
namespace Comparacion2024
{
    partial class CrudReel
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
			this.dgvReel = new System.Windows.Forms.DataGridView();
			this.btnAgregar = new System.Windows.Forms.Button();
			this.btnModificar = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtBusqueda = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnCargarStenciles = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvReel)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvReel
			// 
			this.dgvReel.BackgroundColor = System.Drawing.Color.White;
			this.dgvReel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvReel.Location = new System.Drawing.Point(12, 112);
			this.dgvReel.Name = "dgvReel";
			this.dgvReel.Size = new System.Drawing.Size(923, 242);
			this.dgvReel.TabIndex = 0;
			this.dgvReel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvReel_CellContentClick);
			// 
			// btnAgregar
			// 
			this.btnAgregar.Location = new System.Drawing.Point(277, 12);
			this.btnAgregar.Name = "btnAgregar";
			this.btnAgregar.Size = new System.Drawing.Size(127, 47);
			this.btnAgregar.TabIndex = 1;
			this.btnAgregar.Text = "Agregar Pasta o Stencil";
			this.btnAgregar.UseVisualStyleBackColor = true;
			this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
			// 
			// btnModificar
			// 
			this.btnModificar.Location = new System.Drawing.Point(410, 12);
			this.btnModificar.Name = "btnModificar";
			this.btnModificar.Size = new System.Drawing.Size(127, 47);
			this.btnModificar.TabIndex = 2;
			this.btnModificar.Text = "Modificar";
			this.btnModificar.UseVisualStyleBackColor = true;
			this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(543, 12);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(127, 47);
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Borrar";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 368);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(220, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Click al encabezado para ordenar la columna";
			// 
			// txtBusqueda
			// 
			this.txtBusqueda.Location = new System.Drawing.Point(57, 75);
			this.txtBusqueda.Name = "txtBusqueda";
			this.txtBusqueda.Size = new System.Drawing.Size(878, 20);
			this.txtBusqueda.TabIndex = 5;
			this.txtBusqueda.TextChanged += new System.EventHandler(this.txtBusqueda_TextChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(808, 12);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(127, 47);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 78);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Buscar";
			// 
			// btnRefresh
			// 
			this.btnRefresh.Location = new System.Drawing.Point(675, 12);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(127, 47);
			this.btnRefresh.TabIndex = 10;
			this.btnRefresh.Text = "Refrescar Tabla";
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnCargarStenciles
			// 
			this.btnCargarStenciles.Location = new System.Drawing.Point(11, 12);
			this.btnCargarStenciles.Name = "btnCargarStenciles";
			this.btnCargarStenciles.Size = new System.Drawing.Size(127, 47);
			this.btnCargarStenciles.TabIndex = 11;
			this.btnCargarStenciles.Text = "Cargar Stenciles";
			this.btnCargarStenciles.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(144, 12);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(127, 47);
			this.button2.TabIndex = 12;
			this.button2.Text = "Cargar Pastas";
			this.button2.UseVisualStyleBackColor = true;
	
			// 
			// CrudReel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(947, 391);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.btnCargarStenciles);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtBusqueda);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnModificar);
			this.Controls.Add(this.btnAgregar);
			this.Controls.Add(this.dgvReel);
			this.MinimizeBox = false;
			this.Name = "CrudReel";
			this.Text = "Base de Datos - Stenciles y Pastas";
			this.Load += new System.EventHandler(this.CrudReel_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgvReel)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvReel;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnCargarStenciles;
		private System.Windows.Forms.Button button2;
	}
}