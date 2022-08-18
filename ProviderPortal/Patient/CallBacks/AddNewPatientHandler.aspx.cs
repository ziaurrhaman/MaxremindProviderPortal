using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;

public partial class HomeHealth_Patient_CallBacks_AddNewPatientHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer objSerializer = new JavaScriptSerializer();
        
        Patient objPatient = objSerializer.Deserialize<Patient>(Request.Form["Patient"]);
        
        objPatient.PracticeId = int.Parse(Profile.PracticeId.ToString());
        objPatient.CreatedById = Profile.UserId;
        objPatient.CreatedDate = DateTime.Now;
        
        PatientDB objPatientDB = new PatientDB();

        long PatientId = objPatientDB.Add(objPatient);

        ltrPatientId.Text = PatientId.ToString();
        
        PatientInsurance objPatientInsurance = objSerializer.Deserialize<PatientInsurance>(Request.Form["objPatientInsurance"]);
        
        if (objPatientInsurance.InsuranceId != 0)
        {
            objPatientInsurance.PriSecOthType = "P";
            objPatientInsurance.PatientId = PatientId;
            objPatientInsurance.CreatedById = Profile.UserId;
            objPatientInsurance.CreatedDate = DateTime.Now;

            PatientInsuranceDB objPatientInsuranceDB = new PatientInsuranceDB();
            objPatientInsuranceDB.Add(objPatientInsurance);
        }
    }
}