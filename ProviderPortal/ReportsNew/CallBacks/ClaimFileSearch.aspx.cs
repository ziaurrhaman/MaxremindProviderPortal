using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_ClaimFileSearch : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string filename = Request.Form["FileName"].ToString();
        int PracticeId = 0;
        if (Request.Form["PracticeId"] != null)
        {
            PracticeId = Convert.ToInt32(Request.Form["PracticeId"]);
        }
        else
        {
            PracticeId = Convert.ToInt32(Profile.PracticeId);
        }
       
        UploadFilesDB uploadFileDB = new UploadFilesDB();
        DataTable dt= uploadFileDB.GetFilesOfClaim(PracticeId, filename);
        rptFileSearch.DataSource = dt;
        rptFileSearch.DataBind();

    }
}