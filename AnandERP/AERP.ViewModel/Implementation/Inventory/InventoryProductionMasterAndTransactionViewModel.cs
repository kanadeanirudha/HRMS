using AMS.Common;
using AMS.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace AMS.ViewModel
{
    public class InventoryProductionMasterAndTransactionViewModel : IInventoryProductionMasterAndTransactionViewModel
    {

        public InventoryProductionMasterAndTransactionViewModel()
        {
            InventoryProductionMasterAndTransactionDTO = new InventoryProductionMasterAndTransaction();
            IngridentsListByVarients = new List<InventoryProductionMasterAndTransaction>();
            ViewItemList = new List<InventoryProductionMasterAndTransaction>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();
            GetUnitsList = new List<InventoryProductionMasterAndTransaction>();
        }

        public List<InventoryProductionMasterAndTransaction> GetUnitsList { get; set; }

        public IEnumerable<SelectListItem> ListGeneralTaxMasterItems
        {
            get
            {
                return new SelectList(GetUnitsList, "GeneralUnitsID", "UnitName");
            }
        }
        public List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetAdminRoleApplicableCentreItems
        {
            get
            {
                return new SelectList(ListGetAdminRoleApplicableCentre, "CentreCode", "CentreName");
            }
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreName
        {
            get;
            set;
        }
        public List<InventoryProductionMasterAndTransaction> IngridentsListByVarients { get; set; }
        public List<InventoryProductionMasterAndTransaction> ViewItemList { get; set; }
        public InventoryProductionMasterAndTransaction InventoryProductionMasterAndTransactionDTO
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.GeneralItemMasterID : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.GeneralItemMasterID = value;
            }
        }
        public int GeneralUnitsID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.GeneralUnitsID : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.GeneralUnitsID = value;
            }
        }
        public int StatusFlag
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.StatusFlag : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.StatusFlag = value;
            }
        }
        public Int16 ID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null && InventoryProductionMasterAndTransactionDTO.ID > 0) ? InventoryProductionMasterAndTransactionDTO.ID : new Int16();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ID = value;
            }
        }
        public int ItemNumber
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ItemNumber : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ItemNumber = value;
            }
        }
          [Display(Name = "Transaction Date")]
        public string TransactionDate
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.TransactionDate : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.TransactionDate = value;
            }
        }
          public string CentreCode
          {
              get
              {
                  return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.CentreCode : string.Empty;
              }
              set
              {
                  InventoryProductionMasterAndTransactionDTO.CentreCode = value;
              }
          }
        public string ItemName
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ItemName : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ItemName = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.XMLstring : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.XMLstring = value;
            }
        }
        public string BaseUomCode
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.BaseUomCode : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.BaseUomCode = value;
            }
        }
        public decimal ConversionFactor
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ConversionFactor : new decimal();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ConversionFactor = value;
            }
        }
        public decimal SalePrice
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.SalePrice : new decimal();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.SalePrice = value;
            }
        }
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ItemDescription : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ItemDescription = value;
            }
        }
        //Fields From InventoryRecipeMaster

        [Display(Name = "Main Menu Item")]
        public string InventoryRecipeMasterTitle
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.InventoryRecipeMasterTitle : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.InventoryRecipeMasterTitle = value;
            }
        }
        [Display(Name = "Description")]
        public string Description
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.Description : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.Description = value;
            }
        }
        public string VersionCode
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.VersionCode : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.VersionCode = value;
            }
        }
        public int PrimaryItemOutputId
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.PrimaryItemOutputId : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.PrimaryItemOutputId = value;
            }
        }
        public Int16 InventoryRecipeMasterID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.InventoryRecipeMasterID : new Int16();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.InventoryRecipeMasterID = value;
            }
        }
        public int OldRecipeId
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.OldRecipeId : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.OldRecipeId = value;
            }
        }

        //Fields From InventoryVariationMaster
        public Int16 InventoryVariationMasterID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.InventoryVariationMasterID : new Int16();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.InventoryVariationMasterID = value;
            }
        }
        [Display(Name = "Recipe Variation Title")]
        public string RecipeVariationTitle
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.RecipeVariationTitle : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.RecipeVariationTitle = value;
            }
        }

        //Fields From InventoryRecipeFormulaDetails
        public decimal Cost
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.Cost : new decimal();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.Cost = value;
            }
        }
        public int InventoryRecipeFormulaDetailsID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.InventoryRecipeFormulaDetailsID : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.InventoryRecipeFormulaDetailsID = value;
            }
        }
        public byte OrderNumber
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.OrderNumber : new byte();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.OrderNumber = value;
            }
        }
        //Fields From InventoryRecipeMenuMaster
        public Int16 InventoryRecipeMenuMaster
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.InventoryRecipeMenuMaster : new Int16();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.InventoryRecipeMenuMaster = value;
            }
        }
        public string MenuDescription
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.MenuDescription : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.MenuDescription = value;
            }
        }
        [Display(Name = "Define Variants")]
        public string DefineVariants
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.DefineVariants : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.DefineVariants = value;
            }
        }

        public string BOMRelevant
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.BOMRelevant : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.BOMRelevant = value;
            }
        }
        [Display(Name = "Billing Item Name")]
        public string BillingItemName
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.BillingItemName : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.BillingItemName = value;
            }
        }
        public string UnitName
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.UnitName : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.UnitName = value;
            }
        }

        public bool CheckInfo
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.CheckInfo : false;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.CheckInfo = value;
            }
        }
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.IsDeleted : false;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null && InventoryProductionMasterAndTransactionDTO.CreatedBy > 0) ? InventoryProductionMasterAndTransactionDTO.CreatedBy : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ModifiedBy : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.DeletedBy : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }
        public double Quantity
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null && InventoryProductionMasterAndTransactionDTO.Quantity > 0) ? InventoryProductionMasterAndTransactionDTO.Quantity : new double();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.Quantity = value;
            }
        }
        [Display(Name = "UoM code")]
        public string UoMCode
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.UoMCode : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.UoMCode = value;
            }
        }
        public int InventoryProductionTransactionID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.InventoryProductionTransactionID : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.InventoryProductionTransactionID = value;
            }
        }
        public int ProductionMasterID
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ProductionMasterID : new int();
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ProductionMasterID = value;
            }
        }
         [Display(Name = "Production Number")]
        public string ProductionNumber
        {
            get
            {
                return (InventoryProductionMasterAndTransactionDTO != null) ? InventoryProductionMasterAndTransactionDTO.ProductionNumber : string.Empty;
            }
            set
            {
                InventoryProductionMasterAndTransactionDTO.ProductionNumber = value;
            }
        }

    }
}

