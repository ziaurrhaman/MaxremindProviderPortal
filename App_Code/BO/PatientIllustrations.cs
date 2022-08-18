using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientIllustrations
/// </summary>
public class PatientIllustrations
{
	public PatientIllustrations()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _PatientIllustrationId;
    Int64 _PatientId;
    Int64? _ChartId;
    string _Illustration = string.Empty;
    string _Descrption = string.Empty;
    string _IllustrationImg = string.Empty;
    Int64 _CreatedById;
    DateTime? _CreatedDate;
    Int64 _ModifiedById;
    DateTime? _ModifiedDate;
    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientIllustrationId
    {
        get { return _PatientIllustrationId; }
        set { _PatientIllustrationId = value; }
    }

    public Int64 PatientId
    {
        get { return _PatientId; }
        set { _PatientId = value; }
    }

    public Int64? ChartId
    {
        get { return _ChartId; }
        set { _ChartId = value; }
    }

    public string Illustration
    {
        get { return _Illustration; }
        set { _Illustration = value; }
    }

    public string Descrption
    {
        get { return _Descrption; }
        set { _Descrption = value; }
    }

    public string IllustrationImg
    {
        get { return _IllustrationImg; }
        set { _IllustrationImg = value; }
    }
    public Int64 CreatedById
    {
        get { return _CreatedById; }
        set { _CreatedById = value; }
    }

    public DateTime? CreatedDate
    {
        get { return _CreatedDate; }
        set { _CreatedDate = value; }
    }

    public Int64 ModifiedById
    {
        get { return _ModifiedById; }
        set { _ModifiedById = value; }
    }

    public DateTime? ModifiedDate
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