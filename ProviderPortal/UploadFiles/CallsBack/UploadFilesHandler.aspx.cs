using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_UploadFiles_UploadFilesHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
        long practiceId = Profile.PracticeId;
        int Rows = int.Parse(Request.Form["Rows"].ToString());
        int PageNumber = int.Parse(Request.Form["PageNumber"].ToString());
        string CreatedDate = Request.Form["CreatedDate"].ToString();
        string FileName = Request.Form["FileName"].ToString();
        string FileStatus = Request.Form["FileStatus"].ToString();
        string SubmissionMethod = Request.Form["SubmissionMethod"].ToString();
        string Patients = Request.Form["Patients"].ToString();
        string Claims = Request.Form["Claims"].ToString();
       
        DataSet ds = new DataSet();
        UploadFilesDB db = new UploadFilesDB();
        ds = db.ShowUploadedFiles(practiceId, Rows, PageNumber, CreatedDate, FileName, FileStatus, SubmissionMethod, Patients,Claims);
        rptUploadedFiles.DataSource = ds;
        rptUploadedFiles.DataBind();

        ltrlUploadFilesRowsCount.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}