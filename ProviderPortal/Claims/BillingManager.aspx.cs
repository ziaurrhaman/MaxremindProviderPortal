using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;


public partial class EMR_Claims_BillingManager : System.Web.UI.Page
{
    string _text = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        LoadClaims();
       BindDlls();
        LoadProvider();
        if (!IsPostBack)
        {   
            //Added by Khayyam Adeel as per task reuirement dated 8/10/2021;
            
            spnClaimSection.Visible=(Profile.PracticeId == 1026 && Profile.PracticeId == 1001) ? false : spnClaimSection.Visible = false;
        }

    }
    /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter
    public void LoadProvider()
    {
        string PracticeLocationId = Request.Form["PracticeLocationId"];
        ReportsDB db = new ReportsDB();
        DataTable ds = db.GetProvidersByDefault(Profile.PracticeId);
        rptProviders.DataSource = ds;
        rptProviders.DataBind();
    }
    /// End Modified By Irfan Mahmood 9/August/2022 : Add Provider Filter
    private void LoadClaims()
    {
        string statusid = "";
        bool IsFilter = false;
        bool isRPM = false;

        //if (!string.IsNullOrEmpty(Request.QueryString["status"]))
        //{
        //    //statusid = Request.QueryString["RPM"].ToString();
        //    statusid = Request.QueryString["status"].ToString();

        //    IsFilter = true;

        //}
        if (!string.IsNullOrEmpty(Request.QueryString["RPM"]))
        {
            //statusid = Request.QueryString["RPM"].ToString();
            string a = Request.QueryString["RPM"].ToString();
            isRPM=(a == "1")? true : false;

            IsFilter = true;
            
        }

        ClaimDB objClaimDB = new ClaimDB();
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        if (Session["SpecificView"] != null)
        {
            string UserId = Profile.UserId.ToString();
            string Location = Profile.PracticeState;
            DataSet dsClaims = objClaimDB.GetClaims_AllByUserId(10, 0, Profile.PracticeId, "Claim No DESC", Convert.ToInt32(UserId), "", "", "", "", "", "", statusid, false, "", "", "", IsFilter, IsImportedDataOnly,null);
            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
            hdnClaimsCount.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
            hdnRows.Value= dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
            rptLocation.DataSource = dsClaims.Tables[2];
            rptLocation.DataBind();
        }
        else
        {
            string Location = Profile.PracticeState;
            DataSet dsClaims = objClaimDB.GetAllByPractice(10, 0, Profile.PracticeId, "Claim No DESC", "",  "", "", "", "", "", statusid, false, "", "","", "", IsFilter, IsImportedDataOnly,null, isRPM);
            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
            hdnClaimsCount.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
            hdnRows.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
            rptLocation.DataSource = dsClaims.Tables[2];
            rptLocation.DataBind();
        }

    }

    private void BindDlls()
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();
        ddlSubmissionStatus.DataSource = dtSubmissionStatusCodes;
        ddlSubmissionStatus.DataValueField = "SubmissionStatusId";
        ddlSubmissionStatus.DataTextField = "SubmissionStatus";
        ddlSubmissionStatus.DataBind();
        ddlSubmissionStatus.Items.Insert(0, new System.Web.UI.WebControls.ListItem("", ""));
      
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("100"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("200"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("201"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("202"));
        ddlSubmissionStatus.Items.Remove(ddlSubmissionStatus.Items.FindByValue("203"));
        ddlSubmissionStatus.Items.Insert(1, new System.Web.UI.WebControls.ListItem("InProcess", "100"));
        if (!string.IsNullOrEmpty(Request.QueryString["status"]))
        {

            ddlSubmissionStatus.SelectedValue = "206";
        }

    }

    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["Name"].ToString();
            Label lblstatus = (Label)e.Item.FindControl("lblstatus");
               lblstatus.Text = drv["SubmissionStatus"].ToString();
            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");

            if (Name == "")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }
            
        }

    }
    public void ExportToExcel(object sender, EventArgs e)
    {

        string ClaimIds = hdnClaimIds.Value;
        int Rows = int.Parse(hdnRows.Value);
        string LocationIds = hdnLocationIds.Value;
        string ProviderId = hdnProviderId.Value;
        if (LocationIds == "") { LocationIds = null; }
        ClaimDB objClaimDB = new ClaimDB();
        DataSet dsClaims;
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        if (ClaimIds != "")
        {
            if (Session["SpecificView"] != null)
            {
                string UserId = Profile.UserId.ToString();
                dsClaims = objClaimDB.GetClaims_AllByUserId(Rows, 0, Profile.PracticeId, "", Convert.ToInt32(UserId), ClaimIds, "", "", "", "", "", "", false, "", "", "", true, IsImportedDataOnly, LocationIds); 
            }
            else
            {
                dsClaims = objClaimDB.GetAllByPractice(Rows, 0, Profile.PracticeId, "", ClaimIds, "", "",  "", "", "", "", false, "", "", "", "", true, IsImportedDataOnly, LocationIds);
               
            }

            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
        }
        else 
        {
            if (Session["SpecificView"] != null)
            {
                string UserId = Profile.UserId.ToString();
                dsClaims = objClaimDB.GetClaims_AllByUserId(Rows, 0, Profile.PracticeId, "", Convert.ToInt32(UserId), ClaimIds, "", "", "",  "", "", "", false, "", "", "",true, IsImportedDataOnly, LocationIds);
             
            }

            else
            {
                dsClaims = objClaimDB.GetAllByPractice(Rows, 0, Profile.PracticeId, "", "", ClaimIds, "", "", "", "",  "", false, "", "", "", "",true, IsImportedDataOnly, LocationIds);
                
            }

            var count = dsClaims.Tables[0].Rows.Count;
            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
        }
        for (int i = 0; i < rptClaims.Items.Count; i++)
        {
            HtmlTableCell tdchk = (HtmlTableCell)rptClaims.Items[i].FindControl("tdchk");
            HtmlTableCell tdPrint = (HtmlTableCell)rptClaims.Items[i].FindControl("tdPrint");
            tdchk.Style.Add("display", "none");
            tdPrint.Style.Add("display", "none");
            tdchk.InnerHtml = "";
            tdPrint.InnerText = "";
        }
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Claims.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Write("<table border='1'>");
        Response.Write("<tr>");
        Response.Write("<th>");
        Response.Write("Row N0");
        Response.Write("</th>");
        Response.Write("<th style='width:0.1px;'>");
        Response.Write("");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Claim No");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Account No");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Patient Name");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("DOS");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Bill Date");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Location");
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column In Excel
        Response.Write("<th>");
        Response.Write("Attending Physician");
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column In Excel
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Primary Insurance");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Status");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Paid Amount");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Balance Due");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Charges");
        Response.Write("</th>");
        Response.Write("<th style='width:0.1px;'>");
        Response.Write("");
        Response.Write("</th>");
        Response.Write("</tr>");
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptClaims.RenderControl(hw);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.Write("</table>");
        //Response.End();
        Response.SuppressContent = true; 

    }
    public void ExportToPDF(object sender, EventArgs e)
    {
        string ClaimIds = hdnClaimIds.Value;
        int Rows = int.Parse(hdnClaimsCount.Value);
        string LocationIds = hdnLocationIds.Value;
        if (LocationIds == "") { LocationIds = null; }
        ClaimDB objClaimDB = new ClaimDB();
        DataSet dsClaims;
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        if (ClaimIds != "")
        {
            if (Session["SpecificView"] != null)
            {
                string UserId = Profile.UserId.ToString();
                dsClaims = objClaimDB.GetClaims_AllByUserId(Rows, 0, Profile.PracticeId, "", Convert.ToInt32(UserId), ClaimIds, "", "", "", "", "", "", false, "", "", "", false,IsImportedDataOnly, LocationIds);
            }

            else
            {
                dsClaims = objClaimDB.GetAllByPractice(Rows, 0, Profile.PracticeId, "", ClaimIds, "", "", "", "", "", "", false, "", "", "", "",false,IsImportedDataOnly, LocationIds);
            }

            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
        }
        else
        {
            if (Session["SpecificView"] != null)
            {
                string UserId = Profile.UserId.ToString();
                dsClaims = objClaimDB.GetClaims_AllByUserId(Rows, 0, Profile.PracticeId, "", Convert.ToInt32(UserId), "", "", "", "",  "", "", "", false, "", "", "", false, IsImportedDataOnly, LocationIds);
            }

            else
            {
                dsClaims = objClaimDB.GetAllByPractice(Rows, 0, Profile.PracticeId, "", "", "", "", "", "", "", "", false, "", "", "", "",false, IsImportedDataOnly, LocationIds);
            }

            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
        }

        for (int i = 0; i < rptClaims.Items.Count; i++)
        {
            HtmlTableCell tdchk = (HtmlTableCell)rptClaims.Items[i].FindControl("tdchk");
            HtmlTableCell tdPrint = (HtmlTableCell)rptClaims.Items[i].FindControl("tdPrint");
            tdchk.Style.Add("display", "none");
            tdPrint.Style.Add("display", "none");
            tdchk.InnerHtml = "";
            tdPrint.InnerText = "";
        }
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=Claim.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write("<table border='0.1'>");
        Response.Write("<tr>");
        Response.Write("<th>");
        Response.Write("Row N0");
        Response.Write("</th>");
        Response.Write("<th style='width:1px;'>");
        Response.Write("");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Claim No");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Account No");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Patient Name");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("DOS");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Bill Date");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Location");
        Response.Write("</th>");
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column In PDF
        Response.Write("<th>");
        Response.Write("Attending Physician");
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column In PDF
        Response.Write("<th>");
        Response.Write("Primary Insurance");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Status");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Paid Amount");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Balance Due");
        Response.Write("</th>");
        Response.Write("<th style='width:0.1px;'>");
        Response.Write("");
        Response.Write("</th>");
        Response.Write("</tr>");
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        rptClaims.DataBind();
        rptClaims.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.Write("</table>");
        // Response.End();
        Response.SuppressContent = true; 

    }
    public void ExportToWord(object sender, EventArgs e)
    {
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        string ClaimIds = hdnClaimIds.Value;
        int Rows = int.Parse(hdnClaimsCount.Value);
        string LocationIds = hdnLocationIds.Value;
        if (LocationIds == "") { LocationIds = null; }
        ClaimDB objClaimDB = new ClaimDB();
        DataSet dsClaims;
        if (ClaimIds != "")
        {
            if (Session["SpecificView"] != null)
            {
                string UserId = Profile.UserId.ToString();
                dsClaims = objClaimDB.GetClaims_AllByUserId(Rows, 0, Profile.PracticeId, "", Convert.ToInt32(UserId), ClaimIds, "", "",  "", "", "", "", false, "","", "", false, IsImportedDataOnly, LocationIds);
             }

            else
            {
                dsClaims = objClaimDB.GetAllByPractice(Rows, 0, Profile.PracticeId, "", ClaimIds, "", "", "", "", "", "", false, "", "", "", "",false, IsImportedDataOnly, LocationIds);
            }

            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
        }
        else
        {
            if (Session["SpecificView"] != null)
            {
                string UserId = Profile.UserId.ToString();
                dsClaims = objClaimDB.GetClaims_AllByUserId(Rows, 0, Profile.PracticeId, "", Convert.ToInt32(UserId), "", "", "", "",  "", "", "", false, "", "", "", false, IsImportedDataOnly, LocationIds);
            }

            else
            {
                dsClaims = objClaimDB.GetAllByPractice(Rows, 0, Profile.PracticeId, "", "", "", "", "", "", "", "",  false, "", "", "", "",false, IsImportedDataOnly, LocationIds);
            }

            rptClaims.DataSource = dsClaims.Tables[0];
            rptClaims.DataBind();
        }

        for (int i = 0; i < rptClaims.Items.Count; i++)
        {
            HtmlTableCell tdchk = (HtmlTableCell)rptClaims.Items[i].FindControl("tdchk");
            HtmlTableCell tdPrint = (HtmlTableCell)rptClaims.Items[i].FindControl("tdPrint");
            tdchk.Style.Add("display", "none");
            tdPrint.Style.Add("display", "none");
            tdchk.InnerHtml = "";
            tdPrint.InnerText = "";
        }
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=Claim.doc");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.word";
        Response.Write("<table border='1'>");
        Response.Write("<tr>");
        Response.Write("<th>");
        Response.Write("Row N0");
        Response.Write("</th>");
        Response.Write("<th style='width:0.1px;'>");
        Response.Write("");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Claim No");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Account No");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Patient Name");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("DOS");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Bill Date");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Location");
        Response.Write("</th>");
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column In Word
        Response.Write("<th>");
        Response.Write("Billing Provider");
        /// Modified By Irfan Mahmood 9/August/2022 : Add Provider Column In Word
        Response.Write("<th>");
        Response.Write("Primary Insurance");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Status");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Paid Amount");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Balance Due");
        Response.Write("</th>");
        Response.Write("<th>");
        Response.Write("Charges");
        Response.Write("</th>");
        Response.Write("<th style='width:0.1px;'>");
        Response.Write("");
        Response.Write("</th>");
        Response.Write("</tr>");
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        rptClaims.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.Write("</table>");
        Response.End();
        //Response.SuppressContent = true; 
    }
    protected void ddlExportTo_SelectedIndexChanged(object sender, EventArgs e)
    {
        Utility obj = new Utility();
        string exportTo = ddlExportTo.SelectedValue;
        string FileName = "Patient Claims";
        if (exportTo == "Excel")
        {
            ExportToExcel(sender, e);
        }
        else if (exportTo == "Word")
        {
            ExportToWord(sender, e);
        }
    }
}