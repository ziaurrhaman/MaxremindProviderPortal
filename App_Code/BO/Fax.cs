using System;
//using interfax;

/// <summary>
/// Summary description for Fax
/// </summary>
public class Fax
{
    public Fax()
    {
        
    }
	public void SendFax(string html, string FaxNumbers)
	{
		//
		// TODO: Add constructor logic here
		//
        string username = "maxremind";
        string password = "123456";
        string[] FaxNumbersArray = FaxNumbers.Split(';'); //"0018555747238";
	    string faxcontents = html;

        for (int i = 0; i < FaxNumbersArray.Length - 1; i++)
        {
            //InterFax ifws = new InterFax();
            //ifws.SendCharFax(username, password, FaxNumbersArray[i], faxcontents, "txt");
        }                
	}
}