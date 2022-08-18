using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Controls_CheckedInPatientsHandler : System.Web.UI.Page
{
    DataSet _ds_checkedInroomMaster;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];

        if (action == "LoadCheckedInPatientList")
        {
            LoadCheckedInPatientList();
        }
    }

    private void LoadCheckedInPatientList()
    {
        long PracticeId = Profile.PracticeId;
        if (Request.Form["PracticeLocationsId"] != null)
        {
            long PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsId"]);

            CheckedInPatientsDB objCheckedInPatientsDB = new CheckedInPatientsDB();

            _ds_checkedInroomMaster = objCheckedInPatientsDB.GetAllByDate(PracticeId, PracticeLocationsId, DateTime.Now);

            rptCheckedInPatients.DataSource = _ds_checkedInroomMaster.Tables[0];
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
}