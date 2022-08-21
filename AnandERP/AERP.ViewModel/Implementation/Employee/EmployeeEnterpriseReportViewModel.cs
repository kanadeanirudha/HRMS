using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class EmployeeEnterpriseReportViewModel : IEmployeeEnterpriseReportViewModel
    {
        public EmployeeEnterpriseReportViewModel()
        {
            EmployeeEnterpriseReportDTO = new EmployeeEnterpriseReport();
        }

        public EmployeeEnterpriseReport EmployeeEnterpriseReportDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.ID > 0) ? EmployeeEnterpriseReportDTO.ID : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.EmployeeID > 0) ? EmployeeEnterpriseReportDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.EmployeeID = value;
            }
        }
        
        [Display(Name = "DisplayName_EmployeeCode", ResourceType = typeof(AMS.Common.Resources))]        
        public string EmployeeCode
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null) ? EmployeeEnterpriseReportDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeEnterpriseReportDTO.EmployeeCode = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeFirstName", ResourceType = typeof(AMS.Common.Resources))]
        public string EmployeeFirstName
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null) ? EmployeeEnterpriseReportDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                EmployeeEnterpriseReportDTO.EmployeeFirstName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeFullName", ResourceType = typeof(AMS.Common.Resources))]       
        public string EmployeeFullName
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null) ? EmployeeEnterpriseReportDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                EmployeeEnterpriseReportDTO.EmployeeFullName = value;
            }
        }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AMS.Common.Resources))]
        public string CentreCode
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null) ? EmployeeEnterpriseReportDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeEnterpriseReportDTO.CentreCode = value;
            }
        }

        public int DepartmentID
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.DepartmentID > 0) ? EmployeeEnterpriseReportDTO.DepartmentID : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.DepartmentID = value;
            }
        }

        [Display(Name = "DisplayName_DepartmentName", ResourceType = typeof(AMS.Common.Resources))]
        public string DepartmentName
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null) ? EmployeeEnterpriseReportDTO.DepartmentName : string.Empty;
            }
            set
            {
                EmployeeEnterpriseReportDTO.DepartmentName = value;
            }
        }

        public int FacultyCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.FacultyCount > 0) ? EmployeeEnterpriseReportDTO.FacultyCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.FacultyCount = value;
            }
        }

        public int DoctorateCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.DoctorateCount > 0) ? EmployeeEnterpriseReportDTO.DoctorateCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.DoctorateCount = value;
            }
        }

        public int PostGraduationCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.PostGraduationCount > 0) ? EmployeeEnterpriseReportDTO.PostGraduationCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.PostGraduationCount = value;
            }
        }

        public decimal ExperinceInMonthCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.ExperinceInMonthCount > 0) ? EmployeeEnterpriseReportDTO.ExperinceInMonthCount : new decimal();
            }
            set
            {
                EmployeeEnterpriseReportDTO.ExperinceInMonthCount = value;
            }
        }

        public int SpecializationCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.SpecializationCount > 0) ? EmployeeEnterpriseReportDTO.SpecializationCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.SpecializationCount = value;
            }
        }

        public int JournalPaperCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.JournalPaperCount > 0) ? EmployeeEnterpriseReportDTO.JournalPaperCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.JournalPaperCount = value;
            }
        }

        public int MainAuthorCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.MainAuthorCount > 0) ? EmployeeEnterpriseReportDTO.MainAuthorCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.MainAuthorCount = value;
            }
        }

        public int CoAuthorCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.CoAuthorCount > 0) ? EmployeeEnterpriseReportDTO.CoAuthorCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.CoAuthorCount = value;
            }
        }

        public int ConferenceCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.ConferenceCount > 0) ? EmployeeEnterpriseReportDTO.ConferenceCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.ConferenceCount = value;
            }
        }

        public int PublishedBookCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.PublishedBookCount > 0) ? EmployeeEnterpriseReportDTO.PublishedBookCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.PublishedBookCount = value;
            }
        }

        public int SynopsisCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.SynopsisCount > 0) ? EmployeeEnterpriseReportDTO.SynopsisCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.SynopsisCount = value;
            }
        }

        public int ProjectCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.ProjectCount > 0) ? EmployeeEnterpriseReportDTO.ProjectCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.ProjectCount = value;
            }
        }

        public int ElectedBodyMemberCount
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.ElectedBodyMemberCount > 0) ? EmployeeEnterpriseReportDTO.ElectedBodyMemberCount : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.ElectedBodyMemberCount = value;
            }
        }

        [Display(Name = "DisplayName_errorMessage", ResourceType = typeof(AMS.Common.Resources))]
        public string errorMessage
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null) ? EmployeeEnterpriseReportDTO.errorMessage : string.Empty;
            }
            set
            {
                EmployeeEnterpriseReportDTO.errorMessage = value;
            }
        }
               
       
         [Display(Name = "DisplayName_AverageRanking", ResourceType = typeof(AMS.Common.Resources))]
        public decimal AverageRanking
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.AverageRanking > 0) ? EmployeeEnterpriseReportDTO.AverageRanking : new decimal();
            }
            set
            {
                EmployeeEnterpriseReportDTO.AverageRanking = value;
            }
        }

        public int Level
        {
            get
            {
                return (EmployeeEnterpriseReportDTO != null && EmployeeEnterpriseReportDTO.Level > 0) ? EmployeeEnterpriseReportDTO.Level : new int();
            }
            set
            {
                EmployeeEnterpriseReportDTO.Level = value;
            }
        }
        

    }
}
