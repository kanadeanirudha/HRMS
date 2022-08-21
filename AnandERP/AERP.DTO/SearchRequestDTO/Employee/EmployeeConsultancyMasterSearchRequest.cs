using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EmployeeConsultancyMasterSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
        public string ConsultancyDate
		{
			get;
			set;
		}
		public string ConsultancyName
		{
			get;
			set;
		}
		public string TitleOfAssignment
		{
			get;
			set;
		}
		public decimal ConsultancyCost
		{
			get;
			set;
		}
        public decimal EmployeeShare
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
		public string Remarks
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
        public string CentreCode { get; set; }
	}
}
