using System;

/// <summary>
/// Summary description for PatientLabOrderDiagnosis
/// </summary>
public class PatientLabOrderDiagnosis
{
	public PatientLabOrderDiagnosis()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    private Int64 _PatientDiagnosisId;
    private Int64 _PatientOrderId;
    private Int64 _PatientId;
    private string _DxCode = string.Empty;
    private string _DxDescription = string.Empty;
    private long _CreatedById;
    private DateTime _CreatedDate;
    private long _ModifiedById;
    private DateTime _ModifiedDate;
    private bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientDiagnosisId
    {
        get { return _PatientDiagnosisId; }
        set { _PatientDiagnosisId = value; }
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

    public string DxCode
    {
        get { return _DxCode; }
        set { _DxCode = value; }
    }

    public string DxDescription
    {
        get { return _DxDescription; }
        set { _DxDescription = value; }
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