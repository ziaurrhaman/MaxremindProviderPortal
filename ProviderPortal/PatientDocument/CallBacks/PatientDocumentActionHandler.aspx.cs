using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientDocument_CallBacks_PatientDocumentActionHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];

        if (action == "Save")
        {
            SavePatientDocuments();
        }
        else if (action == "Delete")
        {
            DeletePatientDocuments();
        }

        LoadPatientDocuments();
    }

    private void SavePatientDocuments()
    {
        long UserId = Profile.UserId;

        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();

        PatientDocuments objPatientDocuments = objJavaScriptSerializer.Deserialize<PatientDocuments>(Request.Form["objPatientDocuments"]);

        PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

        if (objPatientDocuments.DocumentId == 0)
        {
            objPatientDocuments.CreatedById = UserId;
            objPatientDocuments.CreatedDate = DateTime.Now;

            objPatientDocuments.DocumentId = objPatientDocumentDB.Add(objPatientDocuments);
        }
        else
        {
            objPatientDocuments.ModifiedById = UserId;
            objPatientDocuments.ModifiedDate = DateTime.Now;

            objPatientDocumentDB.Update(objPatientDocuments);
        }


        List<PatientDocumentAttachments> listPatientDocumentAttachments = objJavaScriptSerializer.Deserialize<List<PatientDocumentAttachments>>(Request.Form["listPatientDocumentAttachments"]);

        PatientDocumentAttachmentsDB objPatientDocumentAttachmentsDB = new PatientDocumentAttachmentsDB();

        foreach (PatientDocumentAttachments objPatientDocumentAttachments in listPatientDocumentAttachments)
        {
            objPatientDocumentAttachments.DocumentId = objPatientDocuments.DocumentId;

            if (objPatientDocumentAttachments.PatientDocumentAttachmentsId == 0)
            {
                objPatientDocumentAttachments.CreatedById = UserId;
                objPatientDocumentAttachments.CreatedDate = DateTime.Now;

                objPatientDocumentAttachmentsDB.Add(objPatientDocumentAttachments);
            }
            else
            {
                objPatientDocumentAttachments.ModifiedById = UserId;
                objPatientDocumentAttachments.ModifiedDate = DateTime.Now;

                objPatientDocumentAttachmentsDB.Update(objPatientDocumentAttachments);
            }
        }
    }

    private void DeletePatientDocuments()
    {
        long DocumentId = long.Parse(Request.Form["DocumentId"]);

        PatientDocuments objPatientDocuments = new PatientDocuments();

        objPatientDocuments.DocumentId = DocumentId;
        objPatientDocuments.ModifiedById = Profile.UserId;

        PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

        objPatientDocumentDB.Delete(objPatientDocuments);
    }

    private void LoadPatientDocuments()
    {
        PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

        long PatientId = long.Parse(Request.Form["PatientId"]);

        DataSet dsPatientDocuments = objPatientDocumentDB.FilterPatientDocuments(PatientId, "", "", "", 10, 0, "", "", "");
        rptPatientDocuments.DataSource = dsPatientDocuments.Tables[0];
        rptPatientDocuments.DataBind();

        ltrTotalRows.Text = dsPatientDocuments.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}