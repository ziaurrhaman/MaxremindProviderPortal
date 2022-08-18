using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterDuplicateChecks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["action"]))
        {
            InsuranceDB insuranceDB = new InsuranceDB();
            string PayersName = Request.Form["PayerName"];

            DataTable dtPayerName = insuranceDB.CheckNoList(Profile.PracticeId, PayersName, "", "CheckNumber");
            ddlCheckNumber.DataSource = dtPayerName;
            ddlCheckNumber.DataBind();
            ddlCheckNumber.DataTextField = "CheckNumber";
            ddlCheckNumber.DataValueField = "CheckNumber";
            ddlCheckNumber.DataBind();
            ddlCheckNumber.Items.Insert(0, new ListItem("", "All"));
            ddlCheckNumber.SelectedIndex = 0;
        }
        else { 
        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());

        string _DateFrom = "";
        string _DateTo = "";
        string InsuranceID = "";
        string CheckNo = "";

        _DateFrom = (Request.Form["Datefrom"]);
        _DateTo = (Request.Form["Dateto"]);
        InsuranceID = (Request.Form["InsuranceID"]);
        CheckNo = (Request.Form["CheckNo"]);

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        DataSet ds = objPatientReportsDB.DuplicateChecks(Profile.PracticeId, Profile.UserId, Rows, PageNumber, _DateFrom, _DateTo, InsuranceID, CheckNo);
        rptDuplicatecChecks.DataSource = ds.Tables[0];
        rptDuplicatecChecks.DataBind();
        ltrTotalRows.Text = ds.Tables[1].Rows[0]["TotRow"].ToString();
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnInsuranceID.Value = InsuranceID;
        hdnCheckNo.Value = CheckNo;

        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
        }

    }
}