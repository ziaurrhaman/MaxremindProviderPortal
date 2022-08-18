using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_InsuranceCredentialing_InsuranceCredentialing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InsuranceCredentialingDB db = new InsuranceCredentialingDB();
        DataSet ds = db.GetAllFilter(Profile.PracticeId, 10, 0, "insurancecredentialingid DESC", "", "", "", "", "", "", 0, 0, null, null, "");
        rptInsuranceCredentialing.DataSource = ds.Tables[0];
        rptInsuranceCredentialing.DataBind();
        hdnTotalRowsInsuranceCredentialingGrid.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}