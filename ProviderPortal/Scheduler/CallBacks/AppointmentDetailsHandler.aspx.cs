using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class ProviderPortal_Appointments_CallBacks_AppointmentDetailsHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long AppointmentsId = long.Parse(Request.Form["AppointmentsId"]);
        
        hdnAppointmentsIdAppointmentDetail.Value = AppointmentsId.ToString();
        
        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        
        DataTable dtAppointmentDetail = objAppointmentsDB.GetAppointmentDetail(AppointmentsId);
        
        if (dtAppointmentDetail.Rows.Count > 0)
        {
            hdnPracticeLocationsIdAppointmentDetail.Value = dtAppointmentDetail.Rows[0]["PracticeLocationsId"].ToString();

            hdnAttendingPhysicianAppointmentDetail.Value = dtAppointmentDetail.Rows[0]["PracticeStaffId"].ToString().Trim();
            
            hdnPatientIdAppointmentDetail.Value = dtAppointmentDetail.Rows[0]["PatientId"].ToString();
            hdnAppointmentDateAppointmentDetail.Value = dtAppointmentDetail.Rows[0]["AppointmentDate"].ToString();
            
            lblAge.Text = dtAppointmentDetail.Rows[0]["Age"].ToString();
            lblPatientName.Text = dtAppointmentDetail.Rows[0]["PatientName"].ToString();
            lblHomePhone.Text = dtAppointmentDetail.Rows[0]["HomePhone"].ToString();
            lblWorkPhone.Text = dtAppointmentDetail.Rows[0]["WorkPhone"].ToString();
            lblProvider.Text = dtAppointmentDetail.Rows[0]["ProviderName"].ToString();
            lblAppointmentTime.Text = DateTime.Parse(dtAppointmentDetail.Rows[0]["StartTime"].ToString()).ToString("hh:mm tt");
            lblAppointmentDate.Text = DateTime.Parse(dtAppointmentDetail.Rows[0]["AppointmentDate"].ToString()).ToString("MM/dd/yyyy");
            lblAppointmentStatus.Text = dtAppointmentDetail.Rows[0]["AppointmentStatus"].ToString();
            
            string ImageUrl = dtAppointmentDetail.Rows[0]["ImagePath"].ToString();
            string PatientId = dtAppointmentDetail.Rows[0]["PatientId"].ToString();
            
            if (string.IsNullOrEmpty(ImageUrl))
            {
                if (dtAppointmentDetail.Rows[0]["Gender"].ToString() == "Male")
                {
                    imgUserImage.ImageUrl = ResolveUrl("~/Images/maleIcon.png");
                }
                else if (dtAppointmentDetail.Rows[0]["Gender"].ToString() == "Female")
                {
                    imgUserImage.ImageUrl = ResolveUrl("~/Images/FemaleIcon.png");
                }
            }
            else
            {
                imgUserImage.ImageUrl = ResolveUrl(ConfigurationManager.AppSettings["PatientPhoto"].ToString() + "/" + dtAppointmentDetail.Rows[0]["PracticeId"].ToString() + "/Patients/" + PatientId + "/" + ImageUrl);
            }
        }
    }
}