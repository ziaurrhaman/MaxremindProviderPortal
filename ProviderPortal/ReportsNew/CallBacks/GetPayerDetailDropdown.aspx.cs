using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_CallBacks_GetPayerDetailDropdown : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string payerName = "";
        string CheckNumber = "";

        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["PayerName"]))
        {
            payerName = Request.Form["PayerName"];
            DataTable dtPayerName = insuranceDB.GetAllPayersDetail(PracticeId, payerName, "", "CheckNumber");
            ddlCheckNumber.DataSource = dtPayerName;
            ddlCheckNumber.DataBind();
            ddlCheckNumber.DataTextField = "CheckNumber";
            ddlCheckNumber.DataValueField = "CheckNumber";
            ddlCheckNumber.DataBind();
            //ddlPostDate.Items.Insert(0, new ListItem("", "0"));
            //ddlPostDate.SelectedIndex = 0;
            //ddlPostDate.DataBind();


            //CustomizePayersName.DataSource = dtPatient;
            //CustomizePayersName.DataBind();
            //CustomizePayersName.DataTextField = "PayerName";
            //CustomizePayersName.DataValueField = "PayerName";
            //CustomizePayersName.DataBind();
            //CustomizePayersName.Items.Insert(0, new ListItem("All", ""));
            //DataRow drv = dtPayerName.Rows[0];
            //CheckNumber = drv["CheckNumber"].ToString();
            //DataTable dtCheckNumber = insuranceDB.GetAllPayersDetail(PracticeId, "", CheckNumber, "");
            //ddlPostDate.DataSource = dtCheckNumber;
            //ddlPostDate.DataBind();
            //ddlPostDate.DataTextField = "PostDate";
            //ddlPostDate.DataValueField = "PostDate";
            //ddlPostDate.DataBind();
            //CheckNumber = Request.Form["CheckNumber"];
            //DataTable dtCheckNumber = insuranceDB.GetAllPayersDetail(PracticeId, "", CheckNumber, "");
            //ddlPostDate.DataSource = dtCheckNumber;
            //ddlPostDate.DataBind();
            //ddlPostDate.DataTextField = "PostDate";
            //ddlPostDate.DataValueField = "PostDate";
            //ddlPostDate.DataBind();


        }
        if (!string.IsNullOrEmpty(Request.Form["CheckNumber"]))
        {
            CheckNumber = Request.Form["CheckNumber"];
            DataTable dtCheckNumber = insuranceDB.GetAllPayersDetail(PracticeId, "", CheckNumber, "");
            ddlPostDate.DataSource = dtCheckNumber;
            ddlPostDate.DataBind();
            ddlPostDate.DataTextField = "PostDate";
            ddlPostDate.DataValueField = "PostDate";
            ddlPostDate.DataBind();
        }
    }
}