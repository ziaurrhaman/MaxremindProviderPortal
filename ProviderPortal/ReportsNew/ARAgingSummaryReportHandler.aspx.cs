using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_ARAgingSummaryReportHandler : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

        string Action = Request.Form["Action"];
        if (Action == "FirstDetail")
        {
            IstinsuranceDetail();
        }
        else if (Action == "SecondDetail")
        {
            SecinsuranceDetail();
        }
        else if (Action == "PatientDetail")
        {
            PatientDetail();
        }

        else if (Action == "PatClaimDetail")
        {
            PatClaimDetailFunction();
        }
 
    }



    protected void IstinsuranceDetail()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string Asof = Request.Form["Asof"];
        if (Asof == "" || Asof==null)
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

        DataSet ds = objPatientReportsDB.AccountsReceivableAgingTAB(Profile.UserId, Profile.PracticeId.ToString(), AgingType, Asof, ProviderId, PracticeLocationId, PayerId, IsImportedDataOnly);
        rptARAgingSummary.DataSource = ds.Tables[0];
        rptARAgingSummary.DataBind();
        hdnTotalRows.Value = "NoRows";


        hdnAgingType.Value = AgingType;
        hdnPracticeLocationId.Value = PracticeLocationId;
        hdnProviderId.Value = ProviderId;
        hdnPayerId.Value = PayerId;
        hdnAsof.Value = Asof;

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
            PayerId, "", "", "", "", "", "", "", "", "", "", "", "", Aging, BilledAs, "", IsImportedDataOnly,10,0);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rpt_InsuranceDetail.DataSource = ds.Tables[0];
            rpt_InsuranceDetail.DataBind();


            //rptPatients.DataSource = ds.Tables[1];
            //rptPatients.DataBind();



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
            // txtTotalOutStanding1P.Text = TotalOutStanding1P.ToString("0.00") + "%";



        }
        hdnBilledAs.Value = BilledAs;
        hdnAging.Value = Aging;
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

        DataSet ds = db.ARSummaryPatientsDetails(Profile.UserId, PracticeId.ToString(), "", "Patient ASC", AgingType, Asof, ProviderId, PracticeLocationId, PatsId, "", "", "",
            "", "", "", "",IsImportedDataOnly,"", 10, 0);

        rpt_Patient.DataSource = ds.Tables[0];
        rpt_Patient.DataBind();

        hdnAgingType1.Value = AgingType;
        hdnPracticeLocationId1.Value = PracticeLocationId;
        hdnProviderId1.Value = ProviderId;
        hdnPayerId1.Value = PayerId;
        hdnAsof1.Value = Asof;



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
        hdnPatientDetailRows.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();

    }

    protected void PatClaimDetailFunction()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;
        string AgingType = Request.Form["AgingType"];
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        string ProviderId = Request.Form["ProviderId"];
        string PayerId = Request.Form["PayerId"];
        string Asof = Request.Form["Asof"].ToString();
        string Patient = Request.Form["Patient"].ToString();

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

        DataSet ds = objPatientReportsDB.GetARInsuranceDetailFromDB(Profile.UserId, PracticeId.ToString(), "ClaimId Desc", AgingType, Asof, ProviderId, PracticeLocationId, "", Patient, "", "", "", "", "", "", "", "", "", "", "", "", IsImportedDataOnly);
        if (ds.Tables[0].Rows.Count > 0)
        {

            rptPatClm.DataSource = ds.Tables[0];
            rptPatClm.DataBind();


            //rptPatients.DataSource = ds.Tables[1];
            //rptPatients.DataBind();



            decimal TotalCharges = Convert.ToDecimal(ds.Tables[0].Compute("SUM(TotalCharges)", string.Empty));
            decimal PatientPayment = Convert.ToDecimal(ds.Tables[0].Compute("SUM(PatientPayment)", string.Empty));
            decimal InsurancePayment = Convert.ToDecimal(ds.Tables[0].Compute("SUM(InsurancePayment)", string.Empty));
            decimal Adjustments = Convert.ToDecimal(ds.Tables[0].Compute("SUM(Adjustments)", string.Empty));
            decimal TotalOutStanding = Convert.ToDecimal(ds.Tables[0].Compute("SUM(TotalOutStanding)", string.Empty));



            txtTotalCharges1.Text = TotalCharges.ToString("C");
            PatientPayment1.Text = PatientPayment.ToString("C");
            InsurancePayment1.Text = InsurancePayment.ToString("C");
            txtAdjustments.Text = Adjustments.ToString("C");
            TotalOutStanding1.Text = TotalOutStanding.ToString("C");


            decimal TotalChargesP = (TotalCharges / TotalOutStanding) * 100;
            decimal PatientPaymentP = (PatientPayment / TotalOutStanding) * 100;
            decimal InsurancePaymentP = (InsurancePayment / TotalOutStanding) * 100;
            decimal AdjustmentsP = (Adjustments / TotalOutStanding) * 100;
            decimal TotalOutStanding1P = (TotalOutStanding / TotalOutStanding) * 100;



            txtTotalChargesP1.Text = TotalChargesP.ToString("0.00") + "%";
            txtPatientPaymentP1.Text = PatientPaymentP.ToString("0.00") + "%";
            txtInsurancePaymentP1.Text = InsurancePaymentP.ToString("0.00") + "%";

            txtAdjustmentsP.Text = Adjustments.ToString("0.00") + "%";
            txtTotalOutStanding1P.Text = TotalOutStanding1P.ToString("0.00") + "%";

        }
    }
}