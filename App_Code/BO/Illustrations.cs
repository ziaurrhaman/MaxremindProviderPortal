using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Illustrations
/// </summary>
public class Illustrations
{
    public Illustrations()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region " Private Members "

    int _IllustrationId;
    Int64 _PracticeId;
    string _Illustration = string.Empty;
    string _IllustrationImg = string.Empty;
    string _Type = string.Empty;
    Int64 _CreatedById;
    DateTime? _CreatedDate;
    Int64 _ModifiedById;
    DateTime? _ModifiedDate;

    bool _Deleted = false;
    #endregion

    #region " Properties "

    public int IllustrationId
    {
        get { return _IllustrationId; }
        set { _IllustrationId = value; }
    }

    public Int64 PracticeId
    {
        get { return _PracticeId; }
        set { _PracticeId = value; }
    }

    public string Illustration
    {
        get { return _Illustration; }
        set { _Illustration = value; }
    }

    public string IllustrationImg
    {
        get { return _IllustrationImg; }
        set { _IllustrationImg = value; }
    }

    public string Type
    {
        get { return _Type; }
        set { _Type = value; }
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