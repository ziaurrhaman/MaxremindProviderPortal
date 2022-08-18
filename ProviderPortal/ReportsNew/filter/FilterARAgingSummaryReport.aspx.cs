using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class ProviderPortal_ReportsNew_filter_FilterARAgingSummaryReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Action = Request.Form["Action"].ToString();

        if (Action == "SecondDetail")
        {
            SecinsuranceDetail();
        }
        else if (Action == "PatientDetail")
        {
            PatientDetail();
        }
        else if (Action == "Filter")
        {
            Filter();
        }
        
    }

    protected void SecinsuranceDetail()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string Asof = Request.Form["Asof"];
        string BilledAs = Request.Form["BilledAs"];
        string Aging = Request.Form["Aging"];
        int Rows = int.Parse(Request.Form["Row"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        if (Asof == "")
        {
            Asof = DateTime.Now.ToString("MM/dd/yyyy");
        }

        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        DataSet ds = objPatientReportsDB.GetARInsuranceDetailFromTABDB(Profile.UserId, PracticeId.ToString(), "ClaimId Desc", AgingType, Asof, ProviderId, PracticeLocationId,
            PayerId, "", "", "", "", "", "", "", "", "", "", "", "", Aging, BilledAs, "", IsImportedDataOnly, Rows, PageNumber);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpt_InsuranceDetail.DataSource = ds.Tables[0];
            rpt_InsuranceDetail.DataBind();
            decimal TotalCharges = Convert.ToDecimal(ds.Tables[0].Compute("SUM(TotalCharges)", string.Empty));
            decimal PatientPayment = Convert.ToDecimal(ds.Tables[0].Compute("SUM(PatientPayment)", string.Empty));
            decimal InsurancePayment = Convert.ToDecimal(ds.Tables[0].Compute("SUM(InsurancePayment)", string.Empty));
            decimal Adjustments = Convert.ToDecimal(ds.Tables[0].Compute("SUM(Adjustments)", string.Empty));
            decimal TotalOutStanding = Convert.ToDecimal(ds.Tables[0].Compute("SUM(TotalOutStanding)", string.Empty));
            txtTotalCharges.Text = TotalCharges.ToString("C");
            txtPatientPayment.Text = PatientPayment.ToString("C");
            txtInsurancePayment.Text = InsurancePayment.ToString("C");
            txtAdjustments.Text = Adjustments.ToString("C");
            txtTotalOutStanding1.Text = TotalOutStanding.ToString("C");

            decimal TotalChargesP = (TotalCharges / TotalOutStanding) * 100;
            decimal PatientPaymentP = (PatientPayment / TotalOutStanding) * 100;
            decimal InsurancePaymentP = (InsurancePayment / TotalOutStanding) * 100;
            decimal AdjustmentsP = (Adjustments / TotalOutStanding) * 100;
            decimal TotalOutStanding1P = (TotalOutStanding / TotalOutStanding) * 100;

            txtTotalChargesP.Text = TotalChargesP.ToString("0.00") + "%";
            txtPatientPaymentP.Text = PatientPaymentP.ToString("0.00") + "%";
            txtInsurancePaymentP.Text = InsurancePaymentP.ToString("0.00") + "%";
            txtAdjustmentsP.Text = AdjustmentsP.ToString("0.00") + "%";
        }
        hdnInsRows.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();

    }

    protected void PatientDetail()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string Asof = Request.Form["Asof"].ToString();
        string PatsId = "";
        int Rows = int.Parse(Request.Form["Row"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        if (Asof == "")
        {
            Asof = DateTime.Now.ToString("MM/dd/yyyy");
        }

        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        ReportsPatientDB db = new ReportsPatientDB();

        DataSet ds = db.ARSummaryPatientsDetails(Profile.UserId, PracticeId.ToString(), "", "Patient ASC", AgingType, Asof, ProviderId, 
            PracticeLocationId, PatsId, "", "", "", "", "", "", "", IsImportedDataOnly,"", Rows, PageNumber);

        rpt_Patient.DataSource = ds.Tables[0];
        rpt_Patient.DataBind();
        decimal Current = Convert.ToDecimal(ds.Tables[0].Compute("SUM(Current)", string.Empty));
        decimal var3160 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([31-60])", string.Empty));
        decimal var6190 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([61-90])", string.Empty));
        decimal var91120 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([91-120])", string.Empty));
        decimal var120 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([120+])", string.Empty));
        decimal TotalOutStanding = Convert.ToDecimal(ds.Tables[0].Compute("SUM(TotalOutStanding)", string.Empty));


        Label7.Text = Current.ToString("C");
        Label8.Text = var3160.ToString("C");
        Label9.Text = var6190.ToString("C");
        Label10.Text = var91120.ToString("C");
        Label11.Text = var120.ToString("C");
        Label12.Text = TotalOutStanding.ToString("C");


        decimal CurrentP = (Current / TotalOutStanding) * 100;
        decimal var3160P = (var3160 / TotalOutStanding) * 100;
        decimal var6190P = (var6190 / TotalOutStanding) * 100;
        decimal var91120P = (var91120 / TotalOutStanding) * 100;
        decimal var120P = (var120 / TotalOutStanding) * 100;


        Label13.Text = CurrentP.ToString("0.00") + "%";
        Label14.Text = var3160P.ToString("0.00") + "%";
        Label15.Text = var6190P.ToString("0.00") + "%";
        Label16.Text = var91120P.ToString("0.00") + "%";
        Label17.Text = var120P.ToString("0.00") + "%";
        Label18.Text = "100%";
        hdnInsRows.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();

    }


    protected void Filter()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string Asof = Request.Form["Asof"];

        if (Asof == "" || Asof == null)
        {
            Asof = DateTime.Now.ToString("MM/dd/yyyy");
        }
        else
        {
            Asof = Request.Form["Asof"];

        }
        if (AgingType == "" || AgingType == null)
        {
            AgingType = "EncounterPostDate";
        }
        else
        {
            AgingType = Request.Form["AgingType"];
        }
        if (PracticeLocationId == "" || PracticeLocationId == null)
        {
            PracticeLocationId = null;
        }
        else
        {
            PracticeLocationId = Request.Form["PracticeLocationId"];
        }
        if (ProviderId == "" || ProviderId == null)
        {
            ProviderId = null;
        }
        else
        {
            ProviderId = Request.Form["ProviderId"]; ;
        }


        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))

        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        DataSet ds = objPatientReportsDB.GetARAgingSummary(Profile.UserId, Profile.PracticeId, AgingType, Asof, ProviderId, PracticeLocationId, PayerId, IsImportedDataOnly);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rptARAgingSummary.DataSource = ds.Tables[0];
            rptARAgingSummary.DataBind();
            hdnTotalRows.Value = "NoRows";




            decimal Current = Convert.ToDecimal(ds.Tables[0].Compute("SUM(Current)", string.Empty));
            decimal var3160 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([31-60])", string.Empty));
            decimal var6190 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([61-90])", string.Empty));
            decimal var91120 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([91-120])", string.Empty));
            decimal var120 = Convert.ToDecimal(ds.Tables[0].Compute("SUM([120+])", string.Empty));
            decimal TotalOutStanding = Convert.ToDecimal(ds.Tables[0].Compute("SUM(TotalOutStanding)", string.Empty));


            txtCurrent.Text = Current.ToString("C");
            txt3160.Text = var3160.ToString("C");
            txt6190.Text = var6190.ToString("C");
            txt91120.Text = var91120.ToString("C");
            txt120.Text = var120.ToString("C");
            txtTotalOutStanding.Text = TotalOutStanding.ToString("C");


            decimal CurrentP = (Current / TotalOutStanding) * 100;
            decimal var3160P = (var3160 / TotalOutStanding) * 100;
            decimal var6190P = (var6190 / TotalOutStanding) * 100;
            decimal var91120P = (var91120 / TotalOutStanding) * 100;
            decimal var120P = (var120 / TotalOutStanding) * 100;


            txtCurrentP.Text = CurrentP.ToString("0.00") + "%";
            txt3160P.Text = var3160P.ToString("0.00") + "%";
            txt6190P.Text = var6190P.ToString("0.00") + "%";
            txt91120P.Text = var91120P.ToString("0.00") + "%";
            txt120P.Text = var120P.ToString("0.00") + "%";
        }
        hdnAgingType.Value = AgingType;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProviderId.Value = ProviderId;
        hdnPayerId.Value = PayerId;
        hdnAsof.Value = Asof;
        string[] DateFrom = Asof.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0];
    }
    int count = 0;
    protected void rptARAgingSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {

            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Current = drv["Current"].ToString();
            string a3160 = drv["31-60"].ToString();
            string a61 = drv["61-90"].ToString();
            string a91 = drv["91-120"].ToString();
            string a120 = drv["120+"].ToString();
            string TotalOutStanding = drv["TotalOutStanding"].ToString();
            Label td_cpatient = (Label)e.Item.FindControl("current");
            Label td_cpatient1 = (Label)e.Item.FindControl("p31");
            Label td_cpatient2 = (Label)e.Item.FindControl("p61");
            Label td_cpatient3 = (Label)e.Item.FindControl("p91");
            Label td_cpatient4 = (Label)e.Item.FindControl("p120");
            Label td_cpatient5 = (Label)e.Item.FindControl("TotalOutStanding");
            if (count == 1)
            {
                td_cpatient.Attributes.Remove("class");
                td_cpatient1.Attributes.Remove("class");
                td_cpatient2.Attributes.Remove("class");
                td_cpatient3.Attributes.Remove("class");
                td_cpatient4.Attributes.Remove("class");
                td_cpatient5.Attributes.Remove("class");
            }
            td_cpatient.Text = Current;
            td_cpatient1.Text = a3160;
            td_cpatient2.Text = a61;
            td_cpatient3.Text = a91;
            td_cpatient4.Text = a120;
            td_cpatient5.Text = TotalOutStanding;
            count++;
        }
    }
}