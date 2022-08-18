using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_filter_FilterReportPostClaims : System.Web.UI.Page
{
    string _DateTo = ""; string _DateFrom = "";
    string _TimeSpan = "";
    string ClaimStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string DateType = Request.Form["DateType"];
        _DateFrom = Request.Form["StartDate"];
        _DateTo = Request.Form["EndDate"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string POSCode = Request.Form["PlaceOfService"];
        string CPTCode = Request.Form["POSCode"];
        string Payer = Request.Form["payer"];
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string ReportType = Request.Form["ReportType"];


        string Search_FileId = Request.Form["FileSearchId"];
        string SearchFileId = Search_FileId;
        string phsicians = "";
        if (!string.IsNullOrEmpty(Request.Form["providers"]))
        {
            phsicians = Request.Form["providers"];
        }


        ClaimStatus = Request.Form["ClaimStatus"];
        string name = Request.Form["name"];

        DataSet ds = new DataSet();


        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }


        DataSet dsReportData = objPatientReportsDB.GetPostClaim(PracticeId, Rows, PageNumber, DateType, _DateFrom, _DateTo, PracticeLocationId, POSCode, ClaimStatus, SearchFileId, CPTCode, Payer, ReportType, IsImportedDataOnly, phsicians, name);
        rptpostlciam.DataSource = dsReportData.Tables[1];
        rptpostlciam.DataBind();
    }
    protected void rptpostlciam_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string ProcedureCode = drv["ProcedureCode"].ToString();
            Label lblProcedureCode = (Label)e.Item.FindControl("lblProcedureCode");
            if (ProcedureCode == "")
            {
                lblProcedureCode.Style.Add("display", "none");
            }
            else
            {
                lblProcedureCode.Style.Add("display", "block");
            }
        }
    }
    
}