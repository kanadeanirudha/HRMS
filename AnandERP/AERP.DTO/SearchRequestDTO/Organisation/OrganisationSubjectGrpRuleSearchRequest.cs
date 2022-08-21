using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSubjectGrpRuleSearchRequest : Request
	{
		public int SubjectRuleGrpNumber
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
		public int OrganisationSessionCryrAllotID
		{
			get;
			set;
		}
		public bool IsActive
		{
			get;
			set;
		}
		public string SortOrder
		{
			get;
			set;
		}
		public string SortBy
		{
			get;
			set;
		}
		public int StartRow
		{
			get;
			set;
		}
		public int RowLength
		{
			get;
			set;
		}
		public int EndRow
		{
			get;
			set;
		}
        public string CentreCode
        {
            get;
            set;
        }
        public int SessionID
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int GroupRuleID { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string ScopeIdentity { get; set; }
        public int AdminRoleMasterID { get; set; }
	}
}
