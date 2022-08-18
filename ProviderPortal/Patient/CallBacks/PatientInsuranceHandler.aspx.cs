using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class EMR_Patient_CallBacks_PatientInsuranceHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long PatientId = Convert.ToInt64(Request.Form["PatientId"]);

        if (PatientId > 0)
        {
            PatientInsuranceDB ObjPatientInsuranceDB = new PatientInsuranceDB();
            DataTable ddtPatientInsurance = ObjPatientInsuranceDB.PatientInsurance_GetByPatientId(PatientId);
            if (ddtPatientInsurance.Rows.Count > 0)
            {
                for (int i = 0; i < ddtPatientInsurance.Rows.Count; i++)
                {

                    char PriSecOthType = Convert.ToChar(ddtPatientInsurance.Rows[i]["PriSecOthType"]);
                    if (PriSecOthType == 'P')
                    {
                        divPrimaryInsuranceView.Style.Add("display", "");
                        divPrimaryInsuranceAdd.Style.Add("display", "none");
                        hdnPatientPrimaryInsuranceId.Value = ddtPatientInsurance.Rows[i]["PatientInsuranceId"].ToString();
                        hdnPrimaryInsuranceId.Value = ddtPatientInsurance.Rows[i]["InsuranceId"].ToString();
                        txtPrimaryInsurance.Value = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        txtPrimaryPolicyNo.Value = ddtPatientInsurance.Rows[i]["PolicyNumber"].ToString();
                        txtPrimaryGroupNo.Value = ddtPatientInsurance.Rows[i]["GroupNumber"].ToString();
                        txtPrimaryGroupName.Value = ddtPatientInsurance.Rows[i]["GroupName"].ToString();
                        ddlPrimaryRelationship.SelectedValue = ddtPatientInsurance.Rows[i]["Relationship"].ToString();
                        txtPrimaryEffectiveDate.Value = ddtPatientInsurance.Rows[i]["EffectiveDate"].ToString();
                        txtPrimaryTerminationDate.Value = ddtPatientInsurance.Rows[i]["TerminationDate"].ToString();
                        txtPrimaryCopay.Value = ddtPatientInsurance.Rows[i]["CoPay"].ToString();
                        ddlPrimaryCoPayType.SelectedValue = ddtPatientInsurance.Rows[i]["CoPayType"].ToString();
                        txtPrimaryCoInsurance.Value = ddtPatientInsurance.Rows[i]["CoInsurance"].ToString();
                        ddlPrimaryCoInsuranceType.SelectedValue = ddtPatientInsurance.Rows[i]["CoInsuranceType"].ToString();
                        txtPrimaryDeductable.Value = ddtPatientInsurance.Rows[i]["Deductable"].ToString();
                        ddlPrimaryDeductableType.SelectedValue = ddtPatientInsurance.Rows[i]["DeductableType"].ToString();
                        hdnPrimarySubscriberId.Value = ddtPatientInsurance.Rows[i]["SubscriberId"].ToString();

                        if (hdnPrimarySubscriberId.Value != "0")
                        {
                            txtPrimarySubscriberFirstName.Value = ddtPatientInsurance.Rows[i]["FirstName"].ToString();
                            txtPrimarySubscriberLastName.Value = ddtPatientInsurance.Rows[i]["LastName"].ToString();
                        }
                        else
                        {
                            txtPrimarySubscriberFirstName.Value = ddtPatientInsurance.Rows[i]["PatientFirstName"].ToString();
                            txtPrimarySubscriberLastName.Value = ddtPatientInsurance.Rows[i]["PatientLastName"].ToString();
                        }

                        ddlPrimaryRelationship.SelectedValue = ddtPatientInsurance.Rows[i]["Relationship"].ToString();


                        lblPrimaryInsurance.Text = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        lblPrimaryPolicyNo.Text = ddtPatientInsurance.Rows[i]["PolicyNumber"].ToString();
                        lblPrimaryGroupNo.Text = ddtPatientInsurance.Rows[i]["GroupNumber"].ToString();
                        lblPrimaryGroupName.Text = ddtPatientInsurance.Rows[i]["GroupName"].ToString();
                        lblPrimaryEffectiveDate.Text = ddtPatientInsurance.Rows[i]["EffectiveDate"].ToString();
                        lblPrimaryTerminationDate.Text = ddtPatientInsurance.Rows[i]["TerminationDate"].ToString();
                        lblPrimaryCoPay.Text = ddtPatientInsurance.Rows[i]["CoPay"].ToString();
                        lblPrimaryCoPayType.Text = ddlPrimaryCoPayType.SelectedItem.Text;
                        lblPrimaryCoInsurance.Text = ddtPatientInsurance.Rows[i]["CoInsurance"].ToString();
                        lblPrimaryCoInsuranceType.Text = ddlPrimaryCoInsuranceType.SelectedItem.Text;
                        lblPrimaryDeductable.Text = ddtPatientInsurance.Rows[i]["Deductable"].ToString();
                        lblPrimaryDeductableType.Text = ddlPrimaryDeductableType.SelectedItem.Text;
                        lblPrimaryRelationship.Text = ddlPrimaryRelationship.SelectedItem.Text;

                        if (hdnPrimarySubscriberId.Value != "0")
                        {
                            lblPrimarySubscriberFirstName.Text = ddtPatientInsurance.Rows[i]["FirstName"].ToString();
                            lblPrimarySubscriberLastName.Text = ddtPatientInsurance.Rows[i]["LastName"].ToString();
                        }
                        else
                        {
                            lblPrimarySubscriberFirstName.Text = ddtPatientInsurance.Rows[i]["PatientFirstName"].ToString();
                            lblPrimarySubscriberLastName.Text = ddtPatientInsurance.Rows[i]["PatientLastName"].ToString();
                        }
                    }


                    if (PriSecOthType == 'S')
                    {
                        divSecondaryInsuranceView.Style.Add("display", "");
                        divSecondaryInsuranceAdd.Style.Add("display", "none");
                        hdnPatientSecondaryInsuranceId.Value = ddtPatientInsurance.Rows[i]["PatientInsuranceId"].ToString();
                        hdnSecondaryInsuranceId.Value = ddtPatientInsurance.Rows[i]["InsuranceId"].ToString();
                        txtSecondaryInsurance.Value = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        txtSecondaryPolicyNo.Value = ddtPatientInsurance.Rows[i]["PolicyNumber"].ToString();
                        txtSecondaryGroupNo.Value = ddtPatientInsurance.Rows[i]["GroupNumber"].ToString();
                        txtSecondaryGroupName.Value = ddtPatientInsurance.Rows[i]["GroupName"].ToString();
                        ddlSecondaryRelationship.SelectedValue = ddtPatientInsurance.Rows[i]["Relationship"].ToString();
                        txtSecondaryEffectiveDate.Value = ddtPatientInsurance.Rows[i]["EffectiveDate"].ToString();
                        txtSecondaryTerminationDate.Value = ddtPatientInsurance.Rows[i]["TerminationDate"].ToString();
                        txtSecondaryCopay.Value = ddtPatientInsurance.Rows[i]["CoPay"].ToString();
                        ddlSecondaryCoPayType.SelectedValue = ddtPatientInsurance.Rows[i]["CoPayType"].ToString();
                        txtSecondaryCoInsurance.Value = ddtPatientInsurance.Rows[i]["CoInsurance"].ToString();
                        ddlSecondaryCoInsuranceType.SelectedValue = ddtPatientInsurance.Rows[i]["CoInsuranceType"].ToString();
                        txtSecondaryDeductable.Value = ddtPatientInsurance.Rows[i]["Deductable"].ToString();
                        ddlSecondaryDeductableType.SelectedValue = ddtPatientInsurance.Rows[i]["DeductableType"].ToString();
                        hdnSecondarySubscriberId.Value = ddtPatientInsurance.Rows[i]["SubscriberId"].ToString();

                        if (hdnSecondarySubscriberId.Value != "0")
                        {
                            txtSecondarySubscriberFirstName.Value = ddtPatientInsurance.Rows[i]["FirstName"].ToString();
                            txtSecondarySubscriberLastName.Value = ddtPatientInsurance.Rows[i]["LastName"].ToString();
                        }
                        else
                        {
                            txtSecondarySubscriberFirstName.Value = ddtPatientInsurance.Rows[i]["PatientFirstName"].ToString();
                            txtSecondarySubscriberLastName.Value = ddtPatientInsurance.Rows[i]["PatientLastName"].ToString();
                        }
                        
                        ddlSecondaryRelationship.SelectedValue = ddtPatientInsurance.Rows[i]["Relationship"].ToString();

                        lblSecondaryInsurance.Text = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        lblSecondaryPolicyNo.Text = ddtPatientInsurance.Rows[i]["PolicyNumber"].ToString();
                        lblSecondaryGroupNo.Text = ddtPatientInsurance.Rows[i]["GroupNumber"].ToString();
                        lblSecondaryGroupName.Text = ddtPatientInsurance.Rows[i]["GroupName"].ToString();
                        lblSecondaryEffectiveDate.Text = ddtPatientInsurance.Rows[i]["EffectiveDate"].ToString();
                        lblSecondaryTerminationDate.Text = ddtPatientInsurance.Rows[i]["TerminationDate"].ToString();
                        lblSecondarycopay.Text = ddtPatientInsurance.Rows[i]["CoPay"].ToString();
                        lblSecondaryCoPayType.Text = ddlSecondaryCoPayType.SelectedItem.Text;
                        lblSecondaryCoInsurance.Text = ddtPatientInsurance.Rows[i]["CoInsurance"].ToString();
                        lblSecondaryCoInsuranceType.Text = ddlSecondaryCoInsuranceType.SelectedItem.Text;
                        lblSecondaryDeductable.Text = ddtPatientInsurance.Rows[i]["Deductable"].ToString();
                        lblSecondaryDeductableType.Text = ddlSecondaryDeductableType.SelectedItem.Text;

                        if (hdnSecondarySubscriberId.Value != "0")
                        {
                            lblSecondarySubscriberFirstName.Text = ddtPatientInsurance.Rows[i]["FirstName"].ToString();
                            lblSecondarySubscriberLastName.Text = ddtPatientInsurance.Rows[i]["LastName"].ToString();
                        }
                        else
                        {
                            lblSecondarySubscriberFirstName.Text = ddtPatientInsurance.Rows[i]["PatientFirstName"].ToString();
                            lblSecondarySubscriberLastName.Text = ddtPatientInsurance.Rows[i]["PatientLastName"].ToString();
                        }
                        
                        lblSecondaryRelationship.Text = ddlSecondaryRelationship.SelectedItem.Text;

                    }


                    if (PriSecOthType == 'O')
                    {
                        divOtherInsuranceView.Style.Add("display", "");
                        divOtherInsuranceAdd.Style.Add("display", "none");
                        txtOtherInsurance.Value = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        hdnOtherInsuranceId.Value = ddtPatientInsurance.Rows[i]["InsuranceId"].ToString();
                        hdnPatientOtherInsuranceId.Value = ddtPatientInsurance.Rows[i]["PatientInsuranceId"].ToString();
                        txtOtherCoInsurance.Value = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        txtOtherPolicyNo.Value = ddtPatientInsurance.Rows[i]["PolicyNumber"].ToString();
                        txtOtherGroupNo.Value = ddtPatientInsurance.Rows[i]["GroupNumber"].ToString();
                        txtOtherGroupName.Value = ddtPatientInsurance.Rows[i]["GroupName"].ToString();
                        ddlOtherRelationship.SelectedValue = ddtPatientInsurance.Rows[i]["Relationship"].ToString();
                        txtOtherEffectiveDate.Value = ddtPatientInsurance.Rows[i]["EffectiveDate"].ToString();
                        txtOtherTerminationDate.Value = ddtPatientInsurance.Rows[i]["TerminationDate"].ToString();
                        txtOtherCopay.Value = ddtPatientInsurance.Rows[i]["CoPay"].ToString();
                        ddlOtherCoPayType.SelectedValue = ddtPatientInsurance.Rows[i]["CoPayType"].ToString();
                        txtOtherCoInsurance.Value = ddtPatientInsurance.Rows[i]["CoInsurance"].ToString();
                        ddlOtherCoInsuranceType.SelectedValue = ddtPatientInsurance.Rows[i]["CoInsuranceType"].ToString();
                        txtOtherDeductable.Value = ddtPatientInsurance.Rows[i]["Deductable"].ToString();
                        ddlOtherDeductableType.SelectedValue = ddtPatientInsurance.Rows[i]["DeductableType"].ToString();
                        hdnOtherSubscriberId.Value = ddtPatientInsurance.Rows[i]["SubscriberId"].ToString();

                        if (hdnOtherSubscriberId.Value != "0")
                        {
                            txtOtherSubscriberFirstName.Value = ddtPatientInsurance.Rows[i]["FirstName"].ToString();
                            txtOtherSubscriberLastName.Value = ddtPatientInsurance.Rows[i]["LastName"].ToString();
                        }
                        else
                        {
                            txtOtherSubscriberFirstName.Value = ddtPatientInsurance.Rows[i]["PatientFirstName"].ToString();
                            txtOtherSubscriberLastName.Value = ddtPatientInsurance.Rows[i]["PatientLastName"].ToString();
                        }

                        ddlOtherRelationship.SelectedValue = ddtPatientInsurance.Rows[i]["Relationship"].ToString();

                        lblOtherInsurance.Text = ddtPatientInsurance.Rows[i]["InsuranceName"].ToString();
                        lblOtherPolicyNo.Text = ddtPatientInsurance.Rows[i]["PolicyNumber"].ToString();
                        lblOtherGroupNo.Text = ddtPatientInsurance.Rows[i]["GroupNumber"].ToString();
                        lblOtherGroupName.Text = ddtPatientInsurance.Rows[i]["GroupName"].ToString();
                        lblOtherEffectiveDate.Text = ddtPatientInsurance.Rows[i]["EffectiveDate"].ToString();
                        lblOtherTerminationDate.Text = ddtPatientInsurance.Rows[i]["TerminationDate"].ToString();
                        lblOthercopay.Text = ddtPatientInsurance.Rows[i]["CoPay"].ToString();
                        lblOtherCoPayType.Text = ddlOtherCoPayType.SelectedItem.Text;
                        lblOtherCoInsurance.Text = ddtPatientInsurance.Rows[i]["CoInsurance"].ToString();
                        lblOtherCoInsuranceType.Text = ddlOtherCoInsuranceType.SelectedItem.Text;
                        lblOtherDeductable.Text = ddtPatientInsurance.Rows[i]["Deductable"].ToString();
                        lblotherDeductableType.Text = ddlOtherDeductableType.SelectedItem.Text;
                        
                        if (hdnOtherSubscriberId.Value != "0")
                        {
                            lblOtherSubscriberFirstName.Text = ddtPatientInsurance.Rows[i]["FirstName"].ToString();
                            lblOtherSubscriberLastName.Text = ddtPatientInsurance.Rows[i]["LastName"].ToString();
                        }
                        else
                        {
                            lblOtherSubscriberFirstName.Text = ddtPatientInsurance.Rows[i]["PatientFirstName"].ToString();
                            lblOtherSubscriberLastName.Text = ddtPatientInsurance.Rows[i]["PatientLastName"].ToString();
                        }
                        
                        lblOtherRelationship.Text = ddlOtherRelationship.SelectedItem.Text;
                    }
                }
            }
        }

        //if (txtPrimaryInsurance.Value == "")
        //{
        //    tblPrimaryInsurance.Attributes.Add("class", "Hide tblPatientDemographics");
        //    tblViewPrimaryInsurance.Attributes.Add("class", "Hide");
        //    DivViewPrimaryInsuranceControls.Attributes.Add("class", "Hide");
        //    DivPrimaryInsuranceControls.Attributes.Add("class", "Hide");
        //    btnAddNewPrimaryInsurance.Attributes.Add("class", "Show");


        //}
        //if (txtSecondaryInsurance.Value == "")
        //{
        //    DivSecondaryInsuranceControls.Attributes.Add("class", "Hide");
        //    tblSecondaryInsurance.Attributes.Add("class", "Hide tblPatientDemographics");
        //    DivViewSecondaryControls.Attributes.Add("class", "Hide");
        //    tblViewSecondaryInsurance.Attributes.Add("class", "Hide");
        //    btnAddNewSecondaryInsurance.Attributes.Add("class", "Show");
        //}
        //if (txtOtherInsurance.Value == "")
        //{
        //    DivOtherInsuranceControls.Attributes.Add("class", "Hide");
        //    tblOtherInsurance.Attributes.Add("class", "Hide tblPatientDemographics");
        //    DivViewOhterInsuranceControls.Attributes.Add("class", "Hide");
        //    tblViewOtherInsurance.Attributes.Add("class", "Hide");
        //    btnAddNewOtherInsurance.Attributes.Add("class", "Show");
        //}
        if (ddlPrimaryRelationship.SelectedItem.Text == "Self")
        {
            PrimarySubscribertd.Attributes.Add("class", "HideInsurance");

        }
        //if (ddlSecondaryRelationship.SelectedItem.Text == "Self")
        //    SecondarySubscribertd.Attributes.Add("class", "HideInsurance");
        //if (ddlOtherRelationship.SelectedItem.Text == "Self")
        //    OtherSubscribertd.Attributes.Add("class", "HideInsurance");

        CommonDB objCommonDB = new CommonDB();
        DataTable ddtInsurance = objCommonDB.Insurance_GetAll(Profile.PracticeId);

    }
}