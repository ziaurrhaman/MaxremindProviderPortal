using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for QualificationManager
/// </summary>
public class QualificationManager
{
	public QualificationManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Add(Qualification objQualification, SqlTransaction objSqlTransaction = null)
    {

        QualificationDB objQualificationDB = new QualificationDB();

        return objQualificationDB.Add(objQualification, objSqlTransaction);

    }

    public int Update(Qualification objQualification, SqlTransaction objSqlTransaction = null)
    {

        QualificationDB objQualificationDB = new QualificationDB();
        return objQualificationDB.Update(objQualification, objSqlTransaction);

    }
}