using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterCPTWiseCollection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string StartDate = "";
        string EndDate = ""; string claimid = "";
        string PracticeLocationId = ""; string ProviderId = "";
        string DateType = "";
        string CheckAssociated = "";
        string InsuranceID = "";
        string CPTCode = "";

        string Action = Request.Form["action"];
        if (Request.Form["DateTypeCPT"] == "" || Request.Form["DateTypeCPT"] == null)
        {
            DateType = "PostDate";
            CheckAssociated = "";
        }
        else
        {
            DateType = Request.Form["DateTypeCPT"].ToString();
        }
        if (DateType == "PostDate")
        {
            CheckAssociated = "";
        }
        else if (DateType == "DOS")
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
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "" || Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            var today = DateTime.Today;
            var month = new DateTime(today.Year, today.Month, 1);
            StartDate = month.AddMonths(-1).ToShortDateString();
            EndDate = month.AddDays(-1).ToShortDateString();
        }
        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }
        if (Request.Form["InsuranceID"] != null)
        {
            InsuranceID = Request.Form["InsuranceID"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }
        if (Request.Form["claimid"] != null)
        {
            claimid = Request.Form["claimid"].ToString();
        }
        if (Request.Form["CPTCode"] != null)
        {
            CPTCode = Request.Form["CPTCode"];
        }
        ReportsDB db = new ReportsDB();
        DataSet ds = db.CPTWiseCollection(Profile.PracticeId, Rows, PageNumber, DateType, StartDate, EndDate, PracticeLocationId, ProviderId, CheckAssociated, InsuranceID,CPTCode);

            Filtered.DataSource = ds.Tables[0];
            Filtered.DataBind();
        ltrTotalRows.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnDateFrom.Value = StartDate;
        hdnDateTo.Value = EndDate;
        hdnDateType.Value = DateType;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProviderId.Value = ProviderId;
        hdnclaimid.Value = claimid;
        hdnPayer.Value = InsuranceID;
        hdnCPTCode.Value = CPTCode;
        string[] _DateFrom = StartDate.Split(new Char[] { '-' });
        string[] _DateTo = EndDate.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
    }

    protected void Filtered_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {


        }
    }
}