using AMS.Common;
using AMS.DTO;
using System;
using System.ComponentModel.DataAnnotations;
namespace AMS.ViewModel
{
    public class GeneralReligionMasterViewModel : IGeneralReligionMasterViewModel
    {
        public GeneralReligionMasterViewModel()
        {
            GeneralReligionMasterDTO = new GeneralReligionMaster();
        }

        public GeneralReligionMaster GeneralReligionMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralReligionMasterDTO != null && GeneralReligionMasterDTO.ID > 0) ? GeneralReligionMasterDTO.ID : new int();
            }
            set
            {
                GeneralReligionMasterDTO.ID = value;
            }
        }
        [Display(Name = "DisplayName_ReligionDescription", ResourceType = typeof(AMS.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AMS.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ReligionDescription")]
        public string Description
        {
            get
            {
                return (GeneralReligionMasterDTO != null) ? GeneralReligionMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralReligionMasterDTO.Description = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralReligionMasterDTO != null) ? GeneralReligionMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralReligionMasterDTO.IsDeleted = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralReligionMasterDTO != null) ? GeneralReligionMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralReligionMasterDTO.IsUserDefined = value;
            }
        }
        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralReligionMasterDTO != null && GeneralReligionMasterDTO.CreatedBy > 0) ? GeneralReligionMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralReligionMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralReligionMasterDTO != null) ? GeneralReligionMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralReligionMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralReligionMasterDTO != null && GeneralReligionMasterDTO.ModifiedBy.HasValue) ? GeneralReligionMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralReligionMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralReligionMasterDTO != null && GeneralReligionMasterDTO.ModifiedDate.HasValue) ? GeneralReligionMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralReligionMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralReligionMasterDTO != null && GeneralReligionMasterDTO.DeletedBy.HasValue) ? GeneralReligionMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralReligionMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralReligionMasterDTO != null && GeneralReligionMasterDTO.DeletedDate.HasValue) ? GeneralReligionMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralReligionMasterDTO.DeletedDate = value;
            }
        }
    }
}
