using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EmployeeProjectWorksMasterSearchRequest : Request
	{
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
        public decimal FundingAgency
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
        public int EmployeeID { get; set; }
        
	}
}
