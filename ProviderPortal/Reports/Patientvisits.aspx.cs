using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class ProviderPortal_Reports_Patientvisits : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDropDowns();
        LoadReport();
    }

    private void LoadDropDowns()
    {
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet dsFilterData = objPatientReportsDB.LoadFilterDropDowns_PatientVitals(Profile.PracticeId);

        DataTable dtLocations = dsFilterData.Tables[0];
        DataTable dtProviders = dsFilterData.Tables[1];

        ddlPracticeLocations.DataSource = dtLocations;
        ddlPracticeLocations.DataValueField = "PracticeLocationsId";
        ddlPracticeLocations.DataTextField = "Name";
        ddlPracticeLocations.DataBind();

        BindProvidersByLocation();
    }

    private void BindProvidersByLocation()
    {
        PracticeStaffManager objPracticeStaffManager = new PracticeStaffManager();

        DataTable dtProviders = objPracticeStaffManager.GetPracticeStaffByType(Profile.PracticeId, 0, "");

        StringBuilder providersByLocationScript = new StringBuilder();

        providersByLocationScript.Append("<script type='text/javascript'>");

        providersByLocationScript.Append("var _arrPracticeStaffByLocation = new Array();");

        for (int i = 0; i < dtProviders.Rows.Count; i++)
        {
            providersByLocationScript.Append("var objApprovedProviders = new Object();");

            providersByLocationScript.Append("objApprovedProviders.ServiceProviderId ='" + dtProviders.Rows[i]["PracticeStaffId"].ToString() + "';");
            providersByLocationScript.Append("objApprovedProviders.Name ='" + dtProviders.Rows[i]["Name"].ToString() + "';");
            providersByLocationScript.Append("objApprovedProviders.PracticeLocationsId ='" + dtProviders.Rows[i]["PracticeLocationsId"].ToString() + "';");
            providersByLocationScript.Append("objApprovedProviders.StaffType ='" + dtProviders.Rows[i]["StaffType"].ToString() + "';");

            providersByLocationScript.Append("_arrPracticeStaffByLocation.push(objApprovedProviders);");
        }

        providersByLocationScript.Append("</script>");

        ltrProvidersByLocation.Text = providersByLocationScript.ToString();

        ddlServiceProviders.DataSource = dtProviders;
        ddlServiceProviders.DataValueField = "PracticeStaffId";
        ddlServiceProviders.DataTextField = "Name";
        ddlServiceProviders.DataBind();
    }

    private void LoadReport()
    {
        PatientDB objPatientDB = new PatientDB();

        DataSet ds = objPatientDB.PATIENTVISITS(10, 0, "DOS DESC", Profile.PracticeId, 0, 0);

        rptReportData.DataSource = ds.Tables[0];
        rptReportData.DataBind();

        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = hdnReportHtml.Value;
        string exportTo = ddlExportTo.SelectedValue;

        string FileName = "Patient Visit";

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
}