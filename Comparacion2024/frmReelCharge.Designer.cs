
namespace Comparacion2024
{
    partial class frmReelCharge
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtReelUserID = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.btnGetValue = new System.Windows.Forms.Button();
			this.txtreelvalue2 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtreelvalue1 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtReelID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFeeder = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkDisableLabel = new System.Windows.Forms.CheckBox();
			this.btnSetUP = new System.Windows.Forms.Button();
			this.ComboLabelID = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.checkShowSlot = new System.Windows.Forms.CheckBox();
			this.checkKeepUserID = new System.Windows.Forms.CheckBox();
			this.checkContinuousInput = new System.Windows.Forms.CheckBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnOkUp = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(74, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "No. Empleado";
			// 
			// txtReelUserID
			// 
			this.txtReelUserID.Location = new System.Drawing.Point(83, 19);
			this.txtReelUserID.Name = "txtReelUserID";
			this.txtReelUserID.Size = new System.Drawing.Size(184, 20);
			this.txtReelUserID.TabIndex = 1;
			this.txtReelUserID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReelUserID_KeyDown);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtReelUserID);
			this.groupBox1.Location = new System.Drawing.Point(24, 68);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(299, 62);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.btnGetValue);
			this.groupBox2.Controls.Add(this.txtreelvalue2);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.txtreelvalue1);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.txtReelID);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.txtFeeder);
			this.groupBox2.Location = new System.Drawing.Point(24, 136);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(299, 122);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Cargando";
			// 
			// btnGetValue
			// 
			this.btnGetValue.Location = new System.Drawing.Point(189, 81);
			this.btnGetValue.Name = "btnGetValue";
			this.btnGetValue.Size = new System.Drawing.Size(75, 23);
			this.btnGetValue.TabIndex = 4;
			this.btnGetValue.Text = "Get Value";
			this.btnGetValue.UseVisualStyleBackColor = true;
			// 
			// txtreelvalue2
			// 
			this.txtreelvalue2.Location = new System.Drawing.Point(140, 83);
			this.txtreelvalue2.Name = "txtreelvalue2";
			this.txtreelvalue2.ReadOnly = true;
			this.txtreelvalue2.Size = new System.Drawing.Size(40, 20);
			this.txtreelvalue2.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 86);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 5;
			this.label4.Text = "Valor";
			// 
			// txtreelvalue1
			// 
			this.txtreelvalue1.Location = new System.Drawing.Point(80, 83);
			this.txtreelvalue1.Name = "txtreelvalue1";
			this.txtreelvalue1.ReadOnly = true;
			this.txtreelvalue1.Size = new System.Drawing.Size(54, 20);
			this.txtreelvalue1.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Reel ID";
			// 
			// txtReelID
			// 
			this.txtReelID.Location = new System.Drawing.Point(80, 55);
			this.txtReelID.Name = "txtReelID";
			this.txtReelID.Size = new System.Drawing.Size(184, 20);
			this.txtReelID.TabIndex = 3;
			this.txtReelID.TextChanged += new System.EventHandler(this.txtReelID_TextChanged);
			this.txtReelID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReelID_KeyDown);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Feeder";
			// 
			// txtFeeder
			// 
			this.txtFeeder.Location = new System.Drawing.Point(80, 29);
			this.txtFeeder.Name = "txtFeeder";
			this.txtFeeder.Size = new System.Drawing.Size(184, 20);
			this.txtFeeder.TabIndex = 2;
			this.txtFeeder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFeeder_KeyDown);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkDisableLabel);
			this.groupBox3.Controls.Add(this.btnSetUP);
			this.groupBox3.Controls.Add(this.ComboLabelID);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Location = new System.Drawing.Point(30, 264);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(299, 93);
			this.groupBox3.TabIndex = 3;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Impresion Codigo de Barras";
			// 
			// checkDisableLabel
			// 
			this.checkDisableLabel.AutoSize = true;
			this.checkDisableLabel.Location = new System.Drawing.Point(143, 57);
			this.checkDisableLabel.Name = "checkDisableLabel";
			this.checkDisableLabel.Size = new System.Drawing.Size(124, 17);
			this.checkDisableLabel.TabIndex = 6;
			this.checkDisableLabel.Text = "Desactivar impresion";
			this.checkDisableLabel.UseVisualStyleBackColor = true;
			this.checkDisableLabel.CheckedChanged += new System.EventHandler(this.checkDisableLabel_CheckedChanged);
			// 
			// btnSetUP
			// 
			this.btnSetUP.Location = new System.Drawing.Point(21, 53);
			this.btnSetUP.Name = "btnSetUP";
			this.btnSetUP.Size = new System.Drawing.Size(75, 23);
			this.btnSetUP.TabIndex = 7;
			this.btnSetUP.Text = "Set-UP";
			this.btnSetUP.UseVisualStyleBackColor = true;
			// 
			// ComboLabelID
			// 
			this.ComboLabelID.FormattingEnabled = true;
			this.ComboLabelID.Location = new System.Drawing.Point(143, 29);
			this.ComboLabelID.Name = "ComboLabelID";
			this.ComboLabelID.Size = new System.Drawing.Size(121, 21);
			this.ComboLabelID.TabIndex = 5;
			this.ComboLabelID.SelectedIndexChanged += new System.EventHandler(this.ComboLabelID_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(23, 37);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Estilo de etiqueta";
			// 
			// checkShowSlot
			// 
			this.checkShowSlot.AutoSize = true;
			this.checkShowSlot.Location = new System.Drawing.Point(30, 363);
			this.checkShowSlot.Name = "checkShowSlot";
			this.checkShowSlot.Size = new System.Drawing.Size(195, 17);
			this.checkShowSlot.TabIndex = 8;
			this.checkShowSlot.Text = "Mostrar numero de slot en programa";
			this.checkShowSlot.UseVisualStyleBackColor = true;
			// 
			// checkKeepUserID
			// 
			this.checkKeepUserID.AutoSize = true;
			this.checkKeepUserID.Location = new System.Drawing.Point(30, 386);
			this.checkKeepUserID.Name = "checkKeepUserID";
			this.checkKeepUserID.Size = new System.Drawing.Size(288, 17);
			this.checkKeepUserID.TabIndex = 9;
			this.checkKeepUserID.Text = "Mantener No Empleado sin cambio durante el programa";
			this.checkKeepUserID.UseVisualStyleBackColor = true;
			// 
			// checkContinuousInput
			// 
			this.checkContinuousInput.AutoSize = true;
			this.checkContinuousInput.Location = new System.Drawing.Point(30, 409);
			this.checkContinuousInput.Name = "checkContinuousInput";
			this.checkContinuousInput.Size = new System.Drawing.Size(151, 17);
			this.checkContinuousInput.TabIndex = 10;
			this.checkContinuousInput.Text = "Modo de entrada continua";
			this.checkContinuousInput.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.White;
			this.pictureBox1.Location = new System.Drawing.Point(24, 25);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(299, 24);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.White;
			this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(131, 25);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(88, 24);
			this.label6.TabIndex = 8;
			this.label6.Text = "REEL ID";
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(20, 445);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 11;
			this.btnNext.Text = "Siguiente";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(101, 445);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(75, 23);
			this.btnClear.TabIndex = 12;
			this.btnClear.Text = "Limpiar";
			this.btnClear.UseVisualStyleBackColor = true;
			// 
			// btnOkUp
			// 
			this.btnOkUp.Location = new System.Drawing.Point(182, 445);
			this.btnOkUp.Name = "btnOkUp";
			this.btnOkUp.Size = new System.Drawing.Size(75, 23);
			this.btnOkUp.TabIndex = 13;
			this.btnOkUp.Text = " Ok/UP";
			this.btnOkUp.UseVisualStyleBackColor = true;
			this.btnOkUp.Click += new System.EventHandler(this.btnOkUp_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(263, 445);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 14;
			this.btnCancel.Text = "Cancelar";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmReelCharge
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(353, 489);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOkUp);
			this.Controls.Add(this.btnClear);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.checkContinuousInput);
			this.Controls.Add(this.checkKeepUserID);
			this.Controls.Add(this.checkShowSlot);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.Name = "frmReelCharge";
			this.Text = "Cargar Reel en Feeder";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmReelCharge_FormClosing);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmReelCharge_FormClosed);
			this.Load += new System.EventHandler(this.Form2_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReelUserID;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFeeder;
        private System.Windows.Forms.TextBox txtreelvalue2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtreelvalue1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtReelID;
        private System.Windows.Forms.Button btnGetValue;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ComboLabelID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkShowSlot;
        private System.Windows.Forms.CheckBox checkKeepUserID;
        private System.Windows.Forms.CheckBox checkContinuousInput;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkDisableLabel;
        private System.Windows.Forms.Button btnSetUP;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnOkUp;
        private System.Windows.Forms.Button btnCancel;
	}
}