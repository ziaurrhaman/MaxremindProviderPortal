using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientDocument_CallBacks_PatientDocumentAttachmentsPaths : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long DocumentId = long.Parse(Request.Form["DocumentId"]);

        PatientDocumentAttachmentsDB objPatientDocumentAttachmentsDB = new PatientDocumentAttachmentsDB();

        DataTable dtDocumentAttachments = objPatientDocumentAttachmentsDB.GetByDocumentId(DocumentId);

        rptDocumentAttachments.DataSource = dtDocumentAttachments;
        rptDocumentAttachments.DataBind();
    }
}