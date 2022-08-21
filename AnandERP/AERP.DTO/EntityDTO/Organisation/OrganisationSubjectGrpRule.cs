using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSubjectGrpRule : BaseDTO
	{
		public int ID
		{
			get;
			set;
		}
		public string RuleName
		{
			get;
			set;
		}
		public string RuleCode
		{
			get;
			set;
		}
		public int TotalSubjects
		{
			get;
			set;
		}
		public int MaxCompulsorySubjects
		{
			get;
			set;
		}
		public int MaxOptSubjects
		{
			get;
			set;
		}
		public int NoOfOptSubjects
		{
			get;
			set;
		}
		public int MaxGroups
		{
			get;
			set;
		}
		public int MaxNoOfCompulsoryGroups
		{
			get;
			set;
		}
		public int CourseYearSemesterID
		{
			get;
			set;
		}
		public int OrgSessionCryrAllotID
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
        public string OrgSemesterName
        {
            get;
            set;
        }
        public string CourseYearCode
        {
            get;
            set;
        }
        

        ///<summary>
        ///Properties required for OrganisationSubjectGroupRuleSessionwise table
        ///<returns><returns>

        public int SessionID
        {
            get;
            set;
        }
        public int OrgSubGrpRuleSessionwiseID
        {
            get;
            set;
        }
        public string BranchDescription
        {
            get;
            set;
        }
        public string SemesterName
        {
            get;
            set;
        }
        public string BranchShortCode
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }

        public int OrgSessionCryAllocationID { get; set; }
        public bool SessionCryAllocationStatus { get; set; }
        ///<summary>
        ///Properties required for OrgElectiveGrpMaster table
        ///<returns><returns>
        public int OrgElectiveGrpMasterID { get; set; }
        public string GroupShortCode { get; set; }
        public string GroupName { get; set; }
        public int SubjectRuleGrpNumber { get; set; }
        public bool GroupCompulsoryFlag { get; set; }
        public int NoOfSubGroups { get; set; }
        public int NoOfCompulsorySubGrp { get; set; }
        public int NoOfSubGrpSubjectSelect { get; set; }
        public string ElectiveCommonGroup { get; set; }


        ///<summary>
        ///Properties required for OrgSubElectiveGrpMaster table
        ///<returns><returns>

        public int OrgSubElectiveGrpMasterID { get; set; }
        public int OrgElectiveGrpID { get; set; }
        public string OrgSubElectiveGrpDescription { get; set; }
        public string ShortDescription { get; set; }
        public int TotalNoOfSubjects { get; set; }
        public bool SubGrpCompulsorySubjFlag { get; set; }
        public int AllowToSelect { get; set; }
        public bool SubGroupCompulsoryFlag { get; set; }
        public int TotalNoOfSubjectCompulsory { get; set; }
        public string ElectiveCommonSubGroup { get; set; }
        public bool FeeBased { get; set; }
        public int NextSubElectiveGrpID { get; set; }


        public string errorMessage { get; set; }

	}
}
