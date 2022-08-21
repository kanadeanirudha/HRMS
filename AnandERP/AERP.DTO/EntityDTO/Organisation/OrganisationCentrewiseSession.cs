using AMS.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DTO
{
	public class OrganisationCentrewiseSession : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public int SessionID
		{
			get;
			set;
		}
        public string SessionName { get; set; }
		public string SessionFromDate
		{
			get;
			set;
		}
		public string SessionUptoDate
		{
			get;
			set;
		}
		public string ActiveSessionType
		{
			get;
			set;
		}
		public string ActiveSessionFlag
		{
			get;
			set;
		}
        public string CentreCode
		{
			get;
			set;
		}
        public string CentreName
        {
            get;
            set;
        }
		public string LockStatus
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
		public bool IsDeleted
		{
			get;
			set;
		}
		public int CreatedBy
		{
			get;
			set;
		}
		public DateTime CreatedDate
		{
			get;
			set;
		}
		public int ModifiedBy
		{
			get;
			set;
		}
		public DateTime ModifiedDate
		{
			get;
			set;
		}
		public int DeletedBy
		{
			get;
			set;
		}
		public DateTime DeletedDate
		{
			get;
			set;
		}
        public string SelectedCentreName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
	}
}
