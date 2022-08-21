using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveEmployeeApplicationStatusReportViewModel : ILeaveEmployeeApplicationStatusReportViewModel
    {
        public LeaveEmployeeApplicationStatusReportViewModel()
        {
            LeaveEmployeeApplicationStatusReportDTO = new LeaveEmployeeApplicationStatusReport();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListGetOrganisationDepartmentCentreAndRoleWise = new List<OrganisationDepartmentMaster>();
        }

        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public List<OrganisationDepartmentMaster> ListGetOrganisationDepartmentCentreAndRoleWise
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetOrganisationDepartmentCentreAndRoleWiseItems
        {
            get
            {
                return new SelectList(ListGetOrganisationDepartmentCentreAndRoleWise, "ID", "DepartmentName");
            }
        }
        public LeaveEmployeeApplicationStatusReport LeaveEmployeeApplicationStatusReportDTO
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.DepartmentName : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.DepartmentName = value;
            }
        }
        public string EmployeeFullName
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.EmployeeFullName = value;
            }
        }
      public string LeaveType
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.LeaveType : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.LeaveType = value;
            }
        }
      public string ApplicationDate
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.ApplicationDate : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.ApplicationDate = value;
            }
        }
      
        public string errorMessage { get; set; }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.CentreName = value;
            }
        }
    

        public string EntityLevel { get; set; }

        public int DepartmentID
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null && LeaveEmployeeApplicationStatusReportDTO.DepartmentID > 0) ? LeaveEmployeeApplicationStatusReportDTO.DepartmentID : new int();
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.DepartmentID = value;
            }
        }
      
        public string Dates
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.Dates : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.Dates = value;
            }
        }
        public string ApprovalStatus
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.ApprovalStatus : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.ApprovalStatus = value;
            }
        }
        public string FullDayHalfDayStatus
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.FullDayHalfDayStatus : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.FullDayHalfDayStatus = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.FromDate : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (LeaveEmployeeApplicationStatusReportDTO != null) ? LeaveEmployeeApplicationStatusReportDTO.UptoDate : string.Empty;
            }
            set
            {
                LeaveEmployeeApplicationStatusReportDTO.UptoDate = value;
            }
        }
        

        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public string SelectedDepartmentID
        {
            get;
            set;
        }
        public string SelectedDepartmentIDs
        {
            get;
            set;
        }
    }
}
