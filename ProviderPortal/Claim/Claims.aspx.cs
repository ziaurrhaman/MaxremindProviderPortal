using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillingManager_Claims_Claims : System.Web.UI.Page
{
    DataSet dsPTLReasons = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        DataTable dtInsuranceDb = objInsuranceDB.GetAllInsurancesHavingClaims(Profile.PracticeId,"");

        ddlInsurance.DataSource = dtInsuranceDb;
        ddlInsurance.DataTextField = "InsuranceName";
        ddlInsurance.DataValueField = "InsuranceId";
        ddlInsurance.DataBind();
        ddlInsurance.Items.Insert(0, new ListItem("All", ""));
        ddlInsurance.Items.Insert(dtInsuranceDb.Rows.Count + 1, new ListItem("Self Pay", "0"));

        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        ddlSubmissionStatus.DataSource = dtSubmissionStatusCodes;
        ddlSubmissionStatus.DataValueField = "SubmissionStatusId";
        ddlSubmissionStatus.DataTextField = "SubmissionStatus";
        ddlSubmissionStatus.DataBind();
        ddlSubmissionStatus.Items.Insert(0, new ListItem("All", ""));


        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();

        dsPTLReasons = objPTLReasonsDB.GetAllPTLReasons(Profile.PracticeId);

        rptPTLReasons.DataSource = dsPTLReasons.Tables[1];
        rptPTLReasons.DataBind();

        ClaimDB objClaimDB = new ClaimDB();

        DataSet dsClaims = objClaimDB.GetAllByPractice(10, 0, Profile.PracticeId, "", "", "",  "", "", "", "", "", false, "", "",  "", "",false,null);
            //GetAllByPractice(Profile.PracticeId, "","", "", "", "", "", "", "", 10, 0);

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
                    ReasonText += dsPTLReasons.Tables[1].Select("PTLReasonsId = " + PTLReasons[i])[0]["Reason"].ToString();
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