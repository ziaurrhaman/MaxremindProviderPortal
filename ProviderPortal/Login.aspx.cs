using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Profile;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

public partial class EMR_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        PracticeUsersDB objPracticeUserDB = new PracticeUsersDB();

        string userName = txtUserName.Text.ToString();
        string password = txtPassword.Text.ToString();

        DataTable SpecificUserDetail = objPracticeUserDB.GetUserSpecific(userName, password);
        if (SpecificUserDetail.Rows.Count > 0)
        {
            FormsAuthentication.RedirectFromLoginPage(userName, false);
            var UserId = SpecificUserDetail.Rows[0]["UserRegistrationId"].ToString();           
            ProfileCommon objProfileCommon = new ProfileCommon();
            ProfileCommon Profile1 = objProfileCommon.GetProfile(userName);
            Profile1.SpecificUserName = SpecificUserDetail.Rows[0]["LastName"].ToString() + ", " + SpecificUserDetail.Rows[0]["FirstName"].ToString();
            Profile1.SpecificUserId = SpecificUserDetail.Rows[0]["UserRegistrationId"].ToString(); 
            Profile1.Save();
            Response.Redirect("/ProviderPortal/Register/UserDetail.aspx");
        }
        else { 
        //Changes By Syed Sajid Ali Date:11-08-2018 Des:For Check Sucess Data
        var regex = new Regex("^[A-Za-z0-9@#$_]+$");
        Match matchP = regex.Match(password);
        Match matchUName = regex.Match(userName);
        if (matchP.Success && matchUName.Success)
        { 

        Session["OldPassword"] = password;
        DataTable objDataTable = new DataTable();
        EncryptionAndDeccryption objEncryption = new EncryptionAndDeccryption();
        string EncryptedPass = objEncryption.Encrypt(password);
        objDataTable = objPracticeUserDB.GetUserProfile(userName, EncryptedPass);
        if (objDataTable.Rows.Count == 0)
        {
            objDataTable = objPracticeUserDB.GetUserProfile(userName, password);
        }

        if (objDataTable.Rows.Count > 0)
        {
            if (!bool.Parse(objDataTable.Rows[0]["IsActive"].ToString()))
            {
                lblErrorMessage.Text = "Inactive user. Please contact your administrator for more details.";
            }
            else if (bool.Parse(objDataTable.Rows[0]["PracticeDeleted"].ToString()))
            {
                lblErrorMessage.Text = "Practice account blocked. Please contact technical support for more details.";
            }
            else
            {

                ProfileCommon objProfileCommon = new ProfileCommon();
                ProfileCommon Profile1 = objProfileCommon.GetProfile(userName);

                Profile1.PracticeId = long.Parse(objDataTable.Rows[0]["PracticeId"].ToString());

                Session["PracticeId"] = objDataTable.Rows[0]["PracticeId"].ToString();
                Profile1.PracticeName = objDataTable.Rows[0]["PracticeName"].ToString();
                Profile1.PracticeLogo = objDataTable.Rows[0]["PracticeLogo"].ToString();
                Profile1.PracticeAddress = objDataTable.Rows[0]["Address"].ToString();
                Profile1.PracticeCity = objDataTable.Rows[0]["City"].ToString();
                Profile1.PracticeState = objDataTable.Rows[0]["State"].ToString();
                Profile1.PracticeZip = objDataTable.Rows[0]["Zip"].ToString();
                Profile1.PracticeContactPersonPhone = objDataTable.Rows[0]["ContactPersonPhone"].ToString();
                Profile1.PracticeLocationsId = int.Parse(objDataTable.Rows[0]["PracticeLocationsId"].ToString());
                Profile1.UserId = long.Parse(objDataTable.Rows[0]["UserId"].ToString());
                Profile1.UserName = objDataTable.Rows[0]["UserName"].ToString();
                Profile1.FirstName = objDataTable.Rows[0]["FirstName"].ToString();
                Profile1.LastName = objDataTable.Rows[0]["LastName"].ToString();
                Profile1.MiddleName = objDataTable.Rows[0]["MiddleName"].ToString();
                Profile1.EmailAddress = objDataTable.Rows[0]["EmailAddress"].ToString();
                Profile1.PhoneNumber = objDataTable.Rows[0]["PhoneNumber"].ToString();
                Profile1.ServiceProviderId = long.Parse(objDataTable.Rows[0]["ServiceProviderId"].ToString());
                Profile1.ProfilePicturePath = objDataTable.Rows[0]["ProfilePicturePath"].ToString();
                Profile1.UserType = objDataTable.Rows[0]["UserType"].ToString();
                Profile1.PatientId = 0;
                Profile1.IsImported= objDataTable.Rows[0]["IsImported"].ToString();

                      
                        AddRights(Profile1, objDataTable.Rows[0]["UserType"].ToString());
                try
                {
                    Profile1.Save();
                }
                catch (Exception)
                {
                    System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\iisreset.exe", "/noforce");
                }
                           
                if (Profile1.UserType == "SA")
                {
                    string redirectUrl = FormsAuthentication.GetRedirectUrl(userName, false);
                    string superAdminPath = ConfigurationManager.AppSettings["SuperAdminDefaultPath"].ToString();
                    string superAdminDirectory = ConfigurationManager.AppSettings["SuperAdminDirectory"].ToString();
                    string[] redirectUrlString = redirectUrl.Split('/');
                    AuthorizationStoreRoleProvider obj = new AuthorizationStoreRoleProvider();

                    string redirectDirectory = "";

                    if (redirectUrlString.Length > 1)
                    {
                        for (int i = 1; i < 3; i++)
                        {
                            redirectDirectory += "/" + redirectUrlString[i].ToString();
                        }
                    }

                    FormsAuthentication.SetAuthCookie(userName, false);
                    if (redirectDirectory != superAdminDirectory)
                    {
                        Response.Redirect("~" + superAdminPath);
                    }
                    else
                    {
                        Response.Redirect(redirectUrl);
                    }
                }
                else
                {
                                FormsAuthentication.RedirectFromLoginPage(userName, false);
                    
                }
            }
        }
        else
        {
            lblErrorMessage.Text = "Invalid username or password.";
        }
        }
        else
        {
            alertdanger.Attributes.Add("style", "display:block");
        }
      }
    }

    public void AddModulesToProfile(ProfileCommon Profile1)
    {
        
        CompanyModulesDB objCompanyModulesDB = new CompanyModulesDB();
        if (!string.IsNullOrEmpty(Profile1.PracticeId.ToString()))
        {
            DataTable dtCompanyModules = objCompanyModulesDB.GetByCompanyId(Profile1.PracticeId);
            if (dtCompanyModules.Rows.Count > 0)
            {
                Profile1.CompanyModuleEMR = dtCompanyModules.Rows[0]["EMR"].ToString();
                Profile1.CompanyModuleAccounting = dtCompanyModules.Rows[0]["Accounting"].ToString();
                
                long CompanyModulesId = long.Parse(dtCompanyModules.Rows[0]["CompanyModulesId"].ToString());

                if (Profile1.CompanyModuleEMR == "True")
                {
                    CompanyEMRModulesDB objCompanyEMRModulesDB = new CompanyEMRModulesDB();

                    DataTable dtCompanyEMRModules = objCompanyEMRModulesDB.GetByCompanyModulesId(CompanyModulesId);

                    if (dtCompanyEMRModules.Rows.Count > 0)
                    {
                        ArrayList MainMenuEMRList = new ArrayList();
                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["Scheduler"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["Scheduler"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["PatientManager"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["PatientManager"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["BillingManager"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["BillingManager"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["LabManager"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["LabManager"].ToString());
                        }

                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["Message"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["Message"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["Settings"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["Settings"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["TriageManager"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["TriageManager"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyEMRModules.Rows[0]["CCM"].ToString()))
                        {
                            MainMenuEMRList.Add(dtCompanyEMRModules.Rows[0]["CCM"].ToString());
                        }
                        
                        Profile1.MainMenuEMR = MainMenuEMRList;
                    }
                }
                
                if (Profile1.CompanyModuleAccounting == "True")
                {
                    CompanyAccountingModulesDB objCompanyAccountingModulesDB = new CompanyAccountingModulesDB();
                    DataTable dtCompanyAccountingModules = objCompanyAccountingModulesDB.GetByCompanyModulesId(CompanyModulesId);
                    if (dtCompanyAccountingModules.Rows.Count > 0)
                    {
                        ArrayList MainMenuAccountingList = new ArrayList();
                        if (!string.IsNullOrEmpty(dtCompanyAccountingModules.Rows[0]["Sales"].ToString()))
                        {
                            MainMenuAccountingList.Add(dtCompanyAccountingModules.Rows[0]["Sales"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyAccountingModules.Rows[0]["Purchase"].ToString()))
                        {
                            MainMenuAccountingList.Add(dtCompanyAccountingModules.Rows[0]["Purchase"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyAccountingModules.Rows[0]["ItemsAndInventory"].ToString()))
                        {
                            MainMenuAccountingList.Add(dtCompanyAccountingModules.Rows[0]["ItemsAndInventory"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyAccountingModules.Rows[0]["Manufacturing"].ToString()))
                        {
                            MainMenuAccountingList.Add(dtCompanyAccountingModules.Rows[0]["Manufacturing"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyAccountingModules.Rows[0]["BankingAndGeneralLedger"].ToString()))
                        {
                            MainMenuAccountingList.Add(dtCompanyAccountingModules.Rows[0]["BankingAndGeneralLedger"].ToString());
                        }
                        
                        if (!string.IsNullOrEmpty(dtCompanyAccountingModules.Rows[0]["Setup"].ToString()))
                        {
                            MainMenuAccountingList.Add(dtCompanyAccountingModules.Rows[0]["Setup"].ToString());
                        }
                        
                        Profile1.MainMenuAccounting = MainMenuAccountingList;
                    }
                }
            }
        }
    }

    //Checking Rights Here
    private void AddRights(ProfileCommon userProfile, string userType)
    {

        StringBuilder str = new StringBuilder();
        UserRightsDB objUserRightsDb = new UserRightsDB();
        DataTable dtRights = objUserRightsDb.GetUsersRights(userProfile.UserId, userType);

        str.Append("<script type='text/javascript'> userRightsArray={");
        ModuleRights objModuleRights = new ModuleRights();


        for (int i = 0; i < dtRights.Rows.Count; i++)
        {
            switch (dtRights.Rows[i]["ModuleRightId"].ToString())
            {
                case "1":
                    objModuleRights.PatientView = true;
                    str.Append("PatientView:'True',");
                    break;
                case "2":
                    objModuleRights.PatientCreate = true;
                    str.Append("PatientCreate:'True',");
                    break;
                case "3":
                    objModuleRights.PatientEdit = true;
                    str.Append("PatientEdit:'True',");
                    break;
                
                case "5":
                    objModuleRights.ClaimsCreate = true;
                    str.Append("ClaimsCreate:'True',");
                    break;
                case "6":
                    objModuleRights.ClaimsEdit = true;
                    objModuleRights.ClaimsEditStatus = dtRights.Rows[i]["Status"].ToString();
                    str.Append("ClaimsEdit:'True',ClaimsEditStatus:'" + dtRights.Rows[i]["Status"] + "',");

                    break;
                case "7":
                    objModuleRights.UnProcessedClaimsView = true;
                    str.Append("UnProcessedClaimsView:'True',");
                    break;
                case "8":
                    objModuleRights.GenerateSubmissionFile = true;
                    str.Append("GenerateSubmissionFile:'True',");
                    break;
                case "9":
                    objModuleRights.SubmissionLogView = true;
                    str.Append("SubmissionLogView:'True',");
                    break;
                case "10":
                    objModuleRights.SubmissionFilesView = true;
                    str.Append("SubmissionFilesView:'True',");
                    break;
                case "11":
                    objModuleRights.SubmissionFilesDownload = true;
                    str.Append("SubmissionFilesDownload:'True',");
                    break;
                case "12":
                    objModuleRights.ClaimPaymentView = true;
                    str.Append("ClaimPaymentView:'True',");
                    break;
                case "13":
                    objModuleRights.ClaimPaymentSend = true;
                    str.Append("ClaimPaymentSend:'True',");
                    break;
                case "14":
                    objModuleRights.ProcessFileCreate = true;
                    str.Append("ProcessFileCreate:'True',");
                    break;
                case "15":
                    objModuleRights.EobCreate = true;
                    str.Append("EobCreate:'True',");
                    break;
                case "16":
                    objModuleRights.PayRollCreate = true;
                    str.Append("PayRollCreate:'True',");
                    break;

                case "21":
                    objModuleRights.MedicationView = true;
                    str.Append("MedicationView:'True',");
                    break;
                case "22":
                    objModuleRights.MedicationAdd = true;
                    str.Append("MedicationAdd:'True',");
                    break;
                case "23":
                    objModuleRights.MedicationEdit = true;
                    str.Append("MedicationEdit:'True',");
                    break;
                case "24":
                    objModuleRights.MedicationDelete = true;
                    str.Append("MedicationDelete:'True',");
                    break;
                case "25":
                    objModuleRights.AllergyView = true;
                    str.Append("AllergyView:'True',");
                    break;
                case "26":
                    objModuleRights.AllergyAdd = true;
                    str.Append("AllergyAdd:'True',");
                    break;
                case "27":
                    objModuleRights.AllergyEdit = true;
                    str.Append("AllergyEdit:'True',");
                    break;
                case "28":
                    objModuleRights.AllergyDelete = true;
                    str.Append("AllergyDelete:'True',");
                    break;
                case "29":
                    objModuleRights.InsuranceView = true;
                    str.Append("InsuranceView:'True',");
                    break;
                case "30":
                    objModuleRights.InsuranceAdd = true;
                    str.Append("InsuranceAdd:'True',");
                    break;
                case "31":
                    objModuleRights.InsuranceEdit = true;
                    str.Append("InsuranceEdit:'True',");
                    break;
                case "32":
                    objModuleRights.InsuranceDelete = true;
                    str.Append("InsuranceDelete:'True',");
                    break;
                case "33":
                    objModuleRights.PracticeLocationsView = true;
                    objModuleRights.PracticeLocationsViewLocations = dtRights.Rows[i]["Status"].ToString();
                    str.Append("PracticeLocationsView:'True',PracticeLocationsViewLocations:'" + dtRights.Rows[i]["Status"] + "',");
                    break;
                case "34":
                    objModuleRights.PracticeLocationsAdd = true;
                    str.Append("PracticeLocationsAdd:'True',");
                    break;
                case "35":
                    objModuleRights.PracticeLocationsEdit = true;
                    objModuleRights.PracticeLocationsEditLocations = dtRights.Rows[i]["Status"].ToString();
                    str.Append("PracticeLocationsEdit:'True',PracticeLocationsEditLocations:'" + dtRights.Rows[i]["Status"] + "',");
                    break;
                case "36":
                    objModuleRights.PracticeLocationsDelete = true;
                    objModuleRights.PracticeLocationsDeleteLocations = dtRights.Rows[i]["Status"].ToString();
                    str.Append("PracticeLocationsDelete:'True',PracticeLocationsDeleteLocations:'" + dtRights.Rows[i]["Status"] + "',");
                    break;
                case "81":
                    objModuleRights.PracticeView = true;
                    str.Append("PracticeView:'True',");
                    break;
                case "82":
                    objModuleRights.PracticeEdit = true;
                    str.Append("PracticeEdit:'True',");
                    break;

                case "89":
                    objModuleRights.PatientInsuranceView = true;
                    str.Append("PatientInsuranceView:'True',");
                    break;
                case "90":
                    objModuleRights.PatientInsuranceAdd = true;
                    str.Append("PatientInsuranceAdd:'True',");
                    break;
                case "91":
                    objModuleRights.PatientInsuranceEdit = true;
                    str.Append("PatientInsuranceEdit:'True',");
                    break;
                case "92":
                    objModuleRights.PatientInsuranceDelete = true;
                    str.Append("PatientInsuranceDelete:'True',");
                    break;
                case "102":
                    objModuleRights.ProviderTimingsView = true;
                    str.Append("ProviderTimingsView:'True',");
                    break;
                case "103":
                    objModuleRights.ProviderTimingsEdit = true;
                    str.Append("ProviderTimingsEdit:'True',");
                    break;

                case "104":
                    objModuleRights.AppointmentsView = true;
                    str.Append("AppointmentsView:'True',");
                    break;
                case "105":
                    objModuleRights.AppointmentsAdd = true;
                    objModuleRights.AppointmentsAddStatus = dtRights.Rows[i]["Status"].ToString();
                    str.Append("AppointmentsAdd:'True',AppointmentsAddStatus:'" + dtRights.Rows[i]["Status"] + "',");
                    break;
                case "106":
                    objModuleRights.AppointmentsEdit = true;
                    objModuleRights.AppointmentsEditStatus = dtRights.Rows[i]["Status"].ToString();
                    str.Append("AppointmentsEdit:'True',AppointmentsEditStatus:'" + dtRights.Rows[i]["Status"] + "',");
                    break;
                case "107":
                    objModuleRights.AppointmentsDelete = true;
                    str.Append("AppointmentsDelete:'True',");
                    break;
                case "109":
                    objModuleRights.ReportsView = true;
                    str.Append("ReportsView:'True',");
                    break;
                case "112":
                    objModuleRights.UserRoleView = true;
                    str.Append("UserRoleView:'True',");
                    break;
                case "113":
                    objModuleRights.UserRoleAdd = true;
                    str.Append("UserRoleAdd:'True',");
                    break;
                case "114":
                    objModuleRights.UserRoleEdit = true;
                    str.Append("UserRoleEdit:'True',");
                    break;
                case "115":
                    objModuleRights.UserRoleDelete = true;
                    str.Append("UserRoleDelete:'True',");
                    break;
                case "116":
                    objModuleRights.UserRightEdit = true;
                    str.Append("UserRightEdit:'True',");
                    break;
                case "117":
                    objModuleRights.UserRightView = true;
                    str.Append("UserRightView:'True',");
                    break;
                case "123":
                    objModuleRights.PatientClinicalExamsView = true;
                    str.Append("PatientClinicalExamsView:'True',");
                    break;
                case "124":
                    objModuleRights.PatientClinicalExamsAdd = true;
                    str.Append("PatientClinicalExamsAdd:'True',");
                    break;
                case "125":
                    objModuleRights.PatientClinicalExamsEdit = true;
                    str.Append("PatientClinicalExamsEdit:'True',");
                    break;
                case "126":
                    objModuleRights.PatientClinicalExamsDelete = true;
                    str.Append("PatientClinicalExamsDelete:'True',");
                    break;
                case "127":
                    objModuleRights.PatientDocumentsView = true;
                    str.Append("PatientDocumentsView:'True',");
                    break;
                case "129":
                    objModuleRights.PatientDocumentsAdd = true;
                    str.Append("PatientDocumentsAdd:'True',");
                    break;
                case "130":
                    objModuleRights.PatientDocumentsEdit = true;
                    str.Append("PatientDocumentsEdit:'True',");
                    break;
                case "131":
                    objModuleRights.PatientDocumentsDelete = true;
                    str.Append("PatientDocumentsDelete:'True',");
                    break;
                case "149":
                    objModuleRights.ServiceProvidersView = true;
                    str.Append("ServiceProvidersView:'True',");
                    break;
                case "150":
                    objModuleRights.ServiceProvidersAdd = true;
                    str.Append("ServiceProvidersAdd:'True',");
                    break;
                case "151":
                    objModuleRights.ServiceProvidersEdit = true;
                    str.Append("ServiceProvidersEdit:'True',");
                    break;
                case "152":
                    objModuleRights.ServiceProvidersDelete = true;
                    str.Append("ServiceProvidersDelete:'True',");
                    break;

                case "153":
                    objModuleRights.PracticeRoomView = true;
                    str.Append("PracticeRoomView:'True',");
                    break;
                case "154":
                    objModuleRights.PracticeRoomAdd = true;
                    str.Append("PracticeRoomAdd:'True',");
                    break;
                case "155":
                    objModuleRights.PracticeRoomEdit = true;
                    str.Append("PracticeRoomEdit:'True',");
                    break;
                case "156":
                    objModuleRights.PracticeRoomDelete = true;
                    str.Append("PracticeRoomDelete:'True',");
                    break;

                case "157":
                    objModuleRights.PracticeUsersView = true;
                    str.Append("PracticeUsersView:'True',");
                    break;
                case "158":
                    objModuleRights.PracticeUsersAdd = true;
                    str.Append("PracticeUsersAdd:'True',");
                    break;
                case "159":
                    objModuleRights.PracticeUsersEdit = true;
                    str.Append("PracticeUsersEdit:'True',");
                    break;
                case "160":
                    objModuleRights.PracticeUsersDelete = true;
                    str.Append("PracticeUsersDelete:'True',");
                    break;

                case "161":
                    objModuleRights.AppointmentTypesView = true;
                    str.Append("AppointmentTypesView:'True',");
                    break;
                case "162":
                    objModuleRights.AppointmentTypesAdd = true;
                    str.Append("AppointmentTypesAdd:'True',");
                    break;
                case "163":
                    objModuleRights.AppointmentTypesEdit = true;
                    str.Append("AppointmentTypesEdit:'True',");
                    break;
                case "164":
                    objModuleRights.AppointmentTypesDelete = true;
                    str.Append("AppointmentTypesDelete:'True',");
                    break;

                case "165":
                    objModuleRights.ChartTemplatesView = true;
                    str.Append("ChartTemplatesView:'True',");
                    break;
                case "166":
                    objModuleRights.ChartTemplatesAdd = true;
                    str.Append("ChartTemplatesAdd:'True',");
                    break;
                case "167":
                    objModuleRights.ChartTemplatesEdit = true;
                    str.Append("ChartTemplatesEdit:'True',");
                    break;
                case "168":
                    objModuleRights.ChartTemplatesDelete = true;
                    str.Append("ChartTemplatesDelete:'True',");
                    break;
                case "172":
                    objModuleRights.OrdersView = true;
                    str.Append("OrdersView:'True',");
                    break;
                case "177":
                    objModuleRights.OrdersAdd = true;
                    str.Append("OrdersAdd:'True',");
                    break;
                case "179":
                    objModuleRights.OrdersEdit = true;
                    str.Append("OrdersEdit:'True',");
                    break;
                case "180":
                    objModuleRights.OrdersDelete = true;
                    str.Append("OrdersDelete:'True',");
                    break;

                case "181":
                    objModuleRights.OrdersResultsView = true;
                    str.Append("OrdersResultsView:'True',");
                    break;
                case "182":
                    objModuleRights.OrdersResultsAdd = true;
                    str.Append("OrdersResultsAdd:'True',");
                    break;
                case "183":
                    objModuleRights.OrdersResultsEdit = true;
                    str.Append("OrdersResultsEdit:'True',");
                    break;
                case "184":
                    objModuleRights.OrdersResultsDelete = true;
                    str.Append("OrdersResultsDelete:'True',");
                    break;
                case "185":
                    objModuleRights.OrdersResultsSign = true;
                    str.Append("OrdersResultsSign:'True',");
                    break;
                case "186":
                    objModuleRights.ClaimsSpecificView = true;
                    str.Append("ClaimsSpecificView:'True',");
                    break;
                case "191":
                    objModuleRights.PaymentsSpecificView = true;
                    str.Append("PaymentsSpecificView:'True',");
                    break;
                case "206":
                    objModuleRights.PatientInvocie = true;
                    str.Append("PatientInvocie:'True',");
                    break;
                case "210":
                    objModuleRights.ClaimsView = true;
                    str.Append("ClaimsView:'True',");
                    break;
                case "212":
                    objModuleRights.Scheduler = true;
                    str.Append("Scheduler:'True',");
                    break;
                case "214":
                    objModuleRights.Payments = true;
                    str.Append("Payments:'True',");
                    break;
                case "218":
                    objModuleRights.Eligibility = true;
                    str.Append("Eligibility:'True',");
                    break;
                case "220":
                    objModuleRights.Dashboard = true;
                    str.Append("Dashboard:'True',");
                    break;
                case "221":
                    objModuleRights.CustomerSupport = true;
                    str.Append("CustomerSupport:'True',");
                    break;
                case "228":
                    objModuleRights.PaymentView = true;
                    str.Append("PaymentView:'True',");
                    break;
                case "229":
                    objModuleRights.InsuranceCredentialling = true;
                    str.Append("InsuranceCredentialling:'True',");
                    break;
                case "230":
                    objModuleRights.EDIERAUser = true;
                    str.Append("EDIERAUser:'True',");
                    break;
                case "231":
                    objModuleRights.ClientInvoices = true;
                    str.Append("ClientInvoices:'True',");
                    break;
            }
        }

        if (objModuleRights.ClaimsSpecificView == true)
        {
            Session["SpecificView"] = Profile.UserId.ToString();
            string a = Session["SpecificView"].ToString();
        }
        if (objModuleRights.PaymentsSpecificView == true)
        {
            Session["PaymentsSpecificView"] = Profile.UserId.ToString();
            
        }
       
        str.ToString().TrimEnd(',');
        str.Append("}; </script>");
        userProfile.Rights = str.ToString();
        userProfile.RightsServer = objModuleRights;
    }
}
