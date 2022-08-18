using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


public partial class EMR_Reports_Top10Procedures : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //TherapyTasks objTherapyTasks = new TherapyTasks();
        //DataSet ds = objTherapyTasks.GetTherapyTaskSequency(int.Parse(Profile.AgencyId), 10, 0, "EpisodeId");

        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();



        DataSet ds = objClaimChargesDB.TOPTENPROCEDURES_SUMMARYReport(10, 0, Profile.PracticeId);


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
            obj.ExportToExcel(ref html, "Top 10 Procedures");
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, "Top 10 Procedures");
        }
        else if (exportTo == "Word")
        {
            ExportToWord(html, "Top 10 Procedures");
        }
    }

    public void ExportToWord(string html, string fileName)
    {
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
            obj.ExportToExcel(ref html, "Top 10 Procedures");
        }
        else if (exportTo == "PDF")
        {
            obj.ExportToPDF(ref html, "Top 10 Procedures");
        }
        else if (exportTo == "Word")
        {
            ExportToWord(html, "Top 10 Procedures");
        }
    }
}