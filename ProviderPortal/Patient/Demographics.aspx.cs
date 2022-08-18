using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Text;
using System.IO;

public partial class BillingManager_Patient_Demographics : System.Web.UI.Page
{
    DataSet dsPTLReasons = new DataSet();
    string Patiendid = null;
    object FinancialGuranterId = 0;
    string InsuranceType;
    string GridHtml = "";

    protected void Page_Load(object sender, EventArgs e)
    {

      
        if (Request.QueryString["Patientid"] != null)
        {
            Patiendid = Request.QueryString["Patientid"];
            hdnPatientId.Value = Patiendid;
        }
        else
        {
            Patiendid = Request.Form["PatientIdaction"];
        }


        if (Request.Form["action"] == "update")
        {
            JavaScriptSerializer serilizer = new JavaScriptSerializer();

            Patient patobj = new Patient();
            PatientDB Db = new PatientDB();
            if (Request.Form["UpdateData"] != null)
            {
                patobj = serilizer.Deserialize<Patient>(Request.Form["UpdateData"]);

                Db.UpdatePatientDemographicsInformation(patobj);
            }
        }



     //   Patiendid = Request.QueryString["Patientid"]; 

        Pid.Value = Patiendid;
        CurrentDate.Value = DateTime.Now.ToString();
         PatientDB dbb = new PatientDB();
     
        
        DataTable practisedt = dbb.CalimGetByPractiseId(Patiendid);
        if (practisedt.Rows.Count > 0)
        {
            string practiseid = practisedt.Rows[0][0].ToString();
            hdnPracticeId.Value = practiseid;
        }
        if (Request.QueryString["PatientId"] == null)
        {
            return;
        }


        PatientViewMethod();

        //rizwan kharal start
        //21 sep 2017

        // Calling the PatientClaimsInformation  method to show patient insurance information on demographic page
        PatientInsuranceInformation();

        // Calling the PatientClaimsInformation
        PatientClaimsInformation();

        // Calling the  SubmissionStatusCodesInformation
        SubmissionStatusCodesInformation();

        // Calling the PTLReasonsInformation
        PTLReasonsInformation();

        // Calling the Inusrances Types 
        PriSecothinsuranceTypeChecking();
        // calling the Insurances Name
        InsurancesNames();


        //rizwan kharal End


        //Primary Inurance Type 

        //Get All PTL Reason 
        GetAllPTLReasons();
        PatientPayments();
        }


    //rizwan kharal start
    //21 sep 2017
    // showing patient insurance on demographic page 
    public void PatientInsuranceInformation()
    {
        string Patientid = Request.QueryString["PatientId"].ToString();
        Pid.Value = Patientid;


        //long prac = Profile.PracticeId;

        PatientDB db = new PatientDB();

        //DataTable practisedt = db.PatientGetByPractiseId(Patientid);

        //string practiseid = practisedt.Rows[0][0].ToString();

        DataSet ds = db.InsurancePatient(Patientid);
        DataTable dt = ds.Tables[0];
        if (dt.Rows.Count > 0)
        {

            /********added by shahid kazmi 2/7/2018****/
            if (!string.IsNullOrEmpty(dt.Rows[0]["InsuranceId"].ToString()))
                hdnInsuranceId.Value = dt.Rows[0]["InsuranceId"].ToString();
            /******end shahid kazmi 2/7/2018******/

            RptInsurance.DataSource = dt;

            RptInsurance.DataBind();
        }

        else
        {
         
        }
    }





    //rizwan kharal End


    //rizwan kharal start
    //21 sep 2017 
    // updated on 12 oct 2017
    // showing patient Claims on demographic page 
    // updated to showing the claim and filtering 

    public void PatientClaimsInformation()
    {
       long ClaimId=0; 
        //int ClaimTotal=0; int AmountPaid=0; int Adjustment=0; int AmountDue=0;
        string Patientid = Request.QueryString["PatientId"].ToString();
        PatientDB db = new PatientDB();
        DataTable practisedt = db.CalimGetByPractiseId(Patientid);
        if (practisedt.Rows.Count > 0)
        {
            string practiseid = practisedt.Rows[0][0].ToString();


            DataSet dsClaimFilter = db.FilterClaims(Convert.ToInt32(practiseid), Convert.ToInt32(Patientid), 5, 0, "","","",ClaimId,"","","","","");

            //DataTable dt = db.ClaimsPatient(Patientid, practiseid);
            rptClaims.DataSource = dsClaimFilter.Tables[0];
            rptClaims.DataBind();
            hdnClaimsCount.Value = dsClaimFilter.Tables[1].Rows[0]["TotalRows"].ToString();
        }
        else
        {
          
        }

    }
    //rizwan kharal End

    //rizwan kharal start
    //25 sep 2017
    // showing Submission Status Codes  on demographic page in Claim div on ptl reason dropdown
    public void SubmissionStatusCodesInformation()
    {

        PatientDB db = new PatientDB();
        DataTable dt = db.SubmissionStatusCodes();
        ddlSubmissionStatus.DataSource = dt;
        ddlSubmissionStatus.DataTextField = "submissionStatus";
        ddlSubmissionStatus.DataValueField = "SubmissionStatusId";
        ddlSubmissionStatus.DataBind();
        ddlSubmissionStatus.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    }
    //rizwan kharal End

    //rizwan kharal start
    //25 sep 2017
    // showing PTL Reasons on on demographic page in Claim div on ptl reason dropdown
    public void PTLReasonsInformation()
    {
        long practiceId = 0;
        if (Session["PracticeId"] != null)
        {
            practiceId = Convert.ToInt64(Session["PracticeId"].ToString());
        }
        PatientDB db = new PatientDB();
        DataTable dt = db.PTLReasons(practiceId);
        //ddlPtlReasons.DataSource = dt;
        //ddlPtlReasons.DataTextField = "Reason";
        //ddlPtlReasons.DataValueField = "PTLReasonsId";
        //ddlPtlReasons.DataBind();
        //ddlPtlReasons.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    }
    //rizwan kharal End
    //Added By Syed Sajid Ali Date:8/30/2011
    private void GetAllPTLReasons()
    {
        PTLReasonsDB db = new PTLReasonsDB();

        DataSet ds = db.GetAllPTLReasons(Profile.PracticeId);



        PTLReasonsDB objPTLReasonsDB = new PTLReasonsDB();

        DataSet dsPTLReasons = objPTLReasonsDB.GetAllPTLReasons();



        rptPTLReasons.DataSource = dsPTLReasons.Tables[1];
        rptPTLReasons.DataBind();
    }
    //Added By Syed Sajid Ali Date:8/30/2011
    protected void rptClaims_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        
    }

    //rizwan kharal start
    //26 sep 2017
    // calling patient  PatientUpdateDemographicMethod and  PatientViewMethod on Button Save click

  


    //rizwan kharal End

 

  
    //rizwan kharal start UPdated
    //10 oct 2017 Updated=11 nov 2017
    // Getting the Primary insurance
    protected void PriSecothinsuranceTypeChecking()
    {
        //Patiendid = Request.QueryString["PatientId"].ToString();
        //PatientDB db = new PatientDB();
        //DataTable dt = new DataTable();
        //dt = db.PriSecothinsuranceTypeCheck(Convert.ToInt32(Patiendid));
        //if (dt.Rows.Count > 0)
        //{
        //    InsuranceType = dt.Rows[0]["PriSecOthType"].ToString();
        //}
        //else
        //{
        //    InsuranceType = "";
        //}
       
   

    }
    //rizwan kharal End



    //rizwan kharal start
    //12 oct 2017
    // showing the only insurance names
    public void InsurancesNames()
    { 
      
        long practiceId = 0;
        if (Session["PracticeId"] != null)
        {
            practiceId = Convert.ToInt64(Session["PracticeId"].ToString());
        }
        InsuranceDB db=new InsuranceDB();
       
        DataTable dt = db.InsuranceFilterByName(practiceId);
        ddlInsurancesNames.DataSource = dt;
        ddlInsurancesNames.DataTextField = "Name";
        ddlInsurancesNames.DataValueField = "InsuranceId";
        ddlInsurancesNames.DataBind();
        ddlInsurancesNames.Items.Insert(0, new ListItem(string.Empty, string.Empty));
    }
    //rizwan kharal End




    //Sir Method
    protected void PatientViewMethod()
    {

        long PatientId = long.Parse(Request.QueryString["PatientId"]);

        Session["PId"] = PatientId;

        hdnPatientId.Value = PatientId.ToString();

        PatientDB objPatientDB = new PatientDB();
        DataSet ddtPatient = objPatientDB.Patient_GetById(PatientId, Profile.PracticeId);

        string ImageUrl = "";
        if (ddtPatient.Tables[0].Rows[0]["ImagePath"].ToString() != "") {
            ImageUrl = ddtPatient.Tables[0].Rows[0]["ImagePath"].ToString().Trim();
        }
        string a = ddtPatient.Tables[0].Rows[0]["RaceName"].ToString();
        if (ImageUrl == "")
        {
            if (ddtPatient.Tables[0].Rows[0]["Gender"].ToString() == "Male")
            {
                imgPatientImage.ImageUrl = "~/Images/maleIcon.png";
            }
            else if (ddtPatient.Tables[0].Rows[0]["Gender"].ToString() == "Female")
            {
                imgPatientImage.ImageUrl = "~/Images/FemaleIcon.png";
            }
        }
        else
        {
            imgPatientImage.ImageUrl = ConfigurationManager.AppSettings["PatientPhoto"].ToString() + "/" + Profile.PracticeId + "/Patients/" + PatientId + "/" + ImageUrl;
        }

        string FGuarantorId = ddtPatient.Tables[0].Rows[0]["FinancialGuarantorId"].ToString();
        if (FGuarantorId == "")
        {
            hdnFinancialGuranterId.Value = ddtPatient.Tables[0].Rows[0]["FinancialGuarantorId"].ToString();
        }
        else
        {
            FinancialGuranterId = ddtPatient.Tables[0].Rows[0]["FinancialGuarantorId"].ToString();
            hdnFinancialGuranterId.Value = FinancialGuranterId.ToString();
        }

        // Drop Downs Strat


        // race
        RaceDB objRaceDB = new RaceDB();
        ddlRace.DataSource = objRaceDB.GetAllRace();
        ddlRace.DataValueField = "RaceId";
        ddlRace.DataTextField = "Name";
        ddlRace.DataBind();
        string racename = ddtPatient.Tables[0].Rows[0]["RaceName"].ToString();
        string raceid = ddtPatient.Tables[0].Rows[0]["RaceId"].ToString();
        ddlRace.Items.Insert(0, new ListItem(racename, raceid));

        //Ethnicity
        EthnicityDB objEthnicityDB = new EthnicityDB();
        ddlEthnicity.DataSource = objEthnicityDB.GetAllEthnicity();
        ddlEthnicity.DataValueField = "EthnicityId";
        ddlEthnicity.DataTextField = "Name";
        ddlEthnicity.DataBind();
        string Ethname = ddtPatient.Tables[0].Rows[0]["EthnicityName"].ToString();
        string Ethid = ddtPatient.Tables[0].Rows[0]["EthnicityId"].ToString();
        ddlEthnicity.Items.Insert(0, new ListItem(Ethname, Ethid));


        // Languages
        LanguagesDB objLanguagesDB = new LanguagesDB();

        ddlPreferredLanguage.DataSource = objLanguagesDB.GetAllLanguages();
        ddlPreferredLanguage.DataValueField = "LanguageId";
        ddlPreferredLanguage.DataTextField = "Name";
        ddlPreferredLanguage.DataBind();

        string lanname = ddtPatient.Tables[0].Rows[0]["Language"].ToString();
        string lanid = ddtPatient.Tables[0].Rows[0]["PreferredLanguageId"].ToString();
        ddlPreferredLanguage.Items.Insert(0, new ListItem(lanname, lanid));

        //RelationShip 

        RelationshipDB ObjRelationshipDB = new RelationshipDB();
        //Guranter RelationShip 
        DataTable ddtRelationship = ObjRelationshipDB.Relationship_GetAll();
        ddlRelationship.DataSource = ddtRelationship;
        ddlRelationship.DataValueField = "Code";
        ddlRelationship.DataTextField = "Definition";
        ddlRelationship.DataBind();

        string GRelationshipName = ddtPatient.Tables[0].Rows[0]["FinancialGuarantorRelation"].ToString();
        string GRelationshipId = ddtPatient.Tables[0].Rows[0]["GuarantorRelationship"].ToString();
        if (GRelationshipId == "" || GRelationshipId == "0")
        {
            ddlRelationship.Items.Insert(0, new ListItem("Self", "0"));

        }
        else
        {
            ddlRelationship.Items.Insert(0, new ListItem(GRelationshipName, GRelationshipId));
        }

        //Emergency RelationShip 
        ddlEmergencyRelationship.DataSource = ddtRelationship;
        ddlEmergencyRelationship.DataValueField = "Code";
        ddlEmergencyRelationship.DataTextField = "Definition";
        ddlEmergencyRelationship.DataBind();
        string EmergencyRelationshipName = ddtPatient.Tables[0].Rows[0]["EmergencyRelationship"].ToString();
        string RelationshipId = ddtPatient.Tables[0].Rows[0]["Relationship"].ToString();
        ddlEmergencyRelationship.Items.Insert(0, new ListItem(EmergencyRelationshipName, RelationshipId));
        //

        lblPatientId.Text = "Account# " + PatientId.ToString();
        hdnPatId.Value = PatientId.ToString();

        lblName.Text = ddtPatient.Tables[0].Rows[0]["LastName"].ToString().Trim() + ", " + ddtPatient.Tables[0].Rows[0]["FirstName"].ToString().Trim();


        lblFirstName.Text = ddtPatient.Tables[0].Rows[0]["FirstName"].ToString().Trim();
        lblLastName.Text = ddtPatient.Tables[0].Rows[0]["LastName"].ToString().Trim();
        lblMiddleName.Text = ddtPatient.Tables[0].Rows[0]["MiddleName"].ToString().Trim();

        if (!string.IsNullOrEmpty(ddtPatient.Tables[0].Rows[0]["DateOfBirth"].ToString()))
        {
            if (ddtPatient.Tables[0].Rows[0]["DateOfBirth"].ToString() == "09/09/1900") { lblDOB.Text = ""; }
            else { lblDOB.Text = Convert.ToDateTime(ddtPatient.Tables[0].Rows[0]["DateOfBirth"]).ToShortDateString(); }
        }
        lblGender.Text = ddtPatient.Tables[0].Rows[0]["Gender"].ToString();
        lblMaritalStatus.Text = ddtPatient.Tables[0].Rows[0]["MaritalStatus"].ToString();
        if (ddtPatient.Tables[1].Rows.Count > 0)
        {
            lblRACE.Text = ddtPatient.Tables[1].Rows[0]["RaceName"].ToString();
        }
        else
        {
            lblRACE.Text = "";
        }
        if (ddtPatient.Tables[2].Rows.Count > 0)
        {
            lblEthnicity.Text = ddtPatient.Tables[2].Rows[0]["EthnicityName"].ToString();
        }
        else
        {
            lblEthnicity.Text = "";
        }

        lblSSN.Text = ddtPatient.Tables[0].Rows[0]["SSN"].ToString();
        lblPreferredLanguage.Text = ddtPatient.Tables[0].Rows[0]["Language"].ToString();
        if (ddtPatient.Tables[0].Rows[0]["Address"].ToString() == "No Address") { lblAddress.Text = ""; }
        else { lblAddress.Text = ddtPatient.Tables[0].Rows[0]["Address"].ToString(); }
        lblCity.Text = ddtPatient.Tables[0].Rows[0]["City"].ToString();
        if (ddtPatient.Tables[0].Rows[0]["Zip"].ToString() == "00000") { lblZipCode.Text = ""; }
        else { lblZipCode.Text = ddtPatient.Tables[0].Rows[0]["Zip"].ToString(); }
       string st = ddtPatient.Tables[0].Rows[0]["State"].ToString();
        ddlState.SelectedValue = ddtPatient.Tables[0].Rows[0]["State"].ToString();
        lblHomePhone.Text = ddtPatient.Tables[0].Rows[0]["HomePhone"].ToString();
        lblCellPhone.Text = ddtPatient.Tables[0].Rows[0]["Cell"].ToString();
        lblWorkPhone.Text = ddtPatient.Tables[0].Rows[0]["WorkPhone"].ToString();
        lblExt.Text = ddtPatient.Tables[0].Rows[0]["Ext"].ToString();
        lblEmail.Text = ddtPatient.Tables[0].Rows[0]["Email"].ToString();


        lblEmergencyName.Text = ddtPatient.Tables[0].Rows[0]["EmergencyContactName"].ToString();
        lblEmergencyRelationship.Text = ddtPatient.Tables[0].Rows[0]["EmergencyRelationship"].ToString();
        lblEmergencyContact.Text = ddtPatient.Tables[0].Rows[0]["Phone"].ToString();

        string GRelationshipIdd = ddtPatient.Tables[0].Rows[0]["GuarantorRelationship"].ToString();
        if (GRelationshipIdd == "0")
        {
            lblFirstGuarantorName.Text = ddtPatient.Tables[0].Rows[0]["FirstName"].ToString().Trim();
            lblLastGuarantorName.Text = ddtPatient.Tables[0].Rows[0]["LastName"].ToString().Trim();
        }
        else
        {
            lblFirstGuarantorName.Text = ddtPatient.Tables[0].Rows[0]["GuarantorFirstName"].ToString();
            lblLastGuarantorName.Text = ddtPatient.Tables[0].Rows[0]["GuarantorLastName"].ToString();
            lblMiddleGuarantorName.Text = ddtPatient.Tables[0].Rows[0]["GuarantorMiddleName"].ToString();
        }

        string GRelationshipID = ddtPatient.Tables[0].Rows[0]["GuarantorRelationship"].ToString();

        if (GRelationshipID == "0")
        {
            lblRelationship.Text = "Self";
        }
        else
        {
            lblRelationship.Text = ddtPatient.Tables[0].Rows[0]["FinancialGuarantorRelation"].ToString();
        }


        ddlAddressType.SelectedValue = ddtPatient.Tables[0].Rows[0]["AddressType"].ToString();
        lblAddressType.Text = ddlAddressType.SelectedItem.Text;

        ddlCCP.SelectedValue = ddtPatient.Tables[0].Rows[0]["CCP"].ToString();
        lblCCP.Text = ddlCCP.SelectedItem.Text;
        string aa = ddtPatient.Tables[0].Rows[0]["State"].ToString().Trim();

        if (aa != "")
        {
            StatesDB objStatesDB = new StatesDB();
            ddlState.DataSource = objStatesDB.GetAllAsDataTable();
            ddlState.DataValueField = "StateCode";
            ddlState.DataTextField = "StateName";
            ddlState.DataBind();
            string bb = ddlState.SelectedValue.ToString();
            if (string.IsNullOrEmpty(bb))
            {
                ddlState.SelectedValue = ddtPatient.Tables[0].Rows[0]["State"].ToString();

            }
            
            lblState.Text = ddlState.SelectedItem.Text;
        }

        txtNotes.InnerText = ddtPatient.Tables[0].Rows[0]["Notes"].ToString();

      //  lblPharmacyName.Text = ddtPatient.Rows[0]["StoreName"] == DBNull.Value ? "" : ddtPatient.Rows[0]["StoreName"].ToString();
        lblPharmacyName.Text = ddtPatient.Tables[0].Rows[0]["PharmacyName"].ToString();
        string deathdate = ddtPatient.Tables[0].Rows[0]["DeathDate"].ToString();
        string DisabilityDate = ddtPatient.Tables[0].Rows[0]["DisabilityDate"].ToString();
        if (deathdate != "" && deathdate !="01/01/1900")
        {
            lblDateOfDeath.Text = Convert.ToDateTime(ddtPatient.Tables[0].Rows[0]["DeathDate"]).ToShortDateString();

        }
        else
        {
            lblDateOfDeath.Text = "";
        }
        if (DisabilityDate != "" && DisabilityDate != "01/01/1900")
        {

            lblDateOfDisability.Text = Convert.ToDateTime(ddtPatient.Tables[0].Rows[0]["DisabilityDate"]).ToShortDateString();
        }
        else
        {
            lblDateOfDisability.Text = "";
        }
        lblCauseOfDeath.Text = ddtPatient.Tables[0].Rows[0]["CauseOfDeath"].ToString();
    }

    protected void Inssave_Click(object sender, EventArgs e)
    {
        PriSecothinsuranceTypeChecking();
    }
    protected void RptInsurance_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView drv = (DataRowView)e.Item.DataItem;
            string SubscriberName = drv["SubscriberName"].ToString();
            string Terminationdate = drv["TerminationDate"].ToString();
           
           

            Label lblSubscriberName = (Label)e.Item.FindControl("lblSubscriberName");
            if(SubscriberName=="")
            {
                lblSubscriberName.Text = lblLastName.Text+", "+lblFirstName.Text;
            }
            else
            {
                lblSubscriberName.Text = SubscriberName;
            }
            if (!string.IsNullOrEmpty(drv["PriSecOthType"].ToString()))
            {
                string PriSecOthType = drv["PriSecOthType"].ToString();
                Label lblInsuranceType = (Label)e.Item.FindControl("lblInsuranceType");
                if (PriSecOthType == "P" || PriSecOthType == "p")
                {
                    lblInsuranceType.Text = "Primary";
                }
                else if (PriSecOthType == "S" || PriSecOthType == "s")
                {
                    lblInsuranceType.Text = "Secondary";
                }
                else if (PriSecOthType == "O" || PriSecOthType == "o")
                {
                    lblInsuranceType.Text = "Other";
                }

                 if (!string.IsNullOrEmpty(Terminationdate))
                {
                   
                    
                        string date = DateTime.Now.ToString("yyyy/MM/dd");
                        DateTime Termination = Convert.ToDateTime(Terminationdate); 

                        DateTime Todate = Convert.ToDateTime(date);

                        if (Termination <= Todate)
                        {
                            lblInsuranceType.Text = "Terminated";
                        }
                    
                }
              
            }
        }
    }

    public void PatientPayments()
    {
        string a = "";
        long patientid = long.Parse(Request.QueryString["PatientId"]);
        ProcedurePaymentsDB procedurePaymentsdb = new ProcedurePaymentsDB();
        DataSet ds = procedurePaymentsdb.GetPatientPayment(patientid);
        var mainresult = from myrow in ds.Tables[0].AsEnumerable() select new {
             checknumber = myrow.Field<string>("CheckNumber"),
             checkdate = myrow.Field<DateTime?>("checkDate"),
             checkAmount = myrow.Field<decimal?>("PaymentAmount"),
             PaymentPosted = myrow.Field<decimal?>("PaymentPosted"),
             UnAppliedAmount = myrow.Field<decimal?>("UnAppliedAmount")
         
        };

        rptPatientPayment.DataSource = mainresult.Distinct();
        rptPatientPayment.DataBind();
        //Added by Khayyam adeel : database has no values so added a hardcoded values
        // For testing Purpose please Uncommment these no data available on local


        //DataTable custTable = new DataTable("Customers");
        //DataColumn dtColumn;
        //DataRow myDataRow;


        //dtColumn = new DataColumn();
        //dtColumn.DataType = typeof(Int32);
        //dtColumn.ColumnName = "checknumber";
        //dtColumn.Caption = "checknumber";
        //dtColumn.ReadOnly = false;
        //dtColumn.Unique = true;

        //custTable.Columns.Add(dtColumn);


        //dtColumn = new DataColumn();
        //dtColumn.DataType = typeof(String);
        //dtColumn.ColumnName = "checkdate";
        //dtColumn.Caption = "checkdate";
        //dtColumn.AutoIncrement = false;
        //dtColumn.ReadOnly = false;
        //dtColumn.Unique = false;

        //custTable.Columns.Add(dtColumn);


        //dtColumn = new DataColumn();
        //dtColumn.DataType = typeof(String);
        //dtColumn.ColumnName = "checkAmount";
        //dtColumn.Caption = "checkAmount";
        //dtColumn.ReadOnly = false;
        //dtColumn.Unique = false;
        //custTable.Columns.Add(dtColumn);

        //dtColumn = new DataColumn();
        //dtColumn.DataType = typeof(String);
        //dtColumn.ColumnName = "PaymentPosted";
        //dtColumn.Caption = "PaymentPosted";
        //dtColumn.ReadOnly = false;
        //dtColumn.Unique = false;
        //custTable.Columns.Add(dtColumn);

        //dtColumn = new DataColumn();
        //dtColumn.DataType = typeof(String);
        //dtColumn.ColumnName = "UnAppliedAmount";
        //dtColumn.Caption = "UnAppliedAmount";
        //dtColumn.ReadOnly = false;
        //dtColumn.Unique = false;

        //custTable.Columns.Add(dtColumn);


        //DataColumn[] PrimaryKeyColumns = new DataColumn[1];
        //PrimaryKeyColumns[0] = custTable.Columns["checknumber"];
        //custTable.PrimaryKey = PrimaryKeyColumns;

        //myDataRow = custTable.NewRow();

        //myDataRow["checknumber"] = 1001;
        //myDataRow["checkdate"] = "12/12/2021";
        //myDataRow["checkAmount"] = "123";
        //myDataRow["PaymentPosted"] = "120";
        //myDataRow["UnAppliedAmount"] = "3";
        //custTable.Rows.Add(myDataRow);

        //myDataRow = custTable.NewRow();
        //myDataRow["checknumber"] = 1002;
        //myDataRow["checkdate"] = "12/12/2021";
        //myDataRow["checkAmount"] = "123";
        //myDataRow["PaymentPosted"] = "120";
        //myDataRow["UnAppliedAmount"] = "3";
        //custTable.Rows.Add(myDataRow);

        //myDataRow = custTable.NewRow();
        //myDataRow["checknumber"] = 1003;
        //myDataRow["checkdate"] = "12/12/2021";
        //myDataRow["checkAmount"] = "123";
        //myDataRow["PaymentPosted"] = "120";
        //myDataRow["UnAppliedAmount"] = "3";
        //custTable.Rows.Add(myDataRow);
        //End of change 

        RptBalanceSheet_Trn.DataSource = mainresult.Distinct();
        RptBalanceSheet_Trn.DataBind();


        


        if (ds.Tables[1].Rows.Count > 0)
        {



            if (Convert.ToDecimal(ds.Tables[1].Rows[0][0]).ToString("0.00") == "0.00") {
                lblpr.Text = "N/A";
                lblBalanceDue.Text = "N/A";
            }
            else
            {
                if (ds.Tables[1].Rows[0][0].ToString() != "")
                {
                    lblpr.Text = "$" + Convert.ToDecimal(ds.Tables[1].Rows[0][0]).ToString("0.00");
                }
                if (ds.Tables[1].Rows[0][2].ToString() != "")
                {
                    lblBalanceDue.Text = "$" + Convert.ToDecimal(ds.Tables[1].Rows[0][2]).ToString("0.00");
                }
                if (ds.Tables[1].Rows[0][2].ToString() == "")
                {
                    lblBalanceDue.Text = "$0.00";
                }
            }
            
            lblpaid.Text = "$" + Convert.ToDecimal(ds.Tables[1].Rows[0][1]).ToString("0.00");
            
            
        }
    }


    protected void RptBalanceSheet_Trn_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Label CheckNumber = (Label)e.Item.FindControl("CheckNumber");
            Label checkAmount = (Label)e.Item.FindControl("checkAmount");
            Label checkDate = (Label)e.Item.FindControl("checkDate");
            HiddenField hdnCheckAmount = (HiddenField)e.Item.FindControl("hdnCheckAmount");

            //do nothing

            

        }
    }
}