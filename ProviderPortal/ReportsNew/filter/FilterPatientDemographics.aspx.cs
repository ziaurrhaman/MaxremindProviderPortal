using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class ProviderPortal_ReportsNew_filter_FilterPatientDemographics : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long PatientId = 0;
        if (!string.IsNullOrEmpty(Request.Form["PatientId"]))
        {
             PatientId = long.Parse(Request.Form["PatientId"]);
        }
        int Rows = int.Parse(Request.Form["Rows"]);
        int PageNumber = int.Parse(Request.Form["PageNumber"]);
        string _DateFrom = Request.Form["Datefrom"];
        string _DateTo = Request.Form["DateTo"];
        string _DateType = "PostDate";
        string Gender = Request.Form["Gender"];
        string Payers = Request.Form["PayerId"];
        PatientDB ObjPatientDB = new PatientDB();

       DataSet dsPatients = ObjPatientDB.PatientsDemographics(PatientId, Profile.PracticeId, Rows, PageNumber, _DateFrom, _DateTo, _DateType, Payers, Gender);

        rptPatients.DataSource = dsPatients.Tables[0];
        rptPatients.DataBind();


        hdnTotalRows.Text = dsPatients.Tables[1].Rows[0]["TotalRows"].ToString();
        hdnStartDate.Value = _DateFrom;
        hdnEndDate.Value = _DateTo;
        hdnGender.Value = Gender;
        hdnInsuranceId.Value = Payers;
        string[] DateFrom = _DateFrom.Split(new Char[] { '-' });
        string[] DateTo = _DateTo.Split(new Char[] { '-' });
        TimeSpan.Text = DateFrom[1] + "/" + DateFrom[2] + "/" + DateFrom[0] + "-" + DateTo[1] + "/" + DateTo[2] + "/" + DateTo[0];

    }
}