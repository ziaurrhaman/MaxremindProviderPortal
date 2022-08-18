using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


/// <summary>
/// Summary description for EligibilityRequest
/// </summary>
public class EligibilityRequest
{
    string PracticeName = "";
    string PracticeNPI = "";
    public string GetEligibilityCheckString(long PatientId, long InsuranceId, long PracticeId, DateTime eligibilityStartDate, DateTime eligibilityEndDate, string firstName, string lastName, string dateOfBirth, string policyNumber)
    {
        InsuranceDB objInsuranceDB = new InsuranceDB();
        DataTable dtInsuranceSubmitterPayerReceiverId = objInsuranceDB.GetSubmitterReceiverPayerId(InsuranceId);

        string submitterId = dtInsuranceSubmitterPayerReceiverId.Rows[0]["SubmitterId270"].ToString().Trim();
        string receiverId = dtInsuranceSubmitterPayerReceiverId.Rows[0]["ReceiverId270"].ToString().Trim();
        string payerId = dtInsuranceSubmitterPayerReceiverId.Rows[0]["PayerId270"].ToString().Trim();
        string payerName = dtInsuranceSubmitterPayerReceiverId.Rows[0]["PayerName"].ToString().Trim();

        PracticesDB objPracticesDB = new PracticesDB();
        DataTable dtPracticeInfo = objPracticesDB.Practices_GetByPracticeId(PracticeId);

        PracticeName = dtPracticeInfo.Rows[0]["PracticeName"].ToString().Trim();
        PracticeNPI = dtPracticeInfo.Rows[0]["NPI"].ToString().Trim(); //"9999999990"; // For testing  //
        
        string EligibilityCheckString = string.Empty;

        string ISAString = ISA(submitterId, receiverId);
        string GSString = GS(submitterId, receiverId);
        string STString = ST();
        string BHTString = BHT();

        #region Payer Information

        string PayerInformation = string.Empty;
        string PayerHLString = HL("", "20", "1");
        string PayerNM1String = NM1("PR", "2", receiverId == "CMS" ? "CMS" : payerName, "", "", "", "PI", receiverId == "CMS" ? "CMS" : payerId);

        PayerInformation = PayerHLString + PayerNM1String;

        #endregion

        #region Information Receiver

        string InformationReceiver = string.Empty;
        string InformationReceiverHLString = HL("1", "21", "1");
        string InformationReceiverNM1String = NM1("1P", "2", PracticeName, "", "", "", "XX", PracticeNPI);

        InformationReceiver = InformationReceiverHLString + InformationReceiverNM1String;

        #endregion

        #region Subscriber Information

        string SubscriberInformation = string.Empty;
        string SubscriberInformationHLString = HL("2", "22", "0");
        string SubscriberInformationTRNString = TRN(dtPracticeInfo.Rows[0]["NPI"].ToString());
        string SubscriberInformationNM1String = NM1("IL", "1", lastName, firstName, "", "", "MI", policyNumber);
        string SubscriberInformationDMGString = DMG("D8", dateOfBirth);
        string SubscriberInformationDTPString = DTP("291", "D8", eligibilityStartDate.ToString("yyyyMMdd"));
        string SubscriberInformationEQString = EQ("30");

        SubscriberInformation = SubscriberInformationHLString + SubscriberInformationTRNString + SubscriberInformationNM1String + SubscriberInformationDMGString + SubscriberInformationDTPString + SubscriberInformationEQString;

        #endregion

        string SEString = SE();
        string GEString = GE();
        string IEAString = IEA();

        EligibilityCheckString = ISAString + GSString + STString + BHTString + PayerInformation + InformationReceiver + SubscriberInformation + SEString + GEString + IEAString;


        return EligibilityCheckString;
    }

    private string RemoveLastStars(string segment)
    {
        while (segment.LastIndexOf('*') == segment.Length - 1)
        {
            segment = segment.Remove(segment.LastIndexOf('*'));
        }

        return segment;
    }

    private int _segmentCounter = 0;
    private int _ISAInterchangeControlNumber;
    private int _GSGroupCtrlNumber;
    private int _STTransactionSetControlNumber;
    private int _HLCounter = 0;
    private int _STCounter = 0;
    private int _GSCounter = 0;

    private string ISA(string InterchangeSenderID, string InterchangeReceiverID)
    {
        string dateTimeNow = DateTime.Now.ToString("yyMMddHHmm").Substring(0, 9);
        _ISAInterchangeControlNumber = int.Parse(dateTimeNow);

        string ISA = "ISA*";

        string ISA01 = "00";
        string ISA02 = string.Empty.PadRight(10);
        string ISA03 = "00";
        string ISA04 = string.Empty.PadRight(10);
        string ISA05 = "ZZ";
        string ISA06 = InterchangeSenderID.PadRight(15);
        string ISA07 = "ZZ";
        string ISA08 = InterchangeReceiverID.PadRight(15);
        string ISA09 = DateTime.Now.ToString("yyMMdd");
        string ISA10 = DateTime.Now.ToString("HHmm");
        string ISA11 = "^";

        string ISA12 = "00501";
        string ISA13 = _ISAInterchangeControlNumber.ToString();

        string ISA14 = "0";
        string ISA15 = "P";
        string ISA16 = "|";

        ISA += ISA01 + "*" + ISA02 + "*" + ISA03 + "*" + ISA04 + "*" + ISA05 + "*" + ISA06 + "*" + ISA07 + "*" + ISA08 + "*" + ISA09 + "*" + ISA10 + "*" + ISA11 + "*" + ISA12 + "*" + ISA13 + "*" + ISA14 + "*" + ISA15 + "*" + ISA16 + "~";

        return ISA;
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


    private string GS(string ApplicationSendsCode, string ApplicationRecsCode)
    {
        string dateTimeNow = DateTime.Now.ToString("yyMMddHHmm").Substring(0, 9);
        _GSGroupCtrlNumber = int.Parse(dateTimeNow);

        _GSCounter++;

        string GS = "GS*";

        string GS01 = "HS";
        string GS02 = ApplicationSendsCode;
        string GS03 = ApplicationRecsCode;
        string GS04 = DateTime.Now.ToString("yyyyMMdd");
        string GS05 = DateTime.Now.ToString("HHmmss");
        string GS06 = _GSGroupCtrlNumber.ToString();
        string GS07 = "X";
        string GS08 = "005010X279A1";

        GS += GS01 + "*" + GS02 + "*" + GS03 + "*" + GS04 + "*" + GS05 + "*" + GS06 + "*" + GS07 + "*" + GS08 + "~";

        return GS;
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

    private string ST()
    {
        _segmentCounter++;
        _STCounter++;


        string dateTimeNow = DateTime.Now.ToString("yyMMddHHmm").Substring(0, 9);
        _STTransactionSetControlNumber = int.Parse(dateTimeNow);

        string ST = "ST*";
        string ST01 = "270";
        string ST02 = _STTransactionSetControlNumber.ToString();
        string ST03 = "005010X279A1";

        ST += ST01 + "*" + ST02 + "*" + ST03 + "~";

        return ST;
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


    private string BHT(string TransactionTypeCode = "")
    {
        _segmentCounter++;

        string BHT = "BHT*";

        string BHT01 = "0022";
        string BHT02 = "13";
        string BHT03 = DateTime.Now.ToString("yyyyMMddHHmmss");
        string BHT04 = DateTime.Now.ToString("yyyyMMdd");
        string BHT05 = DateTime.Now.ToString("HHmmss");
        string BHT06 = TransactionTypeCode;

        BHT += BHT01 + "*" + BHT02 + "*" + BHT03 + "*" + BHT04 + "*" + BHT05 + "*" + BHT06;

        return RemoveLastStars(BHT) + "~";
    }

    private string HL(string HierarchParentID, string HierarchLevelCode, string HierarchChildCode)
    {
        _segmentCounter++;
        _HLCounter++;

        string HL = "HL*";

        string HL01 = _HLCounter.ToString();
        string HL02 = HierarchParentID;
        string HL03 = HierarchLevelCode;
        string HL04 = HierarchChildCode;

        HL += HL01 + "*" + HL02 + "*" + HL03 + "*" + HL04 + "~";

        return HL;
    }

    private string NM1(string EntityIDCode, string EntityTypeQualifier, string LastorOrgName = "", string FirstName = "", string MiddleName = "", string NameSuffix = "", string IDCodeQualifier = "", string IDCode = "")
    {
        _segmentCounter++;

        string NM1 = "NM1*";

        string NM101 = EntityIDCode;
        string NM102 = EntityTypeQualifier;
        string NM103 = LastorOrgName;
        string NM104 = FirstName;
        string NM105 = MiddleName;
        string NM106 = string.Empty; //obsolete
        string NM107 = NameSuffix;
        string NM108 = IDCodeQualifier;
        string NM109 = IDCode;

        if (EntityIDCode == "1P")
        {

            //NM1 = "NM1*1P*2*" + PracticeName + "*****XX*" + PracticeNPI;
            if (PracticeNPI == "1972015337" || PracticeNPI == "1376027953")
            {
                NM1 = "NM1*1P*1*" + "AZIZ" + "*SYED****XX*" + 1386634293;
            }
            else
            {
                NM1 = "NM1*1P*2*" + PracticeName + "*****XX*" + PracticeNPI;
            }
            //NM1 = "NM1*1P*2*Paloma Home Health Agency Inc*****XX*1992963318";
            // NM1 = "NM1*1P*2*Paloma Home Health Agency Inc*****XX*1164667531";  //for CMS working 
        }
        else
        {

            NM1 += NM101 + "*" + NM102 + "*" + NM103 + "*" + NM104 + "*" + NM105 + "*" + NM106 + "*" + NM107 + "*" + NM108 + "*" + NM109;
        }

        return RemoveLastStars(NM1) + "~";
    }

    private string REF(string ReferenceIdentQual, string ReferenceIdent, string Description = "")
    {
        _segmentCounter++;

        string REF = "REF*";

        string REF01 = ReferenceIdentQual;
        string REF02 = ReferenceIdent;
        string REF03 = Description;

        REF += REF01 + "*" + REF02 + "*" + REF03;

        return RemoveLastStars(REF) + "~";
    }


    private string N3(string AddressInformation, string AddressInformationExtra = "")
    {
        _segmentCounter++;

        string N3 = "N3*";

        string N301 = AddressInformation;
        string N302 = AddressInformationExtra;

        N3 += N301 + "*" + N302;

        return RemoveLastStars(N3) + "~";
    }


    private string N4(string CityName, string StateorProvCode = "", string PostalCode = "", string CountryCode = "", string CountrySubCode = "")
    {
        _segmentCounter++;

        string N4 = "N4*";

        string N401 = CityName;
        string N402 = StateorProvCode;
        string N403 = PostalCode;
        string N404 = CountryCode;
        string N405 = string.Empty; //obsolete
        string N406 = string.Empty; //obsolete
        string N407 = CountrySubCode;

        N4 += N401 + "*" + N402 + "*" + N403 + "*" + N404 + "*" + N405 + "*" + N406 + "*" + N407;

        return RemoveLastStars(N4) + "~";
    }

    private string PRV(string ProviderCode, string ReferenceIdentQual = "", string ReferenceIdent = "")
    {
        _segmentCounter++;

        string PRV = "PRV*";
        string PRV01 = ProviderCode;
        string PRV02 = ReferenceIdentQual;
        string PRV03 = ReferenceIdent;

        PRV += PRV01 + "*" + PRV02 + "*" + PRV03;
        return RemoveLastStars(PRV) + "~";
    }

    private string DMG(string DateTimeFormatQual = "", string DateTimePeriod = "", string GenderCode = "")
    {
        _segmentCounter++;

        string DMG = "DMG*";
        string DMG01 = DateTimeFormatQual;
        string DMG02 = DateTimePeriod;
        string DMG03 = GenderCode;

        DMG += DMG01 + "*" + DMG02 + "*" + DMG03;
        return RemoveLastStars(DMG) + "~";
    }

    private string DTP(string DateorTimeQualifier, string DateTimeFormatQual, string DateTimePeriod)
    {
        _segmentCounter++;

        string DTP = "DTP*";
        string DTP01 = DateorTimeQualifier;
        string DTP02 = DateTimeFormatQual;
        string DTP03 = DateTimePeriod;

        DTP += DTP01 + "*" + DTP02 + "*" + DTP03;
        return RemoveLastStars(DTP) + "~";
    }


    private string TRN(string NPI)
    {
        _segmentCounter++;

        string TRN = "TRN*";
        string TRN01 = "1";
        string TRN02 = DateTime.Now.ToString("yyyyMMddHHmmss");
        string TRN03 = DateTime.Now.ToString("yyyyMMddHHmmss").Substring(0, 10);
        string TRN04 = string.Empty;

        TRN += TRN01 + "*" + TRN02 + "*" + TRN03 + "*" + TRN04;
        return RemoveLastStars(TRN) + "~";
    }

    private string EQ(string ServiceTypeCode, string CompMedProced = "", string CoverageLevelCode = "", string CompDiagCodePoint = "")
    {
        _segmentCounter++;

        string EQ = "EQ*";
        string EQ01 = ServiceTypeCode;
        string EQ02 = CompMedProced;
        string EQ03 = CoverageLevelCode;
        string EQ04 = string.Empty; //obsolete
        string EQ05 = CompDiagCodePoint;

        EQ += EQ01 + "*" + EQ02 + "*" + EQ03 + "*" + EQ04 + "*" + EQ05;
        return RemoveLastStars(EQ) + "~";
    }
}