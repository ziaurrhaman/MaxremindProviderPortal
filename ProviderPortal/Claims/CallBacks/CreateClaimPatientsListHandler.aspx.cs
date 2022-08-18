using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_Claims_CallBacks_CreateClaimPatientsListHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var objClaimDb = new ClaimDB();
        //Int32 patientId = Int32.Parse(Request.Form["PracticeLocationsId"]);
        Int64 insuranceId = Int64.Parse(Request.Form["InsuranceId"]);
        Int32 rows = Int32.Parse(Request.Form["Rows"]);
        Int32 pageNumber = Int32.Parse(Request.Form["PageNumber"]);

        var dtPatients = objClaimDb.GetPatients(insuranceId, 0, rows, pageNumber);
        rptPatients.DataSource = dtPatients.Tables[0];
        rptPatients.DataBind();
        hdnPatientsCount.Value = dtPatients.Tables[1].Rows[0]["TotalRows"].ToString(); 
    }
}