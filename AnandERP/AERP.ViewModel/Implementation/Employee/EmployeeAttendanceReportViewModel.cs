using AMS.Common;
using AMS.DTO;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AMS.ViewModel
{
    public class EmployeeAttendanceReportViewModel : IEmployeeAttendanceReportViewModel
    {
        public EmployeeAttendanceReportViewModel()
        {
            EmployeeAttendanceReportDTO = new EmployeeAttendanceReport();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListGetCentreEmployeeName = new List<EmployeeAttendanceReport>();
            ListEmployeeAttendanceReportData = new List<EmployeeAttendanceReport>();
        }

        public EmployeeAttendanceReport EmployeeAttendanceReportDTO { get; set; }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre { get; set; }
        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster { get; set; }
        public List<EmployeeAttendanceReport> ListGetCentreEmployeeName { get; set; }
        public List<EmployeeAttendanceReport> ListEmployeeAttendanceReportData { get; set; }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }

        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationDepartmentMaster, "ID", "DepartmentName");
            }
        }

        public IEnumerable<SelectListItem> ListGetCentreEmployeeNameItems
        {
            get
            {
                return new SelectList(ListGetCentreEmployeeName, "EmployeeID", "EmployeeName");
            }
        }

        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        
        public string CentreName
        {
            get
            {
                return (EmployeeAttendanceReportDTO.CentreName != null && EmployeeAttendanceReportDTO.CentreName != "") ? EmployeeAttendanceReportDTO.CentreName : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.CentreName = value;
            }
        }

        [Display(Name = "Centre Name ")]        
        public string CentreCode
        {
            get
            {
                return (EmployeeAttendanceReportDTO.CentreCode != null && EmployeeAttendanceReportDTO.CentreCode != "") ? EmployeeAttendanceReportDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.CentreCode = value;
            }
        }
                
        public string DepatmentName
        {
            get
            {
                return (EmployeeAttendanceReportDTO.DepatmentName != null && EmployeeAttendanceReportDTO.DepatmentName != "") ? EmployeeAttendanceReportDTO.DepatmentName : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.DepatmentName = value;
            }
        }

        [Display(Name = "Department Name")]
        public string DepartmentID
        {
            get
            {
                return (EmployeeAttendanceReportDTO.DepartmentID != null && EmployeeAttendanceReportDTO.DepartmentID != "") ? EmployeeAttendanceReportDTO.DepartmentID : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.DepartmentID = value;
            }
        }

        [Display(Name = "Employee Name")]
        public int EmployeeID
        {
            get
            {
                return (EmployeeAttendanceReportDTO.EmployeeID > 0) ? EmployeeAttendanceReportDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeAttendanceReportDTO.EmployeeID = value;
            }
        }
                
        public string EmployeeName
        {
            get
            {
                return (EmployeeAttendanceReportDTO.EmployeeName != null && EmployeeAttendanceReportDTO.EmployeeName != "") ? EmployeeAttendanceReportDTO.EmployeeName : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.EmployeeName = value;
            }
        }

        public string EmployeeCode
        {
            get
            {
                return (EmployeeAttendanceReportDTO.EmployeeCode != null && EmployeeAttendanceReportDTO.EmployeeCode != "") ? EmployeeAttendanceReportDTO.EmployeeCode : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.EmployeeCode = value;
            }
        }

        [Display(Name = "From Date")]
        public string FromDate
        {
            get
            {
                return (EmployeeAttendanceReportDTO.FromDate != null && EmployeeAttendanceReportDTO.FromDate != "") ? EmployeeAttendanceReportDTO.FromDate : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.FromDate = value;
            }
        }
        [Display(Name = "Upto Date")]
        public string UptoDate
        {
            get
            {
                return (EmployeeAttendanceReportDTO.UptoDate != null && EmployeeAttendanceReportDTO.UptoDate != "") ? EmployeeAttendanceReportDTO.UptoDate : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.UptoDate = value;
            }
        }

        public string AdminRoleMasterID
        {
            get
            {
                return (EmployeeAttendanceReportDTO.AdminRoleMasterID != null && EmployeeAttendanceReportDTO.AdminRoleMasterID != "") ? EmployeeAttendanceReportDTO.AdminRoleMasterID : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.AdminRoleMasterID = value;
            }
        }

        public bool IsActive
        {
            get
            {
                return (EmployeeAttendanceReportDTO.IsActive != false) ? EmployeeAttendanceReportDTO.IsActive : false;
            }
            set
            {
                EmployeeAttendanceReportDTO.IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (EmployeeAttendanceReportDTO.IsDeleted != false) ? EmployeeAttendanceReportDTO.IsDeleted : false;
            }
            set
            {
                EmployeeAttendanceReportDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (EmployeeAttendanceReportDTO.CreatedBy > 0) ? EmployeeAttendanceReportDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeAttendanceReportDTO.CreatedBy = value;
            }
        }

        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeAttendanceReportDTO.CreatedDate != null) ? EmployeeAttendanceReportDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeAttendanceReportDTO.CreatedDate = value;
            }
        }

        public int? ModifiedBy
        {
            get
            {
                return (EmployeeAttendanceReportDTO.ModifiedBy > 0) ? EmployeeAttendanceReportDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeAttendanceReportDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeAttendanceReportDTO.ModifiedDate != null) ? EmployeeAttendanceReportDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeAttendanceReportDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Delete By")]
        public Nullable<int> DeletedBy
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null && EmployeeAttendanceReportDTO.DeletedBy > 0) ? EmployeeAttendanceReportDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeAttendanceReportDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Delete Date")]
        public Nullable<DateTime> DeletedDate
        {
            get
            {
                return (EmployeeAttendanceReportDTO.DeletedDate != null && EmployeeAttendanceReportDTO.DeletedDate.HasValue) ? EmployeeAttendanceReportDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeAttendanceReportDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null && EmployeeAttendanceReportDTO.errorMessage != "") ? EmployeeAttendanceReportDTO.errorMessage : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.errorMessage = value;
            }
        }

        public bool IsPosted
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null) ? EmployeeAttendanceReportDTO.IsPosted : false;
            }
            set
            {
                EmployeeAttendanceReportDTO.IsPosted = value;
            }
        }

        public string AttendanceDate 
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null && EmployeeAttendanceReportDTO.AttendanceDate != "") ? EmployeeAttendanceReportDTO.AttendanceDate : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.AttendanceDate = value;
            }
        }

        public string CheckInTime 
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null && EmployeeAttendanceReportDTO.CheckInTime != "") ? EmployeeAttendanceReportDTO.CheckInTime : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.CheckInTime = value;
            } 
        }
        public string CheckOutTime
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null && EmployeeAttendanceReportDTO.CheckInTime != "") ? EmployeeAttendanceReportDTO.CheckInTime : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.CheckInTime = value;
            }
        }

        public string WorkingHour
        {
            get
            {
                return (EmployeeAttendanceReportDTO != null && EmployeeAttendanceReportDTO.WorkingHour != "") ? EmployeeAttendanceReportDTO.WorkingHour : string.Empty;
            }
            set
            {
                EmployeeAttendanceReportDTO.WorkingHour = value;
            }
        }
        
        public bool IsConsiderForLateMark
        {
            get
            {
                return EmployeeAttendanceReportDTO != null ? EmployeeAttendanceReportDTO.IsConsiderForLateMark : false;
            }
            set
            {
                EmployeeAttendanceReportDTO.IsConsiderForLateMark = value;
            }
        }
    }
}
