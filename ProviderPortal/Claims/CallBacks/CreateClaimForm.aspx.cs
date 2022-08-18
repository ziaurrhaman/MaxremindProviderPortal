using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class EMR_Claims_CallBacks_CreateClaimForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadDropDowns();
        
        if (string.IsNullOrEmpty(Request.Form["ClaimId"]))
        {
            return;
        }

        long ClaimId = long.Parse(Request.Form["ClaimId"]);
        long PatientId = long.Parse(Request.Form["PatientId"]);
        
        if (ClaimId == 0)
        {
            LoadStaffByFirstLocation();
        }
        
        if (PatientId != 0)
        {
            GetPatientSummaryInfo(PatientId);
            txtDos.Text = Request.Form["ServiceDate"];
            
            GetClaimsDetails(ClaimId, PatientId);
        }

        //LoadPatientPaymentViewData();
        //LoadPatientPaymentData();
    }
    
    private void LoadDropDowns()
    {
        PracticeLocationsDB objPracticeLocationsDB = new PracticeLocationsDB();
        PracticeStaffManager objPracticeStaffManager = new PracticeStaffManager();

        ddlLocation.DataSource = objPracticeLocationsDB.GetPracticeLocationsByPractice(Profile.PracticeId);
        ddlLocation.DataTextField = "Name";
        ddlLocation.DataValueField = "PracticeLocationsId";
        ddlLocation.DataBind();

        StatesDB objStatesDB = new StatesDB();
        DataTable dtStates = objStatesDB.GetAllAsDataTable();

        ddlAmbulancePickUpLocationState.DataSource = dtStates;
        ddlAmbulancePickUpLocationState.DataValueField = "StateCode";
        ddlAmbulancePickUpLocationState.DataTextField = "StateName";
        ddlAmbulancePickUpLocationState.DataBind();
        ddlAmbulancePickUpLocationState.Items.Insert(0, new ListItem("", ""));

        ddlAmbulanceDropLocationState.DataSource = dtStates;
        ddlAmbulanceDropLocationState.DataValueField = "StateCode";
        ddlAmbulanceDropLocationState.DataTextField = "StateName";
        ddlAmbulanceDropLocationState.DataBind();
        ddlAmbulanceDropLocationState.Items.Insert(0, new ListItem("", ""));

        ddlServiceFacilityState.DataSource = dtStates;
        ddlServiceFacilityState.DataValueField = "StateCode";
        ddlServiceFacilityState.DataTextField = "StateName";
        ddlServiceFacilityState.DataBind();
        ddlServiceFacilityState.Items.Insert(0, new ListItem("", ""));

        ddlAutoAccidentState.DataSource = dtStates;
        ddlAutoAccidentState.DataValueField = "StateCode";
        ddlAutoAccidentState.DataTextField = "StateName";
        ddlAutoAccidentState.DataBind();
        ddlAutoAccidentState.Items.Insert(0, new ListItem("", ""));

        DataTable dtProviders = objPracticeStaffManager.GetProvidersByPractice(Profile.PracticeId);
        
        StringBuilder providersByLocationScript = new StringBuilder();
        providersByLocationScript.Append("<script type='text/javascript'>");
        providersByLocationScript.Append("var _arrProvidersByLocation = new Array();");
        
        for (int i = 0; i < dtProviders.Rows.Count; i++)
        {
            providersByLocationScript.Append("var objProviders = new Object();");
            providersByLocationScript.Append("objProviders.ServiceProviderId ='" + dtProviders.Rows[i]["PracticeStaffId"].ToString() + "';");
            providersByLocationScript.Append("objProviders.Name ='" + dtProviders.Rows[i]["Name"].ToString() + "';");
            providersByLocationScript.Append("objProviders.PracticeLocationsId ='" + dtProviders.Rows[i]["PracticeLocationsId"].ToString() + "';");
            
            providersByLocationScript.Append("_arrProvidersByLocation.push(objProviders);");
        }
        
        providersByLocationScript.Append("</script>");
        ltrProvidersByLocation.Text = providersByLocationScript.ToString();
        
        SubmissionStatusCodesDB objSubmissionStatusCodesDB = new SubmissionStatusCodesDB();
        DataTable dtSubmissionStatusCodes = objSubmissionStatusCodesDB.GetSubmissionStatusCodes();

        ddlPrimaryStatus.DataSource = dtSubmissionStatusCodes;
        ddlPrimaryStatus.DataValueField = "SubmissionStatusId";
        ddlPrimaryStatus.DataTextField = "SubmissionStatus";
        ddlPrimaryStatus.DataBind();
        ddlPrimaryStatus.Items.Insert(0, new ListItem("", ""));

        ddlSecondaryStatus.DataSource = dtSubmissionStatusCodes;
        ddlSecondaryStatus.DataValueField = "SubmissionStatusId";
        ddlSecondaryStatus.DataTextField = "SubmissionStatus";
        ddlSecondaryStatus.DataBind();
        ddlSecondaryStatus.Items.Insert(0, new ListItem("", ""));

        ddlOtherStatus.DataSource = dtSubmissionStatusCodes;
        ddlOtherStatus.DataValueField = "SubmissionStatusId";
        ddlOtherStatus.DataTextField = "SubmissionStatus";
        ddlOtherStatus.DataBind();
        ddlOtherStatus.Items.Insert(0, new ListItem("", ""));
    }

    private void LoadStaffByFirstLocation()
    {
        PracticeStaffManager objPracticeStaffManager = new PracticeStaffManager();

        if (ddlLocation.Items.Count > 0)
        {
            long PracticeLocationsId = long.Parse(ddlLocation.Items[0].Value);

            DataTable dtProvider = objPracticeStaffManager.GetProvidersByPracticeLocation(PracticeLocationsId, Profile.ServiceProviderId);

            ddlReferringPhy.DataSource = dtProvider;
            ddlReferringPhy.DataTextField = "Name";
            ddlReferringPhy.DataValueField = "PracticeStaffId";
            ddlReferringPhy.DataBind();
            ddlReferringPhy.Items.Insert(0, new ListItem("", ""));

            ddlAttendingPhy.DataSource = dtProvider;
            ddlAttendingPhy.DataTextField = "Name";
            ddlAttendingPhy.DataValueField = "PracticeStaffId";
            ddlAttendingPhy.DataBind();
            ddlAttendingPhy.Items.Insert(0, new ListItem("", ""));

            ddlBillingPhy.DataSource = dtProvider;
            ddlBillingPhy.DataTextField = "Name";
            ddlBillingPhy.DataValueField = "PracticeStaffId";
            ddlBillingPhy.DataBind();
            ddlBillingPhy.Items.Insert(0, new ListItem("", ""));

            ddlRenderingPhysician.DataSource = dtProvider;
            ddlRenderingPhysician.DataTextField = "Name";
            ddlRenderingPhysician.DataValueField = "PracticeStaffId";
            ddlRenderingPhysician.DataBind();
            ddlRenderingPhysician.Items.Insert(0, new ListItem("", "0"));

            ddlSupervisingPhysician.DataSource = dtProvider;
            ddlSupervisingPhysician.DataTextField = "Name";
            ddlSupervisingPhysician.DataValueField = "PracticeStaffId";
            ddlSupervisingPhysician.DataBind();
            ddlSupervisingPhysician.Items.Insert(0, new ListItem("", "0"));
        }
    }

    private void LoadStaffByPracticeLocation(long PracticeLocationsId)
    {
        PracticeStaffManager objPracticeStaffManager = new PracticeStaffManager();

        DataTable dtProvider = objPracticeStaffManager.GetProvidersByPracticeLocation(PracticeLocationsId);

        //ddlReferringPhy.DataSource = dtProvider;
        //ddlReferringPhy.DataTextField = "Name";
        //ddlReferringPhy.DataValueField = "PracticeStaffId";
        //ddlReferringPhy.DataBind();
        //ddlReferringPhy.Items.Insert(0, new ListItem("", ""));

        ddlAttendingPhy.DataSource = dtProvider;
        ddlAttendingPhy.DataTextField = "Name";
        ddlAttendingPhy.DataValueField = "PracticeStaffId";
        ddlAttendingPhy.DataBind();
        ddlAttendingPhy.Items.Insert(0, new ListItem("", ""));

        ddlBillingPhy.DataSource = dtProvider;
        ddlBillingPhy.DataTextField = "Name";
        ddlBillingPhy.DataValueField = "PracticeStaffId";
        ddlBillingPhy.DataBind();
        ddlBillingPhy.Items.Insert(0, new ListItem("", ""));

        ddlRenderingPhysician.DataSource = dtProvider;
        ddlRenderingPhysician.DataTextField = "Name";
        ddlRenderingPhysician.DataValueField = "PracticeStaffId";
        ddlRenderingPhysician.DataBind();
        ddlRenderingPhysician.Items.Insert(0, new ListItem("", "0"));

        ddlSupervisingPhysician.DataSource = dtProvider;
        ddlSupervisingPhysician.DataTextField = "Name";
        ddlSupervisingPhysician.DataValueField = "PracticeStaffId";
        ddlSupervisingPhysician.DataBind();
        ddlSupervisingPhysician.Items.Insert(0, new ListItem("", "0"));
    }
    
    public void GetPatientSummaryInfo(long PatientId)
    {
        //AppointmentsDB objAppointmentsDB = new AppointmentsDB();

        //ddlDos.DataSource = objAppointmentsDB.GetPatientAppointmentDate(PatientId);
        //ddlDos.DataTextField = "AppointmentDate";
        //ddlDos.DataValueField = "AppointmentDate";
        //ddlDos.DataBind();
        //ddlDos.Items.Insert(0, new ListItem("", ""));

        PatientDB objPatientDB = new PatientDB();
        DataSet ddtPatient = objPatientDB.Patient_GetById(PatientId, Profile.PracticeId);

        lblPatientId.Text = "Account No: " + PatientId;
        lblNamePatient.Text = ddtPatient.Tables[0].Rows[0]["FirstName"].ToString() + " " + ddtPatient.Tables[0].Rows[0]["MiddleName"].ToString() + " " + ddtPatient.Tables[0].Rows[0]["LastName"].ToString();
        lblGenderPatient.Text = ddtPatient.Tables[0].Rows[0]["Gender"].ToString() + ",";
        lblDOBPatient.Text = ddtPatient.Tables[0].Rows[0]["DateOfBirth"].ToString();
        lblMaritalStatusPatient.Text = ddtPatient.Tables[0].Rows[0]["MaritalStatus"].ToString();

        string ImageUrl = ddtPatient.Tables[0].Rows[0]["ImagePath"].ToString();

        if (string.IsNullOrEmpty(ImageUrl))
        {
            hfImageFileNamePatient.Value = "";
        }
        else
        {
            hfImageFileNamePatient.Value = ddtPatient.Tables[0].Rows[0]["PracticeId"].ToString() + "/Patients/" + PatientId + "/" + ImageUrl;
        }

        lblCellPatient.Text = ddtPatient.Tables[0].Rows[0]["Cell"].ToString() + ", ";
        lblHomePhonePatient.Text = ddtPatient.Tables[0].Rows[0]["HomePhone"].ToString() + ", ";
        lblWorkPhonePatient.Text = ddtPatient.Tables[0].Rows[0]["WorkPhone"].ToString();
        lblAddressPatient.Text = ddtPatient.Tables[0].Rows[0]["Address"].ToString() + ", " + ddtPatient.Tables[0].Rows[0]["City"].ToString() + ", " + ddtPatient.Tables[0].Rows[0]["State"].ToString() + " " + ddtPatient.Tables[0].Rows[0]["Zip"].ToString();

        divPatientInfo.Style["display"] = "block";
    }

    public void GetClaimsDetails(long ClaimId, long PatientId)
    {
        #region Load Insurances

        PatientInsuranceDB ObjPatientInsuranceDB = new PatientInsuranceDB();
        DataTable ddtPatientInsurance = ObjPatientInsuranceDB.GetByPatient(PatientId);


        ddlPrimaryInsurance.DataSource = ddtPatientInsurance;
        ddlPrimaryInsurance.DataTextField = "InsuranceName";
        ddlPrimaryInsurance.DataValueField = "Insuranceid";
        ddlPrimaryInsurance.DataBind();
        ddlPrimaryInsurance.Items.Insert(ddtPatientInsurance.Rows.Count, new ListItem("Self Pay", "0"));
        ddlPrimaryInsurance.Items.Insert(0, new ListItem("", ""));

        #region Patient Payment Payer
        ddlPayerPatientPayment.DataSource = ddtPatientInsurance;
        ddlPayerPatientPayment.DataTextField = "InsuranceName";
        ddlPayerPatientPayment.DataValueField = "Insuranceid";
        ddlPayerPatientPayment.DataBind();
        ddlPayerPatientPayment.Items.Insert(ddtPatientInsurance.Rows.Count, new ListItem("Patient", "0"));
        ddlPayerPatientPayment.Items.Insert(0, new ListItem("", ""));
        #endregion

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

        #endregion

        ClaimDB objClaimDB = new ClaimDB();
        
        DataSet dsClaimDB = objClaimDB.GetClaimDetails(PatientId, ClaimId);

        DataTable dtClaimDB = dsClaimDB.Tables[0];

        if (dtClaimDB.Rows.Count > 0)
        {
            DataRow drClaim = dtClaimDB.Rows[0];
            
            long PracticeLocationsId = long.Parse(drClaim["PracticeLocationsId"].ToString());
            LoadStaffByPracticeLocation(PracticeLocationsId);
            
            //claims
            txtDos.Text = drClaim["DOS"].ToString();
            ddlPOS.SelectedValue = drClaim["POS"].ToString();
            ddlLocation.SelectedValue = PracticeLocationsId.ToString();
            ddlAttendingPhy.SelectedValue = drClaim["AttendingPhysician"].ToString();
            ddlBillingPhy.SelectedValue = drClaim["BillingPhysicianId"].ToString();
            ddlReferringPhy.SelectedValue = drClaim["ReferringPhysicianId"].ToString();

            //ddlPatientInsurences.SelectedValue = drClaim["PatientInsuranceId"].ToString();

            txtReferralNo.Text = drClaim["ReferralNumber"].ToString();
            txtPANo.Text = drClaim["PANumber"].ToString();

            txtIcdCode1.Value = drClaim["DxCode1"].ToString();
            txtIcdCode2.Value = drClaim["DxCode2"].ToString();
            txtIcdCode3.Value = drClaim["DxCode3"].ToString();
            txtIcdCode4.Value = drClaim["DxCode4"].ToString();
            txtIcdCode5.Value = drClaim["DxCode5"].ToString();
            txtIcdCode6.Value = drClaim["DxCode6"].ToString();
            txtIcdCode7.Value = drClaim["DxCode7"].ToString();
            txtIcdCode8.Value = drClaim["DxCode8"].ToString();

            txtIcdDesc1.Value = drClaim["dx1Description"].ToString();
            txtIcdDesc2.Value = drClaim["dx2Description"].ToString();
            txtIcdDesc3.Value = drClaim["dx3Description"].ToString();
            txtIcdDesc4.Value = drClaim["dx4Description"].ToString();
            txtIcdDesc5.Value = drClaim["dx5Description"].ToString();
            txtIcdDesc6.Value = drClaim["dx6Description"].ToString();
            txtIcdDesc7.Value = drClaim["dx7Description"].ToString();
            txtIcdDesc8.Value = drClaim["dx8Description"].ToString();

            /**********Start Set Patient Insurances According To Claim**********/

            if (!string.IsNullOrEmpty(drClaim["InsuranceId"].ToString()))
            {
                long InsuranceId = long.Parse(drClaim["InsuranceId"].ToString());
                ddlPrimaryInsurance.SelectedValue = InsuranceId.ToString();

            }

            if (!string.IsNullOrEmpty(drClaim["PriSubmissionStatusId"].ToString()))
            {
                int PriSubmissionStatusId = int.Parse(drClaim["PriSubmissionStatusId"].ToString());
                ddlPrimaryStatus.SelectedValue = PriSubmissionStatusId.ToString();
            }

            if (!string.IsNullOrEmpty(drClaim["SecInsuranceId"].ToString()))
            {
                long SecInsuranceId = long.Parse(drClaim["SecInsuranceId"].ToString());
                ddlSecondaryInsurance.SelectedValue = SecInsuranceId.ToString();
            }

            if (!string.IsNullOrEmpty(drClaim["SecSubmissionStatusId"].ToString()))
            {
                int SecSubmissionStatusId = int.Parse(drClaim["SecSubmissionStatusId"].ToString());
                ddlSecondaryStatus.SelectedValue = SecSubmissionStatusId.ToString();
            }

            if (!string.IsNullOrEmpty(drClaim["OthInsuranceId"].ToString()))
            {
                long OthInsuranceId = long.Parse(drClaim["OthInsuranceId"].ToString());
                ddlOtherInsurance.SelectedValue = OthInsuranceId.ToString();
            }

            if (!string.IsNullOrEmpty(drClaim["OthSubmissionStatusId"].ToString()))
            {
                int OthSubmissionStatusId = int.Parse(drClaim["OthSubmissionStatusId"].ToString());
                ddlOtherStatus.SelectedValue = OthSubmissionStatusId.ToString();
            }
            /**********End Set Patient Insurances According To Claim**********/
            
            txtAdmissionDate.Text = drClaim["AdmissionDate"].ToString();
            txtDischargeDate.Text = drClaim["DischargeDate"].ToString();
            txtCurrentIllness.Text = drClaim["OnSetOfCurrentIllness"].ToString();
            txtXryDate.Text = drClaim["XRayDate"].ToString();
            txtAcuteManifestation.Text = drClaim["AcuteManifestation"].ToString();
            txtDateOfAccident.Text = drClaim["AccidentDate"].ToString();
            txtLMP.Text = drClaim["LMPDate"].ToString();
            txtInitialTreatmentDate.Text = drClaim["InitialTreatmentDate"].ToString();
            txtLastSeenDate.Text = drClaim["LastSeenDate"].ToString();
            
            if (!string.IsNullOrEmpty(drClaim["PatientPaidAmmount"].ToString()) && drClaim["PatientPaidAmmount"].ToString() != "0.0000")
            {
                txtPatientPaidAmmount.Text = drClaim["PatientPaidAmmount"].ToString().Remove(drClaim["PatientPaidAmmount"].ToString().Length - 2);
            }
            
            txtServiceAuthorizationException.Text = drClaim["ServiceAuthorizationException"].ToString();
            txtMammographyCertificationNumber.Text = drClaim["MammographyCertificationNumber"].ToString();
            txtCLIANumber.Text = drClaim["CLIANumber"].ToString();
            txtICNDCN.Text = drClaim["ICNDCN"].ToString();
            txtAmbulancePickUpLocationAddress.Text = drClaim["AmbulancePickUpLocationAddress"].ToString();
            txtAmbulancePickUpLocationCity.Text = drClaim["AmbulancePickUpLocationCity"].ToString();
            txtAmbulancePickUpLocationZip.Text = drClaim["AmbulancePickUpLocationZip"].ToString();
            ddlAmbulancePickUpLocationState.SelectedValue = drClaim["AmbulancePickUpLocationState"].ToString();
            txtAmbulanceDropLocationAddress.Text = drClaim["AmbulanceDropLocationAddress"].ToString();
            txtAmbulanceDropLocationCity.Text = drClaim["AmbulanceDropLocationCity"].ToString();
            txtAmbulanceDropLocationZip.Text = drClaim["AmbulanceDropLocationZip"].ToString();
            ddlAmbulanceDropLocationState.SelectedValue = drClaim["AmbulanceDropLocationState"].ToString();
            ddlTransportationReasonCode.SelectedValue = drClaim["TransportationReasonCode"].ToString();
            txtPatientWeight.Text = drClaim["PatientWeight"].ToString();
            ddlPatientWeightUnit.SelectedValue = drClaim["PatientWeightUnit"].ToString();
            ddlPatientCondition.SelectedValue= drClaim["PatientCondition"].ToString();
            ddlEpsdtCode.SelectedValue = drClaim["EpsdtCode"].ToString();
            ddlRenderingPhysician.SelectedValue = drClaim["RenderingPhysicianId"].ToString();
            ddlSupervisingPhysician.SelectedValue = drClaim["SupervisingPhysicianId"].ToString();
            txtServiceFacilityLocationName.Text = drClaim["ServiceFacilityLocationName"].ToString();
            txtServiceFacilityAddress.Text = drClaim["ServiceFacilityAddress"].ToString();
            txtServiceFacilityNPI.Text = drClaim["ServiceFacilityNPI"].ToString();
            txtServiceFacilityCity.Text = drClaim["ServiceFacilityCity"].ToString();
            txtServiceFacilityZip.Text = drClaim["ServiceFacilityZip"].ToString();
            ddlServiceFacilityState.SelectedValue = drClaim["ServiceFacilityState"].ToString();
            
            if (!string.IsNullOrEmpty(drClaim["AccidentAuto"].ToString()))
            {
                chkAutoAccident.Checked = bool.Parse(drClaim["AccidentAuto"].ToString());
                chkOtherAccident.Checked = false;
                ddlAutoAccidentState.Enabled = true;
            }
            else if (!string.IsNullOrEmpty(drClaim["AccidentOther"].ToString()))
            {
                chkOtherAccident.Checked = bool.Parse(drClaim["AccidentOther"].ToString());
                chkAutoAccident.Checked = false;
                ddlAutoAccidentState.Enabled = false;
            }

            if (!string.IsNullOrEmpty(drClaim["Employment"].ToString()))
            {
                chkEmployment.Checked = bool.Parse(drClaim["Employment"].ToString());
            }
            
            ddlAutoAccidentState.SelectedValue = drClaim["AccidentState"].ToString();

            chkIsPTL.Checked = bool.Parse(drClaim["IsPTL"].ToString());
        }


        DataTable dtClaimCharges = dsClaimDB.Tables[1];
        rptPatientServices.DataSource = dtClaimCharges;
        rptPatientServices.DataBind();
    }

    protected void rptPatientServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;

            DropDownList ddlUnitCode = (DropDownList)e.Item.FindControl("ddlUnitCode");
            ddlUnitCode.SelectedValue = drv["UnitCode"].ToString().Trim();

            CheckBox cbIncludeInSubmission = (CheckBox)e.Item.FindControl("cbIncludeInSubmission");
            DropDownList ddlBillingStatus = (DropDownList)e.Item.FindControl("ddlBillingStatus");
            Label lblPointers = (Label)e.Item.FindControl("lblPointers");

            string IncludeInSubmission = drv["IncludeInSubmission"].ToString();

            string DXPointer1 = drv["DXPointer1"].ToString().Trim();
            string DXPointer2 = drv["DXPointer2"].ToString().Trim();
            string DXPointer3 = drv["DXPointer3"].ToString().Trim();
            string DXPointer4 = drv["DXPointer4"].ToString().Trim();
            string DXPointer5 = drv["DXPointer5"].ToString().Trim();
            string DXPointer6 = drv["DXPointer6"].ToString().Trim();
            string DXPointer7 = drv["DXPointer7"].ToString().Trim();
            string DXPointer8 = drv["DXPointer8"].ToString().Trim();

            string BillingStatus = drv["BillingStatus"].ToString().Trim();
            ddlBillingStatus.SelectedValue = BillingStatus;


            if (IncludeInSubmission == "True")
            {
                cbIncludeInSubmission.Checked = true;
            }

            string pointerString = "";

            if (!string.IsNullOrEmpty(DXPointer1))
            {
                if (DXPointer1 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer1)).Checked = true;
                    pointerString += DXPointer1 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer2))
            {
                if (DXPointer2 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer2)).Checked = true;
                    pointerString += DXPointer2 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer3))
            {
                if (DXPointer3 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer3)).Checked = true;
                    pointerString += DXPointer3 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer4))
            {
                if (DXPointer4 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer4)).Checked = true;
                    pointerString += DXPointer4 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer5))
            {
                if (DXPointer5 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer5)).Checked = true;
                    pointerString += DXPointer5 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer6))
            {
                if (DXPointer6 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer6)).Checked = true;
                    pointerString += DXPointer6 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer7))
            {
                if (DXPointer7 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer7)).Checked = true;
                    pointerString += DXPointer7 + ", ";
                }
            }

            if (!string.IsNullOrEmpty(DXPointer8))
            {
                if (DXPointer8 != "0")
                {
                    ((CheckBox)e.Item.FindControl("cbDXPointer" + DXPointer8)).Checked = true;
                    pointerString += DXPointer8 + ", ";
                }
            }

            if (pointerString.Length != 0)
            {
                pointerString = pointerString.Remove(pointerString.Length - 2);
            }

            lblPointers.Text = pointerString;
            lblPointers.ToolTip = pointerString;
        }
    }
    
    private void LoadPatientPaymentData()
    {
        long ClaimId = long.Parse(Request.Form["ClaimId"]);

        ClaimDB objClaimDB = new ClaimDB();
        
        DataSet dsPaymentsData = objClaimDB.GetPaymentsData(ClaimId);
        
        DataTable dtPatientServicesPayments = dsPaymentsData.Tables[0];
        DataTable dtPaymentHistory = dsPaymentsData.Tables[1];
        
        rptPatientServicesPayments.DataSource = dtPatientServicesPayments;
        rptPatientServicesPayments.DataBind();
        
        rptPaymentHistory.DataSource = dtPaymentHistory;
        rptPaymentHistory.DataBind();
        
        LoadERAList();
    }
    
    private void LoadERAList()
    {
        long ClaimId = long.Parse(Request.Form["ClaimId"]);
        //long PatientId = long.Parse(Request.Form["PatientId"]);

        ClaimDB objClaimDB = new ClaimDB();

        string PayerID837p = "";
        string PayerID837s = "";
        string PayerID837o = "";

        DataTable dtPayerIds837 = objClaimDB.GetPayerIds837For_ERA_PatientPayment_GetAllFilter(ClaimId, true, false, false);

        if (dtPayerIds837.Rows.Count > 0)
        {
            PayerID837p = dtPayerIds837.Rows[0]["PayerID837p"].ToString();
            PayerID837s = dtPayerIds837.Rows[0]["PayerID837s"].ToString();
            PayerID837o = dtPayerIds837.Rows[0]["PayerID837o"].ToString();
        }

        ERAMasterDB objERAMasterDB = new ERAMasterDB();

        DataSet dsERAList = objERAMasterDB.PatientPayment_GetAllFilter(0, PayerID837p, PayerID837s, PayerID837o, "", "", "", "", "", true, 10, 0, "");

        DataTable dtERA = dsERAList.Tables[0];
        DataTable dtERATotalCount = dsERAList.Tables[1];

        rptERA.DataSource = dtERA;
        rptERA.DataBind();
        hdnPatientPaymentsCount.Value = dtERATotalCount.Rows[0]["TotalRows"].ToString();
    }

    protected void rptPaymentHistory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;
        
        string PaymentSource = drv["PaymentSource"].ToString().Trim();
        
        if (PaymentSource == "PRI")
        {
            PaymentSource = "Primary";
        }
        else if (PaymentSource == "SEC")
        {
            PaymentSource = "Secondary";
        }
        else if (PaymentSource == "OTH")
        {
            PaymentSource = "Other";
        }
        
        Label spnPaymentSource = (Label)e.Item.FindControl("spnPaymentSource");
        
        spnPaymentSource.Text = PaymentSource;
    }
    
    private void LoadPatientPaymentViewData()
    {
        long ClaimId = long.Parse(Request.Form["ClaimId"]);
        
        ClaimDB objClaimDB = new ClaimDB();
        
        DataSet dsPaymentsDataForView = objClaimDB.GetPaymentsDataForView(ClaimId);
        
        DataTable dtClaimSummary = dsPaymentsDataForView.Tables[0];
        DataTable dtPaymentSummary = dsPaymentsDataForView.Tables[1];
        DataTable dtPaymentDetail = dsPaymentsDataForView.Tables[2];
        
        
        if (dtClaimSummary.Rows.Count > 0)
        {
            spnTotalChargesClaimSummary.InnerHtml = dtClaimSummary.Rows[0]["ClaimTotal"].ToString();
            spnPaidAmountClaimSummary.InnerHtml = dtClaimSummary.Rows[0]["AmountPaid"].ToString();
            spnAdjustedAmountClaimSummary.InnerHtml = dtClaimSummary.Rows[0]["AdjustedAmount"].ToString();
            spnBalanceDueClaimSummary.InnerHtml = dtClaimSummary.Rows[0]["AmountDue"].ToString();
        }

        rptPaymentSummaryView.DataSource = dtPaymentSummary;
        rptPaymentSummaryView.DataBind();

        rptPaymentDetailView.DataSource = dtPaymentDetail;
        rptPaymentDetailView.DataBind();
    }

    protected void rptPaymentDetailView_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        DataRowView drv = (DataRowView)e.Item.DataItem;

        string PaymentSource = drv["PaymentSource"].ToString().Trim();

        if (PaymentSource == "PRI")
        {
            PaymentSource = "Primary";
        }
        else if (PaymentSource == "SEC")
        {
            PaymentSource = "Secondary";
        }
        else if (PaymentSource == "OTH")
        {
            PaymentSource = "Other";
        }

        Label spnPaymentSource = (Label)e.Item.FindControl("spnPaymentSource");

        spnPaymentSource.Text = PaymentSource;
    }
}