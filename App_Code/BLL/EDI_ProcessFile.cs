using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EDI_ProcessFile
/// </summary>
public class EDI_ProcessFile
{
	public EDI_ProcessFile()
	{
		//
		// TODO: Add constructor logic here
		//
	}


    public string SetFileSeparartors(string sFileData)
    {
        string elementSeparator = "";
        string segmentSeparator = "";
        
        sFileData = sFileData.Trim();
        // Check if file is a valid X12 File otherwise return NVF

        if ((sFileData.Length < 3) || (sFileData.Substring(0, 3) != "ISA"))
        {
            return sFileData = "NVF";
        }

        elementSeparator = sFileData.Substring(3, 1);
        segmentSeparator = sFileData.Substring(105, 1);

        sFileData = sFileData.Replace(elementSeparator, "*");
        sFileData = sFileData.Replace(segmentSeparator, "~");


        return sFileData;
    }

    public string getTransactionType(string sFileData)
    {
        string sTransactionType = "";


        string[] arrFileData = sFileData.Split(new[] { "~ST*" }, StringSplitOptions.RemoveEmptyEntries);

        sTransactionType = arrFileData[1].Substring(0, 3);

        return sTransactionType;
    }

    public Dictionary<string,string> GetFilesDetails(string sFileData)
    {
        Dictionary<string, string> objDicFileDetails = new Dictionary<string, string>();
        string sFileId = "";
        string sSubmitterId = "";
        string sReceiverId = "";
        string sTransactionType = "";
        string sTransactionCode = "";
        string sTransactionVersion = "";
        string sFileCreationTime = "";
        string sFileCreationDate = "";

        string[] arrFileData = sFileData.Split('*');

        sSubmitterId = arrFileData[6].Trim();
        sReceiverId = arrFileData[8].Trim();
        sFileCreationDate = arrFileData[9];
        sFileCreationTime = arrFileData[10];
        sTransactionVersion = arrFileData[12];
        sFileId = arrFileData[13];

        string[] arrFileData1 = sFileData.Split(new[] { "~ST*" }, StringSplitOptions.RemoveEmptyEntries);

        sTransactionType = arrFileData1[1].Substring(0, 3);

        string[] arrFileData2 = sFileData.Split(new[] { "~GS*" }, StringSplitOptions.RemoveEmptyEntries);

        sTransactionCode = arrFileData2[1].Split('*')[7].Split('~')[0];

        objDicFileDetails.Add("FileId",sFileId);
        objDicFileDetails.Add("SubmitterId",sSubmitterId);
        objDicFileDetails.Add("ReceiverId",sReceiverId);
        objDicFileDetails.Add("TransactionType",sTransactionType);
        objDicFileDetails.Add("TransactionCode",sTransactionCode);
        objDicFileDetails.Add("TransactionVersion",sTransactionVersion);
        objDicFileDetails.Add("CreationDate",sFileCreationDate);
        objDicFileDetails.Add("CreationTime",sFileCreationTime);

        return objDicFileDetails;
    }

    public bool CheckFileAlreadyImported(long practiceId, string sFileName,Dictionary<string,string> dicFileInfo)
    {
        string sFileId = "";
        string sSubmitterId = "";
        string sReceiverId = "";
        string sTransactionType = "";
        string sTransactionCode = "";
        string sTransactionVersion = "";
        string sFileCreationTime = "";
        string sFileCreationDate = "";

        EDIProcessedFilesDB objProcessedFiles = new EDIProcessedFilesDB();

        sFileId = dicFileInfo["FileId"];
        sSubmitterId = dicFileInfo["SubmitterId"];
        sReceiverId = dicFileInfo["ReceiverId"];
        sTransactionType = dicFileInfo["TransactionType"];
        sTransactionCode = dicFileInfo["TransactionCode"];
        sTransactionVersion = dicFileInfo["TransactionVersion"];
        sFileCreationTime = dicFileInfo["CreationDate"];
        sFileCreationDate = dicFileInfo["CreationTime"];

        DataTable dtImportedFile = objProcessedFiles.FileAlreadyImported(practiceId, sFileName, sSubmitterId, sReceiverId, sFileId, sFileCreationDate, sFileCreationTime, sTransactionType);

        if(dtImportedFile.Rows.Count>0)
        {
            return true;
        }
        

        return false;
    }
}