using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_MailToInvoices_CallBacks_MailToInvoicesHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        var action = Request.Form["action"].ToString();

        if(action == "ViewFileName"){
            nameDetails();
        }
        else if (action == "BatchFilter")
        {
            BatchDetails();
        }
    }
    public void nameDetails()
    {    
        MailToInvoiceDB ObjMailToInvoiceDB = new MailToInvoiceDB();
        long PracticeId = Profile.PracticeId;
        string date  = Request.Form["date"].ToString();
        string Patientinvoicesearch = Request.Form["Patientinvoicesearch"].ToString();

        

        DataSet dsMailToInvoiceRecord = ObjMailToInvoiceDB.GetDetailedMailToInvoices(PracticeId, date, Patientinvoicesearch);
        if (dsMailToInvoiceRecord.Tables[0].Rows.Count > 0)
        {
            rptDetailMailToInvoice.DataSource = dsMailToInvoiceRecord.Tables[1];
            rptDetailMailToInvoice.DataBind();
        }
     
    }
    public void BatchDetails()
    {
        MailToInvoiceDB ObjMailToInvoiceDB = new MailToInvoiceDB();
        long PracticeId = Profile.PracticeId;
        string WeeklyInvoicetxt = Request.Form["WeeklyInvoicetxt"].ToString();

        DataSet dsMailToInvoiceRecord = ObjMailToInvoiceDB.GetAllMailToInvoice(PracticeId, WeeklyInvoicetxt);

        rptMailToInvoices.DataSource = dsMailToInvoiceRecord.Tables[0];
        rptMailToInvoices.DataBind();
    }
}