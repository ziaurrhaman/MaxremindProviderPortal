using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Scheduler_Scheduler : System.Web.UI.Page
{

    long _PracticeLocationId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPracticeLocations();
        loadReasons();
        LoadStatuses();
        LoadPracticeLocationsRooms();

        loadRefillRequests();
        TotalCounts();
    }

    public void LoadPracticeLocations()
    {
        long PracticeId = Profile.PracticeId;

        PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();

        ddLocationMain.DataSource = objPracticeLocationsDB.GetPracticeLocationsByPractice(PracticeId);

        ddLocationMain.DataValueField = "PracticeLocationsId";
        ddLocationMain.DataTextField = "Name";
        ddLocationMain.DataBind();

        long PracticeStaffId = 0;
        _PracticeLocationId = Profile.PracticeLocationsId;

        if (_PracticeLocationId == 0 && ddLocationMain.Items.Count > 0)
        {
            _PracticeLocationId = long.Parse(ddLocationMain.Items[0].Value);
        }
        else
        {
            ddLocationMain.SelectedValue = _PracticeLocationId.ToString();
            ddLocationMain.Enabled = false;

            PracticeStaffId = Profile.ServiceProviderId;
        }

        LoadServiceProviders(_PracticeLocationId, PracticeStaffId);
    }

    public void LoadServiceProviders(long PracticeLocationId, long PracticeStaffId)
    {
        PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
        DataTable dtProvider = objPracticeStaffDB.GetProvidersByPracticeLocation(PracticeLocationId, PracticeStaffId);

        ddDialogAppProvider.DataSource = dtProvider;
        ddDialogAppProvider.DataValueField = "PracticeStaffId";
        ddDialogAppProvider.DataTextField = "Name";
        ddDialogAppProvider.DataBind();

        rptServiceProviders.DataSource = dtProvider;
        rptServiceProviders.DataBind();
    }

    public void loadReasons()
    {
        ReasonsDB objReasonsDB = new ReasonsDB();
        ddReason.DataSource = objReasonsDB.GetAll();

        ddReason.DataValueField = "ReasonId";
        ddReason.DataTextField = "Description";
        ddReason.DataBind();
        ddReason.Items.Insert(0, new ListItem("Select", "0"));
    }

    private void LoadStatuses()
    {
        StatusesDB objStatusesDB = new StatusesDB();

        DataTable dtStatuses = objStatusesDB.GetAll();

        ddAppStatus.DataSource = dtStatuses;
        ddAppStatus.DataValueField = "StatusId";
        ddAppStatus.DataTextField = "StatusName";
        ddAppStatus.DataBind();
    }

    private void LoadAppointmentStatusWithColor()
    {
        AppointmentsDB objAppointmentsDB = new AppointmentsDB();
    }

    protected void rptAppointmentStatusLegend_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;
        string StatusId = drv["StatusId"].ToString();

        DropDownList ddlPatientAppointmentStatus = (DropDownList)e.Item.FindControl("ddlPatientAppointmentStatus");
        ddlPatientAppointmentStatus.SelectedValue = StatusId;
    }

    public void LoadPracticeLocationsRooms()
    {
        CheckInRoomManager objCheckInRoomManager = new CheckInRoomManager();
        DataTable dtRooms = objCheckInRoomManager.GetRoomsByPracticeLocations(_PracticeLocationId);

        ddlPracticeRooms.DataSource = dtRooms;
        ddlPracticeRooms.DataValueField = "RoomId";
        ddlPracticeRooms.DataTextField = "Name";
        ddlPracticeRooms.DataBind();
    }

    private void loadRefillRequests()
    {
        MedicationRefillRequestsDB objMedicationRefillRequestsDB = new MedicationRefillRequestsDB();
        rptRefillRequests.DataSource = objMedicationRefillRequestsDB.GetAll(Profile.PracticeId);
        rptRefillRequests.DataBind();
    }

    private void TotalCounts()
    {
        PTLReasonsManager objPTLReasonsManager = new PTLReasonsManager();

        DataSet dsTotalCounts = objPTLReasonsManager.TotalCounts(Profile.PracticeId);

        #region PTL Patient Count

      //  ((Label)(QuickLaunchBar1.FindControl("lblPTLCount"))).Text = "(" + dsTotalCounts.Tables[0].Rows[0]["TotalPTL"].ToString() + ")";

        #endregion
    }
}