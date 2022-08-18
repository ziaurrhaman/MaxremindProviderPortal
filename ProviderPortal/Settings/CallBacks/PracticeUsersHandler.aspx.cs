using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using System.Text.RegularExpressions;

public partial class ProviderPortal_Settings_CallBacks_PracticeUsersHandler : System.Web.UI.Page
{
    string assignedUserId = ""; string PrividerPortalUser = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        string action = Request.Form["action"];
        if (action == "Save User") { AddUser(); }
        else if (action == "DeleteAssignPracticeofUser") { DeletePracticeUser(); }

        PracticeUsersDB objPracticeUsersDB = new PracticeUsersDB();
        DataSet dsUsers = objPracticeUsersDB.GetAllFilter(Profile.PracticeId, Profile.PracticeLocationsId, 0, Profile.ServiceProviderId, Rows, PageNumber, SortBy);
        rptUsers.DataSource = dsUsers.Tables[0];
        rptUsers.DataBind();

        ltrlRowsCount.Text= dsUsers.Tables[1].Rows[0]["TOTALROWS"].ToString();
        hdnUsersTotalCount.Value = dsUsers.Tables[1].Rows[0]["TOTALROWS"].ToString();
    }

    public void AddUser()
    {

        long UserId = 0;
        var serializer = new JavaScriptSerializer();
        var objJavaScriptSerializer = new JavaScriptSerializer();
        PracticeUsers practiceUsers = serializer.Deserialize<PracticeUsers>(Request.Form["User"]);
        UserRolesDB userRolesDB = new UserRolesDB();
        //UserRoles User_Roles = serializer.Deserialize<UserRoles>(Request.Form["UserRole"]);
        UserRoles User_Roles = new UserRoles();
        PracticeUsersDB PracticeUsersDB = new PracticeUsersDB();
        practiceUsers.CreatedById = Profile.UserId;
        practiceUsers.CreatedDate = DateTime.Now;
        practiceUsers.Deleted = false;

        //Check Sucess Data
        string UserN = practiceUsers.UserName;
        string UPassword = Request.Form["Password"].ToString();
        var regex = new Regex("^[A-Za-z0-9@#$_]+$");
        Match matchP = regex.Match(UPassword);
        Match matchUName = regex.Match(UserN);
        if (matchP.Success && matchUName.Success)
        {
            EncryptionAndDeccryption encryptionobj = new EncryptionAndDeccryption();
            // encryptionobj.Encrypt(Request.Form["Password"].ToString());
            practiceUsers.Password = encryptionobj.Encrypt(Request.Form["Password"].ToString());

            practiceUsers.PracticeId = Profile.PracticeId;
            if (!string.IsNullOrEmpty(Request.Form["Frontdesk"]))
            {
                PrividerPortalUser = Request.Form["Frontdesk"].ToString();
            }
            if (PrividerPortalUser == "true")
            {
               //practiceUsers.ProviderPortalUsers = true;
            }
            else
            {
                //practiceUsers.ProviderPortalUsers = false;
            }

            if (Request.Form["UserId"] == null || Request.Form["UserId"] == "0" || Request.Form["UserId"] == "")
            {
                practiceUsers.UserType = "6";
                practiceUsers.ProviderPortalUsers = true;
                practiceUsers.StaffShift = "Morning";
                UserId = PracticeUsersDB.Add(practiceUsers);
                UserId = practiceUsers.UserId;
                User_Roles.UserId = UserId;
                User_Roles.RoleId = Convert.ToInt64(Request.Form["UserRoleId"].ToString());
                User_Roles.ModifiedById = Convert.ToInt32(Profile.UserId);
                User_Roles.ModifiedDate = DateTime.Now;
                User_Roles.Deleted = false;
                userRolesDB.Add(User_Roles);
                assignedUserId = "0";
                SaveUserAssignedPratice_And_UserJd(UserId);

            }
            else
            {


                practiceUsers.UserId = Convert.ToInt64(Request.Form["UserId"]);
                practiceUsers.UserType = "6";
                practiceUsers.ProviderPortalUsers = true;
                practiceUsers.StaffShift="Morning";
                
                User_Roles.UserId = practiceUsers.UserId;
                User_Roles.RoleId = Convert.ToInt64(Request.Form["UserRoleId"].ToString()); 
                User_Roles.ModifiedById = Convert.ToInt32(Profile.UserId);
                User_Roles.ModifiedDate = DateTime.Now;
                User_Roles.Deleted = false;
                userRolesDB.Update(User_Roles);
                PracticeUsersDB.Update(practiceUsers);
                assignedUserId = Request.Form["UserId"].ToString();
                long UserRoleId = Convert.ToInt64(Request.Form["UserRoleId"]);
                //SaveUserAssignedPratice_And_UserJd(Convert.ToInt64(Request.Form["UserId"]));

            }
        }
        else
        {
            //AUMessage.Attributes.Add("style", "display:block");
        }
    }

    private void SaveUserAssignedPratice_And_UserJd(long UserId)
    {


        UserAssignedPractices objcs = new UserAssignedPractices();
        UserAssignedPracticeDB db = new UserAssignedPracticeDB();
        //BillingTaskDB BTdb = new BillingTaskDB();
        UserJd ObjCsJd = new UserJd();
        UserJdDB dbJd = new UserJdDB();

            assignedUserId = Request.Form["UserId"].ToString();
            objcs.UserId = UserId;

            //string splitedBillingTaskId = splitedIds.Substring(0, index2);
            //string splitedUserJdId = splitedIds.Substring(index2 + 1);

            objcs.PracticeId = Convert.ToInt64(Profile.PracticeId);
            objcs.CreatedById = Profile.UserId;
            objcs.CreatedDate = DateTime.Now;
            objcs.PraticeLocation = 0;
            objcs.IsActive = true;
            objcs.Deleted = false;

            ObjCsJd.UserId = UserId;
            ObjCsJd.PracticeId = Convert.ToInt64(Profile.PracticeId);
            //f (string.IsNullOrEmpty(splitedBillingTaskId)) { splitedBillingTaskId = "0"; }
            ObjCsJd.TaskId = 1;
            ObjCsJd.CreatedDate = DateTime.Now;
            ObjCsJd.CreatedById = Profile.UserId;
            ObjCsJd.Deleted = false;
            if (assignedUserId == "0")
            {
                dbJd.Add(ObjCsJd);
                db.Add(objcs);
            }
    }

    private void DeletePracticeUser()
    {
        long UserId = Convert.ToInt32(Request.Form["UserId"]);
        string type = Request.Form["type"];
        long PracticeId = Profile.PracticeId;
        PracticeUsersDB db = new PracticeUsersDB();
        db.UserAssignedPracticesDelete(UserId, PracticeId, type);

    }
}