using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Claims_CallBacks_InvoiceGeneratedHandler : System.Web.UI.Page
{
  
    int Rows = 10;
    int PageNumber = 0;
    string Sort = ""; 
    string InvoiceNumber = "";
    string StatementPeriod = "";
    string InvoiceDueDate = "";
    string BillDate = "";
    string Amount = "";
    string PayStatus = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInvoiceDB invopiceDB = new PatientInvoiceDB();
        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["Rows"]))
            Rows = int.Parse(Request.Form["Rows"]);
        if (!string.IsNullOrEmpty(Request.Form["pageNumber"]))
            PageNumber = int.Parse(Request.Form["pageNumber"]);
        if (!string.IsNullOrEmpty(Request.Form["sort"]))
            Sort = Request.Form["sort"];
        if (!string.IsNullOrEmpty(Request.Form["InvoiceNumber"]))
            InvoiceNumber = Request.Form["InvoiceNumber"];
        if (!string.IsNullOrEmpty(Request.Form["StatementPeriod"]))
            StatementPeriod = Request.Form["StatementPeriod"];
        if (!string.IsNullOrEmpty(Request.Form["InvoiceDueDate"]))
            InvoiceDueDate = Request.Form["InvoiceDueDate"];
        if (!string.IsNullOrEmpty(Request.Form["BillDate"]))
            BillDate = Request.Form["BillDate"];
        if (!string.IsNullOrEmpty(Request.Form["Amount"]))
            Amount = Request.Form["Amount"];
        if (!string.IsNullOrEmpty(Request.Form["PayStatus"]))
            PayStatus = Request.Form["PayStatus"];
        if (PayStatus == "0")
            PayStatus = "";
        DataSet dsClientInvoice = invopiceDB.GetGeneratedClientInvoices(PracticeId, Rows, PageNumber, Sort, InvoiceNumber, StatementPeriod, InvoiceDueDate, BillDate, Amount, PayStatus);
        rptClientInvoices.DataSource = dsClientInvoice.Tables[0];
        rptClientInvoices.DataBind();
        ltrlERARowsCount.Text = dsClientInvoice.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}