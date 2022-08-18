using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeHealth_Patient_CallBacks_PatientSummaryHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string PatientId = Request.Form["PatientId"].ToString();
        string EpisodeTaskId = Request.Form["EpisodeTaskId"].ToString();

        
        
        PatientDB objPatientDB = new PatientDB();
        DataTable dtPatientList = new DataTable();
        dtPatientList = objPatientDB.GetPatientDetailByPatientId(int.Parse(PatientId), int.Parse(EpisodeTaskId));
        imgPatientProfilePicture.Src = "../PracticeDocuments/" + Profile.PracticeId + "/Patients/" + PatientId + "/" + dtPatientList.Rows[0]["ImagePath"].ToString();
        lblPatientName.Text = dtPatientList.Rows[0]["PatientName"].ToString();
        lblDateOfBirth.Text = dtPatientList.Rows[0]["DOB"].ToString();
        lblGender.Text = dtPatientList.Rows[0]["Gender"].ToString();
        lblMaritalStatus.Text = dtPatientList.Rows[0]["MaritalStatus"].ToString();
        lblAddress.Text = dtPatientList.Rows[0]["PatientAddress"].ToString();
        lblReasonForVisit.Text = dtPatientList.Rows[0]["TaskName"].ToString();
    }
}