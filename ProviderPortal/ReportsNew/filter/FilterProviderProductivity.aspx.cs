using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterProviderProductivity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string startDate = "";
        string endDate = "";
        int Rows;
        int PageNumber;
        string ProviderId = null;
        string PracticeLocationId = null;
        string DateType = null;
        string CheckAssociated = "";
        string Payers = null;
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        startDate = Request.Form["DateFrom"].ToString();
        endDate = Request.Form["DateTo"].ToString();
        if (!string.IsNullOrEmpty(Request.Form["ProviderId"]))
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }
        if (!string.IsNullOrEmpty(Request.Form["PracticeLocationId"]))
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }
        if (!string.IsNullOrEmpty(Request.Form["Payers"]))
        {
            Payers = Request.Form["Payers"].ToString();
        }
        if (!string.IsNullOrEmpty(Request.Form["DateType"]))
        {
            DateType = Request.Form["DateType"];
        }
        if (DateType == "PostDate")
        {
            CheckAssociated = "";
        }
        else if (DateType == "DOS")
        {
            CheckAssociated = "DOS";
        }
        Rows = int.Parse(Request.Form["Rows"]);
        PageNumber = int.Parse(Request.Form["PageNumber"]);
        DataSet dt = objPatientReportsDB.ProviderCollectionReport(Profile.PracticeId, Rows, PageNumber, startDate, endDate, ProviderId, PracticeLocationId, DateType, CheckAssociated, Payers);

        rptProviderCollectionReport.DataSource = dt.Tables[0];
        rptProviderCollectionReport.DataBind();
        ltrTotalRows.Text = dt.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}