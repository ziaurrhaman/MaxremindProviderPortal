using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EMR_ReportsNew_CallBacks_DuplicateChecks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string _DateFrom = "";
        string _DateTo = "";
        string DateType = "";

        _DateFrom = (Request.Form["Datefrom"]);
        _DateTo = (Request.Form["Dateto"]);
        ReportsPatientDB objPatientReportsDB = new ReportsPatientDB();

        DataSet ds = objPatientReportsDB.DuplicateChecks(Profile.PracticeId, Profile.UserId, 10, 0, _DateFrom, _DateTo);
       
        rptDuplicatecChecks.DataSource = ds.Tables[0];
        rptDuplicatecChecks.DataBind();
        hdnTotalRows.Value = ds.Tables[1].Rows[0]["TotRow"].ToString();
        hdnDateFrom.Value = _DateFrom;
        hdnDateTo.Value = _DateTo;
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });


        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
       // LoadChecks();
        LoadPayersFromClaim();
    }
    public void LoadChecks()
    {
        InsuranceDB insuranceDB = new InsuranceDB();

        DataTable dtPayerName = insuranceDB.CheckNoList(Profile.PracticeId, "", "", "CheckNumber");
        ddlCheckNumber.DataSource = dtPayerName;
        ddlCheckNumber.DataBind();
        ddlCheckNumber.DataTextField = "CheckNumber";
        ddlCheckNumber.DataValueField = "CheckNumber";
        ddlCheckNumber.DataBind();
        ddlCheckNumber.Items.Insert(0, new ListItem("", "All"));
        ddlCheckNumber.SelectedIndex = 0;
        //ddlCheckNumber.DataBind();

    }
    public void LoadPayersFromClaim()
    {
        InsuranceDB insuranceDB = new InsuranceDB();
        long PracticeId = Profile.PracticeId;
        DataTable dtPatient = insuranceDB.GetPayersByPracticeId(PracticeId, "", "");
        rptPayerScenario.DataSource = dtPatient;
        rptPayerScenario.DataBind();

    }
}