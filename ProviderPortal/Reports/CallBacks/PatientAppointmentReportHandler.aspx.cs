using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Reports_CallBacks_PatientAppointmentReportHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int LocationId = int.Parse(Request.Form["LocationId"].ToString());
        string ResourceId = Request.Form["ResourceId"].ToString();
        long PatientId = long.Parse(Request.Form["PatientId"].ToString());
        string PatientName = Request.Form["PatientName"].ToString();
        string AppointmentDate = Request.Form["AppointmentDate"].ToString();
        string StartTime = Request.Form["StartTime"].ToString();
        string EndTime = Request.Form["EndTime"].ToString();
        string StatusId = Request.Form["StatusId"].ToString();
        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());
        ReportsDB objReportsDB = new ReportsDB();
        DataSet dsAppointmentsDB = objReportsDB.GetAppointmentBySearchCriteria(LocationId, ResourceId, PatientId, PatientName, AppointmentDate, StartTime, EndTime, StatusId, Rows, PageNumber);
        rptAppointment.DataSource = dsAppointmentsDB.Tables[0];
        rptAppointment.DataBind();
        ltrRowsCount.Text = dsAppointmentsDB.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}