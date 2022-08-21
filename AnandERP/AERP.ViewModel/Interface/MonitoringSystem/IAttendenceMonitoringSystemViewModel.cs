using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IAttendenceMonitoringSystemViewModel
    {
        AttendenceMonitoringSystem AttendenceMonitoringSystemDTO
        {
            get;
            set;
        }
         int ID
        {
            get;
            set;
        }
         int EmployeeID
        {
            get;
            set;
        }
         string EmployeeCode
        {
            get;
            set;
        }
         string EmployeeFirstName
        {
            get;
            set;
        }
         string EmployeeFullName
        {
            get;
            set;
        }
         int TotalEmployeeInDepartment
        {
            get;
            set;
        }
        int TotalDaysCount
        {
            get;
            set;
        }
        int PresentDaysCount
        {
            get;
            set;
        }int AbsentDaysCount
        {
            get;
            set;
        }int HolidaysCount
        {
            get;
            set;
        }int WeeklyoffCount
        {
            get;
            set;
        }
        decimal AttendencePercentage
        {
            get;
            set;
        }                                    
                                            
                                            
                                            
                                             
         string CentreCode
        {
            get;
            set;
        }
         string CentreName
        {
            get;
            set;
        }
         int DepartmentID
        {
            get;
            set;
        }
         string DepartmentName
        {
            get;
            set;
        }
         string DeptShortCode
        {
            get;
            set;
        }
         int DepartmentCount
        {
            get;
            set;
        }
         int TotalEmployeeInCentre
        {
            get;
            set;
        }
         string errorMessage
        {
            get;
            set;
        }
         decimal AverageRanking
        {
            get;
            set;
        }
         int Level
        {
            get;
            set;
        }
         int RoleID { get; set; }
         List<AttendenceMonitoringSystem> DataCollection { get; set; }
    }
}
