using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Controls_LCDDiagnosis : System.Web.UI.Page
{
    LcdDB _objLcdDB;

    protected void Page_Load(object sender, EventArgs e)
    {
        _objLcdDB = new LcdDB();

        GetDXSupportedLCDS();
    }
    
    private void GetDXSupportedLCDS()
    {
        string DXCode = Request.Form["DXCode"];

        DataTable dtLCD = _objLcdDB.GetDXSupportedLCDS(DXCode, "");

        ltrLCDCount.Text = dtLCD.Rows.Count.ToString();
        
        if (dtLCD.Rows.Count > 0)
        {
            int LcdId = int.Parse(dtLCD.Rows[0]["lcd_id"].ToString());

            LoadLcdDetail(LcdId, DXCode);

            rptLcds.DataSource = dtLCD;
            rptLcds.DataBind();
        }
    }
    
    private void LoadLcdDetail(int LcdId, string DXCode)
    {
        DataSet dsLcdDetails = _objLcdDB.GetSupportedCPTICD9Wise(LcdId, DXCode, "");
        
        DataTable dtLcdDetail = dsLcdDetails.Tables[0];
        DataTable dtProcedureSupported = dsLcdDetails.Tables[1];
        
        if (dtLcdDetail.Rows.Count > 0)
        {
            spnTopDescription.InnerHtml = dtLcdDetail.Rows[0]["DXDescription"].ToString();
            spnLcdTitle.InnerHtml = dtLcdDetail.Rows[0]["Title"].ToString();
            spnLcdDates.InnerHtml = "(" + dtLcdDetail.Rows[0]["EffectiveDate"].ToString() + " - " + dtLcdDetail.Rows[0]["TerminationDate"].ToString() + ")";

            divPolicyDescription.InnerHtml = dtLcdDetail.Rows[0]["PolicyDescription"].ToString();
        }
        
        rptProcedureSupported.DataSource = dtProcedureSupported;
        rptProcedureSupported.DataBind();
    }
}