<%@ WebHandler Language="C#" Class="ChangeUserProfileImage" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

public class ChangeUserProfileImage : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {

        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;

        try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            string UserId = context.Request["UserId"].ToString();
            string User = context.Request["User"].ToString();
           // string UserId = "100";
            
            //string AgencyId = context.Request["AgencyId"].ToString();
            string savepath = "";
           string tempPath = "";

            tempPath = ConfigurationManager.AppSettings["DocumentsPath"].ToString() + "/" + UserId + "/" + "Users";
            savepath = context.Server.MapPath(tempPath);
            string[] FileNameArray = postedFile.FileName.Split('.');
            string ext = FileNameArray[FileNameArray.Length - 1].ToString();

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            string ImagePath = Guid.NewGuid().ToString() + "." + ext;

            postedFile.SaveAs(savepath + @"\" + ImagePath);


            UserProfileDB db = new UserProfileDB();
            UserProfile objUserProfile = new UserProfile();
            
           long ModifiedById = Convert.ToInt64(UserId);
            DateTime ModifiedDate = DateTime.Now;
          
            
            db.UpdateProfileImage(Convert.ToInt64(User), ImagePath,ModifiedById,ModifiedDate);

            ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
            objProfileCommon.ProfilePicturePath = ImagePath;
            objProfileCommon.Save();

            ResponseFile objResponse = new ResponseFile();
            objResponse.fileName = ImagePath;
            var jSon = new JavaScriptSerializer();
            var OutPut = jSon.Serialize(objResponse);
            context.Response.Write(OutPut);
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}