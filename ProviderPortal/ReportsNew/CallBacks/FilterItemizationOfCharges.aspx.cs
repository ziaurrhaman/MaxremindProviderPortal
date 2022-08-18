using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_filter_FilterItemizationOfCharges : System.Web.UI.Page
{
    ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();
    string ProviderId = ""; string DateType = ""; string CustomDate = ""; string AsOf = ""; string PatientIds = ""; int Rows; string PayerId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientIds = Request.Form["PatientId"];
        ProviderId = Request.Form["ProviderId"];
        DateType = Request.Form["DateType"];
        if (DateType == "")
        {
            DateType = "DOS";
        }
        else
        {
            DateType = Request.Form["DateType"];
        }
        PayerId = Request.Form["PayerId"];
        AsOf = Request.Form["AsOf"];

        CustomDate = Request.Form["CustomDate"];

        if (CustomDate == "Today")
        {
            AsOf = DateTime.Today.ToShortDateString();
        }
        else if (CustomDate == "Yesterday")
        {
            AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
        }
        else if (CustomDate == "Custom")
        {
            AsOf = Request.QueryString["AsOf"];
        }

        hdnAsOf.Value = AsOf;
        hdnPatId.Value = PatientIds;
        hdnProviderId.Value = ProviderId;
        hdnDateType.Value = DateType;
        TimeSpan.Text = AsOf;

        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), 10, 0, "DOS Desc", DateType, AsOf, ProviderId, Convert.ToInt32(PatientIds), PayerId);
        rptItemizationOfCharges.DataSource = dsReportData;
        rptItemizationOfCharges.DataBind();
        hdnTotalRows.Value = dsReportData.Tables[1].Rows[0]["TotalRows"].ToString();
        Rows = Convert.ToInt32(dsReportData.Tables[1].Rows[0]["TotalRows"].ToString());

        Control FooterTemplate = rptItemizationOfCharges.Controls[rptItemizationOfCharges.Controls.Count - 1].Controls[0];

        if (dsReportData.Tables[0].Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            lblGranAverage.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dsReportData.Tables[0].Compute("sum(Charges)", string.Empty).ToString());
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }

            string adjustments = dsReportData.Tables[0].Rows[0]["Adjustments"].ToString();
            if (!string.IsNullOrEmpty(adjustments))
            {
                float TotalAdjustment = float.Parse(dsReportData.Tables[0].Compute("sum(Adjustments)", string.Empty).ToString());
                Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Payment"].ToString()))
            {
                float TotalPayment = float.Parse(dsReportData.Tables[0].Compute("sum(Payment)", string.Empty).ToString());
                Label lblTotalPayments = FooterTemplate.FindControl("lblTotalPayments") as Label;
                lblTotalPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPayment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Balance"].ToString()))
            {
                float TotalBalance = float.Parse(dsReportData.Tables[0].Compute("sum(Balance)", string.Empty).ToString());
                Label lblTotalBalance = FooterTemplate.FindControl("lblTotalBalance") as Label;
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        }
    }
    [System.Web.Services.WebMethod]
    public static bool GetPatientDetailsResponse(string PatientId)
    {

        HttpContext.Current.Session["PatientId"] = PatientId;
        return true;
    }
    public void GetTotal()
    {
        PatientIds = Request.QueryString["PatientId"].ToString();

        ProviderId = Request.QueryString["ProviderId"];
        DateType = Request.QueryString["DateType"];
        CustomDate = Request.QueryString["CustomDate"];

        if (CustomDate == "Today")
        {
            AsOf = DateTime.Today.ToShortDateString();
        }
        else if (CustomDate == "Yesterday")
        {
            AsOf = DateTime.Today.AddDays(-1).ToShortDateString();
        }
        else if (CustomDate == "Custom")
        {
            AsOf = Request.QueryString["AsOf"];
        }
        TimeSpan.Text = AsOf;
        DataSet dsReportData = objPatientReportsDB.ItemizationOfcharges(Convert.ToInt32(Profile.PracticeId), Rows, 0, "DOS Desc", DateType, AsOf, ProviderId, Convert.ToInt32(PatientIds), PayerId);

        Control FooterTemplate = rptItemizationOfCharges.Controls[rptItemizationOfCharges.Controls.Count - 1].Controls[0];
        if (dsReportData.Tables[0].Rows.Count > 0)
        {
            Label lblGranAverage = FooterTemplate.FindControl("lblGranAverage") as Label;
            lblGranAverage.Text = "Grand Total";
            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Charges"].ToString()))
            {
                float TotalCharges = float.Parse(dsReportData.Tables[0].Compute("sum(Charges)", string.Empty).ToString());
                Label lblTotalCharges = FooterTemplate.FindControl("lblTotalCharges") as Label;
                lblTotalCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalCharges));
            }


            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Adjustments"].ToString()))
            {
                float TotalAdjustment = float.Parse(dsReportData.Tables[0].Compute("sum(Adjustments)", string.Empty).ToString());
                Label lblTotalAdjustments = FooterTemplate.FindControl("lblTotalAdjustments") as Label;
                lblTotalAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalAdjustment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Payment"].ToString()))
            {
                float TotalPayment = float.Parse(dsReportData.Tables[0].Compute("sum(Payment)", string.Empty).ToString());
                Label lblTotalPayments = FooterTemplate.FindControl("lblTotalPayments") as Label;
                lblTotalPayments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalPayment));
            }

            if (!string.IsNullOrEmpty(dsReportData.Tables[0].Rows[0]["Balance"].ToString()))
            {
                float TotalBalance = float.Parse(dsReportData.Tables[0].Compute("sum(Balance)", string.Empty).ToString());
                Label lblTotalBalance = FooterTemplate.FindControl("lblTotalBalance") as Label;
                lblTotalBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(TotalBalance));
            }
        }




    }
    protected void rptItemizationOfCharges_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string Charges = drv["Charges"].ToString();
            Label lblCharges = (Label)e.Item.FindControl("lblCharges");
            if (Charges != "")
            {
                lblCharges.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Charges));
            }
            string Adjustment = drv["Adjustments"].ToString();
            Label lblAdjustments = (Label)e.Item.FindControl("lblAdjustments");
            if (Adjustment != "")
            {
                lblAdjustments.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Adjustment));
            }

            string Payment = drv["Payment"].ToString();
            Label lblPayment = (Label)e.Item.FindControl("lblPayment");
            if (Payment != "")
            {
                lblPayment.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Payment));

            }

            string Balance = drv["Balance"].ToString();
            Label lblBalance = (Label)e.Item.FindControl("lblBalance");
            if (Balance != "")
            {
                lblBalance.Text = "$" + string.Format("{0:0,0.00}", Convert.ToDouble(Balance));

            }

        }

    }
}