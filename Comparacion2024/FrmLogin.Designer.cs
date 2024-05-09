
namespace Comparacion2024
{
    partial class FrmLogin
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
			this.txtUserLogin = new System.Windows.Forms.TextBox();
			this.txtPasswordLog = new System.Windows.Forms.TextBox();
			this.lblUser = new System.Windows.Forms.Label();
			this.lblPassLog = new System.Windows.Forms.Label();
			this.groupLogin = new System.Windows.Forms.GroupBox();
			this.btnLoginOK = new System.Windows.Forms.Button();
			this.btnLogCancel = new System.Windows.Forms.Button();
			this.groupLogin.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtUserLogin
			// 
			this.txtUserLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtUserLogin.Location = new System.Drawing.Point(205, 36);
			this.txtUserLogin.Multiline = true;
			this.txtUserLogin.Name = "txtUserLogin";
			this.txtUserLogin.Size = new System.Drawing.Size(194, 33);
			this.txtUserLogin.TabIndex = 0;
			// 
			// txtPasswordLog
			// 
			this.txtPasswordLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPasswordLog.Location = new System.Drawing.Point(205, 86);
			this.txtPasswordLog.Multiline = true;
			this.txtPasswordLog.Name = "txtPasswordLog";
			this.txtPasswordLog.PasswordChar = '*';
			this.txtPasswordLog.Size = new System.Drawing.Size(194, 36);
			this.txtPasswordLog.TabIndex = 1;
			this.txtPasswordLog.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPasswordLog_KeyDown);
			// 
			// lblUser
			// 
			this.lblUser.AutoSize = true;
			this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblUser.Location = new System.Drawing.Point(80, 36);
			this.lblUser.Name = "lblUser";
			this.lblUser.Size = new System.Drawing.Size(119, 25);
			this.lblUser.TabIndex = 4;
			this.lblUser.Text = "User Name";
			// 
			// lblPassLog
			// 
			this.lblPassLog.AutoSize = true;
			this.lblPassLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPassLog.Location = new System.Drawing.Point(84, 86);
			this.lblPassLog.Name = "lblPassLog";
			this.lblPassLog.Size = new System.Drawing.Size(106, 25);
			this.lblPassLog.TabIndex = 5;
			this.lblPassLog.Text = "Password";
			// 
			// groupLogin
			// 
			this.groupLogin.Controls.Add(this.txtUserLogin);
			this.groupLogin.Controls.Add(this.txtPasswordLog);
			this.groupLogin.Controls.Add(this.lblUser);
			this.groupLogin.Controls.Add(this.lblPassLog);
			this.groupLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupLogin.Location = new System.Drawing.Point(30, 31);
			this.groupLogin.Name = "groupLogin";
			this.groupLogin.Size = new System.Drawing.Size(420, 142);
			this.groupLogin.TabIndex = 8;
			this.groupLogin.TabStop = false;
			this.groupLogin.Text = "User Login";
			// 
			// btnLoginOK
			// 
			this.btnLoginOK.Location = new System.Drawing.Point(30, 195);
			this.btnLoginOK.Name = "btnLoginOK";
			this.btnLoginOK.Size = new System.Drawing.Size(262, 39);
			this.btnLoginOK.TabIndex = 10;
			this.btnLoginOK.Text = "OK";
			this.btnLoginOK.UseVisualStyleBackColor = true;
			this.btnLoginOK.Click += new System.EventHandler(this.btnLoginOK_Click);
			// 
			// btnLogCancel
			// 
			this.btnLogCancel.Location = new System.Drawing.Point(312, 195);
			this.btnLogCancel.Name = "btnLogCancel";
			this.btnLogCancel.Size = new System.Drawing.Size(138, 39);
			this.btnLogCancel.TabIndex = 11;
			this.btnLogCancel.Text = "Cancel";
			this.btnLogCancel.UseVisualStyleBackColor = true;
			this.btnLogCancel.Click += new System.EventHandler(this.btnLogCancel_Click_1);
			// 
			// FrmLogin
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 258);
			this.Controls.Add(this.btnLogCancel);
			this.Controls.Add(this.btnLoginOK);
			this.Controls.Add(this.groupLogin);
			this.MaximizeBox = false;
			this.Name = "FrmLogin";
			this.Text = "Login";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.groupLogin.ResumeLayout(false);
			this.groupLogin.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserLogin;
        private System.Windows.Forms.TextBox txtPasswordLog;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPassLog;
        private System.Windows.Forms.GroupBox groupLogin;
        private System.Windows.Forms.Button btnLoginOK;
        private System.Windows.Forms.Button btnLogCancel;
    }
}

