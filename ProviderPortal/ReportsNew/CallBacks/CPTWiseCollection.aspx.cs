using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_CPTWiseCollection : System.Web.UI.Page
{
    string StartDate = "";
    string EndDate = ""; string claimid = "";
    string PracticeLocationId = ""; string ProviderId = "";
    string DateType = "";
    string CheckAssociated = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["action"];
        if (Request.Form["DateType"] == "" || Request.Form["DateType"] == null)
        {
            DateType = "PostDate";
            CheckAssociated = "";
        }
        else
        {
            DateType = Request.Form["DateType"].ToString();
        }
        if(DateType == "PostDate")
        {
            CheckAssociated = "";
        }
        else  if(DateType == "DOS")
        {
            CheckAssociated = "DOS";
        }
        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"].ToString();
        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"].ToString();
        }

        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "" || Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            //var today = DateTime.Today;
            //var month = new DateTime(today.Year, today.Month, 1);
            //StartDate = month.AddMonths(-1).ToShortDateString();
            //EndDate = month.AddDays(-1).ToShortDateString();
            DateTime curDate = DateTime.Now;
            StartDate = new DateTime(curDate.Year, curDate.Month, 1).ToShortDateString();
            //DateTime endDate1 = startDate.AddMonths(1).AddDays(-1);
            EndDate =(curDate).ToShortDateString();
        }
        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }
        if (Request.Form["claimid"] != null)
        {
            claimid = Request.Form["claimid"].ToString();
        }
        string[] _DateFrom = StartDate.Split(new Char[] { '-' });
        string[] _DateTo = EndDate.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
        ReportsDB db = new ReportsDB();
        DataSet ds = db.CPTWiseCollection(Profile.PracticeId, 10, 0, DateType, StartDate, EndDate, PracticeLocationId, ProviderId, CheckAssociated);

            rptReportData.DataSource = ds.Tables[0];
            rptReportData.DataBind();
        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();

        hdnStartDate.Value = StartDate;
        hdnEndDate.Value = EndDate;
        hdnDateType.Value = DateType;

        LoadProvider();
        LoadPracticeLocation();
        LoadPayersFromClaim();
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

    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           


        }
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