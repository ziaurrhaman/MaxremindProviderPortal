using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for jqGridSearchFilterItem
/// </summary>
public class jqGridSearchFilterItem
{
	public jqGridSearchFilterItem()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string field { get; set; }
    public string op { get; set; }
    public string data { get; set; }
}