using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_filter_FilterClaimsDetailReport : System.Web.UI.Page
{

    string StartDate = "";
    string EndDate = ""; long claimid = 0;
    string PracticeLocationId = ""; string ProviderId = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Level"];
        if (action == "CLM") { ClaimDetail(); }
        else { ProcedureDetail(); }
      
    }
   
    public void ClaimDetail() {

        string DateType = "";
       

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
            claimid = Convert.ToInt64(Request.Form["claimid"].ToString());
        }
       
        string  level = "CLM";
        string type = Request.Form["type"];        
      
        ReportsDB db = new ReportsDB();
        DataSet ds = db.GetClaimsDetails(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid,level,type);
        rptclmdetail.DataSource = ds.Tables[1];
        rptclmdetail.DataBind();
    }
    public void ProcedureDetail() {

        string DateType = "";


        if (Request.Form["DateType"] != "" || Request.Form["DateType"] == null)
        {
            DateType = "DOS";
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
            claimid = Convert.ToInt64(Request.Form["claimid"].ToString());
        }
        string level = "";
        string type = Request.Form["type"];        
      
        ReportsDB db = new ReportsDB();
        DataSet ds = db.GetClaimsDetails(Profile.PracticeId, 10, 0, "ClaimId DESC", DateType, StartDate, EndDate, PracticeLocationId, ProviderId, "", claimid,level,type);
        rptReportData.DataSource = ds.Tables[1];
        rptReportData.DataBind();
      
    }
}