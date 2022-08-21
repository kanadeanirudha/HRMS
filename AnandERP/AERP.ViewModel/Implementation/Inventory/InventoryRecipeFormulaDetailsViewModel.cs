using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryRecipeFormulaDetailsViewModel : IInventoryRecipeFormulaDetailsViewModel
    {

        public InventoryRecipeFormulaDetailsViewModel()
        {
            InventoryRecipeFormulaDetailsDTO = new InventoryRecipeFormulaDetails();

        }
        public InventoryRecipeFormulaDetails InventoryRecipeFormulaDetailsDTO
        {
            get;
            set;
        }

        public Int32 ID
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null && InventoryRecipeFormulaDetailsDTO.ID > 0) ? InventoryRecipeFormulaDetailsDTO.ID : new Int32();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.ID = value;
            }
        }
        [Display(Name="Item number")]
        public Int32 ItemNumber
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null && InventoryRecipeFormulaDetailsDTO.ItemNumber > 0) ? InventoryRecipeFormulaDetailsDTO.ItemNumber : new Int32();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Inout Type")]
        public Boolean InoutType
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.InoutType : new Boolean();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.InoutType = value;
            }
        }

        public double Quantity
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.Quantity : new double();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.Quantity = value;
            }
        }
         [Display(Name = "UOM Code")]
        public string UOMCode
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.UOMCode : string.Empty;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.UOMCode = value;
            }
        }
         [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.ItemDescription = value;
            }
        }

        public byte InventoryVariationMasterID
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.InventoryVariationMasterID : new byte();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.InventoryVariationMasterID = value;
            }
        }
          [Display(Name = "Recipe Variation Title")]
          [Required(ErrorMessage = "Recipe Variation Title should not be blank")]
        public string RecipeVariationTitle
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.RecipeVariationTitle = value;
            }
        }
          [Display(Name = "Order Number")]
        public byte OrderNumber
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.OrderNumber : new byte();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.OrderNumber = value;
            }
        }
         [Display(Name = "Is Optional Ingrediant")]
        public Boolean IsOptionalIngrediant
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.IsOptionalIngrediant : new Boolean();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.IsOptionalIngrediant = value;
            }
        }
        public decimal Cost
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null && InventoryRecipeFormulaDetailsDTO.Cost > 0) ? InventoryRecipeFormulaDetailsDTO.Cost : new decimal();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.Cost = value;
            }
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null && InventoryRecipeFormulaDetailsDTO.GeneralItemMasterID > 0) ? InventoryRecipeFormulaDetailsDTO.GeneralItemMasterID : new int();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.GeneralItemMasterID = value;
            }
        }

        public double LastPurchasePrice
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null && InventoryRecipeFormulaDetailsDTO.GeneralItemMasterID > 0) ? InventoryRecipeFormulaDetailsDTO.LastPurchasePrice : new double();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.LastPurchasePrice = value;
            }
        }
           
       
        
 
        //Common Properties
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.IsDeleted : false;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null && InventoryRecipeFormulaDetailsDTO.CreatedBy > 0) ? InventoryRecipeFormulaDetailsDTO.CreatedBy : new int();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.DeletedBy : new int();
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryRecipeFormulaDetailsDTO != null) ? InventoryRecipeFormulaDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryRecipeFormulaDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
    }
}

