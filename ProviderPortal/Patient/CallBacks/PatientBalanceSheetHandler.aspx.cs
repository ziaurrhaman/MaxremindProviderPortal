using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class EMR_Patient_CallBacks_PatientBalanceSheetHandler : System.Web.UI.Page
{
    decimal _ClaimTotalDue;
    decimal _TotalClaimPaidAmount;
    decimal _TotalPatientPaid;
    decimal _RemainingAmount;
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        BalanceSheetDB objBalanceSheetDb = new BalanceSheetDB();
        if (action == "All")
        {
            rptBalanceSheet.DataSource = objBalanceSheetDb.GetByPatient(long.Parse(Request.Form["PatientId"]));
            rptBalanceSheet.DataBind();
        }
        if (action == "BalanceDetails")
        {
            rptClaims.DataSource = objBalanceSheetDb.GetCashRregisterDetails(Request.Form["Dos"], long.Parse(Request.Form["PatientId"]));
            rptClaims.DataBind();
            hdnClaimTotalDue.Value = _ClaimTotalDue.ToString();
            hdnClaimTotalPaid.Value = _TotalClaimPaidAmount.ToString();
            hdnPatientTotalPaid.Value = _TotalPatientPaid.ToString();
        }
        if (action == "Pay")
        {
            JavaScriptSerializer seriailzer = new JavaScriptSerializer();
            CashRegister objCashRegister = seriailzer.Deserialize<CashRegister>(Request.Form["CashRegister"]);
            objCashRegister.ModifiedById = Profile.UserId;
            objCashRegister.ModifiedDate = DateTime.Now;
            objBalanceSheetDb.PHRPaymentUpdate(objCashRegister);

            var listclaim = seriailzer.Deserialize<List<Claim>>(Request.Form["ClaimChargesList"]);
            foreach (var objlistclaim in listclaim)
            {
                objlistclaim.ModifiedById = Profile.UserId;
                objlistclaim.ModifiedDate = DateTime.Now;
                objBalanceSheetDb.UpdateClaimPaidAmount(objlistclaim);
            }
            rptBalanceSheet.DataSource = objBalanceSheetDb.GetByPatient(objCashRegister.PatientId);
            rptBalanceSheet.DataBind();
        }
    }
    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var dr = (DataRowView)e.Item.DataItem;

            Literal ltrAmountDue = (Literal)e.Item.FindControl("ltrAmountDue");
            Literal ltrPatientPaid = (Literal)e.Item.FindControl("ltrPatientPaid");

            decimal amountDue = decimal.Parse(dr["ClaimTotalCharges"].ToString()) - (decimal.Parse(dr["ClaimPaidAmount"].ToString()) + decimal.Parse(dr["PatientPaidAmmount"].ToString()));

            ltrAmountDue.Text = String.Format("{0:0.00}", amountDue);

            _ClaimTotalDue += decimal.Parse(dr["ClaimTotalCharges"].ToString());
            _TotalClaimPaidAmount += decimal.Parse(dr["ClaimPaidAmount"].ToString());
            _TotalPatientPaid += decimal.Parse(dr["PatientPaidAmmount"].ToString());
            _RemainingAmount += amountDue;
        }
        if (e.Item.ItemType == ListItemType.Footer)
        {
            Label lblTotalCharges = (Label)e.Item.FindControl("lblTotalCharges");
            Label lblInsurancePaid = (Label)e.Item.FindControl("lblInsurancePaid");
            Label lblPatientPaid = (Label)e.Item.FindControl("lblPatientPaid");
            Label lblAmountDue = (Label)e.Item.FindControl("lblAmountDue");

            lblTotalCharges.Text = String.Format("{0:0.00}", _ClaimTotalDue);
            lblInsurancePaid.Text = String.Format("{0:0.00}", _TotalClaimPaidAmount);
            lblPatientPaid.Text = String.Format("{0:0.00}", _TotalPatientPaid);
            lblAmountDue.Text = String.Format("{0:0.00}", _RemainingAmount);
        }
    }
}