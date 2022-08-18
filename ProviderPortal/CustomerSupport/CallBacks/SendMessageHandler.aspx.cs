using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_CustomerSupport_CallBacks_SendMessageHandler : System.Web.UI.Page
{
    JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
    protected void Page_Load(object sender, EventArgs e)
    {
        Post();
    }
    private void Post()
    {
        if (IsReCaptchValid())
        {
            string objSendMessage = Request.Form["objSendMessage"].ToString();
            ContactUs con = objJavaScriptSerializer.Deserialize<ContactUs>(objSendMessage);
            StringBuilder Emailbody = new StringBuilder();
            Emailbody.Append("<b>Client_Name : " + con.tbname + "<br/>");
            Emailbody.Append("<b>Email : " + con.tbemail + "<br/>");
            Emailbody.Append("<b>Phone_No : " + con.tbphone + "<br/>");
            Emailbody.Append("<b>Message :  " + con.tbMesage);
            MailMessage mail = new MailMessage();
            //mail.To.Add("sales@mremind.com , aslam@mremind.com");
            mail.To.Add("sajidbalti707@gmail.com , sajidbalti707@gmail.com");
            if (string.IsNullOrEmpty(con.tbsubject))
            {
                con.tbsubject = "Email Us";
            }
            mail.From = new MailAddress("MaxRemindHealthSystem@mremind.com");
            mail.Subject = con.tbsubject;
            //  mail.Subject = "test";
            mail.Body = Emailbody.ToString();
            mail.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtpout.secureserver.net";
            smtpClient.Port = 3535;
            smtpClient.EnableSsl = false;
            smtpClient.Credentials = new System.Net.NetworkCredential("MaxRemindHealthSystem@mremind.com", "MaxRemindHealth");
            smtpClient.Send(mail);

        }
        else
        {
            ltrerrorMessage.Text = "Almost done! please verify that you are human";
            //return View();

        }
    }

    public bool IsReCaptchValid()
    {
        var result = false;
        var captchaResponse = Request.Form["grecaptcharesponse"];
        var secretKey = ConfigurationManager.AppSettings["SecretKey"];
        var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
        var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
        var request = (HttpWebRequest)WebRequest.Create(requestUri);

        using (WebResponse response = request.GetResponse())
        {
            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                JObject jResponse = JObject.Parse(stream.ReadToEnd());
                var isSuccess = jResponse.Value<bool>("success");
                result = (isSuccess) ? true : false;
            }
        }
        return result;
    }
}