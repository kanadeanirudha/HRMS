using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralTaskModelViewModel : IGeneralTaskModelViewModel
    {
        public GeneralTaskModelViewModel()
        {
            GeneralTaskModelDTO = new GeneralTaskModel();
            MenuCodeList = new List<GeneralTaskModel>();
            LinkMenuCodeList = new List<GeneralTaskModel>();
        }
        public List<GeneralTaskModel> MenuCodeList { get; set; }
        public List<GeneralTaskModel> LinkMenuCodeList { get; set; }
        public IEnumerable<SelectListItem> MenuCodeListItems { get { return new SelectList(MenuCodeList, "MenuCode", "MenuName"); } }
        public IEnumerable<SelectListItem> LinkMenuCodeListItems { get { return new SelectList(MenuCodeList, "MenuLink", "MenuName"); } }
        public GeneralTaskModel GeneralTaskModelDTO
        {
            get;
            set;
        }

        //-------------------------------GeneralTaskModel ------------------------------------
        public int ID
        {
            get
            {
                return (GeneralTaskModelDTO != null && GeneralTaskModelDTO.ID > 0) ? GeneralTaskModelDTO.ID : new int();
            }
            set
            {
                GeneralTaskModelDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_TaskCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TaskCodeRequired")]
        public string TaskCode
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.TaskCode : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.TaskCode = value;
            }
        }
        [Display(Name = "DisplayName_TaskDescription", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_TaskDescriptionRequired")]
        public string TaskDescription
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.TaskDescription : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.TaskDescription = value;
            }
        }
        [Display(Name = "DisplayName_MenuCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_MenuCodeRequired")]
        public string MenuCode
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.MenuCode : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.MenuCode = value;
            }
        }
        [Display(Name = "DisplayName_TaskModelApplicableTo", ResourceType = typeof(Resources))]
        public string TaskModelApplicableTo
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.TaskModelApplicableTo : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.TaskModelApplicableTo = value;
            }
        }
        [Display(Name = "DisplayName_LinkMenuCode", ResourceType = typeof(Resources))]
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "ValidationMessage_LinkMenuCodeRequired")]
        public string LinkMenuCode
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.LinkMenuCode : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.LinkMenuCode = value;
            }
        }
        public bool IsActive
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.IsActive : false;
            }
            set
            {
                GeneralTaskModelDTO.IsActive = value;
            }
        }
        public bool IsDeleted
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.IsDeleted : false;
            }
            set
            {
                GeneralTaskModelDTO.IsDeleted = value;
            }
        }
        public int CreatedBy
        {
            get
            {
                return (GeneralTaskModelDTO != null && GeneralTaskModelDTO.CreatedBy > 0) ? GeneralTaskModelDTO.CreatedBy : new int();
            }
            set
            {
                GeneralTaskModelDTO.CreatedBy = value;
            }
        }
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralTaskModelDTO.CreatedDate = value;
            }
        }
        public int? ModifiedBy
        {
            get
            {
                return (GeneralTaskModelDTO != null && GeneralTaskModelDTO.ModifiedBy > 0) ? GeneralTaskModelDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralTaskModelDTO.ModifiedBy = value;
            }
        }
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralTaskModelDTO.ModifiedDate = value;
            }
        }
        public int? DeletedBy
        {
            get
            {
                return (GeneralTaskModelDTO != null && GeneralTaskModelDTO.DeletedBy > 0) ? GeneralTaskModelDTO.DeletedBy : new int();
            }
            set
            {
                GeneralTaskModelDTO.DeletedBy = value;
            }
        }
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralTaskModelDTO.DeletedDate = value;
            }
        }
        public string errorMessage
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.errorMessage : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.errorMessage = value;
            }
        }
        public string MenuLink
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.MenuLink : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.MenuLink = value;
            }
        }
        public string MenuName
        {
            get
            {
                return (GeneralTaskModelDTO != null) ? GeneralTaskModelDTO.MenuName : string.Empty;
            }
            set
            {
                GeneralTaskModelDTO.MenuName = value;
            }
        }

    }
}
