using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
/// <summary>
/// Summary description for Relationship
/// </summary>
public class RelationshipDB
{
	public RelationshipDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public  DataTable Relationship_GetAll()
    {
        DBManager ObjDBManager = new DBManager();
        return ObjDBManager.ExecuteDataTable("Relationship_GetAll");
    }
}