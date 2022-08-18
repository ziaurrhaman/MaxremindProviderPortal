using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Settings_CallBacks_PracticeUsers : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        RolesDB roleobj = new RolesDB();
        ddlUsersRoles.DataSource = roleobj.GetRoles(Profile.PracticeId);
        ddlUsersRoles.DataTextField = "RoleName";
        ddlUsersRoles.DataValueField = "Roleid";
        ddlUsersRoles.DataBind();
    


        string action = Request.Form["action"];
        if (action == "Update") { 
            EditUserInfo();
            return;
        }

        else
        {
             ddlUsersRoles.Items.Insert(0, new ListItem("", ""));
        }

        if (action == "CheckAlreadyExistUser") { GetAlreadyExistUser(); }

        PracticeUsersDB objPracticeUsersDB = new PracticeUsersDB();

        DataSet dsUsers = objPracticeUsersDB.GetAllFilter(Profile.PracticeId, Profile.PracticeLocationsId, 0, Profile.ServiceProviderId, 10, 0, "");
        rptUsers.DataSource = dsUsers.Tables[0];
        rptUsers.DataBind();

        if(dsUsers.Tables[1].Rows.Count>0)
        hdnUsersTotalCount.Value = dsUsers.Tables[1].Rows[0]["TOTALROWS"].ToString();

       
    }

    protected void EditUserInfo()
    {
        long UserId = Convert.ToInt64(Request.Form["UserId"]);
        PracticeUsersDB objPracticeUsersDB = new PracticeUsersDB();
        DataSet ds = objPracticeUsersDB.ShowUserAssignedPractices(UserId);
        //ListUserTypes();

        txtUserFName.Value = ds.Tables[1].Rows[0]["FirstName"].ToString();
        txtUserLName.Value = ds.Tables[1].Rows[0]["LastName"].ToString();
        txtUserMName.Value = ds.Tables[1].Rows[0]["MiddleName"].ToString();
        txtUserName.Value = ds.Tables[1].Rows[0]["UserName"].ToString();
        txtEmail.Value = ds.Tables[1].Rows[0]["EmailAddress"].ToString();
        txtPhone.Value = ds.Tables[1].Rows[0]["PhoneNumber"].ToString();
        string userId = ds.Tables[1].Rows[0]["RoleId"].ToString();
        ddlUsersRoles.SelectedValue=userId;
        EncryptionAndDeccryption deccryptionObj = new EncryptionAndDeccryption();
        string decryptedPass = "";
        System.Text.RegularExpressions.Regex regex = new 
            System.Text.RegularExpressions.Regex(@"^([A-Za-z0-9+/]{4})*([A-Za-z0-9+/]{4}|[A-Za-z0-9+/]{3}=|[A-Za-z0-9+/]{2}==)$");
        var password = ds.Tables[1].Rows[0]["Password"].ToString();
        if (regex.Match(ds.Tables[1].Rows[0]["Password"].ToString()).Success)
        {

            decryptedPass = deccryptionObj.Decrypt(ds.Tables[1].Rows[0]["Password"].ToString());
            if (decryptedPass == "")
            {
                decryptedPass = password;
            }
        }
        else
        {
            decryptedPass = ds.Tables[1].Rows[0]["Password"].ToString();
        }


        hdnPassord.Value = decryptedPass;

        string chkUserStauts = ds.Tables[1].Rows[0]["IsActive"].ToString();

        if (chkUserStauts == "True")
        {
            this.chkUserStauts.Checked = true;
        }
        else
        {
            this.chkUserStauts.Checked = false;
        }

    }

    public void GetAlreadyExistUser()
    {
        string UserName = Request.Form["UName"];
        PracticesDB practicesDB = new PracticesDB();

        DataTable GetUser = practicesDB.GetAllreadyExistPracticeUser(Profile.PracticeId, UserName);
        if (GetUser.Rows.Count > 0)
        {
            hdnAlreadyExistUser.Value = GetUser.Rows[0]["UserName"].ToString();
        }
    }
   
}