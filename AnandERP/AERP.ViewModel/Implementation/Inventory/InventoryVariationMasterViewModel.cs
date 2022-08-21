using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryVariationMasterViewModel : IInventoryVariationMasterViewModel
    {

        public InventoryVariationMasterViewModel()
        {
            InventoryVariationMasterDTO = new InventoryVariationMaster();
            
        }
       
       
        public InventoryVariationMaster InventoryVariationMasterDTO
        {
            get;
            set;
        }

        public byte ID
        {
            get
            {
                return (InventoryVariationMasterDTO != null && InventoryVariationMasterDTO.ID > 0) ? InventoryVariationMasterDTO.ID : new byte();
            }
            set
            {
                InventoryVariationMasterDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Recipe Variation Title should not be blank.")]
        [Display(Name = "Recipe Variation Title")]
        public string RecipeVariationTitle
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                InventoryVariationMasterDTO.RecipeVariationTitle = value;
            }
        }
        public string Title
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.Title : string.Empty;
            }
            set
            {
                InventoryVariationMasterDTO.Title = value;
            }
        }
        public string Description
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.Description : string.Empty;
            }
            set
            {
                InventoryVariationMasterDTO.Description = value;
            }
        }
         [Display(Name = "Recipe Title")]
        public string RecipeTitle
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.RecipeTitle : string.Empty;
            }
            set
            {
                InventoryVariationMasterDTO.RecipeTitle = value;
            }
        }

          
        public Int16 InventoryRecipeMasterId
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.InventoryRecipeMasterId : new Int16();
            }
            set
            {
                InventoryVariationMasterDTO.InventoryRecipeMasterId = value;
            }
        }


        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryVariationMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryVariationMasterDTO != null && InventoryVariationMasterDTO.CreatedBy > 0) ? InventoryVariationMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryVariationMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryVariationMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryVariationMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryVariationMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryVariationMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryVariationMasterDTO != null) ? InventoryVariationMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryVariationMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

