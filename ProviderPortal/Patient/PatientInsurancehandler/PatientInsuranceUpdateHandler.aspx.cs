using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class ProviderPortal_Patient_PatientInsurancehandler_PatientInsuranceUpdateHandler : System.Web.UI.Page
{

    int PatientinsuranceId;
    int Patientid ;
    string insuranceid;
    string InsuranceName; string InsuranceType;
    protected void Page_Load(object sender, EventArgs e)
    {
        

        if (Request.Form["id"] != null)
        {
            PatientinsuranceId = Convert.ToInt32(Request.Form["id"].ToString());
        }
       
       

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



        if (Request.Form["action"] == "save")
        {
            JavaScriptSerializer serilizer = new JavaScriptSerializer();
            PatientInsurance obj1 = new PatientInsurance();
            obj1 = serilizer.Deserialize<PatientInsurance>(Request.Form["classobj"]);
            PatientInsuranceDB PatientInsuDb = new PatientInsuranceDB();

            PatientInsuDb.Update(obj1);
        }


        PatientInsuranceDB Idb = new PatientInsuranceDB();
        DataTable Dt = new DataTable(); 
        Dt = Idb.ShowPatientInsuranceDateForDialog(Patientid, PatientinsuranceId);
        if (Dt.Rows.Count > 0)
        {
            insuranceid = Dt.Rows[0]["InsuranceId"].ToString();
            InsuranceName = Dt.Rows[0]["Name"].ToString();
        }
      


       

        PatientDB db = new PatientDB();
        DataTable practisedt = db.PatientGetByPractiseId(Patientid);
        long practiceId = Convert.ToInt64(practisedt.Rows[0][0].ToString());

        DataSet ddtPatient = db.Patient_GetById(Patientid, practiceId);
        /********edited by shahid kazmi 2/12/2018 for subscriber name*************/
        //txtFirstName.Text = ddtPatient.Tables[0].Rows[0]["FirstName"].ToString().Trim();
        //txtLastName.Text = ddtPatient.Tables[0].Rows[0]["LastName"].ToString().Trim();
        if (!string.IsNullOrEmpty(Request.Form["Fname"]))
        {
            txtFirstName.Text = Request.Form["Fname"].ToString();
        }
        else
        {
            txtFirstName.Text = ddtPatient.Tables[0].Rows[0]["FirstName"].ToString().Trim();
        }
        if (!string.IsNullOrEmpty(Request.Form["Lname"]))
        {
            txtLastName.Text = Request.Form["Lname"].ToString();
        }
        else
        {
            txtLastName.Text = ddtPatient.Tables[0].Rows[0]["LastName"].ToString().Trim();
        }
        /******end shahid kazmi 2/12/2018**********/
        
        InsuranceNames();
        PatientInsuranceUpdate();
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
   
        long practiceId = Profile.PracticeId;
        dt = Idb.InsuranceFilterByName(practiceId);
        ddNameU.DataSource = dt;
       
        
            ddNameU.DataTextField = "Name";
            ddNameU.DataValueField = "InsuranceId";

            ddNameU.DataBind();

            ddNameU.Items.Insert(0, new ListItem(InsuranceName, insuranceid));
          //  ddlRace.Items.Insert(0, new ListItem(racename, raceid));
           
        
    }

    public void PatientInsuranceUpdate()
    {
        PatientInsuranceDB db = new PatientInsuranceDB();
        DataTable dt = new DataTable();
        dt = db.ShowPatientInsuranceDateForDialog(Patientid, PatientinsuranceId);
       // InsurancesName.Text = dt.Rows[0]["PriSecOthType"].ToString();
        if (dt.Rows.Count > 0)
        {

            string namess=dt.Rows[0]["PriSecOthType"].ToString();
            //string DropDownvalue = dt.Rows[0]["PriSecOthType"].ToString(); //
            //if (DropDownvalue == "P")
            //{
            //    UpdateddInsurance.Items.Insert(0, new ListItem("Primary", "P"));
            //}
            //else if (DropDownvalue == "S")
            //{
            //    UpdateddInsurance.Items.Insert(0, new ListItem("Secondary", "S"));
            //}
            //else if (DropDownvalue == "o")
            //{
            //    UpdateddInsurance.Items.Insert(0, new ListItem("Other", "O"));
            //}
        //  string DropDownvalue = dt.Rows[0]["PriSecOthType"].ToString(); //
            if (namess == "P" || namess=="p")
          {
              InsurancesName.Text = "Primary";
          }
            else if (namess == "S" || namess == "s")
            {
                InsurancesName.Text = "Secondary";
            }
            else if (namess == "o" || namess == "O")
            {
                InsurancesName.Text = "Other";
            }
            txtPoliceNoU.Value = dt.Rows[0]["PolicyNumber"].ToString().Trim();
            txtGroupNoU.Text = dt.Rows[0]["GroupNumber"].ToString().Trim();
            txtGroupNameU.Text = dt.Rows[0]["GroupName"].ToString().Trim();
            /***edited by shahid kazmi 2/7/2018********/
            string eDate = "";
            string tDate = "";
            if(!string.IsNullOrEmpty(dt.Rows[0]["EffectiveDate"].ToString()))
             eDate = dt.Rows[0]["EffectiveDate"].ToString();
            if(!string.IsNullOrEmpty(dt.Rows[0]["TerminationDate"].ToString()))
             tDate = dt.Rows[0]["TerminationDate"].ToString();
            //string EDate = dt.Rows[0]["EffectiveDate"].ToString().Trim();
            //string TDate = dt.Rows[0]["TerminationDate"].ToString().Trim();
            if (eDate != "")
            {

                DateTime EDate = DateTime.Parse(eDate);
                txtEffectiveDateU.Text = EDate.ToShortDateString();
            }
            else
            {
                txtEffectiveDateU.Text = "";
            }

            if (tDate != "")
            {
                DateTime TDate = DateTime.Parse(tDate);
                txtTerminationDateU.Text = TDate.ToShortDateString();
            }
            else
            {
                txtTerminationDateU.Text = "";
            }
            /*********end shahid kazmi 2/7/2018*********/
            txtCopayU.Text = dt.Rows[0]["Copay"].ToString().Trim();
            ddCopayU.Text = dt.Rows[0]["CoPayType"].ToString().Trim();
            txtCoinsuranceU.Text = dt.Rows[0]["CoInsurance"].ToString().Trim();
            ddCoinsuranceU.Text = dt.Rows[0]["CoInsuranceType"].ToString().Trim();
            txtDeductableU.Text = dt.Rows[0]["Deductable"].ToString().Trim();
            ddDeductableU.Text = dt.Rows[0]["DeductableType"].ToString().Trim();
            ddRelationshipU.Text = dt.Rows[0]["Relationship"].ToString().Trim();
        }
        
    }
}