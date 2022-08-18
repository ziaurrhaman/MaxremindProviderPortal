using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeHealth_EpisodeClaims_NewEOB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      InsuranceDB objInsuranceDb = new InsuranceDB();
        ddlEOBInsurance.DataSource = objInsuranceDb.GetAllInsurances(Profile.PracticeId);
        ddlEOBInsurance.DataTextField = "InsuranceName";
        ddlEOBInsurance.DataValueField = "InsuranceId";
        ddlEOBInsurance.DataBind();
    }
}