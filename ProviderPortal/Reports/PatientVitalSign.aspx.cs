using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Reports_PatientVitalSign : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ddlPulseExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = hdnInputPulse.Value;

        string exportTo = ddlPulseExportTo.SelectedValue.ToString();

        string FileName = "Patient Pulse";

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

    protected void ddlTemperatureExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = hdnInputTemperature.Value;

        string exportTo = ddlTemperatureExportTo.SelectedValue.ToString();

        string FileName = "Patient Temperature";

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

    protected void ddlBloodPressureExportTo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = hdnInputBloodPressure.Value;

        string exportTo = ddlBloodPressureExportTo.SelectedValue.ToString();

        string FileName = "Patient Blood Pressure";

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

    protected void ddlRespiratoryExportTo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = hdnInputRespiratory.Value;

        string exportTo = ddlRespiratoryExportTo.SelectedValue.ToString();

        string FileName = "Patient Respiratory";

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

    protected void ddlWeightExportTo_SelectedIndexChanged1(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string html = hdnInputWeight.Value;

        string exportTo = ddlWeightExportTo.SelectedValue.ToString();

        string FileName = "Patient Weight";

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