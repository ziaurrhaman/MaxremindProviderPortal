using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_ReportsNew_CallBacks_MostCommonlyUsedDxCodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB Rptdb = new ReportsPatientDB();
        DataSet ds = Rptdb.Top10Diagnosis(10, 0, Profile.PracticeId,"");
        rptMostCommonlyUsedDxCodes.DataSource = ds.Tables[0];
        rptMostCommonlyUsedDxCodes.DataBind();
        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}