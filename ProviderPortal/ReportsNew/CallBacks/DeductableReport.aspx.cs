using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_DeductableReport : System.Web.UI.Page
{
    string StartDate = "";
    string EndDate = "";
    string PracticeLocationId = ""; string ProviderId = ""; string PriInsurance = ""; string SecInsurance = "";
    string InsuranceType = ""; string PriClaimStatus = ""; string SecClaimStatus = ""; string ReasonCodeValues = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsDB db = new ReportsDB();
        string DateType = "";

        if (Request.Form["DateType"] != "" || Request.Form["DateType"] == null)
        {
            DateType = Request.Form["DateType"];
        }
        else
        {
            DateType = "PostDate";
        }

        if (Request.Form["DateFrom"] != null)
        {
            StartDate = Request.Form["DateFrom"];
        }
        if (Request.Form["DateTo"] != null)
        {
            EndDate = Request.Form["DateTo"];
        }
        if (Request.Form["DateFrom"] == null || Request.Form["DateFrom"] == "")
        {
            StartDate = DateTime.Today.ToShortDateString();
        }
        if (Request.Form["DateTo"] == null || Request.Form["DateTo"] == "")
        {
            EndDate = DateTime.Today.ToShortDateString();
        }
        string[] _DateFrom = StartDate.Split(new Char[] { '-' });
        string[] _DateTo = EndDate.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];

        if ((Request.Form["InsuranceType"] != null) && (Request.Form["InsuranceType"] == ""))
        {
            PriInsurance = "";
            SecInsurance = "";
            hdnInsuranceId.Value = "";
            hdnInsuranceType.Value = "";
        }

        else if ((Request.Form["InsuranceType"] != null) && (Request.Form["InsuranceType"] == "Pri"))
        {
            InsuranceType = Request.Form["InsuranceType"];
            PriInsurance = Request.Form["Insurance"];
            hdnInsuranceId.Value = PriInsurance;
            hdnInsuranceType.Value = Request.Form["InsuranceType"];
            PriClaimStatus = Request.Form["ClaimStatus"];

        }
        else if ((Request.Form["InsuranceType"] != null) && (Request.Form["InsuranceType"] == "Sec"))
        {
            InsuranceType = Request.Form["InsuranceType"];
            SecInsurance = Request.Form["Insurance"];
            hdnInsuranceId.Value = SecInsurance;
            hdnInsuranceType.Value = Request.Form["InsuranceType"];
            SecClaimStatus = Request.Form["ClaimStatus"];

        }
        //if (Request.Form["ClaimStatus"] != null)
        //{
        //    ClaimStatus = Request.Form["ClaimStatus"];
        //}

        if (Request.Form["ReasonCodeValues"] != null)
        {
            ReasonCodeValues = Request.Form["ReasonCodeValues"];
        }

        DataSet ds = db.GetDeductableReport(Profile.PracticeId, "", 10, 0, "PostDate", StartDate, EndDate, PracticeLocationId, ProviderId, InsuranceType, PriInsurance, SecInsurance, PriClaimStatus, SecClaimStatus, ReasonCodeValues);

        rptDeductableReport.DataSource = ds.Tables[1];
        rptDeductableReport.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblDeductible.Text = "$" + string.Format("{0:0,0.00}", ds.Tables[0].Rows[0]["Deductible"]);
            lblCoInsurance.Text = "$" + string.Format("{0:0,0.00}", ds.Tables[0].Rows[0]["Coinsurance"]);
            lblCoPayment.Text = "$" + string.Format("{0:0,0.00}", ds.Tables[0].Rows[0]["Copayment"]);
            lblTotalPR.Text = "$" + string.Format("{0:0,0.00}", ds.Tables[0].Rows[0]["TotalPR"]);
            hdnStartDate.Value = StartDate;
            hdnEndDate.Value = EndDate;
            hdnDateType.Value = DateType;
            hdnPriClaimStatus.Value = PriClaimStatus;
            hdnSecClaimStatus.Value = SecClaimStatus;
            hdnReasonCode.Value = ReasonCodeValues;
            hdnTotalRows.Value = ds.Tables[2].Rows[0]["TotalRows"].ToString();
        }

        LoadClaimStatus();
        LoadPayersFromClaim();
    }
    public void LoadClaimStatus()
    {
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        rptCalimStatus.DataSource = dtSubmissionStatusCodes;
        rptCalimStatus.DataBind();
    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
    protected void rptDeductableReport_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            Label lblsecins = (Label)e.Item.FindControl("lblsecins");
            Label lblPriIns = (Label)e.Item.FindControl("lblPriIns");
            string lblSec = drv["SecondaryInsurance"].ToString();
            string lblPri = drv["PrimaryInsurance"].ToString();
            if (lblSec.Length > 10)
            {
                lblsecins.Text = lblSec.Substring(0, 10);
            }
            else
            {
                lblsecins.Text = lblSec;
            }
            if (lblPri.Length > 10)
            {
                lblPriIns.Text = lblPri.Substring(0, 10);
            }
            else
            {
                lblPriIns.Text = lblPri;
            }

        }
    }
}