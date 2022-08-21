using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryRecipeMasterViewModel : IInventoryRecipeMasterViewModel
    {

        public InventoryRecipeMasterViewModel()
        {
            InventoryRecipeMasterDTO = new InventoryRecipeMaster();

        }



        public InventoryRecipeMaster InventoryRecipeMasterDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (InventoryRecipeMasterDTO != null && InventoryRecipeMasterDTO.ID > 0) ? InventoryRecipeMasterDTO.ID : new Int16();
            }
            set
            {
                InventoryRecipeMasterDTO.ID = value;
            }
        }
        public int OldRecipeId
        {
            get
            {
                return (InventoryRecipeMasterDTO != null && InventoryRecipeMasterDTO.OldRecipeId > 0) ? InventoryRecipeMasterDTO.OldRecipeId : new int();
            }
            set
            {
                InventoryRecipeMasterDTO.OldRecipeId = value;
            }
        }


        public string Description
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.Description : string.Empty;
            }
            set
            {
                InventoryRecipeMasterDTO.Description = value;
            }
        }
        public string RecipeVariationTitle
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                InventoryRecipeMasterDTO.RecipeVariationTitle = value;
            }
        }


        public string VersionCode
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.VersionCode : string.Empty;
            }
            set
            {
                InventoryRecipeMasterDTO.VersionCode = value;
            }
        }
        public string Title
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.Title : string.Empty;
            }
            set
            {
                InventoryRecipeMasterDTO.Title = value;
            }
        }

        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.IsDeleted : false;
            }
            set
            {
                InventoryRecipeMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryRecipeMasterDTO != null && InventoryRecipeMasterDTO.CreatedBy > 0) ? InventoryRecipeMasterDTO.CreatedBy : new int();
            }
            set
            {
                InventoryRecipeMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryRecipeMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.DeletedBy : new int();
            }
            set
            {
                InventoryRecipeMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryRecipeMasterDTO != null) ? InventoryRecipeMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

