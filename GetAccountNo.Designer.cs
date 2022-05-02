namespace EdelUtilities
{
    partial class GetAccountNo
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMID = new System.Windows.Forms.TextBox();
            this.cboApi = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboEnvironment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFirst = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMiddle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLast = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDOB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.BackColor = System.Drawing.Color.White;
            this.rtb.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb.Location = new System.Drawing.Point(12, 290);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(654, 365);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            this.rtb.WordWrap = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(12, 250);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 34);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pag-Ibig API";
            // 
            // txtMID
            // 
            this.txtMID.Location = new System.Drawing.Point(138, 101);
            this.txtMID.Name = "txtMID";
            this.txtMID.Size = new System.Drawing.Size(357, 22);
            this.txtMID.TabIndex = 3;
            this.txtMID.Text = "121027512933";
            // 
            // cboApi
            // 
            this.cboApi.Enabled = false;
            this.cboApi.FormattingEnabled = true;
            this.cboApi.Items.AddRange(new object[] {
            "ActiveCardInfo",
            "GetMemberInfo",
            "GetMemberMCRecord",
            "GetCardNo_AUB"});
            this.cboApi.Location = new System.Drawing.Point(138, 71);
            this.cboApi.Name = "cboApi";
            this.cboApi.Size = new System.Drawing.Size(357, 24);
            this.cboApi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "MID";
            // 
            // cboBank
            // 
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Items.AddRange(new object[] {
            "UBP",
            "AUB",
            "RBANK"});
            this.cboBank.Location = new System.Drawing.Point(138, 41);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(357, 24);
            this.cboBank.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bank";
            // 
            // cboEnvironment
            // 
            this.cboEnvironment.Enabled = false;
            this.cboEnvironment.FormattingEnabled = true;
            this.cboEnvironment.Items.AddRange(new object[] {
            "SIT",
            "PROD"});
            this.cboEnvironment.Location = new System.Drawing.Point(138, 11);
            this.cboEnvironment.Name = "cboEnvironment";
            this.cboEnvironment.Size = new System.Drawing.Size(357, 24);
            this.cboEnvironment.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "ENVIRONMENT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 17);
            this.label5.TabIndex = 12;
            this.label5.Text = "First";
            // 
            // txtFirst
            // 
            this.txtFirst.Location = new System.Drawing.Point(138, 129);
            this.txtFirst.Name = "txtFirst";
            this.txtFirst.Size = new System.Drawing.Size(357, 22);
            this.txtFirst.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Middle";
            // 
            // txtMiddle
            // 
            this.txtMiddle.Location = new System.Drawing.Point(138, 157);
            this.txtMiddle.Name = "txtMiddle";
            this.txtMiddle.Size = new System.Drawing.Size(357, 22);
            this.txtMiddle.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Last";
            // 
            // txtLast
            // 
            this.txtLast.Location = new System.Drawing.Point(138, 185);
            this.txtLast.Name = "txtLast";
            this.txtLast.Size = new System.Drawing.Size(357, 22);
            this.txtLast.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Birth Date";
            // 
            // txtDOB
            // 
            this.txtDOB.Location = new System.Drawing.Point(138, 213);
            this.txtDOB.Name = "txtDOB";
            this.txtDOB.Size = new System.Drawing.Size(357, 22);
            this.txtDOB.TabIndex = 17;
            // 
            // GetAccountNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 667);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtDOB);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtLast);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMiddle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFirst);
            this.Controls.Add(this.cboEnvironment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboApi);
            this.Controls.Add(this.txtMID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rtb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GetAccountNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Get Account No.";
            this.Load += new System.EventHandler(this.GetAccountNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMID;
        private System.Windows.Forms.ComboBox cboApi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboEnvironment;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFirst;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMiddle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLast;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDOB;
    }
}