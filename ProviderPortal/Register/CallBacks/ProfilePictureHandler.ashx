<%@ WebHandler Language="C#" Class="ProfilePictureHandler" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

public class ProfilePictureHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
            long PracticeId = objProfileCommon.PracticeId;
            long UserId = objProfileCommon.UserId;
            string savepath = "";
            string tempPath = "";

            tempPath = ConfigurationManager.AppSettings["DocumentsPath"].ToString() + "/" + 1000 + "/" + "Users";
            savepath = context.Server.MapPath(tempPath);
            string[] FileNameArray = postedFile.FileName.Split('.');
            string ext = FileNameArray[FileNameArray.Length - 1].ToString();

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            string ImagePath = Guid.NewGuid().ToString() + "." + ext;

            postedFile.SaveAs(savepath + @"\" + ImagePath);

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
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}