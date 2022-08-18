using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ProviderPortal_InsuranceEnrollment_InsuranceEnrollment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InsuranceEnrollmentsDB insuranceEnrollmentsDB = new InsuranceEnrollmentsDB();
        DataSet ds = insuranceEnrollmentsDB.GetAllFilter(10, 0, Profile.PracticeId, "", "", "insuranceenrollmentid DESC");
        rptInsuranceEnrollment.DataSource = ds.Tables[0];
        rptInsuranceEnrollment.DataBind();

        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptInsuranceEnrollment_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string ClaimStatusColor = drv["ClaimStatusColor"].ToString();
            string EligibilityStatusColor = drv["EligibilityStatusColor"].ToString();
            string ERAStatusColor = drv["ERAStatusColor"].ToString();


            var spnClaim = e.Item.FindControl("spnclaimstatus") as HtmlGenericControl;
            var spnEligiblity = e.Item.FindControl("spnEligibilitystatus") as HtmlGenericControl;
            var spnErastatus = e.Item.FindControl("spnErastatus") as HtmlGenericControl;

            spnClaim.Style.Add("background-color", ClaimStatusColor);
            spnEligiblity.Style.Add("background-color", EligibilityStatusColor);
            spnErastatus.Style.Add("background-color", ERAStatusColor);

            if (ClaimStatusColor == "") { spnClaim.Style.Add("color", "grey"); }
            if (EligibilityStatusColor == "") { spnEligiblity.Style.Add("color", "grey"); }
            if (ERAStatusColor == "") { spnErastatus.Style.Add("color", "grey"); }

        }
    }
}