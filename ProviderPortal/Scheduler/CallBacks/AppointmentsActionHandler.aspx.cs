using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class ProviderPortal_Scheduler_CallBacks_AppointmentsActionHandler : System.Web.UI.Page
{
    long _CheckedInPatientsId = 0;
    long _PracticeLocationsId = 0;
    long _AppointmentsId = 0;
    int _CheckInRoomId = 0;
    int _StatusId = 0;
    DateTime _CurrentDateTime;
    long _ServiceProviderId = 0;
    long _PatientId = 0;

    JavaScriptSerializer _objJavaScriptSerializer = new JavaScriptSerializer();

    CheckedInPatientsDB objCheckedInPatientsDB = new CheckedInPatientsDB();
    AppointmentsDB objAppointmentsDB = new AppointmentsDB();

    protected void Page_Load(object sender, EventArgs e)
    {
        _AppointmentsId = long.Parse(Request.Form["AppointmentsId"]);

        string action = Request.Form["action"];

        if (action == "Save")
        {
            _PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsId"]);
            Save();
        }
        else if (action == "Delete")
        {
            Delete();
            LoadCheckedInPatientList();
        }
        else if (action == "UpdateStatus")
        {
            _PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsId"]);
            _CheckInRoomId = int.Parse(Request.Form["CheckInRoomId"]);
            _CurrentDateTime = Convert.ToDateTime(Request.Form["LocalTime"]);

            _StatusId = int.Parse(Request.Form["StatusId"]);
            _ServiceProviderId = long.Parse(Request.Form["ServiceProviderId"]);
            _PatientId = long.Parse(Request.Form["PatientId"]);

            UpdateStatus();
            LoadCheckedInPatientList();
        }
        else if (action == "ChangeCheckInRoom")
        {
            _PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsId"]);
            _CheckedInPatientsId = long.Parse(Request.Form["CheckedInPatientsId"]);
            _CheckInRoomId = int.Parse(Request.Form["CheckInRoomId"]);
            _CurrentDateTime = Convert.ToDateTime(Request.Form["LocalTime"]);

            ChangeCheckInRoom();
            LoadCheckedInPatientList();
        }
        else if (action == "UpdateStatusAfterWalkout")
        {
            UpdateStatusAfterWalkout();
            LoadCheckedInPatientList();
        }
    }

    private void Save()
    {
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
        AdminAppointmentData objAdminAppointmentData = objJavaScriptSerializer.Deserialize<AdminAppointmentData>(Request.Form["objAdminAppointmentData"]);

        _AppointmentsId = long.Parse(objAdminAppointmentData.id);

        Appointments objAppointments = new Appointments();

        objAppointments.AppointmentsId = _AppointmentsId;

        objAppointments.PracticeLocationsId = int.Parse(Request.Form["PracticeLocationsId"]);
        objAppointments.PatientId = long.Parse(objAdminAppointmentData.PatientId);

        objAppointments.AppointmentDate = DateTime.Parse(Request.Form["AppointmentDate"]);
        objAppointments.StartTime = DateTime.Parse(objAdminAppointmentData.start);
        objAppointments.EndTime = DateTime.Parse(objAdminAppointmentData.end);
        objAppointments.ServiceProviderId = long.Parse(objAdminAppointmentData.providerId);
        objAppointments.StatusId = int.Parse(objAdminAppointmentData.statusId);
        objAppointments.ReasonId = int.Parse(objAdminAppointmentData.reasonId);
        objAppointments.ResourceId = int.Parse(objAdminAppointmentData.userId);
        objAppointments.Notes = objAdminAppointmentData.Notes;
        objAppointments.BookingReferenceNo = objAdminAppointmentData.BookingReferenceNo;

        objAppointments.IsRecurrence = objAdminAppointmentData.IsRecurrence;
        objAppointments.RecurrenceDays = objAdminAppointmentData.RecurrenceDays;
        objAppointments.RecurrenceFrequency = objAdminAppointmentData.RecurrenceFrequency;
        objAppointments.RecurrenceUnit = objAdminAppointmentData.RecurrenceUnit;

        if (_AppointmentsId == 0)
        {
            objAppointments.CreatedById = Profile.UserId;
            objAppointments.CreatedDate = DateTime.Now;

            _AppointmentsId = objAppointmentsDB.Add(objAppointments);

            if (objAdminAppointmentData.IsRecurrence)
            {
                SaveReccurenceAppointments(_AppointmentsId, _AppointmentsId, objAppointments, objAdminAppointmentData);
            }
        }
        else
        {
            if (objAppointments.StatusId != 4)
            {
                DeleteCheckedInPatient();
            }

            objAppointments.ModifiedById = Profile.UserId;
            objAppointments.ModifiedDate = DateTime.Now;

            objAppointments.AppointmentsId = long.Parse(objAdminAppointmentData.id);
            objAppointmentsDB.Update(objAppointments);

            if (objAdminAppointmentData.IsRecurrence)
            {
                SaveReccurenceAppointments(objAppointments.AppointmentsId, objAdminAppointmentData.ParentAppointmentId, objAppointments, objAdminAppointmentData);
            }
        }

        ltrAppointmentsId.Text = _AppointmentsId.ToString();

        GetAppointmentColors();
    }

    private void Delete()
    {
        Appointments objAppointments = new Appointments();

        objAppointments.AppointmentsId = _AppointmentsId;
        objAppointments.DeleteReason = Request.Form["DeleteReason"];

        objAppointments.ModifiedById = Profile.UserId;
        objAppointments.ModifiedDate = DateTime.Now;

        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        objAppointmentsDB.Delete(objAppointments);
    }

    public void UpdateStatus()
    {
        Appointments objAppointments = new Appointments();

        objAppointments.AppointmentsId = _AppointmentsId;
        objAppointments.StatusId = _StatusId;
        objAppointments.CheckInRoomId = _CheckInRoomId;
        objAppointments.CheckInTime = DateTime.Now;

        objAppointments.ModifiedById = Profile.UserId;
        objAppointments.ModifiedDate = DateTime.Now;

        objAppointmentsDB.UpdateAppointmentStatus(objAppointments);

        DataTable dtAppointmentInfo = objAppointmentsDB.GetAppointmentByID(_AppointmentsId);

        if (dtAppointmentInfo.Rows.Count > 0)
        {
            ltrStatusColor.Text = dtAppointmentInfo.Rows[0]["StatusBackColor"].ToString();

            if (_StatusId == 4)
            {
                AddCheckedInPatient();
            }
            else
            {
                DeleteCheckedInPatient();
            }
        }
    }

    public void GetAppointmentColors()
    {
        DataTable dtAppointmentColors = objAppointmentsDB.GetAppointmentColors(_AppointmentsId);

        if (dtAppointmentColors.Rows.Count > 0)
        {
            ltrStatusBackColor.Text = dtAppointmentColors.Rows[0]["StatusBackColor"].ToString();
            ltrReasonBackColor.Text = dtAppointmentColors.Rows[0]["ReasonBackColor"].ToString();
        }
    }

    private void SaveReccurenceAppointments(long AppointmentsId, long ParentAppointmentId, Appointments objAppointments, AdminAppointmentData objAdminAppointmentData)
    {
        int Interval = 0;

        if (objAdminAppointmentData.IsRecurrence)
        {
            if (objAppointments.RecurrenceUnit == "Week")
            {
                Interval = (int.Parse(objAppointments.RecurrenceFrequency.ToString()) * 7);
            }
            else if (objAppointments.RecurrenceUnit == "Month")
            {
                Interval = (int.Parse(objAppointments.RecurrenceFrequency.ToString()) * 30);
            }

            objAppointmentsDB.Reccurence(AppointmentsId, ParentAppointmentId, objAppointments, Interval);
        }
    }

    public void AddCheckedInPatient()
    {
        DataTable dtAppointmentInfo = objAppointmentsDB.GetAppointmentByID(_AppointmentsId);

        CheckedInPatients objCheckedInPatients = _objJavaScriptSerializer.Deserialize<CheckedInPatients>(Request.Form["objCheckedInPatients"]);

        objCheckedInPatients.PracticeId = Profile.PracticeId;
        objCheckedInPatients.PracticeLocationsId = _PracticeLocationsId;

        objCheckedInPatients.AppointmentsId = _AppointmentsId;
        objCheckedInPatients.PatientId = _PatientId;

        if (dtAppointmentInfo.Rows.Count > 0)
        {
            objCheckedInPatients.AppointmentDate = Convert.ToDateTime(dtAppointmentInfo.Rows[0]["AppointmentDate"].ToString());
        }

        //objCheckedInPatients.ArrivalTime = _CurrentDateTime;
        //objCheckedInPatients.RoomId = _CheckInRoomId;
        //objCheckedInPatients.CheckInTime = _CurrentDateTime;

        objCheckedInPatients.CreatedById = Profile.UserId;
        objCheckedInPatients.CreatedDate = DateTime.Now;

        objCheckedInPatientsDB.Add(objCheckedInPatients);

        SavePatientInsurances();
    }

    public void DeleteCheckedInPatient()
    {
        CheckedInPatients objCheckedInPatients = new CheckedInPatients();

        objCheckedInPatients.AppointmentsId = _AppointmentsId;

        objCheckedInPatients.ModifiedById = Profile.UserId;
        objCheckedInPatients.ModifiedDate = DateTime.Now;

        objCheckedInPatientsDB.DeleteByAppointment(objCheckedInPatients);
    }

    public void UpdateHistoryCheckedInPatientByID()
    {
        CheckedInPatients objCheckedInPatients = new CheckedInPatients();

        objCheckedInPatients.CheckedInPatientsId = _CheckedInPatientsId;
        objCheckedInPatients.TimeInRoom = DateTime.Parse(Request.Form["TimeInRoom"]);

        objCheckedInPatients.ModifiedById = Profile.UserId;
        objCheckedInPatients.ModifiedDate = DateTime.Now;

        objCheckedInPatientsDB.UpdateHistory(objCheckedInPatients);
    }

    public void ChangeCheckInRoom()
    {
        CheckedInPatients objCheckedInPatients = new CheckedInPatients();

        objCheckedInPatients.PracticeId = Profile.PracticeId;
        objCheckedInPatients.PracticeLocationsId = _PracticeLocationsId;

        objCheckedInPatients.AppointmentsId = _AppointmentsId;

        DataTable dtCheckedInPatients = objCheckedInPatientsDB.GetByAppointmentsID(_AppointmentsId);

        if (dtCheckedInPatients.Rows.Count > 0)
        {
            objCheckedInPatients.PatientId = long.Parse(dtCheckedInPatients.Rows[0]["PatientId"].ToString());
            objCheckedInPatients.ArrivalTime = Convert.ToDateTime(dtCheckedInPatients.Rows[0]["ArrivalTime"].ToString());
            objCheckedInPatients.AppointmentDate = Convert.ToDateTime(dtCheckedInPatients.Rows[0]["AppointmentDate"].ToString());
        }

        objCheckedInPatients.RoomId = _CheckInRoomId;
        objCheckedInPatients.CheckInTime = _CurrentDateTime;

        objCheckedInPatients.CreatedById = Profile.UserId;
        objCheckedInPatients.CreatedDate = DateTime.Now;

        objCheckedInPatientsDB.Add(objCheckedInPatients);

        UpdateHistoryCheckedInPatientByID();
    }
    //// LoadCheckedInPatientList
    private void LoadCheckedInPatientList()
    {
        if (Request.Form["PracticeLocationsIdCheckedInPatientList"] != null)
        {
            long PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsIdCheckedInPatientList"]);

            CheckedInPatientsDB objCheckedInPatientsDB = new CheckedInPatientsDB();

            DataSet dsCheckedInroomMaster = objCheckedInPatientsDB.GetAllByDate(Profile.PracticeId, PracticeLocationsId, DateTime.Now);

            rptCheckedInPatients.DataSource = dsCheckedInroomMaster.Tables[0];
            rptCheckedInPatients.DataBind();
        }
       
    }

    protected void rptCheckedInPatients_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            long PracticeLocationsId = long.Parse(drv["PracticeLocationsId"].ToString());

            CheckInRoomManager objCheckInRoomManager = new CheckInRoomManager();
            DataTable dtRooms = objCheckInRoomManager.GetRoomsByPracticeLocations(PracticeLocationsId);

            Repeater rptPracticeRoomsMaster = e.Item.FindControl("rptPracticeRoomsMaster") as Repeater;
            rptPracticeRoomsMaster.DataSource = dtRooms;
            rptPracticeRoomsMaster.DataBind();
        }
    }

    private void UpdateStatusAfterWalkout()
    {
        _AppointmentsId = long.Parse(Request.Form["AppointmentsId"]);
        _StatusId = 5;
        _CheckInRoomId = 0;

        UpdateStatus();
    }

    private void SavePatientInsurances()
    {
        PatientInsurance objPatientInsurancePrimary = _objJavaScriptSerializer.Deserialize<PatientInsurance>(Request.Form["objPatientInsurancePrimary"]);

        PatientInsurance objPatientInsuranceSecondary = _objJavaScriptSerializer.Deserialize<PatientInsurance>(Request.Form["objPatientInsuranceSecondary"]);

        AddUpdatePatientInsurance(objPatientInsurancePrimary);
        AddUpdatePatientInsurance(objPatientInsuranceSecondary);
    }

    private void AddUpdatePatientInsurance(PatientInsurance objPatientInsurance)
    {
        PatientInsuranceDB objPatientInsuranceDB = new PatientInsuranceDB();

        if (objPatientInsurance.PatientInsuranceId != 0)
        {
            objPatientInsurance.ModifiedById = Profile.UserId;
            objPatientInsurance.ModifiedDate = DateTime.Now;

            objPatientInsuranceDB.UpdateInsuranceCardInfo(objPatientInsurance);
        }
    }
}