using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Pharmacy
/// </summary>
public class Pharmacy
{
    public Pharmacy()
    {


    }

    #region " Private Members "

    int _PharmacyId;
    int _PharmacyCode;
    string _Status;
    string _NCPDP_Id;
    string _Store;
    string _StoreName;
    string _Address1;
    string _Address2;
    string _Telephone1;
    string _Telephone2;
    string _Fax;
    string _PhoneAlt1;
    string _PhoneAlt2;
    string _PhoneAlt3;
    string _PhoneAlt4;
    string _PhoneAlt5;
    string _City;
    int _State;
    string _Zip;
    DateTime _TouchDate;
    int _TypeID;

    short _DetailTypeID = short.MinValue;
    #endregion

    #region " Properties "

    public int PharmacyId
    {
        get { return _PharmacyId; }
        set { _PharmacyId = value; }
    }

    public int PharmacyCode
    {
        get { return _PharmacyCode; }
        set { _PharmacyCode = value; }
    }

    public string Status
    {
        get { return _Status; }
        set { _Status = value; }
    }

    public string NCPDP_Id
    {
        get { return _NCPDP_Id; }
        set { _NCPDP_Id = value; }
    }

    public string Store
    {
        get { return _Store; }
        set { _Store = value; }
    }

    public string StoreName
    {
        get { return _StoreName; }
        set { _StoreName = value; }
    }

    public string Address1
    {
        get { return _Address1; }
        set { _Address1 = value; }
    }

    public string Address2
    {
        get { return _Address2; }
        set { _Address2 = value; }
    }

    public string Telephone1
    {
        get { return _Telephone1; }
        set { _Telephone1 = value; }
    }

    public string Telephone2
    {
        get { return _Telephone2; }
        set { _Telephone2 = value; }
    }

    public string Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
    }

    public string PhoneAlt1
    {
        get { return _PhoneAlt1; }
        set { _PhoneAlt1 = value; }
    }

    public string PhoneAlt2
    {
        get { return _PhoneAlt2; }
        set { _PhoneAlt2 = value; }
    }

    public string PhoneAlt3
    {
        get { return _PhoneAlt3; }
        set { _PhoneAlt3 = value; }
    }

    public string PhoneAlt4
    {
        get { return _PhoneAlt4; }
        set { _PhoneAlt4 = value; }
    }

    public string PhoneAlt5
    {
        get { return _PhoneAlt5; }
        set { _PhoneAlt5 = value; }
    }

    public string City
    {
        get { return _City; }
        set { _City = value; }
    }

    public int State
    {
        get { return _State; }
        set { _State = value; }
    }

    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }

    public DateTime TouchDate
    {
        get { return _TouchDate; }
        set { _TouchDate = value; }
    }

    public int TypeID
    {
        get { return _TypeID; }
        set { _TypeID = value; }
    }

    public short DetailTypeID
    {
        get { return _DetailTypeID; }
        set { _DetailTypeID = value; }
    }

    #endregion

}