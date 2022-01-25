namespace EdelUtilities
{
    partial class AddSingleDoubleQuote
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.rtb1 = new System.Windows.Forms.RichTextBox();
            this.rtb2 = new System.Windows.Forms.RichTextBox();
            this.chkSingle = new System.Windows.Forms.CheckBox();
            this.chkDouble = new System.Windows.Forms.CheckBox();
            this.chkRemoveCommaLast = new System.Windows.Forms.CheckBox();
            this.chkAddComma = new System.Windows.Forms.CheckBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 501);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(93, 29);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "PROCESS";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // rtb1
            // 
            this.rtb1.Location = new System.Drawing.Point(12, 42);
            this.rtb1.Name = "rtb1";
            this.rtb1.Size = new System.Drawing.Size(274, 368);
            this.rtb1.TabIndex = 1;
            this.rtb1.Text = "";
            this.rtb1.WordWrap = false;
            // 
            // rtb2
            // 
            this.rtb2.BackColor = System.Drawing.Color.White;
            this.rtb2.Location = new System.Drawing.Point(292, 42);
            this.rtb2.Name = "rtb2";
            this.rtb2.ReadOnly = true;
            this.rtb2.Size = new System.Drawing.Size(274, 368);
            this.rtb2.TabIndex = 2;
            this.rtb2.Text = "";
            this.rtb2.WordWrap = false;
            // 
            // chkSingle
            // 
            this.chkSingle.AutoSize = true;
            this.chkSingle.Checked = true;
            this.chkSingle.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSingle.Location = new System.Drawing.Point(12, 429);
            this.chkSingle.Name = "chkSingle";
            this.chkSingle.Size = new System.Drawing.Size(104, 20);
            this.chkSingle.TabIndex = 4;
            this.chkSingle.Text = "Single quote";
            this.chkSingle.UseVisualStyleBackColor = true;
            this.chkSingle.CheckedChanged += new System.EventHandler(this.chkSingle_CheckedChanged);
            // 
            // chkDouble
            // 
            this.chkDouble.AutoSize = true;
            this.chkDouble.Location = new System.Drawing.Point(163, 429);
            this.chkDouble.Name = "chkDouble";
            this.chkDouble.Size = new System.Drawing.Size(110, 20);
            this.chkDouble.TabIndex = 5;
            this.chkDouble.Text = "Double quote";
            this.chkDouble.UseVisualStyleBackColor = true;
            this.chkDouble.CheckedChanged += new System.EventHandler(this.chkDouble_CheckedChanged);
            // 
            // chkRemoveCommaLast
            // 
            this.chkRemoveCommaLast.AutoSize = true;
            this.chkRemoveCommaLast.Checked = true;
            this.chkRemoveCommaLast.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveCommaLast.Location = new System.Drawing.Point(12, 455);
            this.chkRemoveCommaLast.Name = "chkRemoveCommaLast";
            this.chkRemoveCommaLast.Size = new System.Drawing.Size(213, 20);
            this.chkRemoveCommaLast.TabIndex = 7;
            this.chkRemoveCommaLast.Text = "Remove comma on last record";
            this.chkRemoveCommaLast.UseVisualStyleBackColor = true;
            // 
            // chkAddComma
            // 
            this.chkAddComma.AutoSize = true;
            this.chkAddComma.Checked = true;
            this.chkAddComma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddComma.Location = new System.Drawing.Point(320, 429);
            this.chkAddComma.Name = "chkAddComma";
            this.chkAddComma.Size = new System.Drawing.Size(102, 20);
            this.chkAddComma.TabIndex = 6;
            this.chkAddComma.Text = "Add comma";
            this.chkAddComma.UseVisualStyleBackColor = true;
            this.chkAddComma.CheckedChanged += new System.EventHandler(this.chkAddComma_CheckedChanged);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(498, 9);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(69, 29);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // AddSingleDoubleQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 542);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.chkRemoveCommaLast);
            this.Controls.Add(this.chkAddComma);
            this.Controls.Add(this.chkDouble);
            this.Controls.Add(this.chkSingle);
            this.Controls.Add(this.rtb2);
            this.Controls.Add(this.rtb1);
            this.Controls.Add(this.btnProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AddSingleDoubleQuote";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Single/ Double Quote";
            this.Load += new System.EventHandler(this.AddSingleDoubleQuote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.RichTextBox rtb1;
        private System.Windows.Forms.RichTextBox rtb2;
        private System.Windows.Forms.CheckBox chkSingle;
        private System.Windows.Forms.CheckBox chkDouble;
        private System.Windows.Forms.CheckBox chkRemoveCommaLast;
        private System.Windows.Forms.CheckBox chkAddComma;
        private System.Windows.Forms.Button btnCopy;
    }
}