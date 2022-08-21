using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralUnitMasterViewModel : IGeneralUnitMasterViewModel
    {

        public GeneralUnitMasterViewModel()
        {


            GeneralUnitMasterDTO = new GeneralUnitMaster();
        }

        public GeneralUnitMaster GeneralUnitMasterDTO
        {
            get;
            set;
        }

        public List<GeneralUnitMaster> ListGeneralUnitMaster
        {
            get;
            set;
        }

        public byte ID
        {
            get
            {
                return (GeneralUnitMasterDTO != null && GeneralUnitMasterDTO.ID > 0) ? GeneralUnitMasterDTO.ID : new byte();
            }
            set
            {
                GeneralUnitMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_UnitDescription", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UnitDescriptionRequired")]
       
        public string UnitDescription
        {
            get
            {
                return (GeneralUnitMasterDTO != null) ? GeneralUnitMasterDTO.UnitDescription : string.Empty;
            }
            set
            {
                GeneralUnitMasterDTO.UnitDescription = value;
            }
        }


        [Display(Name = "DisplayName_ShortCode", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_ShortCodeRequired")]
        public string ShortCode
        {
            get
            {
                return (GeneralUnitMasterDTO != null) ? GeneralUnitMasterDTO.ShortCode : string.Empty;
            }
            set
            {
                GeneralUnitMasterDTO.ShortCode = value;
            }
        }

      

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralUnitMasterDTO != null) ? GeneralUnitMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralUnitMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralUnitMasterDTO != null && GeneralUnitMasterDTO.CreatedBy > 0) ? GeneralUnitMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralUnitMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralUnitMasterDTO != null) ? GeneralUnitMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralUnitMasterDTO != null && GeneralUnitMasterDTO.ModifiedBy.HasValue) ? GeneralUnitMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralUnitMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralUnitMasterDTO != null && GeneralUnitMasterDTO.ModifiedDate.HasValue) ? GeneralUnitMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralUnitMasterDTO != null && GeneralUnitMasterDTO.DeletedBy.HasValue) ? GeneralUnitMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralUnitMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralUnitMasterDTO != null && GeneralUnitMasterDTO.DeletedDate.HasValue) ? GeneralUnitMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitMasterDTO.DeletedDate = value;
            }
        }

        public string errorMessage
        {
            get;
            set;
        }

    }
}
