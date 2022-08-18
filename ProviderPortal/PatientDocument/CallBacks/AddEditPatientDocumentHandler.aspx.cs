using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientDocument_CallBacks_AddEditPatientDocumentHandler : System.Web.UI.Page
{
    JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();
    PatientDocumentDB objPatientDocumentDB;

    protected void Page_Load(object sender, EventArgs e)
    {
        objPatientDocumentDB = new PatientDocumentDB();

        long PatientId = 0;

        if (Request.Form["PatientId"] != null)
        {
            PatientId = long.Parse(Request.Form["PatientId"]);
        }

        if (Request.Form["AssignDocument"] != null && Request.Form["AssignDocument"].ToString() == "true")
        {
            AssignDocument();
            PatientId = 0;
        }
        else
        {
            bool IsEdit = Convert.ToBoolean(Request.Form["Edit"]);
            bool IsDelete = Convert.ToBoolean(Request.Form["Delete"]);

            if (IsDelete)
            {
                Delete();
            }
            else
            {
                PatientDocuments objPatientDocuments = objJavaScriptSerializer.Deserialize<PatientDocuments>(Request.Form["Document"]);

                if (!IsEdit && !IsDelete)
                {
                    Add(objPatientDocuments);
                }
                else if (IsEdit && !IsDelete)
                {
                    Update(objPatientDocuments);
                }
            }
        }

        LoadPatientDocuments(PatientId);
    }

    private void AssignDocument()
    {
        PatientDocuments Document = new PatientDocuments();

        Document.PatientId = int.Parse(Request.Form["PatientId"].ToString());
        Document.DocumentId = int.Parse(Request.Form["DocumentId"].ToString());

        Document.ModifiedById = Convert.ToInt64(Profile.UserId);
        Document.ModifiedDate = DateTime.Now;

        objPatientDocumentDB.AssignDocumentToPatient(Document);
    }

    private void Add(PatientDocuments objPatientDocuments)
    {
        objPatientDocuments.CreatedById = Convert.ToInt64(Profile.UserId);
        objPatientDocuments.CreatedDate = DateTime.Now;

        objPatientDocumentDB.Add(objPatientDocuments);
    }

    private void Update(PatientDocuments objPatientDocuments)
    {
        objPatientDocuments.ModifiedById = Convert.ToInt64(Profile.UserId);
        objPatientDocuments.ModifiedDate = DateTime.Now;

        objPatientDocumentDB.Update(objPatientDocuments);
    }

    private void Delete()
    {
        ArrayList list = objJavaScriptSerializer.Deserialize<ArrayList>(Request.Form["listDocumentId"]);
        PatientDocuments objPatientDoc = new PatientDocuments();

        for (int i = 0; i < list.Count; i++)
        {
            objPatientDoc.DocumentId = long.Parse(list[i].ToString());

            objPatientDoc.ModifiedById = Profile.UserId;
            objPatientDoc.ModifiedDate = DateTime.Now;

            objPatientDocumentDB.Delete(objPatientDoc);
        }
    }

    private void LoadPatientDocuments(long PatientId)
    {
        PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

        DataSet dsPatientDocuments = objPatientDocumentDB.FilterPatientDocuments(PatientId, "", "", "", 10, 0, "", "", "");

        rptPatientDocuments.DataSource = dsPatientDocuments.Tables[0];
        rptPatientDocuments.DataBind();

        ltrlPatientDocumentsRowsCount.Text = dsPatientDocuments.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}