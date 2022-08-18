using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_filter_FilterContractManagementSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _TimeSpan = ""; string _DateType; string ProviderId;
    string PracticeLocationId;
    string PatientId; string ProcedureCode;
    string InsuranceId;
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string SortBy = Request.Form["SortBy"];
        _DateFrom = Request.Form["Datefrom"];
        _DateTo = Request.Form["DateTo"];
        if (_DateFrom == null || _DateFrom == "")
        {
            _DateFrom = Request.Form["BillDateFrom"];
        }
        if (_DateTo == null || _DateTo == "")
        {
            _DateTo = Request.Form["BillDateTo"];
        }
        _DateType = Request.Form["DateType"];
        if (_DateType == null || _DateType == "")
        {
            _DateType = "PostDate";
        }

        ProviderId = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];

        PatientId = Request.Form["PatientIds"];

        ProcedureCode = Request.Form["ProcedureCode"];
        //if (!string.IsNullOrEmpty(Request.Form["InsuranceId"]))
            InsuranceId = (Request.Form["PayerId"]);
        DataSet dsReportData = objPatientReportsDB.GetContractManagementSummary(PracticeId, Rows, PageNumber, SortBy, _DateType, ProviderId, PracticeLocationId, ProcedureCode, PatientId, _DateFrom, _DateTo, InsuranceId);
        DataTable dtReportData = dsReportData.Tables[0];
      //  Control FooterTemplate = rptContractManagementSummary.Controls[rptContractManagementSummary.Controls.Count - 1].Controls[0];
       // Label lblPracticeName = FooterTemplate.FindControl("lblPracticeName") as Label;
       // lblPracticeName.Text = Profile.PracticeName;
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AllowedAmount"].ToString()))
            {
                float TotalAllowedAmount = float.Parse(dtReportData.Compute("sum(AllowedAmount)", string.Empty).ToString());
              //  Label lblTotalAllowedAmount = FooterTemplate.FindControl("lblTotalAllowedAmount") as Label;
                lblTotalAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAllowedAmount));
            }
        }
        if (dtReportData.Rows.Count > 0)
        {
            if (!string.IsNullOrEmpty(dtReportData.Rows[0]["AVGPayment"].ToString()))
            {
                float TotalAVGPayment = float.Parse(dtReportData.Compute("sum(AVGPayment)", string.Empty).ToString());
              //  Label lblTotalAVGPayment = FooterTemplate.FindControl("lblTotalAVGPayment") as Label;
                lblTotalAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAVGPayment));
            }
        }

        rptContractManagementSummary.DataSource = dsReportData.Tables[0];
        rptContractManagementSummary.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];

        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnDateType.Value = _DateType;
        hdnPatId.Value = PatientId;
        hdnProviderId.Value = ProviderId;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProcedureCode.Value = ProcedureCode;

    }
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string AllowedAmount = drv["AllowedAmount"].ToString();
            Label lblAllowedAmount = (Label)e.Item.FindControl("lblAllowedAmount");
            if (AllowedAmount != "")
            {
                lblAllowedAmount.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AllowedAmount));
            }
            string AVGPayment = drv["AVGPayment"].ToString();
            Label lblAVGPayment = (Label)e.Item.FindControl("lblAVGPayment");
            if (AVGPayment != "")
            {
                lblAVGPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(AVGPayment));
            }
        }
    }
}