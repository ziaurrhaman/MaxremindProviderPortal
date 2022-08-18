using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterPaymentsDetailReport : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    string DateType = "";
    string _TimeSpan = "";
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
        else
        {
            ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
            long PracticeId = Profile.PracticeId;
            int Rows = int.Parse(Request.Form["Rows"]);
            int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());

            string SortBy = Request.Form["SortBy"];
            DateFrom = Request.Form["DateFrom"];
            DateTo = Request.Form["DateTo"];
            DateType = Request.Form["DateType"];
            string PaymentId = Request.Form["Paymentid"];
            string PaymentType = Request.Form["PaymentType"];
            string Payers = Request.Form["Payers"];
            DataSet dsReportData = objPatientReportsDB.GetPaymentsDetail(PracticeId, Rows, PageNumber, SortBy, DateFrom, DateTo, Payers, PaymentType, PaymentId);

            rptReportData.DataSource = dsReportData.Tables[0];
            rptReportData.DataBind();
            ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();

            string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
            string[] _DateTo = DateTo.Split(new Char[] { '-' });

            TimeSpan.Text =  _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
            hdnDateFrom.Value = DateFrom;
            hdnDateTo.Value = DateTo;
            hdnInsuranceID.Value = Payers;
            hdnCheckNo.Value = PaymentId;
            hdnPaymentType.Value = PaymentType;

        }
    }
}