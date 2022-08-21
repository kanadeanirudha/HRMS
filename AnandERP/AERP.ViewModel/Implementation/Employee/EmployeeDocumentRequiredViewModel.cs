using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class EmployeeDocumentRequiredViewModel : IEmployeeDocumentRequiredViewModel
    {

        public EmployeeDocumentRequiredViewModel()
        {
            EmployeeDocumentRequiredDTO = new EmployeeDocumentRequired();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            ListOrganisationStudyCentreMaster = new List<OrganisationStudyCentreMaster>();
        }

        public EmployeeDocumentRequired EmployeeDocumentRequiredDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.ID > 0) ? EmployeeDocumentRequiredDTO.ID : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_DocumentID", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_DocumentIDRequired")]       
        public int DocumentID
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.DocumentID > 0) ? EmployeeDocumentRequiredDTO.DocumentID : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.DocumentID = value;
            }
        }

        [Display(Name = "DisplayName_LeaveRuleMasterID", ResourceType = typeof(AERP.Common.Resources))]      
        public int LeaveRuleMasterID
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.LeaveRuleMasterID > 0) ? EmployeeDocumentRequiredDTO.LeaveRuleMasterID : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.LeaveRuleMasterID = value;
            }
        }

         [Display(Name = "DisplayName_DocumentCompulsaryFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool DocumentCompulsaryFlag
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.DocumentCompulsaryFlag : false;
            }
            set
            {
                EmployeeDocumentRequiredDTO.DocumentCompulsaryFlag = value;
            }
        }

        [Display(Name = "DisplayName_IsActive", ResourceType = typeof(AERP.Common.Resources))]
        public bool IsActive
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.IsActive : false;
            }
            set
            {
                EmployeeDocumentRequiredDTO.IsActive = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.IsDeleted : false;
            }
            set
            {
                EmployeeDocumentRequiredDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.CreatedBy > 0) ? EmployeeDocumentRequiredDTO.CreatedBy : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                EmployeeDocumentRequiredDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.ModifiedBy.HasValue) ? EmployeeDocumentRequiredDTO.ModifiedBy : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.ModifiedDate.HasValue) ? EmployeeDocumentRequiredDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                EmployeeDocumentRequiredDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.DeletedBy.HasValue) ? EmployeeDocumentRequiredDTO.DeletedBy : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.DeletedDate.HasValue) ? EmployeeDocumentRequiredDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                EmployeeDocumentRequiredDTO.DeletedDate = value;
            }
        }
        public string errorMessage { get; set; }


        public string EntityLevel
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.EntityLevel : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.EntityLevel = value;
            }
        }
        public string CentreCode
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.CentreCode : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.CentreCode = value;
            }
        }

        [Display(Name = "DisplayName_LeaveRuleDescription", ResourceType = typeof(AERP.Common.Resources))]
        public string LeaveRuleDescription
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.LeaveRuleDescription : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.LeaveRuleDescription = value;
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

        public string CentreName
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.CentreName : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.CentreName = value;
            }
        }

        [Display(Name = "DisplayName_LeaveDescription", ResourceType = typeof(AERP.Common.Resources))]     
        public string LeaveDescription
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.LeaveDescription : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.LeaveDescription = value;
            }
        }

        [Display(Name = "DisplayName_Leaves", ResourceType = typeof(AERP.Common.Resources))]     
        public int LeaveMasterID
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null && EmployeeDocumentRequiredDTO.LeaveMasterID > 0) ? EmployeeDocumentRequiredDTO.LeaveMasterID : new int();
            }
            set
            {
                EmployeeDocumentRequiredDTO.LeaveMasterID = value;
            }
        }

        public string DocumentName
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.DocumentName : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.DocumentName = value;
            }
        }

        public string SelectedIDs
        {
            get
            {
                return (EmployeeDocumentRequiredDTO != null) ? EmployeeDocumentRequiredDTO.SelectedIDs : string.Empty;
            }
            set
            {
                EmployeeDocumentRequiredDTO.SelectedIDs = value;
            }
        }
        
    }
}


