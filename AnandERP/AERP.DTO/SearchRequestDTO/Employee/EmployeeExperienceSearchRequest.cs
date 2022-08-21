using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeExperienceSearchRequest : Request
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
        public DateTime ExperienceFromYear
        {
            get;
            set;
        }
        public DateTime ExperienceToYear
        {
            get;
            set;
        }
        public Int16 ExperienceInMonth
        {
            get;
            set;
        }
        public string PreviousOrganisationanisationName
        {
            get;
            set;
        }
        public string PreviousOrganisationnisationAddress
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
        public string AppointmentOrderNumber
        {
            get;
            set;
        }
        public DateTime AppointmentOrderDate
        {
            get;
            set;
        }
        public string UniversityApprovalNumber
        {
            get;
            set;
        }
        public DateTime UniversityApprovalDate
        {
            get;
            set;
        }
        public int GeneralBoardUniversityID
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
    }
}
