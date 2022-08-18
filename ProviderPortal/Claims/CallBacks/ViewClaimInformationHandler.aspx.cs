using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class HomeHealth_EpisodeClaims_CallBacks_ViewClaimInformationHandler : System.Web.UI.Page
{
    private DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        Int64 claimId = Convert.ToInt64(Request.Form["ClaimId"]);
        ERAClaimPaymentsDB objClaimPaymentsDb = new ERAClaimPaymentsDB();
        ds = objClaimPaymentsDb.ERAClaimPayments_GetAllForViewClaims(claimId);
        rptERAClaimPayments.DataSource = ds.Tables[0];
        rptERAClaimPayments.DataBind();
       
    }

    protected void rptERAClaimPayments_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Repeater rptProcedurePayments = (Repeater)e.Item.FindControl("rptProcedurePayments");
            rptProcedurePayments.DataSource = ds.Tables[1];
            rptProcedurePayments.DataBind();
      
        }
    }
}