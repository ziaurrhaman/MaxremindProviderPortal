using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class BillingManager_Payment_Payments : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Profile.RightsServer.PaymentView)
        {
            paymentwrapper.Attributes["class"] = "hide";
            errordiv.Attributes["class"] = "align-center";
        }

        string StartDate = "";
        string EndDate = "";
        DateTime Date = DateTime.Now;
        ERAMasterDB objERAMasterDB = new ERAMasterDB();
       
        /***start***/
        bool? IsImportedDataOnly = null;
        if (!string.IsNullOrEmpty(Session["IsImported"] as string))
        {
            
            if (Session["IsImported"].ToString() == "2") { IsImportedDataOnly = true; }
            else if (Session["IsImported"].ToString() == "1") { IsImportedDataOnly = false; }
            else { IsImportedDataOnly = null; }
        }
        /***End***/
        ///Modified By Irfan Mahmood 20/July/2022 : Add 90 Days 
        DataSet dsERAList = objERAMasterDB.GetBySearchCriteria(Profile.PracticeId, "", "", "", "", "", "", 10, 0,
            "CheckIssueDate Desc", false, false, false, "", IsImportedDataOnly, Date.AddDays(-90).ToString("M/d/yyyy"), DateTime.Today.ToString("M/d/yyyy"), null, null, null, "PostDate");
        ///End Modified By Irfan Mahmood 20/July/2022 
        DataTable dtERA = dsERAList.Tables[0];
            DataTable dtERATotalCount = dsERAList.Tables[1];
            if (dtERA.Rows.Count > 0)
            {
                rptClaimCheck.DataSource = dtERA;
                rptClaimCheck.DataBind();
                hdnTotalRowsClaimList.Value = dtERATotalCount.Rows[0]["TotalRows"].ToString();
                hdnTotalRows.Value = dtERATotalCount.Rows[0]["TotalRows"].ToString();

               

                double chkamount = Convert.ToDouble(dtERA.Compute("SUM(CheckAmount)", string.Empty));
                lblchkamount.Text = "$" + chkamount.ToString();

                double postamount = Convert.ToDouble(dtERA.Compute("SUM(PostedAmount)", string.Empty));
                lblPostamount.Text = "$" + postamount.ToString();
            }
            ddls();
    }
    protected void rptClaimCheck_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        var dr = (DataRowView)e.Item.DataItem;
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {

           
            Label lblOasisStatus = (Label)e.Item.FindControl("lblVerify");
            lblOasisStatus.CssClass = bool.Parse(dr["Verified"].ToString()) ? "tick" : "cross";
        }

     


        }


    protected void ddls()
    {
        InsuranceDB db = new InsuranceDB();
        DataTable dt = db.GetAllInsurancesHavingClaims(Profile.PracticeId, "");
        ddlinsurance.DataSource = dt;
        ddlinsurance.DataTextField = "InsuranceName";
        ddlinsurance.DataValueField = "InsuranceId";
        ddlinsurance.DataBind();
        ///Modified By Irfan Mahmood 14/July/2022
        ReportsDB ReportsDB = new ReportsDB();
        ServiceProviderDB serviceProviderDB = new ServiceProviderDB();
        DataTable dtPayerName = ReportsDB.GetProvidersByDefault(Profile.PracticeId);
        ddlBillingProvider.DataSource = dtPayerName;
        ddlBillingProvider.DataTextField = "StaffName";
        ddlBillingProvider.DataValueField = "StaffNPI";
        ddlBillingProvider.DataBind();
        ///Modified By Irfan Mahmood 14/July/2022

    }




}


 

