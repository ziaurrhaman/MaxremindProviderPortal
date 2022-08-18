using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Controls_ProvidersByLocation : System.Web.UI.Page
{
    long _PracticeLocationId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        LoadServiceProviders();
        LoadPracticeLocationsRooms();
    }

    private void LoadServiceProviders()
    {
        _PracticeLocationId = long.Parse(Request.Form["PracticeLocationId"]);

        PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();

        DataTable dtProvider = objPracticeStaffDB.GetProvidersByPracticeLocation(_PracticeLocationId);

        rptServiceProviders.DataSource = dtProvider;
        rptServiceProviders.DataBind();

        rptServiceProvidersDropDown.DataSource = dtProvider;
        rptServiceProvidersDropDown.DataBind();
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
}