using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Globalization;

/// <summary>
/// Summary description for EligibilityResponse
/// </summary>
public class EligibilityResponse
{
    public EligibilityResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DataSet _dsEligibilityParsedInfo = new DataSet();
    bool _subscriberFlag = false;
    bool _ebFlag = false;
    bool _lsFlag = false;
    bool _dependentFlag = false;
    string _date = string.Empty;
    string _dateQualifier = string.Empty;
    int _rowNumber = 0;
    public DataSet Parse(string EligibilityResponse)
    {
        DataTable dtPatientInfo = new DataTable();
        dtPatientInfo.Columns.Add("PatientLastName");
        dtPatientInfo.Columns.Add("PatientFirstName");
        dtPatientInfo.Columns.Add("DOB");
        dtPatientInfo.Columns.Add("Gender");
        dtPatientInfo.Columns.Add("Address");
        dtPatientInfo.Columns.Add("CityStateZip");
        dtPatientInfo.Columns.Add("PolicyNumber");
        dtPatientInfo.Columns.Add("Date");
        dtPatientInfo.Columns.Add("DateQualifier");
        _dsEligibilityParsedInfo.Tables.Add(dtPatientInfo);



        DataTable dtBenefitInformation = new DataTable();
        dtBenefitInformation.Columns.Add("RowNumber");
        dtBenefitInformation.Columns.Add("Service");
        dtBenefitInformation.Columns.Add("CoverageLevel");
        dtBenefitInformation.Columns.Add("ServiceType");
        dtBenefitInformation.Columns.Add("InsuranceType");
        dtBenefitInformation.Columns.Add("PlanCoverageDescription");
        dtBenefitInformation.Columns.Add("Time");
        dtBenefitInformation.Columns.Add("Amount");
        dtBenefitInformation.Columns.Add("Quantity");
        dtBenefitInformation.Columns.Add("QuantityQualifier");
        dtBenefitInformation.Columns.Add("Unit");
        dtBenefitInformation.Columns.Add("Date");
        dtBenefitInformation.Columns.Add("DateQualifier");
        dtBenefitInformation.Columns.Add("InPlanNetwork"); // N No,U Unknown,W Not Applicable,Y Yes
        dtBenefitInformation.Columns.Add("Auhorization"); // N No,U Unknown,Y Yes
        dtBenefitInformation.Columns.Add("Message");
        dtBenefitInformation.Columns.Add("LSNameModifier");
        dtBenefitInformation.Columns.Add("LSName");
        dtBenefitInformation.Columns.Add("LSModifier");
        dtBenefitInformation.Columns.Add("LSCode");
        dtBenefitInformation.Columns.Add("LSAddress");
        dtBenefitInformation.Columns.Add("OtherPlanModifier");
        dtBenefitInformation.Columns.Add("OthePlanCode");

        _dsEligibilityParsedInfo.Tables.Add(dtBenefitInformation);

        DataTable dtRejections = new DataTable();
        dtRejections.Columns.Add("RejectionReason");
        dtRejections.Columns.Add("FollowupAction");

        _dsEligibilityParsedInfo.Tables.Add(dtRejections);

        DataTable dtDependentInfo = new DataTable();
        dtDependentInfo.Columns.Add("DependentLastName");
        dtDependentInfo.Columns.Add("DependentFirstName");
        dtDependentInfo.Columns.Add("DependentDOB");
        dtDependentInfo.Columns.Add("DependentGender");
        dtDependentInfo.Columns.Add("DependentAddress");
        dtDependentInfo.Columns.Add("DependentCityStateZip");
        dtDependentInfo.Columns.Add("Date");
        dtDependentInfo.Columns.Add("DateQualifier");
        dtDependentInfo.Columns.Add("RelationshipCode"); //01 Spouse,19 Child,34 Other Adult

        _dsEligibilityParsedInfo.Tables.Add(dtDependentInfo);



        string[] segmentArray = EligibilityResponse.Split('~');

        for (int i = 0; i < segmentArray.Length; i++)
        {
            CallFunction(segmentArray[i]);
        }

        return _dsEligibilityParsedInfo;
    }

    private void CallFunction(string SegmentString)
    {
        string[] Elements = SegmentString.Split('*');
        string SegmentName = Elements[0];

        switch (SegmentName)
        {
            case "ISA":
                ISA(SegmentString);
                break;

            case "GS":
                GS(SegmentString);
                break;

            case "BHT":
                BHT(SegmentString);
                break;

            case "ST":
                ST(SegmentString);
                break;

            case "HL":
                HL(SegmentString);
                break;

            case "NM1":
                NM1(SegmentString);
                break;

            case "N3":
                N3(SegmentString);
                break;

            case "N4":
                N4(SegmentString);
                break;

            case "DMG":
                DMG(SegmentString);
                break;

            case "EB":
                EB(SegmentString);
                break;

            case "DTP":
                DTP(SegmentString);
                break;

            case "MSG":
                MSG(SegmentString);
                break;

            case "LS":
                LS(SegmentString);
                break;

            case "REF":
                REF(SegmentString);
                break;

            case "AAA":
                AAA(SegmentString);
                break;

            default:
                break;
        }
    }

    private void ISA(string ISAString)
    {

    }

    private void GS(string ISAString)
    {

    }

    private void ST(string ISAString)
    {

    }

    private void BHT(string ISAString)
    {

    }

    private void HL(string HLString)
    {
        //string[] Elements = HLString.Split('*');
        //if (Elements[3] == "22")
        //{
        //    if (Elements[4] != "0")
        //    {
        //        _dependentFlag = true;
        //    }
        //}
    }

    private void NM1(string NM1String)
    {
        string[] Elements = NM1String.Split('*');

        if (Elements[1] == "IL")
        {
            _subscriberFlag = true;
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[0].NewRow();
            if (Elements.Length >= 4)
            {
                objDataRow["PatientLastName"] = Elements[3];
            }
            if (Elements.Length >= 5) { 
            objDataRow["PatientFirstName"] = Elements[4];
            }
            if (Elements.Length >= 10)
                objDataRow["PolicyNumber"] = Elements[9];

            _dsEligibilityParsedInfo.Tables[0].Rows.Add(objDataRow);
        }
        if (Elements[1] == "03")
        {
            _subscriberFlag = false;
            _dependentFlag = true;

            if (_dsEligibilityParsedInfo.Tables[3].Rows.Count > 0) { 
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[3].NewRow();
            objDataRow["DependentLastName"] = Elements[3];
            objDataRow["DependentFirstName"] = Elements[4];
          }
        }

        if (_lsFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].Rows[_dsEligibilityParsedInfo.Tables[1].Rows.Count - 1];
            objDataRow["LSNameModifier"] = Elements[1];

            if (Elements.Length >= 4)
                objDataRow["LSName"] = Elements[3];

            if (Elements.Length >= 5)
                objDataRow["LSName"] = objDataRow["LSName"].ToString() == "" ? Elements[3] : " " + Elements[4];

            if (Elements.Length >= 9)
                objDataRow["LSModifier"] = Elements[8];

            if (Elements.Length >= 10)
                objDataRow["LSCode"] = Elements[9];
        }
    }

    private void N3(string N3String)
    {
        string[] Elements = N3String.Split('*');

        if (_subscriberFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[0].Rows[0];
            objDataRow["Address"] = Elements[1];
        }
        if (_dependentFlag == true)
        {
            if (_dsEligibilityParsedInfo.Tables[3].Rows.Count > 0) { 
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[3].Rows[0];
            objDataRow["DependentAddress"] = Elements[1];
            }
        }
        else if (_lsFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].Rows[_dsEligibilityParsedInfo.Tables[1].Rows.Count - 1];
            objDataRow["LSAddress"] = Elements[1];
        }
    }

    private void N4(string N4String)
    {
        string[] Elements = N4String.Split('*');

        if (_subscriberFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[0].Rows[0];
            objDataRow["CityStateZip"] = Elements[1] + ", " + Elements[2] + " " + Elements[3];
        }
        if (_dependentFlag == true)
        {
            if (_dsEligibilityParsedInfo.Tables[3].Rows.Count > 0) { 
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[3].Rows[0];
            objDataRow["CityStateZip"] = Elements[1] + ", " + Elements[2] + " " + Elements[3];
          }
        }
        else if (_lsFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].Rows[_dsEligibilityParsedInfo.Tables[1].Rows.Count - 1];
            objDataRow["LSAddress"] = objDataRow["LSAddress"] + ", " + Elements[1] + ", " + Elements[2] + " " + Elements[3];
        }
    }

    private void DMG(string DMG)
    {
        string[] Elements = DMG.Split('*');

        string gender = "";
        if (Elements.Length >= 4)
        {
            if (Elements[3] == "M")
                gender = "Male";
            else if (Elements[3] == "F")
                gender = "Female";
        }
        if (_subscriberFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[0].Rows[0];
            objDataRow["DOB"] = DateTime.ParseExact(Elements[2], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            objDataRow["Gender"] = gender;
        }
        else if (_dependentFlag)
        {
            if (_dsEligibilityParsedInfo.Tables[3].Rows.Count > 0) { 
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[3].Rows[0];
            objDataRow["DependentDOB"] = DateTime.ParseExact(Elements[2], "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            objDataRow["Gender"] = gender;
           }
        }
    }

    private void INS(string INS)
    {
        if (_dependentFlag == true)
        {
            string[] Elements = INS.Split('*');
            if (_dsEligibilityParsedInfo.Tables[3].Rows.Count > 0)
            {
                DataRow objDataRow = _dsEligibilityParsedInfo.Tables[3].Rows[0];
                objDataRow["RelationshipCode"] = Elements[2];
                //01 Spouse,19 Child,34 Other Adult
            }
        }
    }

    private void EB(string EBString)
    {
        _ebFlag = true;
        _subscriberFlag = false;

        string[] Elements = EBString.Split('*');

        DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].NewRow();

        objDataRow["RowNumber"] = _rowNumber;
        _rowNumber++;

        objDataRow["Service"] = Elements[1];
        if (Elements.Length >= 3)
            objDataRow["CoverageLevel"] = Elements[2];

        if (Elements.Length >= 4)
            objDataRow["ServiceType"] = Elements[3];

        if (Elements.Length >= 5)
            objDataRow["InsuranceType"] = Elements[4];

        if (Elements.Length >= 6)
            objDataRow["PlanCoverageDescription"] = Elements[5];

        if (Elements.Length >= 7)
            objDataRow["Time"] = Elements[6];

        if (Elements.Length >= 8)
            objDataRow["Amount"] = Elements[7];

        if (Elements.Length >= 9)
            objDataRow["Quantity"] = Elements[8];

        if (Elements.Length >= 10)
            objDataRow["QuantityQualifier"] = Elements[9];

        if (Elements.Length >= 11)
            objDataRow["Amount"] += objDataRow["Amount"].ToString() == "" ? Elements[10] : "\n" + Elements[10];

        if (Elements.Length >= 12)
            objDataRow["Auhorization"] = Elements[11];

        if (Elements.Length >= 13)
            objDataRow["InPlanNetwork"] = Elements[12];

        _dsEligibilityParsedInfo.Tables[1].Rows.Add(objDataRow);
    }

    private void MSG(string MSGString)
    {
        string[] Elements = MSGString.Split('*');
        if (_ebFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].Rows[_dsEligibilityParsedInfo.Tables[1].Rows.Count - 1];

            objDataRow["Message"] += objDataRow["Message"].ToString() == "" ? Elements[1] : "\n" + Elements[1];
        }

    }

    private void DTP(string DTPString)
    {
        string[] Elements = DTPString.Split('*');

        if (_subscriberFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[0].Rows[_dsEligibilityParsedInfo.Tables[0].Rows.Count - 1];

            objDataRow["DateQualifier"] += objDataRow["DateQualifier"].ToString() == "" ? Elements[1] : "\n" + Elements[1];

            objDataRow["Date"] += objDataRow["Date"].ToString() == "" ? Elements[3] : "\n" + Elements[3];

        }
        else if (_dependentFlag == true)
        {
            if(_dsEligibilityParsedInfo.Tables[3].Rows.Count > 0){
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[3].Rows[_dsEligibilityParsedInfo.Tables[3].Rows.Count - 1];

            objDataRow["DateQualifier"] += objDataRow["DateQualifier"].ToString() == "" ? Elements[1] : "\n" + Elements[1];

            objDataRow["Date"] += objDataRow["Date"].ToString() == "" ? Elements[3] : "\n" + Elements[3];
           }
        }
        else if (_ebFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].Rows[_dsEligibilityParsedInfo.Tables[1].Rows.Count - 1];

            objDataRow["DateQualifier"] += objDataRow["DateQualifier"].ToString() == "" ? Elements[1] : "\n" + Elements[1];

            objDataRow["Date"] += objDataRow["Date"].ToString() == "" ? Elements[3] : "\n" + Elements[3];
        }

    }

    private void LS(string LSString)
    {
        _lsFlag = true;

    }

    private void HSD(string HSDString)
    {

    }

    private void AAA(string AAAString)
    {
        string[] Elements = AAAString.Split('*');

        DataRow objDataRow = _dsEligibilityParsedInfo.Tables[2].NewRow();

        if (Elements.Length >= 3)
            objDataRow["RejectionReason"] = Elements[3];

        if (Elements.Length >= 4)
            objDataRow["FollowupAction"] = Elements[4];

        _dsEligibilityParsedInfo.Tables[2].Rows.Add(objDataRow);
    }

    private void REF(string REFString)
    {
        string[] Elements = REFString.Split('*');

        if (_ebFlag == true)
        {
            DataRow objDataRow = _dsEligibilityParsedInfo.Tables[1].Rows[_dsEligibilityParsedInfo.Tables[1].Rows.Count - 1];

            objDataRow["OtherPlanModifier"] += Elements[1];
            objDataRow["OthePlanCode"] += Elements[2];
        }

    }
}