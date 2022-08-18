using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Text;
public partial class ProviderPortal_Register_CallBacks_UserRegisterationHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        if (!string.IsNullOrEmpty(action))
        {
            if (action == "add") { UserRegisterationAdd(); }
            else if (action == "update") { UserRegistrationUpdate(); }
            else if (action == "delete") { }
            else if (action == "getById") { }
            else if (action == "gird") { }
            //else if (action == "UserNameExist") { ValidateUserName(); }
            else if (action == "ChkValidNPI") { validateNPI(); }
            //else if (action == "SendEmail") { sendEmail(); }
            else if (action == "UpdatePassword") { UpdatePassword(); }
        }
    }


    public void UserRegisterationAdd()
    {
        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();

        UserRegistration userRegistration = new UserRegistration();
        userRegistration = objJavaScriptSerializer.Deserialize<UserRegistration>(Request.Form["UserRegistration"]);
        DataTable user = new UserRegistrationDB().GetByID(new UserRegistration() { UserRegistrationId = -1, UserName = userRegistration.UserName });
        if (user.Rows.Count > 0)
            AlredyExistUsername.Text = "true";
        else
        {
            AlredyExistUsername.Text = "false";
        }
        if (AlredyExistUsername.Text == "false")
        {

            sendEmail(userRegistration);
            if (EmailVerification.Text == "True")
            {
                UserRegistrationDB userRegistrationDB = new UserRegistrationDB();
                userRegistrationDB.Add(userRegistration);
            }
            else
            {
                AddProfile.Text = "False";
            }
        }
    }
    public void UserRegistrationUpdate()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        UserRegistration user = new UserRegistration();
        user = serializer.Deserialize<UserRegistration>(Request.Form["UpdatedData"]);
        UserRegistrationDB db = new UserRegistrationDB();
        db.Update(user);
        Profile.SpecificUserName = user.LastName + ", " + user.FirstName;
    }

    public void getById(UserRegistration userregistration)
    {
        UserRegistrationDB userRegistrationDB = new UserRegistrationDB();
        DataTable dt = userRegistrationDB.GetByID(userregistration);
        UserRegistration userRegistration = new UserRegistration();
        userRegistration.UserRegistrationId = Convert.ToInt64(dt.Rows[0][""]);

    }
    public void ValidateUserName()
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        var username = serializer.Deserialize<string>(Request.Form["UserName"]);
        DataTable user = new UserRegistrationDB().GetByID(new UserRegistration() { UserRegistrationId = -1, UserName = username });
        if (user.Rows.Count > 0)
            AlredyExistUsername.Text = "true";
        else
        {
            AlredyExistUsername.Text = "false";
        }
    }

    public void validateNPI()
    {
        string NPI = Request.Form["NPI"];
        string url = "https://npiregistry.cms.hhs.gov/api/?number=" + NPI + "&version=2.1";

        using (var client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            string s = client.DownloadString(url);
            s = s.Substring(1, 16);
            s = s.Substring(s.Length - 1);
            bool result = false;
            if (s == "1") { result = true; }
            DataTable user = new UserRegistrationDB().GetByID(new UserRegistration() { UserRegistrationId = -2, ProviderNPI = NPI });
            if (user.Rows.Count > 0)
            {
                lNPI.Text = "Exist";
            }
            else
            {
                lNPI.Text = result + "";
            }
        }
    }
    public void sendEmail(UserRegistration objUserRegistration)
    {
        string email = objUserRegistration.Email;
        string password = objUserRegistration.Password;
        string ReturnUrl = Request.Form["ReturnUrl"];
        EmailVerification.Text = "False";

        string username = email.Substring(0, email.IndexOf('@'));
        StringBuilder Emailbody = new StringBuilder();
        Emailbody.Append("<h3> Welcom to Maxremind Provider Portal.</h3>");
        Emailbody.Append("<b>User Name : " + username + "<br/>");
        Emailbody.Append("<b>Password : " + password + "<br/>");
        Emailbody.Append("<b>Login : <a target='_blank' href='" + ReturnUrl + "'>" + ReturnUrl + "</a><br/>");


        MailMessage mail = new MailMessage();
        
        mail.To.Add(email);
        //mail.To.Add("sales@mremind.com , aslam@mremind.com");
        mail.From = new MailAddress(@"MaxRemindHealthSystem@mremind.com");
        mail.Subject = "ProviderPortal";
        mail.Body = Emailbody.ToString();
        mail.IsBodyHtml = true;
        SmtpClient smtpClient = new SmtpClient();
        smtpClient.Host = "smtpout.secureserver.net";
        smtpClient.Port = 3535;
        smtpClient.EnableSsl = false;
        smtpClient.Credentials = new System.Net.NetworkCredential("MaxRemindHealthSystem@mremind.com", "MaxRemindHealth");
        smtpClient.Send(mail);
        EmailVerification.Text = "True";
    }

    public void UpdatePassword()
    {
        UserRegistrationDB db = new UserRegistrationDB();
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        UserRegistration user = new UserRegistration();
        user = serializer.Deserialize<UserRegistration>(Request.Form["UpdatePasswordData"]);
        PasswordUpdateStatus.Text = "False";
        string OldPassword = Request.Form["OldPassword"];
        DataTable table = db.GetByID(new UserRegistration() { UserRegistrationId = user.UserRegistrationId, UserName = null, Password = null, ProviderNPI = null });
        bool old_password = OldPassword == table.Rows[0]["Password"].ToString() || false;
        if (old_password)
        {
            PasswordUpdateStatus.Text = "True";
            db.UpdateUserPassword(user);
            StringBuilder Emailbody = new StringBuilder();
            Emailbody.Append("<b>Your New Password is: " + user.Password + "<br/>");
            string email = table.Rows[0]["Email"].ToString();
            MailMessage mail = new MailMessage();
            mail.To.Add(email);
            //mail.To.Add("sales@mremind.com , aslam@mremind.com");
            mail.From = new MailAddress(@"MaxRemindHealthSystem@mremind.com");
            mail.Subject = "ProviderPortal";
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
            PasswordUpdateStatus.Text = "False";
        }
    }
}