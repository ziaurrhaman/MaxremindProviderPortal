using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Controls_CallBacks_LCDDiagnosisActionHandler : System.Web.UI.Page
{
    LcdDB _objLcdDB;
    string _action = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        _objLcdDB = new LcdDB();

        _action = Request.Form["action"];

        if (_action == "LoadLcdDetail")
        {
            LoadLcdDetail();
        }
        else if (_action == "FilterLcdPolicies")
        {
            FilterLcdPolicies();
        }
        else if (_action == "FilterProcedureSupported")
        {
            FilterProcedureSupported();
        }
    }
    
    private void LoadLcdDetail()
    {
        int LcdId = int.Parse(Request.Form["LcdId"]);
        string DXCode = Request.Form["DXCode"];
        
        LoadLcdDetailData(LcdId, DXCode, "");
    }

    private void FilterProcedureSupported()
    {
        int LcdId = int.Parse(Request.Form["LcdId"]);
        string DXCode = Request.Form["DXCode"];
        string Procedure = Request.Form["Procedure"];

        LoadLcdDetailData(LcdId, DXCode, Procedure);
    }

    private void LoadLcdDetailData(int LcdId, string DXCode, string Procedure)
    {
        DataSet dsLcdDetails = _objLcdDB.GetSupportedCPTICD9Wise(LcdId, DXCode, Procedure);
        
        DataTable dtLcdDetail = dsLcdDetails.Tables[0];
        DataTable dtProcedureSupported = dsLcdDetails.Tables[1];

        if (_action == "LoadLcdDetail")
        {
            SetLcdDetail(dtLcdDetail);
        }
        
        SetProcedureSupported(dtProcedureSupported);
    }
    
    private void SetLcdDetail(DataTable dtLcdDetail)
    {
        if (dtLcdDetail.Rows.Count > 0)
        {
            ltrTopDescription.Text = dtLcdDetail.Rows[0]["DXDescription"].ToString();
            ltrLcdTitle.Text = dtLcdDetail.Rows[0]["Title"].ToString();
            ltrLcdDates.Text = "(" + dtLcdDetail.Rows[0]["EffectiveDate"].ToString() + " - " + dtLcdDetail.Rows[0]["TerminationDate"].ToString() + ")";

            ltrPolicyDescription.Text = dtLcdDetail.Rows[0]["PolicyDescription"].ToString();
        }
    }

    private void SetProcedureSupported(DataTable dtProcedureSupported)
    {
        rptProcedureSupported.DataSource = dtProcedureSupported;
        rptProcedureSupported.DataBind();
    }

    private void FilterLcdPolicies()
    {
        string DXCode = Request.Form["DXCode"];
        string PolicyTitle = Request.Form["PolicyTitle"];

        DataTable dtLCD = _objLcdDB.GetDXSupportedLCDS(DXCode, PolicyTitle);

        rptLcds.DataSource = dtLCD;
        rptLcds.DataBind();
    }
}