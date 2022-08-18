using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Claims_CallBacks_PatientClaims : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];

        if (action == "LoadPatientClaims")
        {
            LoadClaims();
        }
        else if (action == "LoadAllClaims")
        {
            LoadClaims();
        }
    }
    
    private void LoadClaims()
    {
        long PatientId = 0;
        long ClaimId = 0;
        
        if (Request.Form["PatientId"] != null)
        {
            PatientId = long.Parse(Request.Form["PatientId"]);
        }

        if (Request.Form["ClaimId"] != null)
        {
            ClaimId = long.Parse(Request.Form["ClaimId"]);
        }
        
        ClaimDB objClaimDB = new ClaimDB();

        DataTable dtClaims = objClaimDB.GetAllByPatient(PatientId, ClaimId);
        
        rptClaims.DataSource = dtClaims;
        rptClaims.DataBind();

        rptAllClaims.DataSource = dtClaims;
        rptAllClaims.DataBind();
    }
}