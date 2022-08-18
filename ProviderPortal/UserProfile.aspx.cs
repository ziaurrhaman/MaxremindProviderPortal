using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Web.Script.Serialization;

public partial class ProviderPortal_UserProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /**********Profile Dropdown Main**********/
        string userName = Profile.LastName + " " + Profile.FirstName;
        lblProfileLastName.Text = Profile.LastName;
        lblProfileFirstName.Text = Profile.FirstName;
        hdnUserIdMaster.Value = Profile.PracticeId.ToString();
        hdnUser.Value = Profile.UserId.ToString();
        
      

        //imgProfileImageOnWelcome.ImageUrl = "~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/Staff/" + Profile.ProfilePicturePath;

        string ProfileImagePath = "~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/Users/" + Profile.ProfilePicturePath;

        string ProfileImagePhysicalPath = Server.MapPath("~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/Users/" + Profile.ProfilePicturePath);

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

        imgUserProfile.ImageUrl = ProfileImagePath;
        lblProfilePhoneNumber.Text = Profile.PhoneNumber;
        lblProfileEmailAddress.Text = Profile.EmailAddress;


        string Section = Request.Form["Section"];
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();

        if (Request.Form["objUserProfile"] != null)
        {
            UserProfile objUserProfile = objJavaScriptSerializer.Deserialize<UserProfile>(Request.Form["objUserProfile"]);

            objUserProfile.ModifiedById = Profile.UserId;
            objUserProfile.ModifiedDate = DateTime.Now;
            objUserProfile.UserId = Profile.UserId;

            UserProfileDB objUserProfileDB = new UserProfileDB();

            if (Section == "Personal")
            {
                objUserProfileDB.UpdateProfilePersonalInformation(objUserProfile);
                Profile.FirstName = objUserProfile.FirstName;
                Profile.LastName = objUserProfile.LastName;
                //  UpdateUserProfilePersonalInformation(objUserProfile);
            }
            if (Section == "Contact")
            {
               
                objUserProfileDB.UpdateProfileContactInformation(objUserProfile);
                Profile.EmailAddress = objUserProfile.EmailAddress;
                Profile.PhoneNumber = objUserProfile.PhoneNumber;
                //  UpdateUserProfilePersonalInformation(objUserProfile);
            }

            
        }
            
        }
      


    }
    //private void UpdateUserProfilePersonalInformation(UserProfile objUserProfile)
    //{
    //    Profile.LastName = objUserProfile.LastName;
    //    Profile.FirstName = objUserProfile.FirstName;
    //    Profile.Save();
    //}

  