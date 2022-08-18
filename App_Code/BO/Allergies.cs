using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Allergies
/// </summary>
public class Allergies
{
	public Allergies()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _AllergyCode;
    private string _Allergy = string.Empty;
    private string _Description = string.Empty;
    private int _AllergyTypeId;

    public int AllergyCode
    {
        get { return _AllergyCode; }
        set { _AllergyCode = value; }
    }
    public string Allergy
    {
        get { return _Allergy; }
        set { _Allergy = value; }
    }
    public string Description
    {
        get { return _Description; }
        set { _Description = value; }
    }
    public int AllergyTypeId
    {
        get { return _AllergyTypeId; }
        set { _AllergyTypeId = value; }
    }
}