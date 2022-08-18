using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HeaderInformation837
/// </summary>
public class HeaderInformation837
{
	public HeaderInformation837()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    int _HeaderID837;
    string _AuthInfoQL = string.Empty;
    string _AuthInfo = string.Empty;
    string _SecurityInfoQL = string.Empty;
    string _SecurityInfo = string.Empty;
    string _InterSenderQL = string.Empty;
    string _InterSenderId = string.Empty;
    string _InterReceiverQL = string.Empty;
    string _InterReceiverId = string.Empty;
    string _TestOrp = string.Empty;
    string _GSSenderCode = string.Empty;
    string _GSReceiverCode = string.Empty;

    #endregion

    #region " Properties "

    public int HeaderID837
    {
        get { return _HeaderID837; }
        set { _HeaderID837 = value; }
    }

    public string AuthInfoQL
    {
        get { return _AuthInfoQL; }
        set { _AuthInfoQL = value; }
    }

    public string AuthInfo
    {
        get { return _AuthInfo; }
        set { _AuthInfo = value; }
    }

    public string SecurityInfoQL
    {
        get { return _SecurityInfoQL; }
        set { _SecurityInfoQL = value; }
    }

    public string SecurityInfo
    {
        get { return _SecurityInfo; }
        set { _SecurityInfo = value; }
    }

    public string InterSenderQL
    {
        get { return _InterSenderQL; }
        set { _InterSenderQL = value; }
    }

    public string InterSenderId
    {
        get { return _InterSenderId; }
        set { _InterSenderId = value; }
    }

    public string InterReceiverQL
    {
        get { return _InterReceiverQL; }
        set { _InterReceiverQL = value; }
    }

    public string InterReceiverId
    {
        get { return _InterReceiverId; }
        set { _InterReceiverId = value; }
    }

    public string TestOrp
    {
        get { return _TestOrp; }
        set { _TestOrp = value; }
    }

    public string GSSenderCode
    {
        get { return _GSSenderCode; }
        set { _GSSenderCode = value; }
    }

    public string GSReceiverCode
    {
        get { return _GSReceiverCode; }
        set { _GSReceiverCode = value; }
    }

    #endregion

}