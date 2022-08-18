using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientInvoice_CallBacks_GetInvoiceForSinglePatient : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string type = Request.Form["action"];
        //string PatientId = Request.Form["PatientId"];
        int? PatientId = null;
        if (!string.IsNullOrEmpty(Request.Form["PatientId"]))
        {
            PatientId = Convert.ToInt32(Request.Form["PatientId"]);
        }
        if (type == "UnBilled")
        {
            lbltype.Text = "Invoice Type : All Cases";
        }
            else{
                lbltype.Text = "Invoice Type : Billed to patient";
            }
        
        //if (action == "RBR")
        //{
            PatientInvoiceDB objPatientInvoiceDb = new PatientInvoiceDB();
            DataSet dsPendingSubmissions = objPatientInvoiceDb.GetPatientInvoiceDetails(Convert.ToInt64(Profile.PracticeId), 10, 0, PatientId, null, null, null, null, null, null, null, type);
            rptPatientInvoices.DataSource = dsPendingSubmissions.Tables[0];
            rptPatientInvoices.DataBind();
            hdnPatientInvoicesCount.Value = dsPendingSubmissions.Tables[1].Rows[0]["TotalRows"].ToString();
        
        //}
        //else
        //{
        //    PatientInvoiceDB objPatientInvoiceDb = new PatientInvoiceDB();
        //    DataSet dsPendingSubmissions = objPatientInvoiceDb.GetPendingSubmissions1(Convert.ToInt64(Profile.PracticeId), 10, 0, PatientId, null, null, null, null, null, null, null);
        //    rptPatientInvoices.DataSource = dsPendingSubmissions.Tables[2];
        //    rptPatientInvoices.DataBind();
        //    hdnPatientInvoicesCount.Value = dsPendingSubmissions.Tables[3].Rows[0]["TotalRows"].ToString();
        //}
    }
}