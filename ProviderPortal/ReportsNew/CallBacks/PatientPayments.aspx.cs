using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_ReportsNew_CallBacks_PatientPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ERAMasterDB objERAMasterDB = new ERAMasterDB();
        string DateType = "";      
        string DateFrom="";
        string DateTo  ="";
        long PracticeId = Profile.PracticeId;
      
         DateType = Request.Form["DateType"].ToString(); 
       
         DateFrom = Request.Form["DateFrom"].ToString();
         DateTo   = Request.Form["DateTo"].ToString();
       
       

        hdnDateFrom.Value = DateFrom;
        hdnDateTo.Value = DateTo;
        hdnDateType.Value = DateType;

        DataSet dsReportData = objERAMasterDB.Report_PatientPayments(PracticeId, 10, 0, "PatientId ASC",DateType, DateFrom, DateTo);

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}