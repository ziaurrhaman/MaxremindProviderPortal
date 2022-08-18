using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactUs
/// </summary>
public class ContactUs
{
	public ContactUs()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string tbname { get; set; }
    public string tbLastname { get; set; }
    public string tbemail { get; set; }
    public string tbphone { get; set; }
    public string tbMesage { get; set; }
    public string tbsubject { get; set; }

}