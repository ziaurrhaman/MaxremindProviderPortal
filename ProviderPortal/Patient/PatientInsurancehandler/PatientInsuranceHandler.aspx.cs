using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class ProviderPortal_Patient_PatientInsurancehandler_PatientInsuranceHandler : System.Web.UI.Page
{
    string Patiendid = null; string InsuranceType;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        PatientDB db = new PatientDB();
        int Patientid = 0;


        if (Session["Pid"] != null)
        {
            Patientid = Convert.ToInt32(Session["PId"]);

        }

        PatientDB dbb = new PatientDB();
        DataTable dt = new DataTable();
        dt = dbb.PriSecothinsuranceTypeCheck(Convert.ToInt32(Patientid));
        if (dt.Rows.Count > 0)
        {
            InsuranceType = dt.Rows[0]["PriSecOthType"].ToString();
            hdnInshuranecType.Value = InsuranceType;

        }
        else
        {
            InsuranceType = "";
            hdnInshuranecType.Value = InsuranceType;

        }

        PatientDB Pat = new PatientDB();
        DataTable practisedt = Pat.PatientGetByPractiseId(Patientid);
        long practiceId = Convert.ToInt64(practisedt.Rows[0][0].ToString());

        DataSet ddtPatient = Pat.Patient_GetById(Patientid, practiceId);

        txtFirstName.Text = ddtPatient.Tables[0].Rows[0]["FirstName"].ToString().Trim();
        txtLastName.Text = ddtPatient.Tables[0].Rows[0]["LastName"].ToString().Trim();


        InsuranceNames();

        if (Request.Form["action"] == "Insert")
        {
            JavaScriptSerializer serilizer = new JavaScriptSerializer();
            PatientInsurance obj1 = new PatientInsurance();
            obj1 = serilizer.Deserialize<PatientInsurance>(Request.Form["Insertdataobj"]);
            PatientInsuranceDB PatientInsuDb = new PatientInsuranceDB();
            PatientInsuDb.Add(obj1);
        }
     
       
    }





    public void InsuranceNames()
    {
        int Patientid = 0;

        if (Session["Pid"] != null)
        {
            Patientid = Convert.ToInt32(Session["PId"]);
        }
       
        DataTable dt = new DataTable();
        PatientDB db = new PatientDB();
        InsuranceDB Idb = new InsuranceDB();
        DataTable practisedt = db.PatientGetByPractiseId(Patientid);
        long practiceId = Convert.ToInt64(practisedt.Rows[0][0].ToString());
        dt = Idb.InsuranceFilterByName(practiceId);
        ddName.DataSource = dt;
        ddName.DataTextField = "Name";
        ddName.DataValueField = "InsuranceId";

        ddName.DataBind();
        ddName.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    }

}