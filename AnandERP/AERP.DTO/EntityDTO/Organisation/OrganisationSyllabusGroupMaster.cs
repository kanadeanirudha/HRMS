
using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSyllabusGroupMaster : BaseDTO
	{
		public int ID { get; set; }
		public Int16 SubjectTypeNumber { get; set; }
		public string SyllabusDesc { get; set; }
		public bool SyllabusUnitType { get; set; }
		public int SubjectGroupID { get; set; }
		public bool IsActive { get; set; }
		public bool IsDeleted { get; set; }
		public int CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; }
		public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }

        public string SyllabusGrpAndDetailID { get; set; }

        ///<summary>
        ///Properties required for USP_OrgSyllabusGroupMaster_SelectAll 
        ///</summary>


        public string GroupingColumn { get; set; }
        public int BranchID { get; set; }
        public string BranchDescription { get; set; }
        public string BranchShortCode { get; set; }
        public int UniversityID { get; set; }
        public bool IsCommonBranchApplicable { get; set; }
        public string CentreCode { get; set; }
        public int CourseYearID { get; set; }
        public string CourseYearCode { get; set; }
        public int OrgSemesterMstID { get; set; }
        public string SemesterType { get; set; }
        public string OrgSemesterName { get; set; }
        public string OrgSemesterCode { get; set; }
        public int CourseYearSemesterID { get; set; }
        public int OrgSubjectGrpRuleID { get; set; }
        public string RuleName { get; set; }
        public string RuleCode { get; set; }
        public int SessionID { get; set; }
        public int SubjectID { get; set; }
        public int SubjectCombgrpID { get; set; }
        public string SubjectGroupDesc { get; set; }
        public string SubjectGroupShortDesc { get; set; }
        public string SubjectTypeName { get; set; }
        public  bool StatusFlag { get; set; }
        public string SubjectName { get; set; }

        ///<summary>
        ///Properties required for OrgSyllabusGroupDetails
        ///</summary>

        public int SyllabusGroupID { get; set; }
        public int SyllabusGrpDetailsID { get; set; }
        public string UnitDescription { get; set; }
        public string UnitWeightage { get; set; }
        public int UnitPercentage { get; set; }
        public int NoOfLecturesForUnit { get; set; }
        public bool UnitStatus { get; set; }
        public string UnitName { get; set; }

        ///<summary>
        ///Properties required for OrgSyllabusGroupTopics
        ///</summary>

        public int SyllabusGroupDetID { get; set; }
        public int SyllabusGrpTopicsID { get; set; }
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public string TopicWeightage { get; set; }
        public int TopicPercentage { get; set; }
        public int NoOfLecturesForTopic { get; set; }
        public bool TopicStatus { get; set; }

        public string errorMessage { get; set; }
        
	}
}
