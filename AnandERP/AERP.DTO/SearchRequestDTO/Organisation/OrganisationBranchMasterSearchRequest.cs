using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class OrganisationBranchMasterSearchRequest : Request
	{
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
		public DateTime IntroductionYear
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
		public string CommonBranch
		{
			get;
			set;
		}
		public int DurationInDays
		{
			get;
			set;
		}
		public int UniversityID
		{
			get;
			set;
		}
		public string DteCodeShortDesc
		{
			get;
			set;
		}
		public int StreamID
		{
			get;
			set;
		}
		public bool IsCommonBranchApplicable
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
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string ScopeIdentity { get; set; }
        public int AdminRoleMasterID { get; set; }
        public string CentreCode { get; set; }
        public string isFirstYearPromotion { get; set; }
	}
}
