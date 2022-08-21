using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel 
{
    public class BOMAndRecipeDetailsViewModel : IBOMAndRecipeDetailsViewModel
    {

        public BOMAndRecipeDetailsViewModel()
        {
            BOMAndRecipeDetailsDTO = new BOMAndRecipeDetails();
            IngridentsListByVarients = new List<BOMAndRecipeDetails>();
           
        }
        public List<BOMAndRecipeDetails> IngridentsListByVarients { get; set; }
        public BOMAndRecipeDetails BOMAndRecipeDetailsDTO
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.GeneralItemMasterID : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.GeneralItemMasterID = value;
            }
        }
        public Int16 ID
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null && BOMAndRecipeDetailsDTO.ID > 0) ? BOMAndRecipeDetailsDTO.ID : new Int16();
            }
            set
            {
                BOMAndRecipeDetailsDTO.ID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.ItemNumber : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.ItemNumber = value;
            }
        }
        public string LowerLevelUomCode
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.LowerLevelUomCode : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.LowerLevelUomCode = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.XMLstring : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.XMLstring = value;
            }
        }
         [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.ItemDescription : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.ItemDescription = value;
            }
        }
        //Fields From InventoryRecipeMaster

        [Display(Name = "Main Menu Item")]
        public string InventoryRecipeMasterTitle
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.InventoryRecipeMasterTitle : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.InventoryRecipeMasterTitle = value;
            }
        }
        [Display(Name = "Description")]
        public string Description
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.Description : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.Description = value;
            }
        }
        public string VersionCode
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.VersionCode : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.VersionCode = value;
            }
        }
        public int PrimaryItemOutputId
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.PrimaryItemOutputId : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.PrimaryItemOutputId = value;
            }
        }
        public Int16 InventoryRecipeMasterID
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.InventoryRecipeMasterID : new Int16();
            }
            set
            {
                BOMAndRecipeDetailsDTO.InventoryRecipeMasterID = value;
            }
        }
        public int OldRecipeId
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.OldRecipeId : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.OldRecipeId = value;
            }
        }

        //Fields From InventoryVariationMaster
        public Int16 InventoryVariationMasterID
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.InventoryVariationMasterID : new Int16();
            }
            set
            {
                BOMAndRecipeDetailsDTO.InventoryVariationMasterID = value;
            }
        }
       [Display(Name = "Recipe Variation Title")]
        public string RecipeVariationTitle
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.RecipeVariationTitle = value;
            }
        }

        //Fields From InventoryRecipeFormulaDetails
        public decimal Cost
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.Cost : new decimal();
            }
            set
            {
                BOMAndRecipeDetailsDTO.Cost = value;
            }
        }
            [Display(Name = "Wastage(%)")]
        public decimal WastageInPercentage
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.WastageInPercentage : new decimal();
            }
            set
            {
                BOMAndRecipeDetailsDTO.WastageInPercentage = value;
            }
        }
        public int InventoryRecipeFormulaDetailsID
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.InventoryRecipeFormulaDetailsID : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.InventoryRecipeFormulaDetailsID = value;
            }
        }
        public byte OrderNumber
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.OrderNumber : new byte();
            }
            set
            {
                BOMAndRecipeDetailsDTO.OrderNumber = value;
            }
        }
        //Fields From InventoryRecipeMenuMaster
        public Int16 InventoryRecipeMenuMaster
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.InventoryRecipeMenuMaster : new Int16();
            }
            set
            {
                BOMAndRecipeDetailsDTO.InventoryRecipeMenuMaster = value;
            }
        }
        public string MenuDescription
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.MenuDescription : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.MenuDescription = value;
            }
        }
        [Display(Name = "Define Variants")]
        public string DefineVariants
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.DefineVariants : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.DefineVariants = value;
            }
        }

        public string BOMRelevant
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.BOMRelevant : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.BOMRelevant = value;
            }
        }
        [Display(Name = "Billing Item Name")]
        public string BillingItemName
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.BillingItemName : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.BillingItemName = value;
            }
        }
        public string UnitName
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.UnitName : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.UnitName = value;
            }
        }
        public bool IsBOM
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.IsBOM : false;
            }
            set
            {
                BOMAndRecipeDetailsDTO.IsBOM = value;
            }
        }
      
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.IsDeleted : false;
            }
            set
            {
                BOMAndRecipeDetailsDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null && BOMAndRecipeDetailsDTO.CreatedBy > 0) ? BOMAndRecipeDetailsDTO.CreatedBy : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                BOMAndRecipeDetailsDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.ModifiedBy : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                BOMAndRecipeDetailsDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.DeletedBy : new int();
            }
            set
            {
                BOMAndRecipeDetailsDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                BOMAndRecipeDetailsDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public double Quantity
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null && BOMAndRecipeDetailsDTO.Quantity > 0) ? BOMAndRecipeDetailsDTO.Quantity : new double();
            }
            set
            {
                BOMAndRecipeDetailsDTO.Quantity = value;
            }
        }
        public double Quantity1
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null && BOMAndRecipeDetailsDTO.Quantity1 > 0) ? BOMAndRecipeDetailsDTO.Quantity1 : new double();
            }
            set
            {
                BOMAndRecipeDetailsDTO.Quantity1 = value;
            }
        }
        [Display(Name = "Consumption UoM")]
        public string UoMCode
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.UoMCode : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.UoMCode = value;
            }
        }
        [Display(Name = "Order UoM")]
        public string OrderUomCode
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.OrderUomCode : string.Empty;
            }
            set
            {
                BOMAndRecipeDetailsDTO.OrderUomCode = value;
            }
        }
           [Display(Name = "Consumption Price")]
        public decimal ConsumptionPrice
        {
            get
            {
                return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.ConsumptionPrice : new decimal();
            }
            set
            {
                BOMAndRecipeDetailsDTO.ConsumptionPrice = value;
            }
        }
           [Display(Name = "Purchase Price")]
           public decimal PurchasePrice
           {
               get
               {
                   return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.PurchasePrice : new decimal();
               }
               set
               {
                   BOMAndRecipeDetailsDTO.PurchasePrice = value;
               }
           }

           public decimal ConsumptionPrice1
           {
               get
               {
                   return (BOMAndRecipeDetailsDTO != null) ? BOMAndRecipeDetailsDTO.ConsumptionPrice1 : new decimal();
               }
               set
               {
                   BOMAndRecipeDetailsDTO.ConsumptionPrice1 = value;
               }
           }
    }
}

