using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

public partial class EMR_Claims_ClaimFormView : System.Web.UI.Page
{
    string ProviderNPI = "";
    string POS = "";
    string EPSDT = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["isCMSBlank"] != null)
        {
            bool isCMSBlank = bool.Parse(Request.QueryString["isCMSBlank"].ToString());
            if (!isCMSBlank)
            {
                imgCMSBG.Style["display"] = "none";
            }
        }

        long ClaimId = 0;
        long PatientId = 0;

        if (Request.QueryString["ClaimId"] != null)
        {
            ClaimId = long.Parse(Request.QueryString["ClaimId"].ToString());
        }

        if (Request.QueryString["PatientId"] != null)
        {
            PatientId = long.Parse(Request.QueryString["PatientId"].ToString());
        }

        LoadClaimData(ClaimId, PatientId);
        LoadClaimServices(ClaimId);

    }

    private void LoadClaimData(long ClaimId, long PatientId)
    {
        ClaimDB objClaimDB = new ClaimDB();

        DataSet dsClaimData = objClaimDB.GetInformationForCMS1500(ClaimId, PatientId);
        DataTable dtClaimData = dsClaimData.Tables[0];
        string address = "", city = "", state = "", zip = "", gender = "", relation = "", locatoin = "";

        if (dtClaimData.Rows.Count > 0)
        {
            ///**********Start Primary Insurance Detail**********/
            string PrimaryInsurance = "";
            PrimaryInsurance = dtClaimData.Rows[0]["PriInsuranceName"].ToString()+"<br />";

            PrimaryInsurance += dtClaimData.Rows[0]["PriHeadOfficeAddress"].ToString()+"<br />";
            city = dtClaimData.Rows[0]["PriCity"].ToString();
            if (!string.IsNullOrEmpty(city))
            {
                PrimaryInsurance +=  city;
            }
            state = dtClaimData.Rows[0]["PriState"].ToString();
            if (!string.IsNullOrEmpty(state))
            {
                PrimaryInsurance += ", " + state;
            }
            zip = dtClaimData.Rows[0]["PriZip"].ToString();
            if (!string.IsNullOrEmpty(zip))
            {
                PrimaryInsurance += ", " + zip;
            }
            lblPrimaryInsurance.Text = PrimaryInsurance;
            lblPriInsurancePlanName.Text = dtClaimData.Rows[0]["PatPriGroupName"].ToString();
            ///**********End Primary Insurance Detail**********/
            
            /**********Start Primary Insurance Subscriber Details**********/

            lblInsuranceSubscriberName.Text = dtClaimData.Rows[0]["PriSubscriberName"].ToString();
            lblPatientId.Text = PatientId.ToString();
            address = dtClaimData.Rows[0]["PriSubscriberAddress"].ToString();
            if (address == "No Address") { lblInsuranceSubscriberAddress.Text = ""; }
            else { lblInsuranceSubscriberAddress.Text = address; }
            city = dtClaimData.Rows[0]["PriSubscriberCity"].ToString();
            state = dtClaimData.Rows[0]["PriSubscriberState"].ToString();
            zip = dtClaimData.Rows[0]["PriSubscriberZip"].ToString();
            if (zip == "00000") {

                lblInsuranceSubscriberCity.Text = "";
                lblInsuranceSubscriberState.Text = "";
                lblInsuranceSubscriberZip.Text = "";
            }
            else
            {
                lblInsuranceSubscriberCity.Text = city;
                lblInsuranceSubscriberState.Text = state;
                lblInsuranceSubscriberZip.Text = zip;
            }
            string PriSubscriberPhone = dtClaimData.Rows[0]["PriSubscriberPhone"].ToString();
            if (!string.IsNullOrEmpty(PriSubscriberPhone))
            {
                PriSubscriberPhone.Split(' ');
                lblInsuranceSubscriberAreaCode.Text = PriSubscriberPhone.Split(' ')[0].Replace("(", "").Replace(")", "");
                lblInsuranceSubscriberPhone.Text = PriSubscriberPhone.Split(' ')[1];
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["PriSubscriberDateOfBirth"].ToString()))
            {
                DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["PriSubscriberDateOfBirth"].ToString());
                lblInsuranceSubscriberDOBdd.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                lblInsuranceSubscriberDOBmm.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                lblInsuranceSubscriberDOByy.Text = dt.Year.ToString().Substring(2, 2);
            }

            gender = dtClaimData.Rows[0]["PriSubscriberGender"].ToString();
            if (gender == "Male")
            {
                lblInsuranceSubscriberGenderM.Text = "X";
            }
            else
            {
                lblInsuranceSubscriberGenderF.Text = "X";
            }

            lblInsuranceSubscriberGroupNumber.Text = dtClaimData.Rows[0]["PatPriGroupNumber"].ToString();
            /**********End Primary Insurance Subscriber Details**********/

            /**********Start Patient Details**********/
            lblPatientName.Text = dtClaimData.Rows[0]["PatName"].ToString();

            address = dtClaimData.Rows[0]["PatAddress"].ToString();
            if (address == "No Address") { lblPatientAddress.Text = ""; }
            else { lblPatientAddress.Text = address; }
          
            zip = dtClaimData.Rows[0]["PatZip"].ToString();
            state = dtClaimData.Rows[0]["PatState"].ToString();
            city = dtClaimData.Rows[0]["PatCity"].ToString();
            if (zip == "00000") {
                lblPatientCity.Text = "";
                lblPatientState.Text = "";
                lblPatientZip.Text = "";
            }
            else
            {             
                lblPatientCity.Text = city;               
                lblPatientState.Text = state;
                lblPatientZip.Text = zip;
            }

            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["PatDateOfBirth"].ToString()))
            {
                DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["PatDateOfBirth"].ToString());
                lblPatientDOBdd.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                lblPatientDOBmm.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                lblPatientDOByy.Text = dt.Year.ToString().Substring(2, 2);
            }
            gender = dtClaimData.Rows[0]["PatGender"].ToString();
            if (gender == "Male")
            {
                lblPatientGenderM.Text = "X";
            }
            else
            {
                lblPatientGenderF.Text = "X";
            }

            string Phone = dtClaimData.Rows[0]["HomePhone"].ToString();
            bool ComparePhoneNo = System.Text.RegularExpressions.Regex.Match(Phone, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$").Success;
            if (!string.IsNullOrEmpty(Phone))
            {
            if (ComparePhoneNo == false)
            {
                int loc = 3;
                for (int ins = loc; ins < Phone.Length; ins += loc + 7)
                    Phone = Phone.Insert(ins, "-");
                var P=Phone.Split('-');
                lblPhoneAreaCode.Text = P[0];
                lblPhoneNumber.Text = P[1];
            }
            else if (ComparePhoneNo == true)
            {           
                Phone.Split(' ');
                lblPhoneAreaCode.Text = Phone.Split(' ')[0].Replace("(", "").Replace(")", "");
                lblPhoneNumber.Text = Phone.Split(' ')[1];
            }
           }
            lblClaimId.Text = dtClaimData.Rows[0]["ClaimId"].ToString();

            relation = dtClaimData.Rows[0]["PatPriRelationship"].ToString();
            if (relation == "Self")
            {
                lblPatientRelationshipToSubscriberSelf.Text = "X";

                lblInsuranceSubscriberName.Text = dtClaimData.Rows[0]["PatName"].ToString();
                lblPatientId.Text = PatientId.ToString();
                address = dtClaimData.Rows[0]["PatAddress"].ToString();
                if (address == "No Address") { lblInsuranceSubscriberAddress.Text = ""; }
                else { lblInsuranceSubscriberAddress.Text = address; }
                city = dtClaimData.Rows[0]["PatCity"].ToString();
                state = dtClaimData.Rows[0]["PatState"].ToString();
                zip = dtClaimData.Rows[0]["PatZip"].ToString();
                if (zip == "00000")
                {
                    lblInsuranceSubscriberCity.Text = "";
                    lblInsuranceSubscriberState.Text = "";
                    lblInsuranceSubscriberZip.Text = "";
                }
                else { 
                lblInsuranceSubscriberCity.Text = city;               
                lblInsuranceSubscriberState.Text = state;             
                lblInsuranceSubscriberZip.Text = zip;
                }
                PriSubscriberPhone = dtClaimData.Rows[0]["HomePhone"].ToString();
                bool ComparePriSubscriberPhone = System.Text.RegularExpressions.Regex.Match(PriSubscriberPhone, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$").Success;
                if (!string.IsNullOrEmpty(PriSubscriberPhone))
                {
                if (ComparePriSubscriberPhone == false)
                {
                    int loc = 3;
                    for (int ins = loc; ins < PriSubscriberPhone.Length; ins += loc + 7)
                        PriSubscriberPhone = PriSubscriberPhone.Insert(ins, "-");
                    var PSP = PriSubscriberPhone.Split('-');
                    lblInsuranceSubscriberAreaCode.Text = PSP[0];
                    lblInsuranceSubscriberPhone.Text = PSP[1];
                }
                else if (ComparePriSubscriberPhone == true){              
                    PriSubscriberPhone.Split(' ');
                    lblInsuranceSubscriberAreaCode.Text = PriSubscriberPhone.Split(' ')[0].Replace("(", "").Replace(")", "");
                    lblInsuranceSubscriberPhone.Text = PriSubscriberPhone.Split(' ')[1];
                }
                }
                if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["PatDateOfBirth"].ToString()))
                {
                    DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["PatDateOfBirth"].ToString());
                    lblInsuranceSubscriberDOBdd.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                    lblInsuranceSubscriberDOBmm.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                    lblInsuranceSubscriberDOByy.Text = dt.Year.ToString().Substring(2, 2); ;
                }

                gender = dtClaimData.Rows[0]["PatGender"].ToString();
                if (gender == "Male")
                {
                    lblInsuranceSubscriberGenderM.Text = "X";
                }
                else
                {
                    lblInsuranceSubscriberGenderF.Text = "X";
                }
            }
            else if (relation == "Spouse")
            {
                lblPatientRelationshipToSubscriberSpouse.Text = "X";
            }
            else if (relation == "Children")
            {
                lblPatientRelationshipToSubscriberDependentChild.Text = "X";
            }
            else if (relation == "Other")
            {
                lblPatientRelationshipToSubscriberOther.Text = "X";
            }

            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["PatientPaidAmmount"].ToString()))
            {
                string[] PatientPaidAmmount = dtClaimData.Rows[0]["PatientPaidAmmount"].ToString().Split('.');
                lblPatientPaidAmmount.Text = PatientPaidAmmount[0];
                lblPatientPaidAmmount1.Text = PatientPaidAmmount[1];
            }


            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["AdmissionDate"].ToString()))
            {
                DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["AdmissionDate"].ToString());
                lblPatientAdmissionDD.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                lblPatientAdmissionMM.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                lblPatientAdmissionYY.Text = dt.Year.ToString().Substring(2, 2);
            }

            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["DischargeDate"].ToString()))
            {
                DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["DischargeDate"].ToString());
                lblPatientDischageDD.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                lblPatientDischageMM.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                lblPatientDischageYY.Text = dt.Year.ToString().Substring(2, 2);
            }
            lblpaNumber.Text = dtClaimData.Rows[0]["PANumber"].ToString();
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["OnSetOfCurrentIllness"].ToString()))
            {
                DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["OnSetOfCurrentIllness"].ToString());
                lblCurrentIllnessDD.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                lblCurrentIllnessMM.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                lblCurrentIllnessYY.Text = dt.Year.ToString().Substring(2, 2);
                lblCurrentIllnessQual.Text = "431";
            }
            else
            {
                if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["LMPDate"].ToString()))
                {
                    DateTime dt = Convert.ToDateTime(dtClaimData.Rows[0]["LMPDate"].ToString());
                    lblCurrentIllnessDD.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                    lblCurrentIllnessMM.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                    lblCurrentIllnessYY.Text = dt.Year.ToString().Substring(2, 2);
                    lblCurrentIllnessQual.Text = "484";
                }
            }
            string PatientOtherDate = "";
            string PatientOtherQUAL = "";
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["AccidentAuto"].ToString()))
            {
                bool AccidentAuto = bool.Parse(dtClaimData.Rows[0]["AccidentAuto"].ToString());
                if (AccidentAuto)
                    lblAutoAccidentYes.Text = "X";
                else
                    lblAutoAccidentNo.Text = "X";
                lblAutoAccidentState.Text = dtClaimData.Rows[0]["AccidentState"].ToString();
                PatientOtherDate = dtClaimData.Rows[0]["AccidentDate"].ToString();
                PatientOtherQUAL = "439";
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["AccidentOther"].ToString()))
            {
                bool AccidentOther = bool.Parse(dtClaimData.Rows[0]["AccidentOther"].ToString());
                if (AccidentOther)
                    lblOtherAccidentYes.Text = "X";
                else
                    lblOtherAccidentNo.Text = "X";
                PatientOtherDate = dtClaimData.Rows[0]["AccidentDate"].ToString();
                PatientOtherQUAL = "439";
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["Employment"].ToString()))
            {
                bool Employment = bool.Parse(dtClaimData.Rows[0]["Employment"].ToString());
                if (Employment)
                    lblEmploymentYes.Text = "X";
                else
                    lblEmploymentNo.Text = "X";
                PatientOtherDate = dtClaimData.Rows[0]["AccidentDate"].ToString();
                PatientOtherQUAL = "439";
            }

            if (string.IsNullOrEmpty(PatientOtherDate))
            {
                PatientOtherDate = dtClaimData.Rows[0]["XRayDate"].ToString();
                PatientOtherQUAL = "455";
            }
            else if (string.IsNullOrEmpty(PatientOtherDate))
            {
                PatientOtherDate = dtClaimData.Rows[0]["InitialTreatmentDate"].ToString();
                PatientOtherQUAL = "454";
            }
            else if (string.IsNullOrEmpty(PatientOtherDate))
            {
                PatientOtherDate = dtClaimData.Rows[0]["AcuteManifestation"].ToString();
                PatientOtherQUAL = "453";
            }

            if (!string.IsNullOrEmpty(PatientOtherDate))
            {
                DateTime dt = Convert.ToDateTime(PatientOtherDate);
                lblPatientOtherDD.Text = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
                lblPatientOtherMM.Text = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
                lblPatientOtherYY.Text = dt.Year.ToString().Substring(2, 2);
                lblPatientOtherQual.Text = PatientOtherQUAL;
            }
            EPSDT = dtClaimData.Rows[0]["EpsdtCode"].ToString();

            /**********End Patient Details**********/

            ///**********Start Secondary Insurance Detail**********/
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["SecInsuranceName"].ToString()))
            {
                lblIsOtherInsurancePlanYes.Text = "X";
            }
            else
                lblIsOtherInsurancePlanNo.Text = "X";
            //lblOtherInsuranceCompanyName.Text = dtClaimData.Rows[0]["SecInsuranceName"].ToString();

            //address = dtClaimData.Rows[0]["SecHeadOfficeAddress"].ToString();
            //lblOtherInsuranceCompanyAddress.Text = address;
            //city = dtClaimData.Rows[0]["SecCity"].ToString();
            //if (!string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(address))
            //{
            //    city = ", " + city;
            //}
            //lblOtherInsuranceCompanyCity.Text = city;

            //state = dtClaimData.Rows[0]["SecState"].ToString();
            //if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(city))
            //{
            //    state = ", " + state;
            //}
            //lblOtherInsuranceCompanyState.Text = state;

            //zip = dtClaimData.Rows[0]["SecZip"].ToString();
            //if (!string.IsNullOrEmpty(zip) && !string.IsNullOrEmpty(state))
            //{
            //    zip = ", " + zip;
            //}
            //lblOtherInsuranceCompanyZip.Text = zip;
            lblOtherInsurancePlan.Text = dtClaimData.Rows[0]["PatSecGroupName"].ToString();
            ///**********End Secondary Insurance Detail**********/
            
            /**********Start Secondary Insurance Subscriber Details**********/
            lblOtherInsuranceSubscriberName.Text = dtClaimData.Rows[0]["SecSubscriberName"].ToString();


            lblOtherInsuranceSubscriberGroupNumber.Text = dtClaimData.Rows[0]["PatSecGroupNumber"].ToString();

            /**********End Secondary Insurance Subscriber Details**********/

            /**********Start Billing Physician Details**********/
            lblBillingPhysicianName.Text = dtClaimData.Rows[0]["BillingPhysicianName"].ToString();

            address = dtClaimData.Rows[0]["BillingPhysicianAddress"].ToString();
            if (!string.IsNullOrEmpty(address))
            {
                address = address + ",";
            }
            lblBillingPhysicianAddress.Text = address;

            city = dtClaimData.Rows[0]["BillingPhysicianCity"].ToString();
            lblBillingPhysicianCity.Text = city;

            state = dtClaimData.Rows[0]["BillingPhysicianState"].ToString();
            if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(city))
            {
                state = ", " + state;
            }
            lblBillingPhysicianState.Text = state;

            zip = dtClaimData.Rows[0]["BillingPhysicianZip"].ToString();
            if (!string.IsNullOrEmpty(zip) && !string.IsNullOrEmpty(state))
            {
                zip = ", " + zip;
            }
            lblBillingPhysicianZip.Text = zip;

            lblBillingPhysicianNPI.Text = dtClaimData.Rows[0]["BillingPhysicianNPI"].ToString();
            lblBillingPhysicianLicense.Text = "OB" + dtClaimData.Rows[0]["BillingPhysicianLicenseNumber"].ToString();
            lblBillingPhysicianTaxId.Text = dtClaimData.Rows[0]["BillingPhysicianTIN"].ToString();

            string BillingPhysicianCell = dtClaimData.Rows[0]["BillingPhysicianCell"].ToString();
            string BillingPhysicianCellExt = "";
            string BillingPhysicianCellNumber = "";
            if (!string.IsNullOrEmpty(BillingPhysicianCell))
            {
                BillingPhysicianCellExt = BillingPhysicianCell.Substring(1, 3);
                BillingPhysicianCellNumber = BillingPhysicianCell.Substring(5, 8);

                lblBillingPhysicianPhoneExt.Text = BillingPhysicianCellExt;
                lblBillingPhysicianPhone.Text = BillingPhysicianCellNumber;
            }
            /**********End Billing Physician Details**********/


            ///**********Start Treating Physician Details**********/

            //address = dtClaimData.Rows[0]["TreatingPhysicianAddress"].ToString();
            //if (!string.IsNullOrEmpty(address))
            //{
            //    address = address + ",";
            //}
            //lblTreatingPhysicianAddress.Text = address;

            //city = dtClaimData.Rows[0]["TreatingPhysicianCity"].ToString();
            //lblTreatingPhysicianCity.Text = city;

            //state = dtClaimData.Rows[0]["TreatingPhysicianState"].ToString();
            //if (!string.IsNullOrEmpty(state) && !string.IsNullOrEmpty(city))
            //{
            //    state = ", " + state;
            //}
            //lblTreatingPhysicianState.Text = state;

            //zip = dtClaimData.Rows[0]["TreatingPhysicianZip"].ToString();
            //if (!string.IsNullOrEmpty(zip) && !string.IsNullOrEmpty(state))
            //{
            //    zip = ", " + zip;
            //}
            //lblTreatingPhysicianZip.Text = zip;

            //lblTreatingPhysicianNPI.Text = dtClaimData.Rows[0]["TreatingPhysicianNPI"].ToString();
            //lblTreatingPhysicianLicense.Text = dtClaimData.Rows[0]["TreatingPhysicianLicenseNumber"].ToString();
            //lblTreatingPhysicianTaxonomyCode.Text = dtClaimData.Rows[0]["TreatingPhysicianSpecialityCode"].ToString();

            //string TreatingPhysicianCell = dtClaimData.Rows[0]["TreatingPhysicianCell"].ToString();
            //string TreatingPhysicianCellExt = "";
            //string TreatingPhysicianCellNumber = "";
            //if (!string.IsNullOrEmpty(TreatingPhysicianCell))
            //{
            //    TreatingPhysicianCellExt = TreatingPhysicianCell.Substring(1, 3);
            //    TreatingPhysicianCellNumber = TreatingPhysicianCell.Substring(5, 8);

            //    lblTreatingPhysicianPhoneExt.Text = TreatingPhysicianCellExt;
            //    lblTreatingPhysicianPhoneNumber.Text = TreatingPhysicianCellNumber;
            //}

            ProviderNPI = dtClaimData.Rows[0]["RenderingPhysicianNPI"].ToString();
            string treatingPhysician = "";

            treatingPhysician = dtClaimData.Rows[0]["TreatingPhysicianName"].ToString();
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["TreatingPhysicianType"].ToString()))
            {
                treatingPhysician += ", " + dtClaimData.Rows[0]["TreatingPhysicianType"].ToString();
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["TreatingPhysicianDegree"].ToString()))
            {
                treatingPhysician += ", " + dtClaimData.Rows[0]["TreatingPhysicianDegree"].ToString();
            }

            lblTreatingPhysician.Text = treatingPhysician;
            lblTreatingPhysicianSigDate.Text = DateTime.Now.ToShortDateString();
            ///**********End Treating Physician Details**********/


            ///**********Start Referring Physician Details**********/

            lblReferringPhysician.Text = dtClaimData.Rows[0]["ReferringPhysicianName"].ToString();
            lblReferringPhysicianNPI.Text = dtClaimData.Rows[0]["ReferringPhysicianNPI"].ToString();
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["ReferringPhysicianUPIN"].ToString()))
            {
                lblReferringPhysicianUPIN.Text = dtClaimData.Rows[0]["ReferringPhysicianUPIN"].ToString();
                lblReferringPhysicianUPINQual.Text = "1G";
            }

            ///**********End Referring Physician Details**********/

            /**********Start DxCode Codes**********/
            lblDxCode1.Text = dtClaimData.Rows[0]["DxCode1"].ToString();
            lblDxCode2.Text = dtClaimData.Rows[0]["DxCode2"].ToString();
            lblDxCode3.Text = dtClaimData.Rows[0]["DxCode3"].ToString();
            lblDxCode4.Text = dtClaimData.Rows[0]["DxCode4"].ToString();
            lblDxCode5.Text = dtClaimData.Rows[0]["DxCode5"].ToString();
            lblDxCode6.Text = dtClaimData.Rows[0]["DxCode6"].ToString();
            lblDxCode7.Text = dtClaimData.Rows[0]["DxCode7"].ToString();
            lblDxCode8.Text = dtClaimData.Rows[0]["DxCode8"].ToString();
            /**********End DxCode Codes**********/

            /**********PracticeLocationInforation********/
            //if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["PracticeLocationsId"].ToString()))
            //{
            //    locatoin = dtClaimData.Rows[0]["Location"].ToString();
            //    if (!string.IsNullOrEmpty(locatoin))
            //    {
            //        locatoin = "<span class='bold'>" + locatoin + "</span><br />";
            //    }
            //    if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["LocationAddress"].ToString()))
            //    {
            //        locatoin += dtClaimData.Rows[0]["LocationAddress"].ToString() + ",<br />";
            //    }
            //    if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["LocationCity"].ToString()))
            //    {
            //        locatoin += dtClaimData.Rows[0]["LocationCity"].ToString() + ", ";
            //    }
            //    if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["LocationState"].ToString()))
            //    {
            //        locatoin += dtClaimData.Rows[0]["LocationState"].ToString() + ", ";
            //    }
            //    if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["LocationZip"].ToString()))
            //    {
            //        locatoin += dtClaimData.Rows[0]["LocationZip"].ToString() + ", ";
            //    }
            //    if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["PrimaryContact"].ToString()))
            //    {
            //        locatoin += dtClaimData.Rows[0]["PrimaryContact"].ToString() + ", ";
            //    }
            //    lblLocationInformation.Text = locatoin;
            //}

            /**********ServiceLocationInforation********/
            locatoin = dtClaimData.Rows[0]["ServiceFacilityLocationName"].ToString();
            if (!string.IsNullOrEmpty(locatoin))
            {
                locatoin = "<span class='bold'>" + locatoin + "</span><br />";
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["ServiceFacilityAddress"].ToString()))
            {
                locatoin += dtClaimData.Rows[0]["ServiceFacilityAddress"].ToString() + ",<br />";
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["ServiceFacilityCity"].ToString()))
            {
                locatoin += dtClaimData.Rows[0]["ServiceFacilityCity"].ToString() + ", ";
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["ServiceFacilityState"].ToString()))
            {
                locatoin += dtClaimData.Rows[0]["ServiceFacilityState"].ToString() + ", ";
            }
            if (!string.IsNullOrEmpty(dtClaimData.Rows[0]["ServiceFacilityZip"].ToString()))
            {
                locatoin += dtClaimData.Rows[0]["ServiceFacilityZip"].ToString() + ", ";
            }
            lblLocationInformation.Text = locatoin;
            lblLocationNPI.Text = dtClaimData.Rows[0]["ServiceFacilityNPI"].ToString();

            POS = dtClaimData.Rows[0]["POS"].ToString();
            lblPracticeTaxId.Text = dtClaimData.Rows[0]["TaxID"].ToString();
        }
    }

    private void LoadClaimServices(long ClaimId)
    {
        StringBuilder startUpScript = new StringBuilder();
        startUpScript.Append("<script type=text/javascript>");
        startUpScript.Append("var _arrClaimsServices = new Array();");

        if (ClaimId == 0)
        {
            startUpScript.Append("</script>");
            ltrClaimServices.Text = startUpScript.ToString();
            return;
        }

        ClaimChargesDB objClaimChargesDB = new ClaimChargesDB();
        DataTable dtClaimCharges = objClaimChargesDB.ClaimCharges_GetByClaimId(ClaimId);

        string Pointers = "";

        for (int i = 0; i < dtClaimCharges.Rows.Count; i++)
        {
            startUpScript.Append("var objClaimsServices = new Object();");
            DateTime dt = Convert.ToDateTime(dtClaimCharges.Rows[i]["ServiceDate"]);
            string dtMM = dt.Month < 10 ? "0" + dt.Month.ToString() : dt.Month.ToString();
            string dtDD = dt.Day < 10 ? "0" + dt.Day.ToString() : dt.Day.ToString();
            startUpScript.Append("objClaimsServices.ServiceDateMM ='" + dtMM + "';");
            startUpScript.Append("objClaimsServices.ServiceDateDD ='" + dtDD + "';");
            startUpScript.Append("objClaimsServices.ServiceDateYY ='" + dt.Year.ToString().Substring(2, 2) + "';");
            startUpScript.Append("objClaimsServices.POS ='" + POS + "';");
            startUpScript.Append("objClaimsServices.Code ='" + dtClaimCharges.Rows[i]["CPTCode"] + "';");
            startUpScript.Append("objClaimsServices.EPSDT ='" + EPSDT + "';");
            startUpScript.Append("objClaimsServices.ServiceUnits ='" + dtClaimCharges.Rows[i]["ServiceUnits"] + "';");

            Pointers = "";
            string[] alphabets = { "A", "B", "C", "D", "E", "F", "G", "H" };
            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer1"].ToString()) && dtClaimCharges.Rows[i]["DxPointer1"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer1"].ToString()) - 1];
            }

            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer2"].ToString()) && dtClaimCharges.Rows[i]["DxPointer2"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer2"].ToString()) - 1];
            }

            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer3"].ToString()) && dtClaimCharges.Rows[i]["DxPointer3"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer3"].ToString()) - 1];
            }

            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer4"].ToString()) && dtClaimCharges.Rows[i]["DxPointer4"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer4"].ToString()) - 1];
            }
            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer5"].ToString()) && dtClaimCharges.Rows[i]["DxPointer5"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer5"].ToString()) - 1];
            }
            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer6"].ToString()) && dtClaimCharges.Rows[i]["DxPointer6"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer6"].ToString()) - 1];
            }
            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer7"].ToString()) && dtClaimCharges.Rows[i]["DxPointer7"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer7"].ToString()) - 1];
            }
            if (!string.IsNullOrEmpty(dtClaimCharges.Rows[i]["DxPointer8"].ToString()) && dtClaimCharges.Rows[i]["DxPointer8"].ToString() != "0")
            {
                Pointers += ", " + alphabets[int.Parse(dtClaimCharges.Rows[i]["DxPointer8"].ToString()) - 1];
            }
            
            Pointers = Pointers.TrimStart(',');
            Pointers = Pointers.TrimStart(' ');
            
            startUpScript.Append("objClaimsServices.Pointers ='" + Pointers + "';");
            startUpScript.Append("objClaimsServices.Modifier1 ='" + dtClaimCharges.Rows[i]["Modifier1"].ToString() + "';");
            startUpScript.Append("objClaimsServices.Modifier2 ='" + dtClaimCharges.Rows[i]["Modifier2"].ToString() + "';");
            startUpScript.Append("objClaimsServices.Modifier3 ='" + dtClaimCharges.Rows[i]["Modifier3"].ToString() + "';");
            startUpScript.Append("objClaimsServices.Modifier4 ='" + dtClaimCharges.Rows[i]["Modifier4"].ToString() + "';");

            string Charges = dtClaimCharges.Rows[i]["TotalCharges"].ToString().Trim();
            string Units = dtClaimCharges.Rows[i]["ServiceUnits"].ToString().Trim();

            if (string.IsNullOrEmpty(Charges)) Charges = "0";
            if (string.IsNullOrEmpty(Units)) Units = "0";
            
            string TotalCharges = (float.Parse(Charges) * float.Parse(Units)).ToString();
            
            if (TotalCharges.Split('.').Length == 1)
            {
                TotalCharges = TotalCharges + ".00";
            }
            
            //TotalCharges = TotalCharges.Remove(TotalCharges.Length - 2);
            startUpScript.Append("objClaimsServices.TotalCharges ='" + TotalCharges + "';");
            startUpScript.Append("objClaimsServices.ProviderNPI ='" + ProviderNPI + "';");
            
            startUpScript.Append("_arrClaimsServices.push(objClaimsServices);");
        }
        
        startUpScript.Append("</script>");
        
        ltrClaimServices.Text = startUpScript.ToString();
    }
}