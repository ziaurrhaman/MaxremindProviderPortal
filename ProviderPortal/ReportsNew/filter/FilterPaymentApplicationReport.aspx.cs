using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
public partial class EMR_ReportsNew_filter_FilterPaymentApplicationReport : System.Web.UI.Page
{
    //numbering to patient
    //int indexno = 0;
    string _DateFrom = "";
    string _DateTo = "";
    private List<string> CheckNumbersList;
    private List<string> PatientCheckList;
    public EMR_ReportsNew_filter_FilterPaymentApplicationReport()
    {
        PatientCheckList = new List<string>();
        CheckNumbersList = new List<string>();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        InsuranceDB insuranceDB = new InsuranceDB();
        string Action = Request.Form["Action"]; 
        long PracticeId = Profile.PracticeId;
        string PayerName = Request.Form["PayerName"];
        string CheckNumber = Request.Form["CheckNumber"];
        string PostDate = Request.Form["PostDate"];
        string PatientId = Request.Form["PatientId"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        if (Action == "Filter")
        {
            DataTable dtPayerName = insuranceDB.GetAllPayersDetail(PracticeId, PayerName, "", "CheckNumber");
            ddlCheckNumber.DataSource = dtPayerName;
            ddlCheckNumber.DataBind();
            ddlCheckNumber.DataTextField = "CheckNumber";
            ddlCheckNumber.DataValueField = "CheckNumber";
            ddlCheckNumber.DataBind();
            ddlCheckNumber.Items.Insert(0, new ListItem("All", ""));
        }
        if (Action == "Customize")
        {
            DataTable dtPayerName = insuranceDB.GetAllPayersDetail(PracticeId, PayerName, "", "CheckNumber");
            ddlCheckNumber.DataSource = dtPayerName;
            ddlCheckNumber.DataBind();
            ddlCheckNumber.DataTextField = "CheckNumber";
            ddlCheckNumber.DataValueField = "CheckNumber";
            ddlCheckNumber.DataBind();
            //DataRow drv = dtPayerName.Rows[0];
            //CheckNumber = drv["CheckNumber"].ToString();
            //DataTable dtCheckNumber = insuranceDB.GetAllPayersDetail(PracticeId, "", CheckNumber, "");
            //ddlPostDate.DataSource = dtCheckNumber;
            //ddlPostDate.DataBind();
            //ddlPostDate.DataTextField = "PostDate";
            //ddlPostDate.DataValueField = "PostDate";
            //ddlPostDate.DataBind();
            //ddlCheckNumber.SelectedValue = CheckNumber;
            //ddlPostDate.SelectedValue = PostDate;
           // ddlCheckNumber.Items.Insert(0, new ListItem("All", ""));
        }
        string CheckNo = "";

        _DateFrom = (Request.Form["Datefrom"]);
        _DateTo = (Request.Form["Dateto"]);
        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, 90000000, PageNumber, "", PayerName, CheckNumber, _DateFrom, _DateTo, PatientId);
        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();
        ltrTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnPayerName.Value = Request.Form["payerName"];
        hdnCheckNumber.Value = Request.Form["checkNumber"];


        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        hdnCheckNo.Value = CheckNo;

        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
        //if (!string.IsNullOrEmpty(CheckNumber))
        //{
        //DataTable dtPayerName = insuranceDB.GetAllPayersDetail(PracticeId, PayerName, "", "CheckNumber");
        //ddlCheckNumber.DataSource = dtPayerName;
        //ddlCheckNumber.DataBind();
        //ddlCheckNumber.DataTextField = "CheckNumber";
        //ddlCheckNumber.DataValueField = "CheckNumber";
        //ddlCheckNumber.DataBind();
        ////DataRow drv = dtPayerName.Rows[0];
        ////CheckNumber = drv["CheckNumber"].ToString();
        //DataTable dtCheckNumber = insuranceDB.GetAllPayersDetail(PracticeId, "", CheckNumber, "");
        //ddlPostDate.DataSource = dtCheckNumber;
        //ddlPostDate.DataBind();
        //ddlPostDate.DataTextField = "PostDate";
        //ddlPostDate.DataValueField = "PostDate";
        //ddlPostDate.DataBind();
        //ddlCheckNumber.SelectedValue = CheckNumber;
        //ddlPostDate.SelectedValue = PostDate;

        //}
    }
    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Patientid = drv["Patientid"].ToString();
            string CheckNumber = drv["CheckNumber"].ToString();
            string ClaimId = drv["ClaimId"].ToString();
            string PostDate = drv["CheckPostDate"].ToString();
            string PatientName = drv["Patient"].ToString();
            Label rownumber = (Label)e.Item.FindControl("rownumber");
            Label patient_numbers = (Label)e.Item.FindControl("patient_numbers");
            HtmlTableRow td_checknumber = (HtmlTableRow)e.Item.FindControl("checknumber");
            if (PatientCheckList.Contains(PatientName) && CheckNumbersList.Contains(CheckNumber))
            {
                patient_numbers.Text = "";
            }
            else
            {
                PatientCheckList.Add(PatientName);
                patient_numbers.Text = PatientName;
            }
            if (CheckNumbersList.Contains(CheckNumber))
            {
                td_checknumber.Style.Add("display", "none");
            }
            else
            {
                CheckNumbersList.Add(CheckNumber);
                td_checknumber.Style.Add("display", "show");
                //indexno = 0;
            }
            //indexno++;
            //if (PatientName != "")
            //{
            //    patient_numbers.Text = indexno + "- " + PatientName;
            //}
            Label lblPostDate = (Label)e.Item.FindControl("lblPostDate");
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            Label lblChkGrandTotal = (Label)e.Item.FindControl("lblChkGrandTotal");
            Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal");
            if (Patientid == "" && CheckNumber != "")
            {
                lblChkGrandTotal.Text = "Chk No's Grand Total:";
            }
            else if (Patientid != "" && ClaimId == "")
            {
                lblSubTotal.Text = "Sub Total :";
            }
            else if (CheckNumber == "")
            {
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                lblPostDate.Text = PostDate;
            }
        }
    }
}