using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_CustomerSupport_Support : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnuserid.Value = Profile.UserId.ToString();
        hdnusername.Value = Profile.UserName;
        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();

        DataSet ds = db.GetAllFilter(10, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "");
        rpt_MainGrid.DataSource = ds.Tables[0];
        rpt_MainGrid.DataBind();
        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        Dropdowns();


        DataSet ds1 = db.CSQTotalCountForTabs("", "", Profile.PracticeId.ToString(), DateTime.Now);
        TotalTicketsCount.Text = ds1.Tables[0].Rows[0][0].ToString();
        TotalTicketsClose.Text = ds1.Tables[1].Rows[0][0].ToString();
        TotalTicketsOpen.Text = ds1.Tables[2].Rows[0][0].ToString();
        TotalTicketsInProcess.Text = ds1.Tables[3].Rows[0][0].ToString();
        TotalTicketsProviderreview.Text = ds1.Tables[4].Rows[0][0].ToString();

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

    protected void Dropdowns()
    {
        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.CSDropdowns();
        ddlstatussearch.DataSource = ds.Tables[0];
        ddlstatussearch.DataTextField = "StatusName";
        ddlstatussearch.DataValueField = "StatusId";
        ddlstatussearch.DataBind();
        ddlstatussearch.Items.Insert(0, new ListItem("", ""));
    }


}