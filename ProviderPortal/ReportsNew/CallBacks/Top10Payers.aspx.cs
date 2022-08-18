using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_Top10Payers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        reportShow();
       // LoadPayersFromClaim();
    }

    public void reportShow()
    {

        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        DataSet ds = objClaimChargesDB.TOPTENPayers_SUMMARYReport(10, 0, Profile.PracticeId, "");
        rptTherapyTask1.DataSource = ds.Tables[0];
        rptTherapyTask1.DataBind();
        //hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotalRows"].ToString();



    }
    //public void LoadPayersFromClaim()
    //{
    //    InsuranceDB insuranceDB = new InsuranceDB();
    //    long PracticeId = Profile.PracticeId;
    //    DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
    //    rptPayerScenario.DataSource = dtPatient;
    //    rptPayerScenario.DataBind();

    //}
}