using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace AERP.ViewModel
{
    public class UserModuleMasterBaseViewModel : IUserModuleMasterBaseViewModel
    {
        public UserModuleMasterBaseViewModel()
        {
            ListUserModuleMaster = new List<UserModuleMaster>();

        }

        public List<UserModuleMaster> ListUserModuleMaster
        {
            get;
            set;
        }

        public IEnumerable<SelectListItem> ListUserModuleMasterItems
        {
            get
            {

                return new SelectList(ListUserModuleMaster, "UserModuleMasterID", "SactionedPostDescription");

            }
        }
    }


    public class UserModuleMasterViewModel : IUserModuleMasterViewModel
    {
        public UserModuleMasterViewModel()
        {
            UserModuleMasterDTO = new UserModuleMaster();
        }

        public UserModuleMaster UserModuleMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.ID > 0) ? UserModuleMasterDTO.ID : new int();
            }
            set
            {
                UserModuleMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_ModuleCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleCodeRequired")]
        public string ModuleCode
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleCode : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleCode = value;
            }
        }

        [Display(Name = "DisplayName_ModuleName", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleNameRequired")]
        public string ModuleName
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleName : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleName = value;
            }
        }


         [Display(Name = "DisplayName_ModuleInstalledFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool ModuleInstalledFlag
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleInstalledFlag : false;
            }
            set
            {
                UserModuleMasterDTO.ModuleInstalledFlag = value;
            }
        }

       [Display(Name = "DisplayName_ModuleActiveFlag", ResourceType = typeof(AERP.Common.Resources))]
        public bool ModuleActiveFlag
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleActiveFlag : false;
            }
            set
            {
                UserModuleMasterDTO.ModuleActiveFlag = value;
            }
        }


        // [Required(ErrorMessage = "Module Seq Number")]
        [Display(Name = "Sequence Number")]
        public int ModuleSeqNumber
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.ModuleSeqNumber > 0) ? UserModuleMasterDTO.ModuleSeqNumber : new int();
            }
            set
            {
                UserModuleMasterDTO.ModuleSeqNumber = value;
            }
        }

        [Display(Name = "DisplayName_ModuleRelatedWith", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleRelatedWithRequired")]
        public string ModuleRelatedWith
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleRelatedWith : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleRelatedWith = value;
            }
        }

        [Display(Name = "DisplayName_ModuleTooltip", ResourceType = typeof(AERP.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleTooltipRequired")]
        public string ModuleTooltip
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleTooltip : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleTooltip = value;
            }
        }

        [Display(Name = "DisplayName_ModuleIconName", ResourceType = typeof(AERP.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleIconNameRequired")]
        public string ModuleIconName
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleIconName : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleIconName = value;
            }
        }

        [Display(Name = "DisplayName_ModuleIconPath", ResourceType = typeof(AERP.Common.Resources))]
       // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleIconPathRequired")]
        public string ModuleIconPath
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleIconPath : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleIconPath = value;
            }
        }


        [Display(Name = "DisplayName_ModuleFormName", ResourceType = typeof(AERP.Common.Resources))]
      //  [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ModuleFormNameRequired")]
        public string ModuleFormName
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.ModuleFormName : string.Empty;
            }
            set
            {
                UserModuleMasterDTO.ModuleFormName = value;
            }
        }


        [Display(Name = "Is Deleted?")]
        public bool IsDeleted
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.IsActive : false;
            }
            set
            {
                UserModuleMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "Created by")]
        public int CreatedBy
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.CreatedBy > 0) ? UserModuleMasterDTO.CreatedBy : new int();
            }
            set
            {
                UserModuleMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "Created date")]
        public DateTime CreatedDate
        {
            get
            {
                return (UserModuleMasterDTO != null) ? UserModuleMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                UserModuleMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "Modified by")]
        public int? ModifiedBy
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.ModifiedBy.HasValue) ? UserModuleMasterDTO.ModifiedBy : new int();
            }
            set
            {
                UserModuleMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "Modified date")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.ModifiedDate.HasValue) ? UserModuleMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                UserModuleMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "Deleted by")]
        public int? DeletedBy
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.DeletedBy.HasValue) ? UserModuleMasterDTO.DeletedBy : new int();
            }
            set
            {
                UserModuleMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "Deleted date")]
        public DateTime? DeletedDate
        {
            get
            {
                return (UserModuleMasterDTO != null && UserModuleMasterDTO.DeletedDate.HasValue) ? UserModuleMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                UserModuleMasterDTO.DeletedDate = value;
            }
        }

     
    }
}
