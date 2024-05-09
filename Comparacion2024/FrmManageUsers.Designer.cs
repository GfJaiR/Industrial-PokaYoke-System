
namespace Comparacion2024
{
    partial class FrmManageUsers
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkAdm = new System.Windows.Forms.CheckBox();
			this.btnCreate = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtConfirmarContrasena = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.txtContrasena = new System.Windows.Forms.TextBox();
			this.txtUsername = new System.Windows.Forms.TextBox();
			this.dgvUsuarios = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEliminarUsuario = new System.Windows.Forms.Button();
			this.txtBuscarUsuario = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.menuAdmin = new System.Windows.Forms.MenuStrip();
			this.pantallaDeInicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
			this.menuAdmin.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkAdm);
			this.groupBox1.Controls.Add(this.btnCreate);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtConfirmarContrasena);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtContrasena);
			this.groupBox1.Controls.Add(this.txtUsername);
			this.groupBox1.Location = new System.Drawing.Point(12, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(327, 209);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Crear Usuario";
			// 
			// chkAdm
			// 
			this.chkAdm.AutoSize = true;
			this.chkAdm.Location = new System.Drawing.Point(88, 35);
			this.chkAdm.Name = "chkAdm";
			this.chkAdm.Size = new System.Drawing.Size(146, 17);
			this.chkAdm.TabIndex = 11;
			this.chkAdm.Text = "Asignar Rol Administrador";
			this.chkAdm.UseVisualStyleBackColor = true;
			this.chkAdm.CheckedChanged += new System.EventHandler(this.chkAdm_CheckedChanged);
			// 
			// btnCreate
			// 
			this.btnCreate.Location = new System.Drawing.Point(113, 174);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(75, 29);
			this.btnCreate.TabIndex = 10;
			this.btnCreate.Text = "Crear";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 151);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(108, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Confirmar Contrasena";
			// 
			// txtConfirmarContrasena
			// 
			this.txtConfirmarContrasena.Location = new System.Drawing.Point(142, 148);
			this.txtConfirmarContrasena.Name = "txtConfirmarContrasena";
			this.txtConfirmarContrasena.Size = new System.Drawing.Size(100, 20);
			this.txtConfirmarContrasena.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(52, 118);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(61, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Contrasena";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(38, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(98, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nombre de Usuario";
			// 
			// txtContrasena
			// 
			this.txtContrasena.Location = new System.Drawing.Point(142, 111);
			this.txtContrasena.Name = "txtContrasena";
			this.txtContrasena.Size = new System.Drawing.Size(100, 20);
			this.txtContrasena.TabIndex = 2;
			// 
			// txtUsername
			// 
			this.txtUsername.Location = new System.Drawing.Point(142, 74);
			this.txtUsername.Name = "txtUsername";
			this.txtUsername.Size = new System.Drawing.Size(100, 20);
			this.txtUsername.TabIndex = 1;
			// 
			// dgvUsuarios
			// 
			this.dgvUsuarios.BackgroundColor = System.Drawing.Color.White;
			this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsuarios.GridColor = System.Drawing.Color.Black;
			this.dgvUsuarios.Location = new System.Drawing.Point(378, 48);
			this.dgvUsuarios.Name = "dgvUsuarios";
			this.dgvUsuarios.Size = new System.Drawing.Size(362, 209);
			this.dgvUsuarios.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(525, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Usuarios";
			// 
			// btnEliminarUsuario
			// 
			this.btnEliminarUsuario.Location = new System.Drawing.Point(560, 263);
			this.btnEliminarUsuario.Name = "btnEliminarUsuario";
			this.btnEliminarUsuario.Size = new System.Drawing.Size(180, 44);
			this.btnEliminarUsuario.TabIndex = 5;
			this.btnEliminarUsuario.Text = "Eliminar Usuario Seleccionado";
			this.btnEliminarUsuario.UseVisualStyleBackColor = true;
			this.btnEliminarUsuario.Click += new System.EventHandler(this.btnEliminarUsuario_Click);
			// 
			// txtBuscarUsuario
			// 
			this.txtBuscarUsuario.Location = new System.Drawing.Point(454, 276);
			this.txtBuscarUsuario.Name = "txtBuscarUsuario";
			this.txtBuscarUsuario.Size = new System.Drawing.Size(100, 20);
			this.txtBuscarUsuario.TabIndex = 6;
			this.txtBuscarUsuario.TextChanged += new System.EventHandler(this.txtBuscarUsuario_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(369, 279);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 13);
			this.label6.TabIndex = 7;
			this.label6.Text = "Buscar Usuario";
			// 
			// menuAdmin
			// 
			this.menuAdmin.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pantallaDeInicioToolStripMenuItem});
			this.menuAdmin.Location = new System.Drawing.Point(0, 0);
			this.menuAdmin.Name = "menuAdmin";
			this.menuAdmin.Size = new System.Drawing.Size(762, 24);
			this.menuAdmin.TabIndex = 9;
			this.menuAdmin.Text = "menuStrip2";
			// 
			// pantallaDeInicioToolStripMenuItem
			// 
			this.pantallaDeInicioToolStripMenuItem.Name = "pantallaDeInicioToolStripMenuItem";
			this.pantallaDeInicioToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
			this.pantallaDeInicioToolStripMenuItem.Text = "Pantalla de inicio";
			this.pantallaDeInicioToolStripMenuItem.Click += new System.EventHandler(this.pantallaDeInicioToolStripMenuItem_Click);
			// 
			// FrmManageUsers
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(762, 343);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtBuscarUsuario);
			this.Controls.Add(this.btnEliminarUsuario);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvUsuarios);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuAdmin);
			this.MaximizeBox = false;
			this.Name = "FrmManageUsers";
			this.Text = "Admin Interfaz";
			this.Load += new System.EventHandler(this.FrmManageUsers_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
			this.menuAdmin.ResumeLayout(false);
			this.menuAdmin.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtConfirmarContrasena;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEliminarUsuario;
        private System.Windows.Forms.TextBox txtBuscarUsuario;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.CheckBox chkAdm;
        private System.Windows.Forms.MenuStrip menuAdmin;
        private System.Windows.Forms.ToolStripMenuItem pantallaDeInicioToolStripMenuItem;
    }
}