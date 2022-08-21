using AERP.Common;
using AERP.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web;

namespace AERP.ViewModel
{
    public class GeneralItemMasterViewModel
    {
       
        public GeneralItemMasterViewModel()
        {
            GeneralItemMasterDTO = new GeneralItemMaster();
            GeneralTaxGroupMasterList = new List<GeneralTaxGroupMaster>();
            GeneralPackageTypeList = new List<GeneralPackageType>();
            GeneralCurrencyMasterList = new List<GeneralCurrencyMaster>();
            GeneralItemMasterListForUoMDetails = new List<GeneralItemMaster>();
            GeneralItemMasterListForSaleUoMDetails = new List<InventoryUoMMaster>();
            GeneralItemMasterListForGeneralUnits = new List<GeneralUnits>();
            GeneralItemMasterListForVarientDetails = new List<GeneralItemMaster>();
            GeneralItemMasterListForStoreData = new List<GeneralItemMaster>();
            GeneralItemMasterListForSaleData = new List<GeneralItemMaster>();
            GeneralItemMasterAttributeList = new List<GeneralItemMaster>();
            MultipleVendorListDataList = new List<GeneralItemMaster>();
            ListGetAdminRoleApplicableCentre = new List<AdminRoleApplicableDetails>();

            ListGeneralUnits = new List<GeneralUnits>();
        }
        public List<GeneralUnits> ListGeneralUnits
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> ListGetGeneralUnitsItems
        {
            get
            {
                return new SelectList(ListGeneralUnits, "ID", "UnitName");
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
        public List<GeneralTaxGroupMaster> GeneralTaxGroupMasterList { get; set; }
        public List<GeneralPackageType> GeneralPackageTypeList { get; set; }
        public List<GeneralCurrencyMaster> GeneralCurrencyMasterList { get; set; }
        public List<GeneralItemMaster> GeneralItemMasterListForUoMDetails { get; set; }
        public List<InventoryUoMMaster> GeneralItemMasterListForSaleUoMDetails { get; set; }
        public List<GeneralUnits> GeneralItemMasterListForGeneralUnits { get; set; }
        public List<GeneralItemMaster> GeneralItemMasterListForVarientDetails { get; set; }
        public List<GeneralItemMaster> GeneralItemMasterListForStoreData { get; set; }
        public List<GeneralItemMaster> GeneralItemMasterListForSaleData { get; set; }
        public List<GeneralItemMaster> GeneralItemMasterAttributeList { get; set; }
        public List<GeneralItemMaster> MultipleVendorListDataList { get; set; }

        public HttpPostedFileBase ExcelFile { get; set; }

        public GeneralItemMaster GeneralItemMasterDTO
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> GeneralTaxGroupListItems
        {
            get
            {
                return new SelectList(GeneralTaxGroupMasterList, "ID", "TaxGroupName");
            }
        }
        public IEnumerable<SelectListItem> GeneralCurrencyListItems
        {
            get
            {
                return new SelectList(GeneralCurrencyMasterList, "ID", "CurrencyName");
            }
        }
        public IEnumerable<SelectListItem> GeneralPackageTypeListItems
        {
            get
            {
                return new SelectList(GeneralPackageTypeList, "ID", "PackageType");
            }
        }
        public bool IsActive
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsActive : false;
            }
            set
            {
                GeneralItemMasterDTO.IsActive = value;
            }
        }

        public int ID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ID : new int();
            }
            set
            {
                GeneralItemMasterDTO.ID = value;
            }
        }
        public int InventoryAttributeMasterID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryAttributeMasterID : new int();
            }
            set
            {
                GeneralItemMasterDTO.InventoryAttributeMasterID = value;
            }
        }
        public int InventoryRecipeMenuMasterID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryRecipeMenuMasterID : new int();
            }
            set
            {
                GeneralItemMasterDTO.InventoryRecipeMenuMasterID = value;
            }
        }
        public int InventoryRecipeMenuCategoryID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryRecipeMenuCategoryID : new int();
            }
            set
            {
                GeneralItemMasterDTO.InventoryRecipeMenuCategoryID = value;
            }
        }
        public int GeneralItemMasterID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemMasterID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemMasterID = value;
            }
        }
       // [Required(ErrorMessage = "Item Number should not be blank.")]
        [Display(Name = "Item Number")]
        public int ItemNumber
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemNumber : new int();
            }
            set
            {
                GeneralItemMasterDTO.ItemNumber = value;
            }
        }
        [Display(Name = "Attribute Description")]
        public string AttributeName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.AttributeName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.AttributeName = value;
            }
        }
        [Display(Name = "Billing Display Name")]
        public string ArabicTransalation
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ArabicTransalation : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ArabicTransalation = value;
            }
        }
        [Display(Name = "Short Description")]
        public string ArabicTransalationForMainMenu
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ArabicTransalationForMainMenu : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ArabicTransalationForMainMenu = value;
            }
        }
        //[Required(ErrorMessage = "Item Description should not be blank.")]
        [Display(Name = "Item Description")]
        public string ItemDescription
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemDescription : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ItemDescription = value;
            }
        }
         // [Required(ErrorMessage = "Recipe Menu Category should not be blank.")]
        [Display(Name = "Recipe Menu Category")]
        public int RecipeMenuCategoryID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RecipeMenuCategoryID : new int();
            }
            set
            {
                GeneralItemMasterDTO.RecipeMenuCategoryID = value;
            }
        }
        public string RecipeMenuCategoryCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RecipeMenuCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.RecipeMenuCategoryCode = value;
            }
        }
        [Display(Name = "Short Description")]
        public string ShortDescription
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ShortDescription : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ShortDescription = value;
            }
        }

        [Display(Name = "Brand Description")]
        public string BrandName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BrandName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.BrandName = value;
            }
        }

        [Display(Name = "Purchase Group")]
        public int InventoryPurchaseGroupMasterId
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryPurchaseGroupMasterId : new int();
            }
            set
            {
                GeneralItemMasterDTO.InventoryPurchaseGroupMasterId = value;
            }
        }
         [Required(ErrorMessage = "Please Select Item Category Code.")]
        [Display(Name = "Item Category Code")]
        public string ItemCategoryCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemCategoryCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ItemCategoryCode = value;
            }
        }
        [Display(Name = "Item Category Code")]
        public string ItemCategoryCode_Param
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemCategoryCode_Param : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ItemCategoryCode_Param = value;
            }
        }
        [Display(Name = "UoM code")]
        public string BaseUoMcode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BaseUoMcode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.BaseUoMcode = value;
            }
        }
        [Display(Name = "Cost Per Ordering Unit")]
        public double LastPurchasePrice
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.LastPurchasePrice : new double();
            }
            set 
            {
                GeneralItemMasterDTO.LastPurchasePrice = value;
            }
        }
       
        public double Price
        {
            get;
            set;
        }
        [Display(Name = "Currency Code")]
        public string CurrencyCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CurrencyCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.CurrencyCode = value;
            }
        }
        [Display(Name = "Bar Code")]
        public string BaseBarCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BaseBarCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.BaseBarCode = value;
            }
        }
        [Display(Name = "Price List")]
        public Int16 BasePriceListID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BasePriceListID : new Int16();
            }
            set
            {
                GeneralItemMasterDTO.BasePriceListID = value;
            }
        }
        [Display(Name = "Inventory Item")]
        public bool IsInventoryItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsInventoryItem : false;
            }
            set
            {
                GeneralItemMasterDTO.IsInventoryItem = value;
            }
        }
        public bool StatusFlag
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.StatusFlag : false;
            }
            set
            {
                GeneralItemMasterDTO.StatusFlag = value;
            }
        }
        [Display(Name = "Sales Item")]
        public bool IsSalesItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsSalesItem : false;
            }
            set
            {
                GeneralItemMasterDTO.IsSalesItem = value;
            }
        }
        [Display(Name = "Purchase Item")]
        public bool IsPurchaseItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsPurchaseItem : false;
            }
            set
            {
                GeneralItemMasterDTO.IsPurchaseItem = value;
            }
        }
        [Display(Name = "Fixed Asset Item")]
        public bool IsFixedAssetItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsFixedAssetItem : false;
            }
            set
            {
                GeneralItemMasterDTO.IsFixedAssetItem = value;
            }
        }
          [Display(Name = "Retail Sale")]
        public bool RetailSale
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RetailSale : false;
            }
            set
            {
                GeneralItemMasterDTO.RetailSale = value;
            }
        }
        public bool BOM
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BOM : false;
            }
            set
            {
                GeneralItemMasterDTO.BOM = value;
            }
        }
        public bool Restaurant
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Restaurant : false;
            }
            set
            {
                GeneralItemMasterDTO.Restaurant = value;
            }
        }
        [Display(Name = "UoM Group Code")]
        public string UoMGroupCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UoMGroupCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.UoMGroupCode = value;
            }
        }
        [Display(Name = "Item Type")]
        public Byte ItemType
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemType : new byte();
            }
            set
            {
                GeneralItemMasterDTO.ItemType = value;
            }
        }
        [Display(Name = "Item Code")]
        public int GeneralItemCodeID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemCodeID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemCodeID = value;
            }
        }
        [Display(Name = "Bar Code")]
        public string BarCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BarCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.BarCode = value;
            }
        }
        [Display(Name = "Is Default")]
        public bool IsDefault
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsDefault : false;
            }
            set
            {
                GeneralItemMasterDTO.IsDefault = value;
            }
        }
        [Display(Name = "Is Base Uom")]
        public bool IsBaseUom
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsBaseUom : false;
            }
            set
            {
                GeneralItemMasterDTO.IsBaseUom = value;
            }
        }
      
        [Display(Name = "Uom Code")]
        public string UomCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UomCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.UomCode = value;
            }
        }
        //GeneralItemSupliersData
        public int GeneralItemSupliersDataID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemSupliersDataID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemSupliersDataID = value;
            }
        }
        [Display(Name = "General Vendor")]
        public int GeneralVendorID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralVendorID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralVendorID = value;
            }
        }
        [Display(Name = "Vendor")]
        public string VendorName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.VendorName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.VendorName = value;
            }
        }
        [Display(Name = "Supplier Catalog Number")]
        public string ManufacturCatalogNumber
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ManufacturCatalogNumber : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ManufacturCatalogNumber = value;
            }
        }
        [Display(Name = "Purchase UoM Code")]
        public string PurchaseUoMCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PurchaseUoMCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.PurchaseUoMCode = value;
            }
        }
        [Display(Name = "Purchase Group")]
        public byte GeneralPurchaseGroupMasterID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralPurchaseGroupMasterID : new byte();
            }
            set
            {
                GeneralItemMasterDTO.GeneralPurchaseGroupMasterID = value;
            }
        }
         [Required(ErrorMessage = "Please Select Tax Group.")]
        [Display(Name = "Tax Group")]
        public Int16 GenTaxGroupMasterID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BasePriceListID : new Int16();
            }
            set
            {
                GeneralItemMasterDTO.BasePriceListID = value;
            }
        }
        [Display(Name = "Package Type")]
        public string PackageType
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PackageType : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.PackageType = value;
            }
        }
        ////methods of GeneralItemGeneralData
        public int GeneralItemGeneralDataID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemGeneralDataID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemGeneralDataID = value;
            }
        }
        [Display(Name = "Shipping Type")]
        public byte ShippingTypeId
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralPurchaseGroupMasterID : new byte();
            }
            set
            {
                GeneralItemMasterDTO.GeneralPurchaseGroupMasterID = value;
            }
        }
        [Display(Name = "Manufacturer")]
        public Int16 ManufacturerID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ManufacturerID : new Int16();
            }
            set
            {
                GeneralItemMasterDTO.ManufacturerID = value;
            }
        }
         [Display(Name = "Item Managed By")]
        public byte SerialAndBatchManagedBy
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SerialAndBatchManagedBy : new byte();
            }
            set
            {
                GeneralItemMasterDTO.SerialAndBatchManagedBy = value;
            }
        }   
        [Display(Name = "Management Method")]
        public byte ManagementMethod
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ManagementMethod : new byte();
            }
            set
            {
                GeneralItemMasterDTO.ManagementMethod = value;
            }
        }
           [Display(Name = "Issue Method")]
        public byte IssueMethod
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IssueMethod : new byte();
            }
            set
            {
                GeneralItemMasterDTO.IssueMethod = value;
            }
        }
        ////GeneralItemSalesData
        public int GeneralItemSalesDataID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemSalesDataID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemSalesDataID = value;
            }
        }
         [Display(Name = "Sale UoM Code")]
        public string SaleUoMCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SaleUoMCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.SaleUoMCode = value;
            }
        }
          [Display(Name = "Item Per Sale")]
        public byte ItemPerSaleUnit
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemPerSaleUnit : new byte();
            }
            set
            {
                GeneralItemMasterDTO.ItemPerSaleUnit = value;
            }
        }
        [Display(Name = "Packing Unit Sale")]
        public string PackingUnitSale
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PackingUnitSale : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.PackingUnitSale = value;
            }
        }
        [Display(Name = "Qty Per Unit")]
        public byte QuantityPerPackingUnitSale
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.QuantityPerPackingUnitSale : new byte();
            }
            set
            {
                GeneralItemMasterDTO.QuantityPerPackingUnitSale = value;
            }
        }
        ////GeneralItemStockData
        public int GeneralItemStockDataID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemStockDataID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemStockDataID = value;
            }
        }
         [Display(Name = "GLAccount By")]
        public byte GLAccountBy
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GLAccountBy : new byte();
            }
            set
            {
                GeneralItemMasterDTO.GLAccountBy = value;
            }
        }
         [Display(Name = "Stock UoM Code")]
        public string StockUoMCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.StockUoMCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.StockUoMCode = value;
            }
        }
          [Display(Name = "Valuation Method")]
        public byte ValuationMethod
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ValuationMethod : new byte();
            }
            set
            {
                GeneralItemMasterDTO.ValuationMethod = value;
            }
        }
        [Display(Name = "Min Stock")]
        public Int16 MinStock
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MinStock : new Int16();
            }
            set
            {
                GeneralItemMasterDTO.MinStock = value;
            }

        }
         [Display(Name = "Max Stock")]
        public Decimal MaxStock
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MaxStock : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.MaxStock = value;
            }
        }
         public Decimal ConvertionFactor
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ConvertionFactor : new decimal();
             }
             set
             {
                 GeneralItemMasterDTO.ConvertionFactor = value;
             }
         }
        //Common Properties
        [Display(Name = "IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsDeleted : false;
            }
            set
            {
                GeneralItemMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CreatedBy : new int();
            }
            set
            {
                GeneralItemMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "ModifiedBy")]
        public int ModifiedBy
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ModifiedBy : new int();
            }
            set
            {
                GeneralItemMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "ModifiedDate")]
        public DateTime ModifiedDate
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DeletedBy")]
        public int DeletedBy
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.DeletedBy : new int();
            }
            set
            {
                GeneralItemMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DeletedDate")]
        public DateTime DeletedDate
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                GeneralItemMasterDTO.DeletedDate = value;
            }
        }


        public string errorMessage { get; set; }

        public string TaskCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.TaskCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.TaskCode = value;
            }
        }
          [Display(Name = "Base Quantity")]
        public decimal BaseQty
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BaseQty : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.BaseQty = value;
            }
        }
          //[Display(Name = "Alternative Uom Name")]
        public string AltUomName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.AltUomName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.AltUomName = value;
            }
        }
        [Display(Name = "Transaction Type")]
        public Byte UomTransactionType
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UomTransactionType : new byte();
            }
            set
            {
                GeneralItemMasterDTO.UomTransactionType = value;
            }
        }
        [Display(Name = "Store")]
        public Int16 GeneralUnitsID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralUnitsID : new Int16();
            }
            set
            {
                GeneralItemMasterDTO.GeneralUnitsID = value;
            }
        }
        [Display(Name = "Lead Time")]
        public string LeadTime
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.LeadTime : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.LeadTime = value;
            }
        }
         [Display(Name = "Total Shelf Life(Days)")]
        public string ShelfLife
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ShelfLife : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ShelfLife = value;
            }
        }
         [Display(Name = "Minimum Remaining Shelf Life(Days)")]
         public string RemainingShelfLife
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RemainingShelfLife : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.RemainingShelfLife = value;
             }
         }
           [Display(Name = "Country Of Origin")]
        public string CountryOfOrigin
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CountryOfOrigin : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.CountryOfOrigin = value;
            }
        }
         [Display(Name = "HS Code")]
        public string HSCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.HSCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.HSCode = value;
            }
        }
         [Required(ErrorMessage = "Please Select Temperature.")]  
        [Display(Name = "Temperature")]
        public decimal Temprature
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Temprature : new decimal();

            }
            set
            {
                GeneralItemMasterDTO.Temprature = value;
            }
        }
          [Display(Name = "Temprature Upto")]
          public decimal TempratureUpto
          {
              get
              {
                  return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.TempratureUpto : new decimal();
              }
              set
              {
                  GeneralItemMasterDTO.TempratureUpto = value;
              }
          }
          [Display(Name = "Temprature From")]
          public decimal TempratureFrom
          {
              get
              {
                  return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.TempratureFrom : new decimal();
              }
              set
              {
                  GeneralItemMasterDTO.TempratureFrom = value;
              }
          }
         [Display(Name = "Purchase Organization")]
        public string PurchaseOrganization
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PurchaseOrganization : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.PurchaseOrganization = value;
            }
        }
         [Required(ErrorMessage = "Minimum Order Quantity should not be blank.")]  
        [Display(Name = "Minimum Order Quantity")]
        public decimal MinimumOrderquantity
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MinimumOrderquantity : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.MinimumOrderquantity = value;
            }
        }
        public string XMLstring
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.XMLstring : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.XMLstring = value;
            }
        }
        //store specific information
        public string CentreCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CentreCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.CentreCode = value;
            }
        }
        [Display(Name = "Planner Code")]
        public string PlannerCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PlannerCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.PlannerCode = value;
            }
        }
         [Display(Name = "lead Time Uom")]
        public string leadTimeUom
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.leadTimeUom : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.leadTimeUom = value;
            }
        }
         [Display(Name = "lead Time")]
         public decimal LeadTimeForStore
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.LeadTimeForStore : new decimal();
             }
             set
             {
                 GeneralItemMasterDTO.LeadTimeForStore = value;
             }
         }
          [Display(Name = "Supply Source")]
        public string SupplySource
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SupplySource : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.SupplySource = value;
            }
        }
        public string GRPUomCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GRPUomCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.GRPUomCode = value;
            }
        }
         [Required(ErrorMessage = "Ordering Method should not be blank.")]
        [Display(Name = "Ordering Method")]
        public Byte RPType
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RPType : new byte();
            }
            set
            {
                GeneralItemMasterDTO.RPType = value;
            }
        }
         [Required(ErrorMessage = "Ordering Day should not be blank.")]
         [Display(Name = "Ordering Day")]
        public int OrderingDay
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.OrderingDay : new int();
            }
            set
            {
                GeneralItemMasterDTO.OrderingDay = value;
            }
        }
         [Required(ErrorMessage = "Delivery Day should not be blank.")]
        [Display(Name = "Delivery Day")]
         public int DeliveryDay
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.DeliveryDay : new int();
            }
            set
            {
                GeneralItemMasterDTO.DeliveryDay = value;
            }
        }
         [Display(Name = "Procurement Block")]
        public bool BlockforProcurutment
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BlockforProcurutment : false;
            }
            set
            {
                GeneralItemMasterDTO.BlockforProcurutment = value;
            }
        }
        public double Quantity
        {
            get
            {
                return (GeneralItemMasterDTO != null && GeneralItemMasterDTO.Quantity > 0) ? GeneralItemMasterDTO.Quantity : new double();
            }
            set
            {
                GeneralItemMasterDTO.Quantity = value;
            }
        }
        [Display(Name = "Rounding Profile")]
        public double RoundingProfile
        {
            get
            {
                return (GeneralItemMasterDTO != null && GeneralItemMasterDTO.RoundingProfile > 0) ? GeneralItemMasterDTO.RoundingProfile : new double();
            }
            set
            {
                GeneralItemMasterDTO.RoundingProfile = value;
            }
        }
         [Display(Name = "GR Proccessing Time")]
        public double GRProccessingTime
        {
            get
            {
                return (GeneralItemMasterDTO != null && GeneralItemMasterDTO.GRProccessingTime > 0) ? GeneralItemMasterDTO.GRProccessingTime : new double();
            }
            set
            {
                GeneralItemMasterDTO.GRProccessingTime = value;
            }
        }
         public string XMLstringForSaleUomcode
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.XMLstringForSaleUomcode : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.XMLstringForSaleUomcode = value;
             }
         }

         public int InventoryItemCodeCentreLevelSpecificInfoID
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryItemCodeCentreLevelSpecificInfoID : new int();
             }
             set
             {
                 GeneralItemMasterDTO.InventoryItemCodeCentreLevelSpecificInfoID = value;
             }
         }
         public int InventoryItemStoreSpecificInfoID
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryItemStoreSpecificInfoID : new int();
             }
             set
             {
                 GeneralItemMasterDTO.InventoryItemStoreSpecificInfoID = value;
             }
         }
         public string GeneralItemStoreSpecificDetailsXml
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemStoreSpecificDetailsXml : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.GeneralItemStoreSpecificDetailsXml = value;
             }
         }

        //Fields From InventoryRecipeMaster

        [Display(Name = "Main Menu Item")]
         public string InventoryRecipeMasterTitle
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryRecipeMasterTitle : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.InventoryRecipeMasterTitle = value;
             }
         }
         [Display(Name = "Description")]
         public string Description
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Description : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.Description = value;
             }
         }
         public string VersionCode
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.VersionCode : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.VersionCode = value;
             }
         }
         public int PrimaryItemOutputId
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PrimaryItemOutputId : new int();
             }
             set
             {
                 GeneralItemMasterDTO.PrimaryItemOutputId = value;
             }
         }
         public Int16 InventoryRecipeMasterID
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryRecipeMasterID : new Int16();
             }
             set
             {
                 GeneralItemMasterDTO.InventoryRecipeMasterID = value;
             }
         }
         public int OldRecipeId
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.OldRecipeId : new int();
             }
             set
             {
                 GeneralItemMasterDTO.OldRecipeId = value;
             }
         }

        //Fields From InventoryVariationMaster
         public Int16 InventoryVariationMasterID
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryVariationMasterID : new Int16();
             }
             set
             {
                 GeneralItemMasterDTO.InventoryVariationMasterID = value;
             }
         }
         public string RecipeVariationTitle
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RecipeVariationTitle : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.RecipeVariationTitle = value;
             }
         }

        //Fields From InventoryRecipeFormulaDetails
         public decimal Cost
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Cost : new decimal();
             }
             set
             {
                 GeneralItemMasterDTO.Cost = value;
             }
         }
         public int InventoryRecipeFormulaDetailsID
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryRecipeFormulaDetailsID : new int();
             }
             set
             {
                 GeneralItemMasterDTO.InventoryRecipeFormulaDetailsID = value;
             }
         }
         public byte OrderNumber
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.OrderNumber : new byte();
             }
             set
             {
                 GeneralItemMasterDTO.OrderNumber = value;
             }
         }
        //Fields From InventoryRecipeMenuMaster
         public Int16 InventoryRecipeMenuMaster
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryRecipeMenuMaster : new Int16();
             }
             set
             {
                 GeneralItemMasterDTO.InventoryRecipeMenuMaster = value;
             }
         }
         public string MenuDescription
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuDescription : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.MenuDescription = value;
             }
         }
         [Display(Name = "Define Variants")]
         public string DefineVariants
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.DefineVariants : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.DefineVariants = value;
             }
         }
        [Display(Name = "BOM Relevant")]
         public string BOMRelevant
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BOMRelevant : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.BOMRelevant = value;
             }
         }
         [Display(Name = "Billing Item Name")]
         public string BillingItemName
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.BillingItemName : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.BillingItemName = value;
             }
         }
         public string UnitName
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UnitName : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.UnitName = value;
             }
         }


         public HttpPostedFileBase MenuPhotoFile { get; set; }

         public bool IsFile { get; set; }

         [Range(0, int.MaxValue)]
         public int X { get; set; }

         [Range(0, int.MaxValue)]
         public int Y { get; set; }

         [Range(1, int.MaxValue)]
         public int Width { get; set; }

         [Range(1, int.MaxValue)]
         public int Height { get; set; }

         public byte[] MenuPhoto
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuPhoto : new byte[1];         //review this       
             }
             set
             {
                 GeneralItemMasterDTO.MenuPhoto = value;
             }
         }


         public string MenuPhotoType
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuPhotoType : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.MenuPhotoType = value;
             }
         }


         public string MenuPhotoFilename
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuPhotoFilename : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.MenuPhotoFilename = value;
             }
         }

         public string MenuPhotoFileWidth
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuPhotoFileWidth : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.MenuPhotoFileWidth = value;
             }
         }


         public string MenuPhotoFileHeight
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuPhotoFileHeight : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.MenuPhotoFileHeight = value;
             }
         }


         public string MenuPhotoFileSize
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MenuPhotoFileSize : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.MenuPhotoFileSize = value;
             }
         }
         [Required(ErrorMessage = "Reorder Point should not be blank.")]
         [Display(Name = "Reorder Point")]
         public Byte ReorderPoint
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ReorderPoint : new Byte();
             }
             set
             {
                 GeneralItemMasterDTO.ReorderPoint = value;
             }
         }
         [Display(Name = "Safety Stock")]
         public Byte SafetyStockDriven
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SafetyStockDriven : new Byte();
             }
             set
             {
                 GeneralItemMasterDTO.SafetyStockDriven = value;
             }
         }

         public string ActionOn
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ActionOn : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.ActionOn = value;
             }
         }
         public string ActionName
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ActionName : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.ActionName = value;
             }
         }
         public int ActionID
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ActionID : new int();
             }
             set
             {
                 GeneralItemMasterDTO.ActionID = value;
             }
         }

         public bool IsExists
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsExists : false;
             }
             set
             {
                 GeneralItemMasterDTO.IsExists = value;
             }
         }

        public string CroppedImagePath
         {
             get
             {
                 return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CroppedImagePath : string.Empty;
             }
             set
             {
                 GeneralItemMasterDTO.CroppedImagePath = value;
             }
         }
        public string EComCroppedImagePath
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.EComCroppedImagePath : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.EComCroppedImagePath = value;
            }
        }
        public string MyFile
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MyFile : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.MyFile = value;
            }
        }
        public decimal PriceForVariation
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PriceForVariation : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.PriceForVariation = value;
            }
        }
          [Display(Name = "Price")]
        public decimal PriceForRecipe
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PriceForRecipe : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.PriceForRecipe = value;
            }
        }
        public string XMLstringForRestuarent
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.XMLstringForRestuarent : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.XMLstringForRestuarent = value;
            }
        }
        public int InventoryItemCodeUnitLevelSpecificInfoID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.InventoryItemCodeUnitLevelSpecificInfoID : new int();
            }
            set
            {
                GeneralItemMasterDTO.InventoryItemCodeUnitLevelSpecificInfoID = value;
            }
        }
            //dimension tab

        public decimal Length
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Length : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.Length = value;
            }
        }
        [Display(Name = "Width")]
        public decimal WidthOfItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.WidthOfItem : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.WidthOfItem = value;
            }
        }
         [Display(Name = "Height")]
        public decimal HeightOfItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.HeightOfItem : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.HeightOfItem = value;
            }
        }
        public decimal Volume
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Volume : new decimal();
            }
            set
            {
                GeneralItemMasterDTO.Volume = value;
            }
        }
        public string PurchaseGroupCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.PurchaseGroupCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.PurchaseGroupCode = value;
            }
        }
        public Byte OrderingUnitcheckboxFlag
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.OrderingUnitcheckboxFlag : new byte();
            }
            set
            {
                GeneralItemMasterDTO.OrderingUnitcheckboxFlag = value;
            }
        }
        public string VendorProductCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.VendorProductCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.VendorProductCode = value;
            }
        }
        [Display(Name = "Manufacturer Name")]
        public string ManufacturerName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ManufacturerName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ManufacturerName = value;
            }
        }
          [Display(Name = "Vendor Number")]
        public int VendorNumber
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.VendorNumber : new int();
            }
            set
            {
                GeneralItemMasterDTO.VendorNumber = value;
            }
        }
         [Display(Name = "Net Content Per Piece")]
        public decimal NetContentPerPiece
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.NetContentPerPiece : new int();
            }
            set
            {
                GeneralItemMasterDTO.NetContentPerPiece = value;
            }
        }
        [Display(Name = "Gross Weight Per Piece")]
        public decimal NetWeightPerPiece
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.NetWeightPerPiece : new int();
            }
            set
            {
                GeneralItemMasterDTO.NetWeightPerPiece = value;
            }
        }
          [Display(Name = "Net Content UOM")]
        public string NetContentUOM
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.NetContentUOM : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.NetContentUOM = value;
            }
        }
        [Display(Name = "Special Feature")]
        public string SpecialFeature
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SpecialFeature : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.SpecialFeature = value;
            }
        }
        
        public string UomDetailsParameterXML1
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UomDetailsParameterXML1 : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.UomDetailsParameterXML1 = value;
            }
        }
        
        public string UomDetailsParameterXML2
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UomDetailsParameterXML2 : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.UomDetailsParameterXML2 = value;
            }
        }
        
        public string UomDetailsParameterXML3
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.UomDetailsParameterXML3 : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.UomDetailsParameterXML3 = value;
            }
        }
        [Display(Name = "Shelf Number")]
        public string ShelfNumber
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ShelfNumber : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ShelfNumber = value;
            }
        }
        [Display(Name = "Facing")]
        public int Facing
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Facing : new int();
            }
            set
            {
                GeneralItemMasterDTO.Facing = value;
            }
        }
        [Display(Name = "Is Related With")]
        public Byte IsRelatedWithCafe
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsRelatedWithCafe : new byte();
            }
            set
            {
                GeneralItemMasterDTO.IsRelatedWithCafe = value;
            }
        }
        public string XMLstringForAttribute
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.XMLstringForAttribute : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.XMLstringForAttribute = value;
            }
        }
        public int GeneralItemAttributeDataID
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GeneralItemAttributeDataID : new int();
            }
            set
            {
                GeneralItemMasterDTO.GeneralItemAttributeDataID = value;
            }
        }
        public string RecipeVariationDescription
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.RecipeVariationDescription : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.RecipeVariationDescription = value;
            }
        }
        [Display(Name = "Multiple Vendor")]
        public bool IsMultipleVendor
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsMultipleVendor : false;
            }
            set
            {
                GeneralItemMasterDTO.IsMultipleVendor = value;
            }
        }
        [Display(Name = "Service Item")]
        public bool IsServiceItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsServiceItem : false;
            }
            set
            {
                GeneralItemMasterDTO.IsServiceItem = value;
            }
        }

        public bool IsEComItem
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsEComItem : false;
            }
            set
            {
                GeneralItemMasterDTO.IsEComItem = value;
            }
        }
        public bool IsDefaultVendor
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsDefaultVendor : false;
            }
            set
            {
                GeneralItemMasterDTO.IsDefaultVendor = value;
            }
        }
        [Display(Name = "Display Name")]
        public string DisplayName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.DisplayName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.DisplayName = value;
            }
        }
        public string ImageNameString
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ImageNameString : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ImageNameString = value;
            }
        }
        public string ItemCategoryDescription
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemCategoryDescription : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ItemCategoryDescription = value;
            }
        }
        public string GroupDescription
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.GroupDescription : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.GroupDescription = value;
            }
        }
        public string MerchantiseDepartmentName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MerchantiseDepartmentName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.MerchantiseDepartmentName = value;
            }
        }
        public string MerchantiseCategoryName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MerchantiseCategoryName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.MerchantiseCategoryName = value;
            }
        }
        public string MerchantiseSubCategoryName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MerchantiseSubCategoryName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.MerchantiseSubCategoryName = value;
            }
        }
        public string MarchandiseBaseCatgoryName
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.MarchandiseBaseCatgoryName : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.MarchandiseBaseCatgoryName = value;
            }
        }
        public string SelectedCentreCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SelectedCentreCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.SelectedCentreCode = value;
            }
        }

        public string SelectedCentreCodeForSaleTab
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SelectedCentreCodeForSaleTab : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.SelectedCentreCodeForSaleTab = value;
            }
        }

        public string XMLstringForMultipleImageUpload
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.XMLstringForMultipleImageUpload : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.XMLstringForMultipleImageUpload = value;
            }
        }
        public string CentreListXML
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.CentreListXML : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.CentreListXML = value;
            }
        }
        [Display(Name = "HSN/SAC Code")]
        public string HSNCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.HSNCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.HSNCode = value;
            }
        }
        [Display(Name = "Item Code")]
        public string ItemCode
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.ItemCode : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.ItemCode = value;
            }
        }
        public bool IsConsumable
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsConsumable : new bool();
            }
            set
            {
                GeneralItemMasterDTO.IsConsumable = value;
            }
        }
        public bool IsMachine
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsMachine : new bool();
            }
            set
            {
                GeneralItemMasterDTO.IsMachine = value;
            }
        }
        public bool IsToner
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.IsToner : new bool();
            }
            set
            {
                GeneralItemMasterDTO.IsToner = value;
            }
        }

        public string VersionNumber
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.VersionNumber : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.VersionNumber = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (GeneralItemMasterDTO != null && GeneralItemMasterDTO.LastSyncDate.HasValue) ? GeneralItemMasterDTO.LastSyncDate : null;
            }
            set
            {
                GeneralItemMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.SyncType : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (GeneralItemMasterDTO != null) ? GeneralItemMasterDTO.Entity : string.Empty;
            }
            set
            {
                GeneralItemMasterDTO.Entity = value;
            }
        }
    }
}

