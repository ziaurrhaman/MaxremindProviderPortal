<%@ WebHandler Language="C#" Class="FileAttachments" %>

using System;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.Script.Serialization;
using System.Linq;

public class FileAttachments : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
      try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            //string PatientId = context.Request["ClaimAppealId"].ToString();
            string PracticeId = context.Profile.GetPropertyValue("PracticeId").ToString();
            
            string newFileName = Guid.NewGuid().ToString();

            string tempPath = ConfigurationManager.AppSettings["PracticePath"].ToString() + "/" + PracticeId + "/" + "UploadEmailFiles";
            string savepath = context.Server.MapPath(tempPath);

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
            
            string filename = postedFile.FileName;
            postedFile.SaveAs(savepath + @"\" + newFileName + "." + filename.Split('.').Last());
            
            ResponseFile objResponse = new ResponseFile();
            objResponse.fileName = newFileName + "." + filename.Split('.').Last();
            objResponse.path = PracticeId + "/" + "UploadEmailFiles" + "/" + newFileName + "." + filename.Split('.').Last();
            
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