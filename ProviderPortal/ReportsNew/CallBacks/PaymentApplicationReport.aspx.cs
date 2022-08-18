using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class EMR_ReportsNew_CallBacks_PaymentApplicationReport : System.Web.UI.Page
{
    //numbering to patient
    //int indexno = 0;
    string _DateFrom = "";
    string _DateTo = "";
    private List<string> CheckNumbersList;
    private List<string> PatientCheckList;
    public EMR_ReportsNew_CallBacks_PaymentApplicationReport()
    {
        PatientCheckList = new List<string>();
        CheckNumbersList = new List<string>();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadPayerName();
    }
    public void LoadPayerName()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetAllPayersDetail(PracticeId, "", "", "PayerName");
        //ddlPayerName.DataSource = dtPatient;
        //ddlPayerName.DataBind();
        //ddlPayerName.DataTextField = "PayerName";
        //ddlPayerName.DataValueField = "PayerName";
        //ddlPayerName.DataBind();
        //ddlPayerName.Items.Insert(0, new ListItem("All", ""));
        CustomizePayersName.DataSource = dtPatient;
        CustomizePayersName.DataBind();
        CustomizePayersName.DataTextField = "PayerName";
        CustomizePayersName.DataValueField = "PayerName";
        CustomizePayersName.DataBind();
        CustomizePayersName.Items.Insert(0, new ListItem("All", ""));
        //string payerName = "";
        //string CheckNumber = "";
        //payerName = Request.Form["PayerName"];
        //DataTable dtPayerName = insuranceDB.GetAllPayersDetail(PracticeId, payerName, "", "CheckNumber");
        //ddlCheckNumber.DataSource = dtPayerName;
        //ddlCheckNumber.DataBind();
        //ddlCheckNumber.DataTextField = "CheckNumber";
        //ddlCheckNumber.DataValueField = "CheckNumber";
        //ddlCheckNumber.DataBind();
        //CheckNumber = Request.Form["CheckNumber"];
        //DataTable dtCheckNumber = insuranceDB.GetAllPayersDetail(PracticeId, "", CheckNumber, "");
        //ddlPostDate.DataSource = dtCheckNumber;
        //ddlPostDate.DataBind();
        //ddlPostDate.DataTextField = "PostDate";
        //ddlPostDate.DataValueField = "PostDate";
        //ddlPostDate.DataBind();

    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();


        _DateFrom = Request.Form["Datefrom"];
        _DateTo = Request.Form["Dateto"];
        long PracticeId = Profile.PracticeId;
        string payerName = Request.Form["payerName"];
        string checkNumber = Request.Form["checkNumber"];
        string postDate = Request.Form["CheckPostDate"];
        hdnPayerName.Value = Request.Form["payerName"];
        hdnCheckNumber.Value = Request.Form["checkNumber"];
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

        DataSet dsReportData = objPatientReportsDB.GetPaymentApplication(PracticeId, 9000000, 0, "", payerName, checkNumber, _DateFrom, _DateTo);

        rptPaymentApplication.DataSource = dsReportData.Tables[0];
        rptPaymentApplication.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
    }
    protected void rptPaymentApplication_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            //string rownumber = drv[""].ToString();
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
            //if(PatientName!="")
            //{
            //patient_numbers.Text = indexno + "- " + PatientName;
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
                //Checknumber_numbers.Text = "";
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                lblPostDate.Text = PostDate;
            }
        }
    }
}