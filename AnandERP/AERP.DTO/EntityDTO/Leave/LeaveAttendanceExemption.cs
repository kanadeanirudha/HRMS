using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class LeaveAttendanceExemption : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public int EmployeeId
		{
			get;
			set;
		}
		public string ExemptionFromDate
		{
			get;
			set;
		}
        public string ExemptionUpToDate
		{
			get;
			set;
		}
        public string EmployeeName
		{
			get;
			set;
		}
        public bool StatusFlag 
		{
			get;
			set;
		}    
		public bool IsActive
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
        public string errorMessage { get; set; }
	}
}
