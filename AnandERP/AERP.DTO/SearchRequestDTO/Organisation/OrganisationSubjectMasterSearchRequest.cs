using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSubjectMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public string SubjectCode
		{
			get;
			set;
		}
		public string Descriptions
		{
			get;
			set;
		}
		public DateTime SubjectIntroYear
		{
			get;
			set;
		}
		public int UniversityID
		{
			get;
			set;
		}
        public int SubjectGrpID
		{
			get;
			set;
		}

		public int LanguageID
		{
			get;
			set;
		}
		public string PaperCode
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
        public int OrgSemesterMstID
        {
            get;
            set;
        }
        public int CourseYearDetailID
        {
            get;
            set;
        }
        public int SubjectRuleGrpNumber
        {
            get;
            set;
        }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
	}
}
