
namespace EdelUtilities
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeEmptyFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uBPDAOEncryptdecryptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.singleDoubleQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagIbigAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.regexTesterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagIbigDatabaseDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(872, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeEmptyFolderToolStripMenuItem,
            this.uBPDAOEncryptdecryptToolStripMenuItem,
            this.singleDoubleQuoteToolStripMenuItem,
            this.pagIbigAPIToolStripMenuItem,
            this.regexTesterToolStripMenuItem,
            this.pagIbigDatabaseDataToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(58, 24);
            this.toolStripMenuItem1.Text = "Tools";
            // 
            // removeEmptyFolderToolStripMenuItem
            // 
            this.removeEmptyFolderToolStripMenuItem.Name = "removeEmptyFolderToolStripMenuItem";
            this.removeEmptyFolderToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.removeEmptyFolderToolStripMenuItem.Text = "Remove empty folder";
            this.removeEmptyFolderToolStripMenuItem.Click += new System.EventHandler(this.removeEmptyFolderToolStripMenuItem_Click);
            // 
            // uBPDAOEncryptdecryptToolStripMenuItem
            // 
            this.uBPDAOEncryptdecryptToolStripMenuItem.Name = "uBPDAOEncryptdecryptToolStripMenuItem";
            this.uBPDAOEncryptdecryptToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.uBPDAOEncryptdecryptToolStripMenuItem.Text = "UBP DAO encrypt/decrypt";
            this.uBPDAOEncryptdecryptToolStripMenuItem.Click += new System.EventHandler(this.uBPDAOEncryptdecryptToolStripMenuItem_Click);
            // 
            // singleDoubleQuoteToolStripMenuItem
            // 
            this.singleDoubleQuoteToolStripMenuItem.Name = "singleDoubleQuoteToolStripMenuItem";
            this.singleDoubleQuoteToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.singleDoubleQuoteToolStripMenuItem.Text = "Single/ Double Quote";
            this.singleDoubleQuoteToolStripMenuItem.Click += new System.EventHandler(this.singleDoubleQuoteToolStripMenuItem_Click);
            // 
            // pagIbigAPIToolStripMenuItem
            // 
            this.pagIbigAPIToolStripMenuItem.Name = "pagIbigAPIToolStripMenuItem";
            this.pagIbigAPIToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.pagIbigAPIToolStripMenuItem.Text = "Pag-Ibig API";
            this.pagIbigAPIToolStripMenuItem.Click += new System.EventHandler(this.pagIbigAPIToolStripMenuItem_Click);
            // 
            // regexTesterToolStripMenuItem
            // 
            this.regexTesterToolStripMenuItem.Name = "regexTesterToolStripMenuItem";
            this.regexTesterToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.regexTesterToolStripMenuItem.Text = "Regex Tester";
            this.regexTesterToolStripMenuItem.Click += new System.EventHandler(this.regexTesterToolStripMenuItem_Click);
            // 
            // pagIbigDatabaseDataToolStripMenuItem
            // 
            this.pagIbigDatabaseDataToolStripMenuItem.Name = "pagIbigDatabaseDataToolStripMenuItem";
            this.pagIbigDatabaseDataToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.pagIbigDatabaseDataToolStripMenuItem.Text = "Pag-Ibig Database Data";
            this.pagIbigDatabaseDataToolStripMenuItem.Click += new System.EventHandler(this.pagIbigDatabaseDataToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 596);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edel Utilities";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeEmptyFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uBPDAOEncryptdecryptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem singleDoubleQuoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagIbigAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem regexTesterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagIbigDatabaseDataToolStripMenuItem;
    }
}