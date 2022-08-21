using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryRecipeMenuCategoryViewModel : IInventoryRecipeMenuCategoryViewModel
    {

        public InventoryRecipeMenuCategoryViewModel()
        {
            InventoryRecipeMenuCategoryDTO = new InventoryRecipeMenuCategory();

        }



        public InventoryRecipeMenuCategory InventoryRecipeMenuCategoryDTO
        {
            get;
            set;
        }

        public Int16 ID
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null && InventoryRecipeMenuCategoryDTO.ID > 0) ? InventoryRecipeMenuCategoryDTO.ID : new Int16();
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.ID = value;
            }
        }

        [Required(ErrorMessage = "Menu Category should not be blank.")]
        [Display(Name = "Menu Category")]
        public string MenuCategory
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.MenuCategory : string.Empty;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.MenuCategory = value;
            }
        }

        [Required(ErrorMessage = "Menu Category Code should not be blank.")]
        [Display(Name = "Menu Category Code")]
        public string MenuCategoryCode
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.MenuCategoryCode : string.Empty;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.MenuCategoryCode = value;
            }
        }
        [Required(ErrorMessage = "Category Type should not be blank.")]
        [Display(Name = "Category Type")]
        public Byte CategoryType
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.CategoryType : new byte();
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.CategoryType = value;
            }
        }
        [Required(ErrorMessage = "Please Select Item Category Code.")]
        [Display(Name = "Item Category Code")]
        public string ItemCategoryCode
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.ItemCategoryCode = value;
            }
        }
        [Display(Name = "Active Category")]
        public bool IsActive
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.IsActive : new bool();
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.IsActive = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.IsDeleted : false;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null && InventoryRecipeMenuCategoryDTO.CreatedBy > 0) ? InventoryRecipeMenuCategoryDTO.CreatedBy : new int();
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.DeletedBy : new int();
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryRecipeMenuCategoryDTO != null) ? InventoryRecipeMenuCategoryDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeMenuCategoryDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }






    }
}

