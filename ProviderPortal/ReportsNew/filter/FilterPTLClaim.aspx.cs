using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_PTLClaim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];


        PatientFilterAll();

    }
    private void PatientFilterAll()
    {
        int CommunicationCount = 0;
        long PatientId = 0;
        long ClaimId = 0;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        if (string.IsNullOrEmpty(Request.Form["PatientId"]))
        {
            PatientId = 0;
        }
        else
        {
            PatientId = int.Parse(Request.Form["PatientId"].ToString());
        }
        string PatientName = Request.Form["PatientName"];
        if (string.IsNullOrEmpty(Request.Form["ClaimId"]))
        {
            ClaimId = 0;
        }
        else
        {
            ClaimId = int.Parse(Request.Form["ClaimId"].ToString());
        }
        string Payer = Request.Form["PayerId"];
        string location = Request.Form["Location"];
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        string DateType = Request.Form["DateType"];
        string PtlReason = Request.Form["PtlReason"];
        string LastCommuDate = "";
        string Dateofservice = "";
        string PTLType = Request.Form["PTLType"];

        if (string.IsNullOrEmpty(Request.Form["CommunicationCount"]))
        {
            CommunicationCount = 0;
        }
        else
        {
            CommunicationCount = int.Parse(Request.Form["CommunicationCount"]);
        }
        string DOS = Request.Form["DOS"];
        if (DOS != "__/__/____")
        {
            Dateofservice = DOS;
        }
        string LastCommunicationDate = Request.Form["LastCommunicationDate"];
        if (LastCommunicationDate != "__/__/____")
        {
            LastCommuDate = LastCommunicationDate;
        }

        string QAApproved = Request.Form["QAApproved"];
        string AuditApproved = Request.Form["AuditApproved"];
        string CRMApproved = Request.Form["CRMApproved"];


        ClaimDB objClaimDB = new ClaimDB();

        DataSet dsClaims = objClaimDB.GetClaimPatientptlList(Profile.PracticeId, PageNumber, Rows, PatientId, ClaimId, PatientName, PtlReason, "Claim", Payer, location, CommunicationCount, Dateofservice, LastCommuDate, QAApproved, AuditApproved, CRMApproved, DateFrom, DateTo, DateType);
        //Rizwan kharal End
        rptPTLAll.DataSource = dsClaims.Tables[0];
        rptPTLAll.DataBind();
        ltrTotalRows.Text = dsClaims.Tables[1].Rows[0]["TotalCount"].ToString();
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
        hdnLocations.Value = location;
        hdnPayers.Value = Payer;
    }
    protected void rptPTLAll_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string QAVerified = drv["PTLQAApproved"].ToString();
            string AuditVerified = drv["PTLAuditApproved"].ToString();
            string CRMVerified = drv["PTLCRMApproved"].ToString();
            string isclmptl = drv["CLMPTL"].ToString();
            string ISpAT = drv["PatPTL"].ToString();

            Label lblQA = (Label)e.Item.FindControl("lblQA");
            Label lblAudit = (Label)e.Item.FindControl("lblAudit");
            Label lblCRM = (Label)e.Item.FindControl("lblCRM");

            /// Modified By Irfan Mahmood 07/Dec/2021
            Label QA = (Label)e.Item.FindControl("QA");
            Label Audit = (Label)e.Item.FindControl("Audit");
            Label CRM = (Label)e.Item.FindControl("CRM");
            /// End Modified By Irfan Mahmood 07/Dec/2021
            if (QAVerified == "True")
            {
                lblQA.Text = @"<img src='../../../Images/Tick1.png' style='width:19%'>";
                QA.Text = "True";
            }
            else
            {
                lblQA.Text = "<img src='../../../Images/cross.png'>";
                QA.Text = "False";
            }
            if (AuditVerified == "True")
            {
                lblAudit.Text = "<img src='../../../Images/Tick1.png' style='width:19%'>";
                Audit.Text = "True";
            }
            else
            {
                lblAudit.Text = @"<img src='../../../Images/cross.png'>";
                Audit.Text = "False";

            }
            if (CRMVerified == "True")
            {
                lblCRM.Text = "<img src='../../../Images/Tick1.png' style='width:46%'>";
                CRM.Text = "True";

            }
            else
            {
                lblCRM.Text = @"<img src='../../../Images/cross.png'>";
                CRM.Text = "False";

            }
        }
    }




}