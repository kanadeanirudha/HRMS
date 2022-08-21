using AMS.DTO;
using System;

namespace AMS.ViewModel
{
    public interface IEmployeeAttendanceReportViewModel
    {
        EmployeeAttendanceReport EmployeeAttendanceReportDTO { get; set; }

        string CentreCode { get; set; }
        string CentreName { get; set; }
        string DepatmentName { get; set; }
        string DepartmentID { get; set; }
        int EmployeeID { get; set; }
        string EmployeeName { get; set; }
        string EmployeeCode { get; set; }
        string FromDate { get; set; }
        string UptoDate { get; set; }
        string AdminRoleMasterID { get; set; }
        string AttendanceDate { get; set; }
        string CheckInTime { get; set; }
        string CheckOutTime { get; set; }
        string WorkingHour { get; set; }
        bool IsConsiderForLateMark { get; set; }
        bool IsPosted { get; set; }

        bool IsActive { get; set; }
        bool IsDeleted { get; set; }
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
        int? DeletedBy { get; set; }
        DateTime? DeletedDate { get; set; }
        string errorMessage { get; set; }
    }
}
