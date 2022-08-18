using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;

public partial class EMR_Reports_PatientAppointments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Profile.RightsServer.ReportsView)
        {
            long PracticeId = Profile.PracticeId;
            PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();
            ddlLocations.DataSource = objPracticeLocationsDB.GetPracticeLocationsByPractice(PracticeId);
            ddlLocations.DataValueField = "PracticeLocationsId";
            ddlLocations.DataTextField = "Name";
            ddlLocations.DataBind();

            long PracticeLocationsId = long.Parse(ddlLocations.Items[0].Value);

            PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
            DataTable dtProvider = objPracticeStaffDB.GetProvidersByPracticeLocation(PracticeLocationsId);

            ddlProviders.DataSource = dtProvider;
            ddlProviders.DataValueField = "PracticeStaffId";
            ddlProviders.DataTextField = "Name";
            ddlProviders.DataBind();
            DataTable dtProviders = objPracticeStaffDB.GetProvidersByPractice(PracticeId);

            StringBuilder providersByLocationScript = new StringBuilder();
            providersByLocationScript.Append("<script type='text/javascript'>");
            providersByLocationScript.Append("var _arrProvidersByLocation = new Array();");

            for (int i = 0; i < dtProviders.Rows.Count; i++)
            {
                providersByLocationScript.Append("var objProviders = new Object();");
                providersByLocationScript.Append("objProviders.PracticeStaffId ='" + dtProviders.Rows[i]["PracticeStaffId"].ToString() + "';");
                providersByLocationScript.Append("objProviders.Name ='" + dtProviders.Rows[i]["Name"].ToString() + "';");
                providersByLocationScript.Append("objProviders.PracticeLocationsId ='" + dtProviders.Rows[i]["PracticeLocationsId"].ToString() + "';");

                providersByLocationScript.Append("_arrProvidersByLocation.push(objProviders);");
            }

            providersByLocationScript.Append("</script>");
            ltrProvidersByLocation.Text = providersByLocationScript.ToString();

            ReportsDB objReportsDB = new ReportsDB();
            DataSet dsAppointmentsRecord = null;
            dsAppointmentsRecord = objReportsDB.GetAppointmentBySearchCriteria(0, "", 0, "", "", "", "", "", 10, 0);
            rptAppointment.DataSource = dsAppointmentsRecord.Tables[0];
            rptAppointment.DataBind();
            hdnTotalRows.Value = dsAppointmentsRecord.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else
        {
            divReports.Style["display"] = "none";
            HtmlGenericControl divRightsSettings = (HtmlGenericControl)this.Page.Master.FindControl("divRightsSettings");
            divRightsSettings.InnerText = "You don't have rights to View Reports";
            divRightsSettings.Style["display"] = "block";
        }
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = inpHide.Value;

        string ExportTo = ddlExportTo.SelectedValue.ToString();

        if (ExportTo == "Excel")
        {
            obj.ExportToExcel(ref html, "Appointment-List-Report");
        }
        else if (ExportTo == "PDF")
        {
            obj.ExportToPDF(ref html, "Appointment-List-Report");
        }
        else if (ExportTo == "Word")
        {
            ExportToWord(html, "Appointment-List-Report");
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

        string ExportTo = ddlExportTo.SelectedValue.ToString();
        ddlExportTo.SelectedIndex = 0;
        if (ExportTo == "Excel")
        {
            obj.ExportToExcel(ref html, "Appointment-List-Report");
        }
        else if (ExportTo == "PDF")
        {
            obj.ExportToPDF(ref html, "Appointment-List-Report");
        }
        else if (ExportTo == "Word")
        {
            ExportToWord(html, "Appointment-List-Report");
        }
        
    }
}