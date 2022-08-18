using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrgansDetails
/// </summary>
public class OrgansDetails
{
	public OrgansDetails()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _OrgansDetailsId;
    string _OrganDetailDescription = string.Empty;
    string _OrganCode = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    int _Position = 0;

    List<OrganDetailsValues> _listOrganDetailsValues;
    
    #endregion
    
    #region " Properties "
    
    public long OrgansDetailsId
    {
        get { return _OrgansDetailsId; }
        set { _OrgansDetailsId = value; }
    }

    public string OrganDetailDescription
    {
        get { return _OrganDetailDescription; }
        set { _OrganDetailDescription = value; }
    }

    public string OrganCode
    {
        get { return _OrganCode; }
        set { _OrganCode = value; }
    }

    public long CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public long ModifiedById
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
    
    public int Position
    {
        get { return _Position; }
        set { _Position = value; }
    }
    
    public List<OrganDetailsValues> listOrganDetailsValues
    {
        get { return _listOrganDetailsValues; }
        set { _listOrganDetailsValues = value; }
    }

    #endregion

}