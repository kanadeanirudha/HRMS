using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
	public class EmployeePHdGuideRecognisationDetails : BaseDTO
	{
        //---------------------------------------   EmployeePHdGuideRecognisationDetails Properties  ------------------------------------------//
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

        //---------------------------------------   EmployeePHdGuideStudentsDetails  Properties  ------------------------------------------//
        public int EmployeePHdGuideStudentsDetailsID
        {
            get;
            set;
        }
        public string StudentName
        {
            get;
            set;
        }
        public string Synopsis
        {
            get;
            set;
        }
        public string PersuingFromDate
        {
            get;
            set;
        }
        public string PersuingUptoDate
        {
            get;
            set;
        }
        public string ApprovalStatus
        {
            get;
            set;
        }
        public string ApprovalDate
        {
            get;
            set;
        }
        public string EmployeePHdGuideStudentsDetailsRemarks
        {
            get;
            set;
        }
        public bool StatusFlag { get; set; }
        public string errorMessage { get; set; }

	}
}
