using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Claims_ClientInvoice : System.Web.UI.Page
{
  
    long ClientInvoiceId = 0;
    string CheckNo = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInvoiceDB invopiceDB = new PatientInvoiceDB();
        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.QueryString["CheckNo"]))
        {
            CheckNo = Request.QueryString["CheckNo"];
            hdnCheckNumber.Value = CheckNo;
        }
        if (!string.IsNullOrEmpty(Request.QueryString["ClientInvoiceId"]))
        {
            ClientInvoiceId = long.Parse(Request.QueryString["ClientInvoiceId"]);
            hdnClientInvoiceId.Value = ClientInvoiceId.ToString();
        }

        DataSet dsClientInvoice = invopiceDB.GetClientInvoicesList(PracticeId, 10, 0, "",ClientInvoiceId, "", "", "","","","");
        rptClientInvoices.DataSource = dsClientInvoice.Tables[0];
        rptClientInvoices.DataBind();
        hdnTotalRows.Value = dsClientInvoice.Tables[1].Rows[0]["TotalRows"].ToString();

        
        DataSet dsClientInvoiceCollection = invopiceDB.GetGeneratedClientInvoiceDetail(PracticeId, CheckNo, ClientInvoiceId);
        rptClientInvoicesCollection.DataSource = dsClientInvoiceCollection.Tables[0];
        rptClientInvoicesCollection.DataBind();

        DateTime BillDate = DateTime.Parse(dsClientInvoiceCollection.Tables[0].Rows[0]["BillDate"].ToString());
        lblDateNow.Text = BillDate.ToShortDateString();
        lblInvoice.Text = dsClientInvoiceCollection.Tables[0].Rows[0]["InvoiceNumber"].ToString();
        lblCustomerId.Text = Convert.ToString(PracticeId);
        DateTime InvoiceDueDate = DateTime.Parse(dsClientInvoiceCollection.Tables[0].Rows[0]["InvoiceDueDate"].ToString());
        lblDueDate.Text = InvoiceDueDate.ToShortDateString();
        DateTime StatementFrom = DateTime.Parse(dsClientInvoiceCollection.Tables[0].Rows[0]["StatementFrom"].ToString());
        DateTime StatementTo = DateTime.Parse(dsClientInvoiceCollection.Tables[0].Rows[0]["StatementTo"].ToString());
        lblDateFromDateTo.Text = StatementFrom.ToShortDateString() + "-" + StatementTo.ToShortDateString();
       
        DataTable dtReportData = dsClientInvoiceCollection.Tables[0];

        float Total = 0;
        if (dtReportData.Rows.Count > 0)
        {
            for (int i = 0; i < dtReportData.Rows.Count; i++)
            {
                if (!string.IsNullOrEmpty(dtReportData.Rows[0]["Amount"].ToString()))
                {
                    string Amount = dtReportData.Rows[i]["Amount"].ToString();
                    Total = Total + float.Parse(Amount);

                }
            }
            lblSubTotal.Text = "$"+string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            lblTotal.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Total));
        }



    }
 
}