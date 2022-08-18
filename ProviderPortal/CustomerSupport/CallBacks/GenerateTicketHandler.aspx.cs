using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Data;
public partial class ProviderPortal_CustomerSupport_CallBacks_GenerateTicketHandler : System.Web.UI.Page
{

    CustomerSupportQuries CST1 = new CustomerSupportQuries();
    JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
    CustomerSupportQuriesDB CSTDB = new CustomerSupportQuriesDB();
    //CustomerSupportAttachments CSA = new CustomerSupportAttachments();
   // CustomerSupportAttachmentsDB CSADB = new CustomerSupportAttachmentsDB();

    long CSTicketId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        string action = Request.Form["action"].ToString();
        if (action == "SaveTicketsData")
        {

            var TicketId = Request.Form["TicketId"].ToString();
            var TicketData = Request.Form["TicketData"].ToString();
            var filename = Request.Form["Filename"].ToString();
            var filepath = Request.Form["Filepath"].ToString();
            //string AttachmentData = Request.Form["attachmentList"].ToString();
            CST1 = objJavaScriptSerializer.Deserialize<CustomerSupportQuries>(TicketData);
            //List<CustomerSupportAttachments> attachmentList = objJavaScriptSerializer.Deserialize<List<CustomerSupportAttachments>>(AttachmentData);
            if (TicketId == "0")
            {
                
                CST1.CustomerSupportQuryId = Convert.ToInt32(TicketId);
                CST1.PracticeId = Profile.PracticeId;
                CST1.CreatedById = Profile.UserId;
                CST1.CreatedDate = DateTime.Today;
                CSTicketId = CSTDB.Add(CST1);
                if (!string.IsNullOrEmpty(filename) && !string.IsNullOrEmpty(filepath))
                {
                    long someid = CSTDB.FileAttachmentAdd(CSTicketId, filepath, filename, Profile.UserId, Profile.PracticeId);
                }
                

                //foreach (CustomerSupportAttachments objAttachDocuments in attachmentList)
                //{
                //    objAttachDocuments.PracticeId = Profile.PracticeId;
                //    objAttachDocuments.CreatedById = Profile.UserId;
                //    objAttachDocuments.CreatedDate = DateTime.Today;
                //    objAttachDocuments.CSTicketsId = CSTicketId;
                //    // CSADB.Add(objAttachDocuments);
                //}

            }
            else
            {
                CST1.CustomerSupportQuryId = Convert.ToInt32(TicketId);
                CST1.PracticeId = Profile.PracticeId;
                CST1.ModifiedById = Profile.UserId;
                CST1.ModifiedDate = DateTime.Today;
                CSTDB.Update(CST1);


                //foreach (CustomerSupportAttachments objAttachDocuments in attachmentList)
                //{
                //    objAttachDocuments.CSTicketsId = Convert.ToInt32(TicketId);
                //    objAttachDocuments.PracticeId = Profile.PracticeId;


                //    if (objAttachDocuments.CSAttachmentsId == 0)
                //    {
                //        objAttachDocuments.CreatedById = Profile.UserId;
                //        objAttachDocuments.CreatedDate = DateTime.Today;
                //        // CSADB.Add(objAttachDocuments);
                //    }


                //}
            }
        }
        if (action == "SaveFeedback") {
            SubmitFeedBack();
        }
        if (action == "DeleteTicketFromDB")
        {
            DeleteTicket();
        }
        if (action == "Filter")
        {

            int Ticketno = Convert.ToInt32(Request.Form["TicketNo"].ToString());
            string subject = (Request.Form["Subject"].ToString());
            string description = (Request.Form["Description"].ToString());
            string TkDate = (Request.Form["Tkdate"].ToString());
            string Status = (Request.Form["StatusId"].ToString());
            string Response = (Request.Form["Response"].ToString());

            int Rows = Convert.ToInt32(Request.Form["Rows"].ToString());
            int PageNo = Convert.ToInt32(Request.Form["PageNumber"].ToString());



            DataSet ds2 = CSTDB.GetAllFilter(Rows, PageNo, "CustomerSupportQuryId ASC", Profile.PracticeId.ToString(),subject, "", TkDate, "", "", Status, "", "", description, "", "", Ticketno, "", "", "", "");
            rpt_MainGrid.DataSource = ds2.Tables[0];
            rpt_MainGrid.DataBind();
            hdnrows.Value = ds2.Tables[1].Rows[0]["TotalRows"].ToString();
        }
    }

        

//        else if (action == "viewAttchFiles")
//        {
          
//            int TicketId = Convert.ToInt32(Request.Form["TicketId"].ToString());
//rptAttachment.DataSource = CSADB.GetAllFilter(20, 0, null, TicketId);
//            rptAttachment.DataBind();
//        }
//        else if (action == "SearchPatient")
//        {
//            LoadPatient();
//        }
//        else if (action == "DeleteAttachmentFromDB")
//        {
//            DeleteAttachment();
//        }
      
     
//   }
//    public void LoadPatient()
//{
//    PatientDB patientDB = new PatientDB();
//    long PracticeId = Profile.PracticeId;
//    string PatientValue = Request.Form["SearchValue"].ToString();
//    DataTable dtPatient = patientDB.GetByPatientName(PatientValue, PracticeId);

//    rptPatient.DataSource = dtPatient;

//    rptPatient.DataBind();
//}

//public void DeleteAttachment()
//{

//    CSA.ModifiedById = Profile.UserId;
//    CSA.ModifiedDate = DateTime.Today;
//    CSA.CSAttachmentsId = Convert.ToInt32(Request.Form["TicketAttachmentId"].ToString());
//    CSADB.Delete(CSA);

//}
public void DeleteTicket()
    {
        
        CST1.ModifiedById = Profile.UserId;
        CST1.ModifiedDate = DateTime.Today;
        CST1.CustomerSupportQuryId = Convert.ToInt32(Request.Form["TicketId"].ToString());
        CSTDB.Delete(CST1);
    }

    public void SubmitFeedBack() {
        var Id = Convert.ToInt32(Request.Form["Id"]);
        var CustomerFeedBack = Request.Form["CustomerFeedBack"].ToString();
        var Rating = Convert.ToInt32(Request.Form["Rating"]);
        var ModifiedById = Profile.UserId;
        DateTime ModifiedByDate = DateTime.Now;
        CSTDB.CSQFeedBackByProvider(Id,CustomerFeedBack,Rating,ModifiedByDate,ModifiedById);



    }
    protected void rpt_MainGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
        //string StatusId = dr["StatusId"].ToString();
        //Label statuslbl = (Label)e.Item.FindControl("lblStatusId");
        //if (StatusId == "0")
        //{
        //    statuslbl.Text = "Open";
        //}
        //else if (StatusId == "1")
        //{
        //    statuslbl.Text = "Close";
        //}
        //else
        //{
        //    statuslbl.Text = "Under Review";
        //}

        Label lblQ = (Label)e.Item.FindControl("Descriptions");
        string Question = dr["Descriptions"].ToString();

        if (Question.Length > 20)
        {
            lblQ.Text = Question.Substring(0, 20) + "...";
        }
        else
        {
            lblQ.Text = Question;

        }

        Label lblA = (Label)e.Item.FindControl("lblAnswer");
        string Answer = dr["Response"].ToString();

        //if (Answer.Length > 50)
        //{
        //    lblA.Text = Answer.Substring(0, 48) + "...";
        //}
        //else
        //{
        //    lblA.Text = Answer;

        //}
    }

}