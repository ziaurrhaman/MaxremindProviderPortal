using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Claims_CallBacks_ClientInvoiceDetail : System.Web.UI.Page
{
    long ClientInvoiceId = 0;
    string CheckNo = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInvoiceDB invopiceDB = new PatientInvoiceDB();
        long PracticeId = Profile.PracticeId;
        if (!string.IsNullOrEmpty(Request.Form["CheckNo"]))
            CheckNo = Request.Form["CheckNo"];
        if (!string.IsNullOrEmpty(Request.Form["ClientInvoiceId"]))
        ClientInvoiceId = long.Parse(Request.Form["ClientInvoiceId"]);
        DataSet dsClientInvoice = invopiceDB.GetGeneratedClientInvoiceDetail(PracticeId, CheckNo, ClientInvoiceId);
        rptClientInvoices.DataSource = dsClientInvoice.Tables[0];
        rptClientInvoices.DataBind();

        if (dsClientInvoice.Tables[0].Rows.Count > 0) { 
        DateTime BillDate = DateTime.Parse(dsClientInvoice.Tables[0].Rows[0]["BillDate"].ToString());
        lblDateNow.Text = BillDate.ToShortDateString();
        lblInvoice.Text = dsClientInvoice.Tables[0].Rows[0]["InvoiceNumber"].ToString();//Convert.ToString(PracticeId + DateTime.Now.ToString("yyMM") + ClientInvoiceId);
        lblCustomerId.Text = Convert.ToString(PracticeId);
        DateTime InvoiceDueDate = DateTime.Parse(dsClientInvoice.Tables[0].Rows[0]["InvoiceDueDate"].ToString());
        lblDueDate.Text = InvoiceDueDate.ToShortDateString();
        DateTime StatementFrom = DateTime.Parse(dsClientInvoice.Tables[0].Rows[0]["StatementFrom"].ToString());
        DateTime StatementTo = DateTime.Parse(dsClientInvoice.Tables[0].Rows[0]["StatementTo"].ToString());
        lblDateFromDateTo.Text = StatementFrom.ToShortDateString() + "-" + StatementTo.ToShortDateString();
        lblPracticeName.Text = Profile.PracticeName;
        lblPracticeAddress.Text = Profile.PracticeAddress;
        lblCityStateZip.Text = Profile.PracticeCity + " ," + Profile.PracticeState + " " + Profile.PracticeZip;
        DataTable dtReportData = dsClientInvoice.Tables[0];

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
                lblSubTotal.Text = string.Format("{0:0,0.00}", Convert.ToDouble(Total));
                lblTotal.Text = string.Format("{0:0,0.00}", Convert.ToDouble(Total));
            }
        }
    }

    protected void rptClientInvoices_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            decimal rate = decimal.Parse(drv["RATE"].ToString());
            Label lblRate = (Label)e.Item.FindControl("lblRate");
            if (drv["Collection"].ToString() != "0.0000")
            {
                if (rate != null)
                {
                    lblRate.Text = Convert.ToString(Math.Round(rate, 2)) + "%";
                }

            }
            else
            {
                if (rate != null)
                {
                    lblRate.Text = "$" + Convert.ToString(Math.Round(rate, 2));
                }
            }
        }
    }
}