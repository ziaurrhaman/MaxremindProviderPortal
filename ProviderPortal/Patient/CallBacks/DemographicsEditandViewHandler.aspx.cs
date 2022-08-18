using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ProviderPortal_Patient_CallBacks_DemographicsEditandViewHandler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Form["action"] == "getLevel2Detail")
        {
            PatientPaymentDetailLevel2();
            return;
        }
        else if (Request.Form["action"] == "PatientSearch")
        {
            long PatientID = Convert.ToInt32(Request.Form["patientID"]);
            PatientSearchData(PatientID);
            return;
        }

        else if (Request.Form["action"] == "GetBalanceGrid")
        {
            GetBalanceGrid();
            return;
        }
        else
        {
            if (!string.IsNullOrEmpty(Request.Form["PatientId"].ToString())){
                long PatientId = long.Parse(Request.Form["PatientId"]);
                GetPatientRelatedData();
                if (PatientId != 0)
                {
                    LoadPatientInformation(PatientId);

                }
            }
            
        }
        
    }
    string[] _RaceId = null;
    string[] _EthnicityId = null;
    string _raceText = "";
    string _ethnicityText = "";

    public void LoadPatientInformation(long PatientId)
    {
        PatientDB ObjPatientDb = new PatientDB();
        DataSet dtPatientInfo1 = ObjPatientDb.Patient_GetById(PatientId, Profile.PracticeId);

        DataTable dtEthnicity = dtPatientInfo1.Tables[2];
        if (dtEthnicity.Rows.Count > 0)
        {
            lblEthnicity.Text = dtEthnicity.Rows[0][0].ToString();
        }
        DataTable dtRace = dtPatientInfo1.Tables[1];
        if (dtRace.Rows.Count > 0)
        {
            lblRace.Text = dtRace.Rows[0][0].ToString();
        }
        DataTable dtPatientInfo = dtPatientInfo1.Tables[0];


        txtFirstName.Value = dtPatientInfo.Rows[0]["FirstName"].ToString();
        txtMiddleName.Value = dtPatientInfo.Rows[0]["MiddleName"].ToString();
        txtLastName.Value = dtPatientInfo.Rows[0]["LastName"].ToString();
        txtDOB.Value = dtPatientInfo.Rows[0]["DateOfBirth"].ToString();
        txtTimeOfBirth.Value = dtPatientInfo.Rows[0]["TimeOfBirth"].ToString();
        txtSSN.Value = dtPatientInfo.Rows[0]["SSN"].ToString();
        //txtFilename.Text = dtPatientInfo.Rows[0]["FileName"].ToString();
        string[] race = dtPatientInfo.Rows[0]["RaceId"].ToString().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        if (race.Length > 0)
        {
            ddlRace.SelectedIndex = Convert.ToInt32(race[0]);
        }
        string[] ethnicity = dtPatientInfo.Rows[0]["EthnicityId"].ToString().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        if (ethnicity.Length > 0)
        {
            ddlEthnicity.SelectedIndex = Convert.ToInt32(ethnicity[0]);
        }
        ddlPreferredLanguage.SelectedValue = dtPatientInfo.Rows[0]["PreferredLanguageId"].ToString();

        lblFirstName.Text = dtPatientInfo.Rows[0]["FirstName"].ToString();
        lblMiddleName.Text = dtPatientInfo.Rows[0]["MiddleName"].ToString();
        lblLastName.Text = dtPatientInfo.Rows[0]["LastName"].ToString();
        lblDOBPatient.Text = dtPatientInfo.Rows[0]["DateOfBirth"].ToString();
        lblTimeOfBirthPatient.Text = dtPatientInfo.Rows[0]["TimeOfBirth"].ToString();
        lblSSN.Text = dtPatientInfo.Rows[0]["SSN"].ToString();
        if (dtPatientInfo.Rows[0]["FileName"].ToString() == "")
        {
            lbluploadedfileName.Text = "no file uploaded";
        }
        else
        {
            lbluploadedfileName.Text = dtPatientInfo.Rows[0]["FileName"].ToString();
            txtFilename.Value = dtPatientInfo.Rows[0]["FileName"].ToString();
            hdnUploadedFilesID.Value = dtPatientInfo.Rows[0]["UploadFilesId"].ToString();
        }

        if (ddlPreferredLanguage.SelectedValue == "0")
        {
            lblLanguage.Text = "";
        }
        else
        {
            lblLanguage.Text = ddlPreferredLanguage.SelectedItem.Text;
        }

        lblGenderPatient.Text = dtPatientInfo.Rows[0]["Gender"].ToString();
        lblMaritalStatusPatient.Text = dtPatientInfo.Rows[0]["MaritalStatus"].ToString();
        ddlMaritalStatus.SelectedValue = dtPatientInfo.Rows[0]["MaritalStatus"].ToString();
        txtAddress.Value = dtPatientInfo.Rows[0]["Address"].ToString();
        txtCity.Value = dtPatientInfo.Rows[0]["City"].ToString();
        txtZip.Value = dtPatientInfo.Rows[0]["Zip"].ToString();
        txtHomePhone.Value = dtPatientInfo.Rows[0]["HomePhone"].ToString();
        txtCell.Value = dtPatientInfo.Rows[0]["Cell"].ToString();
        txtWorkPhone.Value = dtPatientInfo.Rows[0]["WorkPhone"].ToString();
        txtExt.Value = dtPatientInfo.Rows[0]["Ext"].ToString();
        txtEmail.Value = dtPatientInfo.Rows[0]["Email"].ToString();
        ddlCCP.SelectedValue = dtPatientInfo.Rows[0]["CCP"].ToString();

        ddlAddressType.SelectedValue = dtPatientInfo.Rows[0]["AddressType"].ToString();
        ddlState.SelectedValue = dtPatientInfo.Rows[0]["State"].ToString();
        ddlGender.SelectedValue = dtPatientInfo.Rows[0]["Gender"].ToString();
        lblAddressPatient.Text = dtPatientInfo.Rows[0]["Address"].ToString();
        lblCityPatient.Text = dtPatientInfo.Rows[0]["City"].ToString();
        lblZipPatient.Text = dtPatientInfo.Rows[0]["Zip"].ToString();
        lblHomePhonePatient.Text = dtPatientInfo.Rows[0]["HomePhone"].ToString();
        lblCellPatient.Text = dtPatientInfo.Rows[0]["Cell"].ToString();
        lblWorkPhonePatient.Text = dtPatientInfo.Rows[0]["WorkPhone"].ToString();
        lblExt.Text = dtPatientInfo.Rows[0]["Ext"].ToString();
        lblEmail.Text = dtPatientInfo.Rows[0]["Email"].ToString();
        lblAddressType.Text = ddlAddressType.SelectedItem.Text;
        lblStatePatient.Text = ddlState.SelectedItem.ToString(); // dtPatientInfo.Rows[0]["Email"].ToString();
        lblCCP.Text = ddlCCP.SelectedItem.Text;
        //     lblCommunicationBarrier.Text = dtPatientInfo.Rows[0]["CommunicationBarrier"].ToString();
        //     ddlCommunicationBarriers.SelectedValue = dtPatientInfo.Rows[0]["CommunicationBarrier"].ToString();
        txtGuarantorFirstName.Value = dtPatientInfo.Rows[0]["GuarantorFirstName"].ToString();
        txtGuarantorLastName.Value = dtPatientInfo.Rows[0]["GuarantorLastName"].ToString();
        ddlRelationship.SelectedValue = dtPatientInfo.Rows[0]["GuarantorRelationship"].ToString();

        lblGuarantorFirstName.Text = dtPatientInfo.Rows[0]["GuarantorFirstName"].ToString();
        lblGuarantorLastName.Text = dtPatientInfo.Rows[0]["GuarantorLastName"].ToString();

        if (ddlRelationship.SelectedValue == "0")
        {
            lblRelationship.Text = "";
        }
        else
        {
            lblRelationship.Text = ddlRelationship.SelectedItem.Text;
        }
        if (lblRelationship.Text == "Self")
        {
            lblGuarantorFirstName.Text = dtPatientInfo.Rows[0]["FirstName"].ToString();
            lblGuarantorLastName.Text = dtPatientInfo.Rows[0]["LastName"].ToString();

        }

        hdnFinancialGuarantorIdView.Value = dtPatientInfo.Rows[0]["FinancialGuarantorId"].ToString();
        hdnFinancialGuarantorIdEdit.Value = dtPatientInfo.Rows[0]["FinancialGuarantorId"].ToString();
        txtEmergencyContactName.Value = dtPatientInfo.Rows[0]["EmergencyContactName"].ToString();
        txtEmergencyContact.Value = dtPatientInfo.Rows[0]["Phone"].ToString();
        ddlEmergencyRelationship.SelectedValue = dtPatientInfo.Rows[0]["Relationship"].ToString();

        lblEmergencyContactName.Text = dtPatientInfo.Rows[0]["EmergencyContactName"].ToString();
        lblEmergencyContactNo.Text = dtPatientInfo.Rows[0]["Phone"].ToString();

        if (ddlEmergencyRelationship.SelectedItem.Text == "Select")
        {
            lblEmergencyRelationship.Text = "";
        }
        else
        {
            lblEmergencyRelationship.Text = ddlEmergencyRelationship.SelectedItem.Text;
        }

        txtDisabilityDate.Value = dtPatientInfo.Rows[0]["DisabilityDate"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["DisabilityDate"].ToString();
        txtDeathDate.Value = dtPatientInfo.Rows[0]["DeathDate"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["DeathDate"].ToString();
        txtCauseOfDeath.Value = dtPatientInfo.Rows[0]["CauseOfDeath"].ToString();

        lblDisabilityDate.Text = dtPatientInfo.Rows[0]["DisabilityDate"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["DisabilityDate"].ToString();
        lblDeathDate.Text = dtPatientInfo.Rows[0]["DeathDate"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["DeathDate"].ToString();
        lblCauseOfDeath.Text = dtPatientInfo.Rows[0]["CauseOfDeath"].ToString();

        string PharmacyName = dtPatientInfo.Rows[0]["StoreName"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["StoreName"].ToString();
        string Address = dtPatientInfo.Rows[0]["PharmacyAddress"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["PharmacyAddress"].ToString();
        string Phone = dtPatientInfo.Rows[0]["PharmacyPhone"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["PharmacyPhone"].ToString();
        string City = dtPatientInfo.Rows[0]["PharmacyCity"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["PharmacyCity"].ToString();
        string State = dtPatientInfo.Rows[0]["PharmacyState"] == DBNull.Value ? "" : dtPatientInfo.Rows[0]["PharmacyState"].ToString();

        if (PharmacyName != "")
        {
            txtPharmacyInfo.Value = PharmacyName + " [" + Address + "," + City + "," + State + "," + "," + Phone + " ]";
            lblPharmacyInfo.Text = txtPharmacyInfo.Value;
        }

        hdnPatientNCPDP.Value = dtPatientInfo.Rows[0]["NCPDP"].ToString();
        hdnNCPDP.Value = dtPatientInfo.Rows[0]["NCPDP"].ToString();

        lblPatientUserName.Text = dtPatientInfo.Rows[0]["UserName"].ToString();
        txtPatientUserName.Value = dtPatientInfo.Rows[0]["UserName"].ToString();
        hdnPassword.Value = dtPatientInfo.Rows[0]["Password"].ToString();
        if (!string.IsNullOrEmpty(dtPatientInfo.Rows[0]["ActiveWebAccount"].ToString()))
        {
            cbIsActiveWebAccount.Checked = bool.Parse(dtPatientInfo.Rows[0]["ActiveWebAccount"].ToString());
            CheckBox1.Checked = bool.Parse(dtPatientInfo.Rows[0]["ActiveWebAccount"].ToString());
        }
    }

    private void GetPatientRelatedData()
    {
        PatientDB objPatientDB = new PatientDB();

        DataSet dsPatientData = objPatientDB.GetPatientRelatedData();

        ddlState.DataSource = dsPatientData.Tables[0];
        ddlState.DataValueField = "StateCode";
        ddlState.DataTextField = "StateName";
        ddlState.DataBind();
        ddlState.Items.Insert(0, new ListItem());

        ddlRace.DataSource = dsPatientData.Tables[1];
        ddlRace.DataValueField = "RaceId";
        ddlRace.DataTextField = "Name";
        ddlRace.DataBind();
        ddlRace.Items.Insert(0, new ListItem());

        ddlEthnicity.DataSource = dsPatientData.Tables[2];
        ddlEthnicity.DataValueField = "EthnicityId";
        ddlEthnicity.DataTextField = "Name";
        ddlEthnicity.DataBind();
        ddlEthnicity.Items.Insert(0, new ListItem());

        ddlPreferredLanguage.DataSource = dsPatientData.Tables[3];
        ddlPreferredLanguage.DataValueField = "LanguageId";
        ddlPreferredLanguage.DataTextField = "Name";
        ddlPreferredLanguage.DataBind();

        ddlRelationship.DataSource = dsPatientData.Tables[7];
        ddlRelationship.DataValueField = "Code";
        ddlRelationship.DataTextField = "Definition";
        ddlRelationship.DataBind();

        ddlEmergencyRelationship.DataSource = dsPatientData.Tables[7];
        ddlEmergencyRelationship.DataValueField = "Code";
        ddlEmergencyRelationship.DataTextField = "Definition";
        ddlEmergencyRelationship.DataBind();
    }

    public void PatientSearchData(long patientID)
    {
        PatientDB patientDb = new PatientDB();


        DataSet ds = patientDb.FilterPatients(patientID, "", "", "", "", "", "", "", Profile.PracticeId, 5, 0, "Account Number");
        rptPatientSearch.DataSource = ds.Tables[0];
        rptPatientSearch.DataBind();

    }

    public void PatientPaymentDetailLevel2()
    {
        long patientid = long.Parse(Request.Form["PatientId"]);
        string checknumber = Request.Form["Checknumber"];
        ProcedurePaymentsDB procedurePaymentsdb = new ProcedurePaymentsDB();
        DataSet ds = procedurePaymentsdb.GetPatientPayment(patientid);
        
        try
        {
            RptBalanceSheet_Trn.DataSource = ds.Tables[0];
            RptBalanceSheet_Trn.DataBind();

            var mainresult = from myrow in ds.Tables[0].AsEnumerable()
                             where myrow.Field<string>("CheckNumber") == checknumber
                             select new
                             {
                                 DOS = myrow.Field<DateTime?>("DOS"),
                                 CPTCode = myrow.Field<string>("CPTCode"),
                                 TotalCharges = myrow.Field<decimal?>("totalcharges"),
                                 PR =myrow.Field<string>("PR").ToString(),
                                 PaidAmount =myrow.Field<decimal?>("PaidAmount"),
                                 RemainingBalance =myrow.Field<decimal?>("RemainingBalance")
                             };
            PDate.Text = Convert.ToDateTime(mainresult.Select(x => x.DOS).FirstOrDefault()).ToShortDateString();
            Check.Text = checknumber;
            CheckAmt.Text = mainresult.Select(x => x.PaidAmount).FirstOrDefault().ToString();
            rptlevel2detail.DataSource = mainresult.Distinct();
            rptlevel2detail.DataBind();

            rptlevel2detail_dialogue.DataSource = mainresult.Distinct();
            rptlevel2detail_dialogue.DataBind();

           


        }
        catch (Exception ex)
        {
        }
        
    }

    protected void GetBalanceGrid()
    {
        long patientid = long.Parse(Request.Form["PatientId"]);
        ProcedurePaymentsDB procedurePaymentsdb = new ProcedurePaymentsDB();
        DataSet ds = procedurePaymentsdb.GetPatientPayment(patientid);

        if (ds.Tables[3].Rows.Count > 0)
        {
            RepBGrid.DataSource = ds.Tables[3];
            RepBGrid.DataBind();
            double sum = Convert.ToDouble(ds.Tables[3].Compute("SUM(Balance)", string.Empty));

            TotalBalanceDue.Text = String.Format("{0:C}", sum); 
        }
      

    }

}