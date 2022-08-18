using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_MailToInvoices_MailToInvoices : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MailToInvoiceDB ObjMailToInvoiceDB = new MailToInvoiceDB();
        long PracticeId = Profile.PracticeId;

        DataSet dsMailToInvoiceRecord = ObjMailToInvoiceDB.GetAllMailToInvoice(PracticeId,"");

        rptMailToInvoices.DataSource = dsMailToInvoiceRecord.Tables[0];
        rptMailToInvoices.DataBind();

        //hdnTotalRows.Value = dsMailToInvoiceRecord.Tables[1].Rows[0]["TotalRows"].ToString();

        hdnPracticeId.Value = Profile.PracticeId.ToString();

    }
}