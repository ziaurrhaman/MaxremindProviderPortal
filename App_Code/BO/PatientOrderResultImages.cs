using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PatientOrderResultImages
/// </summary>
public class PatientOrderResultImages
{
	public PatientOrderResultImages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region " Private Members "

    Int64 _PatientOrderResultImagesId;
    string _ResultImage = string.Empty;
    string _Description = string.Empty;
    Int64 _PatientOrderResultId;
    Int64 _CreatedById;
    DateTime? _CreatedDate;
    Int64 _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public Int64 PatientOrderResultImagesId
    {
        get { return _PatientOrderResultImagesId; }
        set { _PatientOrderResultImagesId = value; }
    }

    public string ResultImage
    {
        get { return _ResultImage; }
        set { _ResultImage = value; }
    }

    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }

    public Int64 PatientOrderResultId
    {
        get { return _PatientOrderResultId; }
        set { _PatientOrderResultId = value; }
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