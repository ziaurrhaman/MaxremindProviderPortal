using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class HomeHealth_EpisodeClaims_CallBacks_ERAClaimsPrintHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long ClaimCheckId = long.Parse(Request.Form["ClaimCheckId"]);
        long PracticeId = Profile.PracticeId;
        string action = Request.Form["action"];
        if (action == "ERADetail")
        {
            bool flgPayment = true;

            ClaimsDB objEpisodeClaimsDb = new ClaimsDB();
            DataSet ds = objEpisodeClaimsDb.GetERAClaimsDetail(ClaimCheckId, PracticeId);

            DataTable dtAgencyInfo = ds.Tables[0];
            DataTable dtPayerInfo = ds.Tables[1];
            DataTable dtCheckInfo = ds.Tables[2];
            DataTable dtERAClaimsPayment = ds.Tables[3];
            DataTable dtTotalCheckInfo = ds.Tables[4];
            DataTable dtRejReasonsAdjCodes = ds.Tables[5];

            DataTable dtProviderAdjustments = ds.Tables[7];
            rptProviderAdjustments.DataSource = dtProviderAdjustments;
            rptProviderAdjustments.DataBind();


            if (dtPayerInfo.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtPayerInfo.Rows[0]["PayerName"].ToString()))
                {
                    lblPayerName.Text = dtPayerInfo.Rows[0]["PayerName"].ToString();
                }
                if (!string.IsNullOrEmpty(dtPayerInfo.Rows[0]["PayerAddress1"].ToString()))
                {
                    lblPayerAddress1.Text = dtPayerInfo.Rows[0]["PayerAddress1"].ToString();
                }
                if (!string.IsNullOrEmpty(dtPayerInfo.Rows[0]["PayerAddress2"].ToString()))
                {
                    lblPayerAddress2.Text = dtPayerInfo.Rows[0]["PayerAddress2"].ToString();
                }
            }

            if (dtAgencyInfo.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtAgencyInfo.Rows[0]["PracticeName"].ToString()))
                {
                    lblAgencyName.Text = dtAgencyInfo.Rows[0]["PracticeName"].ToString();
                }
                if (!string.IsNullOrEmpty(dtAgencyInfo.Rows[0]["AgencyAddress"].ToString()))
                {
                    lblAgencyAddress1.Text = dtAgencyInfo.Rows[0]["AgencyAddress"].ToString();
                }
                if (!string.IsNullOrEmpty(dtAgencyInfo.Rows[0]["AgencyAddress2"].ToString()))
                {
                    lblAgencyAddress2.Text = dtAgencyInfo.Rows[0]["AgencyAddress2"].ToString();
                }
            }

            if (dtCheckInfo.Rows.Count > 0)
            {
                if (!string.IsNullOrEmpty(dtCheckInfo.Rows[0]["PayerIdentifier"].ToString()))
                {
                    lblPayerIdentifier.Text = dtCheckInfo.Rows[0]["PayerIdentifier"].ToString();
                }
                if (!string.IsNullOrEmpty(dtCheckInfo.Rows[0]["CheckIssueDate"].ToString()))
                {
                    lblCheckIssueDate.Text = dtCheckInfo.Rows[0]["CheckIssueDate"].ToString();
                }
                if (!string.IsNullOrEmpty(dtCheckInfo.Rows[0]["CheckNumber"].ToString()))
                {
                    lblCheckNumber.Text = dtCheckInfo.Rows[0]["CheckNumber"].ToString();
                }

                if (!string.IsNullOrEmpty(dtCheckInfo.Rows[0]["CheckAmount"].ToString()))
                {
                    lblCheckAmt.Text = String.Format("{0:0.##}", dtCheckInfo.Rows[0]["CheckAmount"].ToString());
                    ltrlCheck.Text = String.Format("{0:0.##}", dtCheckInfo.Rows[0]["CheckAmount"].ToString());
                }
                if (!string.IsNullOrEmpty(dtCheckInfo.Rows[0]["TransactionHandlingCode"].ToString()))
                {
                    string sCode = dtCheckInfo.Rows[0]["TransactionHandlingCode"].ToString();

                    switch (sCode)
                    {
                        case "C":
                            sCode = "C - Payment Accompanies Remittance Advice";
                            break;
                        case "D":
                            sCode = "D - Make Payment Only";
                            break;
                        case "H":
                            sCode = "H - Notification Only";
                            break;

                        case "I":
                            sCode = "I - Remittance Information Only";
                            break;
                        case "P":
                            sCode = "P - Prenotification of Future Transfers";
                            break;
                        case "U":
                            sCode = "U - Split Payment and Remittance";
                            break;
                        case "X":
                            sCode = "X - Handling Party’s Option to Split Payment and Remittance";
                            break;


                    }
                    lblTransactionHandlingCode.Text = sCode;
                }

            }

            //come here
            rptERAClaimsPayments.DataSource = dtERAClaimsPayment;
            rptERAClaimsPayments.DataBind();

            if (dtTotalCheckInfo.Rows.Count > 0)
            {
                ltrlNoOfClaims.Text = dtTotalCheckInfo.Rows[0]["TotalClaims"].ToString();
                ltrlTotalBilledAmt.Text = dtTotalCheckInfo.Rows[0]["TotalBilled"].ToString();
                ltrlTotalAllowedAmt.Text = dtTotalCheckInfo.Rows[0]["TotalAllowed"].ToString();
                ltrlTotalDeductAmt.Text = dtTotalCheckInfo.Rows[0]["TotalDeduct"].ToString();
                ltrlTotalCoinsAmt.Text = dtTotalCheckInfo.Rows[0]["TotalCoins"].ToString();
                ltrlTotalRCAmt.Text = dtTotalCheckInfo.Rows[0]["TotalRCAMT"].ToString();
                ltrlTotalPROVPDAmt.Text = dtTotalCheckInfo.Rows[0]["PROVPDAMT"].ToString();
                ltrlTotalPROVADJAmt.Text = dtTotalCheckInfo.Rows[0]["TotalPROVADJ"].ToString();
                //ltrlCheck.Text = dtTotalCheckInfo.Rows[0]["CHECK"].ToString();
            }
            if (dtRejReasonsAdjCodes.Rows.Count > 0)
            {
                rptRejReasonsAdjCodes.DataSource = dtRejReasonsAdjCodes;
                rptRejReasonsAdjCodes.DataBind();
            }

        }

        //Added by Khayyam adeel desc Show EOB PAyment dated 1/13/2021
        if (action == "EOBDetail")
        {

            string Action = "Edit";





            if (Request.Form["ClaimCheckId"] != null && Request.Form["ClaimCheckId"] != "")
            {
                string ERAMasterId = Request.Form["ClaimCheckId"];
                hdnERAMasterId.Value = ERAMasterId;
                ERAMasterDB objERAMasterDB = new ERAMasterDB();
                DataTable dtERAdetails = objERAMasterDB.ERAMaster_GetByERAMasterId(Convert.ToInt64(ERAMasterId));
                txtEOBDate.InnerText = DateTime.Parse(dtERAdetails.Rows[0]["CheckIssueDate"].ToString()).ToShortDateString();
                hdnCheckDate.Value = DateTime.Parse(dtERAdetails.Rows[0]["CheckIssueDate"].ToString()).ToShortDateString();
                txtEOBRefNo.InnerText = dtERAdetails.Rows[0]["CheckNumber"].ToString();
                lblPaymentMethod.Text = dtERAdetails.Rows[0]["PaymentMethodCode"].ToString();
                txtEOBAmount.InnerText = float.Parse(dtERAdetails.Rows[0]["PaymentAmount"].ToString()).ToString();
                hdnUploadedFilesID.Value = dtERAdetails.Rows[0]["uploadfilesid"].ToString();
                string PaymentType = dtERAdetails.Rows[0]["PaymentType"].ToString();
                //txtFilename.Value = dtERAdetails.Rows[0]["FileName"].ToString();


                switch (PaymentType)
                {
                    case "EOB":
                        lblPaymenttype.Text = "EOB";
                        hdnPaymentType.Value = "EOB";
                        break;
                    case "PAT":
                        lblPaymenttype.Text = "PAT";
                        hdnPaymentType.Value = "PAT";
                        ddlPaymentReason.Visible = true;
                        break;
                }
                ERAMasterDB objERAMasterDb = new ERAMasterDB();
                DataSet objDataSet = objERAMasterDb.ERAMaster_GetClaimDetailbyMasterId(long.Parse(ERAMasterId), null);
                RptAllocatedClaimDetails.DataSource = objDataSet;
                RptAllocatedClaimDetails.DataBind();

            }
            ERAGetPatandUploadFileDetails();
        }
    }
    private void ERAGetPatandUploadFileDetails()
    {
        ERAAttachFilesDB eRAattachFilesDB = new ERAAttachFilesDB();
        long ERAMasterId = Convert.ToInt64(Request.Form["ClaimCheckId"]);
        DataSet ERAGetPatandUploadFileDetails = eRAattachFilesDB.ERAGetPatandUploadFileDetails(ERAMasterId);
        //Get UploadFiles Details
        rptUFileERAEOB.DataSource = ERAGetPatandUploadFileDetails.Tables[0];
        rptUFileERAEOB.DataBind();



    }
    protected void rptERAClaimsPayments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView currRow = e.Item.DataItem as DataRowView;
        Repeater rptERAClaimPaymentsDetails = (Repeater)e.Item.FindControl("rptERAClaimPaymentsDetail");
        DataTable dt = GetERAClaimPaymentDetail(int.Parse(currRow.Row["ERAClaimPaymentsId"].ToString()));

        rptERAClaimPaymentsDetails.DataSource = dt;
        rptERAClaimPaymentsDetails.DataBind();

        //Object sumBilled = dt.Compute("Sum(Billed)", "");
        //Object sumAllowed = dt.Compute("Sum(Allowed)", "");
        //Object sumDeduct = dt.Compute("Sum(Deduct)", "");
        //Object sumCoins = dt.Compute("Sum(Coins)", "");
        //Object sumRCAMT = dt.Compute("Sum(RC-AMT)", "");
        //Object sumPROVPD = dt.Compute("Sum(PROV PD)", "");

    }

    //End od change added by Khayyam Adeel
    Object sumBilled;
    Object sumAllowed;
    Object sumDeduct;
    Object sumCoins;
    Object sumRCAMT;
    Object sumPROVPD;
    private DataTable GetERAClaimPaymentDetail(long ERAClaimPaymentId)
    {
        ClaimsDB objEpisodeClaimsDb = new ClaimsDB();
        DataTable dt = objEpisodeClaimsDb.GetERAProcedurePaymentDetail(ERAClaimPaymentId);
        sumBilled = dt.Compute("Sum(Billed)", "");
        sumAllowed = dt.Compute("Sum(Allowed)", "");
        sumDeduct = dt.Compute("Sum(Deduct)", "");
        sumCoins = dt.Compute("Sum(Coins)", "");
        sumRCAMT = dt.Compute("Sum(RCAMT_Total)", "");
        sumPROVPD = dt.Compute("Sum(PROVPD)", "");

        if (sumPROVPD.ToString() == "")
            sumPROVPD = "0";

        if (sumBilled.ToString() == "")
            sumBilled = "0";

        if (sumAllowed.ToString() == "")
            sumAllowed = "0";

        if (sumDeduct.ToString() == "")
            sumDeduct = "0";

        if (sumCoins.ToString() == "")
            sumCoins = "0";

        if (sumRCAMT.ToString() == "")
            sumRCAMT = "0";

        if (sumPROVPD.ToString() == "")
            sumPROVPD = "0";

        return dt;
    }

    private DataTable GetERAClaimAdjustments(long ERAProcedurePaymentsId, long ERAProcedureAdjustmentsId)
    {
        ClaimsDB objEpisodeClaimsDb = new ClaimsDB();
        DataTable dt = objEpisodeClaimsDb.GetERAProcedureAdjustmentDetail(ERAProcedurePaymentsId, ERAProcedureAdjustmentsId);

        return dt;

    }

    protected void rptERAClaimPaymentsDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView currRow = e.Item.DataItem as DataRowView;
        if (currRow != null)
        {
            if (!String.IsNullOrEmpty(currRow.Row["ERAProcedureAdjustmentsId"].ToString()))
            {
                Repeater rptERAProcedureAdjustments = (Repeater)e.Item.FindControl("rptERAProcedureAdjustments");
                DataTable dt = GetERAClaimAdjustments(long.Parse(currRow.Row["ERAProcedurePaymentsId"].ToString()), long.Parse(currRow.Row["ERAProcedureAdjustmentsId"].ToString()));

                rptERAProcedureAdjustments.DataSource = dt;
                rptERAProcedureAdjustments.DataBind();

            }

        }


        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblTotalBilled = (Label)e.Item.FindControl("lblTotalBilled");
            lblTotalBilled.Text = sumBilled.ToString();

            Label lblTotalAllowed = (Label)e.Item.FindControl("lblTotalAllowed");
            lblTotalAllowed.Text = sumAllowed.ToString();

            Label lblTotalDeduct = (Label)e.Item.FindControl("lblTotalDeduct");
            lblTotalDeduct.Text = sumDeduct.ToString();

            Label lblTotalCoins = (Label)e.Item.FindControl("lblTotalCoins");
            lblTotalCoins.Text = sumCoins.ToString();

            Label lblTotalRCAMT = (Label)e.Item.FindControl("lblTotalRCAMT");
            lblTotalRCAMT.Text = sumRCAMT.ToString();

            Label lblTotalPROVPD = (Label)e.Item.FindControl("lblTotalPROVPD");
            lblTotalPROVPD.Text = sumPROVPD.ToString();

            Label lblTotalNet = (Label)e.Item.FindControl("lblTotalNet");
            lblTotalNet.Text = (Convert.ToDecimal(sumBilled) - Convert.ToDecimal(sumRCAMT)).ToString();

            //Label lblCO253 = (Label)e.Item.FindControl("lblCO253");
            //lblCO253.Text = "CO-253 " + (Convert.ToDecimal(lblTotalNet.Text) - Convert.ToDecimal(sumPROVPD)).ToString();
            //lblCO253.Visible = (Convert.ToDecimal(lblTotalNet.Text) - Convert.ToDecimal(sumPROVPD)) == 0 ? false : true;
        }
    }

    protected void rptERAProcedureAdjustments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
}