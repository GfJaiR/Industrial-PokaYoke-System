
namespace Comparacion2024
{
	partial class frmEditar
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
			this.txtUserID = new System.Windows.Forms.TextBox();
			this.txtReelID = new System.Windows.Forms.TextBox();
			this.txtPartNo = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtUserID
			// 
			this.txtUserID.Location = new System.Drawing.Point(69, 24);
			this.txtUserID.Name = "txtUserID";
			this.txtUserID.Size = new System.Drawing.Size(186, 20);
			this.txtUserID.TabIndex = 0;
			// 
			// txtReelID
			// 
			this.txtReelID.Location = new System.Drawing.Point(69, 63);
			this.txtReelID.Name = "txtReelID";
			this.txtReelID.Size = new System.Drawing.Size(186, 20);
			this.txtReelID.TabIndex = 1;
			// 
			// txtPartNo
			// 
			this.txtPartNo.Location = new System.Drawing.Point(69, 101);
			this.txtPartNo.Name = "txtPartNo";
			this.txtPartNo.Size = new System.Drawing.Size(186, 20);
			this.txtPartNo.TabIndex = 2;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(69, 144);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(186, 20);
			this.txtQuantity.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(23, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "UserID";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(23, 66);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "ReelID";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(23, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "PartNo";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(23, 147);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(46, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Quantity";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(109, 194);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Text = "Ok";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmEditar
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(300, 255);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtQuantity);
			this.Controls.Add(this.txtPartNo);
			this.Controls.Add(this.txtReelID);
			this.Controls.Add(this.txtUserID);
			this.Name = "frmEditar";
			this.Text = "Editar Stencil/Pasta";
			this.Load += new System.EventHandler(this.frmEditar_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.TextBox txtReelID;
		private System.Windows.Forms.TextBox txtPartNo;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnOK;
	}
}