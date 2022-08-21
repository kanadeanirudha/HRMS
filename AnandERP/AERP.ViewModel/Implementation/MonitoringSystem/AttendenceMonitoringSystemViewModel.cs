using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class AttendenceMonitoringSystemViewModel : IAttendenceMonitoringSystemViewModel
    {
        public AttendenceMonitoringSystemViewModel()
        {
            AttendenceMonitoringSystemDTO = new AttendenceMonitoringSystem();
            List<AttendenceMonitoringSystem> DataCollection = new List<AttendenceMonitoringSystem>();
        }
        public List<AttendenceMonitoringSystem> DataCollection { get; set; }
        public AttendenceMonitoringSystem AttendenceMonitoringSystemDTO
        {
            get;
            set;
        }

        public string VersionNumber
        {

            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.VersionNumber : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.VersionNumber = value;
            }
        }

        public int ID
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.ID > 0) ? AttendenceMonitoringSystemDTO.ID : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.ID = value;
            }
        }

        public Int64 StartTime
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.StartTime > 0) ? AttendenceMonitoringSystemDTO.StartTime : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.StartTime = value;
            }
        }

        public Int64 EndTime
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.EndTime > 0) ? AttendenceMonitoringSystemDTO.EndTime : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.EndTime = value;
            }
        }


        public int EmployeeID
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.EmployeeID > 0) ? AttendenceMonitoringSystemDTO.EmployeeID : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.EmployeeID = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeCode", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeCode
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.EmployeeCode : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.EmployeeCode = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeFirstName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeFirstName
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.EmployeeFirstName = value;
            }
        }
        [Display(Name = "DisplayName_EmployeeFullName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeFullName
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.EmployeeFullName = value;
            }
        }

        public int TotalEmployeeInDepartment
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.TotalEmployeeInDepartment > 0) ? AttendenceMonitoringSystemDTO.TotalEmployeeInDepartment : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.TotalEmployeeInDepartment = value;
            }
        }
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        public string CentreCode
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.CentreCode : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.CentreCode = value;
            }
        }
        public string CentreName
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.CentreName : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.CentreName = value;
            }
        }
        public int DepartmentID
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.DepartmentID > 0) ? AttendenceMonitoringSystemDTO.DepartmentID : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.DepartmentID = value;
            }
        }
        [Display(Name = "DisplayName_DepartmentName", ResourceType = typeof(AERP.Common.Resources))]
        public string DepartmentName
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.DepartmentName : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.DepartmentName = value;
            }
        }
        public string DeptShortCode
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.DeptShortCode : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.DeptShortCode = value;
            }
        }
        public int DepartmentCount
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.DepartmentCount > 0) ? AttendenceMonitoringSystemDTO.DepartmentCount : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.DepartmentCount = value;
            }
        }
        public int TotalEmployeeInCentre
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.TotalEmployeeInCentre > 0) ? AttendenceMonitoringSystemDTO.TotalEmployeeInCentre : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.TotalEmployeeInCentre = value;
            }
        }
        public int RoleID
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.RoleID > 0) ? AttendenceMonitoringSystemDTO.RoleID : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.RoleID = value;
            }
        }
        public int TotalDaysCount
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.TotalDaysCount > 0) ? AttendenceMonitoringSystemDTO.TotalDaysCount : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.TotalDaysCount = value;
            }
        }
        public int PresentDaysCount
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.PresentDaysCount > 0) ? AttendenceMonitoringSystemDTO.PresentDaysCount : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.PresentDaysCount = value;
            }
        }
        public int AbsentDaysCount
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.AbsentDaysCount > 0) ? AttendenceMonitoringSystemDTO.AbsentDaysCount : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.AbsentDaysCount = value;
            }
        }
        public int HolidaysCount
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.HolidaysCount > 0) ? AttendenceMonitoringSystemDTO.HolidaysCount : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.HolidaysCount = value;
            }
        }
        public int WeeklyoffCount
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.WeeklyoffCount > 0) ? AttendenceMonitoringSystemDTO.WeeklyoffCount : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.WeeklyoffCount = value;
            }
        }
        public decimal AttendencePercentage
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.AttendencePercentage > 0) ? AttendenceMonitoringSystemDTO.AttendencePercentage : new decimal();
            }
            set
            {
                AttendenceMonitoringSystemDTO.AttendencePercentage = value;
            }
        }

        [Display(Name = "DisplayName_errorMessage", ResourceType = typeof(AERP.Common.Resources))]
        public string errorMessage
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null) ? AttendenceMonitoringSystemDTO.errorMessage : string.Empty;
            }
            set
            {
                AttendenceMonitoringSystemDTO.errorMessage = value;
            }
        }


        [Display(Name = "DisplayName_AverageRanking", ResourceType = typeof(AERP.Common.Resources))]
        public decimal AverageRanking
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.AverageRanking > 0) ? AttendenceMonitoringSystemDTO.AverageRanking : new decimal();
            }
            set
            {
                AttendenceMonitoringSystemDTO.AverageRanking = value;
            }
        }

        public int Level
        {
            get
            {
                return (AttendenceMonitoringSystemDTO != null && AttendenceMonitoringSystemDTO.Level > 0) ? AttendenceMonitoringSystemDTO.Level : new int();
            }
            set
            {
                AttendenceMonitoringSystemDTO.Level = value;
            }
        }
    }
}
