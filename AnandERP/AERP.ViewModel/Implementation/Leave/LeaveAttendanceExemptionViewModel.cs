using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveAttendanceExemptionViewModel : ILeaveAttendanceExemptionViewModel
    {
        public LeaveAttendanceExemptionViewModel()
        {
            LeaveAttendanceExemptionDTO = new LeaveAttendanceExemption();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
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

        public LeaveAttendanceExemption LeaveAttendanceExemptionDTO
        {
            get;
            set;
        }
        public int ID
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null && LeaveAttendanceExemptionDTO.ID > 0) ? LeaveAttendanceExemptionDTO.ID : new int();
            }
            set
            {
                LeaveAttendanceExemptionDTO.ID = value;
            }
        }
        public int EmployeeId
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null && LeaveAttendanceExemptionDTO.EmployeeId > 0) ? LeaveAttendanceExemptionDTO.EmployeeId : new int();
            }
            set
            {
                LeaveAttendanceExemptionDTO.EmployeeId = value;
            }
        }
        //[Display(Name="Exemption From Date")]
        //[Required(ErrorMessage = "ExemptionFromDate must be selected")]
        [Display(Name = "DisplayName_ExemptionFromDate", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ExemptionFromdateRequired")]
        public string ExemptionFromDate
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.ExemptionFromDate : string.Empty;
            }
            set
            {
                LeaveAttendanceExemptionDTO.ExemptionFromDate = value;
            }
        }
        //[Display(Name = "Employee Name")]
        //[Required(ErrorMessage = "EmployeeName should not be blank")]
        [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmployeeNameExmptedRequired")]
        public string EmployeeName
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.EmployeeName : string.Empty;
            }
            set
            {
                LeaveAttendanceExemptionDTO.EmployeeName = value;
            }
        }
         [Display(Name = "DisplayName_ExemptionUpTodate", ResourceType = typeof(AERP.Common.Resources))]
         //[Display(Name = "Exemption UpTo Date")]
        public string ExemptionUpToDate
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.ExemptionUpToDate : string.Empty;
            }
            set
            {
                LeaveAttendanceExemptionDTO.ExemptionUpToDate = value;
            }
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string CentreCode
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveAttendanceExemptionDTO.CentreCode = value;
            }
        }
       // [Display(Name = "Centre")]
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_TaxNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveAttendanceExemptionDTO.CentreName = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.StatusFlag : false;
            }
            set
            {
                LeaveAttendanceExemptionDTO.StatusFlag = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.IsDeleted : false;
            }
            set
            {
                LeaveAttendanceExemptionDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null && LeaveAttendanceExemptionDTO.CreatedBy > 0) ? LeaveAttendanceExemptionDTO.CreatedBy : new int();
            }
            set
            {
                LeaveAttendanceExemptionDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceExemptionDTO.CreatedDate = value;
            }
        }
        public int ModifiedBy
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null && LeaveAttendanceExemptionDTO.ModifiedBy > 0) ? LeaveAttendanceExemptionDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveAttendanceExemptionDTO.ModifiedBy = value;
            }
        }
        public DateTime ModifiedDate
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceExemptionDTO.ModifiedDate = value;
            }
        }
        public int DeletedBy
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null && LeaveAttendanceExemptionDTO.DeletedBy > 0) ? LeaveAttendanceExemptionDTO.DeletedBy : new int();
            }
            set
            {
                LeaveAttendanceExemptionDTO.DeletedBy = value;
            }
        }
        public DateTime DeletedDate
        {
            get
            {
                return (LeaveAttendanceExemptionDTO != null) ? LeaveAttendanceExemptionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveAttendanceExemptionDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        public string EntityLevel { get; set; }
    }
}
