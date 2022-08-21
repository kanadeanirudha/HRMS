using AERP.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class ManualAttendanceStatusReportViewModel
    {
        public ManualAttendanceStatusReportViewModel()
        {
            ManualAttendanceStatusReportDTO = new ManualAttendanceStatusReport();
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
        public ManualAttendanceStatusReport ManualAttendanceStatusReportDTO
        {
            get;
            set;
        }

        public string DepartmentName
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.DepartmentName : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.DepartmentName = value;
            }
        }

        public string Reason
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.Reason : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.Reason = value;
            }
        }
        public string EmployeeFullName
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.EmployeeFullName = value;
            }
        }
        public string LeaveType
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.LeaveType : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.LeaveType = value;
            }
        }
        public string ApplicationDate
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.ApplicationDate : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.ApplicationDate = value;
            }
        }

        public string errorMessage { get; set; }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.CentreCode : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.CentreName : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.CentreName = value;
            }
        }


        public string EntityLevel { get; set; }

        public int DepartmentID
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null && ManualAttendanceStatusReportDTO.DepartmentID > 0) ? ManualAttendanceStatusReportDTO.DepartmentID : new int();
            }
            set
            {
                ManualAttendanceStatusReportDTO.DepartmentID = value;
            }
        }

        public string Dates
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.Dates : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.Dates = value;
            }
        }
        public string ApprovalStatus
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.ApprovalStatus : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.ApprovalStatus = value;
            }
        }
        public string FullDayHalfDayStatus
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.FullDayHalfDayStatus : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.FullDayHalfDayStatus = value;
            }
        }
        public string FromDate
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.FromDate : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.FromDate = value;
            }
        }
        public string UptoDate
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.UptoDate : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.UptoDate = value;
            }
        }

        public string CheckInTime
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.CheckInTime : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.CheckInTime = value;
            }
        }
        public string CheckOutTime
        {
            get
            {
                return (ManualAttendanceStatusReportDTO != null) ? ManualAttendanceStatusReportDTO.CheckOutTime : string.Empty;
            }
            set
            {
                ManualAttendanceStatusReportDTO.CheckOutTime = value;
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
