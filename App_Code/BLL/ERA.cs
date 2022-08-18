using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for ERA
/// </summary>
public class ERA
{
    ERAMasterDB objERAMasterDB = new ERAMasterDB();
    ERAClaimPaymentsDB objClaimPaymentDB = new ERAClaimPaymentsDB();
    ERAProcedurePaymentsDB objProceudrePaymentsDB = new ERAProcedurePaymentsDB();
    ERAProcedureAdjustmentsDB objProcedureAdjustmentsDB = new ERAProcedureAdjustmentsDB();
    ClaimAdjustmentsDB objClaimAdjustmentDB = new ClaimAdjustmentsDB();
    ERAProcedureRemarkCodesDB objProcedureRemarkCodeDB = new ERAProcedureRemarkCodesDB();
    ProviderAdjustmentsDB objProviderAdjustmentDB = new ProviderAdjustmentsDB();

    ERAMaster objERAMaster = new ERAMaster();

    public ERA()
    {
        //
        // ERA Payment Posting Logic
        // Update claims table, columns {PriSubmissionStatusId, SecSubmissionStatusId, amountpaid, amountdue, adjustment, prmiaryinsurancepayement, secondaryinsurancepayment}
        // Insert value in procedurepayments table
        // Insert value in procedureadjustments table
    }

    public void ProcessERA(string sERAData)
    {
        string[] checkArray = sERAData.Split(new[] { "BPR*" }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < checkArray.Length; i++)
        {
            ProcessCheck("BPR*" + checkArray[i].ToString());
        }





    }

    public void ProcessCheck(string sCheckData)
    {
        //Pull check information
        long ERAMasterId = 0;
        long practiceId = 0;
        string personType = "", sNPI = "", sTaxId = "";

        //Split data in two parts one containing check information other claims information
        string[] claimArray = sCheckData.Split(new[] { "CLP*" }, StringSplitOptions.RemoveEmptyEntries);

        string[] arrProviderAdjustment = sCheckData.Split(new[] { "PLB*" }, StringSplitOptions.RemoveEmptyEntries);

        //Check Information part, pull check level details
        string[] arrCheckDetails = claimArray[0].Split('~');

        for (int i = 0; i < arrCheckDetails.Length; i++)
        {
            string[] data = arrCheckDetails[i].Split('*');

            switch (data[0])
            {
                case "BPR":

                    objERAMaster.TransactionHandlingCode = data[1];

                    string str = data[2];
                    if (isDouble(str))
                        objERAMaster.PaymentAmount = Convert.ToDecimal(data[2]);

                    if (data.Length > 4)
                        objERAMaster.PaymentMethodCode = data[4];

                    if (data.Length > 7)
                        objERAMaster.SenderDFIIdentifier = data[7];

                    if (data.Length > 9)
                        objERAMaster.SenderBankAccountNumber = data[9];

                    if (data.Length > 10)
                        objERAMaster.PayerIdentifier = data[10];

                    if (data.Length > 11)
                        objERAMaster.SupplementalCode = data[11];

                    if (data.Length > 13)
                        objERAMaster.ReceiverDFINumber = data[13];

                    if (data.Length > 14)
                        objERAMaster.ReceiverAccountQualifier = data[14];
                    if (data.Length > 15)
                        objERAMaster.ReceiverAccountNumber = data[15];

                    if (data.Length > 16)
                    {
                        str = data[16];

                        if (str == "" || !isInt(str) || str.Length < 8 || str.Length > 8)
                            objERAMaster.CheckIssueDate = null;
                        else
                            objERAMaster.CheckIssueDate = ConvertToDateTime(str);
                    }

                    break;
                case "TRN":

                    objERAMaster.CheckNumber = data[2];
                    objERAMaster.OrganizationId = data[3];

                    break;
                case "REF":

                    if (data[1] == "EV")
                        objERAMaster.ReceiverIdentifier = data[2];

                    if (personType == "Payee")
                    {
                        if (data[1] == "TJ")
                            sTaxId = data[2].ToString();
                    }

                    break;
                case "N1":

                    if (data[1] == "PR")
                    {

                        objERAMaster.PayerName = data[2];
                        personType = "Payer";
                    }

                    if (data[1] == "PE")
                    {
                        objERAMaster.PayeeName = data[2];
                        objERAMaster.PayeeCodeQualifier = data[3];
                        objERAMaster.PayeeCode = data[4];

                        if (objERAMaster.PayeeCodeQualifier == "XX")
                            sNPI = data[4].ToString();
                        else if (objERAMaster.PayeeCodeQualifier == "FI")
                            sTaxId = data[4].ToString();

                        personType = "Payee";
                    }

                    break;
                case "N3":

                    if (personType == "Payer")
                    {
                        objERAMaster.PayerAddress = data[1];
                    }
                    if (personType == "Payee")
                    {
                        objERAMaster.PayeeAddress = data[1];
                    }

                    break;
                case "N4":

                    if (personType == "Payer")
                    {
                        objERAMaster.PayerCity = data[1];
                        objERAMaster.PayerState = data[2];
                        objERAMaster.ZipCode = data[3];
                    }
                    if (personType == "Payee")
                    {
                        objERAMaster.PayeeCity = data[1];
                        objERAMaster.PayeeState = data[2];
                        objERAMaster.PayeeZip = data[3];
                    }

                    break;
                case "PER":
                    if (data.Length > 2)
                        objERAMaster.PayerContactPerson = data[2];

                    if (data.Length > 3)
                        objERAMaster.CommunicationNumberQualifier1 = data[3];

                    if (data.Length > 4)
                        objERAMaster.CommunicationNumber1 = data[4];

                    if (data.Length > 5)
                        objERAMaster.CommunicationNumberQualifier2 = data[5];

                    if (data.Length > 6)
                        objERAMaster.CommunicationNumber2 = data[6];


                    break;
                case "DTM":

                    if (data[0] == "405")
                    {
                        string dateString = data[2];
                        if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)
                            objERAMaster.ERAGenerationDate = null;
                        else

                            objERAMaster.ERAGenerationDate = ConvertToDateTime(dateString);
                    }

                    break;

            }

        }

        //Verify if check is already imported

        DataTable dtPracticeInfo = objERAMasterDB.GetPracticeID(sNPI, sTaxId);

        if (dtPracticeInfo.Rows.Count > 0)
        {
            objERAMaster.PracticeId = long.Parse(dtPracticeInfo.Rows[0]["PracticeId"].ToString());
        }
        else
        {
            objERAMaster.PracticeId = 0;
        }        


        DataTable dtVerifyCheck = objERAMasterDB.VerifyImportedCheck(objERAMaster.CheckNumber, objERAMaster.CheckIssueDate, objERAMaster.PayerIdentifier);

        if (dtVerifyCheck.Rows.Count == 0)
        {

            //Insert Check information in ERAMaster table

            objERAMaster.PaymentType = "ERA";
            //objERAMaster.CreatedById = CreatedById;
            objERAMaster.CreatedDate = DateTime.Now;
            ERAMasterId = objERAMasterDB.Add(objERAMaster);


            //Pull claims and send claim one by one for processing


            for (int i = 1; i < claimArray.Length; i++)
            {
                ProcessClaim(ERAMasterId, practiceId, "CLP*" + claimArray[i].ToString());
            }

            for (int i = 1; i < arrProviderAdjustment.Length; i++)
            {
                processProviderAdjustments(ERAMasterId, "PLB*" + arrProviderAdjustment[i].ToString());
            }
        }

    }

    public void ProcessClaim(long ERAMasterId, long practiceId, string sClaimData)
    {
        //Pull claim information
        long PatientId = 0;
        long claimId = 0;
        long ERAclaimpaymentId = 0;
        int StatusCode = 0;

        //Create Object for payment Posting
        ProcedurePayments objProcedurPayment = new ProcedurePayments();

        ClaimDB objClaimDb = new ClaimDB();
        EpisodeClaims objclaim = new EpisodeClaims();



        objProcedurPayment.CheckNumber = objERAMaster.CheckNumber;
        objProcedurPayment.CheckDate = objERAMaster.CheckIssueDate;
        objProcedurPayment.ERAMasterId = ERAMasterId;


        ERAClaimPayment objClaimPayments = new ERAClaimPayment();

        //Split data in two parts, first part contains claim level information, after that we have procedures of the claim

        string[] procedureArray = sClaimData.Split(new[] { "SVC*" }, StringSplitOptions.RemoveEmptyEntries);
        string[] arrClaimDetails = procedureArray[0].Split('~');

        //Check Information part, pull check level details

        for (int i = 0; i < arrClaimDetails.Length; i++)
        {
            string[] data = arrClaimDetails[i].Split('*');

            switch (data[0].ToUpper())
            {
                case "CLP":


                    if (data.Length > 1)
                    {


                        //long ln = 0;
                        //if (long.TryParse(data[1].ToString(), out ln))
                        //{
                            objClaimPayments.ClaimNumber = data[1].ToString();
                        //}

                    }
                    if (data.Length > 2)
                        objClaimPayments.ClaimStatusCode = data[2];

                    if (data.Length > 3)
                    {
                        if (isDouble(data[3]))
                            objClaimPayments.ClaimCharges = Convert.ToDecimal(data[3]);

                    }
                    if (data.Length > 4)
                    {
                        if (isDouble(data[4]))
                            objClaimPayments.ClaimPayments = Convert.ToDecimal(data[4]);

                    }

                    if (data.Length > 5)
                    {
                        if (isDouble(data[5]))
                            objClaimPayments.PatientResponsibility = Convert.ToDecimal(data[5]);

                    }

                    if (data.Length > 6)
                        objClaimPayments.InsurancePlanCode = data[6];

                    if (data.Length > 7)
                        objClaimPayments.PayerClaimControlNumber = data[7];

                    break;

                case "NM1":

                    string identifierCode = data[1];
                    if (identifierCode == "QC")  // Patient
                    {
                        objClaimPayments.PatientLastName = data[3];
                        objClaimPayments.PatientFirstName = data[4];
                        objClaimPayments.PatientIdQualifier = data[8];
                        objClaimPayments.PatientIdNumber = data[9];
                    }

                    if (identifierCode == "IL") // Insured
                    {
                        objClaimPayments.InsuredLastName = data[3];
                        objClaimPayments.InsuredFirstName = data[4];
                        objClaimPayments.InsuredIdQualifier = data[8];
                        objClaimPayments.InsuredIdNumber = data[9];
                    }

                    if (identifierCode == "74") // Corrected Patient
                    {
                        objClaimPayments.CorrectedLastName = data[3];
                        objClaimPayments.CorrectedFirstName = data[4];
                        //objClaimPayments.CorrectedIdQualifier = data[8];
                        //objClaimPayments.CorrectedIdCode = data[9];
                    }

                    if (identifierCode == "82") // Service Provider
                    {
                        objClaimPayments.ServiceProviderLastName = data[3];
                        objClaimPayments.ServiceProviderFirstName = data[4];
                        objClaimPayments.ServiceProviderIdQualifier = data[8];
                        objClaimPayments.ServiceProviderIdCode = data[9];
                    }

                    if (identifierCode == "TT") // Cross Over
                    {
                        objClaimPayments.CrossOverPayerName = data[3];
                        objClaimPayments.CrossOverIdQualifier = data[8];
                        objClaimPayments.CrossOverIdCode = data[9];
                    }

                    if (identifierCode == "PR")  // Corrected Payer
                    {
                        objClaimPayments.CorrectedPayerName = data[3];
                        objClaimPayments.CorrectedIdQualifier = data[8];
                        objClaimPayments.CorrectedIdCode = data[9];
                    }

                    if (identifierCode == "GB")
                    {
                        objClaimPayments.OtherSubscriberLastName = data[3];
                        objClaimPayments.OtherSubscriberFirstName = data[4];
                        objClaimPayments.OtherSubscriberIdQualifier = data[8];
                        objClaimPayments.OtherSubscriberId = data[9];
                    }
                    break;

                case "MIA":

                    if (data.Length > 1)
                    {
                        if (isDouble(data[1]))
                            objClaimPayments.CoveredDaysVisitCount = Convert.ToDouble(data[1]);

                    }

                    if (data.Length > 2)
                    {
                        if (isDouble(data[2]))
                            objClaimPayments.PPSOperatingAmount = Convert.ToDecimal(data[2]);

                    }

                    if (data.Length > 3)
                    {
                        if (isDouble(data[3]))
                            objClaimPayments.PsychiatricDays = Convert.ToDouble(data[3]);

                    }

                    break;

                case "DTM":

                    string DTM01 = data[1];
                    if (DTM01 == "232")
                    {
                        string dateString = data[2];
                        if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)
                            objClaimPayments.StatementPeriodStart = null;
                        else
                            objClaimPayments.StatementPeriodStart = ConvertToDateTime(dateString);
                    }

                    if (DTM01 == "233")
                    {
                        string dateString = data[2];
                        if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)

                            objClaimPayments.StatementPeriodEnd = null;
                        else
                            objClaimPayments.StatementPeriodEnd = ConvertToDateTime(dateString);
                    }

                    if (DTM01 == "036")
                    {
                        string dateString = data[2];
                        if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)

                            objClaimPayments.CoverageExpirationDate = null;
                        else
                            objClaimPayments.CoverageExpirationDate = ConvertToDateTime(dateString);
                    }

                    if (DTM01 == "050")
                    {
                        string dateString = data[2];
                        if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)
                            objClaimPayments.ClaimReceiverDate = null;
                        else
                            objClaimPayments.ClaimReceiverDate = ConvertToDateTime(dateString);
                    }
                    break;


                default:
                    break;
            }

        }

        //Insert claim values in database

        objClaimPayments.ERAPaymentsId = ERAMasterId;
        //objClaimPayments.CreatedById = CreatedById;
        objClaimPayments.CreatedDate = DateTime.Now;
        ERAclaimpaymentId = objClaimPaymentDB.Add(objClaimPayments);

        //Set the values for payment posting

        //objProcedurPayment.CheckNumber = objClaimPayments.ClaimNumber.ToString();
        objProcedurPayment.ICN = objClaimPayments.PayerClaimControlNumber;
        objProcedurPayment.ClaimNumber = objClaimPayments.ClaimNumber;

        if (isLong(objClaimPayments.ClaimNumber.ToString()))
            objProcedurPayment.ClaimId = Convert.ToInt64(objClaimPayments.ClaimNumber);

        if (objClaimPayments.ClaimPayments > 0)
        {
            StatusCode = 106;
        }
        else
        {
            StatusCode = 104;
        }

        switch (objClaimPayments.ClaimStatusCode)
        {
            case "1":
                objProcedurPayment.PaymentSource = "PRI";
                break;
            case "2":
                objProcedurPayment.PaymentSource = "SEC";
                break;
            case "3":
                objProcedurPayment.PaymentSource = "OTH";
                break;
            case "4":
                objProcedurPayment.PaymentSource = "PRI";
                StatusCode = 108;
                break;
            case "19":
                objProcedurPayment.PaymentSource = "PRI";
                break;
            case "20":
                objProcedurPayment.PaymentSource = "SEC";
                break;
            case "21":
                objProcedurPayment.PaymentSource = "OTH";
                break;

        }

        //Get Claim level information

        //DataTable dtClaimDetail = objClaimDb.GetClaimDetailsForERA(Convert.ToInt64(objClaimPayments.ClaimNumber));

        //Update claim information {PriSubmissionStatusId, SecSubmissionStatusId, amountpaid, amountdue, adjustment, prmiaryinsurancepayement, secondaryinsurancepayment}

        if (objProcedurPayment.ClaimId !=0 )
        {
            objClaimDb.UpdateClaimStatus(objProcedurPayment.ClaimId, StatusCode, objProcedurPayment.PaymentSource, 0);
        }
        

        //Pull procedures and send procedure one by one for processing       

        for (int i = 1; i < procedureArray.Length; i++)
        {
            ProcessProcedure(PatientId, claimId, ERAclaimpaymentId, "SVC*" + procedureArray[i].ToString(), objProcedurPayment);

        }


    }

    public void ProcessProcedure(long PaitentId, long claimId, long ERAclaimpaymentId, string sProcedureData, ProcedurePayments objProcedurPayment)
    {
        //Pull Procedure Information
        long ERAprocedurepaymentId = 0;

        ERAProcedurePayments objProcedurePayments = new ERAProcedurePayments();


        string[] arrProcedureDetails = sProcedureData.Split('~');

        for (int i = 0; i < arrProcedureDetails.Length; i++)
        {
            string[] data = arrProcedureDetails[i].Split('*');


            switch (data[0])
            {
                case "SVC":
                    char[] sep = data[1].Substring(2, 1).ToCharArray();
                    string[] SVC01Segments = data[1].Split(sep);

                    if (SVC01Segments.Length > 0)
                        objProcedurePayments.ProcedureQualifier = SVC01Segments[0];

                    if (SVC01Segments.Length > 1)
                        objProcedurePayments.ProcedureCode = SVC01Segments[1];

                    if (SVC01Segments.Length > 2)
                        objProcedurePayments.ProcedureModifier1 = SVC01Segments[2];

                    if (SVC01Segments.Length > 3)
                        objProcedurePayments.ProcedureModifier2 = SVC01Segments[3];

                    if (SVC01Segments.Length > 4)
                        objProcedurePayments.ProcedureModifier3 = SVC01Segments[4];

                    if (SVC01Segments.Length > 5)
                        objProcedurePayments.ProcedureModifier4 = SVC01Segments[5];

                    if (data.Length > 2)
                    {
                        if (isDouble(data[2]))
                            objProcedurePayments.ChargedAmount = Convert.ToDecimal(data[2]);

                    }

                    if (data.Length > 3)
                    {
                        if (isDouble(data[3]))
                            objProcedurePayments.PaidAmount = Convert.ToDecimal(data[3]);

                    }

                    if (data.Length > 4)
                        objProcedurePayments.RevenueCode = data[4];


                    if (data.Length > 5)
                    {
                        if (isDouble(data[5]))
                            objProcedurePayments.PaidUnits = Convert.ToDouble(data[5]);

                    }

                    if (data.Length > 6)
                    {
                        string[] SVC06Segments = data[6].Split(sep);

                        if (SVC06Segments.Length > 0)
                            objProcedurePayments.SubmittedProcedureQualifier = SVC06Segments[0];

                        if (SVC06Segments.Length > 1)
                            objProcedurePayments.SubmittedProcedure = SVC06Segments[1];

                        if (SVC06Segments.Length > 2)
                            objProcedurePayments.SubmittedModifier1 = SVC06Segments[2];

                        if (SVC06Segments.Length > 3)
                            objProcedurePayments.SubmittedModifier2 = SVC06Segments[3];

                        if (SVC06Segments.Length > 4)
                            objProcedurePayments.SubmittedModifier3 = SVC06Segments[4];

                        if (SVC06Segments.Length > 5)
                            objProcedurePayments.SubmittedModifier4 = SVC06Segments[5];


                    }


                    if (data.Length > 7)
                        objProcedurePayments.OriginalUnits = data[7];


                    break;

                case "DTM":
                    {
                        string DTM01 = data[1];
                        if (DTM01 == "150" || DTM01 == "472")
                        {
                            string dateString = data[2];
                            if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)
                                objProcedurePayments.ServiceStartDate = null;
                            else
                                objProcedurePayments.ServiceStartDate = ConvertToDateTime(dateString);
                        }


                        if (DTM01 == "151" || DTM01 == "472")
                        {
                            string dateString = data[2];
                            if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)

                                objProcedurePayments.ServiceEndDate = null;
                            else
                                objProcedurePayments.ServiceEndDate = ConvertToDateTime(dateString);
                        }
                        break;
                    }
                case "REF":

                    if (data[1] == "6R")
                        objProcedurePayments.LineItemControlNumber = data[2];
                    break;

                case "AMT":

                    if (isDouble(data[2]))
                        objProcedurePayments.ServiceAllowedAmount = Convert.ToDecimal(data[2]);

                    break;

                default:
                    break;
            }
        }

        //Insert values in ERAProcedurePayments

        objProcedurePayments.ERAClaimPaymentsId = ERAclaimpaymentId;
        //objProcedurePayments.CreatedById = CreatedById;
        objProcedurePayments.CreatedDate = DateTime.Now;
        Int64 ERAprocedurePaymentId = objProceudrePaymentsDB.Add(objProcedurePayments);

        /////////////////////////////////////////////////
        //Set values to post data in procedurepayments//
        ////////////////////////////////////////////////

        objProcedurPayment.PaidAmount = objProcedurePayments.PaidAmount;
        objProcedurPayment.PaidProcedure = objProcedurePayments.ProcedureCode;
        objProcedurPayment.ChargedProcedure = objProcedurePayments.ProcedureCode;

        if (!String.IsNullOrEmpty(objProcedurePayments.SubmittedProcedure))
            objProcedurPayment.ChargedProcedure = objProcedurePayments.SubmittedProcedure;

        objProcedurPayment.LineItemNumber = objProcedurePayments.LineItemControlNumber;
        objProcedurPayment.PaymentMethod = objERAMaster.PaymentMethodCode;
        objProcedurPayment.PaidUnits = objProcedurePayments.PaidUnits;
        objProcedurPayment.CreatedDate = DateTime.Now;


        ProcedurePaymentsDB objProcedurePaymentDb = new ProcedurePaymentsDB();

        long lineControlNumber = 0;
        Int64 procedurePaymentId = 0;

        if (isLong(objProcedurPayment.LineItemNumber))
            lineControlNumber = Convert.ToInt64(objProcedurPayment.LineItemNumber);

        if (objProcedurPayment.ClaimId !=0)
        {
            DataTable dtTable = objProcedurePaymentDb.GetClaimChargesId(objProcedurPayment.ClaimId, lineControlNumber, objProcedurPayment.ChargedProcedure, objProcedurePayments.ServiceStartDate);

            if (dtTable.Rows.Count > 0)
            {
                objProcedurPayment.ClaimChargesId = Convert.ToInt64(dtTable.Rows[0]["ClaimChargesId"].ToString());
                procedurePaymentId = objProcedurePaymentDb.Add(objProcedurPayment);
            }   
            
        }

        //Pull adjustment codes and send to function ProcessProcedureAdjustments for processing
        string[] arrprocedureAdjustmentArray = sProcedureData.Split(new[] { "CAS*" }, StringSplitOptions.RemoveEmptyEntries);


        for (int i = 1; i < arrprocedureAdjustmentArray.Length; i++)
        {
            ProcessProcedureAdjustments(PaitentId, claimId, ERAclaimpaymentId, ERAprocedurePaymentId, procedurePaymentId, "CAS*" + arrprocedureAdjustmentArray[i]);

        }

        //Pull adjustment remark codes and send to function ProcessProcedureRemarkCodes for processing
        string[] arrprocedureAdjustmentRemarkCodes = sProcedureData.Split(new[] { "LQ*" }, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 1; i < arrprocedureAdjustmentRemarkCodes.Length; i++)
        {
            ProcessProcedureRemarkCodes(PaitentId, claimId, ERAclaimpaymentId, ERAprocedurePaymentId, procedurePaymentId, "LQ*" + arrprocedureAdjustmentRemarkCodes[i]);
        }

        //Update procedure level information





    }

    public void ProcessProcedureAdjustments(long PatientId, long claimId, long ERAclaimpaymentId, long ERAprocedurepaymentId, long procedurepaymentsId, string sAdjustmentData)
    {
        string[] arrAdjustmentData = sAdjustmentData.Split('~');
        bool flgProcessed = false;

        ERAProcedureAdjustments objERAProcedureAdjustments = new ERAProcedureAdjustments();

        for (int i = 0; i < arrAdjustmentData.Length; i++)
        {

            string[] data = arrAdjustmentData[i].Split('*');

            switch (data[0].ToUpper())
            {
                case "CAS":
                    flgProcessed = false;

                    if (data.Length > 1)
                    {
                        objERAProcedureAdjustments.AdjustmentGroupCode = data[1];
                        flgProcessed = true;
                    }


                    if (data.Length > 2)
                        objERAProcedureAdjustments.AdjustmentReasonCode = data[2];

                    if (data.Length > 3)
                    {
                        if (isDouble(data[3]))
                            objERAProcedureAdjustments.AdjustmentAmount = Convert.ToDecimal(data[3]);



                    }

                    if (data.Length > 4)
                    {
                        if (isDouble(data[4]))
                            objERAProcedureAdjustments.AdjustedUnits = Convert.ToDouble(data[4]);

                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);

                    }
                    if (data.Length > 5)
                    {
                        objERAProcedureAdjustments.AdjustmentReasonCode = data[5];
                        flgProcessed = true;
                    }

                    if (data.Length > 6)
                    {

                        if (isDouble(data[6]))
                            objERAProcedureAdjustments.AdjustmentAmount = Convert.ToDecimal(data[6]);

                    }

                    if (data.Length > 7)
                    {

                        if (isDouble(data[7]))
                            objERAProcedureAdjustments.AdjustedUnits = Convert.ToDouble(data[7]);

                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);

                    }
                    if (data.Length > 8)
                    {
                        objERAProcedureAdjustments.AdjustmentReasonCode = data[8];
                        flgProcessed = true;
                    }

                    if (data.Length > 9)
                    {

                        if (isDouble(data[9]))
                            objERAProcedureAdjustments.AdjustmentAmount = Convert.ToDecimal(data[9]);

                    }

                    if (data.Length > 10)
                    {
                        if (isDouble(data[10]))
                            objERAProcedureAdjustments.AdjustedUnits = Convert.ToDouble(data[10]);

                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);
                    }

                    if (data.Length > 11)
                    {
                        objERAProcedureAdjustments.AdjustmentReasonCode = data[11];
                        flgProcessed = true;
                    }


                    if (data.Length > 12)
                    {

                        if (isDouble(data[12]))
                            objERAProcedureAdjustments.AdjustmentAmount = Convert.ToDecimal(data[12]);

                    }

                    if (data.Length > 13)
                    {

                        if (isDouble(data[13]))
                            objERAProcedureAdjustments.AdjustedUnits = Convert.ToDouble(data[13]);

                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);

                    }

                    if (data.Length > 14)
                    {
                        objERAProcedureAdjustments.AdjustmentReasonCode = data[14];
                        flgProcessed = true;
                    }


                    if (data.Length > 15)
                    {

                        if (isDouble(data[15]))
                            objERAProcedureAdjustments.AdjustmentAmount = Convert.ToDecimal(data[15]);

                    }

                    if (data.Length > 16)
                    {

                        if (isDouble(data[16]))
                            objERAProcedureAdjustments.AdjustedUnits = Convert.ToDouble(data[16]);

                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);


                    }
                    if (data.Length > 17)
                    {
                        objERAProcedureAdjustments.AdjustmentReasonCode = data[17];
                        flgProcessed = true;
                    }

                    if (data.Length > 10)
                    {

                        if (isDouble(data[10]))
                            objERAProcedureAdjustments.AdjustmentAmount = Convert.ToDecimal(data[18]);

                    }

                    if (data.Length > 19)
                    {

                        if (isDouble(data[19]))
                            objERAProcedureAdjustments.AdjustedUnits = Convert.ToDouble(data[19]);

                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);

                    }

                    if (flgProcessed)
                    {
                        objERAProcedureAdjustments.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureAdjustments.CreatedById = CreatedById;
                        objERAProcedureAdjustments.CreatedDate = DateTime.Now;
                        Int64 procedureAdjustmentId = objProcedureAdjustmentsDB.Add(objERAProcedureAdjustments);
                        flgProcessed = false;

                        ProcedureAdjustments objProcedureAdjustment = new ProcedureAdjustments();
                        ProcedureAdjustmentsDB objProcedureAdjustmentDB = new ProcedureAdjustmentsDB();

                        //Insert values in procedure adjustments

                        objProcedureAdjustment.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureAdjustment.AdjustedAmount = objERAProcedureAdjustments.AdjustmentAmount;
                        objProcedureAdjustment.ReasonCode = objERAProcedureAdjustments.AdjustmentReasonCode;
                        objProcedureAdjustment.GroupCode = objERAProcedureAdjustments.AdjustmentGroupCode;
                        objProcedureAdjustment.CreatedById = 0;
                        objProcedureAdjustment.CreatedDate = DateTime.Now;

                        if (procedurepaymentsId != 0)
                            objProcedureAdjustmentDB.Add(objProcedureAdjustment);
                    }



                    // objProcedureAdjustmentDB.Add(objProcedureAdjustment);



                    break;

            }


        }


    }

    public void ProcessProcedureRemarkCodes(long PatientId, long claimId, long ERAclaimpaymentId, long ERAprocedurepaymentId, long procedurepaymentsId, string sAdjustmentData)
    {
        string[] procedurePaymentRemarkCode = sAdjustmentData.Split('~');         // Procedure Remark Code for ProcedurePaymentId

        for (int varProcedureRemarkCode = 0; varProcedureRemarkCode < procedurePaymentRemarkCode.Length; varProcedureRemarkCode++)
        {
            string[] segments = procedurePaymentRemarkCode[varProcedureRemarkCode].Split('*');
            switch (segments[0].ToUpper())
            {
                case "LQ":
                    {
                        ERAProcedureRemarkCodes objProcedureRemarkCode = new ERAProcedureRemarkCodes();


                        ERAProcedureRemarkCodes objProcedureRemarkCodes = new ERAProcedureRemarkCodes();

                        for (int varLoop = 2; varLoop <= segments.Length; varLoop++)
                        {
                            if (varLoop == 2)
                            {
                                objProcedureRemarkCode.RemarkCodeQualifier = segments[1];
                            }

                            if (varLoop == 3)
                            {
                                objProcedureRemarkCode.RemarkCode = segments[2];
                            }
                        }
                        objProcedureRemarkCode.ERAProcedurePaymentsId = ERAprocedurepaymentId;
                        //objProcedureRemarkCode.CreatedById = CreatedById;
                        objProcedureRemarkCode.CreatedDate = DateTime.Now;
                        objProcedureRemarkCodeDB.Add(objProcedureRemarkCode);

                        objProcedureRemarkCodes.ProcedurePaymentsId = procedurepaymentsId;
                        objProcedureRemarkCodes.RemarkCode = objProcedureRemarkCode.RemarkCode;
                        objProcedureRemarkCodes.RemarkCodeQualifier = objProcedureRemarkCode.RemarkCodeQualifier;
                        objProcedureRemarkCodes.CreatedDate = DateTime.Now;

                        ERAProcedureRemarkCodesDB objProcedureRemarkCodesDB = new ERAProcedureRemarkCodesDB();

                        if (procedurepaymentsId !=0)
                            objProcedureRemarkCodesDB.Add(objProcedureRemarkCodes);

                        break;
                    }
            }
        }

    }

    public void processClaimAdjustments(long ERAMasterId, long practiceId, long claimPaymentsId, long claimId, string claimNo, string sClaimAdjustmentData)
    {

        string[] claismAdjustmentsSegments = sClaimAdjustmentData.Split('~');            // ClaimAdjustments

        for (var varClaimAdjustment = 0; varClaimAdjustment < claismAdjustmentsSegments.Length; varClaimAdjustment++)
        {
            ClaimAdjustments objclaimAdjustment = new ClaimAdjustments();
            string[] claimAdjustmentsSegmentsPart = claismAdjustmentsSegments[varClaimAdjustment].Split('*');
            switch (claimAdjustmentsSegmentsPart[0].ToUpper())
            {
                case "CAS":
                    {
                        for (int varClaimAdjustmentSegment = 2; varClaimAdjustmentSegment <= claimAdjustmentsSegmentsPart.Length; varClaimAdjustmentSegment++)
                        {
                            if (varClaimAdjustmentSegment == 2)
                            {
                                objclaimAdjustment.AdjustmentGroupCode = claimAdjustmentsSegmentsPart[1];
                            }
                            if (varClaimAdjustmentSegment == 3)
                            {
                                objclaimAdjustment.AdjustmentReasonCode = claimAdjustmentsSegmentsPart[2];
                            }
                            if (varClaimAdjustmentSegment == 4)
                            {
                                if (isDouble(claimAdjustmentsSegmentsPart[3]))
                                {
                                    objclaimAdjustment.AdjustmentAmount = Convert.ToDecimal(claimAdjustmentsSegmentsPart[3]);
                                }
                            }

                            if (varClaimAdjustmentSegment == 5)
                            {
                                if (isDouble(claimAdjustmentsSegmentsPart[4]))
                                {
                                    objclaimAdjustment.Quantity = Convert.ToDouble(claimAdjustmentsSegmentsPart[4]);
                                }
                            }

                        }
                        objclaimAdjustment.ClaimAdjustmentsId = claimPaymentsId;
                        objclaimAdjustment.ClaimNumber = claimNo;
                        // objclaimAdjustment.CreatedById = CreatedById;
                        objclaimAdjustment.CreatedDate = DateTime.Now;
                        objClaimAdjustmentDB.Add(objclaimAdjustment);
                        break;
                    }

            }

        }


    }

    public void processProviderAdjustments(long ERAMasterId, string providerAdjustments1)
    {
        string[] providerAdjustments = providerAdjustments1.Split('~');

        for (int varProviderAdjustment = 0; varProviderAdjustment < providerAdjustments.Length; varProviderAdjustment++)
        {

            ProviderAdjustments objProviderAdjustments = new ProviderAdjustments();

            string[] providerAdjustmentsSegments = providerAdjustments[varProviderAdjustment].ToString().Split('*');

            if (providerAdjustmentsSegments[0].ToString() == "PLB")
            {
                if (providerAdjustmentsSegments.Length > 1)
                {
                    objProviderAdjustments.ReferenceId = providerAdjustmentsSegments[1];
                }

                if (providerAdjustmentsSegments.Length > 2)
                {
                    string dateString = providerAdjustmentsSegments[2];

                    if (dateString == "" || !isInt(dateString) || dateString.Length < 8 || dateString.Length > 8)
                        objProviderAdjustments.ProviderFiscalDate = null;
                    else
                        objProviderAdjustments.ProviderFiscalDate = ConvertToDateTime(dateString);
                }

                if (providerAdjustmentsSegments.Length > 3)
                {
                    string[] subSegments = providerAdjustmentsSegments[3].Split(':');
                    if (subSegments.Length > 0)
                        objProviderAdjustments.ProviderAdjustmentReasonCode = subSegments[0];
                    if (subSegments.Length > 1)
                        objProviderAdjustments.ReferenceIdentification = subSegments[1];
                }

                if (providerAdjustmentsSegments.Length > 4)
                {
                    string str = providerAdjustmentsSegments[4];
                    if (isDouble(str))
                    {
                        objProviderAdjustments.ProviderAdjustmentAmount = Convert.ToDecimal(providerAdjustmentsSegments[4]);
                    }

                }

                if (providerAdjustmentsSegments.Length > 5)
                {
                    string[] subSegments = providerAdjustmentsSegments[5].Split(':');
                    for (int varSubSegments = 1; varSubSegments <= subSegments.Length; varSubSegments++)
                    {
                        if (varSubSegments == 1)
                        {
                            objProviderAdjustments.ProviderAdjustmentReasonCode1 = subSegments[0];
                        }
                        if (varSubSegments == 2)
                        {
                            objProviderAdjustments.ReferenceIdentification1 = subSegments[1];
                        }
                    }

                }


                if (providerAdjustmentsSegments.Length > 6)
                {
                    string str = providerAdjustmentsSegments[6];
                    if (isDouble(str))
                    {
                        objProviderAdjustments.ReferenceAdjustmentAmount1 = Convert.ToDecimal(providerAdjustmentsSegments[6]);
                    }
                }

                if (providerAdjustmentsSegments.Length > 7)
                {
                    string[] subSegments = providerAdjustmentsSegments[7].Split(':');
                    for (int varSubSegment = 1; varSubSegment <= subSegments.Length; varSubSegment++)
                    {
                        if (varSubSegment == 1)
                        {
                            objProviderAdjustments.ProviderAdjustmentReasonCode2 = subSegments[0];
                        }
                        if (varSubSegment == 1)
                        {
                            objProviderAdjustments.ReferenceIdentification2 = subSegments[1];
                        }
                    }
                }

                if (providerAdjustmentsSegments.Length > 8)
                {
                    string str = providerAdjustmentsSegments[8];
                    if (isDouble(str))
                    {
                        objProviderAdjustments.ProviderAdjustmentAmount2 = Convert.ToDecimal(providerAdjustmentsSegments[8]);
                    }
                }

                if (providerAdjustmentsSegments.Length > 9)
                {
                    string[] subSegments = providerAdjustmentsSegments[9].Split(':');
                    for (int varSubSegment = 1; varSubSegment <= subSegments.Length; varSubSegment++)
                    {
                        if (varSubSegment == 1)
                        {
                            objProviderAdjustments.ProviderAdjustmentReasonCode3 = subSegments[0];
                        }
                        if (varSubSegment == 2)
                        {
                            objProviderAdjustments.ReferenceIdentification3 = subSegments[1];
                        }
                    }
                }
                if (providerAdjustmentsSegments.Length > 10)
                {
                    string str = providerAdjustmentsSegments[10];
                    if (isDouble(str))
                    {
                        objProviderAdjustments.ProviderAdjustmentAmount3 = Convert.ToDecimal(providerAdjustmentsSegments[10]);
                    }
                }

                //objProviderAdjustments.CreatedById = CreatedById;
                objProviderAdjustments.ERAId = ERAMasterId;
                objProviderAdjustments.CreatedDate = DateTime.Now;
                objProviderAdjustmentDB.Add(objProviderAdjustments);
            }

        }
    }

    public string ConvertToTime(string timeString)
    {
        char[] timeStringSegments = timeString.ToCharArray();
        return timeStringSegments[0].ToString() + timeStringSegments[1].ToString() + ":" + timeStringSegments[2].ToString() + timeStringSegments[3].ToString();

    }

    public DateTime ConvertToDateTime(string dateString)
    {
        string[] format = { "yyyyMMdd" };
        DateTime date;
        if (DateTime.TryParseExact(dateString, format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
        {
            return date;
        }
        else
            return DateTime.Now;
    }

    public bool isDouble(string str)
    {
        double number;
        bool isDouble = double.TryParse(str, out number);
        return isDouble;
    }

    public bool isLong(string str)
    {
        long number;
        bool isLong = long.TryParse(str, out number);
        return isLong;
    }

    public bool isInt(string str)
    {
        int number;
        bool isInt = int.TryParse(str, out number);
        return isInt;
    }



}
