using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterDeductableReport : System.Web.UI.Page
{
    string StartDate = "";
    string EndDate = "";
    string PracticeLocationId = ""; string ProviderId = ""; string PriInsurance = ""; string SecInsurance = "";
    string InsuranceType = ""; string PriClaimStatus = ""; string SecClaimStatus = ""; string ReasonCodeValues = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsDB db = new ReportsDB();
        string DateType = "";

        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);

        if (Request.Form["DateType"] != "" || Request.Form["DateType"] == null || Request.Form["DateType"] == "")
        {
            DateType = Request.Form["DateType"];
        }
        else
        {
            DateType = "PostDate";
        }
        if (Request.Form["PracticeLocationId"] != null)
        {
            PracticeLocationId = Request.Form["PracticeLocationId"].ToString();
        }

        if (Request.Form["ProviderId"] != null)
        {
            ProviderId = Request.Form["ProviderId"].ToString();
        }

        if ((Request.Form["InsuranceType"] != null) && (Request.Form["InsuranceType"] == ""))
        {
            PriInsurance = Request.Form["Insurance"].ToString();
            PriClaimStatus = Request.Form["ClaimStatus"].ToString();
        }

        else if ((Request.Form["InsuranceType"] != null) && (Request.Form["InsuranceType"] == "Pri"))
        {
            InsuranceType = Request.Form["InsuranceType"].ToString();
            PriInsurance = Request.Form["Insurance"].ToString();
            PriClaimStatus = Request.Form["ClaimStatus"].ToString();

        }
        else if ((Request.Form["InsuranceType"] != null) && (Request.Form["InsuranceType"] == "Sec"))
        {
            InsuranceType = Request.Form["InsuranceType"].ToString();
            SecInsurance = Request.Form["Insurance"].ToString();
            SecClaimStatus = Request.Form["ClaimStatus"].ToString();
        }
        //if (Request.Form["ClaimStatus"] != null)
        //{
        //    ClaimStatus = Request.Form["ClaimStatus"].ToString();
        //}
        if (Request.Form["ReasonCodeValues"] != null)
        {
            ReasonCodeValues = Request.Form["ReasonCodeValues"].ToString();
        }
        string StartDate = Request.Form["StartDate"];
        string EndDate = Request.Form["EndDate"];
        DataSet ds = db.GetDeductableReport(Profile.PracticeId, "", Rows, PageNumber, DateType, StartDate, EndDate, PracticeLocationId, ProviderId, InsuranceType, PriInsurance, SecInsurance, PriClaimStatus, SecClaimStatus, ReasonCodeValues);

        rptDeductableReport.DataSource = ds.Tables[1];
        rptDeductableReport.DataBind();
        ltrTotalRows.Text = ds.Tables[2].Rows[0]["TotalRows"].ToString();
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
            hdnInsuranceType.Value = InsuranceType;
            if(PriInsurance == "")
            {
                hdnInsuranceId.Value = SecInsurance;
            }
            else if(SecInsurance == "")
            {
                hdnInsuranceId.Value = PriInsurance;
            }
            
        }
        string[] _DateFrom = StartDate.Split(new Char[] { '-' });
        string[] _DateTo = EndDate.Split(new Char[] { '-' });


        TimeSpan.Text = _DateFrom[1] + "/" + _DateFrom[2] + "/" + _DateFrom[0] + "-" + _DateTo[1] + "/" + _DateTo[2] + "/" + _DateTo[0];
    }


    protected void rptDeductableReport_ItemDataBound1(object sender, RepeaterItemEventArgs e)
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