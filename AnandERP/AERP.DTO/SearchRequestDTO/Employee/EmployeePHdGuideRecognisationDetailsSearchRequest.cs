using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EmployeePHdGuideRecognisationDetailsSearchRequest : Request
	{
		public int ID
		{
			get;
			set;
		}
		public int EmployeeID
		{
			get;
			set;
		}
		public int GeneralBoardUniversityID
		{
			get;
			set;
		}
		public string ApprovalSubjectName
		{
			get;
			set;
		}
        public string ApprovalFromDate
		{
			get;
			set;
		}
        public string ApprovalUptoDate
		{
			get;
			set;
		}
		public string UniversityApprovalNumber
		{
			get;
			set;
		}
        public string UniversityApprovalDate
		{
			get;
			set;
		}
		public int NoOfCandidateCompletedPHd
		{
			get;
			set;
		}
		public int NumberOfCandidateRegistered
		{
			get;
			set;
		}
		public string Remarks
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
        public string CentreCode { get; set; }
	}
}
