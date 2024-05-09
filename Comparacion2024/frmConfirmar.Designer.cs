
namespace Comparacion2024
{
    partial class frmConfirmar
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
            this.txtConfNum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtConfNum
            // 
            this.txtConfNum.Location = new System.Drawing.Point(70, 26);
            this.txtConfNum.Name = "txtConfNum";
            this.txtConfNum.Size = new System.Drawing.Size(276, 20);
            this.txtConfNum.TabIndex = 0;
            this.txtConfNum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtConfNum_KeyDown);
            // 
            // frmConfirmar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 81);
            this.Controls.Add(this.txtConfNum);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConfirmar";
            this.Text = "ConfirmarNumParte";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfirmar_FormClosing);
            this.Load += new System.EventHandler(this.frmConfirmar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConfNum;
    }
}