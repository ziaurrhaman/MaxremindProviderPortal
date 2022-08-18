using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class HomeHealth_EpisodeClaims_ApplyEOBPayments : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["InsuranceId"] == null || Request.QueryString["ERAMasterId"] == null)
        {
            return;
        }

        Int64 insuranceId = Convert.ToInt64(Request.QueryString["InsuranceId"]);
        Int64 ERAMasterId = Convert.ToInt64(Request.QueryString["ERAMasterId"]);
        hdnPayerId.Value = insuranceId.ToString();

        ERAMasterDB objERAMasterDb = new ERAMasterDB();
        DataTable ddtERAMaster = objERAMasterDb.ERAMaster_GetByERAMasterId(ERAMasterId);

        lblCheckAmount.Text = string.Format("{0:c}", ddtERAMaster.Rows[0]["PaymentAmount"]);
        lblCheckNumber.Text = ddtERAMaster.Rows[0]["CheckNumber"].ToString();
        lblInsuranceName.Text = ddtERAMaster.Rows[0]["PayerName"].ToString();
        lblPaymentType.Text = ddtERAMaster.Rows[0]["PaymentType"].ToString();
        lblPostedAmount.Text = string.Format("{0:c}", ddtERAMaster.Rows[0]["PaymentPosted"]);
        decimal remainingBalance = (Convert.ToDecimal(ddtERAMaster.Rows[0]["PaymentAmount"]) -
                                    Convert.ToDecimal(ddtERAMaster.Rows[0]["PaymentPosted"]));
        lblRemainingBalance.Text = string.Format("{0:c}", remainingBalance);


        hdnCheckIssueDate.Value = ddtERAMaster.Rows[0]["CheckIssueDate"].ToString();
        hdnPaymentMethod.Value = ddtERAMaster.Rows[0]["PaymentType"].ToString();

        hdnCheckNumber.Value = ddtERAMaster.Rows[0]["CheckNumber"].ToString();
        ClaimsDB objClaims = new ClaimsDB();
        ClaimDB objClaim = new ClaimDB();
        DataSet ds = objClaim.Claims_GetByInsuranceId(insuranceId);
        if (ds.Tables[0].Rows.Count == 0)
        {
            divNoClaim.Style["display"] = "block";
            btnApplyPayments.Visible = false;
        }
        rptEpisodeClaims.DataSource = ds;
        rptEpisodeClaims.DataBind();
    }
}
