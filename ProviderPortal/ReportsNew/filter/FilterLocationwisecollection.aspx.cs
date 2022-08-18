using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FilterLocationwisecollection : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

            long PracticeId = Profile.PracticeId;
            string DateType = Request.Form["DateType"];
            string ProviderId = Request.Form["ProviderId"];
            string PracticeLocationId = Request.Form["PracticeLocationId"];
            string ClaimId = Request.Form["ClaimId"];
            string InsuranceID = Request.Form["InsuranceID"];
            int PageNumber = int.Parse(Request.Form["PageNumber"]);
            int Rows = int.Parse(Request.Form["Rows"]);

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
            if (PracticeLocationId == "")
            {
                PracticeLocationId = null;

            }
        if (InsuranceID == "")
        {
            InsuranceID = null;

        }


        ReportsDB db = new ReportsDB();
            DataSet ds = db.LocationWiseDataSummary(PracticeId, Rows, PageNumber, DateFrom, DateTo, DateType, ProviderId, PracticeLocationId, CheckAssociated, InsuranceID);
            rptReportDataTbody.DataSource = ds.Tables[0];
            rptReportDataTbody.DataBind();
            ltrTotalRows.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
            hdnDateFrom.Value = DateFrom;
            hdnDateTo.Value = DateTo;
            hdnDateType.Value = DateType;
            hdnProvider.Value = ProviderId;
            hdnLocation.Value = PracticeLocationId;
            hdnPayers.Value = InsuranceID;
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];

    }
}