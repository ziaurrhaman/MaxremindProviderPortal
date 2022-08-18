using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.IO;
using System.Data;

public partial class EMR_Patient_CallBacks_PatientHandler : System.Web.UI.Page
{
    JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
    PatientDB objPatientDB;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        objPatientDB = new PatientDB();
        
        AddEditPatient();
     
    }
    
    private void AddEditPatient()
    {
        Patient objPatient = objJavaScriptSerializer.Deserialize<Patient>(Request.Form["Patient"]);
        
        long PatientId = objPatient.PatientId;
        
        if (objPatient.PatientId == 0)
        {
            PatientManager objPatientManager = new PatientManager();
            
            bool IfPatientExists = objPatientManager.CheckPatientByName(Profile.PracticeId, objPatient.LastName, objPatient.FirstName);
            
            if (IfPatientExists)
            {
                ltrPatientId.Text = "PatientExists";
            }
            else
            {
                PatientId = AddPatient(objPatient);
                ltrPatientId.Text = PatientId.ToString();
            }
        }
        else
        {
            UpdatePatient(objPatient);
            
            ltrPatientId.Text = objPatient.PatientId.ToString();
        }
        
        if (Request.Form["objPatientInsurance"] != null)
        {
            AddEditPatientInsurance(PatientId);
        }
    }
    
    private long AddPatient(Patient objPatient)
    {
        objPatient.PracticeId = Profile.PracticeId;
        objPatient.CreatedDate = DateTime.Now;
        objPatient.CreatedById = Profile.UserId;
        
        return objPatientDB.Add(objPatient);
    }
    
    private void UpdatePatient(Patient objPatient)
    {
        objPatient.ModifiedDate = DateTime.Now;
        objPatient.ModifiedById = Profile.UserId;

        objPatientDB.Update(objPatient);
    }
    
    private void AddEditPatientInsurance(long PatientId)
    {
        PatientInsurance objPatientInsurance = objJavaScriptSerializer.Deserialize<PatientInsurance>(Request.Form["objPatientInsurance"]);
        
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