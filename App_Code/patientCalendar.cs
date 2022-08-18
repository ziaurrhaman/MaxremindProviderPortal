using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Web.Script.Serialization;
using System.Globalization;

/// <summary>
/// Summary description for patientCalendar
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class patientCalendar : System.Web.Services.WebService {

    public patientCalendar () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }


    [WebMethod(EnableSession = true)]
    public AppointmentResponseData SaveAppointments(AdminAppointmentData appData, string loc_id, string app_date)
    {
        AppointmentResponseData objAppointmentResponseData = new AppointmentResponseData();

        DateTime currentDateTime = DateTime.Now;
        string updatedTime = currentDateTime.ToString("hh:mm tt");

        DateTime start;
        DateTime end;
        string startTime = "";
        string endTime = "";
        string query = "";
        string patiant_id = "";
        string statusId = "";
        string appStatus = "";
        SqlDataReader dr = null;

        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long userId = objProfileCommon.UserId;
        AppointmentsDB objAppointmentsDB = new AppointmentsDB();

        start = DateTime.Parse(appData.start);
        startTime = start.ToString("yyyy-MM-dd HH:mm:ss");
        end = DateTime.Parse(appData.end);
        endTime = end.ToString("yyyy-MM-dd HH:mm:ss");
        patiant_id = appData.PatientId;

        Appointments objAppointments = new Appointments();

        objAppointments.PracticeLocationsId = int.Parse(loc_id);
        objAppointments.PatientId = long.Parse(patiant_id);
        objAppointments.AppointmentDate = DateTime.Parse(app_date);
        objAppointments.StartTime = DateTime.Parse(startTime);
        objAppointments.EndTime = DateTime.Parse(endTime);
        objAppointments.ServiceProviderId = long.Parse(appData.providerId);
        objAppointments.StatusId = int.Parse(appData.statusId);
        objAppointments.BookingReferenceNo = appData.BookingReferenceNo;

        if (appData.reasonId == null)
        {
            appData.reasonId = "0";
        }

        objAppointments.ReasonId = int.Parse(appData.reasonId);
        objAppointments.ResourceId = int.Parse(appData.userId);
        objAppointments.Notes = appData.Notes;

        objAppointments.ModifiedById = userId;
        objAppointments.ModifiedDate = currentDateTime;

        if (appData.id.Contains("new"))
        {
            if (appData.statusId == "2" || appData.statusId == "3")
            {
                if (appData.statusId == "2")
                {
                    appStatus = "Confirmed";
                }
                else if (appData.statusId == "3")
                {
                    appStatus = "Cancelled";
                }

                prepareEmail(patiant_id, appStatus);
            }

            objAppointments.CreatedById = userId;
            objAppointments.CreatedDate = currentDateTime;

            objAppointmentResponseData.AppointmentId = objAppointmentsDB.Add(objAppointments);

            objAppointmentResponseData.status_back_color = objAppointmentsDB.GetAppointmentStatusBackColor(objAppointmentResponseData.AppointmentId);
            objAppointmentResponseData.reason_back_color = objAppointmentsDB.GetAppointmentReasonBackColor(objAppointmentResponseData.AppointmentId);
        }
        else
        {
            if (appData.statusId == "2" || appData.statusId == "3")
            {
                query = "Select StatusId From [Appointments] Where AppointmentsId = '" + appData.id + "'";

                dr = DB.GetData(query);
                if (dr.Read())
                {
                    statusId = dr["StatusId"].ToString();
                }
                dr.Close();

                if (appData.statusId != statusId)
                {
                    if (appData.statusId == "2")
                    {
                        appStatus = "Confirmed";
                    }
                    else if (appData.statusId == "3")
                    {
                        appStatus = "Cancelled";
                    }
                }
            }

            if (appData.statusId != "4")
            {
                DeleteCheckedInPatient(long.Parse(appData.id));
            }

            objAppointments.AppointmentsId = long.Parse(appData.id);
            objAppointmentsDB.Update(objAppointments);

            objAppointmentResponseData.status_back_color = objAppointmentsDB.GetAppointmentStatusBackColor(long.Parse(appData.id));
            objAppointmentResponseData.reason_back_color = objAppointmentsDB.GetAppointmentReasonBackColor(long.Parse(appData.id));

            objAppointmentResponseData.isUpdated = true;
        }

        objAppointmentResponseData.updatedTime = updatedTime;

        return objAppointmentResponseData;
    }

    private bool prepareEmail(string patiant_id, string appStatus)
    {
        return true;
        string FromEmail = "";
        string password = "";
        string host = "";
        string port = "";

        string query = "Select * From [Server_Configuration]";
        SqlDataReader drMail = null; // DB.GetData(query);

        if (drMail.Read())
        {
            FromEmail = drMail["email_account"].ToString();
            password = drMail["password"].ToString();
            host = drMail["host_name"].ToString();
            port = drMail["port"].ToString();
        }

        drMail.Close();

        query = "Select Email_Address From [Patient] Where Pat_ID = '" + patiant_id + "'";


        string msg = "Your appointment has been " + appStatus + " by the admin";
        string sub = "Appointment Alert From VCC";
        string email = "";// DB.GetValue(query).ToString();

        return sendEmail(msg, sub, email, FromEmail, password, host, port);

    }

    private bool sendEmail(string msg, string sub, string ToEmail, string FromEmail, string password, string host, string port)
    {

        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential(FromEmail, password);
        client.Port = 25;
        client.Host = host;
        client.EnableSsl = false;
        MailMessage mail = new MailMessage(FromEmail, ToEmail, sub, msg);
        mail.IsBodyHtml = true;
        try
        {
            client.Send(mail);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public void DeleteCheckedInPatient(long AppointmentsId)
    {
        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long UserId = objProfileCommon.UserId;

        CheckedInPatients objCheckedInPatients = new CheckedInPatients();

        objCheckedInPatients.AppointmentsId = AppointmentsId;

        objCheckedInPatients.ModifiedById = UserId;
        objCheckedInPatients.ModifiedDate = DateTime.Now;

        CheckedInPatientsDB objCheckedInPatientsDB = new CheckedInPatientsDB();
        objCheckedInPatientsDB.DeleteByAppointment(objCheckedInPatients);
    }

    [WebMethod]
    public AppointmentResponseData UpdateAppointmentStatus(string AppointmentsId, string StatusId)
    {
        AppointmentResponseData objAppointmentResponseData = new AppointmentResponseData();

        DateTime currentDateTime = DateTime.Now;
        string updatedTime = currentDateTime.ToString("hh:mm tt");

        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long userId = objProfileCommon.UserId;

        Appointments objAppointments = new Appointments();
        objAppointments.AppointmentsId = int.Parse(AppointmentsId);
        objAppointments.StatusId = int.Parse(StatusId);
        objAppointments.ModifiedById = userId;
        objAppointments.ModifiedDate = currentDateTime;

        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        objAppointmentsDB.UpdateStatus(objAppointments);

        objAppointmentResponseData.isUpdated = true;
        objAppointmentResponseData.updatedTime = updatedTime;

        objAppointmentResponseData.status_back_color = objAppointmentsDB.GetAppointmentStatusBackColor(long.Parse(AppointmentsId));

        return objAppointmentResponseData;
    }

    [WebMethod]
    public bool UpdateAppointmentTime(long AppointmentsId, DateTime EndTime)
    {
        DateTime end;
        string endTime = "";
        end = EndTime.ToLocalTime();
        endTime = end.ToString("yyyy-MM-dd HH:mm:ss");

        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        long userId = objProfileCommon.UserId;

        Appointments objAppointments = new Appointments();

        objAppointments.EndTime = DateTime.Parse(endTime);
        objAppointments.AppointmentsId = AppointmentsId;

        objAppointments.ModifiedById = userId;
        objAppointments.ModifiedDate = DateTime.Now;

        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        objAppointmentsDB.UpdateAppointmentTime(objAppointments);
        return true;
    }

    /*
    [WebMethod(EnableSession = true)]
    public AppointmentDataSource LoadAppointments(string app_date, string loc_id, string prov_id, string day)
    {
        if (string.IsNullOrEmpty(prov_id))
        {
            PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
            prov_id = objPracticeStaffDB.GetTop1ByPracticeLocation(int.Parse(loc_id));
        }
        
        if (prov_id == "") prov_id = "0";
        
        List<AppointmentEventData> listEvents = new List<AppointmentEventData>();

        List<AppointmentFreeBusyData> listFreeBusy = new List<AppointmentFreeBusyData>();
        
        List<Statuses> listStatusData = LoadStatuses();
        
        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        
        DataTable dtApp = new DataTable();

        if (loc_id != "null" && prov_id != "undefined")
        {
            dtApp = objAppointmentsDB.GetAll(DateTime.Parse(app_date), int.Parse(loc_id), long.Parse(prov_id));
        }
        
        for (int i = 0; i < dtApp.Rows.Count; i++)
        {
            AppointmentEventData objClientAppEventsData = new AppointmentEventData();
            objClientAppEventsData.id = dtApp.Rows[i]["AppointmentsId"].ToString();
            DateTime startTime = DateTime.Parse(dtApp.Rows[i]["StartTime"].ToString());
            objClientAppEventsData.start = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime endTime = DateTime.Parse(dtApp.Rows[i]["EndTime"].ToString());
            objClientAppEventsData.end = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            objClientAppEventsData.patiant = dtApp.Rows[i]["Name"].ToString();
            objClientAppEventsData.patiantId = dtApp.Rows[i]["PatientId"].ToString();
            objClientAppEventsData.providerId = dtApp.Rows[i]["ServiceProviderId"].ToString();
            objClientAppEventsData.reasonId = dtApp.Rows[i]["ReasonId"].ToString();
            objClientAppEventsData.status = dtApp.Rows[i]["StatusName"].ToString();
            objClientAppEventsData.status_back_color = dtApp.Rows[i]["StatusBackColor"].ToString();
            objClientAppEventsData.reason_back_color = dtApp.Rows[i]["BackColor"].ToString();
            objClientAppEventsData.status_list = listStatusData;
            objClientAppEventsData.statusId = dtApp.Rows[i]["StatusId"].ToString();
            objClientAppEventsData.userId = Convert.ToInt32(dtApp.Rows[i]["ResourceId"].ToString());
            objClientAppEventsData.title = "";
            listEvents.Add(objClientAppEventsData);
        }
        
        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();

        DataTable dtTimingsByProvider = new DataTable();

        if (!((prov_id == "null") || (prov_id == "undefined")))
        {
            dtTimingsByProvider = objTimeSettingsDB.GetTimingsByProvider(int.Parse(day), "Provider", int.Parse(prov_id));
        }
        
        int BreakTypeId = 0;
        PracticeLocations objBussinessHours = new PracticeLocations();
        
        objBussinessHours.Bussiness_start_Time = 0;
        objBussinessHours.Bussiness_end_Time = 24;

        int Users = 1;
        if (loc_id != "null")
        {
            Users = LoadUsers(loc_id);
        }
        bool isOffDay = false;
        
        if (dtTimingsByProvider.Rows.Count > 0)
        {
            for (int i = 0; i < Users; i++)
            {
                AppointmentFreeBusyData objOpenHours = new AppointmentFreeBusyData();
                objOpenHours.start = app_date + " " + dtTimingsByProvider.Rows[0]["TimeFrom"].ToString();
                objOpenHours.end = app_date + " " + dtTimingsByProvider.Rows[0]["TimeTo"].ToString();
                objOpenHours.free = true;
                objOpenHours.userId = i;

                listFreeBusy.Add(objOpenHours);

                AppointmentFreeBusyData objBreakHours = new AppointmentFreeBusyData();
                objBreakHours.start = app_date + " " + dtTimingsByProvider.Rows[0]["BreakStart"].ToString();
                objBreakHours.end = app_date + " " + dtTimingsByProvider.Rows[0]["BreakEnd"].ToString();
                objBreakHours.free = false;
                objBreakHours.userId = i;

                listFreeBusy.Add(objBreakHours);
            }
        }
        else
        {
            isOffDay = true;
        }
        
        JavaScriptSerializer ser = new JavaScriptSerializer();
        string eventData = ser.Serialize(listEvents);
        string freebusyData = ser.Serialize(listFreeBusy);
        
        List<PracticeLocations> bussinessHoursData = new List<PracticeLocations>();
        bussinessHoursData.Add(objBussinessHours);
        
        AppointmentDataSource objDatasource = new AppointmentDataSource()
        {
            events = eventData,
            freebusys = freebusyData,
            businessHours = bussinessHoursData,
            userLength = Users,
            isOffDay = isOffDay
        };
        
        return objDatasource;
    }
    */

    [WebMethod(EnableSession = true)]
    public AppointmentDataSource LoadAppointments(string app_date, string loc_id, string prov_id, string day, int UsersLength, long PatientId)
    {
        if (string.IsNullOrEmpty(prov_id))
        {
            PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
            prov_id = objPracticeStaffDB.GetTop1ByPracticeLocation(int.Parse(loc_id));
        }

        List<AppointmentEventData> listEvents = new List<AppointmentEventData>();

        List<AppointmentFreeBusyData> listFreeBusy = new List<AppointmentFreeBusyData>();
        List<AppointmentFreeBusyData> listFreeBusyPatients = new List<AppointmentFreeBusyData>();

        List<Statuses> listStatusData = LoadStatuses();

        AppointmentsDB objAppointmentsDB = new AppointmentsDB();

        DataTable dtApp = new DataTable();

        if (loc_id != "null" && prov_id != "undefined")
        {
            dtApp = objAppointmentsDB.GetAllByProviders(DateTime.Parse(app_date), int.Parse(loc_id), prov_id);
        }

        List<string> listProviders = prov_id.Split(',').ToList<string>();

        for (int i = 0; i < dtApp.Rows.Count; i++)
        {
            AppointmentEventData objClientAppEventsData = new AppointmentEventData();

            objClientAppEventsData.id = dtApp.Rows[i]["AppointmentsId"].ToString();
            DateTime startTime = DateTime.Parse(dtApp.Rows[i]["StartTime"].ToString());
            objClientAppEventsData.start = startTime.ToString("yyyy-MM-dd HH:mm:ss");
            DateTime endTime = DateTime.Parse(dtApp.Rows[i]["EndTime"].ToString());
            objClientAppEventsData.end = endTime.ToString("yyyy-MM-dd HH:mm:ss");
            objClientAppEventsData.PatientName = dtApp.Rows[i]["Name"].ToString();
            objClientAppEventsData.PatientId = dtApp.Rows[i]["PatientId"].ToString();
            objClientAppEventsData.providerId = dtApp.Rows[i]["ServiceProviderId"].ToString();
            objClientAppEventsData.reasonId = dtApp.Rows[i]["ReasonId"].ToString();
            objClientAppEventsData.status = dtApp.Rows[i]["StatusName"].ToString();
            objClientAppEventsData.status_back_color = dtApp.Rows[i]["StatusBackColor"].ToString();
            objClientAppEventsData.reason_back_color = dtApp.Rows[i]["BackColor"].ToString();
            objClientAppEventsData.status_list = listStatusData;
            objClientAppEventsData.statusId = dtApp.Rows[i]["StatusId"].ToString();
            objClientAppEventsData.Notes = dtApp.Rows[i]["Notes"].ToString();
            objClientAppEventsData.BookingReferenceNo = dtApp.Rows[i]["BookingReferenceNo"].ToString();
            objClientAppEventsData.EligibilityStatus = dtApp.Rows[i]["EligibilityStatus"].ToString();

            objClientAppEventsData.ParentAppointmentId = long.Parse(dtApp.Rows[i]["ParentAppointmentId"].ToString());
            objClientAppEventsData.IsRecurrence = bool.Parse(dtApp.Rows[i]["IsRecurrence"].ToString());
            objClientAppEventsData.RecurrenceDays = dtApp.Rows[i]["RecurrenceDays"].ToString();
            objClientAppEventsData.RecurrenceFrequency = int.Parse(dtApp.Rows[i]["RecurrenceFrequency"].ToString());
            objClientAppEventsData.RecurrenceUnit = dtApp.Rows[i]["RecurrenceUnit"].ToString();

            objClientAppEventsData.DateOfBirth = dtApp.Rows[i]["DateOfBirth"].ToString();
            objClientAppEventsData.Gender = dtApp.Rows[i]["Gender"].ToString();
            objClientAppEventsData.MaritalStatus = dtApp.Rows[i]["MaritalStatus"].ToString();
            objClientAppEventsData.Cell = dtApp.Rows[i]["Cell"].ToString();
            objClientAppEventsData.HomePhone = dtApp.Rows[i]["HomePhone"].ToString();
            objClientAppEventsData.WorkPhone = dtApp.Rows[i]["WorkPhone"].ToString();
            objClientAppEventsData.City = dtApp.Rows[i]["City"].ToString();
            objClientAppEventsData.State = dtApp.Rows[i]["State"].ToString();
            objClientAppEventsData.Zip = dtApp.Rows[i]["Zip"].ToString();
            objClientAppEventsData.Address = dtApp.Rows[i]["Address"].ToString();
            objClientAppEventsData.ImagePath = dtApp.Rows[i]["ImagePath"].ToString();

            string ResouceId = dtApp.Rows[i]["ServiceProviderId"].ToString();
            int userId = listProviders.IndexOf(ResouceId);

            objClientAppEventsData.userId = userId; // Convert.ToInt32(dtApp.Rows[i]["ResourceId"].ToString());
            objClientAppEventsData.title = "";


            if (PatientId.ToString() != objClientAppEventsData.PatientId)
            {
                AppointmentFreeBusyData objBreakHours = new AppointmentFreeBusyData();
                objBreakHours.start = objClientAppEventsData.start;
                objBreakHours.end = objClientAppEventsData.end;
                objBreakHours.free = false;
                objBreakHours.userId = userId;
                
                listFreeBusyPatients.Add(objBreakHours);
            }
            else
            {
                listEvents.Add(objClientAppEventsData);
            }
        }

        TimeSettingsDB objTimeSettingsDB = new TimeSettingsDB();

        DataTable dtTimingsByProvider = new DataTable();

        if (!((prov_id == "null") || (prov_id == "undefined")))
        {
            dtTimingsByProvider = objTimeSettingsDB.GetTimingsByProviders(int.Parse(day), "Provider", prov_id);
        }

        PracticeLocations objBussinessHours = new PracticeLocations();

        objBussinessHours.Bussiness_start_Time = 0;
        objBussinessHours.Bussiness_end_Time = 24;

        bool isOffDay = false;

        if (dtTimingsByProvider.Rows.Count > 0)
        {
            for (int j = 0; j < dtTimingsByProvider.Rows.Count; j++)
            {
                string ResouceId = dtTimingsByProvider.Rows[j]["ResourceId"].ToString();

                int userId = listProviders.IndexOf(ResouceId);

                if (userId != -1)
                {
                    AppointmentFreeBusyData objOpenHours = new AppointmentFreeBusyData();
                    objOpenHours.start = app_date + " " + dtTimingsByProvider.Rows[j]["TimeFrom"].ToString();
                    objOpenHours.end = app_date + " " + dtTimingsByProvider.Rows[j]["TimeTo"].ToString();
                    objOpenHours.free = true;
                    objOpenHours.userId = userId;

                    listFreeBusy.Add(objOpenHours);

                    AppointmentFreeBusyData objBreakHours = new AppointmentFreeBusyData();
                    objBreakHours.start = app_date + " " + dtTimingsByProvider.Rows[j]["BreakStart"].ToString();
                    objBreakHours.end = app_date + " " + dtTimingsByProvider.Rows[j]["BreakEnd"].ToString();
                    objBreakHours.free = false;
                    objBreakHours.userId = userId;

                    listFreeBusy.Add(objBreakHours);
                }
            }
            
            foreach (AppointmentFreeBusyData objAppointmentFreeBusyData in listFreeBusyPatients)
            {
                listFreeBusy.Add(objAppointmentFreeBusyData);
            }
        }
        else
        {
            isOffDay = true;
        }


        JavaScriptSerializer ser = new JavaScriptSerializer();
        string eventData = ser.Serialize(listEvents);
        string freebusyData = ser.Serialize(listFreeBusy);

        List<PracticeLocations> bussinessHoursData = new List<PracticeLocations>();
        bussinessHoursData.Add(objBussinessHours);

        AppointmentDataSource objDatasource = new AppointmentDataSource()
        {
            events = eventData,
            freebusys = freebusyData,
            businessHours = bussinessHoursData,
            userLength = UsersLength,
            isOffDay = isOffDay
        };

        return objDatasource;
    }

    [WebMethod]
    public int LoadUsers(string loc_id)
    {

        PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();

        DataTable dtPracticeLocation = objPracticeLocationsDB.GetByID(Convert.ToInt32(loc_id));

        if (dtPracticeLocation.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtPracticeLocation.Rows[0]["ConcurrentPatients"].ToString()))
            {
                return Convert.ToInt32(dtPracticeLocation.Rows[0]["ConcurrentPatients"].ToString());
            }
        }

        return 3;
    }

    [WebMethod]
    public List<Statuses> LoadStatuses()
    {
        List<Statuses> listStatusData = new List<Statuses>();

        StatusesDB objStatusesDB = new StatusesDB();

        DataTable dt = objStatusesDB.GetAll();

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            Statuses objStatuses = new Statuses();
            objStatuses.StatusId = Convert.ToInt32(dt.Rows[i]["StatusId"].ToString());
            objStatuses.StatusName = dt.Rows[i]["StatusName"].ToString();
            listStatusData.Add(objStatuses);
        }

        return listStatusData;
    }

    [WebMethod]
    public int SavePatiant(string firstName, string middleName, string lastName, string gender, string birthDate, string primaryNum, string mobileNum, string email, string address, string streetAddress, string city, string state, string zip)
    {
        string query = "Insert into [Patient] values('" + lastName + "', '" + firstName + "', '" + middleName + "', '" + gender + "', '" + birthDate + "', '" + address + "', '" + city + "', '" + state + "', '" + zip + "', 'cu', '" + primaryNum + "', '" + mobileNum + "', '" + email + "', '', 'enable', 'False', '')";
        //DB.executeQuery(query);

        query = "Select top 1 Pat_id From [Patient] Order By Pat_id desc";
        SqlDataReader dr = null; // DB.GetData(query);

        if (dr.Read())
        {
            return Convert.ToInt32(dr["Pat_id"].ToString());
        }
        dr.Close();
        return 0;
    }
}
