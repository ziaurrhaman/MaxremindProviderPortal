using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;

public partial class ProviderPortal_UserProfileHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Section = Request.Form["Section"];
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
        if (Request.Form["objUserProfile"] != null)
        {
            UserProfile objUserProfile = objJavaScriptSerializer.Deserialize<UserProfile>(Request.Form["objUserProfile"]);

            objUserProfile.ModifiedById = Profile.UserId;
            objUserProfile.ModifiedDate = DateTime.Now;

            UserProfileDB objUserProfileDB = new UserProfileDB();

         

            if (Section == "WebAccount")
            {
                long UserId = Profile.UserId;
                string OldPassword = objUserProfile.OldPassword;

                DataTable dtVerifyPassword = objUserProfileDB.VerifyProfilePassword(UserId, OldPassword);

                if (dtVerifyPassword.Rows[0]["ISPASSWORDEXIST"].ToString() == "0")
                {
                  
                    ltrPasswordResponse.Text = "InValid";
                }
                else
                {
               
                    objUserProfileDB.UpdateProfileWebAccount(objUserProfile);
                    ltrPasswordResponse.Text = "Updated";
                }
            }
        }
    }
}