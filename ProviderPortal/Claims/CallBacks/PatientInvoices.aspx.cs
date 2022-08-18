using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class BillingManager_Claims_CallBacks_PatientInvoices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var objClaimDb = new ClaimDB();
        var dsUnProcessedClaims = objClaimDb.GetUnProcessedClaims(Convert.ToInt64(Profile.PracticeId), 10, 0, "", "", "");
        rptUnProcessedClaims.DataSource = dsUnProcessedClaims.Tables[0];
        rptUnProcessedClaims.DataBind();
        hdnUnProcessedClaimsCount.Value = dsUnProcessedClaims.Tables[1].Rows[0]["TotalRows"].ToString();


        DataSet dsPendingSubmissions = objClaimDb.GetPendingSubmissions(Convert.ToInt64(Profile.PracticeId), 10, 0);
        rptPendingSubmissions.DataSource = dsPendingSubmissions.Tables[0];
        rptPendingSubmissions.DataBind();

        hdnPendingSubmissionCount.Value = dsPendingSubmissions.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptUnProcessedClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
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