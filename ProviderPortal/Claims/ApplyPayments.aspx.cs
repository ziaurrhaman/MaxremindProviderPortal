using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomeHealth_EpisodeClaims_ApplyPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["InsuranceId"] == null || Request.QueryString["ERAMasterId"] == null)
        {
            return;

        }

        Int64 insuranceId = Convert.ToInt64(Request.QueryString["InsuranceId"]);
        Int64 ERAMasterId = Convert.ToInt64(Request.QueryString["ERAMasterId"]);
        
        ClaimDB objClaimDb = new ClaimDB();
        
        DataSet dsClaims = objClaimDb.Claims_GetByInsuranceId(insuranceId);

        rptClaims.DataSource = dsClaims.Tables[0];
        rptClaims.DataBind();
        hdnPayerId.Value = insuranceId.ToString();

        ERAMasterDB objERAMasterDb = new ERAMasterDB();
        DataTable ddtERAMaster = objERAMasterDb.ERAMaster_GetByERAMasterId(ERAMasterId);
        lblTotalAmount.Text = ddtERAMaster.Rows[0]["PaymentAmount"].ToString();

        hdnCheckIssueDate.Value = ddtERAMaster.Rows[0]["CheckIssueDate"].ToString();
        hdnPaymentMethod.Value = ddtERAMaster.Rows[0]["PaymentType"].ToString();

        hdnCheckNumber.Value = ddtERAMaster.Rows[0]["CheckNumber"].ToString();
        ClaimsDB objClaims = new ClaimsDB();
   
        if (dsClaims.Tables[0].Rows.Count == 0)
        {
            divbtnPayments.Style["display"] = "none";
            tblSearch.Style["display"] = "none";
            divNoClaim.Style["display"] = "block";
            tblTotalAmount.Style["display"] = "none";
        }
     

    }
    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        ClaimChargesDB objClaimCharges = new ClaimChargesDB();
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView) e.Item.DataItem;
            Int64 ClaimId = Convert.ToInt64(drv["ClaimId"]);
            Repeater rptClaimCharges = (Repeater)e.Item.FindControl("rptClaimCharges");
            rptClaimCharges.DataSource = objClaimCharges.ClaimCharges_GetByClaimId(ClaimId);
            rptClaimCharges.DataBind();

        }
    }
}