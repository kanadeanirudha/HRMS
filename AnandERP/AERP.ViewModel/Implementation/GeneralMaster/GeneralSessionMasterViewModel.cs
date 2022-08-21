using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
   public class GeneralSessionMasterViewModel
    {

       public GeneralSessionMasterViewModel()
        {
            GeneralSessionMasterDTO = new GeneralSessionMaster();
        }

        public GeneralSessionMaster GeneralSessionMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralSessionMasterDTO != null && GeneralSessionMasterDTO.ID > 0) ? GeneralSessionMasterDTO.ID : new int();
            }
            set
            {
                GeneralSessionMasterDTO.ID = value;
            }
        }



        //[Display(Name = "DisplayName_SessionName", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionNameRequired")]
        public string SessionName
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.SessionName : string.Empty;
            }
            set
            {
                GeneralSessionMasterDTO.SessionName = value;
            }
        }
        [Display(Name = "DisplayName_SessionFrom", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionFromRequired")]
        public int SessionFrom
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.SessionFrom : new int();
            }
            set
            {
                GeneralSessionMasterDTO.SessionFrom = value;
            }
        }
        [Display(Name = "DisplayName_SessionUpto", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionUptoRequired")]
        public int SessionUpto
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.SessionUpto : new int();
            }
            set
            {
                GeneralSessionMasterDTO.SessionUpto = value;
            }
        }
        [Display(Name = "DisplayName_SessionOrder", ResourceType = typeof(AMS.Common.Resources))]
        //[Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SessionOrderRequired")]
        public int SessionOrder
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.SessionOrder : new int();
            }
            set
            {
                GeneralSessionMasterDTO.SessionOrder = value;
            }
        }

        [Display(Name = "DisplayName_CurrentFlag")]
        public bool CurrentFlag
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.CurrentFlag :false;
            }
            set
            {
                GeneralSessionMasterDTO.CurrentFlag = value;
            }
        }

        [Display(Name = "LockFlag")]
        public bool LockFlag
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.LockFlag : false;
            }
            set
            {
                GeneralSessionMasterDTO.LockFlag = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.IsDeleted: false;
            }
            set
            {
                GeneralSessionMasterDTO.IsDeleted= value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralSessionMasterDTO != null && GeneralSessionMasterDTO.CreatedBy > 0) ? GeneralSessionMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralSessionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralSessionMasterDTO != null) ? GeneralSessionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralSessionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralSessionMasterDTO != null && GeneralSessionMasterDTO.ModifiedBy.HasValue) ? GeneralSessionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralSessionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralSessionMasterDTO != null && GeneralSessionMasterDTO.ModifiedDate.HasValue) ? GeneralSessionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralSessionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralSessionMasterDTO != null && GeneralSessionMasterDTO.DeletedBy.HasValue) ? GeneralSessionMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralSessionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralSessionMasterDTO != null && GeneralSessionMasterDTO.DeletedDate.HasValue) ? GeneralSessionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralSessionMasterDTO.DeletedDate = value;
            }
        }

    }
}
