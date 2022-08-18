using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterUnpostedPaymentsDetailandSummary : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.Form["Action"]))
        {
            string action = Request.Form["Action"];
            if (action == "searchCheck") {
                SearchCheck();
            }
            if (action == "searchCheckCus")
            {
                SearchCheckCustomize();
            }
            else if(action == "Filter")
            {
                UnpostedPaymentsummary();
            }
        }
    }
    public void SearchCheck()
    {
        string searchString=Request.Form["Checknumber"];
        ERAMasterDB objEraMasterDb = new ERAMasterDB();
        DataSet ds = objEraMasterDb.ERAMaster_GetBySearchCriteria(Profile.PracticeId, searchString, "", "", "", "", "", "", "", "", 10, 0, "Posted Date DESC", "", "false");
        rptERA1.DataSource = ds.Tables[0];
        rptERA1.DataBind();
    }
    public void SearchCheckCustomize()
    {
        string searchString = Request.Form["Checknumber"];
        ERAMasterDB objEraMasterDb = new ERAMasterDB();
        DataSet ds = objEraMasterDb.ERAMaster_GetBySearchCriteria(Profile.PracticeId, searchString, "", "", "", "", "", "", "", "", 10, 0, "Posted Date DESC", "", "false");
        rptERA1Customize.DataSource = ds.Tables[0];
        rptERA1Customize.DataBind();
    }
    public void UnpostedPaymentsummary()
    {
        string DateFrom = "";
        string DateTo = "";
        string DateType = "";
        string PayerType = "";

        DateType = Request.Form["DateType"];
        DateFrom = Request.Form["DateFrom"];
        DateTo = Request.Form["DateTo"];
        PayerType = Request.Form["PayerType"];
        string checknumber = Request.Form["CheckNo"];
        string Payers = Request.Form["Payers"];
        string Location = Request.Form["Location"];
        string Provider = Request.Form["Provider"];

        if (DateType == "" || DateType == null)
        {
            DateType = "PostDate";
        }

        bool? IsImportedDataOnly = null;

        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        ReportsPatientDB reportsPatientDB = new ReportsPatientDB();
        DataSet dsunpostedsummary = reportsPatientDB.GetUnpostedPaymentsSummary(Profile.PracticeId, PayerType, DateType, DateFrom, DateTo, checknumber, "", IsImportedDataOnly, Payers, Location, Provider);

        rptUnpostedPayments.DataSource = dsunpostedsummary.Tables[0];
        rptUnpostedPayments.DataBind();

        rptCheckDetail.DataSource = dsunpostedsummary.Tables[1];
        rptCheckDetail.DataBind();
        string[] _DateFrom = DateFrom.Split(new Char[] { '-' });
        string[] _DateTo = DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
    }
}