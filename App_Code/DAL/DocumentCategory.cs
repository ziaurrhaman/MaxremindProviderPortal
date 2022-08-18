using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for DocumentCategory
/// </summary>
public class DocumentCategory
{
	public DocumentCategory()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable DocumentCategory_GetByPracticeId(Int64 PracticeId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        return objDBManager.ExecuteDataTable("DocumentCategory_GetByPracticeId");
    }
}