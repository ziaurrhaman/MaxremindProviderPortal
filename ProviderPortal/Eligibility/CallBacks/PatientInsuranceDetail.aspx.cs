using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Eligibility_CallBacks_PatientInsuranceDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientDB db = new PatientDB();
        var PatientId = Request.Form["PatientId"];
        //DataTable dt = db.InsurancePatient(PatientId);
        DataSet ds = db.InsurancePatient(PatientId);
        DataTable dtIDetails = ds.Tables[0];
        DataTable dtDos = ds.Tables[1];

        if (dtIDetails.Rows.Count > 0)
        {

            //if (!string.IsNullOrEmpty(dt.Rows[0]["InsuranceId"].ToString()))
               // hdnInsuranceId.Value = dt.Rows[0]["InsuranceId"].ToString();
            //if (!string.IsNullOrEmpty(dt.Rows[0]["PolicyNumber"].ToString()))
                //PolicyNumber.Value = dt.Rows[0]["PolicyNumber"].ToString();
            //RptInsurance.DataSource = dt;

            //RptInsurance.DataBind();

            ddlInsurance.DataSource = dtIDetails;
            ddlInsurance.DataValueField = "InsuranceId";
            ddlInsurance.DataTextField = "Name";
            ddlInsurance.DataBind();

            foreach (DataRow dr in dtIDetails.Rows)
            {
                ltrHiddenFields.Text += "<input type='hidden' id='" + dr["InsuranceId"] + "' value='" + dr["PolicyNumber"] + "' />";
            }
        }
        if (dtDos.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtDos.Rows[0]["DOS"].ToString()))
                txtEligibilityDOS.Text = dtDos.Rows[0]["DOS"].ToString();
                //txtEligibilityDOS.Text = "07/26/2018";
        }
    }
}