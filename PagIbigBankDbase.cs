using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class PagIbigBankDbase : Form
    {
        public PagIbigBankDbase()
        {
            InitializeComponent();
        }

        private string ubpConStr = "Server=10.88.77.68;Database=LCDB_01;User=allcard;Password=MalboroLights#;";
        private string aubConStr = "Server=10.88.77.71;Database=LCDB_01;User=allcard;Password=MarlboroLights#;";

        private string sysConStr_PreProd = "Server=10.88.77.174;Database=LCDB_01_SYS;User=applcdb;Password=Avega2019#;";
        DAL.MsSql dal = null;
        private DataTable dtDbase = null;

        private void PagIbigBankDbase_Load(object sender, EventArgs e)
        {            
            cboBank.SelectedIndex = 0;
            GetDbaseTablesAndFields();
        }

        private void GetDbaseTablesAndFields()
        {
            dal = null;
            string conStr = "";
            if (cboBank.Text == "UBP") conStr = ubpConStr;
            else if (cboBank.Text == "AUB") conStr = aubConStr;
            dal = new DAL.MsSql(conStr);
            if (dal.SelectQuery("select RTRIM(TABLE_NAME) TABLE_NAME, RTRIM(COLUMN_NAME) COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE from INFORMATION_SCHEMA.COLUMNS where table_Name not like '%_USER%' AND TABLE_NAME not like '%_KIOSK%' AND TABLE_NAME not like '%_CARD%' AND TABLE_NAME not like '%sqlmapoutput%' AND TABLE_NAME not like 'VW_%'"))
            {
                dtDbase = dal.TableResult;
            }
            dal.Dispose();
            if (dtDbase != null)
            {
                var localTB = dtDbase.DefaultView.ToTable(true, "TABLE_NAME");
                localTB.DefaultView.Sort = "TABLE_NAME";
                cboTable.DataSource = localTB;
                cboTable.DisplayMember = "TABLE_NAME";
                cboTable.ValueMember = "TABLE_NAME";
                cboTable.SelectedIndex = cboTable.FindStringExact("tbl_Member");
            }
        }

        private void SelectTable()
        {
            dal = null;
            string conStr = "";
            if (cboBank.Text == "UBP") conStr = ubpConStr;
            else if (cboBank.Text == "AUB") conStr = aubConStr;
            dal = new DAL.MsSql(conStr);

            StringBuilder sb = new StringBuilder();
            foreach (var v in txtData.Text.Split('\r'))
            {
                if(sb.ToString()=="") sb.Append(String.Format("'{0}'",v.Trim().Replace(" ","").Replace("-", "")));
                else sb.Append(String.Format(",'{0}'", v.Trim().Replace(" ", "").Replace("-", "")));
            }

            string tableFields = "*";
            if (chkMember.Visible)
            {
                if (!chkMember.Checked) tableFields = "RefNum, PagIBIGID, Member_FirstName, Member_MiddleName, Member_LastName, Application_Remarks, ApplicationDate, EntryDate, UserName, KioskID, requesting_branchcode";
            }

            if (dal.SelectQuery(String.Format("SELECT {3} FROM {0} WHERE {1} IN ({2})", cboTable.Text.Trim(), cboField.Text.Trim(), sb.ToString(),tableFields)))
            {
                grid.DataSource = dal.TableResult;
                if (dal.TableResult.DefaultView.Count > 0) lblResult.Text = "TOTAL : " + dal.TableResult.DefaultView.Count.ToString();
                else lblResult.Text = "";
            }
            dal.Dispose();            
        }

        private void Test()
        {
            dal = null;
            //string conStr = "";            
            dal = new DAL.MsSql(sysConStr_PreProd);

            if (dal.SelectUBP_Savings_Account("PG60E26391", "121008000650"))
            {
                grid.DataSource = dal.TableResult;
                if (dal.TableResult.DefaultView.Count > 0) lblResult.Text = "TOTAL : " + dal.TableResult.DefaultView.Count.ToString();
                else lblResult.Text = "";
            }
            dal.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            this.Enabled = false;
            SelectTable();
            Cursor = Cursors.Default;
            this.Enabled = true;
            MessageBox.Show("Done!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cboTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboField.Items.Clear();

            //var localTB = dtDbase.Select("TABLE_NAME='" + cboTable.Text.Trim() + "'").CopyToDataTable();
            //localTB.DefaultView.Sort = "TABLE_NAME";

            var rws = dtDbase.Select("TABLE_NAME='" + cboTable.Text.Trim() + "'");            

            foreach (DataRow dr in rws)
            {
                cboField.Items.Add(dr["COLUMN_NAME"].ToString());
            }
            //cboField.DataSource = rws;
            //cboField.DisplayMember = "COLUMN_NAME";
            //cboField.ValueMember = "COLUMN_NAME";
            cboField.SelectedIndex = cboField.FindStringExact("PagIBIGID");

            if (cboTable.Text == "tbl_Member") chkMember.Visible = true; else chkMember.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dal.TableResult != null)
            {
                if (dal.TableResult.DefaultView.Count > 0)
                {
                    //121172865511,
                    this.Enabled = false;
                    PagIbigApi frm = new PagIbigApi();                   
                    frm.GetCardNo_AUB_prod(dal.TableResult.Rows[0]["PAGIBIGID"].ToString(), dal.TableResult.Rows[0]["Member_FirstName"].ToString(), dal.TableResult.Rows[0]["Member_MiddleName"].ToString(), dal.TableResult.Rows[0]["Member_LastName"].ToString(), Convert.ToDateTime(dal.TableResult.Rows[0]["BirthDate"]).ToString("yyyy-MM-dd"));
                    frm.ShowDialog();
                    this.Enabled = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Test();
        }
    }
}
