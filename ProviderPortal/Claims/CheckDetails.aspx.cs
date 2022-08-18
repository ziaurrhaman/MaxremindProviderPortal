using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomeHealth_EpisodeClaims_CheckDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ERAMasterId"] == null)
        {
            return;
        }

        Int64 ERAMasterId = Convert.ToInt64(Request.QueryString["ERAMasterId"]);
        ERAClaimPaymentsDB objClaimPaymentsDB = new ERAClaimPaymentsDB();
        DataSet ds = objClaimPaymentsDB.ERAMaster_GetCheckDetails(ERAMasterId);
        hdnERAMasterId.Value = ERAMasterId.ToString();

        lblInsuranceName.Text = ds.Tables[0].Rows[0]["PayerName"].ToString();
        lblCheckNumber.Text = ds.Tables[0].Rows[0]["CheckNumber"].ToString();
        lblPaymentType.Text = ds.Tables[0].Rows[0]["PaymentType"].ToString();

        lblCheckAmount.Text = string.Format("{0:c}", ds.Tables[0].Rows[0]["PaymentAmount"]);
        lblPostedAmount.Text = string.Format("{0:c}", ds.Tables[0].Rows[0]["PaymentPosted"]);
        lblRemainingBalance.Text = string.Format("{0:c}", ds.Tables[0].Rows[0]["RemainingAmount"]);

        rptDetails.DataSource = ds.Tables[1];
        rptDetails.DataBind();

    }

    protected void rptDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string claimStatusCode = drv["ClaimStatusCode"].ToString();

            Label lblClaimStatus = (Label)e.Item.FindControl("lblClaimStatus");
            switch (claimStatusCode)
            {
                case "1":
                    {
                        lblClaimStatus.Text = "Processed as Primary";
                        break;
                    }
                case "2":
                    {
                        lblClaimStatus.Text = "Processed as Secondary";
                        break; ;
                    }
                case "3":
                    {
                        lblClaimStatus.Text = "Processed as Tertiary";
                        break;
                    }
                case "4":
                    {
                        lblClaimStatus.Text = "Denied";
                        break;
                    }
                case "19":
                    {
                        lblClaimStatus.Text = "Processed as Primary, Forwarded to Additional Payer(s)";
                        break;
                    }
                case "20":
                    {
                        lblClaimStatus.Text = "Processed as Secondary, Forwarded to Additional Payer(s)";
                        break;
                    }
                case "21":
                    {
                        lblClaimStatus.Text = "Processed as Tertiary, Forwarded to Additional Payer(s)";
                        break;
                    }
                case "22":
                    {
                        lblClaimStatus.Text = "Reversal of Previous Payment";
                        break;
                    }
                case "23":
                    {
                        lblClaimStatus.Text = "Not Our Claim, Forwarded to Additional Payer(s)";
                        break;
                    }
                case "24":
                    {
                        lblClaimStatus.Text = "Predetermination Pricing Only - No Payment";
                        break;
                    }
            }
        }


    }
}

