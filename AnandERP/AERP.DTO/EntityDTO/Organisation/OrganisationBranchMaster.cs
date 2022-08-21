using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationBranchMaster : BaseDTO
	{

        public OrganisationDepartmentBranch OrganisationDepartmentBranchDTO
        {
            get;
            set;
        }
		public int ID
		{
			get;
			set;
		}
		public string BranchDescription
		{
			get;
			set;
		}
		public int IntroductionYear
		{
			get;
			set;
		}
		public string BranchShortCode
		{
			get;
			set;
		}
		public string PrintShortCode
		{
			get;
			set;
		}
		public bool CommonBranch
		{
			get;
			set;
		}
		public Int16 DurationInDays
		{
			get;
			set;
		}
		public int UniversityID
		{
			get;
			set;
		}
        public int DepartmentID
        {
            get;
            set;
        }
        public int DepartmentBranchID
        {
            get;
            set;
        }
		public bool IsCommonBranchApplicable
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
        public string errorMessage { get; set; }
	}
}
