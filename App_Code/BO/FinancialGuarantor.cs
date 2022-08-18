using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FinancialGuarantor
/// </summary>
public class FinancialGuarantor
{
	public FinancialGuarantor()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private int _FinancialGuarantorId;
    private Int64 _PracticeId;
    private string _FirstName = string.Empty;
    private string _LastName = string.Empty;
    private string _MiddleName = string.Empty;
    private DateTime _DateOfBirth;
    private string _SSN = string.Empty;
    private string _Gender = string.Empty;
    private string _MaritalStatus = string.Empty;
    private string _Address = string.Empty;
    private string _Zip = string.Empty;
    private string _City = string.Empty;
    private string _State = string.Empty;
    private string _HomePhone = string.Empty;
    private string _Cell = string.Empty;
    private string _WorkPhone = string.Empty;
    private string _Ext = string.Empty;
    private string _Email = string.Empty;
    private long _CreatedById;
    private Nullable<DateTime> _CreatedDate;
    private long _ModifiedById;
    private Nullable<DateTime> _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public int FinancialGuarantorId
    {
        get { return _FinancialGuarantorId; }
        set { _FinancialGuarantorId = value; }
    }

    public string FirstName
    {
        get { return _FirstName; }
        set { _FirstName = value; }
    }

    public string LastName
    {
        get { return _LastName; }
        set { _LastName = value; }
    }

    public string MiddleName
    {
        get { return _MiddleName; }
        set { _MiddleName = value; }
    }

    public DateTime DateOfBirth
    {
        get { return _DateOfBirth; }
        set { _DateOfBirth = value; }
    }

    public string SSN
    {
        get { return _SSN; }
        set { _SSN = value; }
    }

    public string Gender
    {
        get { return _Gender; }
        set { _Gender = value; }
    }

    public string MaritalStatus
    {
        get { return _MaritalStatus; }
        set { _MaritalStatus = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
    }

    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    public string State
    {
        get { return _State; }
        set { _State = value; }
    }

    public string HomePhone
    {
        get { return _HomePhone; }
        set { _HomePhone = value; }
    }

    public string Cell
    {
        get { return _Cell; }
        set { _Cell = value; }
    }

    public string WorkPhone
    {
        get { return _WorkPhone; }
        set { _WorkPhone = value; }
    }

    public string Ext
    {
        get { return _Ext; }
        set { _Ext = value; }
    }

    public string Email
    {
        get { return _Email; }
        set { _Email = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public Nullable<DateTime> CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public Nullable<DateTime> ModifiedDate
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