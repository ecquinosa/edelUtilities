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
    public partial class PagIbigApi : Form
    {
        public PagIbigApi()
        {
            InitializeComponent();
        }

        private ubpWS.ACC_MS_WEBSERVICE ubpWS = new ubpWS.ACC_MS_WEBSERVICE();
        private aubWS.ACC_MS_WEBSERVICE aubWS = new aubWS.ACC_MS_WEBSERVICE();
        private rbankSIT_WS.ACC_MS_WEBSERVICE rbankSIT_WS = new rbankSIT_WS.ACC_MS_WEBSERVICE();
        private ubpWS.RequestAuth raUBP = new ubpWS.RequestAuth();
        private aubWS.RequestAuth raAUB = new aubWS.RequestAuth();
        private rbankSIT_WS.RequestAuth raSIT_RBANK = new rbankSIT_WS.RequestAuth();

        private void RunTemp()
        {
            string sourceFile = @"D:\1538\list.txt";
            if (System.IO.File.Exists(sourceFile))
            {
                foreach (var line in System.IO.File.ReadAllLines(sourceFile))
                {
                    txtMID.Text = line.Trim();
                    btnSubmit.PerformClick();
                }
            }          
        }

        private void SaveDataToTxt(aubWS.SubmitResult sr)
        {
            string line = string.Concat(sr.SearchResult.MemberInfo.MemberID, "|",sr.SearchResult.MemberInfo.MemberName.FirstName, "|", sr.SearchResult.MemberInfo.MemberName.MiddleName,"|", sr.SearchResult.MemberInfo.MemberName.LastName, "|", sr.SearchResult.MemberInfo.PresentAddress.Barangay, "|", sr.SearchResult.MemberInfo.PresentAddress.CityMunicipality, "|", sr.SearchResult.MemberInfo.PresentAddress.Province, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerName, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerAddress.Barangay, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerAddress.CityMunicipality, "|", sr.SearchResult.MemberInfo.MembershipCategory.EmployerAddress.Province);
            string destiFile = @"D:\1538\details.txt";
            using (var sw = new System.IO.StreamWriter(destiFile, true))
            {
                sw.WriteLine(line);
                sw.Close();
                sw.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunTemp();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtMID.Text == "") return;

            rtb.Clear();

            try
            {
                switch (cboApi.Text)
                {
                    case "ActiveCardInfo":
                        ActiveCardInfo();
                        break;
                    case "GetMemberInfo":
                        GetMemberInfo();
                        break;
                    case "GetCardNo_AUB":
                        GetCardNo_AUB();
                        break;
                    default:
                        GetMemberMCRecord();
                        break;
                }
            }
            catch (Exception ex)
            {
                rtb.Text = ex.Message;
            }
        }

        private string GetMID()
        {
            return txtMID.Text.Replace(" ", "").Replace("-", "");
        }

        private void ActiveCardInfo()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    var response1 = ubpWS.GetActiveCardInfo(raUBP, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 1:
                    var response2 = aubWS.GetActiveCardInfo(raAUB, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    var response3 = rbankSIT_WS.GetActiveCardInfo(raSIT_RBANK, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    break;
            }
        }        

        private void GetMemberInfo()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    var response1 = ubpWS.is_MID_RTN_Exist(raUBP, GetMID());                   
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 1:
                    var response2 = aubWS.Is_MID_RTN_Exist(raAUB, GetMID());
                    SaveDataToTxt(response2);
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    var response3 = rbankSIT_WS.is_MID_RTN_Exist(raSIT_RBANK, GetMID());
                    //SaveDataToTxt(response3);
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    break;
            }            
           
        }

        private void GetMemberMCRecord()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    var response1 = ubpWS.Is_Member_Active(raUBP, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                   
                    break;
                case 1:
                    var response2 = aubWS.Is_Member_Active(raAUB, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    var response3 = rbankSIT_WS.Is_Member_Active(raSIT_RBANK, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    break;
            }
        }

        private void GetCardNo_AUB()
        {
            var name = new aubWS.name();
            name.firstName = "ROSALIE";            
            name.middleName = "HERNANE";
            name.lastName = "LORENZANA";
            var inq = new aubWS.inquiry();
            inq.idNo = "121051869550";
            inq.name = name;
            inq.birthdate = "1982-08-14";
            var getCard = new aubWS.AUBGetCardNoRequest();
            getCard.inquiry = inq;
            getCard.aud = "cashcard";
            getCard.jti = Guid.NewGuid().ToString();

            var response2 = aubWS.GetCardNo_AUB(raAUB, getCard);
            rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);

        }

        private void PagIbigApi_Load(object sender, EventArgs e)
        {   
            raUBP.wsUser = "ulilangkawayan";
            raUBP.wsPass = "ragMANOK2kx";
            raUBP.KioskID = "user";
            raUBP.User = 0;

            raAUB.wsUser = "ulilangkawayan";
            raAUB.wsPass = "ragMANOK2kx";
            raAUB.KioskID = "user";
            raAUB.User = 0;


            cboBank.SelectedIndex = 0;
            cboApi.SelectedIndex = 0;
        }       
    }
}
