
namespace EdelUtilities
{
    partial class ConsolidateFileContents
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "DIRECTORY";
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(126, 22);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(379, 23);
            this.txtDirectory.TabIndex = 9;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(31, 57);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(94, 34);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.Text = "Process";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // rtb
            // 
            this.rtb.Location = new System.Drawing.Point(31, 106);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(474, 322);
            this.rtb.TabIndex = 12;
            this.rtb.Text = "";
            this.rtb.WordWrap = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(506, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 28);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // ConsolidateFileContents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 450);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.rtb);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDirectory);
            this.Font = new System.Drawing.Font("Verdana", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ConsolidateFileContents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CONSOLIDATE FILES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.Button btnBrowse;
    }
}