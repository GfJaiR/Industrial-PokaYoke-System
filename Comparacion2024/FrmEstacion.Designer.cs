
namespace Comparacion2024
{
	partial class FrmEstacion
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
			this.txtNombreEstacion = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnGuardar = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtNombreEstacion
			// 
			this.txtNombreEstacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNombreEstacion.Location = new System.Drawing.Point(26, 59);
			this.txtNombreEstacion.Name = "txtNombreEstacion";
			this.txtNombreEstacion.Size = new System.Drawing.Size(376, 26);
			this.txtNombreEstacion.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(85, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(239, 20);
			this.label1.TabIndex = 1;
			this.label1.Text = "Ingrese el nombre de la estacion";
			// 
			// btnGuardar
			// 
			this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGuardar.Location = new System.Drawing.Point(163, 91);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(92, 30);
			this.btnGuardar.TabIndex = 3;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.UseVisualStyleBackColor = true;
			this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
			// 
			// FrmEstacion
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(414, 133);
			this.Controls.Add(this.btnGuardar);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNombreEstacion);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmEstacion";
			this.Text = "Configurar Estacion";
			this.Load += new System.EventHandler(this.FrmEstacion_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtNombreEstacion;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnGuardar;
	}
}