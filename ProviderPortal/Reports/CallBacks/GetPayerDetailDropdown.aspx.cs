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