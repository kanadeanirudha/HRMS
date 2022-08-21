using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeShiftApplicableMasterViewModel : IEmployeeShiftApplicableMasterViewModel
    {
        public EmployeeShiftApplicableMasterViewModel()
        {
            EmployeeShiftApplicableMasterDTO = new EmployeeShiftApplicableMaster();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
            ListOrganisationDepartmentMaster = new List<OrganisationDepartmentMaster>();
        }

        public EmployeeShiftApplicableMaster EmployeeShiftApplicableMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.ID > 0) ? EmployeeShiftApplicableMasterDTO.ID : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.ID = value;
            }
        }

        public int EmployeeID
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.EmployeeID > 0) ? EmployeeShiftApplicableMasterDTO.EmployeeID : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeID = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeName
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeName : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeName = value;
            }
        }

        public string EmployeeShiftMasterID
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeShiftMasterID : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeShiftMasterID = value;
            }
        }


        [Display(Name = "DisplayName_EmployeeShiftDescription", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeShiftDescription
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeShiftDescription : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeShiftDescription = value;
            }
        }

        [Display(Name = "DisplayName_RotationDays", ResourceType = typeof(AERP.Common.Resources))]
        public string RotationDays
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.RotationDays : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.RotationDays = value;
            }
        }

        [Display(Name = "DisplayName_ShiftStartDate", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ShiftStartDate")]
        public string ShiftStartDate
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.ShiftStartDate : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.ShiftStartDate = value;
            }
        }

        [Display(Name = "DisplayName_CurrentActiveFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool CurrentActiveFlag
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.CurrentActiveFlag : false;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.CurrentActiveFlag = value;
            }
        }

        [Display(Name = "DisplayName_ShiftEndDate", ResourceType = typeof(AERP.Common.Resources))]
        public string ShiftEndDate
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.ShiftEndDate : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.ShiftEndDate = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        //   [Display(Name = "IsActive")]
        public bool IsActive
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.IsActive : false;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.IsDeleted : false;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.CreatedBy > 0) ? EmployeeShiftApplicableMasterDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.ModifiedBy.HasValue) ? EmployeeShiftApplicableMasterDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.ModifiedDate.HasValue) ? EmployeeShiftApplicableMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.DeletedBy.HasValue) ? EmployeeShiftApplicableMasterDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.DeletedDate.HasValue) ? EmployeeShiftApplicableMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }
        [Display(Name = "DisplayName_CentreCode", ResourceType = typeof(AERP.Common.Resources))]
        public string CentreCode
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "DisplayName_CentreName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_CentreNameRequired")]
        public string CentreName
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.CentreName : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.CentreName = value;
            }
        }
        [Display(Name = "DisplayName_DepartmentName", ResourceType = typeof(AERP.Common.Resources))]
        // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DepartmentNameRequired")]
        public string DepartmentName
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.DepartmentName : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.DepartmentName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeFirstName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeFirstName
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeFirstName : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeFirstName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeMiddleName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeMiddleName
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeMiddleName : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeMiddleName = value;
            }
        }

        [Display(Name = "DisplayName_EmployeeLastName", ResourceType = typeof(AERP.Common.Resources))]
        public string EmployeeLastName
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeLastName : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeLastName = value;
            }
        }
        public int DepartmentID
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.DepartmentID > 0) ? EmployeeShiftApplicableMasterDTO.DepartmentID : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.DepartmentID = value;
            }
        }
        public string EntityLevel
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EntityLevel : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EntityLevel = value;
            }
        }
        public List<OrganisationStudyCentreMaster> ListOrganisationStudyCentreMaster
        {
            get;
            set;
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListOrganisationStudyCentreMasterItems
        {
            get
            {
                return new SelectList(ListOrganisationStudyCentreMaster, "CentreCode", "CentreName");
            }
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
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
        public List<GeneralWeekDays> ListGeneralWeekDays
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGeneralWeekDaysItems
        {
            get
            {
                return new SelectList(ListGeneralWeekDays, "ID", "WeekDescription");
            }
        }
        //[Display(Name = "Weekly Off Days :")]
        [Display(Name = "DisplayName_GeneralWeekDayID", ResourceType = typeof(AERP.Common.Resources))]
        public int GeneralWeekDayID
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.GeneralWeekDayID > 0) ? EmployeeShiftApplicableMasterDTO.GeneralWeekDayID : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.GeneralWeekDayID = value;
            }
        }
        //[Display(Name = "Weekly Off :")]
        [Display(Name = "DisplayName_WeeklyOffConsideration", ResourceType = typeof(AERP.Common.Resources))]
        public int WeeklyOffConsideration
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.WeeklyOffConsideration > 0) ? EmployeeShiftApplicableMasterDTO.WeeklyOffConsideration : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.WeeklyOffConsideration = value;
            }
        }
        [Display(Name = "From Date")]
        public string EmployeeShistApplicableMasterFromDate
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.EmployeeShistApplicableMasterFromDate : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.EmployeeShistApplicableMasterFromDate = value;
            }
        }
     
        public string XmlWeekDaysString
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null) ? EmployeeShiftApplicableMasterDTO.XmlWeekDaysString : string.Empty;
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.XmlWeekDaysString = value;
            }
        }
        public int SelectedDepartmentID
        {
            get
            {
                return (EmployeeShiftApplicableMasterDTO != null && EmployeeShiftApplicableMasterDTO.SelectedDepartmentID > 0) ? EmployeeShiftApplicableMasterDTO.SelectedDepartmentID : new int();
            }
            set
            {
                EmployeeShiftApplicableMasterDTO.SelectedDepartmentID = value;
            }
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public int ShiftAllocationCentreID { get; set; }
        public string SelectedShiftAndCentreAllocationID { get; set; }
    }
}
