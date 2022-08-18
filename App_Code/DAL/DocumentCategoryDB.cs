using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DocumentCategoryDB
/// </summary>
public class DocumentCategoryDB
{
	public DocumentCategoryDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable DocumentCategory_GetAll(Int64 PracticeId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("PracticeId", PracticeId);
        return objDbManager.ExecuteDataTable("DocumentCategory_GetAll");
    }
}