using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_PatientDocument_CallBacks_PatientDocumentForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        hdnUserName.Value = Profile.LastName + ", " + Profile.FirstName;
        txtPatientDocumentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
        LoadDDLs();

        long DocumentId = long.Parse(Request.Form["DocumentId"]);
        hdnPatientDocumentId.Value = DocumentId.ToString();

        if (DocumentId > 0)
        {
            PatientDocumentDB objPatientDocumentDB = new PatientDocumentDB();

            DataSet dsDocument = objPatientDocumentDB.GetByID(DocumentId);

            DataTable dtDocument = dsDocument.Tables[0];

            if (dtDocument.Rows.Count > 0)
            {
                txtDocumentName.Text = dtDocument.Rows[0]["DocumentName"].ToString();
                ddlPatientDocumentType.SelectedValue = dtDocument.Rows[0]["CategoryId"].ToString();
                txtPatientDocumentDate.Text = dtDocument.Rows[0]["DocumentDate"].ToString();
                chkPatientDocumentIsConfedential.Checked = bool.Parse(dtDocument.Rows[0]["IsConfedential"].ToString());
                txtPatientDocumentComments.Text = dtDocument.Rows[0]["Comments"].ToString();
                ddlPatientDocumentPracticeUsers.SelectedValue = dtDocument.Rows[0]["AssignedTo"].ToString();
            }

            rptDocumentAttachments.DataSource = dsDocument.Tables[1];
            rptDocumentAttachments.DataBind();
        }
    }

    public void LoadDDLs()
    {
        long PracticeId = Convert.ToInt64(Profile.PracticeId);
        long ServiceProviderId = Profile.ServiceProviderId;

        PracticeStaffDB objPracticeStaffDB = new PracticeStaffDB();
        ddlPatientDocumentPracticeUsers.DataSource = objPracticeStaffDB.GetProvidersByPracticeLocation(Profile.PracticeLocationsId);
        ddlPatientDocumentPracticeUsers.DataTextField = "Name";
        ddlPatientDocumentPracticeUsers.DataValueField = "PracticeStaffId";
        ddlPatientDocumentPracticeUsers.DataBind();
        ddlPatientDocumentPracticeUsers.Items.Insert(0, new ListItem("", "0"));

        ListItem item = ddlPatientDocumentPracticeUsers.Items.FindByValue(Profile.ServiceProviderId.ToString());
        if (item != null)
        {
            spnAssignMeDoc.Visible = true;
            hdnLoggedProvideId.Value = ServiceProviderId.ToString();
        }
        else
        {
            spnAssignMeDoc.Visible = false;
        }

        DocumentCategory objDocumentCategory = new DocumentCategory();

        ddlPatientDocumentType.DataSource = objDocumentCategory.DocumentCategory_GetByPracticeId(PracticeId);
        ddlPatientDocumentType.DataTextField = "Name";
        ddlPatientDocumentType.DataValueField = "CategoryId";
        ddlPatientDocumentType.DataBind();
    }

    protected void rptDocumentAttachments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = e.Item.DataItem as DataRowView;
    }
}