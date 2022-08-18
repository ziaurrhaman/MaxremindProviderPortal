using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientDocument_PatientDocument : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long PatientId = 0;
        if(!string.IsNullOrEmpty(Request.Form["PatientId"]))
         PatientId = long.Parse(Request.Form["PatientId"]);

        hdnPracticeDocumentPath.Value = ResolveUrl("~/PracticeDocuments/" + Profile.PracticeId.ToString() + "/PracticeDocumentFiles");

        string DocumentFilesPath = Profile.PracticeId + "/" + "Patients" + "/" + PatientId + "/Documents/";
        hdnDocumentFilesPath.Value = DocumentFilesPath;

        LoadDocumentCategories();
        LoadPatientDocument(PatientId);
    }

    private void LoadDocumentCategories()
    {
        DocumentCategory objDocumentCategory = new DocumentCategory();

        ddlCategory.DataSource = objDocumentCategory.DocumentCategory_GetByPracticeId(Profile.PracticeId);
        ddlCategory.DataTextField = "Name";
        ddlCategory.DataValueField = "CategoryId";
        ddlCategory.DataBind();
        ddlCategory.Items.Insert(0, new ListItem("All", "0"));
    }

    private void LoadPatientDocument(long PatientId)
    {
        PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

        DataSet dsPatientDocuments = objPatientDocumentDB.FilterPatientDocuments(PatientId, "", "", "", 10, 0, "", "", "");

        rptPatientDocuments.DataSource = dsPatientDocuments.Tables[0];
        rptPatientDocuments.DataBind();

        hdnTotalDocRows.Value = dsPatientDocuments.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}