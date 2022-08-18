using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomeHealth_EpisodeClaims_CallBacks_ERAFilterHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string insurance =   Request.Form["insurance"];
        string checkNumber = Request.Form["checkNumber"];
        string paymentType = Request.Form["paymentType"];
        string paymentMethod = Request.Form["paymentMethod"];
        string checkAmount = Request.Form["checkAmount"];
        string paymentPosted = Request.Form["paymentPosted"];
        string status = Request.Form["status"];
        string paymentDate = Request.Form["paymentDate"];
        int rows = Convert.ToInt32(Request.Form["Rows"]);
        
        int pageNumber = Convert.ToInt32(Request.Form["pageNumber"]);
        string sortBy = Request.Form["SortBy"];
        
        ERAMasterDB objEraMasterDb = new ERAMasterDB();
        DataSet ds = objEraMasterDb.ERAMaster_GetBySearchCriteria(checkNumber, insurance, paymentDate,paymentType, paymentMethod, checkAmount,paymentPosted,status, "",rows, pageNumber,sortBy,"","");
                                                                  
        rptERA.DataSource = ds.Tables[0];
        rptERA.DataBind();
        
        ltrlERARowsCount.Text = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }

    protected void rptERA_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string paymentMethodCode = drv["PaymentMethodCode"].ToString();
            Label lblPaymentMethod = (Label)e.Item.FindControl("lblPaymentMethod");
            if (paymentMethodCode == "ACH")
            {
                lblPaymentMethod.Text = "Automated Clearing House";
            }

            if (paymentMethodCode == "BOP")
            {
                lblPaymentMethod.Text = "Financial Institution Option";
            }

            if (paymentMethodCode == "CHK")
            {
                lblPaymentMethod.Text = "Check";
            }

            if (paymentMethodCode == "FWT")
            {
                lblPaymentMethod.Text = "Federal Reserve Funds/Wire Transfer";
            }

            if (paymentMethodCode == "NON")
            {
                lblPaymentMethod.Text = "Non-Payment Data";
            }
        }

    }
}