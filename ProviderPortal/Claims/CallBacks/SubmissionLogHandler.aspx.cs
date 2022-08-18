using System;
using System.Data;
using System.Web.UI.WebControls;


public partial class HomeHealth_EpisodeClaims_CallBacks_SubmissionLogHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Int32 rows = Int32.Parse(Request.Form["Rows"]);
        Int32 pageNo = Int32.Parse(Request.Form["PageNumber"]);


        string PatientName = Request.Form["PatientName"];
        string InsuranceName = Request.Form["InsuranceName"];
        string FileName = Request.Form["FileName"];
        string ClaimId = Request.Form["ClaimId"];
        string SubmissionDate = Request.Form["SubmissionDate"];
        string SubmissionResults = Request.Form["SubmissionResults"];


        var objClaimsSubmittedDb = new ClaimsSubmittedDB();
        var dsSubmissionLog = objClaimsSubmittedDb.GetClaimsSubmittedLog(Convert.ToInt64(Profile.PracticeId), rows,
                                                                         pageNo, PatientName, InsuranceName, FileName, ClaimId, SubmissionDate, SubmissionResults);
        rptSubmissionLog.DataSource = dsSubmissionLog.Tables[0];
        rptSubmissionLog.DataBind();
        hdnSubmissionLogCount.Value = dsSubmissionLog.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptSubmissionLog_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["InsuranceName"].ToString();

            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");

            if (InsuranceId == "0")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }
        }
    }
}