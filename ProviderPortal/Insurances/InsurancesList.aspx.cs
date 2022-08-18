using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Insurances_InsurancesList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var objInsuranceDb = new InsuranceDB();
        DataSet dsInsurancesRecord = objInsuranceDb.GetInsurances(Profile.PracticeId, 10, 0, "Name",null);
        rptInsurances.DataSource = dsInsurancesRecord.Tables[0];
        rptInsurances.DataBind();
        hdnInsurancesTotalCount.Value = dsInsurancesRecord.Tables[1].Rows[0]["TotalRows"].ToString();

        GetInsuranceCategory();


        var objStatesDb = new StatesDB();
        DataTable states = objStatesDb.GetAllAsDataTable();

        ddlInsuranceStates.DataSource = states;
        ddlInsuranceStates.DataTextField = "StateName";
        ddlInsuranceStates.DataValueField = "StateCode";
        ddlInsuranceStates.DataBind();
        ddlInsuranceStates.Items.Insert(0, new ListItem("", ""));

    }

    private void GetInsuranceCategory()
    {
        var objInsuranceCategoryDb = new InsuranceCategoryDB();
        ddlInsuranceCategory.DataSource = objInsuranceCategoryDb.InsuranceCategory_GetAll();
        ddlInsuranceCategory.DataTextField = "InsuranceCategory";
        ddlInsuranceCategory.DataValueField = "InsuranceCategoryId";
        ddlInsuranceCategory.DataBind();
        ddlInsuranceCategory.Items.Insert(0, new ListItem("", ""));
    }

    protected void rptInsurances_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var lblPracticeId = (Label)e.Item.FindControl("lblPracticeId");
            var lblInsuranceId = (Label)e.Item.FindControl("lblInsuranceId");
            var lblAction = (Label)e.Item.FindControl("lblAction");

            string str = "";
            if (lblPracticeId.Text == "0")
            {
                str += "<span class='spanview' title='View' style='margin-left:15px;' onclick='ViewInsuranceGrid_Click(this,\"N\"," + lblInsuranceId.Text + ");'></span>";

            }
            else
            {
                str += "<span class='spnview' title='View' style='margin-left:15px;' onclick='ViewInsuranceGrid_Click(this,\"Y\"," + lblInsuranceId.Text + ");'></span>";
                //str += "<span class='spnedit' title='Edit' style='margin-left:5px;' onclick='editInsuranceGrid_Click(this,  " + lblInsuranceId.Text + ");'></span>";
                //str += "<span class='spndelete' title='Delete' style='margin-left:5px;' onclick='deleteInsuranceGrid_Click(this, " + lblInsuranceId.Text + ");'></span>";

            }
            lblAction.Text = str;

        }
    }
    protected string setClass(long practiceId)
    {
        string classToApply = string.Empty;
        classToApply = practiceId != 0 ? "tr-legend-blue" : "tr-legend-brown";
        return classToApply;
    }

}