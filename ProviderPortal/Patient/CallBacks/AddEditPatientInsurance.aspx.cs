using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
public partial class HomeHealth_Patient_CallBacks_AddEditPatientInsurance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        PatientInsurance Insurance = serializer.Deserialize<PatientInsurance>(Request.Form["Insurance"]);
        if (Insurance.PatientInsuranceId == 0)
        {
            Insurance.CreatedById = Convert.ToInt32(Profile.UserId);
            Insurance.CreatedDate = DateTime.Now;
            PatientInsuranceDB ObjPatientInsuranceDB = new PatientInsuranceDB();
            Insurance.PatientInsuranceId = ObjPatientInsuranceDB.Add(Insurance);
        }
        else
        {
            Insurance.ModifiedById = Convert.ToInt32(Profile.UserId);
            Insurance.ModifiedDate = DateTime.Now;
            PatientInsuranceDB ObjPatientInsuranceDB = new PatientInsuranceDB();
            ObjPatientInsuranceDB.Update(Insurance);
        }
        ltrInsuranceId.Text = Insurance.PatientInsuranceId.ToString();
    }
}