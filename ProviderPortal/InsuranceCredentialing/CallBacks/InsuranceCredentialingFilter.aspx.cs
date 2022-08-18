using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_InsuranceCredentialing_InsuranceCredentialingFilter : System.Web.UI.Page
{
    long PracticeDocumentsId = 0;
    long FileDocumentAttachmentsId = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        //Sjaid testing 
        var action = "";
        InsuranceCredentialing cs = new InsuranceCredentialing();
        InsuranceCredentialingDB db = new InsuranceCredentialingDB();
        if (!string.IsNullOrEmpty(Request.Form["Action"]))
        {
            action = Request.Form["Action"].ToString();
        }
        if (action == "Add")
        {
            AddDocument();
            cs.PracticeId = Profile.PracticeId;
            cs.InsuranceId = Convert.ToInt32(Request.Form["InsuranceId"].ToString());
            //cs.GroupCode = Request.Form["GroupCode"].ToString();
            //cs.GroupCodeDescription = Request.Form["GroupCodeDesc"].ToString();
            //cs.IndividualCode = Request.Form["individualCode"].ToString();
            //cs.IndividualCodeDescription = Request.Form["individualCodeDesc"].ToString();
            //cs.IndividualCode1 = Request.Form["individualCode1"].ToString();
            //cs.IndividualCodeDescription1 = Request.Form["individualCodeDesc1"].ToString();            
            cs.CreatedById = Convert.ToInt32(Profile.UserId);
            cs.CreatedDate = DateTime.Now;
            cs.Status = Request.Form["Status"].ToString();
            //cs.Notes = Request.Form["Notes"].ToString();
            cs.PracticeDocumentsId = Convert.ToInt32(FileDocumentAttachmentsId);
            cs.ProviderId = Convert.ToInt64(Request.Form["ddlProvider"].ToString());
            cs.Source = Request.Form["Source"].ToString();
            cs.NPI = Convert.ToInt64(Request.Form["NPI"].ToString());
            cs.TaxId = Convert.ToInt64(Request.Form["TAX"].ToString());
            cs.TargetDate = Convert.ToDateTime(Request.Form["TargetDate"].ToString());
            cs.GroupId = Request.Form["GroupId"].ToString();
            cs.ProviderPTAN = Request.Form["ProviderPTAN"].ToString();
            cs.SSN = Request.Form["SSN"].ToString();
            cs.Remarks = Request.Form["Remarks"].ToString();

            db.Add(cs);
            InsuranceCredentialingGrid();
        }

        else if (action == "Edit")
        {

            int documentid = Convert.ToInt32(Request.Form["documentid"].ToString());
            if (documentid == 0)
            {
                AddDocument();

            }
            else
            {
                FileDocumentAttachmentsId = documentid;
                UpdateDocument();

            }
            string groupid = "";
            string ProviderPTAN = "";
            if (!string.IsNullOrEmpty(Request.Form["GroupId"]))
                groupid = Request.Form["GroupId"].ToString();
            if (!string.IsNullOrEmpty(Request.Form["ProviderPTAN"]))
                ProviderPTAN = Request.Form["ProviderPTAN"].ToString();
            cs.PracticeDocumentsId = Convert.ToInt32(FileDocumentAttachmentsId);
            cs.InsuranceCredentialingID = Convert.ToInt32(Request.Form["InsuCredentialId"].ToString());
            cs.PracticeId = Profile.PracticeId;
            cs.InsuranceId = Convert.ToInt32(Request.Form["InsuranceId"].ToString());
            //cs.GroupCode = Request.Form["GroupCode"].ToString();
            //cs.GroupCodeDescription = Request.Form["GroupCodeDesc"].ToString();
            //cs.IndividualCode = Request.Form["individualCode"].ToString();
            //cs.IndividualCodeDescription = Request.Form["individualCodeDesc"].ToString();
            //cs.IndividualCode1 = Request.Form["individualCode1"].ToString();
            //cs.IndividualCodeDescription1 = Request.Form["individualCodeDesc1"].ToString();
            cs.ModifiedById = Convert.ToInt32(Profile.UserId);
            cs.ModifiedDate = DateTime.Now;
            cs.Status = Request.Form["Status"].ToString();
            //cs.Notes = Request.Form["Notes"].ToString();
            cs.PracticeDocumentsId = Convert.ToInt32(FileDocumentAttachmentsId);
            cs.ProviderId = Convert.ToInt64(Request.Form["ddlProvider"].ToString());
            cs.Source = Request.Form["Source"].ToString();
            cs.NPI = Convert.ToInt64(Request.Form["NPI"].ToString());
            cs.TaxId = Convert.ToInt64(Request.Form["TAX"].ToString());
            cs.TargetDate = Convert.ToDateTime(Request.Form["TargetDate"].ToString());
            cs.GroupId = groupid;
            cs.ProviderPTAN = ProviderPTAN;
            cs.Remarks = Request.Form["Remarks"].ToString();
            cs.SSN = Request.Form["SSN"].ToString();
            db.Update(cs);
            InsuranceCredentialingGrid();
        }
        else if (action == "Delete")
        {

            cs.InsuranceCredentialingID = Convert.ToInt32(Request.Form["InsuCredentialId"].ToString());

            cs.ModifiedById = Convert.ToInt32(Profile.UserId);
            cs.ModifiedDate = DateTime.Now;

            db.Delete(cs);
            InsuranceCredentialingGrid();
        }

        else if (action == "FilterGrid")
        {
            InsuranceCredentialingFilter();
        }
        else if (action == "InsuranceSearch")
        {
            insuranceGrid();

        }
        else if (action == "loadNpiTax")
        {
            GetNpiTax();
        }

    }

    protected void insuranceGrid()
    {
        InsuranceDB db = new InsuranceDB();
        DataSet ds = new DataSet();
        string InsuranceName = Request.Form["InsuranceName"].ToString();
        ds = db.GetInsurances(Profile.PracticeId, 10, 0, "", InsuranceName);
        rptInsuranceFilter.DataSource = ds.Tables[0];
        rptInsuranceFilter.DataBind();
    }

    protected void InsuranceCredentialingGrid()
    {
        InsuranceCredentialingDB db = new InsuranceCredentialingDB();
        DataSet ds = db.GetAllFilter(Profile.PracticeId, 10, 0, "insurancecredentialingid DESC", "", "", "", "", "", "", 0, 0, null, null, "");
        rptInsuranceCredentialing.DataSource = ds.Tables[0];
        rptInsuranceCredentialing.DataBind();
        hdnTotalRowsInsuranceCredentialingGrid.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void InsuranceCredentialingFilter()
    {
        InsuranceCredentialingDB db = new InsuranceCredentialingDB();
        int Nip = 0;
        int TaxId = 0;
        DateTime? EffectiveDate = null;
        DateTime? StartDate = null;
        int PageNumber = Convert.ToInt32(Request.Form["PageNumber"].ToString());
        int Rows = Convert.ToInt32(Request.Form["Rows"].ToString());

        string InsuranceName = Request.Form["InsuranceName"].ToString();
        string Source = Request.Form["Source"].ToString();
        if (!string.IsNullOrEmpty(Request.Form["NIP"].ToString()))
            Nip = Convert.ToInt32(Request.Form["NIP"].ToString());
        if (!string.IsNullOrEmpty(Request.Form["TaxId"].ToString()))
            TaxId = Convert.ToInt32(Request.Form["TaxId"].ToString());
        string Provider = Request.Form["Provider"].ToString();
        if (!string.IsNullOrEmpty(Request.Form["StartDate"]))
            StartDate = Convert.ToDateTime(Request.Form["StartDate"].ToString());
        if (!string.IsNullOrEmpty(Request.Form["EffectiveDate"]))
            EffectiveDate = Convert.ToDateTime(Request.Form["EffectiveDate"].ToString());
        string GroupId = Request.Form["GroupId"].ToString();
        string Remarks = Request.Form["Remarks"].ToString();
        string Status = Request.Form["Status"].ToString();
        string ProviderPTAN = Request.Form["ProviderPTAN"].ToString();

        DataSet ds = db.GetAllFilter(Profile.PracticeId, Rows, PageNumber, "insurancecredentialingid DESC", InsuranceName, Status, Source, Provider, GroupId, Remarks, Nip, TaxId, EffectiveDate, StartDate, ProviderPTAN);
        rptInsuranceCredentialing.DataSource = ds.Tables[0];
        rptInsuranceCredentialing.DataBind();
        hdnTotalRowsInsuranceCredentialingGrid.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }


    protected void AddDocument()
    {
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        List<FileDocumentAttachments> listFileDocumentAttachments = serializer1.Deserialize<List<FileDocumentAttachments>>(Request.Form["listPatientDocumentAttachments"]);
        if (listFileDocumentAttachments.Count > 0)
        {
            PracticeDocuments upload = new PracticeDocuments();
            string DocumentName = Request.Form["DocumentName"].ToString();
            string DocumentUploadedName = Request.Form["DocumentUploadedName"].ToString();

            PracticeDocumentsDB PracticeDocDB = new PracticeDocumentsDB();
            upload.DocumentName = DocumentName;
            upload.DocumentDate = DateTime.Now;
            upload.PracticeDocumentsCatagoriesId = 0;
            upload.DocumentUploadedName = DocumentUploadedName;
            upload.CreatedById = Profile.UserId;
            upload.CreatedDate = DateTime.Now;
            upload.PracticeId = Profile.PracticeId;
            upload.DocumentType = "Practice Document";
            PracticeDocumentsId = PracticeDocDB.Add(upload);

            FileDocumentAttachmentsDB fileDocumentAttachmentsDB = new FileDocumentAttachmentsDB();


            foreach (FileDocumentAttachments fileDocumentAttachments in listFileDocumentAttachments)
            {
                fileDocumentAttachments.DocumentId = PracticeDocumentsId;

                fileDocumentAttachments.CreatedById = Profile.UserId;
                fileDocumentAttachments.CreatedDate = DateTime.Now;

                FileDocumentAttachmentsId = fileDocumentAttachmentsDB.Add(fileDocumentAttachments);
            }

        }

    }


    protected void UpdateDocument()
    {
        JavaScriptSerializer serializer1 = new JavaScriptSerializer();
        PracticeDocuments upload = new PracticeDocuments();
        string DocumentName = Request.Form["DocumentName"].ToString();
        string DocumentUploadedName = Request.Form["DocumentUploadedName"].ToString();
        //Added By Syed Sajid Ali
        InsuranceCredentialingDB insuranceCredentialingDB = new InsuranceCredentialingDB();
        FileDocumentAttachments file_DocumentAttachments = new FileDocumentAttachments();
        if (DocumentUploadedName == "" || DocumentUploadedName == null)
        {
            file_DocumentAttachments.FileDocumentAttachmentsId = Convert.ToInt32(Request.Form["FileDocumentAttachmentsId"]);
            file_DocumentAttachments.Deleted = true;
            file_DocumentAttachments.ModifiedById = Profile.UserId;
            file_DocumentAttachments.ModifiedDate = DateTime.Now;
            insuranceCredentialingDB.Delete(file_DocumentAttachments);
        }
        else
        {
            file_DocumentAttachments.FileDocumentAttachmentsId = Convert.ToInt32(Request.Form["FileDocumentAttachmentsId"]);
            file_DocumentAttachments.Deleted = false;
            file_DocumentAttachments.ModifiedById = Profile.UserId;
            file_DocumentAttachments.ModifiedDate = DateTime.Now;
            insuranceCredentialingDB.Delete(file_DocumentAttachments);
        }
        //End by Syed Sajid Ali
        PracticeDocumentsDB PracticeDocDB = new PracticeDocumentsDB();
        upload.PracticeDocumentsId = Convert.ToInt32(Request.Form["documentid"].ToString());
        upload.DocumentName = DocumentName;
        upload.DocumentDate = DateTime.Now;
        upload.PracticeDocumentsCatagoriesId = 0;
        upload.DocumentUploadedName = DocumentUploadedName;
        upload.ModifiedById = Profile.UserId;
        upload.ModifiedDate = DateTime.Now;
        upload.PracticeId = Profile.PracticeId;
        upload.DocumentType = "Practice Document";
        //Comment

        List<FileDocumentAttachments> listFileDocumentAttachments = serializer1.Deserialize<List<FileDocumentAttachments>>(Request.Form["listPatientDocumentAttachments"]);

        FileDocumentAttachmentsDB fileDocumentAttachmentsDB = new FileDocumentAttachmentsDB();

        foreach (FileDocumentAttachments fileDocumentAttachments in listFileDocumentAttachments)
        {
            fileDocumentAttachments.FileDocumentAttachmentsId = Convert.ToInt32(Request.Form["FileDocumentAttachmentsId"]);
            fileDocumentAttachments.DocumentId = PracticeDocumentsId;

            fileDocumentAttachments.ModifiedById = Profile.UserId;
            fileDocumentAttachments.ModifiedDate = DateTime.Now;

            fileDocumentAttachmentsDB.Update(fileDocumentAttachments);

        }


    }
    public void GetNpiTax()
    {
        InsuranceCredentialingDB db = new InsuranceCredentialingDB();

        string Source = Request.Form["Source"].ToString();
        long ProviderId = Convert.ToInt64(Request.Form["ProviderId"].ToString());
        DataTable dt = db.GetNipTaxId(Profile.PracticeId, Source, ProviderId);
        NPITXT.Value = dt.Rows[0]["NPI"].ToString();
        TAXTXT.Value = dt.Rows[0]["TaxId"].ToString();
    }
}