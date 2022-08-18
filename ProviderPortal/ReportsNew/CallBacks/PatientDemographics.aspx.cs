using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class ProviderPortal_ReportsNew_CallBacks_PatientDemographics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadPayersFromClaim();

        string _DateFrom = Request.Form["Datefrom"];
        string _DateTo = Request.Form["DateTo"];
        string Gender = Request.Form["Gender"];
        string Payers = Request.Form["PayerId"];
        string DateType = "PostDate";
        PatientDB ObjPatientDB = new PatientDB();
        long PracticeId = Profile.PracticeId;
        using (DataSet dsPatientRecord = ObjPatientDB.PatientsDemographics(0, PracticeId, 10, 0, _DateFrom, _DateTo, DateType, "", ""))
        {
            rptPatients.DataSource = dsPatientRecord.Tables[0];
            rptPatients.DataBind();
            hdnTotalRows.Value = dsPatientRecord.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        hdnStartDate.Value = _DateFrom;
        hdnEndDate.Value = _DateTo;
        hdnGender.Value = Gender;
        hdnInsuranceId.Value = Payers;
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];
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

   
    

   
    
