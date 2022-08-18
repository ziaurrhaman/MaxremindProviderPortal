using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Reports_Top10DxCodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        ReportsPatientDB Rptdb = new ReportsPatientDB();


        DataSet ds = Rptdb.Top10Diagnosis(10, 0, Profile.PracticeId);


        rptTherapyTask.DataSource = ds.Tables[0];
        rptTherapyTask.DataBind();

        hdnTotalRowsTherapyTask.Value = "10";

    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = inpHide.Value;
        string exportTo = ddlExportTo.SelectedValue;
        if (exportTo == "Excel")
        {
            obj.ExportToExcel(ref html, "Top 10 Diagnosis");
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, "Top 10 Diagnosis");
        }
        else if (exportTo == "Word")
        {
            ExportToWord(html, "Top 10 Diagnosis");
        }
    }

    public void ExportToWord(string html, string fileName)
    {
        fileName = "Top 10 Diagnosis";
        html = html.Replace("&gt;", ">");
        html = html.Replace("&lt;", "<");
        HttpContext.Current.Response.ClearContent();
        HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName + ".doc");
        HttpContext.Current.Response.Write(html);
        HttpContext.Current.Response.End();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = inpHide.Value;
        string exportTo = ddlExportTo.SelectedValue;
        if (exportTo == "Excel")
        {
            obj.ExportToExcel(ref html, "Top 10 Diagnosis");
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, "Top 10 Diagnosis");
        }
        else if (exportTo == "Word")
        {
            ExportToWord(html, "Top 10 Diagnosis");
        }
    }
}