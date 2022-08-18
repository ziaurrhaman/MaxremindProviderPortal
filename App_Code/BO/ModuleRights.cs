using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ModuleRights
/// </summary>
public class ModuleRights
{
	public ModuleRights()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public bool PatientView { get; set; }
    public bool PatientCreate { get; set; }
    public bool PatientEdit { get; set; }

    public bool PatientInsuranceView { get; set; }
    public bool PatientInsuranceAdd { get; set; }
    public bool PatientInsuranceEdit { get; set; }
    public bool PatientInsuranceDelete { get; set; }

    public bool PatientClinicalExamsView { get; set; }
    public bool PatientClinicalExamsAdd { get; set; }
    public bool PatientClinicalExamsEdit { get; set; }
    public bool PatientClinicalExamsDelete { get; set; }

    public bool PatientDocumentsView { get; set; }
    public bool PatientDocumentsAdd { get; set; }
    public bool PatientDocumentsEdit { get; set; }
    public bool PatientDocumentsDelete { get; set; }
    
   
    private string _ClaimsViewStatus = string.Empty;
    public string ClaimsViewStatus { get { return _ClaimsViewStatus; } set { _ClaimsViewStatus = value; } }
    public bool ClaimsCreate { get; set; }
    public bool ClaimsEdit { get; set; }
    private string _ClaimsEditStatus = string.Empty;
    public string ClaimsEditStatus { get { return _ClaimsEditStatus; } set { _ClaimsEditStatus = value; } }
   
    public bool UnProcessedClaimsView { get; set; }
    public bool GenerateSubmissionFile { get; set; }
    public bool SubmissionLogView { get; set; }
    public bool SubmissionFilesView { get; set; }
    public bool SubmissionFilesDownload { get; set; }

    public bool ClaimPaymentView { get; set; }
    public bool ClaimPaymentSend { get; set; }
    public bool ProcessFileCreate { get; set; }
    public bool EobCreate { get; set; }
    public bool PayRollCreate { get; set; }

    public bool MedicationView { get; set; }
    public bool MedicationAdd { get; set; }
    public bool MedicationEdit { get; set; }
    public bool MedicationDelete { get; set; }

    public bool AllergyView { get; set; }
    public bool AllergyAdd { get; set; }
    public bool AllergyEdit { get; set; }
    public bool AllergyDelete { get; set; }

    public bool InsuranceView { get; set; }
    public bool InsuranceAdd { get; set; }
    public bool InsuranceEdit { get; set; }
    public bool InsuranceDelete { get; set; }

    public bool PracticeLocationsView { get; set; }
    public string PracticeLocationsViewLocations { get; set; }
    public bool PracticeLocationsAdd { get; set; }
    public bool PracticeLocationsEdit { get; set; }
    public string PracticeLocationsEditLocations { get; set; }
    public bool PracticeLocationsDelete { get; set; }
    public string PracticeLocationsDeleteLocations { get; set; }

    public bool PracticeStaffView { get; set; }
    public string PracticeStaffViewLocations { get; set; }
    public bool PracticeStaffAdd { get; set; }
    public string PracticeStaffAddLocations { get; set; }
    public bool PracticeStaffEdit { get; set; }
    public string PracticeStaffEditLocations { get; set; }
    public bool PracticeStaffDelete { get; set; }
    public string PracticeStaffDeleteLocations { get; set; }

    public bool ServiceProvidersView { get; set; }
    public bool ServiceProvidersAdd { get; set; }
    public bool ServiceProvidersEdit { get; set; }
    public bool ServiceProvidersDelete { get; set; }

    public bool ProviderTimingsView { get; set; }
    public bool ProviderTimingsEdit { get; set; }
   
    public bool PracticeView { get; set; }
    public bool PracticeEdit { get; set; }

    public bool AppointmentsView { get; set; }
    public bool AppointmentsAdd { get; set; }
    public string AppointmentsAddStatus { get; set; }
    public bool AppointmentsEdit { get; set; }
    public string AppointmentsEditStatus { get; set; }
    public bool AppointmentsDelete { get; set; }


    public bool ReportsView { get; set; }
   
    public bool UserRoleView { get; set; }
    public bool UserRoleAdd { get; set; }
    public bool UserRoleEdit { get; set; }
    public bool UserRoleDelete { get; set; }

    public bool UserRightView { get; set; }
    public bool UserRightEdit { get; set; }

    public bool PracticeRoomView { get; set; }
    public bool PracticeRoomAdd { get; set; }
    public bool PracticeRoomEdit { get; set; }
    public bool PracticeRoomDelete { get; set; }

    public bool PracticeUsersView { get; set; }
    public bool PracticeUsersAdd { get; set; }
    public bool PracticeUsersEdit { get; set; }
    public bool PracticeUsersDelete { get; set; }

    public bool AppointmentTypesView { get; set; }
    public bool AppointmentTypesAdd { get; set; }
    public bool AppointmentTypesEdit { get; set; }
    public bool AppointmentTypesDelete { get; set; }

    public bool ChartTemplatesView { get; set; }
    public bool ChartTemplatesAdd { get; set; }
    public bool ChartTemplatesEdit { get; set; }
    public bool ChartTemplatesDelete { get; set; }

    public bool OrdersView { get; set; }
    public bool OrdersAdd { get; set; }
    public bool OrdersEdit { get; set; }
    public bool OrdersDelete { get; set; }

    public bool OrdersResultsView { get; set; }
    public bool OrdersResultsAdd { get; set; }
    public bool OrdersResultsEdit { get; set; }
    public bool OrdersResultsDelete { get; set; }
    public bool OrdersResultsSign { get; set; }
    //Rizwan kharal
    //28 Nov 2017
    // For claim show againt user id
    public bool ClaimsSpecificView { get; set; }
    public bool PaymentsSpecificView { get; set; }

    public bool PatientInvocie { get; set; }
    public bool Payments { get; set; }

    public bool Eligibility { get; set; }
    public bool Scheduler { get; set; }
    public bool Dashboard { get; set; }
    public bool CustomerSupport { get; set; }
    public bool ClaimsView { get; set; }
    public bool PaymentView { get; set; }
    public bool InsuranceCredentialling { get; set; }
    public bool EDIERAUser { get; set; }
    public bool ClientInvoices { get; set; }
}