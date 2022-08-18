using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class ProviderPortal_Patient_PatientInsurancehandler_PatientInsuranceTableHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientInsuranceInformation();
    }


    public void PatientInsuranceInformation()
    {
        string Patientid=null;

        if (Session["Pid"] != null)
        {
            Patientid = Session["PId"].ToString();
        }



        //long prac = Profile.PracticeId;

        PatientDB db = new PatientDB();

        DataTable practisedt = db.PatientGetByPractiseId(Patientid);

        string practiseid = practisedt.Rows[0][0].ToString();

        DataSet dt = db.InsurancePatient(Patientid);

        if (dt.Tables[0].Rows.Count > 0)
        {


            RptInsurance.DataSource = dt;

            RptInsurance.DataBind();
        }

        
    }

}