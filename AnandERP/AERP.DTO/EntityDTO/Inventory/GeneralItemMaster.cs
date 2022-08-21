using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralItemMaster : BaseDTO
    {
        // Properties from GeneralItemMaster
        public int ID
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }

        public int InventoryRecipeMenuMasterID
        {  get;
            set;
        }

        public int InventoryAttributeMasterID
         {  
            get;
            set;
        }
        public int InventoryRecipeMenuCategoryID
        {
            get;
            set;
        }
        public int GeneralItemMasterID
        {
            get;
            set;
        }
        public int ItemNumber
        {
            get;
            set;
        }
        public string AttributeName
        {
            get;
            set;
        }
        public string ArabicTransalation
        {
            get;
            set;
        }
        public string ArabicTransalationForMainMenu
        {
            get;
            set;
        }
        public string ShortDescription
        {
            get;
            set;
        }
        public string ItemDescription
        {
            get;
            set;
        }
        public string ItemCategoryCode
        {
            get;
            set;
        }
        public string ItemCategoryCode_Param
        {
            get;
            set;
        }
        public string BaseUoMcode
        {
            get;
            set;
        }
        public int RecipeMenuCategoryID
            {
            get;
            set;
        }
        public string RecipeMenuCategoryCode
        {
            get;
            set;
        }
        public double LastPurchasePrice
        {
            get;
            set;
        }
        public string CurrencyCode
        {
            get;
            set;
        }
        public string BaseBarCode
        {
            get;
            set;
        }
        public Int16 BasePriceListID
        {
            get;
            set;
        }
        public int InventoryPurchaseGroupMasterId
        {
            get;
            set;
        }
        public bool IsInventoryItem
        {
            get;
            set;
        }
        public bool IsSalesItem
        {
            get;
            set;
        }
        public bool IsPurchaseItem
        {
            get;
            set;
        }
        public bool IsFixedAssetItem
        {
            get;
            set;
        }
        public bool RetailSale
        {
            get;
            set;
        }
        public bool BOM
        {
            get;
            set;
        }
        public bool Restaurant
        {
            get;
            set;
        }
        public bool StatusFlag
        {
            get;
            set;
        }
        public string UoMGroupCode
        {
            get;
            set;
        }
        public byte ItemType
        {
            get;
            set;
        }
        //GeneralItemCode
        public int GeneralItemCodeID
        {
            get;
            set;
        }
        public string BarCode
        {
            get;
            set;
        }
        public bool IsDefault
        {
            get;
            set;
        }
        public bool IsBaseUom
        {
            get;
            set;
        }
        public string BaseUomCode
        {
            get;
            set;
        }
        public string UomCode
        {
            get;
            set;
        }
        public decimal BaseQty
        {
            get;
            set;
        }
        public string AltUomName
        {
            get;
            set;
        }
        public byte UomTransactionType
        {
            get;
            set;
        }
        public Int16 GeneralUnitsID
        {
            get;
            set;
        }
        //GeneralItemSupliersData
        public int GeneralItemSupliersDataID
        {
            get;
            set;
        }
        public int GeneralVendorID
        {
            get;
            set;
        }
        public string VendorName
        {
            get;
            set;
        }
        public string ManufacturCatalogNumber
        {
            get;
            set;
        }
        public string PurchaseUoMCode
        {
            get;
            set;
        }
        public byte GeneralPurchaseGroupMasterID
        {
            get;
            set;
        }
        public Int16 GenTaxGroupMasterID
        {
            get;
            set;
        }
        public string PackageType
        {
            get;
            set;
        }
        //methods of GeneralItemGeneralData
        public string BrandName
        {
            get;
            set;
        }
        public int GeneralItemGeneralDataID
        {
            get;
            set;
        }
        public byte ShippingTypeId
        {
            get;
            set;
        }
        public Int16 ManufacturerID
        {
            get;
            set;
        }
        public byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
        public byte ManagementMethod
        {
            get;
            set;
        }
        public byte IssueMethod
        {
            get;
            set;
        }
        public decimal NetContentPerPiece
        {
            get;
            set;
        }
        public decimal NetWeightPerPiece
        {
            get;
            set;
        }
        public string NetContentUOM
        {
            get;
            set;
        }
        public string SpecialFeature
        {
            get;
            set;
        }
        //GeneralItemSalesData
        public int GeneralItemSalesDataID
        {
            get;
            set;
        }
        public string SaleUoMCode
        {
            get;
            set;
        }
        public byte ItemPerSaleUnit
        {
            get;
            set;
        }
        public string PackingUnitSale
        {
            get;
            set;
        }
        public byte QuantityPerPackingUnitSale
        {
            get;
            set;
        }
        //GeneralItemStockData
        public int GeneralItemStockDataID
        {
            get;
            set;
        }
        public byte GLAccountBy
        {
            get;
            set;
        }

        public string StockUoMCode
        {
            get;
            set;
        }
        public byte ValuationMethod
        {
            get;
            set;
        }
        public string UoMCode
        {
            get;
            set;
        }
        public Int16 MinStock
        {
            get;
            set;
        }
        public decimal MaxStock
        {
            get;
            set;
        }
        //Common Properties
        public bool IsDeleted
        {
            get;
            set;
        }
        public int CreatedBy
        {
            get;
            set;
        }
        public DateTime CreatedDate
        {
            get;
            set;
        }
        public int ModifiedBy
        {
            get;
            set;
        }
        public DateTime ModifiedDate
        {
            get;
            set;
        }
        public int DeletedBy
        {
            get;
            set;
        }
        public DateTime DeletedDate
        {
            get;
            set;
        }
        public string errorMessage { get; set; }
        public string TaskCode
        {
            get;
            set;
        }
        public decimal Temprature
        {
            get;
            set;
        }
        public decimal TempratureFrom
        {
            get;
            set;
        }
        public decimal TempratureUpto
        {
            get;
            set;
        }
        public decimal AltQty
        {
            get;
            set;
        }
        public string OrderUomCode
        {
            get;
            set;
        }
        public decimal BaseUOMQuantity
        {
            get;
            set;
        }
        public string BaseUOMCode
        {
            get;
            set;
        }
        public decimal TaxRate { get; set; }
        //Additional Feilds
        public string PurchaseOrganization
        {
            get;
            set;
        }
        public decimal MinimumOrderquantity
        {
            get;
            set;
        }
        public string LeadTime
        {
            get;
            set;
        }
        public string ShelfLife
        {
            get;
            set;
        }
        public string CountryOfOrigin
        {
            get;
            set;
        }

        public string HSCode
        {
            get;
            set;
        }
        public string XMLstring { get; set; }

        public bool IsSaleUnit
        {
            get;
            set;

        }
        public bool IsOrderingUnit
        {
            get;
            set;
        }
        public bool IsIssueUnit
        {
            get;
            set;
        }
        public string LowerLevelUomCode
        {
            get;
            set;
        }
        //store specific information fields

        public string CentreCode
        {
            get;
            set;
        }
        public Byte RPType
        {
            get;
            set;
        }
        public int OrderingDay
        {
            get;
            set;
        }
        public int DeliveryDay
        {
            get;
            set;
        }
        public double Quantity
        {
            get;
            set;
        }
        public double RoundingProfile
        {
            get;
            set;
        }
        public decimal LeadTimeForStore
        {
            get;
            set;
        }
        public double GRProccessingTime
        {
            get;
            set;
        }
        public string PlannerCode
        {
            get;
            set;
        }
        public string leadTimeUom
        {
            get;
            set;
        }
        public string SupplySource
        {
            get;
            set;
        }
        public bool BlockforProcurutment
        {
            get;
            set;
        }
        public string GRPUomCode
        {
            get;
            set;
        }
        public string XMLstringForSaleUomcode { get; set; }
        public string ListingDate
        {
            get;
            set;
        }
        public string DeListingDate
        {
            get;
            set;
        }
        public int InventoryItemCodeCentreLevelSpecificInfoID
        {
            get;
            set;
        }

        public int InventoryItemStoreSpecificInfoID
        {
            get;
            set;
        }
        public string GeneralItemStoreSpecificDetailsXml
        {
            get;
            set;
        }
        public Byte ReorderPoint { get; set; }
        public Byte SafetyStockDriven { get; set; }
        //Feilds From InventoryRecipeMaster
        public Int16 InventoryRecipeMasterID
        {
            get;
            set;
        }
        public string InventoryRecipeMasterTitle
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public int PrimaryItemOutputId
        {
            get;
            set;
        }
        public string VersionCode
        {
            get;
            set;
        }
        public int OldRecipeId
        {
            get;
            set;
        }
        //Feilds From InventoryVariationMaster
        public Int16 InventoryVariationMasterID
        {
            get;
            set;

        }
        public string RecipeVariationTitle
        {
            get;
            set;
        }
        //feilds from InventoryRecipeFormulaDetails

        public int InventoryRecipeFormulaDetailsID
        {
            get;
            set;
        }
        public decimal Cost
        {
            get;
            set;
        }
        public byte OrderNumber
        {
            get;
            set;
        }
        //feilds from InventoryRecipeMenuMaster
        public Int16 InventoryRecipeMenuMaster
        {
            get;
            set;
        }
        public string MenuDescription
        {
            get;
            set;
        }
        public string DefineVariants 
        {
            get;
            set;
        }
        public string BOMRelevant
        {
            get;
            set;
        }
        public string BillingItemName
        {
            get;
            set;
        }
        ///////////////////////
        public string UnitName
        {
            get;
            set;
        }

     
        public byte[] MenuPhoto
        {
            get;
            set;
        }

        public string MenuPhotoType
        {
            get;
            set;
        }
        public string MenuPhotoFilename
        {
            get;

            set;

        }

        public string MenuPhotoFileWidth
        {
            get;

            set;
        }


        public string MenuPhotoFileHeight
        {
            get;
            set;
        }


        public string MenuPhotoFileSize
        {
            get;
            set;
        }
        public string ActionOn
        {
            get;
            set;
        }
        public string ActionName
        {
            get;
            set;
        }
        public int ActionID
        {
            get;
            set;
        }
        public bool IsExists
        {
            get;
            set;
        }

        public string CroppedImagePath
        {
            get;
            set;
        }
        public string EComCroppedImagePath
        {
            get;
            set;
        }
        public string MyFile
        {
            get;
            set;
        }
        public decimal PriceForVariation
        {
            get;
            set;
        }
        public string XMLstringForRestuarent
        {
            get;
            set;
        }
        public decimal ConvertionFactor
        {
            get;
            set;
        }
        public int InventoryItemCodeUnitLevelSpecificInfoID
        {
            get;
            set;
        }
        public decimal PriceForRecipe
        {
            get;
            set;
        }
        //Dimension data
        public decimal Length
        {
            get;
            set;
        }
        public decimal WidthOfItem
        {
            get;
            set;
        }
        public decimal HeightOfItem
        {
            get;
            set;
        }
        public decimal Volume
        {
            get;
            set;
        }
        public string PurchaseGroupCode
        {
            get;
            set;
        }

        public byte OrderingUnitcheckboxFlag
        {
            get;
            set;
        }

        public string RemainingShelfLife
        {
            get;
            set;
        }
        public string VendorProductCode
        {
            get;
            set;
        }
        public string ManufacturerName  
        {
            get;
            set;
        }
        public int VendorNumber
        {
            get;
            set;
        }
        public string CountryList
        {
            get;
            set;
        }
        public string TemperatureList
        {
            get;
            set;
        }
        public string CurrencyList
        {
            get;
            set;
        }
        public string UnitList
        {
            get;
            set;
        }
        public string TaxGroupList
        {
            get;
            set;
        }
        public string PurchaseGrouplist
        {
            get;
            set;
        }
        
        public string VendorNumberList
        {
            get;
            set;
        }
        public string CategoryCodeList
        {
            get;
            set;
        }
        public string UomDetailsParameterXML1
        {
            get;
            set;
        }
        public string UomDetailsParameterXML2
        {
            get;
            set;
        }
        public string UomDetailsParameterXML3
        {
            get;
            set;
        }
        public string UomDetailsParameterXML4
        {
            get;
            set;
        }
        public int Facing
        {
            get;
            set;
        }
        public string ShelfNumber
        {
            get;
            set;
        }
        public byte IsRelatedWithCafe
        {
            get;
            set;
        }
        public string XMLstringForAttribute
        {
            get;
            set;
        }
        public int GeneralItemAttributeDataID
        {
            get;
            set;
        }
        public string RecipeVariationDescription
        {
            get;
            set;
        }
        public bool IsMultipleVendor
        {
            get;
            set;
        }
        public bool IsDefaultVendor
        {
            get;
            set;
        }

        public string DisplayName
        {
            get;
            set;
        }
        public string ImageNameString
        {
            get;
            set;
        }
        public string ItemCategoryDescription
        {
            get;
            set;
        }
        public string GroupDescription
        {
            get;
            set;
        }
        public string MerchantiseDepartmentName
        {
            get;
            set;
        }
        public string MerchantiseCategoryName
        {
            get;
            set;
        }
        public string MerchantiseSubCategoryName
        {
            get;
            set;
        }
        public string MarchandiseBaseCatgoryName
        {
            get;
            set;
        }
        public bool IsEComItem
        {
            get;
            set;
        }
        public string EComDisplayName
        {
            get;
            set;
        }
        public string SelectedCentreCode
        {
            get;
            set;
        }
        public string SelectedCentreCodeForSaleTab
        {
            get;
            set;
        }
        public string XMLstringForMultipleImageUpload
        {
            get;
            set;
        }
        public string CentreListXML { get; set; }
        public string CentreName
        {
            get;
            set;
        }
        public bool IsServiceItem
        {
            get;
            set;
        }
        public string HSNCode
        {
            get;
            set;
        }
        public string TaxGroupName
        {
            get;
            set;
        }
        public string TaxRateList
        {
            get;
            set;
        }
        public string TaxList
        {
            get;
            set;
        }
        public string ItemCode
        {
            get;
            set;
        }
        public bool IsConsumable
        {
            get;
            set;
        }
        public bool IsMachine
        {
            get;
            set;
        }
        public bool IsToner
        {
            get;
            set;
        }
        public string VersionNumber
        {
            get;
            set;
        }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }
        public string LastCallDate { get; set; }
        public Int32 LastCallNo { get; set; }
        public Int32 LastQuantity { get; set; }
        public Int32 LastMtrRead { get; set; }
        public string ModelNo { get; set; }
        public string lifeInCopies { get; set; }
    }
}
