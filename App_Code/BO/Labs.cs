using System;

/// <summary>
/// Summary description for Labs
/// </summary>
public class Labs
{
	public Labs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

   private Int64 _LabId;
   private string _Name = string.Empty;
   private string _Address = string.Empty;
   private string _City = string.Empty;
   private string _State = string.Empty;
   private string _Zip = string.Empty;
   private string _Phone = string.Empty;
   private string _Fax = string.Empty;
   private string _Email = string.Empty;
   private Int64 _PracticeId;
   private long _CreatedById;
   private DateTime _CreatedDate ;
   private long _ModifiedById;
   private DateTime _ModifiedDate ;
   private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 LabId
    {
        get { return _LabId; }
        set { _LabId = value; }
    }

    public string Name
    {
        get { return _Name; }
        set { _Name = value; }
    }

    public string Address
    {
        get { return _Address; }
        set { _Address = value; }
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

    public string Zip
    {
        get { return _Zip; }
        set { _Zip = value; }
    }

    public string Phone
    {
        get { return _Phone; }
        set { _Phone = value; }
    }

    public string Fax
    {
        get { return _Fax; }
        set { _Fax = value; }
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

    #endregion
}