using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_CallBacks_Locationwisecollection : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["action"];
        string CheckAssociated = "";
       
        if (Action == "FilterLocationWiseCollection")
        {
            FilterLocationWiseCollection();
        }
        else
        {
            LoadPracticeLocation();
            LoadPayersFromClaim();
            LoadProvider();
            long PracticeId = Profile.PracticeId;
            string DateType = Request.Form["DateType"];
            if (DateType == ""||DateType==null)
            {
                DateType = "PostDate";
                CheckAssociated = "";
            }
            else if(DateType == "PostDate")
            {
                CheckAssociated = "";
            }
            else if(DateType == "DOS")
            {
                CheckAssociated = "DOS";
            }
            string ProviderId = Request.Form["ProviderId"];
            string PracticeLocationId = Request.Form["PracticeLocationId"];
            string InsuranceID = "";
            string ClaimId = Request.Form["ClaimId"];
            string DateFrom = Request.Form["DateFrom"];
            string DateTo = Request.Form["DateTo"];
            if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "" || Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
            {
                //var today = DateTime.Today;
                //var month = new DateTime(today.Year, today.Month, 1);
                //StartDate = month.AddMonths(-1).ToShortDateString();
                //EndDate = month.AddDays(-1).ToShortDateString();
                DateTime curDate = DateTime.Now;
                DateFrom = new DateTime(curDate.Year, curDate.Month, 1).ToShortDateString();
                //DateTime endDate1 = startDate.AddMonths(1).AddDays(-1);
                DateTo = (curDate).ToShortDateString();
            }

            if (ProviderId == "")
            { ProviderId = null; }
            if (PracticeLocationId == "")
            { PracticeLocationId = null; }

            string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
            string[] _DateTo = DateTo.Split(new Char[] { '-' });
            TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
            ReportsDB db = new ReportsDB();
            DataSet ds = db.LocationWiseDataSummary(PracticeId, 10, 0, DateFrom, DateTo, DateType, ProviderId, PracticeLocationId, CheckAssociated, InsuranceID);

            rptReportData.DataSource = ds.Tables[0];
            rptReportData.DataBind();
            hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
            hdnDateFrom.Value = DateFrom;
            hdnDateTo.Value = DateTo;
            hdnDateType.Value = DateType;
            hdnProvider.Value = ProviderId;
            hdnLocation.Value = PracticeLocationId;
        }


    }
    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        DynamicProviders.DataSource = ds;
        DynamicProviders.DataBind();
    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();
       
        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();

    }
    public void FilterLocationWiseCollection()
    {
        //DateTime curDate = DateTime.Now;
        //startDate = curDate.AddMonths(-1).AddDays(1 - curDate.Day);
        //endDate = startDate.AddMonths(1).AddDays(-1);

        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateTypeLocation"];
        string ProviderId = Request.Form["ProviderId"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ClaimId = Request.Form["ClaimId"];
        string InsuranceID = Request.Form["InsuranceID"];

        string DateFrom = Request.Form["DateFrom"];
        string DateTo = Request.Form["DateTo"];
        string CheckAssociated = "";
        if (DateType == "PostDate")
        {
            CheckAssociated = "";
        }
        else if (DateType == "DOS")
        {
            CheckAssociated = "DOS";
        }
        if (ProviderId == "")
        {
            ProviderId = null;
        }
       if (PracticeLocationId =="")
        {
            PracticeLocationId = null;

        }

        ReportsDB db = new ReportsDB();
        DataSet ds = db.LocationWiseDataSummary(PracticeId, 10, 0, DateFrom, DateTo, DateType ,ProviderId, PracticeLocationId, CheckAssociated, InsuranceID);
        rptReportDataTbody.DataSource = ds.Tables[0];
        rptReportDataTbody.DataBind();
        ltrTotalRows.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;
        hdnProvider.Value = ProviderId;
        hdnLocation.Value = PracticeLocationId;
        hdnPayers.Value = InsuranceID;

    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }

  
}