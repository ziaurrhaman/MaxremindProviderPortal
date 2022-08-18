using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class EMR_Patient_CallBacks_PersonalInformationHandler : System.Web.UI.Page
{
    string[] _RaceId = null ;
    string [] _EthnicityId = null;
    string _raceText = "";
    string _ethnicityText = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        long PatientId = long.Parse(Request.Form["PatientId"]);
        
        GetAllStates();
        
        GetAllLanguages();
        GetAllRelationship();
        
        
        if (PatientId > 0)
        {
            LoadPatientInformation(PatientId);
            GetPatientBillingInfo(PatientId);
        }
        else
        {
            divPatientInformationEdit.Style.Remove("display");
            divPatientInformationView.Style["display"] = "none";
        }
        GetAllRace();
        GetAllEthnicity();
    }
    
    public void LoadPatientInformation(long PatientId)
    {
        PatientDB ObjPatientDb = new PatientDB();
        DataSet dtPatientInfo = ObjPatientDb.Patient_GetById(PatientId, Profile.PracticeId);
        
        txtFirstName.Value = dtPatientInfo.Tables[0].Rows[0]["FirstName"].ToString();
        txtMiddleName.Value = dtPatientInfo.Tables[0].Rows[0]["MiddleName"].ToString();
        txtLastName.Value = dtPatientInfo.Tables[0].Rows[0]["LastName"].ToString();
        txtDOB.Value = dtPatientInfo.Tables[0].Rows[0]["DateOfBirth"].ToString();
        txtTimeOfBirth.Value = dtPatientInfo.Tables[0].Rows[0]["TimeOfBirth"].ToString();
        txtSSN.Value = dtPatientInfo.Tables[0].Rows[0]["SSN"].ToString();
        _RaceId = dtPatientInfo.Tables[0].Rows[0]["RaceId"].ToString().Split(';');
        _EthnicityId = dtPatientInfo.Tables[0].Rows[0]["EthnicityId"].ToString().Split(';');
        ddlPreferredLanguage.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["PreferredLanguageId"].ToString();

        lblFirstName.Text = dtPatientInfo.Tables[0].Rows[0]["FirstName"].ToString();
        lblMiddleName.Text = dtPatientInfo.Tables[0].Rows[0]["MiddleName"].ToString();
        lblLastName.Text = dtPatientInfo.Tables[0].Rows[0]["LastName"].ToString();
        lblDOBPatient.Text = dtPatientInfo.Tables[0].Rows[0]["DateOfBirth"].ToString();
        lblTimeOfBirthPatient.Text = dtPatientInfo.Tables[0].Rows[0]["TimeOfBirth"].ToString();
        lblSSN.Text = dtPatientInfo.Tables[0].Rows[0]["SSN"].ToString();

        if (ddlPreferredLanguage.SelectedValue == "0")
        {
            lblLanguage.Text = "";
        }
        else
        {
            lblLanguage.Text = ddlPreferredLanguage.SelectedItem.Text;
        }

        lblGenderPatient.Text = dtPatientInfo.Tables[0].Rows[0]["Gender"].ToString();
        lblMaritalStatusPatient.Text = dtPatientInfo.Tables[0].Rows[0]["MaritalStatus"].ToString();
        ddlMaritalStatus.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["MaritalStatus"].ToString();
        txtAddress.Value = dtPatientInfo.Tables[0].Rows[0]["Address"].ToString();
        txtCity.Value = dtPatientInfo.Tables[0].Rows[0]["City"].ToString();
        txtZip.Value = dtPatientInfo.Tables[0].Rows[0]["Zip"].ToString();
        txtHomePhone.Value = dtPatientInfo.Tables[0].Rows[0]["HomePhone"].ToString();
        txtCell.Value = dtPatientInfo.Tables[0].Rows[0]["Cell"].ToString();
        txtWorkPhone.Value = dtPatientInfo.Tables[0].Rows[0]["WorkPhone"].ToString();
        txtExt.Value = dtPatientInfo.Tables[0].Rows[0]["Ext"].ToString();
        txtEmail.Value = dtPatientInfo.Tables[0].Rows[0]["Email"].ToString();
        ddlCCP.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["CCP"].ToString();

        ddlAddressType.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["AddressType"].ToString();
        ddlState.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["State"].ToString();
        ddlGender.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["Gender"].ToString();
        lblAddressPatient.Text = dtPatientInfo.Tables[0].Rows[0]["Address"].ToString();
        lblCityPatient.Text = dtPatientInfo.Tables[0].Rows[0]["City"].ToString();
        lblZipPatient.Text = dtPatientInfo.Tables[0].Rows[0]["Zip"].ToString();
        lblHomePhonePatient.Text = dtPatientInfo.Tables[0].Rows[0]["HomePhone"].ToString();
        lblCellPatient.Text = dtPatientInfo.Tables[0].Rows[0]["Cell"].ToString();
        lblWorkPhonePatient.Text = dtPatientInfo.Tables[0].Rows[0]["WorkPhone"].ToString();
        lblExt.Text = dtPatientInfo.Tables[0].Rows[0]["Ext"].ToString();
        lblEmail.Text = dtPatientInfo.Tables[0].Rows[0]["Email"].ToString();
        lblAddressType.Text = ddlAddressType.SelectedItem.Text;
        lblStatePatient.Text = ddlState.SelectedItem.Text;
        lblCCP.Text = ddlCCP.SelectedItem.Text;
        lblCommunicationBarrier.Text = dtPatientInfo.Tables[0].Rows[0]["CommunicationBarrier"].ToString();
        ddlCommunicationBarriers.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["CommunicationBarrier"].ToString();
        txtGuarantorFirstName.Value = dtPatientInfo.Tables[0].Rows[0]["GuarantorFirstName"].ToString();
        txtGuarantorLastName.Value = dtPatientInfo.Tables[0].Rows[0]["GuarantorLastName"].ToString();
        ddlRelationship.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["GuarantorRelationship"].ToString();

        lblGuarantorFirstName.Text = dtPatientInfo.Tables[0].Rows[0]["GuarantorFirstName"].ToString();
        lblGuarantorLastName.Text = dtPatientInfo.Tables[0].Rows[0]["GuarantorLastName"].ToString();

        if (ddlRelationship.SelectedValue == "0")
        {
            lblRelationship.Text = "";
        }
        else
        {
            lblRelationship.Text = ddlRelationship.SelectedItem.Text;
        }
        hdnFinancialGuarantorId.Value = dtPatientInfo.Tables[0].Rows[0]["FinancialGuarantorId"].ToString();
        txtEmergencyContactName.Value = dtPatientInfo.Tables[0].Rows[0]["EmergencyContactName"].ToString();
        txtEmergencyContact.Value = dtPatientInfo.Tables[0].Rows[0]["Phone"].ToString();
        ddlEmergencyRelationship.SelectedValue = dtPatientInfo.Tables[0].Rows[0]["Relationship"].ToString();

        lblEmergencyContactName.Text = dtPatientInfo.Tables[0].Rows[0]["EmergencyContactName"].ToString();
        lblEmergencyContactNo.Text = dtPatientInfo.Tables[0].Rows[0]["Phone"].ToString();

        if (ddlEmergencyRelationship.SelectedItem.Text == "Select")
        {
            lblEmergencyRelationship.Text = "";
        }
        else
        {
            lblEmergencyRelationship.Text = ddlEmergencyRelationship.SelectedItem.Text;
        }

        txtDisabilityDate.Value = dtPatientInfo.Tables[0].Rows[0]["DisabilityDate"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["DisabilityDate"].ToString();
        txtDeathDate.Value = dtPatientInfo.Tables[0].Rows[0]["DeathDate"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["DeathDate"].ToString();
        txtCauseOfDeath.Value = dtPatientInfo.Tables[0].Rows[0]["CauseOfDeath"].ToString();

        lblDisabilityDate.Text = dtPatientInfo.Tables[0].Rows[0]["DisabilityDate"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["DisabilityDate"].ToString();
        lblDeathDate.Text = dtPatientInfo.Tables[0].Rows[0]["DeathDate"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["DeathDate"].ToString();
        lblCauseOfDeath.Text = dtPatientInfo.Tables[0].Rows[0]["CauseOfDeath"].ToString();

        string PharmacyName = dtPatientInfo.Tables[0].Rows[0]["StoreName"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["StoreName"].ToString();
        string Address = dtPatientInfo.Tables[0].Rows[0]["PharmacyAddress"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["PharmacyAddress"].ToString();
        string Phone = dtPatientInfo.Tables[0].Rows[0]["PharmacyPhone"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["PharmacyPhone"].ToString();
        string City = dtPatientInfo.Tables[0].Rows[0]["PharmacyCity"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["PharmacyCity"].ToString();
        string State = dtPatientInfo.Tables[0].Rows[0]["PharmacyState"] == DBNull.Value ? "" : dtPatientInfo.Tables[0].Rows[0]["PharmacyState"].ToString();

        if (PharmacyName != "")
        {
            txtPharmacyInfo.Value = PharmacyName + " [" + Address + "," + City + "," + State + "," + "," + Phone + " ]";
            lblPharmacyInfo.Text = txtPharmacyInfo.Value;
        }

        hdnPatientNCPDP.Value = dtPatientInfo.Tables[0].Rows[0]["NCPDP"].ToString();

        
        lblPatientUserName.Text = dtPatientInfo.Tables[0].Rows[0]["UserName"].ToString();
        txtPatientUserName.Value= dtPatientInfo.Tables[0].Rows[0]["UserName"].ToString();
        hdnPassword.Value = dtPatientInfo.Tables[0].Rows[0]["Password"].ToString();
        if (!string.IsNullOrEmpty(dtPatientInfo.Tables[0].Rows[0]["ActiveWebAccount"].ToString()))
        {
            cbIsActiveWebAccount.Checked = bool.Parse(dtPatientInfo.Tables[0].Rows[0]["ActiveWebAccount"].ToString());
            cbIsActiveWebAccountView.Checked = bool.Parse(dtPatientInfo.Tables[0].Rows[0]["ActiveWebAccount"].ToString());
        }
    }
    
    public void GetAllStates()
    {
        StatesDB objStatesDB = new StatesDB();
        ddlState.DataSource = objStatesDB.GetAllAsDataTable();
        ddlState.DataValueField = "StateCode";
        ddlState.DataTextField = "StateName";
        ddlState.DataBind();
    }

    public void GetAllRace()
    {
        RaceDB objRaceDB = new RaceDB();
        rptRace.DataSource = objRaceDB.GetAllRace();
        rptRace.DataBind();

        if (_raceText.Length > 0)
        {
            if (_raceText.Length > 26)
            {
                lblRaceSelected.Text = _raceText.Substring(0, 26) + "..";
                lblRace.Text = lblRaceSelected.Text;
                lblRace.ToolTip = _raceText;
            }
            else
            {
                lblRaceSelected.Text = _raceText.Substring(0, _raceText.Length - 1);
                lblRace.Text = lblRaceSelected.Text;
                lblRace.ToolTip = _raceText;
            }
        }
    }

    public void GetAllEthnicity()
    {
        EthnicityDB objEthnicityDB = new EthnicityDB();
        rptEthnicity.DataSource = objEthnicityDB.GetAllEthnicity();
        rptEthnicity.DataBind();
        if (_ethnicityText.Length > 0)
        {
            if (_ethnicityText.Length > 26)
            {
                lblEthnicitySelected.Text = _ethnicityText.Substring(0, 26) + "..";
                lblEthnicity.Text = lblEthnicitySelected.Text;
                lblEthnicity.ToolTip = _raceText;
            }
            else
            {
                lblEthnicitySelected.Text = _ethnicityText.Substring(0, _ethnicityText.Length - 1);
                lblEthnicity.Text = lblEthnicitySelected.Text;
                lblEthnicity.ToolTip = _raceText;
            }
        }
    }

    public void GetAllLanguages()
    {
        LanguagesDB ObjLanguagesDB = new LanguagesDB();
        ddlPreferredLanguage.DataSource = ObjLanguagesDB.GetAllLanguages();
        ddlPreferredLanguage.DataValueField = "LanguageId";
        ddlPreferredLanguage.DataTextField = "Name";
        ddlPreferredLanguage.DataBind();
    }

    public void GetAllRelationship()
    {
        RelationshipDB ObjRelationshipDB = new RelationshipDB();
        DataTable ddtRelationship = ObjRelationshipDB.Relationship_GetAll();
        ddlRelationship.DataSource = ddtRelationship;
        ddlRelationship.DataValueField = "Code";
        ddlRelationship.DataTextField = "Definition";
        ddlRelationship.DataBind();

        ddlEmergencyRelationship.DataSource = ddtRelationship;
        ddlEmergencyRelationship.DataValueField = "Code";
        ddlEmergencyRelationship.DataTextField = "Definition";
        ddlEmergencyRelationship.DataBind();
    }

    public void GetPatientBillingInfo(long PatientId)
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

    protected void rptRace_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if (_RaceId != null)
            {
                string raceId = drv["RaceId"].ToString();
                for (int i = 0; i <= _RaceId.Length-1; i++)
                {
                    if (raceId == _RaceId[i])
                    {
                        CheckBox cbRace = e.Item.FindControl("cbRace") as CheckBox;
                        cbRace.Checked = true;
                        _raceText += cbRace.Text+",";
                    }
                }
            }
            
        }
    }

    protected void rptEthnicity_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            if (_EthnicityId != null)
            {
                string ethnicityId = drv["EthnicityId"].ToString();
                for (int i = 0; i <= _EthnicityId.Length-1; i++)
                {
                    if (ethnicityId == _EthnicityId[i])
                    {
                        CheckBox cbEthnicity = e.Item.FindControl("cbEthnicity") as CheckBox;
                        cbEthnicity.Checked = true;
                        _ethnicityText += cbEthnicity.Text + ",";
                    }
                }
            }
        }
    }
}