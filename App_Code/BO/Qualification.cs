using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Qualification
/// </summary>
public class Qualification
{
	public Qualification()
	{
		//
		// TODO: Add constructor logic here
		//
	}

        #region " Private Members "

        private long _QualificationId;
        private string _Name;
        private string _Description;
        private DateTime _CreatedDate;
        private long _CreatedById;
        private System.Nullable<DateTime> _ModifiedDate;
        private System.Nullable<int> _ModifiedById;
        private bool _Deleted;
        #endregion

        #region " Properties "

        public Int64 QualificationId
        {
            get { return _QualificationId; }
            set { _QualificationId = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        public long CreatedById
        {
            get { return _CreatedById; }
            set { _CreatedById = value; }
        }

        public System.Nullable<DateTime> ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        public System.Nullable<int> ModifiedById
        {
            get { return _ModifiedById; }
            set { _ModifiedById = value; }
        }

        public bool Deleted
        {
            get { return _Deleted; }
            set { _Deleted = value; }
        }


        #endregion
}