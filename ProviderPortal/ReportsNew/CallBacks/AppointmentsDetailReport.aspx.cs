using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_CallBacks_AppointmentsDetailReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string ProviderId;
    string PracticeLocationId; string Status; string Reasons;
    string PatientId;
    protected void Page_Load(object sender, EventArgs e)
    {
        AppointmentsDB objAppointmentDB = new AppointmentsDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["DateFrom"];
        _DateTo = Request.Form["DateTo"];


        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        Status = Request.Form["AppointmentStatus"];
        Reasons = Request.Form["AppointmentReasons"];
        PatientId = Request.Form["PatId"];

        hdnPatient.Value = PatientId;
        hdnReasons.Value = Reasons;
        hdnStatus.Value = Status;

        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;


        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;


        DataSet dsReportData = objAppointmentDB.AppointmentDetails(PracticeId, 10, 0, "AppointmentDate DESC", PatientId, ProviderId, PracticeLocationId, Status, Reasons, _DateFrom, _DateTo);


        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}