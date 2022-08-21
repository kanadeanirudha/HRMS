using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationSyllabusGroupMasterSearchRequest : Request
	{
        public int SyllabusGroupID
		{
			get;
			set;
		}
        public int SyllabusGroupDetID { get; set; }
		public Int16 SubjectTypeMaster
		{
			get;
			set;
		}
		public string SyllabusDesc
		{
			get;
			set;
		}
		public bool SyllabusUnitType
		{
			get;
			set;
		}
		public int SubjectGroupID
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
        public string ScopeIdentity
        {
            get;
            set;
        }
        public int AdminRoleMasterID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int UniversityID
        {
            get;
            set;
        }
        public int SessionID { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string SyllabusGrpAndDetailID { get; set; }
	}
}
