using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EmployeeProjectWorksMaster : BaseDTO
	{
        //---------------------------------------   EmployeeProjectWorksMaster Properties  ------------------------------------------//
		public int ID
		{
			get;
			set;
		}
        public string ProjectWorkDate
		{
			get;
			set;
		}
		public string ProjectWorkName
		{
			get;
			set;
		}
        public decimal ProjectCost
		{
			get;
			set;
		}
        public string FundingAgency
		{
			get;
			set;
		}
        public string AssignmentFromDate
		{
			get;
			set;
		}
        public string AssignmentToDate
		{
			get;
			set;
		}
		public Int16 Duration
		{
			get;
			set;
		}
		public string DurationUnit
		{
			get;
			set;
		}
        public bool ProjectStatus
		{
			get;
			set;
		}
		public string Remarks
		{
			get;
			set;
		}
		public string CentreCode
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
		public int? ModifiedBy
		{
			get;
			set;
		}
		public DateTime? ModifiedDate
		{
			get;
			set;
		}
		public int? DeletedBy
		{
			get;
			set;
		}
		public DateTime? DeletedDate
		{
			get;
			set;
		}


        //---------------------------------------   EmployeeProjectWorksDetails Properties  ------------------------------------------//
        public int EmployeeProjectWorksDetailsID
		{
			get;
			set;
		}
		public int EmployeeProjectWorkMasterID
		{
			get;
			set;
		}
		public int EmployeeID
		{
			get;
			set;
		}
        public string ProjectWorkFromDate
		{
			get;
			set;
		}
        public string ProjectWorkToDate
		{
			get;
			set;
		}
		public string EmployeeRemark
		{
			get;
			set;
		}
		public string WorkAsDesignation
		{
			get;
			set;
		}
        public bool IndividualProjectStatus
		{
			get;
			set;
		}
		public string InActiveReason
		{
			get;
			set;
		}
        public string InActiveDate
		{
			get;
			set;
		}

        public string errorMessage { get; set; }
        public bool StatusFlag { get; set; }
	}
}

