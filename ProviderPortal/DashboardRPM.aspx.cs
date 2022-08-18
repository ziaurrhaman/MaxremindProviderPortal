//using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Default : System.Web.UI.Page
{
    string _dateTo = null;
    string _dateFrom = null;
    //Created by Faiza Bilal 8/6/2021
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
        txtReportDateTo.Style.Remove("border-color");
        txtReportDateFrom.Style.Remove("border-color");
        LoadPatients();
        LoadClaims();
        LoadPaidClaims();
        LoadInprocessClaims();
        LoadPayCharFr();
        BindDlls();


        string script = "<script type='text/javascript'>";
        DashboardRPM objDashboardRPM = new DashboardRPM();


        script += "var GETRPMDashBoard = new Array();";
        script += "GETRPMDashBoard.push(['Status','CoFrequency 1unt']);";



        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, null, _dateFrom, _dateTo);

        for (int i = 0; i < 3; i++)
        {
            if (dsDashboardRPM.Tables[2].Rows.Count > 0)
            {
                string name = dsDashboardRPM.Tables[2].Rows[i]["Name"].ToString();
                if (name == "PendingInsurance") { name = "Pending Insurances"; }
                if (name == "SubmitCharges") { name = "Submitted Charges"; }
                script += "GETRPMDashBoard.push(['" + name + "'," + dsDashboardRPM.Tables[2].Rows[i]["Value"].ToString() + "]);";
            }
            
        }

        script += "</script>";
        ltrlScript.Text = script;


    }
    private void LoadPayCharFr()
    {
        DashboardRPM objDashboardRPM = new DashboardRPM();
        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, null, _dateFrom, _dateTo);
        Repeater1.DataSource = dsDashboardRPM.Tables[3];

        Repeater1.DataBind();

    }
    private void LoadPatients()
    {


        DashboardRPM objDashboardRPM = new DashboardRPM();
        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, null, _dateFrom, _dateTo);
        string TotalPatients = "";
        if (dsDashboardRPM.Tables[0].Rows.Count > 0)
        {
            TotalPatients = dsDashboardRPM.Tables[0].Rows[0]["TotalPatients"].ToString();
        }
        if (string.IsNullOrEmpty(TotalPatients))
        {
            lblpatients.Text = "0";
        }
        else
        {

            lblpatients.Text = TotalPatients;
        }
        PatientDB ObjPatientDB = new PatientDB();

        DataSet dsPatients = ObjPatientDB.FilterPatients(0, "", "", "", "", "", "", "", Profile.PracticeId, 10, 0, "Account Number desc", false, "", "", _dateFrom, _dateTo, true);

        foreach (DataRow Row in dsPatients.Tables[0].Rows)
        {
            string DummyDOB = Row["DateOfBirth"].ToString();
            string DummyAddress = Row["Address"].ToString();
            string DummyAddress1 = "No Address";
            string DummyAddress2 = "00000";

            if (DummyDOB == "09/09/1900")
            {
                Row["DateOfBirth"] = null;
            }
            if (DummyAddress == "No Address, ,   , 00000" || DummyAddress.Contains(DummyAddress1) || DummyAddress.Contains(DummyAddress2))
            {
                Row["Address"] = null;
            }
        }
        rptPatients.DataSource = dsPatients.Tables[0];
        rptPatients.DataBind();
        hdnTotalRows.Value = dsPatients.Tables[1].Rows[0]["TotalRows"].ToString();

        hdnPracticeId.Value = Profile.PracticeId.ToString();

    }
    private void LoadClaims()
    {
        DashboardRPM objDashboardRPM = new DashboardRPM();
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, IsImportedDataOnly, _dateFrom, _dateTo);
        string TotalClaims = "";
        if (dsDashboardRPM.Tables.Count > 0)
        {
            TotalClaims = dsDashboardRPM.Tables[1].Rows[0]["TotalClaims"].ToString();
        }
        if (string.IsNullOrEmpty(TotalClaims))
        {
            lblClaims.Text = "0";
        }
        else
        {

            lblClaims.Text = TotalClaims;
        }

        var objClaimDB = new ClaimDB();

        DataSet dsClaim = objClaimDB.GetAllByPractice(10, 0, Profile.PracticeId, null, null, null, null, null, null, null, null, false, null, null, null, null, true, IsImportedDataOnly, null, true, _dateFrom, _dateTo);
        rptClaims.DataSource = dsClaim.Tables[0];
        rptClaims.DataBind();
        hdnClaimsCount.Value = dsClaim.Tables[1].Rows[0]["TotalRows"].ToString();
    }


    private void LoadPaidClaims()
    {
        DashboardRPM objDashboardRPM = new DashboardRPM();
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, IsImportedDataOnly, _dateFrom, _dateTo);
        string paidclaims = "";
        if (dsDashboardRPM.Tables.Count > 0)
        {
            paidclaims = dsDashboardRPM.Tables[1].Rows[0]["Paid Claims"].ToString();
        }
        if (string.IsNullOrEmpty(paidclaims))
        {
            lblpaidclaims.Text = "0";
        }
        else
        {

            lblpaidclaims.Text = paidclaims;
        }
    }
    private void LoadInprocessClaims()
    {
        DashboardRPM objDashboardRPM = new DashboardRPM();
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, IsImportedDataOnly, _dateFrom, _dateTo);
        string inprocessclaims = "";
        if (dsDashboardRPM.Tables.Count > 0)
        {
            inprocessclaims = dsDashboardRPM.Tables[1].Rows[0]["In Process"].ToString();
        }
        if (string.IsNullOrEmpty(inprocessclaims))
        {
            lblinprocessclaims.Text = "0";
        }
        else
        {
            lblinprocessclaims.Text = inprocessclaims;
        }
    }
    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["Name"].ToString();

            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");
            //
            Label lblstatus = (Label)e.Item.FindControl("lblstatus");
            //if (drv["InsuranceStatus"].ToString() == "No Response")
            //{
            //    lblstatus.Text = "Billed";

            //}
            //else
            //{
            lblstatus.Text = drv["SubmissionStatus"].ToString();
            //}
            ////
            if (Name == "")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }
        }
    }

    private void BindDlls()
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();
        ddlSubmissionStatus.DataSource = dtSubmissionStatusCodes;
        ddlSubmissionStatus.DataValueField = "SubmissionStatusId";
        ddlSubmissionStatus.DataTextField = "SubmissionStatus";
        ddlSubmissionStatus.DataBind();
        ddlSubmissionStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));

        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("100"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("200"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("201"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("202"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("203"));
        ddlSubmissionStatus.Items.Insert(1, new System.Web.UI.WebControls.ListItem("InProcess", "100"));
        if (!string.IsNullOrEmpty(Request.QueryString["status"]))
        {

            ddlSubmissionStatus.SelectedValue = "206";
        }

    }



    protected void BtnDateFilterRPM_Click(object sender, EventArgs e)
    {
        if (txtReportDateFrom.Text == "" || txtReportDateTo.Text == "")
        {
            if (txtReportDateTo.Text == "")
            {
                txtReportDateTo.Style.Add("border-color", "Red");
            }
            if (txtReportDateFrom.Text == "")
            {
                txtReportDateFrom.Style.Add("border-color", "Red");
            }
            if (txtReportDateFrom.Text == "" && txtReportDateTo.Text == "")
            {
                txtReportDateTo.Style.Remove("border-color");
                txtReportDateFrom.Style.Remove("border-color");
            }
           
        }
        else
        {
            txtReportDateTo.Style.Remove("border-color");
            txtReportDateFrom.Style.Remove("border-color");
            _dateTo = txtReportDateTo.Text;
            _dateFrom = txtReportDateFrom.Text;
        }
        LoadPatients();
        LoadClaims();
        LoadPaidClaims();
        LoadInprocessClaims();
        LoadPayCharFr();
        BindDlls();


        string script = "<script type='text/javascript'>";
        DashboardRPM objDashboardRPM = new DashboardRPM();


        script += "var GETRPMDashBoard = new Array();";
        script += "GETRPMDashBoard.push(['Status','CoFrequency 1unt']);";



        DataSet dsDashboardRPM = objDashboardRPM.GETRPMDashBoard(Profile.PracticeId, null, _dateFrom, _dateTo);
        if (dsDashboardRPM.Tables[2].Rows.Count > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                string name = dsDashboardRPM.Tables[2].Rows[i]["Name"].ToString();
                if (name == "PendingInsurance") { name = "Pending Insurances"; }
                if (name == "SubmitCharges") { name = "Submitted Charges"; }
                script += "GETRPMDashBoard.push(['" + name + "'," + dsDashboardRPM.Tables[2].Rows[i]["Value"].ToString() + "]);";
            }

            script += "</script>";
            ltrlScript.Text = script;
        }
        else
        {
            script += "GETRPMDashBoard.push(['" + 0 + "'," + 0 + "]);";
            script += "</script>";
            ltrlScript.Text = script;


        }

    }
}