using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;

public partial class EMR_Messages_CallBacks_CustomerSupportHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        PatientContactMessagesDB objPatientContactMessagesDB = new PatientContactMessagesDB();
        if (action == "Reply")
        {
            JavaScriptSerializer seriailzer = new JavaScriptSerializer();
            PatientContactMessages objPatientContactMessages = seriailzer.Deserialize<PatientContactMessages>(Request.Form["objPatientMessage"]);
            objPatientContactMessages.PracticeId = Convert.ToInt32(Profile.PracticeId);
            objPatientContactMessages.IsRead = false;
            objPatientContactMessages.ModifiedDate = DateTime.Now;
            objPatientContactMessages.ModifiedById = 0;
            objPatientContactMessagesDB.Update(objPatientContactMessages);
            DataSet dsPatientContact = objPatientContactMessagesDB.GetAllFilter("", "", 0, "", Profile.PracticeId, 10, 0, "");
            rptPatientMessages.DataSource = dsPatientContact.Tables[0];
            rptPatientMessages.DataBind();
            hdnPatientMessageTotalRows.Value = dsPatientContact.Tables[1].Rows[0]["TotalRows"].ToString();

        }
        else if (action == "Filter")
        {
            string Subject = Request.Form["Subject"];
            string Priority = Request.Form["Priority"];
            int Rows = int.Parse(Request.Form["Rows"]);
            int PageNumber = int.Parse(Request.Form["PageNumber"]);
            DataSet dsPatientContact = objPatientContactMessagesDB.GetAllFilter(Profile.LastName + " " + Profile.FirstName, Subject, Profile.PatientId, Priority, Profile.PracticeId, Rows, PageNumber, "");
            rptPatientMessages.DataSource = dsPatientContact.Tables[0];
            rptPatientMessages.DataBind();
            hdnPatientMessageTotalRows.Value = dsPatientContact.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else if (action == "Delete")
        {
            long contactMessageId = long.Parse(Request.Form["contactMessageId"]);
            objPatientContactMessagesDB.Delete(contactMessageId);

            DataSet dsPatientContact = objPatientContactMessagesDB.GetAllFilter(Profile.LastName + " " + Profile.FirstName, "", Profile.PatientId, "", Profile.PracticeId, 10, 0, "");
            rptPatientMessages.DataSource = dsPatientContact.Tables[0];
            rptPatientMessages.DataBind();
            hdnPatientMessageTotalRows.Value = dsPatientContact.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else if (action == "Read")
        {
            long contactMessageId = long.Parse(Request.Form["contactMessageId"]);
            objPatientContactMessagesDB.MessageRead(contactMessageId);

            DataSet dsPatientContact = objPatientContactMessagesDB.GetAllFilter(Profile.LastName + " " + Profile.FirstName, "", Profile.PatientId, "", Profile.PracticeId, 10, 0, "");
            rptPatientMessages.DataSource = dsPatientContact.Tables[0];
            rptPatientMessages.DataBind();
            hdnPatientMessageTotalRows.Value = dsPatientContact.Tables[1].Rows[0]["TotalRows"].ToString();
        }
    }
}