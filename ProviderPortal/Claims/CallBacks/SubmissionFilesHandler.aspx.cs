using System;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class HomeHealth_EpisodeClaims_CallBacks_SubmissionFilesHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["Action"];
        var objSubmissionFilesDb = new SubmissionFilesDB();
        if (action.Equals("Download"))
        {
            string fileId = Request.Form["FileId"];
            objSubmissionFilesDb.ChangeFileStatus(Int64.Parse(fileId), Profile.UserId);
        }
        Int32 rows = Int32.Parse(Request.Form["Rows"]);
        Int32 pageNo = Int32.Parse(Request.Form["PageNumber"]);

        string FileName = Request.Form["FileName"];
        string CreatedDate = Request.Form["CreatedDate"];

        var dsSubmissionFiles = objSubmissionFilesDb.GetSubmissionFiles(Convert.ToInt64(Profile.PracticeId), rows, pageNo, FileName, CreatedDate);
        rptSubmissionFiles.DataSource = dsSubmissionFiles.Tables[0];
        rptSubmissionFiles.DataBind();
        hdnSubmissionFilesCount.Value = dsSubmissionFiles.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptSubmissionFiles_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var lblFileStatus = (Label)e.Item.FindControl("lblFileStatus");
            var attachment = (Literal)e.Item.FindControl("ltrlAttachment");
            var drv = (DataRowView)e.Item.DataItem;

            if (lblFileStatus.Text.ToLower() == "downloaded")
            {
                lblFileStatus.Style.Add(HtmlTextWriterStyle.Color, "Green");
                lblFileStatus.Style.Add(HtmlTextWriterStyle.FontWeight, "Bold");                
            }
            attachment.Text = "<span class='iconAttachment' onclick=\"downloadSubmissionFile('" +
                              ResolveUrl("~/PracticeDocuments/SubmissionFiles/" + Profile.PracticeId + "/" +
                                         drv["FileName"].ToString() + ".txt") + "','" + drv["FileName"].ToString() + "','" + drv["SubmissionFileId"].ToString() + "')\"></span>";

        }
    }
   
}