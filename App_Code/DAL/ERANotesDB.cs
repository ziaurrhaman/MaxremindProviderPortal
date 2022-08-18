using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ERANotesDB
/// </summary>
/// 
//// Created By Rizwan kharal 24April2018
public class ERANotesDB
{
    public ERANotesDB()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public long Add(ERANotes objERANotes)
    {

        DBManager objDBManager = new DBManager();

        try
        {

            objDBManager.AddParameter("ERANotesId", objERANotes.ERANotesId, SqlDbType.BigInt, 8, ParameterDirection.Output);
            objDBManager.AddParameter("Comments", objERANotes.Comments, SqlDbType.VarChar, 1500);
            objDBManager.AddParameter("ERAMasterId", objERANotes.ERAMasterId, SqlDbType.VarChar, 10);
            objDBManager.AddParameter("PracticeId", objERANotes.PracticeId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedById", objERANotes.CreatedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("CreatedOn", objERANotes.CreatedOn);
            objDBManager.AddParameter("Deleted", objERANotes.Deleted, SqlDbType.Bit, 1);

            //objDBManager.ExecuteNonQuery("ERANotes_Add");

            objERANotes.ERANotesId = Convert.ToInt32(objDBManager.Parameters[0].Value);

        }
        catch (Exception ex)
        {


            throw ex;

        }

        return (long)Convert.ToInt32(objERANotes.ERANotesId);

    }



    public long Update(ERANotes objERANotes)
    {

        DBManager objDBManager = new DBManager();

        try
        {

            objDBManager.AddParameter("ERANotesId", objERANotes.ERANotesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Comments", objERANotes.Comments, SqlDbType.VarChar, 1500);
            objDBManager.AddParameter("ModifiedById", objERANotes.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedOn", objERANotes.ModifiedOn);


            objDBManager.ExecuteNonQuery("ERANotes_Update");



        }
        catch (Exception ex)
        {


            throw ex;

        }

        return objERANotes.ERANotesId;

    }

    public long Delete(ERANotes objERANotes)
    {

        DBManager objDBManager = new DBManager();

        try
        {

            objDBManager.AddParameter("ERANotesId", objERANotes.ERANotesId, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("Deleted", objERANotes.Deleted, SqlDbType.VarChar, 5);
            objDBManager.AddParameter("ModifiedById", objERANotes.ModifiedById, SqlDbType.BigInt, 8);
            objDBManager.AddParameter("ModifiedOn", objERANotes.ModifiedOn);


            objDBManager.ExecuteNonQuery("ERANotes_Delete");



        }
        catch (Exception ex)
        {


            throw ex;

        }

        return objERANotes.ERANotesId;

    }

    //public DataTable GetAllERANotes(long PracticeId, long ERAMasterId)
    //{
    //    DBManager objDBManager = new DBManager();
    //    objDBManager.AddParameter("PracticeId", PracticeId);
    //    objDBManager.AddParameter("ERAMasterId", ERAMasterId);
    //    return objDBManager.ExecuteDataTable("Get_AllERANotes");
    //}
    public DataTable GetAllERANotes(long PracticeId, int Rows, int PageNumber, string SortBy, long ERAMasterId)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("PracticeId", PracticeId);
        objDBManager.AddParameter("ERAMasterId", ERAMasterId);
        objDBManager.AddParameter("Rows", Rows);
        objDBManager.AddParameter("PageNumber", PageNumber);
        objDBManager.AddParameter("SortBy", SortBy);
        return objDBManager.ExecuteDataTable("Get_AllERANotes");
    }
}