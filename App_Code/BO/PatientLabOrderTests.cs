using System;


/// <summary>
/// Summary description for PatientLabOrderTests
/// </summary>
public class PatientLabOrderTests
{
	public PatientLabOrderTests()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

  private  Int64 _PatientOrderTestId ;
  private Int64 _PatientOrderId;
  private Int64 _PatientId;  
  private Int64 _LabTestGroupId;
  private Int64 _LabTestId;
  private string _CptCode = string.Empty;
  private string _CptDescription = string.Empty;
  private string _Instructions = string.Empty;
  private int _Units;
  private long _CreatedById;
  private DateTime _CreatedDate;
  private long _ModifiedById;
  private DateTime _ModifiedDate;
  private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientOrderTestId
    {
        get { return _PatientOrderTestId; }
        set { _PatientOrderTestId = value; }
    }

    public Int64 PatientOrderId
    {
        get { return _PatientOrderId; }
        set { _PatientOrderId = value; }
    }
    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }    

    public Int64 LabTestGroupId
    {
        get { return _LabTestGroupId; }
        set { _LabTestGroupId = value; }
    }
    public Int64 LabTestId
    {
        get { return _LabTestId; }
        set { _LabTestId = value; }
    }
    public string CptCode
    {
        get { return _CptCode; }
        set { _CptCode = value; }
    }

    public string CptDescription
    {
        get { return _CptDescription; }
        set { _CptDescription = value; }
    }

    public string Instructions
    {
        get { return _Instructions; }
        set { _Instructions = value; }
    }

    public int Units
    {
        get { return _Units; }
        set { _Units = value; }
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

    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik, @toddanglin
    //Facebook: facebook.com/telerik
    //=======================================================

}