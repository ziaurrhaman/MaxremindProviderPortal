using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;

public partial class EMR_ReportsNew_CallBacks_ARAgingSummaryReport : System.Web.UI.Page
{
    string AgingType = "";
    string PracticeLocationId = "";
    string ProviderId = "";
    string PayerId = "";
    string InsuranceID = "";
    string Asof = "";
    string Month = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadReport();
        LoadProvider();
        LoadPracticeLocation();
        InsurancesFromInsurance();
    }
    private void LoadReport()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
        long PracticeId = Profile.PracticeId;


        PayerId = Request.Form["PayerId"];

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
        //Month = DateTime.Now.ToString("MMMM");
        //string[] date = Asof.Split(new Char[] { '/' });
        //TimeSpan.Text = date[1] + date[0] + date[2];
        TimeSpan.Text = Asof;
        //TimeSpan.Text =  Asof;


        //get previous month name
       

    }

    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
    public void LoadPracticeLocation()
    {
        long PracticeId = Profile.PracticeId;
        ReportsDB db = new ReportsDB();

        DataTable dtPracticeLocation = db.GetLocationsByDefault(PracticeId);
        rptLocation.DataSource = dtPracticeLocation;
        rptLocation.DataBind();
    }
    private void InsurancesFromInsurance()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        using (DataTable dtInsuranceDb = objInsuranceDB.Insurance_GetBySearchCriteria(Profile.PracticeId, "", "", "", "", 100, 0, "").Tables[0])
        {
            rptInsurances.DataSource = dtInsuranceDb;
            rptInsurances.DataBind();
        }

    }
    int count = 0;
    protected void rptARAgingSummary_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
           
                DataRowView drv = (DataRowView)e.Item.DataItem;
                decimal Current = Convert.ToDecimal(( drv["Current"]));
                decimal a3160 = Convert.ToDecimal(drv["31-60"]);
                decimal a61 = Convert.ToDecimal(drv["61-90"]);
                decimal a91 = Convert.ToDecimal(drv["91-120"]);
                decimal a120 = Convert.ToDecimal(drv["120+"]);
                decimal TotalOutStanding = Convert.ToDecimal(drv["TotalOutStanding"]);
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
            td_cpatient.Text = Current.ToString("C");
            td_cpatient1.Text = a3160.ToString("C");
            td_cpatient2.Text = a61.ToString("C");
            td_cpatient3.Text = a91.ToString("C");
            td_cpatient4.Text = a120.ToString("C");
            td_cpatient5.Text = TotalOutStanding.ToString("C");
            count++;
        }
    }
}

