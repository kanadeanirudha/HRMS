using AERP.Common;
using AERP.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
    public class GeneralEducationTypeMasterViewModel : IGeneralEducationTypeMasterViewModel
    {

        public GeneralEducationTypeMasterViewModel()
        {
            GeneralEducationTypeMasterDTO = new GeneralEducationTypeMaster();
        }

        public GeneralEducationTypeMaster GeneralEducationTypeMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null && GeneralEducationTypeMasterDTO.ID > 0) ? GeneralEducationTypeMasterDTO.ID : new int();
            }
            set
            {
                GeneralEducationTypeMasterDTO.ID = value;
            }
        }


        [Display(Name = "Qualification Type Description")]
        [Required(ErrorMessage = "Qualification Type Description Required")]
        public string Description
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null) ? GeneralEducationTypeMasterDTO.Description : string.Empty;
            }
            set
            {
                GeneralEducationTypeMasterDTO.Description = value;
            }
        }

        [Display(Name = "Sequence Number")]
       // [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EduSequenceNumberRequired")]
        public int EduSequenceNumber
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null) ? GeneralEducationTypeMasterDTO.EduSequenceNumber : new int();
            }
            set
            {
                GeneralEducationTypeMasterDTO.EduSequenceNumber = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null) ? GeneralEducationTypeMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralEducationTypeMasterDTO.IsDeleted = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null) ? GeneralEducationTypeMasterDTO.IsUserDefined : false;
            }
            set
            {
                GeneralEducationTypeMasterDTO.IsUserDefined = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null && GeneralEducationTypeMasterDTO.CreatedBy > 0) ? GeneralEducationTypeMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralEducationTypeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null) ? GeneralEducationTypeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralEducationTypeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null && GeneralEducationTypeMasterDTO.ModifiedBy.HasValue) ? GeneralEducationTypeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralEducationTypeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null && GeneralEducationTypeMasterDTO.ModifiedDate.HasValue) ? GeneralEducationTypeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralEducationTypeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null && GeneralEducationTypeMasterDTO.DeletedBy.HasValue) ? GeneralEducationTypeMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralEducationTypeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralEducationTypeMasterDTO != null && GeneralEducationTypeMasterDTO.DeletedDate.HasValue) ? GeneralEducationTypeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralEducationTypeMasterDTO.DeletedDate = value;
            }
        }

    }
}
