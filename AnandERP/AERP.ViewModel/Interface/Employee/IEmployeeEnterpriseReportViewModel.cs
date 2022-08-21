using AMS.DTO;
using System;
using System.Collections.Generic;

namespace AMS.ViewModel
{
    public interface IEmployeeEnterpriseReportViewModel
    {
        EmployeeEnterpriseReport EmployeeEnterpriseReportDTO
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
         string CentreCode
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
         int FacultyCount
        {
            get;
            set;
        }
         int DoctorateCount
        {
            get;
            set;
        }
         int PostGraduationCount
        {
            get;
            set;
        }
         decimal ExperinceInMonthCount
        {
            get;
            set;
        }
         int SpecializationCount
        {
            get;
            set;
        }
         int JournalPaperCount
        {
            get;
            set;
        }
         int MainAuthorCount
        {
            get;
            set;
        }
         int CoAuthorCount
        {
            get;
            set;
        }
         int ConferenceCount
        {
            get;
            set;
        }
         int PublishedBookCount
        {
            get;
            set;
        }
         int SynopsisCount
        {
            get;
            set;
        }
         int ProjectCount
        {
            get;
            set;
        }
         int ElectedBodyMemberCount
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
    }
}
