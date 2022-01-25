
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
            this.uBPDAOEncryptdecryptToolStripMenuItem});
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
            this.Text = "Main";
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
    }
}