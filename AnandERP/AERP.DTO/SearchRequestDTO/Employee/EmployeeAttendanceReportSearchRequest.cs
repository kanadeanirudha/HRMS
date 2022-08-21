﻿using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeAttendanceReportSearchRequest : Request
    {
        public string CentreCode { get; set; }
        public string CentreName { get; set; }
        public int DepatmentName { get; set; }
        public string DepartmentID { get; set; }
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public string FromDate { get; set; }
        public string UptoDate { get; set; }
        public string AdminRoleMasterID { get; set; }
        public string AttendanceDate { get; set; }
        public string CheckInTime { get; set; }
        public string CheckOutTime { get; set; }
        public string WorkingHour { get; set; }
        public bool IsConsiderForLateMark { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedDate { get; set; }
        public string errorMessage { get; set; }
        public bool IsPosted { get; set; }

        public string SortOrder { get; set; }
        public string SortBy { get; set; }
        public int StartRow { get; set; }
        public int RowLength { get; set; }
        public int EndRow { get; set; }
        public string SearchBy { get; set; }
        public string SortDirection { get; set; }
        public string SearchWord { get; set; }        
    }
}
