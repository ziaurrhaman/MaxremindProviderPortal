using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeHealth_Patient_CallBacks_DeletePatientInsuranceHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long PatientInsuranceId = Convert.ToInt64(Request.Form["PatientInsuranceId"]);
        PatientInsuranceDB objPatientInsuranceDB = new PatientInsuranceDB();
        objPatientInsuranceDB.PatientInsurance_Delete(PatientInsuranceId);
    }
}