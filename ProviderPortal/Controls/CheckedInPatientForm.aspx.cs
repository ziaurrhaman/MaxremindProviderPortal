using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

public partial class EMR_Controls_CheckedInPatientForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.Form["action"];
        
        if (action == "LoadCheckInForm")
        {
            LoadCheckInForm();
        }
    }
    
    public void LoadCheckInForm()
    {
        long PatientId = long.Parse(Request.Form["PatientId"]);
        long PracticeLocationsId = long.Parse(Request.Form["PracticeLocationsId"]);
        
        CheckedInPatientsDB objCheckedInPatientsDB = new CheckedInPatientsDB();
        DataSet dsCheckInFormInfo = objCheckedInPatientsDB.GetInfoForCheckInForm(PatientId, PracticeLocationsId);
        
        DataTable dtRooms = dsCheckInFormInfo.Tables[0];
        
        ddlPracticeRoomsCheckInForm.DataSource = dtRooms;
        ddlPracticeRoomsCheckInForm.DataValueField = "RoomId";
        ddlPracticeRoomsCheckInForm.DataTextField = "Name";
        ddlPracticeRoomsCheckInForm.DataBind();
        
        DataTable dtPatient = dsCheckInFormInfo.Tables[1];
        DataTable dtPatientInsurance = dsCheckInFormInfo.Tables[2];
        
        SetPatientInfo(dtPatient);

        SetPatientInsurances(dtPatientInsurance);
    }
    
    private void SetPatientInfo(DataTable dtPatient)
    {
        if (dtPatient.Rows.Count == 0) return;

        string PatientId = dtPatient.Rows[0]["PatientId"].ToString();
        string LastName = dtPatient.Rows[0]["LastName"].ToString();
        string FirstName = dtPatient.Rows[0]["FirstName"].ToString();
        string DOB = dtPatient.Rows[0]["DateOfBirth"].ToString();
        string Gender = dtPatient.Rows[0]["Gender"].ToString();
        string PatientMaritalStatus = dtPatient.Rows[0]["MaritalStatus"].ToString();
        string PatientCellNo = dtPatient.Rows[0]["Cell"].ToString();
        string PatientHomeNo = dtPatient.Rows[0]["HomePhone"].ToString();
        string PatientWorkNo = dtPatient.Rows[0]["WorkPhone"].ToString();
        string PatientCity = dtPatient.Rows[0]["City"].ToString();
        string PatientState = dtPatient.Rows[0]["State"].ToString();
        string PatientZip = dtPatient.Rows[0]["Zip"].ToString();
        
        string PracticeId = dtPatient.Rows[0]["PracticeId"].ToString();
        string ProfilePicturePath = dtPatient.Rows[0]["ImagePath"].ToString();
        
        hdnPatientIdCheckInForm.Value = PatientId;
        
        string PatientName = LastName + " " + FirstName;
        
        string DateOfBirth = "";
        
        if (DOB != "")
        {
            DateOfBirth = DOB + ", ";
        }
        
        string GenderMaritalStatus = Gender + ", " + PatientMaritalStatus;
        
        /*Start Phone Number*/
        string Phone = "", Cell = "", HomePhone = "", WorkPhone = "";
        
        if (PatientCellNo != "")
        {
            Cell = PatientCellNo + ", ";
        }
        
        if (PatientHomeNo != "")
        {
            HomePhone = PatientHomeNo + ", ";
        }
        
        if (PatientWorkNo != "")
        {
            WorkPhone = PatientWorkNo;
        }
        
        Phone = Cell.ToString() + HomePhone.ToString() + WorkPhone.ToString();
        /*End Phone Number*/
        
        
        /*Start Address*/
        string PatientAddress = "", City = "", State = "", Zip = "", Address = "";

        if (PatientAddress != "")
        {
            Address = PatientAddress + ", ";
        }

        if (PatientCity != "")
        {
            City = PatientCity + ", ";
        }

        if (PatientState != "")
        {
            State = PatientState + ", ";
        }

        if (PatientZip != "")
        {
            Zip = PatientZip;
        }

        PatientAddress = Address.ToString() + City.ToString() + State.ToString() + Zip.ToString();
        /*End Address*/

        imgPatientPhoto.Src = ResolveUrl(ConfigurationManager.AppSettings["PatientPhoto"].ToString() + "/" + PracticeId + "/Patients/" + PatientId + "/" + ProfilePicturePath);

        spnAccountNo.InnerHtml = PatientId.ToString();
        spnPatientName.InnerHtml = PatientName;
        spnPatientDOB.InnerHtml = DateOfBirth;
        spnPatientGenderMaritalStatus.InnerHtml = GenderMaritalStatus;
        spnPatientPhone.InnerHtml = Phone;
        spnPatientAddress.InnerHtml = PatientAddress;
    }

    private void SetPatientInsurances(DataTable dtPatientInsurance)
    {
        for (int i = 0; i < dtPatientInsurance.Rows.Count; i++)
        {
            DataRow drPatientInsurance = dtPatientInsurance.Rows[i];
            string PriSecOthType = drPatientInsurance["PriSecOthType"].ToString();

            if (PriSecOthType == "P")
            {
                hdnPrimaryInsuranceIdCheckInForm.Value = drPatientInsurance["InsuranceId"].ToString();
                hdnPatientPrimaryInsuranceIdCheckInForm.Value = drPatientInsurance["PatientInsuranceId"].ToString();

                lblPrimaryInsuranceNameCheckInForm.Text = drPatientInsurance["InsuranceName"].ToString();
                lblPrimaryInsurancePolicyNumberCheckInForm.Text = drPatientInsurance["PolicyNumber"].ToString();
                lblPrimaryInsuranceGroupNumberCheckInForm.Text = drPatientInsurance["GroupNumber"].ToString();
                lblPrimaryInsuranceGroupNameCheckInForm.Text = drPatientInsurance["GroupName"].ToString();

                lblPrimaryInsuranceCopayCheckInForm.Text = drPatientInsurance["CoPay"].ToString();
                lblPrimaryInsuranceCopayTypeCheckInForm.Text = drPatientInsurance["CoPayType"].ToString();
                lblPrimaryInsuranceCoinsuranceCheckInForm.Text = drPatientInsurance["CoInsurance"].ToString();
                lblPrimaryInsuranceCoinsuranceTypeCheckInForm.Text = drPatientInsurance["CoInsuranceType"].ToString();
                lblPrimaryInsuranceDeductableCheckInForm.Text = drPatientInsurance["Deductable"].ToString();
                lblPrimaryInsuranceDeductableTypeCheckInForm.Text = drPatientInsurance["DeductableType"].ToString();

                lblPrimaryInsuranceRelationshipCheckInForm.Text = drPatientInsurance["Relationship"].ToString();

                hdnPrimaryInsuranceSubscriberIdCheckInForm.Value = drPatientInsurance["SubscriberId"].ToString().Trim();

                if (hdnPrimaryInsuranceSubscriberIdCheckInForm.Value != "0")
                {
                    lblPrimaryInsuranceSubscriberLastNameCheckInForm.Text = drPatientInsurance["LastName"].ToString();
                    lblPrimaryInsuranceSubscriberFirstNameCheckInForm.Text = drPatientInsurance["FirstName"].ToString();
                }
                else
                {
                    lblPrimaryInsuranceRelationshipCheckInForm.Text = "Self";

                    lblPrimaryInsuranceSubscriberLastNameCheckInForm.Text = drPatientInsurance["PatientLastName"].ToString();
                    lblPrimaryInsuranceSubscriberFirstNameCheckInForm.Text = drPatientInsurance["PatientFirstName"].ToString();
                }


                imgPrimaryInsuranceCardFront.ImageUrl = drPatientInsurance["InsuranceCardFrontFilePath"].ToString();
                imgPrimaryInsuranceCardBack.ImageUrl = drPatientInsurance["InsuranceCardBackFilePath"].ToString();

                hdnPrimaryInsuranceCardFrontFilePath.Value = drPatientInsurance["InsuranceCardFrontFilePath"].ToString();
                hdnPrimaryInsuranceCardBackFilePath.Value = drPatientInsurance["InsuranceCardBackFilePath"].ToString();
            }
            else if (PriSecOthType == "S")
            {
                hdnSecondaryInsuranceIdCheckInForm.Value = drPatientInsurance["InsuranceId"].ToString();
                hdnPatientSecondaryInsuranceIdCheckInForm.Value = drPatientInsurance["PatientInsuranceId"].ToString();

                lblSecondaryInsuranceNameCheckInForm.Text = drPatientInsurance["InsuranceName"].ToString();
                lblSecondaryInsurancePolicyNumberCheckInForm.Text = drPatientInsurance["PolicyNumber"].ToString();
                lblSecondaryInsuranceGroupNumberCheckInForm.Text = drPatientInsurance["GroupNumber"].ToString();
                lblSecondaryInsuranceGroupNameCheckInForm.Text = drPatientInsurance["GroupName"].ToString();

                lblSecondaryInsuranceCopayCheckInForm.Text = drPatientInsurance["CoPay"].ToString();
                lblSecondaryInsuranceCopayTypeCheckInForm.Text = drPatientInsurance["CoPayType"].ToString();
                lblSecondaryInsuranceCoinsuranceCheckInForm.Text = drPatientInsurance["CoInsurance"].ToString();
                lblSecondaryInsuranceCoinsuranceTypeCheckInForm.Text = drPatientInsurance["CoInsuranceType"].ToString();
                lblSecondaryInsuranceDeductableCheckInForm.Text = drPatientInsurance["Deductable"].ToString();
                lblSecondaryInsuranceDeductableTypeCheckInForm.Text = drPatientInsurance["DeductableType"].ToString();

                lblSecondaryInsuranceRelationshipCheckInForm.Text = drPatientInsurance["Relationship"].ToString();

                hdnSecondaryInsuranceSubscriberIdCheckInForm.Value = drPatientInsurance["SubscriberId"].ToString().Trim();

                if (hdnSecondaryInsuranceSubscriberIdCheckInForm.Value != "0")
                {
                    lblSecondaryInsuranceSubscriberLastNameCheckInForm.Text = drPatientInsurance["LastName"].ToString();
                    lblSecondaryInsuranceSubscriberFirstNameCheckInForm.Text = drPatientInsurance["FirstName"].ToString();
                }
                else
                {
                    lblSecondaryInsuranceRelationshipCheckInForm.Text = "Self";

                    lblSecondaryInsuranceSubscriberLastNameCheckInForm.Text = drPatientInsurance["PatientLastName"].ToString();
                    lblSecondaryInsuranceSubscriberFirstNameCheckInForm.Text = drPatientInsurance["PatientFirstName"].ToString();
                }


                imgSecondaryInsuranceCardFront.ImageUrl = drPatientInsurance["InsuranceCardFrontFilePath"].ToString();
                imgSecondaryInsuranceCardBack.ImageUrl = drPatientInsurance["InsuranceCardBackFilePath"].ToString();

                hdnSecondaryInsuranceCardFrontFilePath.Value = drPatientInsurance["InsuranceCardFrontFilePath"].ToString();
                hdnSecondaryInsuranceCardBackFilePath.Value = drPatientInsurance["InsuranceCardBackFilePath"].ToString();
            }
        }
    }
}