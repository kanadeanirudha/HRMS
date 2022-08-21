using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class LeaveAttendanceSpanLock : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public int MaxID
        {
            get;
            set;
        }
        public int IsSpanLockCount
        {
            get;
            set;
        }
        public string SpanFromDate
        {
            get;
            set;
        }
        public string SpanUptoDate
        {
            get;
            set;
        }
        public bool IsSpanLock
        {
            get;
            set;
        }
        public bool IsDescripancyRemoved
        {
            get;
            set;
        }
        public bool IsLateMarkProccessed
        {
            get;
            set;
        }
        public int TaskDoneByEmployee
        {
            get;
            set;
        }
        public string TaskDoneDate
        {
            get;
            set;
        }
        public int ApprovedByUserID
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName
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

        public int DepartmentID
        {
            get;
            set;
        }

        public string DepartmentName { get; set; }

        public int EmployeeID
        {
            get;
            set;
        }

        public string EmployeeName { get; set; }

        public int SalarySpanID
        {
            get;
            set;
        }

        public string SalarySpan { get; set; }

        public string AttendanceDate { get; set; }

        public string CheckInTime { get; set; }

        public string CheckOutTime { get; set; }

        public int LeaveEmployeeAttendanceMasterID { get; set; }

        public string Remark { get; set; }
    }
}
