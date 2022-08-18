using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JqGridData
/// </summary>
public class JqGridData
{
	public JqGridData()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long total { get; set; }
    public int page { get; set; }
    public long records { get; set; }
    public List<TableRow> rows { get; set; }
    public List<int> selectedRows { get; set; }
}