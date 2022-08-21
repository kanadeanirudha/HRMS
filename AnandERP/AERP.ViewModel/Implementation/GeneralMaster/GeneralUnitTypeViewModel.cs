using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AERP.ViewModel
{
    public class GeneralUnitTypeViewModel : IGeneralUnitTypeViewModel
    {

        public GeneralUnitTypeViewModel()
        {
            GeneralUnitTypeDTO = new GeneralUnitType();
           
        }
        


        public GeneralUnitType GeneralUnitTypeDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.ID > 0) ? GeneralUnitTypeDTO.ID : new int();
            }
            set
            {
                GeneralUnitTypeDTO.ID = value;
            }
        }

      /*  [Display(Name = "DisplayName_SeqNo", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_SeqNoRequired")]
        public Nullable<int> SeqNo
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.SeqNo > 0) ? GeneralUnitTypeDTO.SeqNo : new int();
            }
            set
            {
                GeneralUnitTypeDTO.SeqNo = value;
            }
        }*/
       //[Display(Name = "DisplayName_UnitType", ResourceType = typeof(AERP.Common.Resources))]
     //   [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_UnitTypeRequired")]
       [Required(ErrorMessage = "Unit Type should not be blank.")]
       [Display(Name = "Unit Type")]
        public string UnitType
        {
            get
            {
                return (GeneralUnitTypeDTO != null) ? GeneralUnitTypeDTO.UnitType : string.Empty;
            }
            set
            {
                GeneralUnitTypeDTO.UnitType = value;
            }
        }

     // [Display(Name = "DisplayName_RelatedWith", ResourceType = typeof(Resources))]
    //   [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_RelatedWithRequired")]
        [Required(ErrorMessage = "Related with should not be blank.")]
       [Display(Name = "Related With")]
        public Int16 RelatedWith
        {
            get
            {
                return (GeneralUnitTypeDTO != null) ? GeneralUnitTypeDTO.RelatedWith : new Int16();
            }
            set
            {
                GeneralUnitTypeDTO.RelatedWith = value;
            }
        }

       /* [Display(Name = "DefaultFlag", ResourceType = typeof(Resources))]
        public bool DefaultFlag
        {
            get
            {
                return (GeneralUnitTypeDTO != null) ? GeneralUnitTypeDTO.DefaultFlag : false;
            }
            set
            {
                GeneralUnitTypeDTO.DefaultFlag = value;
            }
        }
        public bool IsUserDefined
        {
            get
            {
                return (GeneralUnitTypeDTO != null) ? GeneralUnitTypeDTO.IsUserDefined : false;
            }
            set
            {
                GeneralUnitTypeDTO.IsUserDefined = value;
            }
        }*/
        [Display(Name = "IsDeleted")]
        public Nullable<bool> IsDeleted
        {
            get
            {
                return (GeneralUnitTypeDTO != null) ? GeneralUnitTypeDTO.IsDeleted : false;
            }
            set
            {
                GeneralUnitTypeDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public Nullable<int> CreatedBy
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.CreatedBy > 0) ? GeneralUnitTypeDTO.CreatedBy : new int();
            }
            set
            {
                GeneralUnitTypeDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public Nullable<DateTime> CreatedDate
        {
            get
            {
                return (GeneralUnitTypeDTO != null) ? GeneralUnitTypeDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitTypeDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.ModifiedBy.HasValue) ? GeneralUnitTypeDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralUnitTypeDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.ModifiedDate.HasValue) ? GeneralUnitTypeDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitTypeDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.DeletedBy.HasValue) ? GeneralUnitTypeDTO.DeletedBy : new int();
            }
            set
            {
                GeneralUnitTypeDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (GeneralUnitTypeDTO != null && GeneralUnitTypeDTO.DeletedDate.HasValue) ? GeneralUnitTypeDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralUnitTypeDTO.DeletedDate = value;
            }
        }

       
        public string errorMessage { get; set; }
    }
}

