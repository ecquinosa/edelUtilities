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

            raUBP.wsUser = "ulilangkawayan";
            raUBP.wsPass = "ragMANOK2kx";
            raUBP.KioskID = "user";
            raUBP.User = 0;
           
            raUBP_PreProd.wsUser = "ulilangkawayan";
            raUBP_PreProd.wsPass = "ragMANOK2kx";
            raUBP_PreProd.KioskID = "user";
            raUBP_PreProd.User = 0;

            raAUB.wsUser = "ulilangkawayan";
            raAUB.wsPass = "ragMANOK2kx";
            raAUB_SIT_OLD.wsUser = "ulilangkawayan";
            raAUB_SIT_OLD.wsPass = "ragMANOK2kx";
            raUBP_SIT_OLD.wsUser = "ulilangkawayan";
            raUBP_SIT_OLD.wsPass = "ragMANOK2kx";
            raAUB.KioskID = "user";
            raAUB.User = 0;

            raSIT_RBANK.wsUser = "ulilangkawayan";
            raSIT_RBANK.wsPass = "ragMANOK2kx";
            raSIT_RBANK.KioskID = "user";
            raSIT_RBANK.User = 0;

            raAUB_PreProd.wsUser = "ulilangkawayan";
            raAUB_PreProd.wsPass = "ragMANOK2kx";
            raAUB_PreProd.KioskID = "user";
            raAUB_PreProd.User = 0;           


            cboBank.SelectedIndex = 0;
            cboApi.SelectedIndex = 0;
        }

        private ubpWS.ACC_MS_WEBSERVICE ubpWS = new ubpWS.ACC_MS_WEBSERVICE();
        private aubWS.ACC_MS_WEBSERVICE aubWS = new aubWS.ACC_MS_WEBSERVICE();

        private ubpWS_SIT.ACC_MS_WEBSERVICE ubpWS_SIT_OLD = new ubpWS_SIT.ACC_MS_WEBSERVICE();
        private aubWS_SIT_OLD.ACC_MS_WEBSERVICE aubWS_SIT_OLD = new aubWS_SIT_OLD.ACC_MS_WEBSERVICE();

        private ubp_PreProd.ACC_MS_WEBSERVICE ubpWS_PreProd = new ubp_PreProd.ACC_MS_WEBSERVICE();

        private rbankSIT_WS.ACC_MS_WEBSERVICE rbankSIT_WS = new rbankSIT_WS.ACC_MS_WEBSERVICE();


        private ubpWS.RequestAuth raUBP = new ubpWS.RequestAuth();
        private aubWS.RequestAuth raAUB = new aubWS.RequestAuth();

        private aubWS_SIT_OLD.RequestAuth raAUB_SIT_OLD = new aubWS_SIT_OLD.RequestAuth();
        private ubpWS_SIT.RequestAuth raUBP_SIT_OLD = new ubpWS_SIT.RequestAuth();
        private ubp_PreProd.RequestAuth raUBP_PreProd = new ubp_PreProd.RequestAuth();

        private rbankSIT_WS.RequestAuth raSIT_RBANK = new rbankSIT_WS.RequestAuth();

        //private ubpWS_PreProd.ACC_MS_WEBSERVICE ubpWS_PreProd = new ubpWS_PreProd.ACC_MS_WEBSERVICE();
        //private ubpWS_PreProd.RequestAuth raUBP_PreProd = new ubpWS_PreProd.RequestAuth();

        private aubWS_PreProd.ACC_MS_WEBSERVICE aubWS_PreProd = new aubWS_PreProd.ACC_MS_WEBSERVICE();
        private aubWS_PreProd.RequestAuth raAUB_PreProd = new aubWS_PreProd.RequestAuth();

        private ubpWS_SIT.ACC_MS_WEBSERVICE ubpWS_SIT = new ubpWS_SIT.ACC_MS_WEBSERVICE();
        private ubpWS_SIT.RequestAuth raUBP_SIT = new ubpWS_SIT.RequestAuth();

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
            WS_X();

            return;
            string[] mids = System.IO.File.ReadAllText(@"D:\contri.txt").Split('\r');
            StringBuilder sb = new StringBuilder();

            foreach (string mid in mids)
            {
                switch (mid)
                {
                    //case "121019132734":
                    //    break;
                    default:
                        txtMID.Text = mid.Replace("\n", "");
                        btnSubmit.PerformClick();
                        int startIndex = rtb.Text.IndexOf("MCStatus");
                        if (startIndex != -1)
                        {
                            int endIndex = rtb.Text.IndexOf("}", startIndex);
                            string status = rtb.Text.Substring(startIndex, (endIndex - startIndex));
                            sb.Append(txtMID.Text + ", " + status + "\r");
                        }
                        else
                        {                            
                            sb.Append(txtMID.Text + ", Error" + "\r");
                        }                        
                        break;
                }
                
            }

            System.IO.File.WriteAllText(@"D:\contri2.txt", sb.ToString());

            MessageBox.Show("Done!");


            //RunTemp();
            //GetCardNo_AUB_prod();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (txtMID.Text == "") return;

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
                    case "ManualPackupData":
                        ManualPackupData();
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
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response1_SIT_OLD = ubpWS_SIT_OLD.GetActiveCardInfo(raUBP_SIT_OLD, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1_SIT_OLD, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PRE-PROD")
                    {
                        var response1_PreProd = ubpWS_PreProd.GetActiveCardInfo(raUBP_PreProd, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1_PreProd, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PROD")
                    {
                        var response1 = ubpWS.GetActiveCardInfo(raUBP, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    }                    
                    break;
                case 1:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response_Old_SIT = aubWS_SIT_OLD.GetActiveCardInfo(raAUB_SIT_OLD, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response_Old_SIT, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PRE-PROD")
                    {
                        var response_PreProd = aubWS_PreProd.GetActiveCardInfo(raAUB_PreProd, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response_PreProd, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PROD")
                    {
                        var response_Prod = aubWS.GetActiveCardInfo(raAUB, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response_Prod, Newtonsoft.Json.Formatting.Indented);
                    }
                    break;

                   
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
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response1 = ubpWS_SIT_OLD.is_MID_RTN_Exist(raUBP_SIT_OLD, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PRE-PROD")
                    {
                        var response1_PreProd = ubpWS_PreProd.is_MID_RTN_Exist(raUBP_PreProd, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1_PreProd, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PROD")
                    {
                        var response4 = ubpWS.is_MID_RTN_Exist(raUBP, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response4, Newtonsoft.Json.Formatting.Indented);
                    }
                    
                    break;
                case 1:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response1 = ubpWS_SIT_OLD.is_MID_RTN_Exist(raUBP_SIT_OLD, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PRE-PROD")
                    {
                        var response1_PreProd = aubWS_PreProd.is_MID_RTN_Exist(raAUB_PreProd, GetMID());                        
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1_PreProd, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PROD")
                    {
                        var response2 = aubWS.Is_MID_RTN_Exist(raAUB, GetMID());
                        SaveDataToTxt(response2);
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    }
                    
                    break;
                case 2:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response3 = rbankSIT_WS.is_MID_RTN_Exist(raSIT_RBANK, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    }

                    //SaveDataToTxt(response3);                    
                    break;
            }            
           
        }

        private void GetMemberMCRecord()
        {
            if (GetMID() == "") return;

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response1 = ubpWS_SIT_OLD.Is_Member_Active(raUBP_SIT_OLD, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PRE-PROD")
                    {
                        var response1_PreProd = ubpWS_PreProd.Is_Member_Active(raUBP_PreProd, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1_PreProd, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PROD")
                    {
                        var response1 = ubpWS.Is_Member_Active(raUBP, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);                       
                    }

                    break;
                   
                case 1:
                    var response2 = aubWS.Is_Member_Active(raAUB, GetMID());
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response3 = rbankSIT_WS.Is_Member_Active(raSIT_RBANK, GetMID());
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    }
                    break;
            }
        }

        private void GetCardNo_AUB()
        {
            var name = new aubWS_SIT_OLD.name();
            name.firstName = "ROSALIE";            
            name.middleName = "HERNANE";
            name.lastName = "LORENZANA";
            var inq = new aubWS_SIT_OLD.inquiry();
            inq.idNo = "121051869550";
            inq.name = name;
            inq.birthdate = "1982-08-14";
            var getCard = new aubWS_SIT_OLD.AUBGetCardNoRequest();
            getCard.inquiry = inq;
            getCard.aud = "cashcard";
            getCard.jti = Guid.NewGuid().ToString();

            var response2 = aubWS_SIT_OLD.GetCardNo_AUB(raAUB_SIT_OLD, getCard);
            System.IO.File.WriteAllText(Application.StartupPath + "\\getCard.txt", Newtonsoft.Json.JsonConvert.SerializeObject(getCard));
            rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
        }

        private void ManualPackupData()
        {
            if (txtRefNum.Text == "" | txtAccountNumber.Text == "") return;            

            switch (cboBank.SelectedIndex)
            {
                case 0:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response1 = ubpWS_SIT_OLD.ManualPackUpData(txtRefNum.Text, txtAccountNumber.Text);
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PRE-PROD")
                    {
                        var response1_PreProd = ubpWS_PreProd.ManualPackUpData(txtRefNum.Text, txtAccountNumber.Text);
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response1_PreProd, Newtonsoft.Json.Formatting.Indented);
                    }
                    else if (cboEnvironment.Text == "PROD")
                    {
                        var response4 = ubpWS.ManualPackUpData(txtRefNum.Text, txtAccountNumber.Text);
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response4, Newtonsoft.Json.Formatting.Indented);
                    }

                    break;
                case 1:
                    var response2 = aubWS.ManualPackUpData(txtRefNum.Text, txtAccountNumber.Text);
                    //SaveDataToTxt(response2);
                    rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
                    break;
                case 2:
                    if (cboEnvironment.Text == "SIT")
                    {
                        var response3 = rbankSIT_WS.ManualPackUpData(txtRefNum.Text, txtAccountNumber.Text);
                        rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response3, Newtonsoft.Json.Formatting.Indented);
                    }

                    //SaveDataToTxt(response3);                    
                    break;
            }

        }



        public void GetCardNo_AUB_prod(string mid, string firstName, string middleName, string lastName, string dob)
        {
            txtMID.Text = mid;
            var name = new aubWS.name();
            name.firstName = firstName;
            name.middleName = middleName;
            name.lastName = lastName;
            var inq = new aubWS.inquiry();
            inq.idNo = mid;
            inq.name = name;
            inq.birthdate = dob;
            var getCard = new aubWS.AUBGetCardNoRequest();
            getCard.inquiry = inq;
            getCard.aud = "cashcard";
            getCard.jti = Guid.NewGuid().ToString();

            var response2 = aubWS.GetCardNo_AUB(raAUB, getCard);
            System.IO.File.WriteAllText(Application.StartupPath + "\\getCard.txt", Newtonsoft.Json.JsonConvert.SerializeObject(getCard));
            rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response2, Newtonsoft.Json.Formatting.Indented);
        }

        private void PagIbigApi_Load(object sender, EventArgs e)
        {   
            
        }

        private void WS_X()
        {
            if (GetMID() == "") return;

            var response_Prod = ubpWS.IsMemberHasExistingNewCapture(raUBP, GetMID(), "1");
            rtb.Text = Newtonsoft.Json.JsonConvert.SerializeObject(response_Prod, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
