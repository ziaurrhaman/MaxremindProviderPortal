<%@ WebHandler Language="C#" Class="Attachments" %>

using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

public class Attachments : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            string PracticeId = HttpContext.Current.Profile.GetPropertyValue("PracticeId").ToString();
            string directory = HttpContext.Current.Request.Form["Directory"];
            
            Guid newGuid = Guid.NewGuid();
            string savepath = context.Server.MapPath(ConfigurationManager.AppSettings["DocumentsPath"] + "/" + PracticeId + "/" + directory);            

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }
            string TagName = newGuid + "." + postedFile.FileName.Split('.').Last();
            postedFile.SaveAs(savepath + @"\" + TagName);

            UploadFilesDB objUploadFilesDB = new UploadFilesDB();
            PatientDocumentAttachmentsDB objPatientDocAttDB = new PatientDocumentAttachmentsDB();
            
            UploadFiles objUploadFiles = new UploadFiles();
            PatientDocumentAttachments objPatientDocAtt = new PatientDocumentAttachments();
            objUploadFiles.FileName = postedFile.FileName;
            objUploadFiles.TagName = TagName;

          
                
            objUploadFiles.FileLocation = savepath + @"\" + TagName;
            

            switch (postedFile.FileName.Split('.').Last())
            {
                case "Zip":
                    objUploadFiles.FileFormatId = 1;
                    break;
                case "pdf":
                    objUploadFiles.FileFormatId = 2;
                    break;
                case "docx":
                    objUploadFiles.FileFormatId = 3;
                    break;
                case "doc":
                    objUploadFiles.FileFormatId = 3;
                    break;
                case "xlsx":
                    objUploadFiles.FileFormatId = 4;
                    break;
                case "xls":
                    objUploadFiles.FileFormatId = 4;
                    break;
                case "txt":
                    objUploadFiles.FileFormatId = 5;
                    break;
                case "png":
                    objUploadFiles.FileFormatId = 6;
                    break;
                case "jpg":
                    objUploadFiles.FileFormatId = 6;
                    break;
                case "jpeg":
                    objUploadFiles.FileFormatId = 6;
                    break;
                case "bmp":
                    objUploadFiles.FileFormatId = 6;
                    break;
                case "gif":
                    objUploadFiles.FileFormatId = 6;
                    break;
                default:
                    objUploadFiles.FileFormatId = 7;
                    break;
            }
            ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;

            objUploadFiles.FileStatusId = 1;
            objUploadFiles.PracticeId = objProfileCommon.PracticeId;
            objUploadFiles.UploadDate = DateTime.Now;
            objUploadFiles.CreatedById = objProfileCommon.UserId;            
            objUploadFiles.CreatedDate = DateTime.Now;
            objUploadFiles.SubmissionMethodId = 5;
            objUploadFiles.FileTypeId = 7;
       
          
            objUploadFilesDB.Add(objUploadFiles);
            objPatientDocAtt.DocumentId = objUploadFiles.UploadFilesId;
            objPatientDocAtt.OriginalFileName = postedFile.FileName;
            objPatientDocAtt.DocumentPath = "/PracticeDocuments" + "/" + PracticeId + "/" + directory + "/" + TagName;
            objPatientDocAtt.CreatedById = Convert.ToInt64(PracticeId);
            objPatientDocAtt.CreatedDate = DateTime.Now;
      
            objPatientDocAttDB.Add(objPatientDocAtt);
            ResponseFile objResponse = new ResponseFile
                                            {
                                                path = newGuid + "." + TagName.Split('.').Last(),
                                                fileName = postedFile.FileName
                                            };

            var jSon = new JavaScriptSerializer();
            var outPut = jSon.Serialize(objResponse);
            context.Response.Write(outPut);         
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