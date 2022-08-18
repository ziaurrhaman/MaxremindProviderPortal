using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_Reports_DailyPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnPracticeLocationsIdReport.Value = Profile.PracticeLocationsId.ToString();
        LoadReport();
    }

    private void LoadReport()
    {
        ERAMasterDB objERAMasterDB = new ERAMasterDB();

        DataSet dsReportData = objERAMasterDB.Report_DailyPayments(Profile.PracticeId, 10, 0, "PaymentDate DESC",DateTime.Now.ToString());

        rptReportData.DataSource = dsReportData.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();

        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Daily Payments";

        if (exportTo == "Excel")
        {
            obj.ExportToExcel(ref html, FileName);
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, FileName);
        }
        else if (exportTo == "Word")
        {
            obj.ExportToWord(html, FileName);
        }
    }

    protected void rptReportData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;

        string PaymentType = drv["PaymentType"].ToString().Trim();

        if (PaymentType == "PAT")
        {
            PaymentType = "Patient";
        }
        else
        {
            PaymentType = "Insurance";
        }

        Label lblPaymentSource = (Label)e.Item.FindControl("lblPaymentSource");

        lblPaymentSource.Text = PaymentType;
    }
}