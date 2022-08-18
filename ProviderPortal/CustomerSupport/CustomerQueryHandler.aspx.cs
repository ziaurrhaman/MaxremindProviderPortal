using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_CustomerSupport_CustomerQueryHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = "";
        if (!string.IsNullOrEmpty(Request.Form["Action"]))
        {
            action = Request.Form["Action"].ToString();

            //if (action == "SaveQuery")
            //{
            //    SaveQuery();
            //    Filter();
            //}

            //else if (action == "RefreshTabs")
            //{
            //    RefreshTabs();
            //}
            //else
            if (action == "AllTicket") 
            { 
                TotalTicket(); 
            }
            else if (action == "CloseTicket") { 
                CloseTicket(); 
            }
            else if (action == "OpenTicket") {
                OpenTicket();
            }
            else if (action == "InProcess")
            {
                InProcess();
            }
            else if (action == "ProviderReview")
            {
                ProviderReview();
            }
            


        }


    }
    //protected void SaveQuery()
    //{
    //    var serializer = new JavaScriptSerializer();
    //    CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();

    //    CustomerSupportQuries obj = serializer.Deserialize<CustomerSupportQuries>(Request.Form["objAddQuery"]);

    //    obj.PracticeId = Profile.PracticeId;
    //    obj.CustomerSupportRequesterId = Convert.ToInt32(Profile.UserId);
    //    obj.DepartmentId = 114;
    //    obj.CustomerSupportCommunicationMethodId = 3;
    //    if (Convert.ToInt32(Request.Form["QueryId"]) == 0)
    //    {

    //        obj.RequestDate = DateTime.Now;
    //        obj.CreatedById = Profile.UserId;
    //        obj.CreatedDate = DateTime.Now;
    //        db.Add(obj);

    //    }
    //    else
    //    {
    //        obj.ModifiedById = Profile.UserId;
    //        obj.ModifiedDate = DateTime.Now;

    //        db.Update(obj);
    //    }


    //}

    //protected void Filter()
    //{
    //    string DateFrom = Request.Form["datefrom"].ToString();
    //    string DateTo = Request.Form["dateto"].ToString();
    //    CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
    //    DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", "", "", "", "", "", "", 0, "", "", DateFrom, DateTo);
    //    rpt_MainGrid.DataSource = ds.Tables[0];
    //    rpt_MainGrid.DataBind();
    //}

    protected void rpt_MainGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
        string StatusId = dr["StatusId"].ToString();
        Label statuslbl = (Label)e.Item.FindControl("lblStatusId");
        if (StatusId == "1")
        {
            statuslbl.Text = "Open";
        }
        else if (StatusId == "2")
        {
            statuslbl.Text = "Close";
        }
        else if(StatusId == "6")
        {
            statuslbl.Text = "InProcess";
        }
        else
        {
            statuslbl.Text = "Provider Review";
        }

        Label lblQ = (Label)e.Item.FindControl("lblQuestion");
        string Question = dr["QueryQuestion"].ToString();

        if (Question.Length > 50)
        {
            lblQ.Text = Question.Substring(0, 48) + "...";
        }
        else
        {
            lblQ.Text = Question;

        }

        Label lblA = (Label)e.Item.FindControl("lblAnswer");
        string Answer = dr["QueryAnswer"].ToString();

        if (Answer.Length > 50)
        {
            lblA.Text = Answer.Substring(0, 48) + "...";
        }
        else
        {
            lblA.Text = Answer;

        }
    }

    //protected void RefreshTabs()
    //{
    //    string DateFrom = Request.Form["DateFrom"].ToString();
    //    string DateTo = Request.Form["DateTo"].ToString();
    //    CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
    //    DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", "", "", "", "", "", "", 0, "", "", DateFrom, DateTo);
    //    rpt_SPGrid.DataSource = ds.Tables[0];
    //    rpt_SPGrid.DataBind();

    //    DataSet ds1 = db.CSQTotalCountForTabs(DateFrom, DateTo, DateTime.Now.ToShortDateString(),Profile.PracticeId.ToString());
    //    hdnTotalTicketsCount.Value = ds1.Tables[0].Rows[0][0].ToString();
    //    hdnTotalTicketsClose.Value = ds1.Tables[1].Rows[0][0].ToString();
    //    hdnTotalTicketsOpen.Value = ds1.Tables[2].Rows[0][0].ToString();
    //    hdnTotalTicketsUnderReview.Value = ds1.Tables[4].Rows[0][0].ToString();
        
    //}
    protected void TotalTicket()
    {
        
        string DateFrom = Request.Form["DateFrom"].ToString();
        string DateTo = Request.Form["DateTo"].ToString();
        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "","", "", "", "", "", "", 0, "", "", DateFrom, DateTo);
        rpt_SPGrid.DataSource = ds.Tables[0];
        rpt_SPGrid.DataBind();
        DataSet ds1 = db.CSQTotalCountForTabs(DateFrom, DateTo, Profile.PracticeId.ToString());
        hdnTotalTicketsCount.Value = ds1.Tables[0].Rows[0][0].ToString();
        hdnTotalTicketsClose.Value = ds1.Tables[1].Rows[0][0].ToString();
        hdnTotalTicketsOpen.Value = ds1.Tables[2].Rows[0][0].ToString();
        hdnTotalTicketsInProcess.Value = ds1.Tables[3].Rows[0][0].ToString();
        hdnTotalTicketsProviderReview.Value = ds1.Tables[4].Rows[0][0].ToString();


    }

    protected void CloseTicket()
    {
        //string DateFrom = Request.Form["DateFrom"].ToString();
        //string DateTo = Request.Form["DateTo"].ToString();
        string TicketType = Request.Form["TicketType"].ToString();


        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", TicketType, "", "", "", "", "", 0, "", "", "", "");
        rpt_SPGrid.DataSource = ds.Tables[0];
        rpt_SPGrid.DataBind();

         DataSet ds1 = db.CSQTotalCountForTabs("", "", Profile.PracticeId.ToString());
        hdnTotalTicketsCount.Value = ds1.Tables[0].Rows[0][0].ToString();
        hdnTotalTicketsClose.Value = ds1.Tables[1].Rows[0][0].ToString();
        hdnTotalTicketsOpen.Value = ds1.Tables[2].Rows[0][0].ToString();
        hdnTotalTicketsInProcess.Value = ds1.Tables[3].Rows[0][0].ToString();
        hdnTotalTicketsProviderReview.Value = ds1.Tables[4].Rows[0][0].ToString();


    }
    protected void OpenTicket()
    {
        string DateFrom = Request.Form["DateFrom"].ToString();
        string DateTo = Request.Form["DateTo"].ToString();
        string TicketType = Request.Form["TicketType"].ToString();


        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", TicketType, "", "", "", "", "", 0, "", "", DateFrom, DateTo);
        rpt_SPGrid.DataSource = ds.Tables[0];
        rpt_SPGrid.DataBind();

        DataSet ds1 = db.CSQTotalCountForTabs(DateFrom, DateTo, Profile.PracticeId.ToString());
        hdnTotalTicketsCount.Value = ds1.Tables[0].Rows[0][0].ToString();
        hdnTotalTicketsClose.Value = ds1.Tables[1].Rows[0][0].ToString();
        hdnTotalTicketsOpen.Value = ds1.Tables[2].Rows[0][0].ToString();
        hdnTotalTicketsInProcess.Value = ds1.Tables[3].Rows[0][0].ToString();
        hdnTotalTicketsProviderReview.Value = ds1.Tables[4].Rows[0][0].ToString();



    }
    protected void InProcess()
    {
        string DateFrom = Request.Form["DateFrom"].ToString();
        string DateTo = Request.Form["DateTo"].ToString();
        string TicketType = Request.Form["TicketType"].ToString();


        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", TicketType, "", "", "", "", "", 0, "", "", DateFrom, DateTo);
        rpt_SPGrid.DataSource = ds.Tables[0];
        rpt_SPGrid.DataBind();

        DataSet ds1 = db.CSQTotalCountForTabs(DateFrom, DateTo, Profile.PracticeId.ToString());
        hdnTotalTicketsCount.Value = ds1.Tables[0].Rows[0][0].ToString();
        hdnTotalTicketsClose.Value = ds1.Tables[1].Rows[0][0].ToString();
        hdnTotalTicketsOpen.Value = ds1.Tables[2].Rows[0][0].ToString();
        hdnTotalTicketsInProcess.Value = ds1.Tables[3].Rows[0][0].ToString();
        hdnTotalTicketsProviderReview.Value = ds1.Tables[4].Rows[0][0].ToString();



    }
    protected void ProviderReview()
    {
        string DateFrom = Request.Form["DateFrom"].ToString();
        string DateTo = Request.Form["DateTo"].ToString();
        string TicketType = Request.Form["TicketType"].ToString();


        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", TicketType, "", "", "", "", "", 0, "", "", DateFrom, DateTo);
        rpt_SPGrid.DataSource = ds.Tables[0];
        rpt_SPGrid.DataBind();

        DataSet ds1 = db.CSQTotalCountForTabs(DateFrom, DateTo, Profile.PracticeId.ToString());
        hdnTotalTicketsCount.Value = ds1.Tables[0].Rows[0][0].ToString();
        hdnTotalTicketsClose.Value = ds1.Tables[1].Rows[0][0].ToString();
        hdnTotalTicketsOpen.Value = ds1.Tables[2].Rows[0][0].ToString();
        hdnTotalTicketsInProcess.Value = ds1.Tables[3].Rows[0][0].ToString();
        hdnTotalTicketsProviderReview.Value = ds1.Tables[4].Rows[0][0].ToString();



    }


    protected void rpt_SPGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
        string StatusId = dr["StatusId"].ToString();
        Label statuslbl =  (Label)e.Item.FindControl("lblStatusId");
        if (StatusId == "1")
        {
            statuslbl.Text = "Open";
        }
        else if (StatusId == "2")
        {
            statuslbl.Text = "Close";
        }
        else if(StatusId =="6")
        {
            statuslbl.Text = "InProcess";
        }
        else if(StatusId == "8")
        {
            statuslbl.Text = "Provider Review";
        }
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

        //Label lblA = (Label)e.Item.FindControl("lblAnswer");
        //string Answer = dr["QueryAnswer"].ToString();

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