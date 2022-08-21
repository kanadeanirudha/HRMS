using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
	public class EmployeeExperience : BaseDTO
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
        public string ExperienceFromYear
		{
			get;
			set;
		}
        public string ExperienceToYear
		{
			get;
			set;
		}
        public Int16 ExperienceInMonth
		{
			get;
			set;
		}
		public string PreviousOrganisationName
		{
			get;
			set;
		}
		public string PreviousOrganisationAddress
		{
			get;
			set;
		}
		public string Designation
		{
			get;
			set;
		}
		public string Remarks
		{
			get;
			set;
		}
		public int GeneralExperienceTypeMasterID
		{
			get;
			set;
		}
        public string GeneralExperienceType
        {
            get;
            set;
        }
		public string LastPayDrawnPayScale
		{
			get;
			set;
		}
		public string NatureOfAppointment
		{
			get;
			set;
		}
		public int GeneralJobStatusID
		{
			get;
			set;
		}
        public string GeneralJobStatus
        {
            get;
            set;
        }
        public string AppointmentOrderNumber
		{
			get;
			set;
		}
        public string AppointmentOrderDate
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
		public int GeneralBoardUniversityID
		{
			get;
			set;
		}
        public string GeneralBoardUniversityName
        {
            get;
            set;
        }
		public string SubjectForApproval
		{
			get;
			set;
		}
		public string UniversityApprovalType
		{
			get;
			set;
		}
		public Int16 MonthOfApproval
		{
			get;
			set;
		}
		public Int16 YearOfApproval
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
        public string errorMessage { get; set; }
	}
}
