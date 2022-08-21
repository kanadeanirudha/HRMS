using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class AttendenceMonitoringSystem : BaseDTO
    {
        public string VersionNumber { get; set; }

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

        public Int64 StartTime
        {
            get;
            set;
        }

        public Int64 EndTime
        {
            get;
            set;
        }

        public string EmployeeCode
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeFullName
        {
            get;
            set;
        }
        public int TotalEmployeeInDepartment
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
        public int DepartmentID
        {
            get;
            set;
        }
        public string DepartmentName
        {
            get;
            set;
        }
        public string DeptShortCode
        {
            get;
            set;
        }
        public int DepartmentCount
        {
            get;
            set;
        }
        public int TotalEmployeeInCentre
        {
            get;
            set;
        }
        public string errorMessage
        {
            get;
            set;
        }
        public decimal AverageRanking
        {
            get;
            set;
        }
        public int Level
        {
            get;
            set;
        }
        public int RoleID { get; set; }
        public int TotalDaysCount { get; set; } 
        public int PresentDaysCount { get; set; }
        public int AbsentDaysCount { get; set; } 
        public int HolidaysCount { get; set; }   
        public int WeeklyoffCount { get; set; }
        public decimal AttendencePercentage { get; set; }  
        public string EventTitle
        {
            get;
            set;
        } 
        public DateTime EventeStartDate
        {
            get;
            set;
        }  
        public DateTime EventeEndDate
        {
            get;
            set;
        }
        public DateTime AttendanceDate
        {
            get;
            set;
        }
        public DateTime ApplicationDate
        {
            get;
            set;
        }
        public string AttendanceStatus
        {
            get;
            set;
        }
        public bool WeeklyOffStatus
        {
            get;
            set;
        }
        public bool ApplicationStatus
        {
            get;
            set;
        }
        public bool FullDayHalfDayFlag
        {
            get;
            set;
        }
        public string HalfLeaveStatus
        {
            get;
            set;
        }
        public string LeaveCode
        {
            get;
            set;
        }
        public bool ApprovalStatus
        {
            get;
            set;
        }
        public string EventColor
        {
            get;
            set;
        }
        public string AttendanceDescription
        {
            get;
            set;
        }
         public string HolidayDescription
        {
            get;
            set;
        } 
        public string EventBackgroundColor
        {
            get;
            set;
        } 
        public string EventBorderColor
        {
            get;
            set;
        }
        public int UnInformedDaysCount { get; set; }
        public int LWPCount { get; set; }
        public int InformedLeavesCount { get; set; }
        public string CheckInTime
        {
            get;
            set;
        }
        public string CheckOutTime
        {
            get;
            set;
        }
        public string WorkingHour
        {
            get;
            set;
        }
    }
}
