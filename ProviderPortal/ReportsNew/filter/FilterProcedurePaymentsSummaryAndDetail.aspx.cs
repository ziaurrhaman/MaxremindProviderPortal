using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_filter_FilterProcedurePaymentsSummaryReport : System.Web.UI.Page
{
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["action"]))
        {
            long PracticeId = Profile.PracticeId;
            string insurancetype = Request.Form["InsuranceType"];
            string insuranceIds = Request.Form["Insurance"];
            string CPTCodes = Request.Form["Cptcodes"];
            string Location = Request.Form["Location"];
            string ProviderId = Request.Form["ProviderId"];
            int Rows = int.Parse(Request.Form["Rows"]);
            int PageNumber = int.Parse(Request.Form["PageNumber"]);
            hdnCPTs.Value = CPTCodes;
            hdnInsuranceIds.Value = insuranceIds;
            hdnInsurancetype.Value = insurancetype;
            hdnProviderId.Value = ProviderId;
            hdnLocation.Value = Location;

            bool? IsImportedDataOnly = null;
            if (!string.IsNullOrEmpty(Session["IsImported"] as string))
            {

                if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
                else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
                else { IsImportedDataOnly = null; }
            }
            DataSet dsReportData = objPatientReportsDB.GetCPTwisePaymentDetailNEW(PracticeId, Rows, PageNumber, CPTCodes, insuranceIds, insurancetype, "", "", IsImportedDataOnly, ProviderId, Location);

            rptProcedurePaymentsSummary.DataSource = dsReportData.Tables[0];
            rptProcedurePaymentsSummary.DataBind();
            hdnTotalRows.Text = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else
        {
            long PracticeId = Profile.PracticeId;
            string CPTCodes = Request.Form["CPTS"];
            string insuranceIds = Request.Form["InsuranceIds"];
            string insurancetype = Request.Form["InsuranceType"];
            string SelectedInsurance = "";
            if (!string.IsNullOrEmpty(Request.Form["SelectInsurance"]))
            {
                SelectedInsurance = Request.Form["SelectInsurance"];
            }

            string SelectedCPT = "";
            if (!string.IsNullOrEmpty(Request.Form["SelectCPT"]))
            {
                SelectedCPT = Request.Form["SelectCPT"];
            }

            bool? IsImportedDataOnly = null;
            if (!string.IsNullOrEmpty(Session["IsImported"] as string))
            {

                if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
                else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
                else { IsImportedDataOnly = null; }
            }
            DataSet dsReportData = objPatientReportsDB.GetCPTwisePaymentDetailNEW(PracticeId, 1000, 0, CPTCodes, insuranceIds, insurancetype, SelectedCPT, SelectedInsurance, IsImportedDataOnly);
            rptReportData.DataSource = dsReportData.Tables[2];
            rptReportData.DataBind();
          
        }



    }
}