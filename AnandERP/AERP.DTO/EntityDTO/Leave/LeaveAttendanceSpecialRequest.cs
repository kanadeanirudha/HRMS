using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveAttendanceSpecialRequest : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeAttendanceID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public bool AttendanceStatus
        {
            get;
            set;
        }
        public string RequestedDate { get; set; }

        public string URL { get; set; }
        public TimeSpan CommingTime
        {
            get;
            set;
        }
        public TimeSpan LeavingTime
        {
            get;
            set;
        }
        public string StatusFlag
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public int ApprovedByUserID
        {
            get;
            set;
        }
        public int EmployeeShiftMasterID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string UpdatedInEmployeeAttendance
        {
            get;
            set;
        }
        public string ApprovalStatus
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
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string EmployeeName { get; set; }
    }
}
