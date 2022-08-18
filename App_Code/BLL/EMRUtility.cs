using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;

/// <summary>
/// Summary description for Utility
/// </summary>
public class EMRUtility
{
    public EMRUtility()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void SetPermissions(string dirPath)
    {
        DirectoryInfo info = new DirectoryInfo(dirPath);
        WindowsIdentity self = System.Security.Principal.WindowsIdentity.GetCurrent();
        DirectorySecurity ds = info.GetAccessControl();
        ds.AddAccessRule(new FileSystemAccessRule(self.Name,
        FileSystemRights.FullControl,
        InheritanceFlags.ObjectInherit |
        InheritanceFlags.ContainerInherit,
        PropagationFlags.None,
        AccessControlType.Allow));
        info.SetAccessControl(ds);
    }
}