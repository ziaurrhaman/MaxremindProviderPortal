using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Claims_InvoiceGenerated : System.Web.UI.Page
{
    string DateFrom = "";
    string DateTo = "";
    int Rows = 10;
    int PageNumber = 0;
    string Sort = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInvoiceDB invopiceDB = new PatientInvoiceDB();
        long PracticeId = Profile.PracticeId;
        DateFrom = hdnDateFrom.Value;
        DateTo = hdnDateTo.Value;
        DataSet dsClientInvoice = invopiceDB.GetGeneratedClientInvoices(PracticeId, 10, 0, "", "", "","","","","");
        rptClientInvoices.DataSource = dsClientInvoice.Tables[0];
        rptClientInvoices.DataBind();
        hdnTotalRows.Value = dsClientInvoice.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}