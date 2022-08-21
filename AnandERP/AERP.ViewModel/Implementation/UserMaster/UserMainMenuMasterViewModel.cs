using AERP.Common;
using AERP.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class UserMainMenuMasterViewModel : IUserMainMenuMasterViewModel
    {
        public UserMainMenuMasterViewModel()
        {
            UserMainMenuMasterDTO = new UserMainMenuMaster();
        }

        public UserMainMenuMaster UserMainMenuMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.ID > 0) ? UserMainMenuMasterDTO.ID : new int();
            }
            set
            {
                UserMainMenuMasterDTO.ID = value;
            }
        }
        public int ModuleID
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.ModuleID > 0) ? UserMainMenuMasterDTO.ModuleID : new int();
            }
            set
            {
                UserMainMenuMasterDTO.ModuleID = value;
            }
        }

      //  [Display(Name = "Module Code")]
        public string ModuleName
        {
            get
            {
                return UserMainMenuMasterDTO.ModuleName;
            }
            set
            {
                UserMainMenuMasterDTO.ModuleName = value;
            }
        }

        [Display(Name = "Module Code")]
        public string ModuleCode
        {
            get
            {
                return UserMainMenuMasterDTO.ModuleCode;
            }
            set
            {
                UserMainMenuMasterDTO.ModuleCode = value;
            }
        }

        [Display(Name = "DisplayName_MenuCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MenuCode")]
        public string MenuCode
        {
            get
            {
                return UserMainMenuMasterDTO.MenuCode;
            }
            set
            {
                UserMainMenuMasterDTO.MenuCode = value;
            }
        }

        [Display(Name = "DisplayName_MenuName", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MenuName")]
        public string MenuName
        {
            get
            {
                return UserMainMenuMasterDTO.MenuName;
            }
            set
            {
                UserMainMenuMasterDTO.MenuName = value;
            }
        }

        [Display(Name = "DisplayName_MenuInnerLevel", ResourceType = typeof(AERP.Common.Resources))]
        public int MenuInnerLevel
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.MenuInnerLevel > 0) ? UserMainMenuMasterDTO.MenuInnerLevel : new int();
            }
            set
            {
                UserMainMenuMasterDTO.MenuInnerLevel = value;
            }
        }


        public int ParentMenuID
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.ParentMenuID > 0) ? UserMainMenuMasterDTO.ParentMenuID : new int();
            }
            set
            {
                UserMainMenuMasterDTO.ParentMenuID = value;
            }
        }

          [Display(Name = "Sequence Number")]
        public int MenuDisplaySeqNo
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.MenuDisplaySeqNo > 0) ? UserMainMenuMasterDTO.MenuDisplaySeqNo : new int();
            }
            set
            {
                UserMainMenuMasterDTO.MenuDisplaySeqNo = value;
            }
        }

        [Display(Name = "Menu Ver No")]
        public string MenuVerNo
        {
            get
            {
                return UserMainMenuMasterDTO.MenuVerNo;
            }
            set
            {
                UserMainMenuMasterDTO.MenuVerNo = value;
            }
        }

        [Display(Name = "Menu Installed Flag")]
        public bool MenuInstalledFlag
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.MenuInstalledFlag : false;
            }
            set
            {
                UserMainMenuMasterDTO.MenuInstalledFlag = value;
            }
        }

        [Display(Name = "DisplayName_IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.IsDeleted : false;
            }
            set
            {
                UserMainMenuMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "DisplayName_MenuLink", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MenuLink")]
        public string MenuLink
        {
            get
            {
                return UserMainMenuMasterDTO.MenuLink;
            }
            set
            {
                UserMainMenuMasterDTO.MenuLink = value;
            }
        }

        [Display(Name = "DisplayName_MenuIconName", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MenuIconName")]
        public string MenuIconName
        {
            get
            {
                return UserMainMenuMasterDTO.MenuIconName;
            }
            set
            {
                UserMainMenuMasterDTO.MenuIconName = value;
            }
        }
        

        [Display(Name = "IsEnable")]
        public bool IsEnable
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.IsEnable : false;
            }
            set
            {
                UserMainMenuMasterDTO.IsEnable = value;
            }
        }

        [Display(Name = "DisplayName_DisableDate", ResourceType = typeof(AERP.Common.Resources))]
        public string DisableDate
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.DisableDate : string.Empty;
            }
            set
            {
                UserMainMenuMasterDTO.DisableDate = value;
            }
        }

        [Display(Name = "DisplayName_RemarkAboutDisable", ResourceType = typeof(AERP.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RemarkAboutDisable")]
        public string RemarkAboutDisable
        {
            get
            {
                return UserMainMenuMasterDTO.RemarkAboutDisable;
            }
            set
            {
                UserMainMenuMasterDTO.RemarkAboutDisable = value;
            }
        }

        [Display(Name = "DisplayName_MenuToolTip", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_MenuToolTip")]
        public string MenuToolTip
        {
            get
            {
                return UserMainMenuMasterDTO.MenuToolTip;
            }
            set
            {
                UserMainMenuMasterDTO.MenuToolTip = value;
            }
        }

        [Display(Name = "DisplayName_ParentMenuName", ResourceType = typeof(AERP.Common.Resources))]
        public string ParentMenuName
        {
            get
            {
                return UserMainMenuMasterDTO.ParentMenuName;
            }
            set
            {
                UserMainMenuMasterDTO.ParentMenuName = value;
            }
        }

        [Display(Name = "Parent Menu Code")]
        public string ParentMenuCode
        {
            get
            {
                return UserMainMenuMasterDTO.ParentMenuCode;
            }
            set
            {
                UserMainMenuMasterDTO.ParentMenuCode = value;
            }
        }

        [Display(Name = "Is Active ?")]
        public bool IsActive
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.IsActive : false;
            }
            set
            {
                UserMainMenuMasterDTO.IsActive = value;
            }
        }

        [Display(Name = "DisplayName_CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.CreatedBy > 0) ? UserMainMenuMasterDTO.CreatedBy : new int();
            }
            set
            {
                UserMainMenuMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "DisplayName_CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                UserMainMenuMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "DisplayName_ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.ModifiedBy.HasValue) ? UserMainMenuMasterDTO.ModifiedBy : new int();
            }
            set
            {
                UserMainMenuMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "DisplayName_ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.ModifiedDate.HasValue) ? UserMainMenuMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                UserMainMenuMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DisplayName_DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.DeletedBy.HasValue) ? UserMainMenuMasterDTO.DeletedBy : new int();
            }
            set
            {
                UserMainMenuMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DisplayName_DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (UserMainMenuMasterDTO != null && UserMainMenuMasterDTO.DeletedDate.HasValue) ? UserMainMenuMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                UserMainMenuMasterDTO.DeletedDate = value;
            }
        }


        public List<UserMainMenuMasterViewModel> mmList
        {
            get;
            set;
        }


        public string Path
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.path : string.Empty;
            }
            set
            {
                UserMainMenuMasterDTO.path = value;
            }
        }

        [Display(Name = "IsParent")]
        public bool IsParent
        {
            get
            {
                return (UserMainMenuMasterDTO != null) ? UserMainMenuMasterDTO.IsParent : false;
            }
            set
            {
                UserMainMenuMasterDTO.IsParent = value;
            }
        }
    }
}
