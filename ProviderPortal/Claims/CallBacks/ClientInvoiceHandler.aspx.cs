using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Claims_CallBacks_ClientInvoiceHandler : System.Web.UI.Page
{
    int Rows = 0;
    int pageNumber = 0;
    string Sort = "";
    string PaymentType = "";
    string PayerName = "";
    string PaymentMethod = "";
    string checkNumber = "";
    string PaymentDate = "";
    string Collection = "";
    long ClientInvoiceId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInvoiceDB invopiceDB = new PatientInvoiceDB();
        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["Rows"]))
            Rows = int.Parse(Request.Form["Rows"]);
        if (!string.IsNullOrEmpty(Request.Form["pageNumber"]))
            pageNumber = int.Parse(Request.Form["pageNumber"]);
        if (!string.IsNullOrEmpty(Request.Form["sort"]))
            Sort = Request.Form["sort"];
        if (!string.IsNullOrEmpty(Request.Form["PaymentType"]))
            PaymentType = Request.Form["PaymentType"];
        if (!string.IsNullOrEmpty(Request.Form["PayerName"]))
            PayerName = Request.Form["PayerName"];
        if (!string.IsNullOrEmpty(Request.Form["PaymentMethod"]))
            PaymentMethod = Request.Form["PaymentMethod"];
        if (!string.IsNullOrEmpty(Request.Form["checkNumber"]))
            checkNumber = Request.Form["checkNumber"];
        if (!string.IsNullOrEmpty(Request.Form["PaymentDate"]))
            PaymentDate = Request.Form["PaymentDate"];
        if (!string.IsNullOrEmpty(Request.Form["Collection"]))
            Collection = Request.Form["Collection"];

        if (!string.IsNullOrEmpty(Request.Form["ClientInvoiceId"]))
            ClientInvoiceId = long.Parse(Request.Form["ClientInvoiceId"]);
        DataSet dsClientInvoice = invopiceDB.GetClientInvoicesList(PracticeId, Rows, pageNumber, Sort,ClientInvoiceId, PaymentType, PayerName, PaymentMethod, checkNumber, PaymentDate, Collection);
        rptGeneratedClientInvoices.DataSource = dsClientInvoice.Tables[0];
        rptGeneratedClientInvoices.DataBind();
        ltrlERARowsCount.Text = dsClientInvoice.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}