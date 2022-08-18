using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomeHealth_EpisodeClaims_ERAMaster : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ERAMasterDB objEraMasterDb = new ERAMasterDB();
        DataSet ds = objEraMasterDb.ERAMaster_GetBySearchCriteria(Profile.PracticeId,"","","","","","", "", "","", 10, 0, "paymentDate","","");
        rptERA.DataSource = ds.Tables[0];
        rptERA.DataBind();
        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
    protected void rptERA_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView) e.Item.DataItem;
            string paymentMethodCode = drv["PaymentMethodCode"].ToString();
            Label lblPaymentMethod = (Label) e.Item.FindControl("lblPaymentMethod");
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