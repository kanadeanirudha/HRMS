using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveManualAttendance : BaseDTO
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
        public string AttendanceDate
        {
            get;
            set;
        }

        public string URL
        {
            get;
            set;
        }
        public string AttendenceFor
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }

        public TimeSpan CheckInTime
        {
            get;
            set;
        }
        public TimeSpan CheckOutTime
        {
            get;
            set;
        }
        public string Reason
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
        public int ApprovedByUSerID
        {
            get;
            set;
        }
        public bool IsWorkFlow
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
