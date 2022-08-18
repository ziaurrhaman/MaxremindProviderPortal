using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for InvoiceList
/// </summary>
public class InvoiceList
{
	public InvoiceList()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region " Private Members "

    long _patientId;
    string _data;



    #endregion

    #region " Properties "

    public long patientId
    {
        get { return _patientId; }
        set { _patientId = value; }
    }

    public string data
    {
        get { return _data; }
        set { _data = value; }
    }

  

    #endregion

}