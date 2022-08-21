using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSubGrpRuleSessionwise : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public int SubjectRuleGrpNumber
		{
			get;
			set;
		}
        public string RuleName { get; set; }
		public int SessionID
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
		public int CourseYearSemesterID
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
        public string CentreName
        {
            get;
            set;
        }
        public string UniversityName
        {
            get;
            set;
        }
        public string SessionName
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public int OrgSessionCryAllocationID { get; set; }
    }
}
