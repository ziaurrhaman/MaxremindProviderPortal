<%@ WebHandler Language="C#" Class="PatientDocumentHandler" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Configuration;

using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;

public class PatientDocumentHandler : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";

        try
        {
            HttpPostedFile postedFile = context.Request.Files[0];
            string PatientId = context.Request["PatientId"].ToString();
            string PracticeId = context.Profile.GetPropertyValue("PracticeId").ToString();
            string Action = context.Request["Action"].ToString();
            long UploadFileId = 0;
            string newFileName = Guid.NewGuid().ToString();

            string tempPath = ConfigurationManager.AppSettings["PracticePath"].ToString() + "/" + PracticeId + "/" + "Patients" +"/Documents";
            string savepath = context.Server.MapPath(tempPath);

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            string filename = postedFile.FileName;
            string fileformate = filename.Split('.').Last().ToUpper();
            int FileFormateId = 0;

            if (fileformate == "PDF")
                FileFormateId=2;
            if (fileformate == "TXT")
                FileFormateId=5;
            if (fileformate == "ZIP")
                FileFormateId=1;
            if (fileformate == "JPG")
                FileFormateId=6;
            if (fileformate == "PEG")
                FileFormateId=6;
            if (fileformate == "PNG")
                FileFormateId=6;
            if (fileformate == "GIF")
                FileFormateId=6;
            if (fileformate == "OCX")
                FileFormateId=3;
            if (fileformate == "LSX")
                FileFormateId=4;
            if (fileformate == "CSV")
                FileFormateId=8;
            if (fileformate == "XLS")
                FileFormateId=4;

            postedFile.SaveAs(savepath + @"\" + filename);


            string CurrentDate =  DateTime.Now.ToString();
            //Added by Khayyam adeel desc: Upload File add 
            if (Action == "UploadFiles_Add")
            {
                UploadFiles obj = new UploadFiles();
                UploadFilesDB objDB = new UploadFilesDB();
                obj.PracticeId = long.Parse(PracticeId);
                obj.SubmissionMethodId = 5;
                // obj.UploadDate = CurrentDate;
                obj.FileName = postedFile.FileName;
                obj.FileLocation = PracticeId + "/" + "Patients" + "/Documents/" + filename; /*.Split('.')[0] + "." + filename.Split('.').Last();*/
                obj.FileFormatId = FileFormateId;
                UploadFileId=objDB.Add(obj);

            }

            //Added on 1/11/2021 desc : Add file in FileDocumnetAttachment so that i can visible on EMR Post Payment EOB
            FileDocumentAttachments fileDocumentAttachments = new FileDocumentAttachments();
                    fileDocumentAttachments.OriginalFileName = filename;
                    fileDocumentAttachments.DocumentId = Convert.ToInt32(UploadFileId);
                    FileDocumentAttachmentsDB fileDocumentAttachmentsDB = new FileDocumentAttachmentsDB();
                    fileDocumentAttachments.DocumentPath = PracticeId + "/" + "Patients" + "/Documents/" + filename;;
                    //fileDocumentAttachments.FileDocumentAttachmentsId = upload.UploadFilesId;
                    fileDocumentAttachments.CreatedById = Convert.ToInt32(context.Profile.GetPropertyValue("UserId").ToString());
                    fileDocumentAttachments.CreatedDate = Convert.ToDateTime(DateTime.Now );
                    var output = fileDocumentAttachmentsDB.Add(fileDocumentAttachments);
            ResponseFile objResponse = new ResponseFile();
            objResponse.fileName = newFileName + "." + filename.Split('.').Last();
            objResponse.path = PracticeId + "/" + "Patients" + "/Documents/" + filename; /*+ "." + filename.Split('.').Last();*/
            objResponse.FileId = UploadFileId;
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