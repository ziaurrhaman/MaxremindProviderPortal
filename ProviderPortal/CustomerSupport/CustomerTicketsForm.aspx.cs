using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_CustomerSupport_CustomerTicketsForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Dropdowns();

        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.GetAllFilter(1000000, 0, "CustomerSupportQuryId DESC", Profile.PracticeId.ToString(), "", "", "", "", "", "", "", "", "", "", "", 0, "", "", "", "");
        rpt_MainGrid.DataSource = ds.Tables[0];
        rpt_MainGrid.DataBind();

    }

    protected void Dropdowns()
    {
        CustomerSupportQuriesDB db = new CustomerSupportQuriesDB();
        DataSet ds = db.CSDropdowns(Profile.UserId);
        txtCustomerSupportModuleTypeId.DataSource = ds.Tables[1];
        txtCustomerSupportModuleTypeId.DataTextField = "name";
        txtCustomerSupportModuleTypeId.DataValueField = "CustomerSupportModuleTypeId";
        txtCustomerSupportModuleTypeId.DataBind();
        txtCustomerSupportModuleTypeId.Items.Insert(0, new ListItem("", "0"));

    }

    protected void rpt_MainGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView dr = (DataRowView)e.Item.DataItem;
        string StatusId = dr["StatusId"].ToString();
        Label statuslbl = (Label)e.Item.FindControl("lblStatusId");
        if (StatusId == "0")
        {
            statuslbl.Text = "Open";
        }
        else if (StatusId == "1")
        {
            statuslbl.Text = "Close";
        }
        else
        {
            statuslbl.Text = "Under Review";
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
}