<%@ WebHandler Language="C#" Class="AttachmentUploadHandler" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

public class AttachmentUploadHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
               string PracticeId = HttpContext.Current.Profile.GetPropertyValue("PracticeId").ToString();
                HttpPostedFile postedFile = context.Request.Files[0];
            
                string savepath = "";
                string tempPath = "";
                Guid newGuid = Guid.NewGuid();
               // tempPath = System.Configuration.ConfigurationManager.AppSettings["PracticePath"].ToString() + "/" + "MessageAttachments/" + PracticeId + "/" + "Tickets"+newGuid; 
               tempPath = System.Configuration.ConfigurationManager.AppSettings["DocumentsPath"].ToString() + "/TicketingDocuments";
                savepath = context.Server.MapPath(tempPath);
                
                if (!Directory.Exists(savepath))
                {
                    Directory.CreateDirectory(savepath);
                }
                
                string filename = postedFile.FileName;
                postedFile.SaveAs(savepath + @"\" + newGuid.ToString() + "." + filename.Split('.').Last());
                
                ResponseFile objResponse = new ResponseFile();
                objResponse.path = newGuid.ToString() + "." + filename.Split('.').Last();
            
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