using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_CallBacks_ProviderProductivity : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        string startDate = "";
        string endDate = "";
        int Rows;
        int PageNumber;
        string ProviderId = null;
        string PracticeLocationId = null;
        string DateType = null;
        string CheckAssociated = "";
        string Payers = null;

        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["action"]))
        {
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
            DataSet dt = objPatientReportsDB.ProviderCollectionReport(PracticeId, Rows, PageNumber, startDate, endDate, ProviderId, PracticeLocationId, DateType, CheckAssociated, Payers);
            RptFilterProviderCollectionReport.DataSource = dt.Tables[0];
            RptFilterProviderCollectionReport.DataBind();
            ltrTotalRows.Text = dt.Tables[1].Rows[0]["TotalRows"].ToString();
            hdnLocation.Value = PracticeLocationId;
            hdnProvider.Value = ProviderId;
            hdnPayer.Value = Payers;
        }
        else
        {
            DateTime curDate = DateTime.Now;
            //startDate = new DateTime(curDate.Year, curDate.Month, 1); 
            startDate = Request.Form["DateFrom"].ToString();
            //DateTime endDate1 = startDate.AddMonths(1).AddDays(-1);
            endDate = Request.Form["DateTo"].ToString();
            ProviderId = null;
            PracticeLocationId = null;
            DateType = "PostDate";
            CheckAssociated = "";
            DataSet dt = objPatientReportsDB.ProviderCollectionReport(PracticeId, 10, 0, startDate, endDate, ProviderId, PracticeLocationId, DateType, CheckAssociated);
            rptProviderCollectionReport.DataSource = dt.Tables[0];
            rptProviderCollectionReport.DataBind();
            hdnTotalRows.Value = dt.Tables[1].Rows[0]["TotalRows"].ToString();
            GetLocationsByDefault();
            GetProvidersByDefault();
            InsurancesFromInsurance();
        }
        hdnDateFrom.Value = startDate.ToString();
        hdnDateTo.Value = endDate.ToString();
        hdnDateType.Value = DateType.ToString();
        //string[] DateFrom = startDate.Split(new Char[] { '-' });
        //string[] DateTo = endDate.Split(new Char[] { '-' });
        //TimeSpan.Text =DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + " - " + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
        //hdnLocation.Value = PracticeLocationId.ToString();
        //hdnPayer.Value = Payers.ToString();
        //hdnProvider.Value = ProviderId.ToString();
    }
    public void GetLocationsByDefault()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    public void GetProvidersByDefault()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        DynamicProviders.DataSource = ds;
        DynamicProviders.DataBind();
    }

    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptInsurances.DataSource = dtInsuranceDb;
            rptInsurances.DataBind();
        }

    }
}