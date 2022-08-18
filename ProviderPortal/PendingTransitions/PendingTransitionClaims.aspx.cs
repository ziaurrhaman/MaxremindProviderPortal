 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_PendingTransitions_PendingTransitionClaims : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadClaims();
        BindDlls();
        GetAllPTLReasons();
    }


    private void LoadClaims()
    {
        ClaimDB objClaimDB = new ClaimDB();

        ///DataSet dsClaims = objClaimDB.GetAllByPractice(10, 0, Profile.PracticeId, "", "", "", "", "", "", "", "", true, "", "", "", "");
        DataSet dsClaims = objClaimDB.ShowPTlOfclaim(Profile.PracticeId, 10, 0,null,null,null,null,null,null,null,null);

        rptClaims.DataSource = dsClaims.Tables[0];
        rptClaims.DataBind();

        hdnTotalRowsClaim.Value = dsClaims.Tables[1].Rows[0]["TotalRows"].ToString();
    }


    private void BindDlls()
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        DataTable dtInsuranceDb = objInsuranceDB.GetAllInsurances(Profile.PracticeId);

        ddlInsuranceFilterClaim.DataSource = dtInsuranceDb;
        ddlInsuranceFilterClaim.DataTextField = "InsuranceName";
        ddlInsuranceFilterClaim.DataValueField = "InsuranceId";
        ddlInsuranceFilterClaim.DataBind();
        ddlInsuranceFilterClaim.Items.Insert(0, new ListItem("All", ""));
        ddlInsuranceFilterClaim.Items.Insert(dtInsuranceDb.Rows.Count + 1, new ListItem("Self Pay", "0"));

        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        ddlSubmissionStatusFilterClaim.DataSource = dtSubmissionStatusCodes;
        ddlSubmissionStatusFilterClaim.DataValueField = "SubmissionStatusId";
        ddlSubmissionStatusFilterClaim.DataTextField = "SubmissionStatus";
        ddlSubmissionStatusFilterClaim.DataBind();
        ddlSubmissionStatusFilterClaim.Items.Insert(0, new ListItem("All", ""));
    }


    private void GetAllPTLReasons()
    {
        PTLReasonsDB db = new PTLReasonsDB(); 

        DataSet ds = db.GetAllPTLReasons();



        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();

        DataSet dsPTLReasons = objPTLReasonsDB.GetAllPTLReasons();

       

        rptPTLReasonsClaim.DataSource = dsPTLReasons.Tables[1];
        rptPTLReasonsClaim.DataBind();
    }
}