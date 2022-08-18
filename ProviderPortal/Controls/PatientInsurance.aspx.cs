using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

public partial class ProviderPortal_Controls_PatientInsurance : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        
        if (action == "LoadPatientInsurance")
        {
            LoadForm();
        }
        else if (action == "Save")
        {
            Save();
        }
    }
    
    private void LoadForm()
    {
        long PatientId = long.Parse(Request.Form["PatientId"]);
        long PatientInsuranceId = long.Parse(Request.Form["PatientInsuranceId"]);
        
        PatientInsuranceDB objPatientInsuranceDB = new PatientInsuranceDB();
        
        DataTable dtPatientInsurance = objPatientInsuranceDB.GetById(PatientInsuranceId);
        
        if (dtPatientInsurance.Rows.Count > 0)
        {
            hdnInsuranceIdWalkoutEdit.Value = dtPatientInsurance.Rows[0]["InsuranceId"].ToString();
            hdnPatientInsuranceIdWalkoutEdit.Value = dtPatientInsurance.Rows[0]["PatientInsuranceId"].ToString();
            
            txtPatientInsuranceWalkout.Value = dtPatientInsurance.Rows[0]["InsuranceName"].ToString();
            txtPolicyNoWalkout.Value = dtPatientInsurance.Rows[0]["PolicyNumber"].ToString();
            txtGroupNoWalkout.Value = dtPatientInsurance.Rows[0]["GroupNumber"].ToString();
            txtGroupNameWalkout.Value = dtPatientInsurance.Rows[0]["GroupName"].ToString();
            txtEffectiveDateWalkout.Value = dtPatientInsurance.Rows[0]["EffectiveDate"].ToString();
            txtTerminationDateWalkout.Value = dtPatientInsurance.Rows[0]["TerminationDate"].ToString();

            txtCopayWalkout.Value = dtPatientInsurance.Rows[0]["CoPay"].ToString();
            ddlCoPayTypeWalkout.SelectedValue = dtPatientInsurance.Rows[0]["CoPayType"].ToString();
            txtCoInsuranceWalkout.Value = dtPatientInsurance.Rows[0]["CoInsurance"].ToString();
            ddlCoInsuranceTypeWalkout.SelectedValue = dtPatientInsurance.Rows[0]["CoInsuranceType"].ToString();
            txtDeductableWalkout.Value = dtPatientInsurance.Rows[0]["Deductable"].ToString();
            ddlDeductableTypeWalkout.SelectedValue = dtPatientInsurance.Rows[0]["DeductableType"].ToString();
            
            ddlRelationshipWalkout.SelectedValue = dtPatientInsurance.Rows[0]["Relationship"].ToString();
            
            hdnSubscriberIdWalkoutEdit.Value = dtPatientInsurance.Rows[0]["SubscriberId"].ToString().Trim();
            
            if (hdnSubscriberIdWalkoutEdit.Value != "0")
            {
                txtSubscriberFirstNameWalkout.Value = dtPatientInsurance.Rows[0]["FirstName"].ToString();
                txtSubscriberLastNameWalkout.Value = dtPatientInsurance.Rows[0]["LastName"].ToString();
            }
            else
            {
                txtSubscriberFirstNameWalkout.Value = dtPatientInsurance.Rows[0]["PatientFirstName"].ToString();
                txtSubscriberLastNameWalkout.Value = dtPatientInsurance.Rows[0]["PatientLastName"].ToString();
            }
        }
    }
    
    private void Save()
    {
        long PatientInsuranceId  = 0;

        JavaScriptSerializer objJavaScriptSerializer = new JavaScriptSerializer();

        PatientInsuranceDB objPatientInsuranceDB = new PatientInsuranceDB();

        PatientInsurance objPatientInsurance = objJavaScriptSerializer.Deserialize<PatientInsurance>(Request.Form["objPatientInsurance"]);

        if (objPatientInsurance.PatientInsuranceId == 0)
        {
            objPatientInsurance.CreatedById = Profile.UserId;
            objPatientInsurance.CreatedDate = DateTime.Now;
            
            PatientInsuranceId = objPatientInsuranceDB.Add(objPatientInsurance);
        }
        else
        {
            PatientInsuranceId = objPatientInsurance.PatientInsuranceId;
            objPatientInsurance.ModifiedById = Profile.UserId;
            objPatientInsurance.ModifiedDate = DateTime.Now;

            objPatientInsuranceDB.Update(objPatientInsurance);
        }
        
        ltrPatientInsuranceId.Text = PatientInsuranceId.ToString();
    }
}