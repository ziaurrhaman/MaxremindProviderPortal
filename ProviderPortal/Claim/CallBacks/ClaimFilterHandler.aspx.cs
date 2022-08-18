using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillingManager_Claim_CallBacks_ClaimFilterHandler : System.Web.UI.Page
{
    DataSet dsPTLReasons = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        string ClaimId = Request.Form["ClaimId"];
        string PatientId = Request.Form["PatientId"];
        string PatientName = Request.Form["PatientName"];
        string DateOfService = Request.Form["DateOfService"];
        string BillDate = Request.Form["BillDate"];
        string InsuranceId = Request.Form["InsuranceId"];
        string SubmissionStatusId = Request.Form["SubmissionStatusId"];

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();
        dsPTLReasons = objPTLReasonsDB.GetAllPTLReasons(Profile.PracticeId);

        bool IsPTL = bool.Parse(Request.Form["IsPTL"]);
        string PTLReasons = Request.Form["PTLReasons"];
        /**********EDITED BY SHAHID KAZMI 1/22/2018*******/
        string SortBy = "";
        string MRN = "";
       // string PTLReasons = "";
        string Location = "";
        string billedas = "";
        string charge = "";
        string balanceDue = Request.Form["AmountDue"];
        string AmountPaid = Request.Form["AmountPaid"];
        /********END SHAHID KAZMI 1/22/2018*********/
        ClaimDB objClaimDB = new ClaimDB();
        /***start***/
        bool? IsImportedDataOnly = false;
        if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
        else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
        else { IsImportedDataOnly = null; }
        /***End***/
        DataSet dsClaims = objClaimDB.GetAllByPractice(Rows, PageNumber, Profile.PracticeId, SortBy, ClaimId, PatientId,  PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, false, PTLReasons, Location, balanceDue, AmountPaid,true,IsImportedDataOnly);
            //(Profile.PracticeId, "",ClaimId, PatientId, PatientName, DateOfService, BillDate, InsuranceId, SubmissionStatusId, Rows, PageNumber, IsPTL, PTLReasons);

        rptClaims.DataSource = dsClaims.Tables[0];
        rptClaims.DataBind();

        hdnClaimsCount.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
    }


    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            string InsuranceId = drv["InsuranceId"].ToString();
            string Name = drv["Name"].ToString();

            Label lblInsuranceName = (Label)e.Item.FindControl("lblInsuranceName");

            if (InsuranceId == "0")
            {
                lblInsuranceName.Text = "Self Pay";
            }
            else
            {
                lblInsuranceName.Text = Name;
            }


            if (!string.IsNullOrEmpty(drv["PTLReasons"].ToString()))
            {
                string[] PTLReasons = drv["PTLReasons"].ToString().Split(',');

                string ReasonText = "";
                for (int i = 0; i < PTLReasons.Length; i++)
                {
                    ReasonText += dsPTLReasons.Tables[1].Select("PTLReasonsId = " + PTLReasons[i])[0]["Reason"].ToString() + ", ";
                }

                Label lblPTLReason = (Label)e.Item.FindControl("lblPTLReason");
                lblPTLReason.Text = ReasonText;

            }


            if (!string.IsNullOrEmpty(drv["IsPTL"].ToString()))
            {
                CheckBox chkPTL = (CheckBox)e.Item.FindControl("chkPTL");
                chkPTL.Checked = bool.Parse(drv["IsPTL"].ToString());
            }
        }
    }
}