using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_Top10Procedures : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        DataSet ds = objClaimChargesDB.TOPTENPROCEDURES_SUMMARYReport(10, 0, Profile.PracticeId,"");
        rptTherapyTask.DataSource = ds.Tables[0];
        rptTherapyTask.DataBind();
        //hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }



}