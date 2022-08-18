using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_UploadFiles_UploadFiles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long practiceId = Profile.PracticeId;
        DataSet dt = new DataSet();
        UploadFilesDB db = new UploadFilesDB();
        dt = db.ShowUploadedFiles(practiceId, 10, 0, "", "", "", "", "", "");
        rptUploadedFiles.DataSource = dt;
        rptUploadedFiles.DataBind();

        hdnTotalRows.Value = dt.Tables[1].Rows[0]["TotalRows"].ToString();

    }
}