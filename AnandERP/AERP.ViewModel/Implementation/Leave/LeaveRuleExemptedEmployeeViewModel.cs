using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class LeaveRuleExemptedEmployeeViewModel : ILeaveRuleExemptedEmployeeViewModel
    {
        public LeaveRuleExemptedEmployeeViewModel()
        {
            LeaveRuleExemptedEmployeeDTO = new LeaveRuleExemptedEmployee();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
        }

        public LeaveRuleExemptedEmployee LeaveRuleExemptedEmployeeDTO
        {
            get;
            set;
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
        public int ID
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.ID > 0) ? LeaveRuleExemptedEmployeeDTO.ID : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.ID = value;
            }
        }

         [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AERP.Common.Resources))]
       // [Display(Name = "Employee Name")]
        public int EmployeeID
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.EmployeeID > 0) ? LeaveRuleExemptedEmployeeDTO.EmployeeID : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.EmployeeID = value;
            }
        }

       // [Display(Name = "Employee Full Name")]
        [Display(Name = "DisplayName_EmployeeFullName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeFullName
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.EmployeeFullName : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.EmployeeFullName = value;
            }
        }
        public string LeaveRuleIDs
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.LeaveRuleIDs : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.LeaveRuleIDs = value;
            }
        }
        [Display(Name = "Leave Type")]
        public int LeaveMasterID
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.LeaveMasterID > 0) ? LeaveRuleExemptedEmployeeDTO.LeaveMasterID : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.LeaveMasterID = value;
            }
        }

        public string DepartmentName
         {
             get
             {
                 return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.DepartmentName : string.Empty;
             }
             set
             {
                 LeaveRuleExemptedEmployeeDTO.DepartmentName = value;
             }
         }
       
          [Display(Name = "DisplayName_LeaveRuleMasterID", ResourceType = typeof(AERP.Common.Resources))]
        //[Display(Name = "Leave Rule")]
        public int LeaveRuleMasterID
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.LeaveRuleMasterID > 0) ? LeaveRuleExemptedEmployeeDTO.LeaveRuleMasterID : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.LeaveRuleMasterID = value;
            }
        }
        public string LeaveRuleDescription
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.LeaveRuleDescription : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.LeaveRuleDescription = value;
            }
        }
        public string LeaveCode
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.LeaveCode : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.LeaveCode = value;
            }
        }
        // [Display(Name = "From Date")]
         [Display(Name = "DisplayName_FromDate", ResourceType = typeof(AERP.Common.Resources))]
        public string FromDate
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.FromDate : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.FromDate = value;
            }
        }
         //[Display(Name = "Upto Date")]
         [Display(Name = "DisplayName_UptoDate", ResourceType = typeof(AERP.Common.Resources))]
         public string UptoDate
         {
             get
             {
                 return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.UptoDate : string.Empty;
             }
             set
             {
                 LeaveRuleExemptedEmployeeDTO.UptoDate = value;
             }
         }
        // [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AMS.Common.Resources))]
        //  [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreCode
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.CentreCode : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.CentreCode = value;
            }
        }
        public string EntityLevel
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.EntityLevel : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.EntityLevel = value;
            }
        }
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.CentreName : string.Empty;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.CentreName = value;
            }
        }



        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.IsActive : false;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.IsActive = value;
            }
        }

        public bool IsDeleted
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.IsDeleted : false;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.IsDeleted = value;
            }
        }

        public int CreatedBy
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.CreatedBy > 0) ? LeaveRuleExemptedEmployeeDTO.CreatedBy : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.CreatedBy = value;
            }
        }
        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.ModifiedBy.HasValue) ? LeaveRuleExemptedEmployeeDTO.ModifiedBy : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null && LeaveRuleExemptedEmployeeDTO.DeletedBy.HasValue) ? LeaveRuleExemptedEmployeeDTO.DeletedBy : new int();
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (LeaveRuleExemptedEmployeeDTO != null) ? LeaveRuleExemptedEmployeeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                LeaveRuleExemptedEmployeeDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }



    }
}
