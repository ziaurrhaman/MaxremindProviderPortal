using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientInvoice_PatientInvoices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInvoiceDB objPatientInvoiceDb = new PatientInvoiceDB();
        //DataSet dsPendingSubmissions = objPatientInvoiceDb.GetPatientInvoiceDetails(Convert.ToInt64(Profile.PracticeId), 10, 0, null, null, null, null, null, null, null, null);
        //rptPatientInvoices.DataSource = dsPendingSubmissions.Tables[0];
        //rptPatientInvoices.DataBind();
        //hdnPendingSubmissionCount.Value = dsPendingSubmissions.Tables[1].Rows[0]["TotalRows"].ToString();
        //ddlPatientInvoices1.Attributes.Add("style", "display:none");
    }
}