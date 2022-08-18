using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAssignedPractices
/// </summary>
public class UserAssignedPractices
{
	public UserAssignedPractices()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    #region Private Members
    public long UserAssignedPracticeId { get; set; }
    public long UserId { get; set; }
    public long PracticeId { get; set; }

    public DateTime CreatedDate { get; set; }
    public long CreatedById { get; set; }
    public DateTime ModifiedDate { get; set; }
    public long ModifiedById { get; set; }

    public bool Deleted { get; set; }

    public bool IsActive { get; set; }
    public long PraticeLocation { get; set; }

    #endregion	
}