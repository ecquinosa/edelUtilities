using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdelUtilities
{
    public partial class EditDeleteMID : Form
    {

        DAL.MsSql dalUBP = new DAL.MsSql("Server=10.88.77.68;Database=LCDB_01;User=allcard;Password=MalboroLights#;");
        DAL.MsSql dalAUB = new DAL.MsSql("Server=10.88.77.71;Database=LCDB_01;User=allcard;Password=MarlboroLights#;");

        public EditDeleteMID()
        {
            InitializeComponent();
        }

        private void EditDeleteMID_Load(object sender, EventArgs e)
        {
            cboBank.SelectedIndex = 0;
        }

        private void EditDeleteMID_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseConnection();
        }

        private void SelectData(string mid)
        {
            btnUpdate.Enabled = false;
            DataTable dt = null;

            if (cboBank.Text == "UBP")
            {
                if (dalUBP.SelectQuery(string.Format("select id, RefNum, PagIBIGID, EntryDate, Member_FirstName, Member_LastName, PagIBIGID, getdate() from tbl_Member where PagIBIGID = '{0}'",mid)))
                {
                    if (dalUBP.TableResult.DefaultView.Count > 0) dt = dalUBP.TableResult;                    
                }
            }
            else if(cboBank.Text == "AUB")
            {
                if (dalAUB.SelectQuery(string.Format("select id, RefNum, PagIBIGID, EntryDate, Member_FirstName, Member_LastName, PagIBIGID, getdate() from tbl_Member where PagIBIGID = '{0}'", mid)))
                {
                    if (dalAUB.TableResult.DefaultView.Count > 0) dt = dalAUB.TableResult;
                }
            }

            if (dt == null)
            {
                RTBLog(string.Concat(mid, "\t", "* No record found *"));
                return;
            }

            if (dt.DefaultView.Count > 0)
            {
                foreach (DataRow rw in dt.Rows)
                {
                    string line = string.Concat(rw[0].ToString(), "\t", rw[1].ToString(), "\t", rw[2].ToString(), "\t", rw[3].ToString(), "\t", rw[4].ToString(), "\t", rw[5].ToString(), "\t", rw[6].ToString(), "\t", rw[7].ToString());
                    RTBLog(line);
                }

                btnUpdate.Enabled = true;
            } else RTBLog(string.Concat(mid, "\t", "* No record found *"));
        }

        private void updateQuery(string table, string mid, string newMid)
        {
            if (cboBank.Text == "UBP")
            {
                if (dalUBP.ExecuteQuery(string.Format("update {0} set PagIBIGID = '{1}' WHERE  (PagIBIGID = '{2}')", table, newMid, mid))) RTBLog(string.Concat(mid, "\t", string.Format("{0} success update", table)));
                else RTBLog(string.Concat(mid, "\t", string.Format("{0} failed update", table)));
            }
            else if (cboBank.Text == "AUB")
            {
                if (dalAUB.ExecuteQuery(string.Format("update {0} set PagIBIGID = '{1}' WHERE  (PagIBIGID = '{2}')", table, newMid, mid))) RTBLog(string.Concat(mid, "\t", string.Format("{0} success update", table)));
                else RTBLog(string.Concat(mid, "\t", string.Format("{0} failed update", table)));
            }                
        }

        private void UpdateMID()
        {
            RTBLog(string.Concat(txtMID.Text," (before update)=================="));
            SelectData(txtMID.Text);
            RTBLog("=============================================");
            updateQuery("tbl_Survey", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_MembershipCategoryInfo", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_MemberContactinfo", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_EmploymentHistory", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_Photo", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_PhotoValidID", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_bio", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_Signature", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_Card", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_MemContribution", txtMID.Text, txtNewMID.Text);
            updateQuery("tbl_Member", txtMID.Text, txtNewMID.Text);
            RTBLog("=============================================");
            RTBLog(string.Concat(txtMID.Text, " (after update)=================="));
            SelectData(txtMID.Text);
        }

        private void RTBLog(string desc)
        {
            rtb.AppendText(desc + "\r");
            rtb.ScrollToCaret();
            Application.DoEvents();
        }

        private void CloseConnection()
        {
            if (dalUBP != null)
            {
                dalUBP.Dispose();
                dalUBP = null;
            }

            if (dalAUB != null)
            {
                dalAUB.Dispose();
                dalAUB = null;
            }
        }

       

        #region Button and Textbox Event

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (cboBank.Text == "")
            {
                MessageBox.Show("Please recheck bank value...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtMID.Text == "")
            {
                MessageBox.Show("Please recheck mid value...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectData(txtMID.Text);
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            rtb.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMID.Text == txtNewMID.Text)
            {
                MessageBox.Show("Please recheck new MID value...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtNewMID.Text == "")
            {
                MessageBox.Show("Please recheck new MID value...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Are you sure you want to update " + cboBank.Text.ToUpper() + " db?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                this.Enabled = false;

                UpdateMID();

                this.Enabled = true;
                Cursor = Cursors.Default;

                MessageBox.Show("Process done...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtMID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtNewMID.Text = string.Concat(txtMID.Text.Substring(0, 8), "d", txtMID.Text.Substring(9, 3));
            }
            catch { }
        }


        #endregion

        
    }
}
