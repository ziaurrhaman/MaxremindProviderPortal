using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterProviderCollectionReport : System.Web.UI.Page
{
    string Action = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //Action = Request.Form["FilterDetail"];
        ////if (Action == "FilterDetail")
        ////{
        ////    ProviderWiseDetail();
        ////}
        //else
        //{
            ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
            long PracticeId = Profile.PracticeId;
            string StartDate = Request.Form["StartDate"];
            string EndDate = Request.Form["EndDate"];
            string Attending = Request.Form["Attending"];
            int Rows = int.Parse(Request.Form["Rows"]);
            int PageNumber = int.Parse(Request.Form["PageNumber"]);
            DataSet ds = objPatientReportsDB.ProviderCollectionReport(PracticeId, Rows, PageNumber, StartDate, EndDate, Attending);
            rptProviderCollectionReport.DataSource = ds;
            rptProviderCollectionReport.DataBind();
        //}
    }
    //private void ProviderWiseDetail()
    //{
    //    string DateFrom = Request.Form["DateFrom"];
    //    string DateTo = Request.Form["DateTo"];
    //    string DateType = Request.Form["DateType"];
    //    string Provider = Request.Form["Provider"];
    //    string Payer = Request.Form["Payer"];
    //    string Location = Request.Form["Location"];
    //    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    //    DataTable ds = objPatientReportsDB.ProviderWiseDetail(Profile.PracticeId, Provider, DateFrom, DateTo, DateType, Payer, Location);
    //}

}