using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for jqGridSearchFilter
/// </summary>
public class jqGridSearchFilter
{
	public jqGridSearchFilter()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public string groupOp { get; set; }
    public List<jqGridSearchFilterItem> rules { get; set; }
}