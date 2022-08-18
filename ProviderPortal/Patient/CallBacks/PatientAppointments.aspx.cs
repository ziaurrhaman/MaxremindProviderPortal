using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Patient_CallBacks_PatientAppointments : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        long PatientId = Convert.ToInt64(Request.Form["PatientId"]);
        
        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        
        if (Request.Form["action"] != null)
        {
            string action = Request.Form["action"].ToString();
            
            if (action == "AllAppointments")
            {
                int Rows = int.Parse(Request.Form["Rows"].ToString());
                int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());
                string SortBy = Request.Form["SortBy"].ToString();
                
                string Filter = Request.Form["Filter"].ToString();
                
                DataSet dsAppointments = objAppointmentsDB.GetByPatientId(PatientId, Rows, PageNumber, SortBy);
                
                if (Filter == "")
                {
                    rptAppointments.DataSource = dsAppointments.Tables[0];
                    rptAppointments.DataBind();
                }
                else
                {
                    rptFilterAppointments.DataSource = dsAppointments.Tables[0];
                    rptFilterAppointments.DataBind();
                }
                
                ltrlTotalRows.Text = dsAppointments.Tables[1].Rows[0]["TotalRows"].ToString();
            }
            else if (action == "ViewAppointments")
            {
                int AppointmentsId = Convert.ToInt32(Request.Form["AppointmentsId"]);
                
                DataTable dtAppointment = objAppointmentsDB.GetByID(AppointmentsId);
                
                if (dtAppointment.Rows.Count > 0)
                {
                    lblAppointmentDate.Text = dtAppointment.Rows[0]["AppointmentDate"].ToString();
                    lblStartTime.Text = dtAppointment.Rows[0]["StartTime"].ToString();
                    lblEndTime.Text = dtAppointment.Rows[0]["EndTime"].ToString();
                    lblProviderName.Text = dtAppointment.Rows[0]["ServiceProviderName"].ToString();
                    lblReason.Text = dtAppointment.Rows[0]["AppointmentReason"].ToString();
                    string notes = dtAppointment.Rows[0]["Notes"].ToString();
                    
                    if (!String.IsNullOrEmpty(notes))
                    {
                        txtAppointmentReasonNotes.Text = dtAppointment.Rows[0]["Notes"].ToString();
                        trNotes.Style["display"] = "";
                    }
                    lblLocation.Text = dtAppointment.Rows[0]["LocationName"].ToString();
                    lblStatus.Text = dtAppointment.Rows[0]["StatusName"].ToString();
                }
            }
        }
    }
    
}