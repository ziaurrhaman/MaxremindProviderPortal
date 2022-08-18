using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_PatientClaimCPT_wiseRecord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string CPTCode = Request.Form["CPTCode"];
        string Action = Request.Form["Criteria"];
        if(Action=="Claim" && CPTCode == "")
        {
            DataTable dt = new DataTable();
            DashboardRPM dashboard = new DashboardRPM();
            dt = dashboard.GETRPMDashBoard_ClaimAndPatientDetailWise(Profile.PracticeId, Action,CPTCode);
            rptClaim_wiseRecord.DataSource = dt;
            rptClaim_wiseRecord.DataBind();
        }
        else if (Action=="Patient" && CPTCode=="" )
        {
            DataTable dt = new DataTable();
            DashboardRPM dashboard = new DashboardRPM();
            dt = dashboard.GETRPMDashBoard_ClaimAndPatientDetailWise(Profile.PracticeId, Action, CPTCode);
            rptPatient_wiseRecord.DataSource = dt;
            rptPatient_wiseRecord.DataBind();

        }
        else if(Action=="Claim" && CPTCode != "")
        {
            DataTable dt = new DataTable();
            DashboardRPM dashboard = new DashboardRPM();
            dt = dashboard.GETRPMDashBoard_ClaimAndPatientDetailWise(Profile.PracticeId, Action, CPTCode);
            rptClaim_wiseRecord.DataSource = dt;
            rptClaim_wiseRecord.DataBind();
        }
        else if(Action=="CPTCode" && CPTCode != "")
        {
            string dateFrom = Request.Form["DateFrom"];
            string dateTo = Request.Form["DateTo"];
            DataTable dt = new DataTable();
            DashboardRPM dashboard = new DashboardRPM();
            dt = dashboard.GETRPMDashBoard_ClaimAndPatientDetailWise(Profile.PracticeId, Action, CPTCode,dateFrom,dateTo);
            rptCPT_wiseRecord.DataSource = dt;
            rptCPT_wiseRecord.DataBind();
        }
        else if(Action=="CPTCode" && CPTCode=="")
        {
            DataTable dt = new DataTable();
            DashboardRPM dashboard = new DashboardRPM();
            dt = dashboard.GETRPMDashBoard_ClaimAndPatientDetailWise(Profile.PracticeId, Action, null);
            rptCPT_wiseRecord.DataSource = dt;
            rptCPT_wiseRecord.DataBind();
        }

    }
}