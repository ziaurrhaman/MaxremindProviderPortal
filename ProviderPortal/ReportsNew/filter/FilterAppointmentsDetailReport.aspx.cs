using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_filter_FilterAppointmentsDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string DateType; string ProviderId;
    string PracticeLocationId; string Status; string Reasons;
    string PatientId;
 
    protected void Page_Load(object sender, EventArgs e)
    {
        AppointmentsDB objAppointmentDB = new AppointmentsDB();
        long PracticeId = Profile.PracticeId;
      


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientIds"];

        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];
        Status = Request.Form["Status"];
        Reasons = Request.Form["Reasons"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        DataSet dsReportData = objAppointmentDB.AppointmentDetails(PracticeId, Rows, PageNumber, SortBy, PatientId, ProviderId, PracticeLocationId, Status, Reasons, _DateFrom, _DateTo);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}