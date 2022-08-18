using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;


/// <summary>
/// Summary description for ClaimsSubmission
/// </summary>
public class ClaimsSubmission
{
	public ClaimsSubmission()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string claimSubmissionFile = string.Empty;
    private int _segmentCounter = 0;
    private int _ISAInterchangeControlNumber;
    private int _GSGroupCtrlNumber;
    private int _STTransactionSetControlNumber;
    private int _HLCounter = 0;
    private int _HLParent = 0;
    private int _HLQCParent = 0;
    private int _STCounter = 0;
    private int _GSCounter = 0;
    
    private string _payerId837 = string.Empty;
    private string _CBSA = string.Empty;
    private Int64 _prevReceivderId = 0;
    private Int64 _previousPatAccount = 0;
    private DataTable _dtClaimsEdiDetails;
    private List<ClaimsSubmitted> _claimsSubmitted;
    private string _recieverName = string.Empty;
    private long _PracticeId;
    private long _userId;

    public void GenerateEdiFile(string claimIds, string insuranceIds)
    {
        ProfileCommon objProfileCommon = (ProfileCommon)HttpContext.Current.Profile;
        _PracticeId = long.Parse(objProfileCommon.GetPropertyValue("PracticeId").ToString());
        _userId = long.Parse(objProfileCommon.GetPropertyValue("UserId").ToString());

        InsuranceEDIInfoDB objInsuranceEdiInfoDb = new InsuranceEDIInfoDB();
        //string[] claimIds = (from x in claimsSubmittedList select x.EpisodeId.ToString()).ToArray();

        //Get Receiver and Submitter Info

        _dtClaimsEdiDetails = objInsuranceEdiInfoDb.GetClaimsEdiDetails(claimIds, insuranceIds);

        for (int b = 0; b < _dtClaimsEdiDetails.Rows.Count; b++)
        {
            Int64 receiverId = Int64.Parse(_dtClaimsEdiDetails.Rows[b]["InsuranceEDIinfoID"].ToString());
            if (_prevReceivderId != receiverId)
            {
                if (b != 0)
                {
                    SaveSubmittedClaims();
                }
                claimSubmissionFile = "";
                _claimsSubmitted = new List<ClaimsSubmitted>();
                
                claimSubmissionFile += AddHeader(b);

                AddSegments(Int64.Parse(_dtClaimsEdiDetails.Rows[b]["PatientId"].ToString()), b);
                _prevReceivderId = receiverId;
                if (b == _dtClaimsEdiDetails.Rows.Count - 1)
                    SaveSubmittedClaims();
            }
            else
            {
                AddSegments(Int64.Parse(_dtClaimsEdiDetails.Rows[b]["PatientId"].ToString()), b);
                if (b == _dtClaimsEdiDetails.Rows.Count - 1)
                    SaveSubmittedClaims();
            }
        }

    }

    private string AddHeader(int index)
    {
        _payerId837 = string.Empty;
        string transactionType = string.Empty;
        string submitterId = string.Empty;
        string receiverId = string.Empty;
        string isa05 = string.Empty;
        string isa06 = string.Empty;
        string isa07 = string.Empty;
        string isa08 = string.Empty;
        string gs02 = string.Empty;
        string gs03 = string.Empty;
        string receiverName = string.Empty;
        string submitterName = string.Empty;
        string submitterContactName = string.Empty;
        string submitterContactNumber = string.Empty;

        string header = string.Empty;
        _payerId837 = _dtClaimsEdiDetails.Rows[index]["PayerID837"].ToString();
        transactionType = _dtClaimsEdiDetails.Rows[index]["TransactionType"].ToString();
        submitterId = _dtClaimsEdiDetails.Rows[index]["SubmitterID"].ToString();
        receiverId = _dtClaimsEdiDetails.Rows[index]["ReceiverID"].ToString();
        isa05 = _dtClaimsEdiDetails.Rows[index]["ISA05"].ToString();
        isa06 = _dtClaimsEdiDetails.Rows[index]["ISA06"].ToString();
        isa07 = _dtClaimsEdiDetails.Rows[index]["ISA07"].ToString();
        isa08 = _dtClaimsEdiDetails.Rows[index]["ISA08"].ToString();
        gs02 = _dtClaimsEdiDetails.Rows[index]["GS02"].ToString();
        gs03 = _dtClaimsEdiDetails.Rows[index]["GS03"].ToString();
        _recieverName = _dtClaimsEdiDetails.Rows[index]["ReceiverName"].ToString().Trim();
        submitterName = _dtClaimsEdiDetails.Rows[index]["SubmitterName"].ToString().Trim();
        submitterContactName = _dtClaimsEdiDetails.Rows[index]["SubmitterContactName"].ToString().Trim();
        submitterContactNumber = _dtClaimsEdiDetails.Rows[index]["SubmitterContactNumber"].ToString().Trim();

        header = ISA(isa05, isa06, isa07, isa08);
        header += GS(gs02, gs03);
        
        header += ST(transactionType); // Start of Transaction Set and Hirarchical Transtration
        
        header += BHT("CH");

        header += NM1("41", "2", submitterName, "", "", "", "46", submitterId); // Submitter Info
        header += PER(submitterContactName, submitterContactNumber); // Submitter Contact Person Info
        header += NM1("40", "2", receiverName, "", "", "", "46", receiverId); // Reciever Info

        //Billing Provider Segment
        PracticesDB objPracticesDB = new PracticesDB();
        DataTable dtPracticeInfo = objPracticesDB.Practices_GetByPracticeId(_PracticeId);
        header += HL("", "20", "1");
        header += PRV("BI", "PXC", dtPracticeInfo.Rows[0]["TaxonomyCode"].ToString().Trim());
        header += NM1("85", "2", dtPracticeInfo.Rows[0]["PracticeName"].ToString().Trim(), "", "", "", "XX", dtPracticeInfo.Rows[0]["NPI"].ToString());
        // Submitter Info
        header += N3(dtPracticeInfo.Rows[0]["Address"].ToString());
        header += N4(dtPracticeInfo.Rows[0]["City"].ToString().Trim(), dtPracticeInfo.Rows[0]["State"].ToString(),
                     dtPracticeInfo.Rows[0]["Zip"].ToString());
        header += REF("EI", dtPracticeInfo.Rows[0]["TaxId"].ToString());
        return header;
    }
    private void AddSegments(Int64 patientAccount, int index)
    {
        if (_previousPatAccount != patientAccount)
        {
            //Add Subscriber Segment            
            _previousPatAccount = patientAccount;
            claimSubmissionFile += HL("1", "22", "0");
            claimSubmissionFile += AddSubscriber(index);
            // Add Claim Details Segment
            claimSubmissionFile += AddClaims(index);
        }
        else
        {
            claimSubmissionFile += AddClaims(index);
        }
    }
    private string AddSubscriber(int index)
    {
        //_CBSA = _dtClaimsEdiDetails.Rows[index]["CBSA"].ToString();
        string subscriberInfo = "";
        string sInsuranceType = "CI";

        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["InsuranceCategory"].ToString()))
        {
            switch (_dtClaimsEdiDetails.Rows[index]["InsuranceCategory"].ToString())
            {
                case "MCRA":
                    sInsuranceType = "MB";
                    break;
                case "MCRB":
                    sInsuranceType = "MB";
                    break;
                case "MCRT":
                    sInsuranceType = "MB";
                    break;
                case "MCRD":
                    sInsuranceType = "OF";
                    break;
                case "MCD":
                    sInsuranceType = "MC";
                    break;
                case "BCBS":
                    sInsuranceType = "BL";
                    break;

            }


        }

        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["SubscriberId"].ToString()) && _dtClaimsEdiDetails.Rows[index]["SubscriberId"].ToString() != "0")
        {
            //If subscriber is not the patient 

            
            subscriberInfo = SBR("P", "", sInsuranceType);
            subscriberInfo += NM1("IL", "1", _dtClaimsEdiDetails.Rows[index]["SubscriberLastName"].ToString().Trim(), _dtClaimsEdiDetails.Rows[index]["SubscriberFirstName"].ToString().Trim(), "", "", "MI", _dtClaimsEdiDetails.Rows[index]["PolicyNumber"].ToString());

            if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["SubscriberAddress"].ToString()))
            {
                subscriberInfo += N3(_dtClaimsEdiDetails.Rows[index]["SubscriberAddress"].ToString());
            }

            if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["SubscriberZip"].ToString()))
            {
            subscriberInfo += N4(_dtClaimsEdiDetails.Rows[index]["SubscriberCity"].ToString(), _dtClaimsEdiDetails.Rows[index]["SubscriberState"].ToString(), _dtClaimsEdiDetails.Rows[index]["SubscriberZip"].ToString());
            }

            string dateOfBirth = "";

            if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["SubscriberDOB"].ToString()))
            {
                dateOfBirth = DateTime.Parse(_dtClaimsEdiDetails.Rows[index]["SubscriberDOB"].ToString()).ToString("yyyyMMdd");
            }

            string gender = "";
            if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["SubscriberGender"].ToString()))
            {
                gender = _dtClaimsEdiDetails.Rows[index]["SubscriberGender"].ToString() == "Male" ? "M" : "F";
            }
            subscriberInfo += DMG("D8", dateOfBirth, gender);

            //Subscriber is not the patient write patient loop

            subscriberInfo += PAT(_dtClaimsEdiDetails.Rows[index]["Relationship"].ToString());
            subscriberInfo += NM1("QC", "1", _dtClaimsEdiDetails.Rows[index]["LastName"].ToString().Trim(), _dtClaimsEdiDetails.Rows[index]["FirstName"].ToString().Trim(), "", "", "MI", _dtClaimsEdiDetails.Rows[index]["PolicyNumber"].ToString());

            subscriberInfo += N3(_dtClaimsEdiDetails.Rows[index]["Address"].ToString());
            subscriberInfo += N4(_dtClaimsEdiDetails.Rows[index]["City"].ToString(), _dtClaimsEdiDetails.Rows[index]["State"].ToString(), _dtClaimsEdiDetails.Rows[index]["Zip"].ToString());

            string pdateOfBirth = DateTime.Parse(_dtClaimsEdiDetails.Rows[index]["DateOfBirth"].ToString()).ToString("yyyyMMdd");
            string pgender = "";
            if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["Gender"].ToString()))
            {
                pgender = _dtClaimsEdiDetails.Rows[index]["Gender"].ToString() == "Male" ? "M" : "F";
            }
            subscriberInfo += DMG("D8", pdateOfBirth, pgender);
        }
        else
        {
            //If subscriber is patient

            subscriberInfo = SBR("P", "18", sInsuranceType);
            subscriberInfo += NM1("IL", "1", _dtClaimsEdiDetails.Rows[index]["LastName"].ToString().Trim(), _dtClaimsEdiDetails.Rows[index]["FirstName"].ToString().Trim(), "", "", "MI", _dtClaimsEdiDetails.Rows[index]["PolicyNumber"].ToString());

            subscriberInfo += N3(_dtClaimsEdiDetails.Rows[index]["Address"].ToString());
            subscriberInfo += N4(_dtClaimsEdiDetails.Rows[index]["City"].ToString(), _dtClaimsEdiDetails.Rows[index]["State"].ToString(), _dtClaimsEdiDetails.Rows[index]["Zip"].ToString());

            string dateOfBirth = DateTime.Parse(_dtClaimsEdiDetails.Rows[index]["DateOfBirth"].ToString()).ToString("yyyyMMdd");
            string gender = "";
            if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["Gender"].ToString()))
            {
                gender = _dtClaimsEdiDetails.Rows[index]["Gender"].ToString() == "Male" ? "M" : "F";
            }
            subscriberInfo += DMG("D8", dateOfBirth, gender);
        }

        //Subscriber Insurance 
        subscriberInfo += NM1("PR", "2", _dtClaimsEdiDetails.Rows[index]["InsuranceName"].ToString(), "", "", "", "PI", _dtClaimsEdiDetails.Rows[index]["PayerID837"].ToString());
        return subscriberInfo;
    }
    private string AddClaims(int index)
    {
        ClaimDB objClaimDB = new ClaimDB();
        Int64 claimId = Int64.Parse(_dtClaimsEdiDetails.Rows[index]["ClaimId"].ToString());


        DataSet dsClaimDetails =
            objClaimDB.GetClaimDetailsEDI(Int64.Parse(_dtClaimsEdiDetails.Rows[index]["PatientId"].ToString()), claimId);


        string claim = string.Empty;

        claim += CLM(claimId.ToString(), _dtClaimsEdiDetails.Rows[index]["TotalCharges"].ToString(), _dtClaimsEdiDetails.Rows[index]["POS"].ToString(),"1");

        string sICD = "";

        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode1"].ToString()))
        {
            sICD += "ABK:" + _dtClaimsEdiDetails.Rows[index]["DXCode1"].ToString();

        }

        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode2"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode2"].ToString();

        }

        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode3"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode3"].ToString();

        }

        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode4"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode4"].ToString();

        }
        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode5"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode5"].ToString();

        }
        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode6"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode6"].ToString();

        }
        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode7"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode7"].ToString();

        }
        if (!string.IsNullOrEmpty(_dtClaimsEdiDetails.Rows[index]["DXCode8"].ToString()))
        {
            sICD += "*ABF:" + _dtClaimsEdiDetails.Rows[index]["DXCode8"].ToString();

        }

        claim += HI(sICD);


        claim += NM1("82", "1", _dtClaimsEdiDetails.Rows[index]["AttendingLastName"].ToString().Trim(),
                     _dtClaimsEdiDetails.Rows[index]["AttendingFirstName"].ToString().Trim(), "", "", "XX",
                     _dtClaimsEdiDetails.Rows[index]["AttendingNPI"].ToString());

        if (!(_dtClaimsEdiDetails.Rows[index]["POS"].ToString()=="12" || _dtClaimsEdiDetails.Rows[index]["POS"].ToString() == "11"))
        {
            claim += NM1("77", "2", _dtClaimsEdiDetails.Rows[index]["ServiceFacilityLocationName"].ToString().Trim(),
                     "", "", "", "XX",
                     _dtClaimsEdiDetails.Rows[index]["ServiceFacilityNPI"].ToString());

            claim += N3(_dtClaimsEdiDetails.Rows[index]["ServiceFacilityAddress"].ToString());
            claim += N4(_dtClaimsEdiDetails.Rows[index]["ServiceFacilityCity"].ToString(), _dtClaimsEdiDetails.Rows[index]["ServiceFacilityState"].ToString(), _dtClaimsEdiDetails.Rows[index]["ServiceFacilityZip"].ToString());
        }

        if (_dtClaimsEdiDetails.Rows[index]["SupervisingPhysicianId"].ToString() != "")
        {
            claim += NM1("DQ", "1", _dtClaimsEdiDetails.Rows[index]["SupervisingLastName"].ToString().Trim(),
                     _dtClaimsEdiDetails.Rows[index]["SupervisingFirstName"].ToString().Trim(), "", "", "XX",
                     _dtClaimsEdiDetails.Rows[index]["SupervisingNPI"].ToString());
            
        }

        claim += AddClaimsServices(dsClaimDetails.Tables[1]);

        var objClaimsSubmitted = new ClaimsSubmitted
                                                 {
                                                     ClaimNo = claimId,
                                                     PatientAccount = _previousPatAccount,
                                                     LocationId = long.Parse(_dtClaimsEdiDetails.Rows[index]["PracticeLocationsId"].ToString()),
                                                     InsuranceId = Int64.Parse(_dtClaimsEdiDetails.Rows[index]["InsuranceId"].ToString())
                                                 };

        _claimsSubmitted.Add(objClaimsSubmitted);
        return claim;
    }
    private string AddClaimsServices(DataTable dtService)
    {
        int _ServicesCount = 0;
        string services = "";

        _ServicesCount++;
        for (int i = 0; i < dtService.Rows.Count; i++)
        {
            _segmentCounter++;
            services += "LX*" + _ServicesCount + "~";
            string hcpcsCode = dtService.Rows[i]["CPTCode"].ToString();
            string totalCharges = "";
       
            totalCharges = Math.Round(Convert.ToDecimal(dtService.Rows[i]["TotalCharges"].ToString()), 2).ToString();

            services += SV1(dtService.Rows[i]["CPTCode"].ToString(), dtService.Rows[i]["modifier1"].ToString(), dtService.Rows[i]["modifier2"].ToString()
                , dtService.Rows[i]["modifier3"].ToString(), dtService.Rows[i]["modifier4"].ToString(), totalCharges, "UN", dtService.Rows[i]["ServiceUnits"].ToString(), dtService.Rows[i]["Dxpointer1"].ToString(), dtService.Rows[i]["Dxpointer2"].ToString(), dtService.Rows[i]["Dxpointer3"].ToString(), dtService.Rows[i]["Dxpointer4"].ToString());

            if (!string.IsNullOrEmpty(dtService.Rows[i]["ServiceDate"].ToString()))
                services += DTP("472", "D8", DateTime.Parse(dtService.Rows[i]["ServiceDate"].ToString()).ToString("yyyyMMdd"));

            services += REF("6R", dtService.Rows[i]["ClaimChargesId"].ToString());
            _ServicesCount++;
        }
        return services;
    }
    private string ISA(string isa05, string isa06, string isa07, string isa08)
    {
        string dateTimeNow = DateTime.Now.ToString("yyMMddHHmm").Substring(1, 9);
        _ISAInterchangeControlNumber = int.Parse(dateTimeNow);

        string ISA = "ISA*";
        string ISA01 = "00";
        string ISA02 = string.Empty.PadRight(10);
        string ISA03 = "00";
        string ISA04 = string.Empty.PadRight(10);
        string ISA05 = isa05;
        string ISA06 = isa06.PadRight(15,' ').Substring(0,15);
        string ISA07 = isa07;
        string ISA08 = isa08.PadRight(15, ' ').Substring(0, 15);
        string ISA09 = DateTime.Now.ToString("yyMMdd");
        string ISA10 = DateTime.Now.ToString("HHmm");
        string ISA11 = "^";

        string ISA12 = "00501";
        string ISA13 = _ISAInterchangeControlNumber.ToString();

        string ISA14 = "1";
        string ISA15 = "P";
        string ISA16 = ":";

        ISA += ISA01 + "*" + ISA02 + "*" + ISA03 + "*" + ISA04 + "*" + ISA05 + "*" + ISA06 + "*" + ISA07 + "*" + ISA08 + "*" + ISA09 + "*" + ISA10 + "*" + ISA11 + "*" + ISA12 + "*" + ISA13 + "*" + ISA14 + "*" + ISA15 + "*" + ISA16 + "~";
        return ISA;
    }
    private string GS(string gs02, string gs03)
    {
        string dateTimeNow = DateTime.Now.ToString("yyMMddHHmm").Substring(1, 9);
        _GSGroupCtrlNumber = int.Parse(dateTimeNow);
        _GSCounter++;

        string GS = "GS*";
        string GS01 = "HC";
        string GS02 = gs02;
        string GS03 = gs03;
        string GS04 = DateTime.Now.ToString("yyyyMMdd");
        string GS05 = DateTime.Now.ToString("HHmmss");
        string GS06 = _GSGroupCtrlNumber.ToString();
        string GS07 = "X";
        string GS08 = "005010X222";

        GS += GS01 + "*" + GS02 + "*" + GS03 + "*" + GS04 + "*" + GS05 + "*" + GS06 + "*" + GS07 + "*" + GS08 + "~";
        return GS;
    }
    private string ST(string transactionType)
    {
        _segmentCounter++;
        _STCounter++;
        string dateTimeNow = DateTime.Now.ToString("yyMMddHHmm").Substring(1, 9);
        _STTransactionSetControlNumber = int.Parse(dateTimeNow);

        string ST = "ST*";
        string ST01 = transactionType;
        string ST02 = _STTransactionSetControlNumber.ToString();
        string ST03 = "005010X222";

        ST += ST01 + "*" + ST02 + "*" + ST03 + "~";
        return ST;
    }
    private string BHT(string transactionTypeCode = "")
    {
        _segmentCounter++;
        string BHT = "BHT*";
        string BHT01 = "0019";
        string BHT02 = "00";
        string BHT03 = DateTime.Now.ToString("yyyyMMddHHmmss");
        string BHT04 = DateTime.Now.ToString("yyyyMMdd");
        string BHT05 = DateTime.Now.ToString("HHmmss");
        string BHT06 = transactionTypeCode;

        BHT += BHT01 + "*" + BHT02 + "*" + BHT03 + "*" + BHT04 + "*" + BHT05 + "*" + BHT06 + "~";
        return BHT;
    }
    private string HL(string parentCount, string hirarchicalLevelCode, string hirarchicalChildCode)
    {
        string HL02 = "";
       
        _segmentCounter++;
        _HLCounter++;

        if (hirarchicalLevelCode == "20")
        {
            _HLParent = _HLCounter;
            HL02 = "";
        }
        else if (hirarchicalLevelCode == "22")
        {
            parentCount = _HLCounter.ToString();
            HL02 = _HLParent.ToString();
        }
        else if (hirarchicalLevelCode == "23")
        {
            HL02 = parentCount;
        }

        string HL = "HL*";
        string HL01 = _HLCounter.ToString();
        
        string HL03 = hirarchicalLevelCode;
        string HL04 = hirarchicalChildCode;

        HL += HL01 + "*" + HL02 + "*" + HL03 + "*" + HL04 + "~";

        return HL;
    }
    private string NM1(string entityIdCode, string entityTypeQualifier, string lastNameorOrganizationName = "", string firstName = "", string middleName = "", string nameSuffix = "", string idCodeQualifier = "", string idCode = "")
    {
        _segmentCounter++;

        string NM1 = "NM1*";
        string NM101 = entityIdCode;
        string NM102 = entityTypeQualifier;
        string NM103 = lastNameorOrganizationName.Replace("*","").Trim();
        string NM104 = firstName.Replace("*", "").Trim();
        string NM105 = middleName.Replace("*", "").Trim();
        string NM106 = string.Empty; //obsolete
        string NM107 = nameSuffix;
        string NM108 = idCodeQualifier;
        string NM109 = idCode.Replace("*", "").Trim();

        if (entityIdCode == "QC")
        {
            NM1 += NM101 + "*" + NM102 + "*" + NM103 + "*" + NM104 + "~";
        }
        else
        {
            NM1 += NM101 + "*" + NM102 + "*" + NM103 + "*" + NM104 + "*" + NM105 + "*" + NM106 + "*" + NM107 + "*" + NM108 + "*" + NM109 + "~";
        }
        return NM1;
    }
    private string PER(string submitterContactName, string submitterContactNumber)
    {
        _segmentCounter++;
        string PER = "PER*";
        string PER101 = "IC";
        string PER102 = submitterContactName.Replace("*","").Trim();
        string PER103 = "TE";
        string PER104 = submitterContactNumber;

        PER += PER101 + "*" + PER102 + "*" + PER103 + "*" + PER104 + "~";
        return PER;
    }
    private string REF(string referenceIdentQual, string referenceIdent)
    {
        _segmentCounter++;
        string REF = "REF*";
        string REF01 = referenceIdentQual;
        string REF02 = referenceIdent == "" ? "*" : referenceIdent;

        REF += REF01 + "*" + REF02 + "~";
        return REF;
    }
    private string N3(string addressInformation)
    {
        _segmentCounter++;

        string N3 = "N3*";
        string N301 = addressInformation.Replace("*","").Trim();
        N3 += N301 + "~";
        return N3;
    }
    private string N4(string city, string state, string zip)
    {
        _segmentCounter++;

        string N4 = "N4*";
        string N401 = city;
        string N402 = state;
        string N403 = zip;

        N4 += N401 + "*" + N402 + "*" + N403 + "~";
        return N4;
    }
    private string SBR(string payerResponsibilitySequenceNo, string individualRelationshipCode, string claimFilingIndicatorCode)
    {
        _segmentCounter++;

        string SBR = "SBR*";
        string SBR01 = payerResponsibilitySequenceNo;
        string SBR02 = individualRelationshipCode;
        string SBR09 = claimFilingIndicatorCode;

        SBR += SBR01 + "*" + SBR02 + "*******" + SBR09 + "~";
        return SBR;
    }

    private string PAT(string RelationShip)
    {
        _segmentCounter++;

        string PAT = "PAT*";

        string PAT01 = "";

        switch (RelationShip.ToUpper())
	    {
            case "CHILDREN":
                PAT01 = "19";
                break;
            case "SPOUSE":
                PAT01 = "01";
                break;
            case "EMPLOYEE":
                PAT01 = "20";
                break;
		    default:
                PAT01 = "G8";
            break;
	    }

        PAT += PAT01 + "~";
        return PAT;
    }
    private string DMG(string dateTimeFormatQual = "", string dateTimePeriod = "", string genderCode = "")
    {
        _segmentCounter++;

        string DMG = "DMG*";
        string DMG01 = dateTimeFormatQual;
        string DMG02 = dateTimePeriod;
        string DMG03 = genderCode;

        DMG += DMG01 + "*" + DMG02 + "*" + DMG03 + "~";
        return DMG;
    }
    private string CLM(string claimNo, string charges, string POS, string claimFreequencyCode)
    {
        _segmentCounter++;
        string CLM = "CLM*";
        string CLM01 = claimNo;
        string CLM02 = Math.Round(Convert.ToDecimal(charges), 2).ToString();
        
        
        string CLM05 = "";// = claimType == "100" ? "32:A:2" : "32:A:9";
        //CLM05 = "33:A:9";
        if(POS.Length == 1)
        {
            POS = "0" + POS;
        }
        string CLM05_1 = POS;
        string CLM05_2 = "B";
        string CLM05_3 = claimFreequencyCode;

        CLM05 = CLM05_1 + ":" + CLM05_2 + ":" + CLM05_3;

        string CLM06 = "Y";
        string CLM07 = "A";
        string CLM08 = "Y";
        string CLM09 = "Y";
        CLM += CLM01 + "*" + CLM02 + "***" + CLM05 + "*" + CLM06 + "*" + CLM07 + "*" + CLM08 + "*" + CLM09 + "~";
        return CLM;

    }
    private string DTP(string qualifier, string format, string timePeriod)
    {
        _segmentCounter++;
        string DTP = "DTP*";
        string DTP01 = qualifier;
        string DTP02 = format;
        string DTP03 = timePeriod;

        DTP += DTP01 + "*" + DTP02 + "*" + DTP03 + "~";
        return DTP;

    }

    private string PRV(string providerCode, string qualifier, string referenceId)
    {
        _segmentCounter++;
        string PRV = "PRV*";
        string PRV01 = providerCode;
        string PRV02 = qualifier;
        string PRV03 = referenceId;

        PRV += PRV01 + "*" + PRV02 + "*" + PRV03 + "~";
        return PRV;
    }

    private string CL1(string admissionTypeCode, string admissionSourceCode, string patientStatus)
    {
        _segmentCounter++;
        string CL1 = "CL1*";
        string CL101 = admissionTypeCode;
        string CL102 = admissionSourceCode;
        string CL103 = patientStatus;

        CL1 += CL101 + "*" + CL102 + "*" + CL103 + "~";
        return CL1;
    }
    private string HI(string codes)
    {
        _segmentCounter++;
        string HI = "HI*";
        HI += codes.Replace(".","") + "~";
        return HI;
    }
    private string SV1(string hcpcsCode, string modifier1, string modifier2, string modifier3, string modifier4, string amount, string unitFormat, string unit, string DXPointer1, string DXPointer2, string DXPointer3, string DXPointer4)
    {
        _segmentCounter++;

        
        string SV1 = "SV1*";
        string SV101 = "";

        string SV101_1 = "HC";
        string SV101_2 = hcpcsCode;
        string SV101_3 = modifier1;
        string SV101_4 = modifier2;
        string SV101_5 = modifier3;

        string SV101_6 = modifier4;

        SV101 = SV101_1 + ":" + SV101_2;

        if (SV101_3 != "")
            SV101 += ":" + SV101_3;
        if (SV101_4 != "")
            SV101 += ":" + SV101_4;
        if (SV101_5 != "")
            SV101 += ":" + SV101_5;
        if (SV101_6 != "")
            SV101 += ":" + SV101_6;
        

        string SV102 = amount;
        string SV103 = unitFormat;
        string SV104 = unit;
        string SV105 = "";
        string SV106 = "";

        string SV107 = "";

        string SV107_1 = DXPointer1;
        string SV107_2 = DXPointer2;
        string SV107_3 = DXPointer3;
        string SV107_4 = DXPointer4;



        if (SV107_1 != "" && SV107_1 != "0")
            SV107 += SV107_1;
        if (SV107_2 != "" && SV107_2 != "0")
            SV107 += ":" + SV107_2;
        if (SV107_3 != "" && SV107_3 != "0")
            SV107 += ":" + SV107_3;
        if (SV107_4 != "" && SV107_4 != "0")
            SV107 += ":" + SV107_4;




        SV1 += SV101 + "*" + SV102 + "*" + SV103 + "*" + SV104 + "*" + SV105 + "*" + SV106 + "*" + SV107 + "~";
        return SV1;
    }

    private string SE()
    {
        _segmentCounter++;
        string SE = "SE*";
        string SE01 = _segmentCounter.ToString();
        string SE02 = _STTransactionSetControlNumber.ToString();
        SE += SE01 + "*" + SE02 + "~";

        _STTransactionSetControlNumber++;
        _segmentCounter = 0;
        return SE;
    }
    private string GE()
    {
        string GE = "GE*";

        string GE01 = _STCounter.ToString();
        string GE02 = _GSGroupCtrlNumber.ToString();

        GE += GE01 + "*" + GE02 + "~";
        _GSGroupCtrlNumber++;
        _STCounter = 0;

        return GE;
    }
    private string IEA()
    {
        string IEA = "IEA*";

        string IEA01 = _GSCounter.ToString();
        string IEA02 = _ISAInterchangeControlNumber.ToString();

        IEA += IEA01 + "*" + IEA02 + "~";

        _ISAInterchangeControlNumber++;
        _GSCounter = 0;

        return IEA;
    }

    private string RemoveLastStars(string segment)
    {
        while (segment.LastIndexOf('*') == segment.Length - 1)
        {
            segment = segment.Remove(segment.LastIndexOf('*'));
        }

        return segment;
    }

    private void SaveSubmittedClaims()
    {
        claimSubmissionFile += SE();
        claimSubmissionFile += GE();
        claimSubmissionFile += IEA();

        string dateTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        string fileName = "EDI_" + _recieverName.Substring(0, 5) + "_" + dateTime;

        SaveSubmissionFile(fileName, claimSubmissionFile);

        var submissionFile = new SubmissionFiles
                                 {
                                     FileName = fileName,
                                     PracticeId = _PracticeId,
                                     FileStatus = "Undownloaded",
                                     ISA13 = _ISAInterchangeControlNumber.ToString(),
                                     GS06 = _GSGroupCtrlNumber.ToString(),
                                     CreatedById = _userId,
                                     CreatedDate = DateTime.Now
                                 };

        var objSubmissionFileDb = new SubmissionFilesDB();
        Int64 longSubmissionFileId = objSubmissionFileDb.Add(submissionFile);

        var objClaimsSubmittedDb = new ClaimsSubmittedDB();
        var objClaimDB = new ClaimDB();
        foreach (var claimsSubmitted in _claimsSubmitted)
        {
            claimsSubmitted.PracticeId = _PracticeId;
            claimsSubmitted.SubmissionFileId = longSubmissionFileId;
            claimsSubmitted.PriSecOthType = "P";
            claimsSubmitted.BatchId = _STTransactionSetControlNumber;
            claimsSubmitted.SubmissionDate = DateTime.Now;
            claimsSubmitted.ClaimWorkDate = DateTime.Now;
            claimsSubmitted.CreatedDate = DateTime.Now;
            claimsSubmitted.CreatedById = _userId;

            objClaimsSubmittedDb.Add(claimsSubmitted);
            objClaimDB.ChangeClaimStatus(claimsSubmitted.ClaimNo, 103, _userId);
        }
    }



    private void SaveSubmissionFile(string fileName, string fileText)
    {
        string path = "";
        string savepath = "";
        fileName = fileName + ".txt";
        path = ConfigurationManager.AppSettings["PatientPhoto"] + "/SubmissionFiles/" + _PracticeId;
        savepath = HttpContext.Current.Server.MapPath(path);
        if (!Directory.Exists(savepath))
            Directory.CreateDirectory(savepath);
        try
        {
            System.IO.File.WriteAllText(savepath + "/" + fileName, fileText);
        }
        catch
        {
            ;
        }
    }
}