
namespace EdelUtilities
{
    partial class InsertContactInfoAddress_DCS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContactInfoFile = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtBrgy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSearchBrgy = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPerCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPerBrgy = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPerProvince = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPerRegion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPerRegionDesc = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPreRegionDesc = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPreRegion = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPreProvince = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPreCity = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPreBrgy = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnPerGetValues = new System.Windows.Forms.Button();
            this.btnPreGetValues = new System.Windows.Forms.Button();
            this.cboBank = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btnSearchCity = new System.Windows.Forms.Button();
            this.chkPermanent = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Member Contact info File";
            // 
            // txtContactInfoFile
            // 
            this.txtContactInfoFile.Location = new System.Drawing.Point(177, 36);
            this.txtContactInfoFile.Name = "txtContactInfoFile";
            this.txtContactInfoFile.Size = new System.Drawing.Size(225, 21);
            this.txtContactInfoFile.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(408, 34);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(67, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBrgy
            // 
            this.txtBrgy.Location = new System.Drawing.Point(177, 66);
            this.txtBrgy.Name = "txtBrgy";
            this.txtBrgy.Size = new System.Drawing.Size(225, 21);
            this.txtBrgy.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Barangay";
            // 
            // grid
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grid.DefaultCellStyle = dataGridViewCellStyle4;
            this.grid.Location = new System.Drawing.Point(12, 148);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(522, 104);
            this.grid.TabIndex = 5;
            this.grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grid_CellDoubleClick);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(12, 475);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(162, 23);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "INSERT SCRIPT";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(177, 93);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(225, 21);
            this.txtCity.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "City";
            // 
            // btnSearchBrgy
            // 
            this.btnSearchBrgy.Location = new System.Drawing.Point(12, 122);
            this.btnSearchBrgy.Name = "btnSearchBrgy";
            this.btnSearchBrgy.Size = new System.Drawing.Size(126, 23);
            this.btnSearchBrgy.TabIndex = 9;
            this.btnSearchBrgy.Text = "SEARCH BRGY";
            this.btnSearchBrgy.UseVisualStyleBackColor = true;
            this.btnSearchBrgy.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(105, 504);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(412, 21);
            this.txtOutput.TabIndex = 10;
            this.txtOutput.Text = "H:\\My Drive\\PAGIBIG\\Sql Scripts\\member contact info";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 507);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Output";
            // 
            // txtPerCity
            // 
            this.txtPerCity.Location = new System.Drawing.Point(106, 309);
            this.txtPerCity.Name = "txtPerCity";
            this.txtPerCity.Size = new System.Drawing.Size(136, 21);
            this.txtPerCity.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "City";
            // 
            // txtPerBrgy
            // 
            this.txtPerBrgy.Location = new System.Drawing.Point(106, 282);
            this.txtPerBrgy.Name = "txtPerBrgy";
            this.txtPerBrgy.Size = new System.Drawing.Size(136, 21);
            this.txtPerBrgy.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Barangay";
            // 
            // txtPerProvince
            // 
            this.txtPerProvince.Location = new System.Drawing.Point(106, 336);
            this.txtPerProvince.Name = "txtPerProvince";
            this.txtPerProvince.Size = new System.Drawing.Size(136, 21);
            this.txtPerProvince.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 339);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Province";
            // 
            // txtPerRegion
            // 
            this.txtPerRegion.Location = new System.Drawing.Point(106, 363);
            this.txtPerRegion.Name = "txtPerRegion";
            this.txtPerRegion.Size = new System.Drawing.Size(136, 21);
            this.txtPerRegion.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Region";
            // 
            // txtPerRegionDesc
            // 
            this.txtPerRegionDesc.Location = new System.Drawing.Point(106, 390);
            this.txtPerRegionDesc.Name = "txtPerRegionDesc";
            this.txtPerRegionDesc.Size = new System.Drawing.Size(136, 21);
            this.txtPerRegionDesc.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(25, 393);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Region Desc";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(25, 262);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "PERMANENT";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(300, 262);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "PRESENT";
            // 
            // txtPreRegionDesc
            // 
            this.txtPreRegionDesc.Location = new System.Drawing.Point(381, 390);
            this.txtPreRegionDesc.Name = "txtPreRegionDesc";
            this.txtPreRegionDesc.Size = new System.Drawing.Size(136, 21);
            this.txtPreRegionDesc.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(300, 393);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Region Desc";
            // 
            // txtPreRegion
            // 
            this.txtPreRegion.Location = new System.Drawing.Point(381, 363);
            this.txtPreRegion.Name = "txtPreRegion";
            this.txtPreRegion.Size = new System.Drawing.Size(136, 21);
            this.txtPreRegion.TabIndex = 30;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(300, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Region";
            // 
            // txtPreProvince
            // 
            this.txtPreProvince.Location = new System.Drawing.Point(381, 336);
            this.txtPreProvince.Name = "txtPreProvince";
            this.txtPreProvince.Size = new System.Drawing.Size(136, 21);
            this.txtPreProvince.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(300, 339);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Province";
            // 
            // txtPreCity
            // 
            this.txtPreCity.Location = new System.Drawing.Point(381, 309);
            this.txtPreCity.Name = "txtPreCity";
            this.txtPreCity.Size = new System.Drawing.Size(136, 21);
            this.txtPreCity.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(300, 312);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "City";
            // 
            // txtPreBrgy
            // 
            this.txtPreBrgy.Location = new System.Drawing.Point(381, 282);
            this.txtPreBrgy.Name = "txtPreBrgy";
            this.txtPreBrgy.Size = new System.Drawing.Size(136, 21);
            this.txtPreBrgy.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(300, 285);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 23;
            this.label16.Text = "Barangay";
            // 
            // btnPerGetValues
            // 
            this.btnPerGetValues.Location = new System.Drawing.Point(28, 417);
            this.btnPerGetValues.Name = "btnPerGetValues";
            this.btnPerGetValues.Size = new System.Drawing.Size(92, 23);
            this.btnPerGetValues.TabIndex = 34;
            this.btnPerGetValues.Text = "GET VALUES";
            this.btnPerGetValues.UseVisualStyleBackColor = true;
            this.btnPerGetValues.Click += new System.EventHandler(this.btnPerGetValues_Click);
            // 
            // btnPreGetValues
            // 
            this.btnPreGetValues.Location = new System.Drawing.Point(303, 417);
            this.btnPreGetValues.Name = "btnPreGetValues";
            this.btnPreGetValues.Size = new System.Drawing.Size(92, 23);
            this.btnPreGetValues.TabIndex = 35;
            this.btnPreGetValues.Text = "GET VALUES";
            this.btnPreGetValues.UseVisualStyleBackColor = true;
            this.btnPreGetValues.Click += new System.EventHandler(this.btnPreGetValues_Click);
            // 
            // cboBank
            // 
            this.cboBank.FormattingEnabled = true;
            this.cboBank.Items.AddRange(new object[] {
            "UBP",
            "AUB"});
            this.cboBank.Location = new System.Drawing.Point(177, 9);
            this.cboBank.Name = "cboBank";
            this.cboBank.Size = new System.Drawing.Size(121, 21);
            this.cboBank.TabIndex = 36;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Bank";
            // 
            // btnSearchCity
            // 
            this.btnSearchCity.Location = new System.Drawing.Point(144, 122);
            this.btnSearchCity.Name = "btnSearchCity";
            this.btnSearchCity.Size = new System.Drawing.Size(126, 23);
            this.btnSearchCity.TabIndex = 38;
            this.btnSearchCity.Text = "SEARCH CITY";
            this.btnSearchCity.UseVisualStyleBackColor = true;
            this.btnSearchCity.Click += new System.EventHandler(this.btnSearchCity_Click);
            // 
            // chkPermanent
            // 
            this.chkPermanent.AutoSize = true;
            this.chkPermanent.Checked = true;
            this.chkPermanent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPermanent.Location = new System.Drawing.Point(425, 82);
            this.chkPermanent.Name = "chkPermanent";
            this.chkPermanent.Size = new System.Drawing.Size(88, 17);
            this.chkPermanent.TabIndex = 39;
            this.chkPermanent.Text = "Permanent";
            this.chkPermanent.UseVisualStyleBackColor = true;
            this.chkPermanent.CheckedChanged += new System.EventHandler(this.chkPermanent_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(184, 475);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(162, 23);
            this.btnUpdate.TabIndex = 40;
            this.btnUpdate.Text = "UPDATE SCRIPT";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // InsertContactInfoAddress_DCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 543);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkPermanent);
            this.Controls.Add(this.btnSearchCity);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cboBank);
            this.Controls.Add(this.btnPreGetValues);
            this.Controls.Add(this.btnPerGetValues);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPreRegionDesc);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPreRegion);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPreProvince);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtPreCity);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPreBrgy);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPerRegionDesc);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPerRegion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPerProvince);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPerCity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPerBrgy);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnSearchBrgy);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.txtBrgy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtContactInfoFile);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsertContactInfoAddress_DCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PagIbig DCS Member Contact Info";
            this.Load += new System.EventHandler(this.InsertContactInfoAddress_DCS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContactInfoFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtBrgy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearchBrgy;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPerCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPerBrgy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPerProvince;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPerRegion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPerRegionDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPreRegionDesc;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtPreRegion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPreProvince;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtPreCity;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPreBrgy;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnPerGetValues;
        private System.Windows.Forms.Button btnPreGetValues;
        private System.Windows.Forms.ComboBox cboBank;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnSearchCity;
        private System.Windows.Forms.CheckBox chkPermanent;
        private System.Windows.Forms.Button btnUpdate;
    }
}