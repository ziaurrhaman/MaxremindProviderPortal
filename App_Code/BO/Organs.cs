using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Organs
/// </summary>
public class Organs
{
	public Organs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    
    #region " Private Members "
    
    long _OrganId;
    string _OrganCode = string.Empty;
    string _OrganName = string.Empty;
    long _CreatedById;
    DateTime _CreatedDate;
    long _ModifiedById;
    DateTime _ModifiedDate;
    bool _Deleted = false;
    int _Position = 0;
    long _PracticeId;
    
    List<OrgansDetails> _listOrgansDetails;
    
    #endregion
    
    #region " Properties "
    
    public long OrganId
    {
        get { return _OrganId; }
        set { _OrganId = value; }
    }
    
    public string OrganCode
    {
        get { return _OrganCode; }
        set { _OrganCode = value; }
    }
    
    public string OrganName
    {
        get { return _OrganName; }
        set { _OrganName = value; }
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
    
    public long PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public List<OrgansDetails> listOrgansDetails
    {
        get { return _listOrgansDetails; }
        set { _listOrgansDetails = value; }
    }

    #endregion
    
}