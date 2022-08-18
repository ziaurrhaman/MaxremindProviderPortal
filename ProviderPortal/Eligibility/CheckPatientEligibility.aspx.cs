using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
//using MremindEligibilityService;
//using AbilityService;
using System.Globalization;
using System.Web.Script.Serialization;
public partial class EMR_Eligibility_CheckPatientEligibility : System.Web.UI.Page
{
    DataSet _dsEligibilityResponse;
    DataTable _dtEDICodes;
    bool _alternateRow = false;
    DateTime EligibilityEndDate;
    protected void Page_Load(object sender, EventArgs e)
    {

        long PatientId = 0;
        string FirstName = "";
        string LastName = "";
        string Gender = "";
        string DOB = "";
        string DateOfBirth = "";

        string PolicyNumber = "";

        string Address = "";
        string City = "";
        string State = "";
        string Zip = "";

        DateTime CurrentDateTime = DateTime.Now;
        DateTime EligibilityStartDate = DateTime.Now;

        long InsuranceId = long.Parse(Request.Form["InsuranceId"].ToString());
        InsuranceDB objInsuranceDB = new InsuranceDB();
        DataTable dtInsuranceSubmitterPayerReceiverId = objInsuranceDB.GetSubmitterReceiverPayerId(InsuranceId);
        if (dtInsuranceSubmitterPayerReceiverId.Rows.Count > 0)
        {
            hdnRowCount.Value = dtInsuranceSubmitterPayerReceiverId.Rows.Count.ToString();

            if (!string.IsNullOrEmpty(dtInsuranceSubmitterPayerReceiverId.Rows[0]["PayerName"].ToString()))
            {
                string PayerName = dtInsuranceSubmitterPayerReceiverId.Rows[0]["PayerName"].ToString().Trim();
                              lblPayerName.Text = PayerName;
            }
           
            if (!string.IsNullOrEmpty(dtInsuranceSubmitterPayerReceiverId.Rows[0]["ReceiverId270"].ToString()))
            {

                string payerId = dtInsuranceSubmitterPayerReceiverId.Rows[0]["ReceiverId270"].ToString().Trim();
                lblPayerId.Text = payerId;
            }
            else if (!string.IsNullOrEmpty(dtInsuranceSubmitterPayerReceiverId.Rows[0]["PayerId270"].ToString()))
            {
                string payerId = dtInsuranceSubmitterPayerReceiverId.Rows[0]["PayerId270"].ToString().Trim();
                lblPayerId.Text = payerId;
            }
        }
        if (!string.IsNullOrEmpty(Request.Form["EligibilityStartDate"]))
        {
            EligibilityStartDate = DateTime.Parse(Request.Form["EligibilityStartDate"].ToString());
        }
       
        if (!string.IsNullOrEmpty(Request.Form["EligibilityEndDate"]))
        {
            EligibilityEndDate = DateTime.Parse(Request.Form["EligibilityEndDate"]);
        }
        else
        {
            EligibilityEndDate = EligibilityStartDate; 
        }



        if (!string.IsNullOrEmpty(DateOfBirth))
        {
            DateOfBirth = DateTime.Parse(DateOfBirth).ToString("yyyyMMdd");
        }

        bool IsFromPersonal = bool.Parse(Request.Form["IsFromPersonal"].ToString());

        bool IsCMS = false;

        string ReceiverId270 = "";

        if (!IsFromPersonal)
        {
            PatientDB objPatientDB = new PatientDB();
            if(!string.IsNullOrEmpty(Request.Form["PatientId"]))
            {
                PatientId = long.Parse(Request.Form["PatientId"]);
            }
            DataTable dtPatientInformation = objPatientDB.GetInfoForEligibility(PatientId);
            if (dtPatientInformation.Rows.Count > 0)
            {
                FirstName = dtPatientInformation.Rows[0]["FirstName"].ToString().Trim();
                LastName = dtPatientInformation.Rows[0]["LastName"].ToString().Trim();
                DOB = DateTime.Parse(dtPatientInformation.Rows[0]["DateOfBirth"].ToString()).ToString("MM/dd/yyyy");
                DateOfBirth = DateTime.Parse(dtPatientInformation.Rows[0]["DateOfBirth"].ToString()).ToString("yyyyMMdd");
                Gender = dtPatientInformation.Rows[0]["Gender"].ToString().Trim();
                PolicyNumber = dtPatientInformation.Rows[0]["PolicyNumber"].ToString().Trim();
                InsuranceId = long.Parse(dtPatientInformation.Rows[0]["InsuranceId"].ToString());

                Address = dtPatientInformation.Rows[0]["Address"].ToString().Trim();
                City = dtPatientInformation.Rows[0]["City"].ToString().Trim();
                State = dtPatientInformation.Rows[0]["State"].ToString().Trim();
                Zip = dtPatientInformation.Rows[0]["Zip"].ToString().Trim();

                if (dtPatientInformation.Rows[0]["ReceiverId270"].ToString() == "CMS")
                    IsCMS = true;
            }
            else
            {
                ltrEligibilityAjaxResponse.Text = "PatientInformationNotFound";
                
            }
        }
        else
        {
            DataTable dtInsuranceReceiverId270 = objInsuranceDB.GetReceiverId270(InsuranceId);

            if (dtInsuranceReceiverId270.Rows.Count > 0)
            {
                ReceiverId270 = dtInsuranceReceiverId270.Rows[0]["ReceiverId270"].ToString().Trim();
                if (ReceiverId270 == "CMS")
                {
                    IsCMS = true;
                }
            }
            else
            {
                ltrEligibilityAjaxResponse.Text = "D270InsuranceTableIsEmpty";
                return;
            }

        }

        hdnIsCMSInsurance.Value = IsCMS.ToString();

        EligibilityRequest objEligibilityRequest = new EligibilityRequest();
        DataTable dtInsuranceSubmitter_PayerReceiverId = objInsuranceDB.GetSubmitterReceiverPayerId(InsuranceId);
        if (dtInsuranceSubmitter_PayerReceiverId.Rows.Count > 0)
        {
            if (IsFromPersonal == true)
            {
                FirstName = Request.Form["FirstName"];
                LastName = Request.Form["LastName"];
                DateOfBirth = DateTime.Parse(Request.Form["DateOfBirth"].ToString()).ToString("yyyyMMdd");
                PolicyNumber = Request.Form["PolicyNumber"];
            }
            string eligibilityString = objEligibilityRequest.GetEligibilityCheckString(PatientId, InsuranceId, Profile.PracticeId, EligibilityStartDate, EligibilityEndDate, FirstName, LastName, DateOfBirth, PolicyNumber);

            Ability objEligibility = new Ability();
            string EligibilityResponse = string.Empty;
            if (Profile.PracticeId == 11111 || Profile.PracticeId == 1000)
            {
                EligibilityResponse = "ISA*00*          *00*          *ZZ*               *ZZ*10002          *180507*0553*^*00501*336210982*0*P*|~GS*HB*MD*10002*20180507*055301*1*X*005010X279A1~ST*271*0001*005010X279A1~BHT*0022*11*20180507105258*20180507*055300~HL*1**20*1~NM1*PR*2*UNITEDHEALTHCARE*****PI*10002~PER*IC**UR*WWW.UNITEDHEALTHCAREONLINE.COM~HL*2*1*21*1~NM1*1P*2*PALOMA HOME HEALTH AGENCY INC*****XX*1992963318~HL*3*2*22*0~TRN*2*20180507105258*2018050710~TRN*1*13114561024*9MEDDATACO~NM1*IL*1*CADY*PRESTON*H***MI*868402777~REF*6P*68092~N3*2411 STEWART DR~N4*MESQUITE*TX*75181~DMG*D8*19401101*M~DTP*346*D8*20180101~EB*1**30*PR*LPPO-UNITEDHEALTHCARE GROUP MEDICARE ADVANTAGE (PP~LS*2120~NM1*PR*2*UNITEDHEALTHCARE*****PI*87726~N3*UNITEDHEALTHCARE*P.O. BOX 31362~N4*SALT LAKE CITY*UT*841310362~PER*IC**UR*WWW.UNITEDHEALTHCAREONLINE.COM~LE*2120~EB*C*FAM*30***23*99999.99*****W~EB*C*IND*30***23*290*****W~EB*G*FAM*30*PR**23*99999.99*****W~EB*G*IND*30*PR**23*3290*****W~EB*C*FAM*30***24*290*****W~EB*C*IND*30***24*290*****W~EB*G*FAM*30*PR**24*302.68*****W~EB*G*IND*30*PR**24*302.68*****W~EB*C*FAM*30***29*99709.99*****W~EB*C*IND*30***29*0*****W~EB*G*FAM*30*PR**29*99697.31*****W~EB*G*IND*30*PR**29*2987.32*****W~EB*L~LS*2120~NM1*P3*1*RABORN*WESTLEY****XX*1013910082~N3*2704 N GALLOWAY AVE STE 103~N4*MESQUITE*TX*75150~PER*IC**TE*2146602500*FX*2146602535~PRV*PC*PXC*207Q00000X~LE*2120~EB*1**1^33^47^48^86^98^MH^PT^UC*********W~EB*1**50*********W~MSG*OUTPATIENT SURGERY~EB*1**9*********W~MSG*VIRTUAL VISITS/TELEMEDICINE~EB*1**96*********W~MSG*OFFICE VISIT SPECIALIST~EB*1**50*********W~MSG*OUTPATIENT HOSPITAL~EB*A*IND*50***7**.2****W~MSG*OUTPATIENT HOSPITAL~EB*A*IND*96***7**.2****W~MSG*OFFICE VISIT SPECIALIST~EB*A*IND*9***27**0****W~MSG*VIRTUAL VISITS/TELEMEDICINE~EB*A*IND*33^48^PT***7**.2****W~EB*A*IND*50***7**.2****W~MSG*OUTPATIENT SURGERY~EB*A*IND*86^98^UC***7**0****W~EB*B*IND*9***27*0*****W~MSG*VIRTUAL VISITS/TELEMEDICINE~EB*B*IND*98***7*15*****W~EB*B*IND*86^UC***7*50*****W~EB*B*IND*96***7*0*****W~MSG*OFFICE VISIT SPECIALIST~EB*B*IND*33^48^PT***7*0*****W~EB*B*IND*50***7*0*****W~MSG*OUTPATIENT SURGERY~EB*B*IND*50***7*0*****W~MSG*OUTPATIENT HOSPITAL~EB*C*FAM*9***23*0*****W~MSG*VIRTUAL VISITS/TELEMEDICINE~EB*C*IND*9***23*0*****W~MSG*VIRTUAL VISITS/TELEMEDICINE~EB*C*IND*33^86^UC***23*0*****W~EB*C*FAM*33^86^UC***23*0*****W~EB*U**88~LS*2120~NM1*VN*2*OPTUMRX~PER*IC**UR*PROFESSIONALS.OPTUMRX.COM~LE*2120~EB*X~LS*2120~NM1*1P*2*PALOMA HOME HEALTH AGENCY INC*****XX*1992963318~LE*2120~EB*D*IND~MSG*NONADHERENT-CBP-CONTROLLING BLOOD PRESSURE~SE*91*0001~GE*1*1~IEA*1*336210982~";
                

                EligibilityResponse = EligibilityResponse.Replace("D8*00000000~", "D8*" + EligibilityStartDate.ToString("yyyyMMdd") + "~");
                EligibilityResponse = EligibilityResponse.Replace("*RD8*00000000-00000000~", "*RD8*" + EligibilityStartDate.ToString("yyyyMMdd") + "-" + EligibilityEndDate.ToString("yyyyMMdd") + "~");
            }
            else
            {
                if (IsCMS)
                {
                    EligibilityResponse = objEligibility.GetEligibilityResponse(eligibilityString);
                
                }
                else
                {
                    EligibilityResponse = objEligibility.GetCommercialInsuranceEligibilityResponse(eligibilityString);
                }
            }

            EligibilityResponse objEligibilityResponse = new EligibilityResponse();
            _dsEligibilityResponse = objEligibilityResponse.Parse(EligibilityResponse);
            EDICodes objEDICodes = new EDICodes();
            _dtEDICodes = objEDICodes.GetEDICodes();
            HIPAA270Log objHIPAA270Log = new HIPAA270Log();
            objHIPAA270Log.PracticeId = Profile.PracticeId;
            objHIPAA270Log.PatientId = PatientId;
            objHIPAA270Log.DateFrom = EligibilityStartDate;
            objHIPAA270Log.DateTo = EligibilityEndDate;
            objHIPAA270Log.InsuranceId = InsuranceId;
            objHIPAA270Log.ResponseString = EligibilityResponse;
            objHIPAA270Log.EligibilityInquiryDate = CurrentDateTime;
            objHIPAA270Log.CreatedById = Profile.UserId;
            objHIPAA270Log.CreatedDate = DateTime.Now;

            #region Header Information
            if (_dsEligibilityResponse.Tables[0].Rows.Count > 0)
            {
                string InsuranceLastName = _dsEligibilityResponse.Tables[0].Rows[0]["PatientLastName"].ToString();
                lblInsuranceLastName.Text = InsuranceLastName;
                
                string InsuranceFirstName = _dsEligibilityResponse.Tables[0].Rows[0]["PatientFirstName"].ToString();
                lblInsuranceFirstName.Text = InsuranceFirstName;
                
                string InsuranceGender = _dsEligibilityResponse.Tables[0].Rows[0]["Gender"].ToString();
                lblInsuranceGender.Text = InsuranceGender;
                
                string InsuranceDOB = _dsEligibilityResponse.Tables[0].Rows[0]["DOB"].ToString();
                if (!string.IsNullOrEmpty(InsuranceDOB))
                {
                    InsuranceDOB = DateTime.Parse(_dsEligibilityResponse.Tables[0].Rows[0]["DOB"].ToString()).ToString("MM/dd/yyyy");
                }
                lblInsuranceDOB.Text = InsuranceDOB;
                
                string InsuranceAddress = _dsEligibilityResponse.Tables[0].Rows[0]["Address"].ToString();
                if (InsuranceAddress == "No Address")
                {
                    lblInsuranceAddress.Text=null;
                }
                else { lblInsuranceAddress.Text = InsuranceAddress; }
                
                string InsuranceCityStateZip = _dsEligibilityResponse.Tables[0].Rows[0]["CityStateZip"].ToString();
                string DummyZip = "00000";
                if (InsuranceCityStateZip.Contains(DummyZip)) { 
                    lblInsuranceCityStateZip.Text = null;
                }
                else { lblInsuranceCityStateZip.Text = InsuranceCityStateZip; }
                string InsurancePolicyNumber = _dsEligibilityResponse.Tables[0].Rows[0]["PolicyNumber"].ToString();
                lblInsurancePolicyNumber.Text = InsurancePolicyNumber;
                
                if (_dsEligibilityResponse.Tables[0].Rows[0]["DateQualifier"].ToString() != "")
                {
                    string[] DateQualifier = _dsEligibilityResponse.Tables[0].Rows[0]["DateQualifier"].ToString().Split('\n');
                    string[] Date = _dsEligibilityResponse.Tables[0].Rows[0]["Date"].ToString().Split('\n');

                    for (int i = 0; i < DateQualifier.Length; i++)
                    {
                        DataRow[] drDateQualifier = _dtEDICodes.Select("ElementName = 'DTP01' AND Code='" + DateQualifier[i] + "'");
                    }
                }
            }

            #endregion


            if (_dsEligibilityResponse.Tables[1].Rows.Count > 0)
            {
                DataTable dt = _dsEligibilityResponse.Tables[1].AsEnumerable().GroupBy(r => new { Col1 = r["Service"], Col2 = r["InsuranceType"] }).Select(g => g.First()).CopyToDataTable();
                rptBenefitDescription.DataSource = dt;
                rptBenefitDescription.DataBind();
                rptSections.DataSource = dt;
                rptSections.DataBind();

                if (IsCMS)
                {
                    var MedicarePartB = _dsEligibilityResponse.Tables[1].Select("InsuranceType='MA'");
                    var MedicarePartBActive = _dsEligibilityResponse.Tables[1].Select("Service = '1' and InsuranceType='MB'");
                    var MedicarePartBInActive = _dsEligibilityResponse.Tables[1].Select("Service = '6' and InsuranceType='MB'");
                    foreach (var item in MedicarePartBActive)
                    {
                        DataRow dRItem = item;
                        string GeneralBenefits = dRItem["ServiceType"].ToString();
                        if (GeneralBenefits.Contains("30"))
                        {
                            lblEligBenifits.Text = "Active"; 
                            lblServiceType.Text = "Medicare Part B";
                            lblEligBenifits.Style.Add("color", "#21cc21 !important");
                            lblServiceType.Style.Add("color", "#21cc21 !important");
                        }
                    }
                    foreach (var item in MedicarePartBInActive)
                    {
                        DataRow dRItem = item;
                        string GeneralBenefits = dRItem["ServiceType"].ToString();
                        if (GeneralBenefits.Contains("30"))
                        {
                            lblEligBenifits.Text = "In Active";
                            lblServiceType.Text = "Medicare Part B";
                        }
                    }

                
                }

                else
                {
                
                    var GeneralBenefitsActive = _dsEligibilityResponse.Tables[1].Select("Service = '1'");
                    var GeneralBenefitsInActive = _dsEligibilityResponse.Tables[1].Select("Service = '6'");
                    foreach (var item in GeneralBenefitsActive)
                    {
                        DataRow dRItem = item;
                        string GeneralBenefits = dRItem["ServiceType"].ToString();
                        if (GeneralBenefits.Contains("30"))
                        {
                            lblEligBenifits.Text = "Active";
                            lblServiceType.Text = "General Benefits";
                            lblEligBenifits.Style.Add("color", "#21cc21 !important");
                            lblServiceType.Style.Add("color", "#21cc21 !important");
                        }
                    }
                    foreach (var item in GeneralBenefitsInActive)
                    {
                        DataRow dRItem = item;
                        string GeneralBenefits = dRItem["ServiceType"].ToString();
                        if (GeneralBenefits.Contains("30"))
                        {
                            lblEligBenifits.Text = "In Active";
                            lblServiceType.Text = "General Benefits";
                        }
               
                    }

                }


                HIPAA270LogDB objHIPAA270LogDB = new HIPAA270LogDB();

                objHIPAA270LogDB.Add(objHIPAA270Log);

                hdnEligibilityPatientId.Value = PatientId.ToString();


                objHIPAA270Log.ResponseString = "";
                ltrlEligibilityResponse.Text = "<script type='text/javascript'> var EligibilityStatus=";
                ltrlEligibilityResponse.Text += new JavaScriptSerializer().Serialize(objHIPAA270Log);
                ltrlEligibilityResponse.Text += "</script>";
            }
            else if (_dsEligibilityResponse.Tables[2].Rows.Count > 0)
            {
                rptRejection.DataSource = _dsEligibilityResponse.Tables[2];
                rptRejection.DataBind();
            }
        }
    }
    protected void rptSections_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;

            Label lblServiceType = (Label)e.Item.FindControl("lblServiceType");
            DataRow[] objServiceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB01' AND Code='" + objDataRowView["Service"].ToString() + "'");

            if (objServiceTypeDataRow.Length > 0)
                lblServiceType.Text = objServiceTypeDataRow[0]["Description"].ToString();

            Label lblInsuranceType = (Label)e.Item.FindControl("lblInsuranceType");
            DataRow[] objInsuranceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB04' AND Code='" + objDataRowView["InsuranceType"].ToString() + "'");
            if (objInsuranceTypeDataRow.Length > 0)
                lblInsuranceType.Text = objInsuranceTypeDataRow[0]["Description"].ToString() + " - ";
        }
    }
    protected void rptBenefitDescription_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;

            Label lblServiceType = (Label)e.Item.FindControl("lblServiceType");
            DataRow[] objServiceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB01' AND Code='" + objDataRowView["Service"].ToString() + "'");

            if (objServiceTypeDataRow.Length > 0)
            {
                lblServiceType.Text = objServiceTypeDataRow[0]["Description"].ToString();
            }

            Label lblInsuranceType = (Label)e.Item.FindControl("lblInsuranceType");

            DataRow[] objInsuranceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB04' AND Code='" + objDataRowView["InsuranceType"].ToString() + "'");

            if (objInsuranceTypeDataRow.Length > 0)
            {
                lblInsuranceType.Text = objInsuranceTypeDataRow[0]["Description"].ToString() + " - ";
            }

            Repeater rptBenefitPlanDetail = (Repeater)e.Item.FindControl("rptBenefitPlanDetail");

            rptBenefitPlanDetail.DataSource = _dsEligibilityResponse.Tables[1].Select("Service = '" + objDataRowView["Service"].ToString() + "' AND ISNULL(InsuranceType,'') = '" + objDataRowView["InsuranceType"].ToString() + "'").CopyToDataTable();
            rptBenefitPlanDetail.DataBind();
        }
    }
    protected void rptBenefitPlanDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;

            Label lblService = (Label)e.Item.FindControl("lblService");

            string[] Services = objDataRowView["ServiceType"].ToString().Split('^');
            string html = "";


            for (int i = 0; i < Services.Length; i++)
            {
                if (!string.IsNullOrEmpty(Services[i]))
                {
                    string Service = _dtEDICodes.Select("ElementName = 'EB03' AND Code='" + Services[i] + "'")[0]["Description"].ToString();

                    DataRow[] drTime = _dtEDICodes.Select("ElementName = 'EB06' AND Code='" + objDataRowView["Time"].ToString() + "'");
                    string Time = "";

                    if (drTime.Length > 0)
                    {
                        Time = drTime[0]["Description"].ToString();
                    }

                    string Amount = objDataRowView["Amount"].ToString().Replace("\n", "<br/>");

                    string Quantity = objDataRowView["Quantity"].ToString() == "" ? "" : objDataRowView["Quantity"].ToString() + "%";

                    DataRow[] drQuantityQualifier = _dtEDICodes.Select("ElementName = 'EB09' AND Code='" + objDataRowView["QuantityQualifier"].ToString() + "'");
                    string QuantityQualifier = "";

                    if (drQuantityQualifier.Length > 0)
                    {
                        QuantityQualifier = drQuantityQualifier[0]["Description"].ToString();
                    }

                    string Dates = "";

                    if (!string.IsNullOrEmpty(objDataRowView["DateQualifier"].ToString()))
                    {
                        string[] DateQualifier = objDataRowView["DateQualifier"].ToString().Split('\n');
                        string[] Date = objDataRowView["Date"].ToString().Split('\n');

                        for (int j = 0; j < DateQualifier.Length; j++)
                        {
                            DataRow[] drDateQualifier = _dtEDICodes.Select("ElementName = 'DTP01' AND Code='" + DateQualifier[j] + "'");

                            if (Dates != "")
                            {
                                Dates += "<br/>";
                            }

                            Dates += drDateQualifier[0]["Description"].ToString() + ": " + DateStringParser(Date[j]);
                        }
                    }

                    string Message = objDataRowView["Message"].ToString().Replace("\n", "<br/>");

                    string[] LSNameModifier = objDataRowView["LSNameModifier"].ToString().Split('\n');

                    for (int j = 0; j < LSNameModifier.Length; j++)
                    {
                        DataRow[] drLSNameModifier = _dtEDICodes.Select("ElementName = 'NM101' AND Code='" + objDataRowView["LSNameModifier"].ToString().Split('\n')[j] + "'");
                        if (drLSNameModifier.Length > 0)
                        {
                            if (Message != "")
                            {
                                Message += "<br/>";
                            }

                            Message += drLSNameModifier[0]["Description"].ToString() + ": " + objDataRowView["LSName"].ToString().Split('\n')[j];
                        }

                        if (objDataRowView["LSAddress"].ToString() != "")
                        {
                            Message += "<br/>" + objDataRowView["LSAddress"].ToString().Split('\n')[j];
                        }
                    }


                    html += "<tr style='background-color:" + (_alternateRow ? "#F7F7F7;" : "#FFF;") + "'>" +
                                "<td style='vertical-align: top;'>" + Service + "</td>" +
                                "<td style='vertical-align: top;'>" + Time + "</td>" +
                                "<td style='vertical-align: top;'>" + Amount + "</td>" +
                                "<td style='vertical-align: top;'>" + Quantity + "</td>" +
                                "<td style='vertical-align: top;'>" + QuantityQualifier + "</td>" +
                                "<td style='vertical-align: top;'>" + Dates + "</td>" +
                                "<td style='vertical-align: top;'>" + Message + "</td>" +
                            "</tr>";

                    _alternateRow = !_alternateRow;
                }
            }

            Literal objLiteral = (Literal)e.Item.FindControl("ltrlEligibilityServices");
            objLiteral.Text = html;
        }
    }
    protected void rptRejection_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;

            Label lblRejectionReason = (Label)e.Item.FindControl("lblRejectionReason");
            lblRejectionReason.Text = _dtEDICodes.Select("ElementName = 'AAA03' AND Code='" + objDataRowView["RejectionReason"].ToString() + "'")[0]["Description"].ToString();

            Label lblFollowupAction = (Label)e.Item.FindControl("lblFollowupAction");
            lblFollowupAction.Text = _dtEDICodes.Select("ElementName = 'AAA04' AND Code='" + objDataRowView["FollowupAction"].ToString() + "'")[0]["Description"].ToString();
        }
    }
    protected string DateStringParser(string DateString)
    {
        string ParsedDate = "";

        if (DateString.Length > 0)
        {
            string[] Date = DateString.Split('-');

            for (int i = 0; i < Date.Length; i++)
            {
                if (ParsedDate != "")
                {
                    ParsedDate += "-";
                }

                ParsedDate += DateTime.ParseExact(Date[i], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None).ToShortDateString();
            }
        }
        
        return ParsedDate;
    }
    protected void rptHealthcareFacilityDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;


            string InsuranceType = "";
            DataRow[] objInsuranceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB04' AND Code='" + objDataRowView["InsuranceType"].ToString() + "'");
            if (objInsuranceTypeDataRow.Length > 0)
                InsuranceType = objInsuranceTypeDataRow[0]["Description"].ToString();


            string[] Services = objDataRowView["ServiceType"].ToString().Split('^');
            string html = "";


            for (int i = 0; i < Services.Length; i++)
            {
                if (!string.IsNullOrEmpty(Services[i]))
                {
                    string Service = _dtEDICodes.Select("ElementName = 'EB03' AND Code='" + Services[i] + "'")[0]["Description"].ToString();

                    DataRow[] drTime = _dtEDICodes.Select("ElementName = 'EB06' AND Code='" + objDataRowView["Time"].ToString() + "'");
                    string Time = "";
                    if (drTime.Length > 0)
                        Time = drTime[0]["Description"].ToString();

                    string Amount = objDataRowView["Amount"].ToString().Replace("\n", "<br/>");

                    string Quantity = objDataRowView["Quantity"].ToString() == "" ? "" : objDataRowView["Quantity"].ToString() + "%";

                    DataRow[] drQuantityQualifier = _dtEDICodes.Select("ElementName = 'EB09' AND Code='" + objDataRowView["QuantityQualifier"].ToString() + "'");
                    string QuantityQualifier = "";
                    if (drQuantityQualifier.Length > 0)
                        QuantityQualifier = drQuantityQualifier[0]["Description"].ToString();

                    string Dates = "";
                    if (!string.IsNullOrEmpty(objDataRowView["DateQualifier"].ToString()))
                    {
                        string[] DateQualifier = objDataRowView["DateQualifier"].ToString().Split('\n');
                        string[] Date = objDataRowView["Date"].ToString().Split('\n');

                        for (int j = 0; j < DateQualifier.Length; j++)
                        {
                            DataRow[] drDateQualifier = _dtEDICodes.Select("ElementName = 'DTP01' AND Code='" + DateQualifier[j] + "'");
                            if (Dates != "")
                                Dates += "<br/>";
                            Dates += drDateQualifier[0]["Description"].ToString() + ": " + DateStringParser(Date[j]);
                        }
                    }

                    string Message = objDataRowView["Message"].ToString().Replace("\n", "<br/>");

                    string HealthCareFacility = "";
                    string[] LSNameModifier = objDataRowView["LSNameModifier"].ToString().Split('\n');

                    for (int j = 0; j < LSNameModifier.Length; j++)
                    {
                        DataRow[] drLSNameModifier = _dtEDICodes.Select("ElementName = 'NM101' AND Code='" + objDataRowView["LSNameModifier"].ToString().Split('\n')[j] + "'");
                        if (drLSNameModifier.Length > 0)
                        {
                            if (HealthCareFacility != "")
                                HealthCareFacility += "<br/>";

                            if (objDataRowView["LSModifier"].ToString() != "XX")
                            {
                                HealthCareFacility += drLSNameModifier[0]["Description"].ToString() + ": " + objDataRowView["LSName"].ToString().Split('\n')[j];
                                HealthCareFacility += "<br/>" + objDataRowView["LSAddress"].ToString().Split('\n')[j];
                            }
                            else
                            {
                            }
                        }
                    }

                    html += "<tr style='background-color:" + (_alternateRow ? "#F7F7F7;" : "#FFF;") + "'>" +
                                "<td style='vertical-align: top;'>" + HealthCareFacility + "</td>" +
                                "<td style='vertical-align: top;'>" + InsuranceType + "</td>" +
                                "<td style='vertical-align: top;'>" + Service + "</td>" +
                                "<td style='vertical-align: top;'>" + Time + "</td>" +
                                "<td style='vertical-align: top;'>" + Amount + "</td>" +
                                "<td style='vertical-align: top;'>" + Quantity + "</td>" +
                                "<td style='vertical-align: top;'>" + QuantityQualifier + "</td>" +
                                "<td style='vertical-align: top;'>" + Dates + "</td>" +
                                "<td style='vertical-align: top;'>" + Message + "</td>" +
                            "</tr>";

                    _alternateRow = !_alternateRow;
                }
            }
            Literal objLiteral = (Literal)e.Item.FindControl("ltrlEligibilityServices");
            objLiteral.Text = html;
        }
    }
    protected void rptAdditionalPayerDetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;

            string InsuranceType = "";
            DataRow[] objInsuranceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB04' AND Code='" + objDataRowView["InsuranceType"].ToString() + "'");
            if (objInsuranceTypeDataRow.Length > 0)
                InsuranceType = objInsuranceTypeDataRow[0]["Description"].ToString();

            string[] Services = objDataRowView["ServiceType"].ToString().Split('^');
            string html = "";


            for (int i = 0; i < Services.Length; i++)
            {
                if (!string.IsNullOrEmpty(Services[i]))
                {
                    string Service = _dtEDICodes.Select("ElementName = 'EB03' AND Code='" + Services[i] + "'")[0]["Description"].ToString();

                    DataRow[] drTime = _dtEDICodes.Select("ElementName = 'EB06' AND Code='" + objDataRowView["Time"].ToString() + "'");
                    string Time = "";
                    if (drTime.Length > 0)
                        Time = drTime[0]["Description"].ToString();

                    string Amount = objDataRowView["Amount"].ToString().Replace("\n", "<br/>");

                    string Quantity = objDataRowView["Quantity"].ToString() == "" ? "" : objDataRowView["Quantity"].ToString() + "%";

                    DataRow[] drQuantityQualifier = _dtEDICodes.Select("ElementName = 'EB09' AND Code='" + objDataRowView["QuantityQualifier"].ToString() + "'");
                    string QuantityQualifier = "";
                    if (drQuantityQualifier.Length > 0)
                        QuantityQualifier = drQuantityQualifier[0]["Description"].ToString();

                    string Dates = "";
                    if (!string.IsNullOrEmpty(objDataRowView["DateQualifier"].ToString()))
                    {
                        string[] DateQualifier = objDataRowView["DateQualifier"].ToString().Split('\n');
                        string[] Date = objDataRowView["Date"].ToString().Split('\n');

                        for (int j = 0; j < DateQualifier.Length; j++)
                        {
                            DataRow[] drDateQualifier = _dtEDICodes.Select("ElementName = 'DTP01' AND Code='" + DateQualifier[j] + "'");
                            if (Dates != "")
                                Dates += "<br/>";
                            Dates += drDateQualifier[0]["Description"].ToString() + ": " + DateStringParser(Date[j]);
                        }
                    }

                    string Message = objDataRowView["Message"].ToString().Replace("\n", "<br/>");

                    string AdditionalPayer = "";
                    string[] LSNameModifier = objDataRowView["LSNameModifier"].ToString().Split('\n');

                    for (int j = 0; j < LSNameModifier.Length; j++)
                    {
                        DataRow[] drLSNameModifier = _dtEDICodes.Select("ElementName = 'NM101' AND Code='" + objDataRowView["LSNameModifier"].ToString().Split('\n')[j] + "'");
                        if (drLSNameModifier.Length > 0)
                        {
                            if (AdditionalPayer != "")
                                AdditionalPayer += "<br/>";

                            AdditionalPayer += drLSNameModifier[0]["Description"].ToString() + ": " + objDataRowView["LSName"].ToString().Split('\n')[j];
                        }

                        if (objDataRowView["LSAddress"].ToString() != "")
                            AdditionalPayer += "<br/>" + objDataRowView["LSAddress"].ToString().Split('\n')[j];
                    }


                    html += "<tr style='background-color:" + (_alternateRow ? "#F7F7F7;" : "#FFF;") + "'>" +
                                "<td style='vertical-align: top;'>" + AdditionalPayer + "</td>" +
                                "<td style='vertical-align: top;'>" + InsuranceType + "</td>" +
                                "<td style='vertical-align: top;'>" + Service + "</td>" +
                                "<td style='vertical-align: top;'>" + Time + "</td>" +
                                "<td style='vertical-align: top;'>" + Amount + "</td>" +
                                "<td style='vertical-align: top;'>" + Quantity + "</td>" +
                                "<td style='vertical-align: top;'>" + QuantityQualifier + "</td>" +
                                "<td style='vertical-align: top;'>" + Dates + "</td>" +
                                "<td style='vertical-align: top;'>" + Message + "</td>" +
                            "</tr>";

                    _alternateRow = !_alternateRow;
                }
            }
            Literal objLiteral = (Literal)e.Item.FindControl("ltrlEligibilityServices");
            objLiteral.Text = html;
        }
    }
    protected void rptHomeHealth_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {

    }
    protected void rptEligibilityBenefitDescription_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            
            DataRowView objDataRowView = (DataRowView)e.Item.DataItem;

            Label lblEligibilityOrBenefit = (Label)e.Item.FindControl("lblEligibilityOrBenefit");
            Label lblServiceType = (Label)e.Item.FindControl("lblServiceType");
            Label lblCoverage = (Label)e.Item.FindControl("lblCoverage");
            Label lblInsuranceType = (Label)e.Item.FindControl("lblInsuranceType");
            Label lblPlanCoverageDescription = (Label)e.Item.FindControl("lblPlanCoverageDescription");
            Label lblTimePeriod = (Label)e.Item.FindControl("lblTimePeriod");
            Label lblAmount = (Label)e.Item.FindControl("lblAmount");
            Label lblPercent = (Label)e.Item.FindControl("lblPercent");
            Label lblCertification = (Label)e.Item.FindControl("lblCertification");
            Label lblInPlanNetwork = (Label)e.Item.FindControl("lblInPlanNetwork");
            Label lblMessage = (Label)e.Item.FindControl("lblMessage");
            string EligibilityOrBenefit = objDataRowView["Service"].ToString();
            lblEligibilityOrBenefit.Text = EligibilityOrBenefit;
           
            string[] Services = objDataRowView["Service"].ToString().Split('^');
            for (int i = 0; i < Services.Length; i++)
            {
                if (!string.IsNullOrEmpty(Services[i]))
                {
                    string Service = _dtEDICodes.Select("ElementName = 'EB01' AND Code='" + Services[i] + "'")[0]["Description"].ToString();
                    lblEligibilityOrBenefit.Text = Service;
                }
            }
            DataRow[] objCoverageLevelDataRow = _dtEDICodes.Select("ElementName = 'EB02' AND Code='" + objDataRowView["CoverageLevel"].ToString() + "'");

            if (objCoverageLevelDataRow.Length > 0)
            {
                lblCoverage.Text = objCoverageLevelDataRow[0]["Description"].ToString() + " - ";
            }

            DataRow[] objSerivceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB03' AND Code='" + objDataRowView["ServiceType"].ToString() + "'");

            if (objSerivceTypeDataRow.Length > 0)
            {
                lblCoverage.Text = objSerivceTypeDataRow[0]["Description"].ToString() + " - ";
            }

            DataRow[] objInsuranceTypeDataRow = _dtEDICodes.Select("ElementName = 'EB04' AND Code='" + objDataRowView["InsuranceType"].ToString() + "'");

            if (objInsuranceTypeDataRow.Length > 0)
            {
                lblInsuranceType.Text = objInsuranceTypeDataRow[0]["Description"].ToString() + " - ";
            }

            DataRow[] objPlanCoverageDescDataRow = _dtEDICodes.Select("ElementName = 'EB05' AND Code='" + objDataRowView["PlanCoverageDescription"].ToString() + "'");

            if (objPlanCoverageDescDataRow.Length > 0)
            {
                lblPlanCoverageDescription.Text = objPlanCoverageDescDataRow[0]["Description"].ToString() + " - ";
            }
            
            DataRow[] drTime = _dtEDICodes.Select("ElementName = 'EB06' AND Code='" + objDataRowView["Time"].ToString() + "'");
            string Time = "";

            if (drTime.Length > 0)
            {
                Time = drTime[0]["Description"].ToString();
            }
            lblTimePeriod.Text = Time;

            DataRow[] objAmountDataRow = _dtEDICodes.Select("ElementName = 'EB07' AND Code='" + objDataRowView["Amount"].ToString() + "'");

            if (objAmountDataRow.Length > 0)
            {
                lblAmount.Text = objAmountDataRow[0]["Amount"].ToString();
            }
            lblAmount.Text = objDataRowView["Amount"].ToString(); 

            string Quantity = objDataRowView["Quantity"].ToString() == "" ? "" : objDataRowView["Quantity"].ToString() + "%";
            lblPercent.Text = Quantity;

            DataRow[] drAuth = _dtEDICodes.Select("ElementName = 'EB11' AND Code='" + objDataRowView["Auhorization"].ToString() + "'");
            string Auth = "";

            if (drAuth.Length > 0)
            {
                Auth = drAuth[0]["Description"].ToString();
            }
            lblCertification.Text = Auth;


            DataRow[] drInPlan = _dtEDICodes.Select("ElementName = 'EB11' AND Code='" + objDataRowView["InPlanNetwork"].ToString() + "'");
            string InPlan = "";

            if (drInPlan.Length > 0)
            {
                InPlan = drInPlan[0]["Description"].ToString();
            }
            lblInPlanNetwork.Text = InPlan;

            string Message = objDataRowView["Message"].ToString().Replace("\n", "<br/>");
            //....
            string[] LSNameModifier = objDataRowView["LSNameModifier"].ToString().Split('\n');

            for (int j = 0; j < LSNameModifier.Length; j++)
            {
                DataRow[] drLSNameModifier = _dtEDICodes.Select("ElementName = 'NM101' AND Code='" + objDataRowView["LSNameModifier"].ToString().Split('\n')[j] + "'");
                if (drLSNameModifier.Length > 0)
                {
                    if (Message != "")
                    {
                        Message += "<br/>";
                    }

                    Message += drLSNameModifier[0]["Description"].ToString() + ": " + objDataRowView["LSName"].ToString().Split('\n')[j];
                }

                if (objDataRowView["LSAddress"].ToString() != "")
                {
                    Message += "<br/>" + objDataRowView["LSAddress"].ToString().Split('\n')[j];
                }
            }
            //...
            lblMessage.Text = Message;

            
             
            

        }
    }
}