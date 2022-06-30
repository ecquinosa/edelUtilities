﻿namespace EdelUtilities
{
    partial class PagIbigApi
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
            this.button1 = new System.Windows.Forms.Button();
            this.cboEnvironment = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.BackColor = System.Drawing.Color.White;
            this.rtb.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb.Location = new System.Drawing.Point(9, 149);
            this.rtb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(492, 384);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            this.rtb.WordWrap = false;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(9, 116);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(70, 28);
            this.btnSubmit.TabIndex = 1;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pag-Ibig API";
            // 
            // txtMID
            // 
            this.txtMID.Location = new System.Drawing.Point(104, 82);
            this.txtMID.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMID.Name = "txtMID";
            this.txtMID.Size = new System.Drawing.Size(269, 20);
            this.txtMID.TabIndex = 3;
            this.txtMID.Text = "121027512933";
            // 
            // cboApi
            // 
            this.cboApi.FormattingEnabled = true;
            this.cboApi.Items.AddRange(new object[] {
            "ActiveCardInfo",
            "GetMemberInfo",
            "GetMemberMCRecord",
            "GetCardNo_AUB"});
            this.cboApi.Location = new System.Drawing.Point(104, 58);
            this.cboApi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboApi.Name = "cboApi";
            this.cboApi.Size = new System.Drawing.Size(269, 21);
            this.cboApi.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
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
            this.cboBank.Location = new System.Drawing.Point(104, 33);
            this.cboBank.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(269, 21);
            this.cboBank.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bank";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(428, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cboEnvironment
            // 
            this.cboEnvironment.FormattingEnabled = true;
            this.cboEnvironment.Items.AddRange(new object[] {
            "SIT",
            "PRE-PROD",
            "PROD"});
            this.cboEnvironment.Location = new System.Drawing.Point(104, 9);
            this.cboEnvironment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboEnvironment.Name = "cboEnvironment";
            this.cboEnvironment.Size = new System.Drawing.Size(269, 21);
            this.cboEnvironment.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 11);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ENVIRONMENT";
            // 
            // PagIbigApi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 542);
            this.Controls.Add(this.cboEnvironment);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboApi);
            this.Controls.Add(this.txtMID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rtb);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PagIbigApi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PAG-IBIG API";
            this.Load += new System.EventHandler(this.PagIbigApi_Load);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cboEnvironment;
        private System.Windows.Forms.Label label4;
    }
}