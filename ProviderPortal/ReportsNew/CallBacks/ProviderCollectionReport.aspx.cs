using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_CallBacks_ProviderCollectionReport : System.Web.UI.Page
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
        string InsuranceID = null;

        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["action"]))
        {
            startDate = Request.Form["DateFrom"].ToString();
            endDate = Request.Form["DateTo"].ToString();
            if (!string.IsNullOrEmpty(Request.Form["ProviderId"]))
            {
                ProviderId = Request.Form["ProviderId"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.Form["InsuranceID"]))
            {
                InsuranceID = Request.Form["InsuranceID"].ToString();
            }
            if (!string.IsNullOrEmpty(Request.Form["PracticeLocationId"]))
            {
                PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
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
            DataSet dt = objPatientReportsDB.ProviderCollectionReport(PracticeId, Rows, PageNumber, startDate, endDate, ProviderId, PracticeLocationId, DateType, CheckAssociated, InsuranceID);
            RptFilterProviderCollectionReport.DataSource = dt.Tables[0];
            RptFilterProviderCollectionReport.DataBind();
            ltrTotalRows.Text = dt.Tables[1].Rows[0]["TotalRows"].ToString();
            hdnLocation.Value = PracticeLocationId;
            hdnProvider.Value = ProviderId;
            hdnPayer.Value = InsuranceID;
        }
        else
        {
            DateTime curDate = DateTime.Now;
            //startDate = new DateTime(curDate.Year, curDate.Month, 1); 
            startDate = Request.Form["DateFrom"];
            //DateTime endDate1 = startDate.AddMonths(1).AddDays(-1);
            endDate = Request.Form["DateTo"];
            
            ProviderId = null;
            PracticeLocationId = null;
            DateType = "PostDate";
            CheckAssociated = "";
            DataSet ds = objPatientReportsDB.ProviderCollectionReport(PracticeId, 10, 0, startDate, endDate, ProviderId, PracticeLocationId, DateType, CheckAssociated);
            rptProviderCollectionReport.DataSource = ds.Tables[0];
            rptProviderCollectionReport.DataBind();
            hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
            GetLocationsByDefault();
            GetProvidersByDefault();
            LoadPayersFromClaim();
        }
        hdnDateFrom.Value = startDate.ToString();
        hdnDateTo.Value = endDate.ToString();
        hdnDateType.Value = DateType.ToString();
        hdnLocation.Value = PracticeLocationId;
        hdnPayer.Value = InsuranceID;
        hdnProvider.Value = ProviderId;
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
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    protected void RptFilterProviderCollectionReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           


        }
    }

    protected void rptProviderCollectionReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            


        }

    }
}

   