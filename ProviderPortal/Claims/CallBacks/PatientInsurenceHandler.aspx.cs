using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Claims_CallBacks_PatientInsurenceHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /**********Start Insurances**********/
        PatientInsuranceDB ObjPatientInsuranceDB = new PatientInsuranceDB();
        DataTable ddtPatientInsurance = ObjPatientInsuranceDB.GetByPatient(Convert.ToInt64(Request.Form["PatientId"]));


        ddlPrimaryInsurance.DataSource = ddtPatientInsurance;
        ddlPrimaryInsurance.DataTextField = "InsuranceName";
        ddlPrimaryInsurance.DataValueField = "Insuranceid";
        ddlPrimaryInsurance.DataBind();
        ddlPrimaryInsurance.Items.Insert(ddtPatientInsurance.Rows.Count, new ListItem("Self Pay", "0"));
        ddlPrimaryInsurance.Items.Insert(0, new ListItem("", ""));

        ddlSecondaryInsurance.DataSource = ddtPatientInsurance;
        ddlSecondaryInsurance.DataTextField = "InsuranceName";
        ddlSecondaryInsurance.DataValueField = "Insuranceid";
        ddlSecondaryInsurance.DataBind();
        ddlSecondaryInsurance.Items.Insert(ddtPatientInsurance.Rows.Count, new ListItem("Self Pay", "0"));
        ddlSecondaryInsurance.Items.Insert(0, new ListItem("", ""));
        
        ddlOtherInsurance.DataSource = ddtPatientInsurance;
        ddlOtherInsurance.DataTextField = "InsuranceName";
        ddlOtherInsurance.DataValueField = "Insuranceid";
        ddlOtherInsurance.DataBind();
        ddlOtherInsurance.Items.Insert(ddtPatientInsurance.Rows.Count, new ListItem("Self Pay", "0"));
        ddlOtherInsurance.Items.Insert(0, new ListItem("", ""));

        //AppointmentsDB objAppointmentsDB = new AppointmentsDB();
        //ddlDos.DataSource = objAppointmentsDB.GetPatientAppointmentDate(long.Parse(Request.Form["PatientId"]));
        //ddlDos.DataTextField = "AppointmentDate";
        //ddlDos.DataValueField = "AppointmentDate";
        //ddlDos.DataBind();
        //ddlDos.Items.Insert(0, new ListItem("", ""));
        /**********End Insurances**********/
        
    }
}