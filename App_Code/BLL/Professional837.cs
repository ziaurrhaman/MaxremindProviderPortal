using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Data;

/// <summary>
/// Summary description for Professional837
/// </summary>
public class Professional837
{
    public Professional837(string RootPath, long PracticeId)
	{
        this.RootPath = RootPath;
        this.PracticeId = PracticeId;
	}
    
    public string RootPath;
    public long PracticeId;
    
    
    
    public string strCloseHeader_837 = "";
    
    public int ISAIncrement = 0;
    
    int STCount = 0;
    int GSCount = 0;
    string ISA13 = "";
    string GS06 = "";
    string ST02 = "";
    int segmentsCount = 0;
    int HL_ID = 0;
    int HL01_BillingProvider = 0;
    int HL01_Subscriber = 0;
    int ProcedureCount = 0;
    DateTime currentDateTime = DateTime.Now;
    string IndividualRelationshipCode = "";
    
    
    public bool GenerateFile_837(DataSet dsProfessionalInformation837)
    {
        DataTable dtHeaderInformation837 = dsProfessionalInformation837.Tables[0];
        HeaderInformation837DB objHeaderInformation837DB = new HeaderInformation837DB();
        int HeaderID837;
        string strGenerateHeader_837 = "";
        string strGenerateClaim_837 = "";

        for (int i = 0; i < dtHeaderInformation837.Rows.Count; i++)
        {
            strGenerateHeader_837 = GenerateHeader_837(dtHeaderInformation837.Rows[i]);

            HeaderID837 = int.Parse(dtHeaderInformation837.Rows[i]["HeaderID837"].ToString());
            DataTable dtClaimInformation837 = objHeaderInformation837DB.GetInformation_837_Claim(HeaderID837, 0, 0, PracticeId);
            strGenerateClaim_837 = GenerateClaimInformation_837(dtHeaderInformation837.Rows[i], dtClaimInformation837);

            strCloseHeader_837 = CloseHeader_837();

            Save837File(strGenerateHeader_837 + strGenerateClaim_837 + strCloseHeader_837);
        }
        
        return true;
    }
    
    public string GenerateHeader_837(DataRow drHeaderInformation837)
    {
        string ISA00 = "ISA";
        string ISA01 = SetLength(drHeaderInformation837["AuthInfoQL"].ToString(), 2);
        string ISA02 = SetLength(drHeaderInformation837["AuthInfo"].ToString(), 10);
        if (!string.IsNullOrEmpty(ISA02)) ISA02 = ISA02.PadLeft(10);
        
        string ISA03 = SetLength(drHeaderInformation837["SecurityInfoQL"].ToString(), 2);
        string ISA04 = SetLength(drHeaderInformation837["SecurityInfo"].ToString(), 10);
        if (!string.IsNullOrEmpty(ISA04)) ISA04 = ISA04.PadLeft(10);
        
        string ISA05 = SetLength(drHeaderInformation837["InterSenderQL"].ToString(), 2);
        string ISA06 = SetLength(drHeaderInformation837["InterSenderId"].ToString(), 15);
        string ISA07 = SetLength(drHeaderInformation837["InterReceiverQL"].ToString(), 2);
        string ISA08 = SetLength(drHeaderInformation837["InterReceiverId"].ToString(), 10);
        string ISA09 = GetDateTimeNumber("YYMMDD");
        string ISA10 = GetDateTimeNumber("HHMM");
        string ISA11 = "^";
        string ISA12 = "00501";
        ISA13 = GetDateTimeNumber("YMMDDHHMM"); // Control Number
        string ISA14 = "1";
        string ISA15 = drHeaderInformation837["TestOrp"].ToString();

        string GS00 = "GS";
        string GS01 = "HC";
        string GS02 = SetLength(drHeaderInformation837["GSSenderCode"].ToString(), 15);
        string GS03 = SetLength(drHeaderInformation837["GSReceiverCode"].ToString(), 15);
        string GS04 = GetDateTimeNumber("CCYYMMDD");
        string GS05 = GetDateTimeNumber("HHMM");
        GS06 = GetDateTimeNumber("HHMMSS");
        string GS07 = "X";
        string GS08 = "005010X222";

        string ISAStart = ISA00 + "*" + ISA01 + "*" + ISA02 + "*" + ISA03 + "*" + ISA04 + "*" + ISA05 + "*" + ISA06 + "*" + ISA07 + "*" + ISA08 + "*" + ISA09 + "*" + ISA10 + "*" + ISA11 + "*" + ISA12 + "*" + ISA13 + "*" + ISA14 + "*" + ISA15 + "*:";
        ISAStart = ISAStart.TrimEnd('*') + "~";
        segmentsCount++;

        string GSStart = GS00 + "*" + GS01 + "*" + GS02 + "*" + GS03 + "*" + GS04 + "*" + GS05 + "*" + GS06 + "*" + GS07 + "*" + GS08;
        GSStart = GSStart.TrimEnd('*') + "~";
        segmentsCount++;
        GSCount++;
        
        return ISAStart + GSStart;
    }
    
    public string GenerateClaimInformation_837(DataRow drHeaderInformation837, DataTable dtClaimInformation837)
    {
        string strSTMain = "";
        string strSTBHTSenderReceiver = "";
        string strBillingProvider = "";
        string strSubscriber = "";
        string strPatient = "";
        string strClaim = "";
        string strProcedures = "";
        
        string billingOldNPI = "";
        string billingNPI = "";

        long SubscriberOldId = 0;
        long SubscriberId = 0;
        
        long PatientOldId = 0;
        long PatientId = 0;

        long ClaimOldNo = 0;
        long ClaimNo = 0;

        //strSTBHTSenderReceiver += GenerateSTBHTSenderReceiver(drHeaderInformation837);
        //strSTMain += strSTBHTSenderReceiver;
        
        for (int i = 0; i < dtClaimInformation837.Rows.Count; i++)
        {
            billingNPI = dtClaimInformation837.Rows[i]["BillingNPI"].ToString();
            if (billingOldNPI != billingNPI)
            {
                if (strSTBHTSenderReceiver != "")
                {
                    strSTMain += CloseST();
                }

                strSTBHTSenderReceiver = GenerateSTBHTSenderReceiver(drHeaderInformation837);
                strSTMain += strSTBHTSenderReceiver;

                strBillingProvider = GenerateBillingProvider(dtClaimInformation837.Rows[i]);
                strSTMain += strBillingProvider;
            }
            
            billingOldNPI = billingNPI;
            
            
            SubscriberId = long.Parse(dtClaimInformation837.Rows[i]["SubscriberId"].ToString());
            if (SubscriberOldId != SubscriberId)
            {
                strSubscriber = GenerateSubscriber(dtClaimInformation837.Rows[i]);
                strSTMain += strSubscriber;
            }

            if (SubscriberId == 0)
            {
                strSubscriber = GenerateSubscriber(dtClaimInformation837.Rows[i]);
                strSTMain += strSubscriber;
            }

            SubscriberOldId = SubscriberId;
            
            PatientId = long.Parse(dtClaimInformation837.Rows[i]["PatientId"].ToString());
            if (PatientOldId != PatientId)
            {
                if (IndividualRelationshipCode != "18")
                {
                    strPatient = GeneratePatient(dtClaimInformation837.Rows[i]);
                    strSTMain += strPatient;
                }
            }
            PatientOldId = PatientId;
            
            ClaimNo = long.Parse(dtClaimInformation837.Rows[i]["ClaimNo"].ToString());
            if (ClaimOldNo != ClaimNo)
            {
                strClaim = GenerateClaimInfo(dtClaimInformation837.Rows[i]);
                strSTMain += strClaim;
                
                strProcedures = GenerateProcedureInforamation_837(ClaimNo);
                strSTMain += strProcedures;
            }
            ClaimOldNo = ClaimNo;
        }

        if (strSTBHTSenderReceiver != "")
        {
            strSTMain += CloseST();
        }

        return strSTMain;
    }
    
    public string GenerateSTBHTSenderReceiver(DataRow drHeaderInformation837)
    {
        string ST00 = "ST";
        string ST01 = "837";
        ST02 = GetDateTimeNumber("HHMMSSMS");  //Control Number ST
        string ST03 = "005010X222";

        string ST = ST00 + "*" + ST01 + "*" + ST02 + "*" + ST03;
        ST = ST.TrimEnd('*') + "~";
        segmentsCount++;
        STCount++;

        string BHT00 = "BHT";
        string BHT01 = "0019";
        string BHT02 = "00";
        string BHT03 = GetDateTimeNumber("HHMMSSMS");
        string BHT04 = GetDateTimeNumber("CCYYMMDD");
        string BHT05 = GetDateTimeNumber("HHMM");
        string BHT06 = "CH";

        string BHT = BHT00 + "*" + BHT01 + "*" + BHT02 + "*" + BHT03 + "*" + BHT04 + "*" + BHT05 + "*" + BHT06;
        BHT = BHT.TrimEnd('*') + "~";
        segmentsCount++;

        string NM100_Sender = "NM1";
        string NM101_Sender = "41";
        string NM102_Sender = drHeaderInformation837["SenderQL"].ToString();
        string NM103_Sender = drHeaderInformation837["SenderName"].ToString();
        string NM104_Sender = "";
        string NM105_Sender = "";
        string NM106_Sender = "";
        string NM107_Sender = "";
        string NM108_Sender = "46";
        string NM109_Sender = drHeaderInformation837["SenderName"].ToString();

        string NM1_Sender = NM100_Sender + "*" + NM101_Sender + "*" + NM102_Sender + "*" + NM103_Sender + "*" + NM104_Sender + "*" + NM105_Sender + "*" + NM106_Sender + "*" + NM107_Sender + "*" + NM108_Sender + "*" + NM109_Sender;
        NM1_Sender = NM1_Sender.TrimEnd('*') + "~";
        segmentsCount++;

        string PER00_Sender = "PER";
        string PER01_Sender = "IC";
        string PER02_Sender = drHeaderInformation837["SenderContactName"].ToString();

        string SenderPhone = drHeaderInformation837["SenderPhone"].ToString();
        string PER03_Sender = "";
        string PER04_Sender = "";

        if (!string.IsNullOrEmpty(SenderPhone))
        {
            PER03_Sender = "TE";
            PER04_Sender = SenderPhone;
        }

        string SenderPhoneEx = drHeaderInformation837["SenderPhoneExt"].ToString();
        string PER05_Sender = "";
        string PER06_Sender = "";

        if (!string.IsNullOrEmpty(SenderPhoneEx))
        {
            PER05_Sender = "EX";
            PER06_Sender = SenderPhoneEx;
        }

        string PER_Sender = PER00_Sender + "*" + PER01_Sender + "*" + PER02_Sender + "*" + PER03_Sender + "*" + PER04_Sender + "*" + PER05_Sender + "*" + PER06_Sender;
        PER_Sender = PER_Sender.TrimEnd('*') + "~";
        segmentsCount++;

        string NM100_Receiver = "NM1";
        string NM101_Receiver = "";
        string NM102_Receiver = drHeaderInformation837["ReceiverQL"].ToString();
        string NM103_Receiver = drHeaderInformation837["ReceiverName"].ToString();
        string NM104_Receiver = "";
        string NM105_Receiver = "";
        string NM106_Receiver = "";
        string NM107_Receiver = "";
        string NM108_Receiver = "46";
        string NM109_Receiver = drHeaderInformation837["ReceiverCode"].ToString();
        
        string NM1_Receiver = NM100_Receiver + "*" + NM101_Receiver + "*" + NM102_Receiver + "*" + NM103_Receiver + "*" + NM104_Receiver + "*" + NM105_Receiver + "*" + NM106_Receiver + "*" + NM107_Receiver + "*" + NM108_Receiver + "*" + NM109_Receiver;
        NM1_Receiver = NM1_Receiver.TrimEnd('*') + "~";
        segmentsCount++;
        
        return ST + BHT + NM1_Sender + PER_Sender + NM1_Receiver;
    }
    
    public string CloseST()
    {
        segmentsCount++;

        string SE00 = "SE";
        string SE01 = segmentsCount.ToString();
        string SE02 = ST02;

        string SE = SE00 + "*" + SE01 + "*" + SE02;
        SE = SE.TrimEnd('*') + "~";

        ResetCounters();

        return SE;
    }
    
    public string GenerateBillingProvider(DataRow drClaimInformation837)
    {
        HL01_BillingProvider = ++HL_ID;

        string HL00 = "HL";
        string HL01 = HL01_BillingProvider.ToString();
        string HL02 = "";
        string HL03 = "20";
        string HL04 = "1";
        
        string HL = HL00 + "*" + HL01 + "*" + HL02 + "*" + HL03 + "*" + HL04;
        HL = HL.TrimEnd('*') + "~";
        segmentsCount++;
        
        string PRV00 = "PRV";
        string PRV01 = "BI";
        string PRV02 = "PXC";
        string PRV03 = drClaimInformation837["BillingProviderTaxonomy"].ToString();
        
        string PRV = PRV00 + "*" + PRV01 + "*" + PRV02 + "*" + PRV03;
        PRV = PRV.TrimEnd('*') + "~";
        segmentsCount++;
        
        string NM100 = "NM1";
        string NM101 = "85";
        string NM102 = "1";
        string NM103 = drClaimInformation837["BillingLName"].ToString();
        string NM104 = drClaimInformation837["BillingFName"].ToString();
        string NM105 = "";
        string NM106 = "";
        string NM107 = "";
        string NM108 = "XX";
        string NM109 = drClaimInformation837["BillingNPI"].ToString();
        
        string NM1 = NM100 + "*" + NM101 + "*" + NM102 + "*" + NM103 + "*" + NM104 + "*" + NM105 + "*" + NM106 + "*" + NM107 + "*" + NM108 + "*" + NM109;
        NM1 = NM1.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string N300 = "N3";
        string N301 = drClaimInformation837["BillingStreet"].ToString();
        
        string N3 = N300 + "*" + N301;
        N3 = N3.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string N400 = "N4";
        string N401 = drClaimInformation837["BillingCity"].ToString();
        string N402 = drClaimInformation837["BillingState"].ToString();
        string N403 = drClaimInformation837["BillingZip"].ToString();
        
        string N4 = N400 + "*" + N401 + "*" + N402 + "*" + N403;
        N4 = N4.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string REF00 = "REF";
        string REF01 = "EI";
        string REF02 = drClaimInformation837["BillingTaxId"].ToString();
        
        string REF = REF00 + "*" + REF01 + "*" + REF02;
        REF = REF.TrimEnd('*') + "~";
        segmentsCount++;
        
        return HL + PRV + NM1 + N3 + N4 + REF;
    }
    
    public string GenerateSubscriber(DataRow drClaimInformation837)
    {
        HL01_Subscriber = ++HL_ID;
        string SubscriberRelationship = drClaimInformation837["SubscriberRelationship"].ToString();
        string hlIsRepeat = "1";
        

        if (SubscriberRelationship == "Self")
        {
            hlIsRepeat = "0";
            IndividualRelationshipCode = "18";
        }
        else if (SubscriberRelationship == "Children")
        {
            IndividualRelationshipCode = "19";
        }
        else if (SubscriberRelationship == "Spouse")
        {
            IndividualRelationshipCode = "01";
        }
        else if (SubscriberRelationship == "Other")
        {
            IndividualRelationshipCode = "G8";
        }
        

        string HL00 = "HL";
        string HL01 = HL01_Subscriber.ToString();
        string HL02 = HL01_BillingProvider.ToString();
        string HL03 = "22";
        string HL04 = hlIsRepeat;
        
        string HL = HL00 + "*" + HL01 + "*" + HL02 + "*" + HL03 + "*" + HL04;
        HL = HL.TrimEnd('*') + "~";
        segmentsCount++;


        

        string SBR00 = "SBR";
        string SBR01 = "P";
        string SBR02 = IndividualRelationshipCode;
        string SBR03 = drClaimInformation837["SubscriberGroupCode"].ToString();
        string SBR04 = drClaimInformation837["SubscriberGroupName"].ToString();
        string SBR05 = "";
        string SBR06 = "";
        string SBR07 = "";
        string SBR08 = "";
        string SBR09 = "CI";

        string SBR = SBR00 + "*" + SBR01 + "*" + SBR02 + "*" + SBR03 + "*" + SBR04 + "*" + SBR05 + "*" + SBR06 + "*" + SBR07 + "*" + SBR08 + "*" + SBR09;
        SBR = SBR.TrimEnd('*') + "~";
        segmentsCount++;


        string NM100 = "NM1";
        string NM101 = "IL";
        string NM102 = "1";
        string NM103 = drClaimInformation837["SubscriberLName"].ToString();
        string NM104 = drClaimInformation837["SubscriberFName"].ToString();
        string NM105 = "";
        string NM106 = "";
        string NM107 = "";
        string NM108 = "MI";
        string NM109 = drClaimInformation837["SubscriberPolicyNumber"].ToString();

        string NM1 = NM100 + "*" + NM101 + "*" + NM102 + "*" + NM103 + "*" + NM104 + "*" + NM105 + "*" + NM106 + "*" + NM107 + "*" + NM108 + "*" + NM109;
        NM1 = NM1.TrimEnd('*') + "~";
        segmentsCount++;


        string N300 = "N3";
        string N301 = drClaimInformation837["SubscriberStreet"].ToString();

        string N3 = N300 + "*" + N301;
        N3 = N3.TrimEnd('*') + "~";
        segmentsCount++;


        string N400 = "N4";
        string N401 = drClaimInformation837["SubscriberCity"].ToString().Trim();
        string N402 = drClaimInformation837["SubscriberState"].ToString().Trim();
        string N403 = drClaimInformation837["SubscriberZip"].ToString();

        string N4 = N400 + "*" + N401 + "*" + N402 + "*" + N403;
        N4 = N4.TrimEnd('*') + "~";
        segmentsCount++;


        string subYY = "";
        string subMM = "";
        string subDD = "";
        string subDOB = drClaimInformation837["SubscriberBirthDate"].ToString();
        if (!string.IsNullOrEmpty(subDOB))
        {
            DateTime dtDOB = Convert.ToDateTime(subDOB);
            subYY = dtDOB.Year.ToString();
            subMM = dtDOB.Month.ToString();
            subDD = dtDOB.Day.ToString();
            if (subMM.Length == 1) subMM = "0" + subMM;
            if (subDD.Length == 1) subDD = "0" + subDD;
        }


        string DMG00 = "DMG";
        string DMG01 = "D8";
        string DMG02 = subYY + subMM + subDD;
        string DMG03 = drClaimInformation837["SubscriberGender"].ToString();
        if (DMG03 == "Male") DMG03 = "M";
        else DMG03 = "F";

        string DMG = DMG00 + "*" + DMG01 + "*" + DMG02 + "*" + DMG03;
        DMG = DMG.TrimEnd('*') + "~";
        segmentsCount++;


        string NM100_P = "NM1";
        string NM101_P = "PR";
        string NM102_P = "2";
        string NM103_P = drClaimInformation837["PayerName"].ToString();
        string NM104_P = "";
        string NM105_P = "";
        string NM106_P = "";
        string NM107_P = "";
        string NM108_P = "PI";
        string NM109_P = drClaimInformation837["PayerId"].ToString();

        string NM1_P = NM100_P + "*" + NM101_P + "*" + NM102_P + "*" + NM103_P + "*" + NM104_P + "*" + NM105_P + "*" + NM106_P + "*" + NM107_P + "*" + NM108_P + "*" + NM109_P;
        NM1_P = NM1_P.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string N400_P = "N4";
        string N401_P = drClaimInformation837["PayerCity"].ToString();
        string N402_P = drClaimInformation837["PayerState"].ToString();
        string N403_P = drClaimInformation837["PayerZip"].ToString();
        
        string N4_P = N400_P + "*" + N401_P + "*" + N402_P + "*" + N403_P;
        N4_P = N4_P.TrimEnd('*') + "~";
        segmentsCount++;
        
        return HL + SBR + NM1 + N3 + N4 + DMG + NM1_P + N4_P;
    }

    public string GeneratePatient(DataRow drClaimInformation837)
    {
        string SubscriberRelationship = drClaimInformation837["SubscriberRelationship"].ToString();
        if (SubscriberRelationship == "Children")
        {
            SubscriberRelationship = "19";
        }
        else if (SubscriberRelationship == "Spouse")
        {
            SubscriberRelationship = "01";
        }
        else if (SubscriberRelationship == "Other")
        {
            SubscriberRelationship = "G8";
        }


        string HL00 = "HL";
        string HL01 = (++HL_ID).ToString();
        string HL02 = HL01_Subscriber.ToString();
        string HL03 = "23";
        string HL04 = "0";

        string HL = HL00 + "*" + HL01 + "*" + HL02 + "*" + HL03 + "*" + HL04;
        HL = HL.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string PAT00 = "PAT";
        string PAT01 = SubscriberRelationship;
        
        string PAT = PAT00 + "*" + PAT01;
        PAT = PAT.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string NM100 = "NM1";
        string NM101 = "QC";
        string NM102 = "1";
        string NM103 = drClaimInformation837["PatientLName"].ToString();
        string NM104 = drClaimInformation837["PatientFName"].ToString();

        string NM1 = NM100 + "*" + NM101 + "*" + NM102 + "*" + NM103 + "*" + NM104;
        NM1 = NM1.TrimEnd('*') + "~";
        segmentsCount++;


        string N300 = "N3";
        string N301 = drClaimInformation837["PatientStreet"].ToString();

        string N3 = N300 + "*" + N301;
        N3 = N3.TrimEnd('*') + "~";
        segmentsCount++;


        string N400 = "N4";
        string N401 = drClaimInformation837["PatientCity"].ToString();
        string N402 = drClaimInformation837["PatientState"].ToString();
        string N403 = drClaimInformation837["PatientZip"].ToString();

        string N4 = N400 + "*" + N401 + "*" + N402 + "*" + N403;
        N4 = N4.TrimEnd('*') + "~";
        segmentsCount++;


        string patYY = "";
        string patMM = "";
        string patDD = "";
        string patDOB = drClaimInformation837["PatientDOB"].ToString();
        if (!string.IsNullOrEmpty(patDOB))
        {
            DateTime dtDOB = Convert.ToDateTime(patDOB);
            patYY = dtDOB.Year.ToString();
            patMM = dtDOB.Month.ToString();
            patDD = dtDOB.Day.ToString();
            if (patMM.Length == 1) patMM = "0" + patMM;
            if (patDD.Length == 1) patDD = "0" + patDD;
        }


        string DMG00 = "DMG";
        string DMG01 = "D8";
        string DMG02 = patYY + patMM + patDD;
        string DMG03 = drClaimInformation837["PatientGender"].ToString();
        if (DMG03 == "Male") DMG03 = "M";
        else DMG03 = "F";

        string DMG = DMG00 + "*" + DMG01 + "*" + DMG02 + "*" + DMG03;
        DMG = DMG.TrimEnd('*') + "~";
        segmentsCount++;



        return HL + PAT + NM1 + N3 + N4 + DMG;
    }

    public string GenerateClaimInfo(DataRow drClaimInformation837)
    {
        ProcedureCount = 0;

        string CLM00 = "CLM";
        string CLM01 = GetDateTimeNumber("HHMMSSMS");
        string CLM02 = drClaimInformation837["ClaimCharges"].ToString().Split('.')[0];
        string CLM03 = "";
        string CLM04 = "";
        string CLM05_1 = drClaimInformation837["POS"].ToString();
        string CLM05_2 = "B";
        string CLM05_3 = "1";
        string CLM06 = "Y";
        string CLM07 = "A";
        string CLM08 = "Y";
        string CLM09 = "I";
        
        string CLM = CLM00 + "*" + CLM01 + "*" + CLM02 + "*" + CLM03 + "*" + CLM04 + "*" + CLM05_1 + "*" + CLM05_2 + "*" + CLM05_3 + "*" + CLM06 + "*" + CLM07 + "*" + CLM08 + "*" + CLM09;
        CLM = CLM.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        string REF00_Referral = "REF";
        string REF01_Referral = "9F";
        string REF02_Referral = drClaimInformation837["ClaimReferralNumber"].ToString();

        string REF_Referral = REF00_Referral + "*" + REF01_Referral + "*" + REF02_Referral;
        REF_Referral = REF_Referral.TrimEnd('*') + "~";
        segmentsCount++;


        string REF00_Prior = "REF";
        string REF01_Prior = "G1";
        string REF02_Prior = drClaimInformation837["ClaimAuthorizationNumber"].ToString();

        string REF_Prior = REF00_Prior + "*" + REF01_Prior + "*" + REF02_Prior;
        REF_Prior = REF_Prior.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        
        string HI01_2_Dx = drClaimInformation837["Dx1"].ToString();
        string HI02_2_Dx = drClaimInformation837["Dx2"].ToString();
        string HI03_2_Dx = drClaimInformation837["Dx3"].ToString();
        string HI04_2_Dx = drClaimInformation837["Dx4"].ToString();
        string HI05_2_Dx = drClaimInformation837["Dx5"].ToString();
        string HI06_2_Dx = drClaimInformation837["Dx6"].ToString();
        string HI07_2_Dx = drClaimInformation837["Dx7"].ToString();
        string HI08_2_Dx = drClaimInformation837["Dx8"].ToString();
        
        string HI00_Dx = "HI";
        string HI01_Dx = "";
        string HI02_Dx = "";
        string HI03_Dx = "";
        string HI04_Dx = "";
        string HI05_Dx = "";
        string HI06_Dx = "";
        string HI07_Dx = "";
        string HI08_Dx = "";
        if (HI01_2_Dx != "")
        {
            if (HI01_2_Dx.Contains('.'))
            {
                HI01_2_Dx = HI01_2_Dx.Split('.')[0];
            }
            HI01_Dx = "BK:" + HI01_2_Dx;
        }

        if (HI02_2_Dx != "")
        {
            if (HI02_2_Dx.Contains('.'))
            {
                HI02_2_Dx = HI02_2_Dx.Split('.')[0];
            }
            HI02_Dx = "BF:" + HI02_2_Dx;
        }

        if (HI03_2_Dx != "")
        {
            if (HI03_2_Dx.Contains('.'))
            {
                HI03_2_Dx = HI03_2_Dx.Split('.')[0];
            }
            HI03_Dx = "BF:" + HI03_2_Dx;
        }

        if (HI04_2_Dx != "")
        {
            if (HI04_2_Dx.Contains('.'))
            {
                HI04_2_Dx = HI04_2_Dx.Split('.')[0];
            }
            HI04_Dx = "BF:" + HI04_2_Dx;
        }

        if (HI05_2_Dx != "")
        {
            if (HI05_2_Dx.Contains('.'))
            {
                HI05_2_Dx = HI05_2_Dx.Split('.')[0];
            }
            HI05_Dx = "BF:" + HI05_2_Dx;
        }

        if (HI06_2_Dx != "")
        {
            if (HI06_2_Dx.Contains('.'))
            {
                HI06_2_Dx = HI06_2_Dx.Split('.')[0];
            }
            HI06_Dx = "BF:" + HI06_2_Dx;
        }

        if (HI07_2_Dx != "")
        {
            if (HI07_2_Dx.Contains('.'))
            {
                HI07_2_Dx = HI07_2_Dx.Split('.')[0];
            }
            HI07_Dx = "BF:" + HI07_2_Dx;
        }

        if (HI08_2_Dx != "")
        {
            if (HI08_2_Dx.Contains('.'))
            {
                HI08_2_Dx = HI08_2_Dx.Split('.')[0];
            }
            HI08_Dx = "BF:" + HI08_2_Dx;
        }
        

        string HI_Dx = HI00_Dx + "*" + HI01_Dx + "*" + HI02_Dx + "*" + HI03_Dx + "*" + HI04_Dx + "*" + HI05_Dx + "*" + HI06_Dx + "*" + HI07_Dx + "*" + HI08_Dx;
        HI_Dx = HI_Dx.TrimEnd('*') + "~";
        segmentsCount++;
        
        
        return CLM + REF_Referral + REF_Prior + HI_Dx;
    }
    
    public string GenerateProcedureInforamation_837(long ClaimId)
    {
        string strProcedres = "";

        HeaderInformation837DB objHeaderInformation837DB = new HeaderInformation837DB();
        DataTable dtClaimChargesInformation837DB = objHeaderInformation837DB.GetInformation_837_ClaimCharges(ClaimId);

        for (int i = 0; i < dtClaimChargesInformation837DB.Rows.Count; i++)
        {
            string LX00 = "LX";
            string LX01 = (i+1).ToString();

            string LX = LX00 + "*" + LX01;
            LX = LX.TrimEnd('*') + "~";
            segmentsCount++;


            string Modifier1 = dtClaimChargesInformation837DB.Rows[i]["Modifier1"].ToString();
            string Modifier2 = dtClaimChargesInformation837DB.Rows[i]["Modifier2"].ToString();
            string Modifier3 = dtClaimChargesInformation837DB.Rows[i]["Modifier3"].ToString();
            string Modifier4 = dtClaimChargesInformation837DB.Rows[i]["Modifier4"].ToString();

            string SV100 = "SV1";
            string SV101 = "HC:" + dtClaimChargesInformation837DB.Rows[i]["CPTCode"].ToString();
            if (Modifier1 != "") SV101 = SV101 + ":" + Modifier1;
            if (Modifier2 != "") SV101 = SV101 + ":" + Modifier2;
            if (Modifier3 != "") SV101 = SV101 + ":" + Modifier3;
            if (Modifier4 != "") SV101 = SV101 + ":" + Modifier4;
            
            string charges = dtClaimChargesInformation837DB.Rows[i]["TotalCharges"].ToString();
            
            if (!string.IsNullOrEmpty(charges))
            {
                charges = dtClaimChargesInformation837DB.Rows[i]["TotalCharges"].ToString().Split('.')[0];
            }
            else
            {
                charges = "0";
            }

            string SV102 = charges;
            string SV103 = "UN";
            string SV104 = dtClaimChargesInformation837DB.Rows[i]["ServiceUnits"].ToString();

            string DXPointer1 = dtClaimChargesInformation837DB.Rows[i]["DXPointer1"].ToString();
            string DXPointer2 = dtClaimChargesInformation837DB.Rows[i]["DXPointer2"].ToString();
            string DXPointer3 = dtClaimChargesInformation837DB.Rows[i]["DXPointer3"].ToString();
            string DXPointer4 = dtClaimChargesInformation837DB.Rows[i]["DXPointer4"].ToString();
            string DXPointer5 = dtClaimChargesInformation837DB.Rows[i]["DXPointer5"].ToString();
            string DXPointer6 = dtClaimChargesInformation837DB.Rows[i]["DXPointer6"].ToString();
            string DXPointer7 = dtClaimChargesInformation837DB.Rows[i]["DXPointer7"].ToString();
            string DXPointer8 = dtClaimChargesInformation837DB.Rows[i]["DXPointer8"].ToString();

            string SV105 = "";
            string SV106 = "";
            string SV107 = "";
            if (DXPointer1 != "0") SV107 = SV107 + ":" + DXPointer1;
            if (DXPointer2 != "0") SV107 = SV107 + ":" + DXPointer2;
            if (DXPointer3 != "0") SV107 = SV107 + ":" + DXPointer3;
            if (DXPointer4 != "0") SV107 = SV107 + ":" + DXPointer4;
            if (DXPointer5 != "0") SV107 = SV107 + ":" + DXPointer5;
            if (DXPointer6 != "0") SV107 = SV107 + ":" + DXPointer6;
            if (DXPointer7 != "0") SV107 = SV107 + ":" + DXPointer7;
            if (DXPointer8 != "0") SV107 = SV107 + ":" + DXPointer8;

            string SV1 = SV100 + "*" + SV101 + "*" + SV102 + "*" + SV103 + "*" + SV104 + "*" + SV105 + "*" + SV106 + "*" + SV107;
            SV1 = SV1.TrimEnd('*') + "~";
            segmentsCount++;


            string DTP00 = "DTP";
            string DTP01 = "472";
            string DTP02 = "D8";

            string SrvYY = "";
            string SrvMM = "";
            string SrvDD = "";
            string ServiceDate = dtClaimChargesInformation837DB.Rows[i]["ServiceDate"].ToString();
            if (!string.IsNullOrEmpty(ServiceDate))
            {
                DateTime srvDate = Convert.ToDateTime(ServiceDate);
                SrvYY = srvDate.Year.ToString();
                SrvMM = srvDate.Month.ToString();
                SrvDD = srvDate.Day.ToString();
                if (SrvDD.Length == 1) SrvDD = "0" + SrvDD;
            }
            
            string DTP03 = SrvYY + SrvMM + SrvDD;
            
            string DTP = DTP00 + "*" + DTP01 + "*" + DTP02 + "*" + DTP03;
            DTP = DTP.TrimEnd('*') + "~";
            segmentsCount++;

            strProcedres += LX + SV1 + DTP;
        }



        return strProcedres;
    }
    
    public string CloseHeader_837()
    {
        string GE00 = "GE";
        string GE01 = STCount.ToString();
        string GE02 = GS06;

        string GE = GE00 + "*" + GE01 + "*" + GE02;
        GE = GE.TrimEnd('*') + "~";


        string IEA00 = "IEA";
        string IEA01 = GSCount.ToString();
        string IEA02 = ISA13;
        
        string IEA = IEA00 + "*" + IEA01 + "*" + IEA02;
        IEA = IEA.TrimEnd('*') + "~";

        return GE + IEA;
    }

    public void ResetCounters()
    {
        segmentsCount = 0;
        HL_ID = 0;
    }
    
    public void Save837File(string strGenerateHeader_837)
    {
        string fileName_837 = "837P_EDI" + GetDateTimeNumber("CCYYMMDDHHMMSS") + "_" + ISAIncrement;

        string directory_837 = RootPath + "/837Files";

        if (!Directory.Exists(directory_837))
        {
            Directory.CreateDirectory(directory_837);
        }


        StreamWriter file = new StreamWriter(directory_837 + "/" + fileName_837 + ".txt");
        file.WriteLine(strGenerateHeader_837);

        file.Close();
    }
    
    public string GetDateTimeNumber(string Format)
    {
        string number = "";
        
        string CCYY = currentDateTime.Year.ToString();
        string YY = CCYY.Substring(CCYY.Length - 2, 2);
        char Y = YY[YY.Length - 1];
        
        string MM = currentDateTime.Month.ToString();
        if (MM.Length == 1) MM = "0" + MM;
        
        string DD = currentDateTime.Day.ToString();
        if (DD.Length == 1) DD = "0" + DD;

        char D = DD[DD.Length - 1];
        
        string HH = currentDateTime.Hour.ToString();
        if (HH.Length == 1) HH = "0" + HH;
        
        string Minutes = currentDateTime.Minute.ToString();
        if (Minutes.Length == 1) Minutes = "0" + Minutes;
        
        string SS = currentDateTime.Second.ToString();
        if (SS.Length == 1) SS = "0" + SS;

        string MS = currentDateTime.Millisecond.ToString();
        if (MS.Length == 1) MS = "0" + MS;
        
        switch (Format)
        {
            case "CCYYMMDDHHMMSS":
                {
                    number = CCYY + MM + DD + HH + Minutes + SS;
                    break;
                }
            case "YYMMDD":
                {
                    number = YY + MM + DD;
                    break;
                }
            case "HHMM":
                {
                    number = HH + Minutes;
                    break;
                }
            case "YMMDDHHMM": //Control Number ISA
                {
                    string minutePlusIsaIncrement = (int.Parse(Minutes) + (++ISAIncrement)).ToString();
                    if (minutePlusIsaIncrement.Length == 1) minutePlusIsaIncrement = "0" + minutePlusIsaIncrement;
                    number = Y + MM + DD + HH + minutePlusIsaIncrement;
                    break;
                }
            case "CCYYMMDD":
                {
                    number = CCYY + MM + DD;
                    break;
                }
            case "HHMMSS":
                {
                    number = HH + Minutes + SS;
                    break;
                }
            case "HHMMSSMS":
                {
                    number = HH + Minutes + SS + MS;
                    break;
                }
                
        }
        
        return number.Trim();
    }
    
    public string SetLength(string strObject, int size)
    {
        if (strObject.Length >= size)
        {
            strObject = strObject.Substring(0, size);
        }
        
        return strObject;
    }
}