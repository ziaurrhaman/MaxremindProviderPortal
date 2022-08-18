using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
public partial class BillingManager_BillingMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Add Practice id in this array For showing of RPM // used string to handle this using Jquary
        //string RPMPractices = "1026,1000";
        //string[] RPMPracticesarrey = RPMPractices.Split(','); 
        //    for (int i = 0; i < RPMPracticesarrey.Length; i++)
        //    {
           
        //      if(Profile.PracticeId == long.Parse(RPMPracticesarrey[i]))
        //         {
        //        _dashboardRPM.Style.Add("display", "");
        //         }
              
             
        //        //_dashboardRPM.Visible = (Profile.PracticeId == long.Parse(RPMPracticesarrey[i])) ? true : _dashboardRPM.Visible = false;
        //    }
        //hdnRPMPractices.Value = RPMPractices.ToString();
        RPMDashBoardSideBar.Value = Profile.PracticeId.ToString();
        ltrScript.Text = Profile.Rights;
        userType.Value = Profile.UserType;
        /**********Profile Dropdown Main**********/
        hdnPracticeId.Value = Profile.PracticeId.ToString();
        string userName = Profile.LastName + " " + Profile.FirstName;
        if (Profile.SpecificUserName != "" && Profile.SpecificUserName != " " && Profile.SpecificUserName != null)
        {
            lblUsername.Text = Profile.SpecificUserName;
            hdnPracticeId.Value = "0";
            Profile.PracticeId = 0;
        }
        else { lblUsername.Text = userName; }

        //imgProfileImageOnWelcome.ImageUrl = "~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/Staff/" + Profile.ProfilePicturePath;

        string ProfileImagePath = "~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/Staff/" + Profile.ProfilePicturePath;

        string ProfileImagePhysicalPath = Server.MapPath("~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/Staff/" + Profile.ProfilePicturePath);

        if (!File.Exists(ProfileImagePhysicalPath))
        {
            if (Profile.Gender == "Female")
            {
                ProfileImagePath = "~/Images/FemaleIcon.png";
            }
            else
            {
                ProfileImagePath = "~/Images/maleIcon.png";
            }
        }

        imgProfielPicture.ImageUrl = ProfileImagePath;



        CreateStatesUTCList();
        GetPracticesDetails();
        //string r = Profile.IsImported;
        ////if (Profile.IsImported != "True") { 
        ////    ddlIsImported.Style.Add("display", "none"); 

        ////}
        //if (Profile.IsImported == "True")
        //{
        //    string isimported = "";
        //    if (string.IsNullOrEmpty(Session["IsImported"] as string))
        //    {
        //        isimported = "0";
        //    }
        //    else
        //    {
        //        isimported = Session["IsImported"].ToString();
        //    }
        //    if (isimported == "1")
        //    {
        //        ddlIsImported.SelectedIndex = 1;
        //    }
        //    else if (isimported == "2")
        //    {
        //        ddlIsImported.SelectedIndex = 2;
        //    }
        //    else { ddlIsImported.SelectedIndex = 0; }
        //}


        GetCountstatus206();

    }


    private void CreateStatesUTCList()
    {
        PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();

        DataTable dtLocationStatesUTC = objPracticeLocationsDB.GetLocationStatesUTC(Profile.PracticeId);

        StringBuilder providersByLocationScript = new StringBuilder();
        providersByLocationScript.Append("<script type='text/javascript'>");
        providersByLocationScript.Append("var _arrLocationStateUTC = {");

        for (int i = 0; i < dtLocationStatesUTC.Rows.Count; i++)
        {
            providersByLocationScript.Append(dtLocationStatesUTC.Rows[i]["PracticeLocationsId"].ToString() + ": " + dtLocationStatesUTC.Rows[i]["UTC"].ToString());

            if (i < (dtLocationStatesUTC.Rows.Count - 1))
            {
                providersByLocationScript.Append(", ");
            }
        }

        providersByLocationScript.Append("};");
        providersByLocationScript.Append("</script>");
        ltrStatesUTC.Text = providersByLocationScript.ToString();
    }


    private void GetPracticesDetails()
    {
        PracticeUsersDB objPracticeUserDB = new PracticeUsersDB();
        DataTable objDataTable = objPracticeUserDB.GetUserProfile_WithSelectedPractice(Profile.UserId, Profile.PracticeId);
        if (objDataTable.Rows.Count > 0)
        {
            User_Type.Value = objDataTable.Rows[0]["UserType"].ToString();
        }
    }

   private void GetCountstatus206()
    {
        ClaimDB db = new ClaimDB();
        string count = db.CountEsclatedToProvider(Profile.PracticeId);

        if (Convert.ToInt32(count) > 0)
        {
            lblstatus206.Text = count;
        }
        else
        {
            lblstatus206.Text = "0";
        }
    }
}
