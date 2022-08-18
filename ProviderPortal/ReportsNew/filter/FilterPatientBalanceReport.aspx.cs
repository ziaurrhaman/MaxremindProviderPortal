using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterPatientBalanceReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long userid = Profile.UserId;
        long Practiceid = Profile.PracticeId;
        string PracticeLocationId ="";
        string FromDate = "";
        string ToDate = "";
        string ProviderIds = "";
        string DateType = "";
        int Rows;
        int PageNumber;
        string Action = Request.Form["action"];
        if (Action == "Filter")
        {
             PracticeLocationId = Request.Form["PracticeLocationId"];
             FromDate = Request.Form["Datefrom"];
             ToDate = Request.Form["DateTo"];
             ProviderIds = Request.Form["ProviderId"];
             DateType = Request.Form["DateType"];
             Rows = int.Parse(Request.Form["Rows"]);
            PageNumber = int.Parse(Request.Form["PageNumber"]);

            ReportsDB db = new ReportsDB();
            DataSet dsPatBal = db.GetPatientBalanceSummary(userid, Practiceid, Rows, PageNumber, DateType , FromDate, ToDate, ProviderIds, PracticeLocationId);
            rptFilter.DataSource = dsPatBal.Tables[0];
            rptFilter.DataBind();
            ltrTotalRows.Text = dsPatBal.Tables[1].Rows[0]["TotalRows"].ToString();
            Control FooterTemplate = rptFilter.Controls[rptFilter.Controls.Count - 1].Controls[0];
            if (dsPatBal.Tables[0].Rows.Count != 0)
            {
                int total = int.Parse(dsPatBal.Tables[0].Compute("sum(TotalCount)", string.Empty).ToString());
                Label lblGrandTotal = FooterTemplate.FindControl("lblGrandTotal") as Label;
                lblGrandTotal.Text = total.ToString();
            }
        }
        else
        {
             PracticeLocationId = Request.Form["PracticeLocationId"];
             FromDate = Request.Form["Datefrom"];
             ToDate = Request.Form["DateTo"];
             ProviderIds = Request.Form["ProviderId"];
             DateType = Request.Form["DateType"];
            //Added by Faiza Bilal 2-7-2022
            int Patientid = Convert.ToInt32(Request.Form["Patid"]);
            ReportsDB db = new ReportsDB();
            DataTable dsPatBal = db.GetPatientBalanceDetail(userid, Practiceid, Patientid, DateType, FromDate, ToDate, ProviderIds, PracticeLocationId);
            rptPatBal.DataSource = dsPatBal;
            rptPatBal.DataBind();
            //End Added by Faiza Bilal 2-7-2022
        }
        hdnStartDate.Value = FromDate;
        hdnEndDate.Value = ToDate;
        hdnDateType.Value = DateType;
        hdnProviderId.Value = ProviderIds;
        hdnPracticeLocationId.Value = PracticeLocationId;
    }
}