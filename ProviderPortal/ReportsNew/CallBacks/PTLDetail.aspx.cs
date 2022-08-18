using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_PTLDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


        LoadAllPtlList();
        LoadPayersFromClaim();
        LoadPracticeLocation();
    }



    private void LoadAllPtlList()
    {
        ClaimDB objClaimDB = new ClaimDB();
        string PTLType = "Patient";
        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        string DateType = "PostDate";
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        DataSet dsClaims = objClaimDB.GetClaimPatientptlList(Profile.PracticeId, 0, 10, 0, 0, "", "", PTLType, "", "", 0, "", "", "", "", "", DateFrom, DateTo, DateType);

        rptPTLAll.DataSource = dsClaims.Tables[0];
        rptPTLAll.DataBind();
        hdnTotalRows.Value = dsClaims.Tables[1].Rows[0]["TotalCount"].ToString();
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
        hdnLocations.Value = "";
        hdnPayers.Value = "";

        //lblPractice.Text = Profile.PracticeId + " - " + Profile.PracticeName;
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocationForPatient.DataSource = dtPracticeLocation;
        rptLocationForPatient.DataBind();
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
            Label lblPTLType = (Label)e.Item.FindControl("lblPTLType");
            //Label lblQA = (Label)e.Item.FindControl("lblQA");
            //Label lblAudit = (Label)e.Item.FindControl("lblAudit");
            //Label lblCRM = (Label)e.Item.FindControl("lblCRM");

            //Label QA = (Label)e.Item.FindControl("QA");
            //Label Audit = (Label)e.Item.FindControl("Audit");
            //Label CRM = (Label)e.Item.FindControl("CRM");
            if (isclmptl == "True" && ISpAT == "True")
            {
                lblPTLType.Text = "Patient,Claim";
            }
            if (isclmptl == "True" && (ISpAT == "False" || ISpAT == ""))
            {
                lblPTLType.Text = "Claim";
            }
            if ((isclmptl == "False" || isclmptl == "") && ISpAT == "True")
            {
                lblPTLType.Text = "Patient";
            }
            //if (QAVerified == "True")
            //{
            //    lblQA.Text = @"<img src='../../../Images/Tick1.png' style='width:19%'>";
            //    QA.Text = "True";
            //}
            //else
            //{
            //    lblQA.Text = "<img src='../../../Images/cross.png'>";
            //    QA.Text = "False";
            //}
            //if (AuditVerified == "True")
            //{
            //    lblAudit.Text = "<img src='../../../Images/Tick1.png' style='width:19%'>";
            //    Audit.Text = "True";
            //}
            //else
            //{
            //    lblAudit.Text = @"<img src='../../../Images/cross.png'>";
            //    Audit.Text = "False";

            //}
            //if (CRMVerified == "True")
            //{
            //    lblCRM.Text = "<img src='../../../Images/Tick1.png' style='width:46%'>";
            //    CRM.Text = "True";

            //}
            //else
            //{
            //    lblCRM.Text = @"<img src='../../../Images/cross.png'>";
            //    CRM.Text = "False";

            //}
        }
    }


}