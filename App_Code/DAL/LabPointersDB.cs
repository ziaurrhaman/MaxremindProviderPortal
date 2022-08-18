using System;
using System.Data;

/// <summary>
/// Summary description for LabPointersDB
/// </summary>
public class LabPointersDB
{
	public LabPointersDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public Int64 Add(LabPointers objLabPointers)
    {
        DBManager objDBManager = new DBManager();
        try
        {
            objDBManager.AddParameter("PointerId", objLabPointers.PointerId);
            objDBManager.AddParameter("LabOrderId", objLabPointers.LabOrderId);
            objDBManager.AddParameter("CptCode", objLabPointers.CptCode);
            objDBManager.AddParameter("CptDescription", objLabPointers.CptDescription);
            objDBManager.AddParameter("DosFrom", objLabPointers.DosFrom);
            objDBManager.AddParameter("DosTo", objLabPointers.DosTo);
            objDBManager.AddParameter("Pointer1", objLabPointers.Pointer1);
            objDBManager.AddParameter("Pointer2", objLabPointers.Pointer2);
            objDBManager.AddParameter("Pointer3", objLabPointers.Pointer3);
            objDBManager.AddParameter("Pointer4", objLabPointers.Pointer4);            
            objDBManager.AddParameter("ModifiedById", objLabPointers.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objLabPointers.ModifiedDate);
            objDBManager.AddParameter("Deleted", objLabPointers.Deleted);
            objDBManager.ExecuteNonQuery("Lab_AddPointer");
            objLabPointers.PointerId = Convert.ToInt64(objDBManager.Parameters[0].Value.ToString());
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return objLabPointers.PointerId;
    }

    public void Update(LabPointers objLabPointers)
    {
        DBManager objDBManager = new DBManager();        
        try
        {
            objDBManager.AddParameter("PointerId", objLabPointers.PointerId);
            objDBManager.AddParameter("LabOrderId", objLabPointers.LabOrderId);
            objDBManager.AddParameter("CptCode", objLabPointers.CptCode);
            objDBManager.AddParameter("CptDescription", objLabPointers.CptDescription);
            objDBManager.AddParameter("DosFrom", objLabPointers.DosFrom);
            objDBManager.AddParameter("DosTo", objLabPointers.DosTo);
            objDBManager.AddParameter("Pointer1", objLabPointers.Pointer1);
            objDBManager.AddParameter("Pointer2", objLabPointers.Pointer2);
            objDBManager.AddParameter("Pointer3", objLabPointers.Pointer3);
            objDBManager.AddParameter("Pointer4", objLabPointers.Pointer4);            
            objDBManager.AddParameter("ModifiedById", objLabPointers.ModifiedById);
            objDBManager.AddParameter("ModifiedDate", objLabPointers.ModifiedDate);
            objDBManager.ExecuteNonQuery("Lab_UpdatePointer");
        }
        catch (Exception ex)
        {
            throw ex;

        }        
    }

    public DataTable GetPointers(Int64 labOrderId)
    {
        DBManager objDbManager = new DBManager();
        objDbManager.AddParameter("@LabOrderId", labOrderId);        
        return objDbManager.ExecuteDataTable("Lab_GetPointers");
    }
}