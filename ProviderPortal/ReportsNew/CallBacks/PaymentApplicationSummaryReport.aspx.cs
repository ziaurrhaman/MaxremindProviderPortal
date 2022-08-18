using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class EMR_ReportsNew_CallBacks_PaymentApplicationSummaryReport : System.Web.UI.Page
{
    string _DateFrom = "";
    string _DateTo = "";
    string _DateType = "";
    string _TimeSpan = "";
    //Added By faiza Bilal 6-7-2022
    int renderingprov = 0;
    int IndexNo = 0;

    //End Added By faiza Bilal 6-7-2022
    // Add by iqra 16/30/2022 Resolve Filter bugs//
    string Insurance = "";
    string ProviderIdbYNPI = "";
    string PracticeLocationId = "";
    // End  by iqra 16/30/2022 //
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        _DateFrom = Request.Form["Datefrom"];
        _DateTo = Request.Form["Dateto"];
        _DateType= Request.Form["DateType"];
        // Add by iqra 16/30/2022 Resolve Filter bugs//
        if (!string.IsNullOrEmpty(Request.Form["InsuranceID"]))
        {
            Insurance = Request.Form["InsuranceID"];
        }
        ProviderIdbYNPI = Request.Form["ProviderId"];
        PracticeLocationId = Request.Form["PracticeLocationId"];
        // End by iqra 16/30/2022 //
        if (_DateType == "" || _DateType == null)
        {

            _DateType = "POSTDATE";
        }
        //else
        //{
        //    TimeSpan.Text = "All Records";
        //}
        if (ProviderIdbYNPI == "")
        {
            ProviderIdbYNPI = null;
        }
        if (PracticeLocationId == "")
        {
            PracticeLocationId = null;
        }
        if (Insurance == "")
        {
            Insurance = null;
        }
            DataSet dsReportData = objPatientReportsDB.GetPaymentApplicationSummary(PracticeId, _DateFrom, _DateTo, _DateType, Insurance, ProviderIdbYNPI, PracticeLocationId);

        rptPaymentApplicationSummary.DataSource = dsReportData.Tables[0];
        rptPaymentApplicationSummary.DataBind();
        rptPaymentApplicationSummary1.DataSource = dsReportData.Tables[1];
        rptPaymentApplicationSummary1.DataBind();
        rptPaymentApplicationSummary2.DataSource = dsReportData.Tables[2];
        rptPaymentApplicationSummary2.DataBind();
      //  hdnTotalRows.Value = "NoRows";

        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;

        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
        LoadPayersFromClaim();
        LoadPracticeLocation();
        LoadProvider();

    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
    protected void rptPaymentApplicationSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string RenderingProvider = drv["RenderingProvider"].ToString();
            string PaymentMethod = drv["PaymentMethod"].ToString();
            Label lblPaymentMethod = (Label)e.Item.FindControl("lblPaymentMethod");
            Label lblSubTotal = (Label)e.Item.FindControl("lblSubTotal");
            Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal");
            //Edited By faiza Bilal 6-7-2022 to handle repeating providers name
            HtmlTableRow trRenProvider = (HtmlTableRow)e.Item.FindControl("RenderingProvider");

            Label lblTotalSummary = (Label)e.Item.FindControl("lblTotalSummary");

            if (renderingprov == 0)
            {

            }
            else
            {
                trRenProvider.Style.Add("display", "none");
            }
            renderingprov++;
            if (PaymentMethod == "" && RenderingProvider != "")
            {

                lblSubTotal.Text = "Total " + RenderingProvider;
                renderingprov = 0;
                IndexNo = 0;

            }
            else if (RenderingProvider == "")
            {
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                IndexNo++;
                lblPaymentMethod.Text = IndexNo + "- " + PaymentMethod;


            }
            //End Edited By faiza Bilal 6-7-2022 to handle repeating providers name

            if (!string.IsNullOrEmpty(drv["Total"].ToString()))
            {
                string Total = drv["Total"].ToString();

                lblTotalSummary.Text += "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
    }
    protected void rptPaymentApplicationSummary2_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string PaymentMethod = drv["PaymentMethod"].ToString();
            Label lblPaymentMethod = (Label)e.Item.FindControl("lblPaymentMethod3");
            Label lblGrandTotal = (Label)e.Item.FindControl("lblGrandTotal3");
            if (PaymentMethod == "")
            {
                lblGrandTotal.Text = "Grand Total :";
            }
            else
            {
                lblPaymentMethod.Text = PaymentMethod;
            }
            Label lblTotalAllRenderingProviders = (Label)e.Item.FindControl("lblTotalAllRenderingProviders");
            if (!string.IsNullOrEmpty(drv["Total"].ToString()))
            {
                string Total = drv["Total"].ToString();
                lblTotalAllRenderingProviders.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
    }
    protected void rptPaymentApplicationSummary1_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string total = drv["Total"].ToString();
            Label lblTotalUnappliedAnalysis = (Label)e.Item.FindControl("lblTotalUnappliedAnalysis");
            if (total != "")
            {
                lblTotalUnappliedAnalysis.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(total));
            }
        }
    }

}