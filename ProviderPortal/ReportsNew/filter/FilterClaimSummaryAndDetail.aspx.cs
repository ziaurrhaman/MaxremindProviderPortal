using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterClaimsDetailReport : System.Web.UI.Page
{

    string ClaimStatus = "";
    string StartDate = "";
    string EndDate = ""; string claimid = "";
    string PracticeLocationId = ""; string ProviderId = ""; string MultipleCPTs = ""; string Bill = "";
    string Payerid = "";
    int Rows;
    int PageNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Level"];
        if (action == "CLM") { ClaimDetail(); }
     
        else if (action == "CLMFilter")
        {
            ClaimDetailFilter();
        }
        else if (action == "ProcedureFilter")
        {
            ProcedureDetailFilter();
        }
        else { ProcedureDetail(); }

    }
   
    public void ClaimDetail() {

        string DateType = "";
       
        if (Request.Form["Rows"] != "" || Request.Form["Rows"] == null)
        {
            Rows = int.Parse(Request.Form["Rows"]);
        }
        if (Request.Form["PageNumber"] != "" || Request.Form["PageNumber"] == null)
        {
            PageNumber = int.Parse(Request.Form["PageNumber"]);
        }

        if (Request.Form["DateType"] != "" || Request.Form["DateType"] == null)
        {
            DateType = Request.Form["DateType"].ToString();
        }
        else
        {
            DateType = "PostDate"; //
        }

      
        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"].ToString();

        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"].ToString();
          
        }
        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "")
        {
            StartDate = "";
        }
        if (Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            EndDate = "";
        }
       
        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }

     
       
        if (Request.Form["claimid"] != null)
        {
            claimid = (Request.Form["claimid"].ToString());
        }
        if (Request.Form["MultipleCPTs"] != null)
        {
            MultipleCPTs = Request.Form["MultipleCPTs"];
        }
        if (Request.Form["BillAs"] != null)
        {
            Bill = Request.Form["BillAs"];
        }
        if (Request.Form["ClaimStatus"] != null)
        {
            ClaimStatus = Request.Form["ClaimStatus"];
        }
        if (Request.Form["Payerid"] != null)
        {
            Payerid = Request.Form["Payerid"];
        }

        string level = "CLM";
        DataSet ds = new DataSet();
        string type = Request.Form["type"];
        if (ProviderId == "")
        { ProviderId = null; }
        if (PracticeLocationId == "")
        { PracticeLocationId = null; }
        if (Payerid == "")
        { Payerid = null; }
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
  
        ReportsDB db = new ReportsDB();
        if (type == "")
        {
            ds = db.GetClaimsDetail_ProviderPortalChargedClaims(Profile.PracticeId, Rows, PageNumber,"ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        if (type == "P")
        {
            ds = db.GetClaimsDetail_ProviderPortalPaidClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        if (type == "U")
        {
           ds = db.GetClaimsDetail_ProviderPortalUnPaidClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        if (type == "A")
        {
            ds = db.GetClaimsDetail_ProviderPortalAdjClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        rptclmdetail.DataSource = ds.Tables[0];
        rptclmdetail.DataBind();
        hdnInsRowsClaimSummary.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();
    }
    public void ProcedureDetail() {

        string DateType = "";
        if (Request.Form["Rows"] != "" || Request.Form["Rows"] == null)
        {
            Rows = int.Parse(Request.Form["Rows"]);
        }
        if (Request.Form["PageNumber"] != "" || Request.Form["PageNumber"] == null)
        {
            PageNumber = int.Parse(Request.Form["PageNumber"]);
        }

        if (Request.Form["DateType"] == "" || Request.Form["DateType"] == null)
        {
            DateType = "PostDate";
        }
        else
        {
            DateType = Request.Form["DateType"]; //
        }


        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"].ToString();
            
        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"].ToString();
            
        }
        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "")
        {
            StartDate = "";
        }
        if (Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            EndDate = "";
        }
       
        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }
        if (Request.Form["Payerid"] != null)
        {
            Payerid = Request.Form["Payerid"];
        }
        if (Request.Form["claimid"] != null)
        {
            claimid = (Request.Form["claimid"].ToString());
        }
        string level = "";
        string type = Request.Form["type"];
        if (ProviderId == "")
        { ProviderId = null; }
        if (PracticeLocationId == "")
        { PracticeLocationId = null; }
        if (Payerid == "")
        { Payerid = null; }
        if (Request.Form["MultipleCPTs"] != null)
        {
            MultipleCPTs = Request.Form["MultipleCPTs"];
        }
        if (Request.Form["BillAs"] != null)
        {
            Bill = Request.Form["BillAs"];
        }
        if (Request.Form["ClaimStatus"] != null)
        {
            ClaimStatus = Request.Form["ClaimStatus"];
        }
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {


            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet ds = new DataSet();

        ReportsDB db = new ReportsDB();
        if (type == "")
        {

            ds = db.GetClaimsDetail_ProviderPortalChargedCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);


        }
        if (type == "P")
        {

            ds = db.GetClaimsDetail_ProviderPortalPaidCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);



        }
        if (type == "U")
        {

            ds = db.GetClaimsDetail_ProviderPortalUnPaidCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, Payerid, claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);


        }
        if (type == "A")
        {

            ds = db.GetClaimsDetail_ProviderPortalAdjCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);


        }
        rptReportData.DataSource = ds.Tables[0];
        rptReportData.DataBind();
        hdnInsRowsCPT.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();

    }
    public void ProcedureDetailFilter()
    {

        string DateType = "";
        if (Request.Form["Rows"] != "" || Request.Form["Rows"] == null)
        {
            Rows = int.Parse(Request.Form["Rows"]);
        }
        if (Request.Form["PageNumber"] != "" || Request.Form["PageNumber"] == null)
        {
            PageNumber = int.Parse(Request.Form["PageNumber"]);
        }

        if (Request.Form["DateType"] == "" || Request.Form["DateType"] == null)
        {
            DateType = "PostDate";
        }
        else
        {
            DateType = Request.Form["DateType"]; //
        }


        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"].ToString();

        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"].ToString();

        }
        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "")
        {
            StartDate = "";
        }
        if (Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            EndDate = "";
        }

        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }

        if (Request.Form["claimid"] != null)
        {
            claimid = (Request.Form["claimid"].ToString());
        }
        string level = "";
        string type = Request.Form["type"];
        if (ProviderId == "")
        { ProviderId = null; }
        if (PracticeLocationId == "")
        { PracticeLocationId = null; }
        if (Payerid == "")
        { Payerid = null; }
        if (Request.Form["MultipleCPTs"] != null)
        {
            MultipleCPTs = Request.Form["MultipleCPTs"];
        }
        if (Request.Form["BillAs"] != null)
        {
            Bill = Request.Form["BillAs"];
        }
        if (Request.Form["ClaimStatus"] != null)
        {
            ClaimStatus = Request.Form["ClaimStatus"];
        }
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {


            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        DataSet ds = new DataSet();

        ReportsDB db = new ReportsDB();
        if (type == "")
        {
            ds = db.GetClaimsDetail_ProviderPortalChargedCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, Payerid, claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

        }
        if (type == "P")
        {
            ds = db.GetClaimsDetail_ProviderPortalPaidCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, Payerid, claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

        }
        if (type == "U")
        {
            ds = db.GetClaimsDetail_ProviderPortalUnPaidCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, Payerid, claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

        }
        if (type == "A")
        {
            ds = db.GetClaimsDetail_ProviderPortalAdjCPT(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, Payerid, claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus);

        }
        rptProceduredetail.DataSource = ds.Tables[0];
        rptProceduredetail.DataBind();
        hdnInsRowsCPT.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();

    }
    public void ClaimDetailFilter()
    {

        string DateType = "";

        if (Request.Form["Rows"] != "" || Request.Form["Rows"] == null)
        {
            Rows = int.Parse(Request.Form["Rows"]);
        }
        if (Request.Form["PageNumber"] != "" || Request.Form["PageNumber"] == null)
        {
            PageNumber = int.Parse(Request.Form["PageNumber"]);
        }

        if (Request.Form["DateType"] != "" || Request.Form["DateType"] == null)
        {
            DateType = Request.Form["DateType"].ToString();
        }
        else
        {
            DateType = "PostDate"; //
        }


        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"].ToString();

        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"].ToString();

        }
        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "")
        {
            StartDate = "";
        }
        if (Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            EndDate = "";
        }

        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }



        if (Request.Form["claimid"] != null)
        {
            claimid = (Request.Form["claimid"].ToString());
        }
        if (Request.Form["MultipleCPTs"] != null)
        {
            MultipleCPTs = Request.Form["MultipleCPTs"];
        }
        if (Request.Form["BillAs"] != null)
        {
            Bill = Request.Form["BillAs"];
        }
        if (Request.Form["ClaimStatus"] != null)
        {
            ClaimStatus = Request.Form["ClaimStatus"];
        }
        if (Request.Form["Payerid"] != null)
        {
            Payerid = Request.Form["Payerid"];
        }

        string level = "CLM";
        DataSet ds = new DataSet();
        string type = Request.Form["type"];
        if (ProviderId == "")
        { ProviderId = null; }
        if (PracticeLocationId == "")
        { PracticeLocationId = null; }
        if (Payerid == "")
        { Payerid = null; }
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {

            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }

        ReportsDB db = new ReportsDB();
        if (type == "")
        {
            ds = db.GetClaimsDetail_ProviderPortalChargedClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        if (type == "P")
        {
            ds = db.GetClaimsDetail_ProviderPortalPaidClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        if (type == "U")
        {
            ds = db.GetClaimsDetail_ProviderPortalUnPaidClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        if (type == "A")
        {
            ds = db.GetClaimsDetail_ProviderPortalAdjClaims(Profile.PracticeId, Rows, PageNumber, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid, IsImportedDataOnly, level, type, MultipleCPTs, Bill, ClaimStatus, Payerid);

        }
        rptfilterclmdetail.DataSource = ds.Tables[0];
        rptfilterclmdetail.DataBind();
        hdnInsRowsClaimSummary.Value = ds.Tables[1].Rows[0]["TotalCount"].ToString();
    }
}