using System;
using System.Configuration;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for UserImages
/// </summary>
public class UserImages
{
	public UserImages()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void saveUserImage(string imagePath,string agencyId,string sourceDirectory,string destinationDirectory)
    {
        string destinationPath = ConfigurationManager.AppSettings["DocumentsPath"] + "/" + agencyId + "/" + destinationDirectory;
        
        if (!Directory.Exists(HttpContext.Current.Server.MapPath(destinationPath)))
            Directory.CreateDirectory(HttpContext.Current.Server.MapPath(destinationPath));
        try
        {

            string sourceFile =
                HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["DocumentsPath"] + "/" + agencyId +
                                                   "/" + sourceDirectory + "/" + imagePath);

            string destinationFile = HttpContext.Current.Server.MapPath(Path.Combine(destinationPath, imagePath));
            if (!File.Exists(destinationFile))
                File.Copy(sourceFile, destinationFile);
        }
        catch
        {
            ;
        }
    }
    
}