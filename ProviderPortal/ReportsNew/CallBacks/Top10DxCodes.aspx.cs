using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_ReportsNew_CallBacks_Top10DxCodes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ReportsPatientDB Rptdb = new ReportsPatientDB();
        DataSet ds = Rptdb.Top10Diagnosis(10, 0, Profile.PracticeId,"");
        rptTop10DxCodes.DataSource = ds.Tables[0];
        rptTop10DxCodes.DataBind();
        //hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();
    }
}