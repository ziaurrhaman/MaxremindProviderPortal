using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class EMR_ReportsNew_CallBacks_PaymentsDetailReport : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    string DateType = "";
    string _TimeSpan = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        InsurancesFromInsurance();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        DateFrom = Request.Form["DateFrom"];
        DateTo = Request.Form["DateTo"];
        DateType = "PostDate";
         hdnDateFrom.Value = DateFrom;
         hdnDateTo.Value = DateTo;
        DataSet dsReportData = objPatientReportsDB.GetPaymentsDetail(PracticeId, 10, 0, "PaymentId asc", DateFrom, DateTo);

        rptPaymentsDetail.DataSource = dsReportData.Tables[0];
        rptPaymentsDetail.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();


        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });


        TimeSpan.Text =  _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];

    }
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptPayerScenario.DataSource = dtInsuranceDb;
            rptPayerScenario.DataBind();
        }

    }
}