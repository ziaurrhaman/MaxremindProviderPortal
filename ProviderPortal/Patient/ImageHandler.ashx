<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

public class ImageHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        
        try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            
            string PracticeId = HttpContext.Current.Profile.GetPropertyValue("PracticeId").ToString();
            long PatientId = long.Parse(context.Request["PatientId"].ToString());
            
            string tempPath = ConfigurationManager.AppSettings["PatientPhoto"].ToString() + "/" + PracticeId + "/" + "Patients" + "/" + PatientId;
            string  savepath = context.Server.MapPath(tempPath);
            string[] FileNameArray = postedFile.FileName.Split('.');
            string ext = FileNameArray[1].ToString();
            
            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
            
            postedFile.SaveAs(savepath + @"\" + PatientId + "." + ext);
            
            string File = PatientId + "." + ext;
            string ImagePath =  File;
            
            PatientDB objPatientDB = new PatientDB();
            objPatientDB.UpdateImagePath(PatientId, ImagePath);
            
            ResponseFile objResponse = new ResponseFile();
            objResponse.fileName = File;
            
            JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
            var response = objJavaScriptSerializer.Serialize(objResponse);
            
            context.Response.Write(response);
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