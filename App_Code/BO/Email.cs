using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.IO;
/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
	public Email()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void SendEmail(string mailTo, string subject, string body)
    {
        MailMessage mail = new MailMessage();

        string[] emailAddresses = mailTo.Split(';');
        for (int i = 0; i < emailAddresses.Length - 1; i++)
        {
            mail.To.Add(emailAddresses[i]);
        }
        mail.From = new MailAddress("aamirkhan@mremind.com", "EMR Practice");
        mail.Subject = subject;

        mail.Body = body;
        mail.IsBodyHtml = true;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtpout.secureserver.net";
        smtpClient.Port = 25;
        smtpClient.Credentials = new System.Net.NetworkCredential("aamirkhan@mremind.com", "aamirkhan");
        smtpClient.Send(mail);
    }

    //public void SendEmail(string emailHtml, IEnumerable<dynamic> attachment, string directory, string subject)
    //{
    //    string host = "relay-hosting.secureserver.net";
    //    int port = 25;
    //    string to = "salman.ali.max@gmail.com";
    //    string from = "emr@emr.com";
    //    string body = emailHtml;
    //    var mail = new MailMessage(from, to, subject, body) { IsBodyHtml = true };

    //    foreach (dynamic attachmentse in attachment ?? Enumerable.Empty<object>())
    //    {
    //        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
    //        long PracticeId = int.Parse(objProfileCommon.GetPropertyValue("PracticeId").ToString());
    //        string filePath = ConfigurationManager.AppSettings["DocumentsPath"] + "/" + PracticeId + "/"
    //                          + directory + "/" + attachmentse.FilePath;
    //        if (File.Exists(HttpContext.Current.Server.MapPath(filePath)))
    //        {
    //            var attachFile = new Attachment(HttpContext.Current.Server.MapPath(filePath));
    //            mail.Attachments.Add(attachFile);
    //        }
    //    }

    //    var client = new SmtpClient { Host = host, Port = port, UseDefaultCredentials = true, EnableSsl = true, Credentials = new System.Net.NetworkCredential("aamirkhan@mremind.com", "aamirkhan") };
    //    client.Send(mail);
    //}   
}