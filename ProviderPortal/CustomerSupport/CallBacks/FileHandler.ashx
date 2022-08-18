<%@ WebHandler Language="C#" Class="FileHandler" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Dynamic;
    using System.Configuration;

public class FileHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            string PracticeId = context.Profile.GetPropertyValue("PracticeId").ToString();
           string newFileName = Guid.NewGuid().ToString();

            string tempPath = ConfigurationManager.AppSettings["PracticePath"].ToString() + "/" + PracticeId + "/" + "UploadEmailFiles";
            string savepath = context.Server.MapPath(tempPath);

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            ResponseFile objResponse = new ResponseFile();
            objResponse.fileName = newFileName + "." + postedFile.FileName.Split('.').Last();
            objResponse.path = PracticeId + "/" + "UploadEmailFiles" + "/" + newFileName + "." + postedFile.FileName.Split('.').Last();
            
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
    public string GetUniqueId()
    {
        StringBuilder sb = new StringBuilder();
        Random rand = new Random(DateTime.Now.Millisecond);
        for (int i = 0; i < 16; i++)
        {
            sb.Append(rand.Next(9));
        }
        return sb.ToString();
    }

}