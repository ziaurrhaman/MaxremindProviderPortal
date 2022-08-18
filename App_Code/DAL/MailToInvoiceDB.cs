using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Created By Agha Sibtain, Dated:04/10/2019
/// Summary description for MailToInvoiceDB
/// </summary>
public class MailToInvoiceDB
{
	public MailToInvoiceDB()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataSet GetAllMailToInvoice(long PracticeId, string WeeklyInvoicetxt)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
      
        if (!string.IsNullOrEmpty(WeeklyInvoicetxt))
        {
            objDBManager.AddParameter("@WeeklyInvoicetxt", WeeklyInvoicetxt);
        }
        return objDBManager.ExecuteDataSet("GetMothBatchWiseInvoice");
    }
    public DataSet GetDetailedMailToInvoices(long PracticeId, string date, string Patientinvoicesearch)
    {
        DBManager objDBManager = new DBManager();
        objDBManager.AddParameter("@PracticeId", PracticeId);
      
        if (!string.IsNullOrEmpty(Patientinvoicesearch))
        {
            objDBManager.AddParameter("@Patientinvoicesearch", Patientinvoicesearch);
        }
        if (!string.IsNullOrEmpty(date))
        {
            objDBManager.AddParameter("@CreatedDate", date);
        }
       
        return objDBManager.ExecuteDataSet("GetMothBatchWiseInvoice");
    }
}