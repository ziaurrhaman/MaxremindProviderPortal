using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterClaimGrid : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsDB objClaimDB = new ReportsDB();
        string ClaimId = Request.Form["ClaimId"];
        DataSet dtClaims = objClaimDB.GetAllByPatient(0, ClaimId , Profile.PracticeId );
        rptClaims.DataSource = dtClaims.Tables[0];
        rptClaims.DataBind();
    }
}