using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveAttendanceSpanLockViewModel : ILeaveAttendanceSpanLockViewModel
    {
        public LeaveAttendanceSpanLockViewModel()
        {
            LeaveAttendanceSpanLockDTO = new LeaveAttendanceSpanLock();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
            ListLeaveAttendanceSpanLock = new List<LeaveAttendanceSpanLock>();
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
        public LeaveAttendanceSpanLock LeaveAttendanceSpanLockDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.ID > 0) ? LeaveAttendanceSpanLockDTO.ID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.ID = value;
            }
        }
        public int MaxID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.MaxID > 0) ? LeaveAttendanceSpanLockDTO.MaxID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.MaxID = value;
            }
        }
        public int IsSpanLockCount
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.IsSpanLockCount > 0) ? LeaveAttendanceSpanLockDTO.IsSpanLockCount : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.IsSpanLockCount = value;
            }
        }

        [Display(Name = "DisplayName_SpanFromDate", ResourceType = typeof(AERP.Common.Resources))]
         [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SpanFromDateRequired")]
        //[Display(Name = "Span From Date")]
        //[Required(ErrorMessage = "Please select Span From Date.")]
        public string SpanFromDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.SpanFromDate : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.SpanFromDate = value;
            }
        }
        [Display(Name = "DisplayName_SpanUptoDate", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SpanUptoDateRequired")]

         //[Display(Name = "Span Upto Date")]
         //[Required(ErrorMessage = "Please select Span Upto Date.")]
        public string SpanUptoDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.SpanUptoDate : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.SpanUptoDate = value;
            }
        }
        public bool IsSpanLock
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.IsSpanLock : false;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.IsSpanLock = value;
            }
        }
        public bool IsDescripancyRemoved
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.IsDescripancyRemoved : false;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.IsDescripancyRemoved = value;
            }
        }
        public bool IsLateMarkProccessed
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.IsLateMarkProccessed : false;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.IsLateMarkProccessed = value;
            }
        }
        public int TaskDoneByEmployee
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.TaskDoneByEmployee > 0) ? LeaveAttendanceSpanLockDTO.TaskDoneByEmployee : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.TaskDoneByEmployee = value;
            }
        }
        public int ApprovedByUserID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.ApprovedByUserID > 0) ? LeaveAttendanceSpanLockDTO.ApprovedByUserID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.ApprovedByUserID = value;
            }
        }
        //[Display(Name = "DisplayName_TaskDoneDate", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TaskDoneDateRequired")]
        public string TaskDoneDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.TaskDoneDate : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.TaskDoneDate = value;
            }
        }

        // [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.IsActive : false;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.IsActive = value;
            }
        }
        // [Display(Name = "DisplayName_IsDeleted", ResourceType = typeof(AMS.Common.Resources))]
        public bool IsDeleted
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.IsDeleted : false;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.CreatedBy > 0) ? LeaveAttendanceSpanLockDTO.CreatedBy : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.ModifiedBy.HasValue) ? LeaveAttendanceSpanLockDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.ModifiedDate.HasValue) ? LeaveAttendanceSpanLockDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.DeletedBy.HasValue) ? LeaveAttendanceSpanLockDTO.DeletedBy : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.DeletedDate.HasValue) ? LeaveAttendanceSpanLockDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }

        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreCodeRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.CentreName = value;
            }
        }


        public string EntityLevel { get; set; }



        //--------------------------------------- Properties for Discrepancy ---------------------------------------//

        [Required(ErrorMessage = "Department name is required")]
        public List<OrganisationDepartmentMaster> ListOrganisationDepartmentMaster
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListOrganisationDepartmentMasterItems
        {
            get
            {

                return new SelectList(ListOrganisationDepartmentMaster, "DeptID", "DepartmentName");
            }
        }

        [Display(Name = "DisplayName_DepartmentName", ResourceType = typeof(AERP.Common.Resources))]
        public int DepartmentID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.DepartmentID > 0) ? LeaveAttendanceSpanLockDTO.DepartmentID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.DepartmentID = value;
            }
        }
       
        public string DepartmentName
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.DepartmentName : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.DepartmentName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AERP.Common.Resources))]
        public int EmployeeID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.EmployeeID > 0) ? LeaveAttendanceSpanLockDTO.EmployeeID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.EmployeeID = value;
            }
        }

        public string EmployeeName
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.EmployeeName : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.EmployeeName = value;
            }
        }

       // [Display(Name = "DisplayName_SpanDurationID", ResourceType = typeof(AMS.Common.Resources))]
        public int SalarySpanID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.SalarySpanID > 0) ? LeaveAttendanceSpanLockDTO.SalarySpanID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.SalarySpanID = value;
            }
        }

        public string SalarySpan
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.SalarySpan : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.SalarySpan = value;
            }
        }

        [Required(ErrorMessage = "You must select salary span")]
        public List<LeaveAttendanceSpanLock> ListLeaveAttendanceSpanLock
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListGetSalarySpanItems
        {
            get
            {
                return new SelectList(ListLeaveAttendanceSpanLock, "ID", "SalarySpan");
            }
        }

        public string AttendanceDate
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.AttendanceDate : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.AttendanceDate = value;
            }
        }

        public string CheckInTime
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.CheckInTime : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.CheckInTime = value;
            }
        }

        public string CheckOutTime
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.CheckOutTime : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.CheckOutTime = value;
            }
        }
        
        public int LeaveEmployeeAttendanceMasterID
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null && LeaveAttendanceSpanLockDTO.LeaveEmployeeAttendanceMasterID > 0) ? LeaveAttendanceSpanLockDTO.LeaveEmployeeAttendanceMasterID : new int();
            }
            set
            {
                LeaveAttendanceSpanLockDTO.LeaveEmployeeAttendanceMasterID = value;
            }
        }

        public string Remark
        {
            get
            {
                return (LeaveAttendanceSpanLockDTO != null) ? LeaveAttendanceSpanLockDTO.Remark : string.Empty;
            }
            set
            {
                LeaveAttendanceSpanLockDTO.Remark = value;
            }
        }
        
    }
}
