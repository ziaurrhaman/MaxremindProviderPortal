using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_PatientBalanceReport : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        long userid = Profile.UserId;
        long Practiceid = Profile.PracticeId;
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string FromDate = Request.Form["Datefrom"];
        string ToDate = Request.Form["DateTo"];
        string ProviderIds = Request.Form["ProviderId"];
        string DateType = Request.Form["DateType"];
        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "" || Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            //var today = DateTime.Today;
            //var month = new DateTime(today.Year, today.Month, 1);
            //StartDate = month.AddMonths(-1).ToShortDateString();
            //EndDate = month.AddDays(-1).ToShortDateString();
            DateTime curDate = DateTime.Now;
            FromDate = new DateTime(curDate.Year, curDate.Month, 1).ToShortDateString();
            //DateTime endDate1 = startDate.AddMonths(1).AddDays(-1);
            ToDate = (curDate).ToShortDateString();
        }
        ReportsDB db = new ReportsDB();
        DataSet dsPatBal = db.GetPatientBalanceSummary(userid, Practiceid, 10, 0, DateType,  FromDate,  ToDate, ProviderIds, PracticeLocationId );
        rptPatBal.DataSource = dsPatBal.Tables[0];
        rptPatBal.DataBind();
        Control FooterTemplate = rptPatBal.Controls[rptPatBal.Controls.Count - 1].Controls[0];
        if (dsPatBal.Tables[0].Rows.Count != 0)
        {
            int total = int.Parse(dsPatBal.Tables[0].Compute("sum(TotalCount)", string.Empty).ToString());
            Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
            lblGrandTotal.Text = total.ToString();
        }
        hdnTotalRows.Value = dsPatBal.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnStartDate.Value = FromDate;
        hdnEndDate.Value = ToDate;
        hdnDateType.Value = DateType;
        hdnProviderId.Value = ProviderIds;
        hdnPracticeLocationId.Value = PracticeLocationId;
        LoadProvider();
        LoadPracticeLocation();
        string[] _DateFrom = FromDate.Split(new Char[] { '-' });
        string[] _DateTo = ToDate.Split(new Char[] { '-' });


        //TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];

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
}