using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Eligibility_CallBacks_GetPatients : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientDB ObjPatientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;

        DataSet dsPatientRecord = ObjPatientDB.GetAllPatientsForEligibility(PracticeId,10,0,"",0,"","","","",""); 

        rptPatients.DataSource = dsPatientRecord.Tables[0];
        rptPatients.DataBind();
        hdnTotalRows.Value = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}