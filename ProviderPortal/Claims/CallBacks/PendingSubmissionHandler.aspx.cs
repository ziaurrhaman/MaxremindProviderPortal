using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Configuration;
using System.IO;

public partial class EMR_Claims_CallBacks_PendingSubmissionHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Action"];
        if (action.Equals("Generate File"))
        {
            string insuranceids = Request.Form["insuranceids"];

           
            ClaimsSubmission objClaimsSubmission = new ClaimsSubmission();

            objClaimsSubmission.GenerateEdiFile("", insuranceids.TrimEnd(','));
            string sData = objClaimsSubmission.claimSubmissionFile;
            string sFileName = "Test";

            SaveSubmissionFile(sFileName, sData);

        }
        else
        {
            ClaimDB objClaimDB = new ClaimDB();

            DataSet dsPendingSubmissions = objClaimDB.GetPendingSubmissions(Convert.ToInt64(Profile.PracticeId), int.Parse(Request.Form["Rows"]), int.Parse(Request.Form["PageNumber"]));
            rptPendingSubmissions.DataSource = dsPendingSubmissions.Tables[0];
            rptPendingSubmissions.DataBind();

            ltrlTotalRows.Text = dsPendingSubmissions.Tables[1].Rows[0]["TotalRows"].ToString();
        }
    }

    private void SaveSubmissionFile(string fileName, string fileText)
    {
        string path = "";
        string savepath = "";
        fileName = fileName + ".txt";
        path = ConfigurationManager.AppSettings["PatientPhoto"] + "/SubmissionFiles/" + Profile.PracticeId;
        savepath = HttpContext.Current.Server.MapPath(path);
        if (!Directory.Exists(savepath))
            Directory.CreateDirectory(savepath);

        System.IO.File.WriteAllText(savepath + "/" + fileName, fileText);
    }
}