using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientInvoice_CallBacks_GetInvoiceForSinglePatiendHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.Form["action"];
        int pageNumber = Convert.ToInt32(Request.Form["PageNumber"]);
        int Rows = Convert.ToInt32(Request.Form["Rows"]);
        //string PayerId = Request.Form["PayerId"];
        int? PayerId = null;
        if (!string.IsNullOrEmpty(Request.Form["PayerId"]))
        {
            PayerId = Convert.ToInt32(Request.Form["PayerId"]);
        }
        string PatientName = Request.Form["PatientName"];
        string lastInvoiceSubmitted = Request.Form["lastInvoiceSubmitted"];
        string totalPendingAmount = Request.Form["totalPendingAmount"];

        //if (action == "RBR")
        //{
            PatientInvoiceDB objPatientInvoiceDb = new PatientInvoiceDB();
            DataSet dsPendingSubmissions = objPatientInvoiceDb.GetPatientInvoiceDetails(Convert.ToInt64(Profile.PracticeId), Rows, pageNumber, PayerId, PatientName, lastInvoiceSubmitted, totalPendingAmount, null, null, null, null, type);
            rptPatientInvoices.DataSource = dsPendingSubmissions.Tables[0];
            rptPatientInvoices.DataBind();
            hdnPatientInvoicesCount.Value = dsPendingSubmissions.Tables[1].Rows[0]["TotalRows"].ToString();
        //}
        //else
        //{
        //    PatientInvoiceDB objPatientInvoiceDb = new PatientInvoiceDB();
        //    DataSet dsPendingSubmissions = objPatientInvoiceDb.GetPendingSubmissions1(Convert.ToInt64(Profile.PracticeId), Rows, pageNumber, PayerId, PatientName, lastInvoiceSubmitted, totalPendingAmount, null, null, null, null);
        //    rptPatientInvoices.DataSource = dsPendingSubmissions.Tables[2];
        //    rptPatientInvoices.DataBind();
        //    hdnPatientInvoicesCount.Value = dsPendingSubmissions.Tables[3].Rows[0]["TotalRows"].ToString();
        //}
    }
}