using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ClaimPayments
/// </summary>
public class ERAClaimPayment
{
	public ERAClaimPayment()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    Int64 _ERAClaimPaymentsId;
    Int64 _ERAPaymentsId;
    string _ClaimNumber;
    string _ClaimStatusCode;
    decimal _ClaimCharges;
    decimal _ClaimPayments;
    decimal _PatientResponsibility;
    string _InsurancePlanCode;
    string _PayerClaimControlNumber;
    string _PatientLastName;
    string _PatientFirstName;
    string _PatientIdQualifier;
    string _PatientIdNumber;
    string _InsuredLastName;
    string _InsuredFirstName;
    string _InsuredIdQualifier;
    string _InsuredIdNumber;
    string _CorrectedLastName;
    string _CorrectedFirstName;
    string _CorrectedIdNumber;
    string _ServiceProviderLastName;
    string _ServiceProviderFirstName;
    string _ServiceProviderIdQualifier;
    string _ServiceProviderIdCode;
    string _CrossOverPayerName;
    string _CrossOverIdQualifier;
    string _CrossOverIdCode;
    string _CorrectedPayerName;
    string _CorrectedIdQualifier;
    string _CorrectedIdCode;
    string _OtherSubscriberLastName;
    string _OtherSubscriberFirstName;
    string _OtherSubscriberId;
    string _OtherSubscriberIdQualifier;
    double _CoveredDaysVisitCount;
    decimal _PPSOperatingAmount;
    double _PsychiatricDays;
    DateTime? _StatementPeriodStart;
    DateTime? _StatementPeriodEnd;
    DateTime? _CoverageExpirationDate;
    DateTime? _ClaimReceiverDate;
    Int64 _CreatedById;
    DateTime _CreatedDate;
    Int64 _ModifiedById;
    DateTime _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 ERAClaimPaymentsId
    {
        get { return _ERAClaimPaymentsId; }
        set { _ERAClaimPaymentsId = value; }
    }

    public Int64 ERAPaymentsId
    {
        get { return _ERAPaymentsId; }
        set { _ERAPaymentsId = value; }
    }

    public string ClaimNumber
    {
        get { return _ClaimNumber; }
        set { _ClaimNumber = value; }
    }

    public string ClaimStatusCode
    {
        get { return _ClaimStatusCode; }
        set { _ClaimStatusCode = value; }
    }

    public decimal ClaimCharges
    {
        get { return _ClaimCharges; }
        set { _ClaimCharges = value; }
    }

    public decimal ClaimPayments
    {
        get { return _ClaimPayments; }
        set { _ClaimPayments = value; }
    }

    public decimal PatientResponsibility
    {
        get { return _PatientResponsibility; }
        set { _PatientResponsibility = value; }
    }

    public string InsurancePlanCode
    {
        get { return _InsurancePlanCode; }
        set { _InsurancePlanCode = value; }
    }

    public string PayerClaimControlNumber
    {
        get { return _PayerClaimControlNumber; }
        set { _PayerClaimControlNumber = value; }
    }

    public string PatientLastName
    {
        get { return _PatientLastName; }
        set { _PatientLastName = value; }
    }

    public string PatientFirstName
    {
        get { return _PatientFirstName; }
        set { _PatientFirstName = value; }
    }

    public string PatientIdQualifier
    {
        get { return _PatientIdQualifier; }
        set { _PatientIdQualifier = value; }
    }

    public string PatientIdNumber
    {
        get { return _PatientIdNumber; }
        set { _PatientIdNumber = value; }
    }

    public string InsuredLastName
    {
        get { return _InsuredLastName; }
        set { _InsuredLastName = value; }
    }

    public string InsuredFirstName
    {
        get { return _InsuredFirstName; }
        set { _InsuredFirstName = value; }
    }

    public string InsuredIdQualifier
    {
        get { return _InsuredIdQualifier; }
        set { _InsuredIdQualifier = value; }
    }

    public string InsuredIdNumber
    {
        get { return _InsuredIdNumber; }
        set { _InsuredIdNumber = value; }
    }

    public string CorrectedLastName
    {
        get { return _CorrectedLastName; }
        set { _CorrectedLastName = value; }
    }

    public string CorrectedFirstName
    {
        get { return _CorrectedFirstName; }
        set { _CorrectedFirstName = value; }
    }

    public string CorrectedIdNumber
    {
        get { return _CorrectedIdNumber; }
        set { _CorrectedIdNumber = value; }
    }

    public string ServiceProviderLastName
    {
        get { return _ServiceProviderLastName; }
        set { _ServiceProviderLastName = value; }
    }

    public string ServiceProviderFirstName
    {
        get { return _ServiceProviderFirstName; }
        set { _ServiceProviderFirstName = value; }
    }

    public string ServiceProviderIdQualifier
    {
        get { return _ServiceProviderIdQualifier; }
        set { _ServiceProviderIdQualifier = value; }
    }

    public string ServiceProviderIdCode
    {
        get { return _ServiceProviderIdCode; }
        set { _ServiceProviderIdCode = value; }
    }

    public string CrossOverPayerName
    {
        get { return _CrossOverPayerName; }
        set { _CrossOverPayerName = value; }
    }

    public string CrossOverIdQualifier
    {
        get { return _CrossOverIdQualifier; }
        set { _CrossOverIdQualifier = value; }
    }

    public string CrossOverIdCode
    {
        get { return _CrossOverIdCode; }
        set { _CrossOverIdCode = value; }
    }

    public string CorrectedPayerName
    {
        get { return _CorrectedPayerName; }
        set { _CorrectedPayerName = value; }
    }

    public string CorrectedIdQualifier
    {
        get { return _CorrectedIdQualifier; }
        set { _CorrectedIdQualifier = value; }
    }

    public string CorrectedIdCode
    {
        get { return _CorrectedIdCode; }
        set { _CorrectedIdCode = value; }
    }

    public string OtherSubscriberLastName
    {
        get { return _OtherSubscriberLastName; }
        set { _OtherSubscriberLastName = value; }
    }

    public string OtherSubscriberFirstName
    {
        get { return _OtherSubscriberFirstName; }
        set { _OtherSubscriberFirstName = value; }
    }

    public string OtherSubscriberId
    {
        get { return _OtherSubscriberId; }
        set { _OtherSubscriberId = value; }
    }

    public string OtherSubscriberIdQualifier
    {
        get { return _OtherSubscriberIdQualifier; }
        set { _OtherSubscriberIdQualifier = value; }
    }

    public double CoveredDaysVisitCount
    {
        get { return _CoveredDaysVisitCount; }
        set { _CoveredDaysVisitCount = value; }
    }

    public decimal PPSOperatingAmount
    {
        get { return _PPSOperatingAmount; }
        set { _PPSOperatingAmount = value; }
    }

    public double PsychiatricDays
    {
        get { return _PsychiatricDays; }
        set { _PsychiatricDays = value; }
    }

    public DateTime? StatementPeriodStart
    {
        get { return _StatementPeriodStart; }
        set { _StatementPeriodStart = value; }
    }

    public DateTime? StatementPeriodEnd
    {
        get { return _StatementPeriodEnd; }
        set { _StatementPeriodEnd = value; }
    }

    public DateTime? CoverageExpirationDate
    {
        get { return _CoverageExpirationDate; }
        set { _CoverageExpirationDate = value; }
    }

    public DateTime? ClaimReceiverDate
    {
        get { return _ClaimReceiverDate; }
        set { _ClaimReceiverDate = value; }
    }

    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime ModifiedDate
    {
        get { return _ModifiedDate; }
        set { _ModifiedDate = value; }
    }

    public bool Deleted
    {
        get { return _Deleted; }
        set { _Deleted = value; }
    }

    #endregion
}