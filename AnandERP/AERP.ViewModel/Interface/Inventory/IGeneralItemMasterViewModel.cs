using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IGeneralItemMasterViewModel
    {
        GeneralItemMaster GeneralItemMasterDTO
        {
            get;
            set;
        }

         int GeneralItemMasterID
        {
            get;
            set;
        }
         int ItemNumber
        {
            get;
            set;
        }
         string ItemDescription
        {
            get;
            set;
        }
         string ItemCategoryCode
        {
            get;
            set;
        }
         string BaseUoMcode
        {
            get;
            set;
        }
         double LastPurchasePrice
        {
            get;
            set;
        }
         string CurrencyCode
        {
            get;
            set;
        }
         string BaseBarCode
        {
            get;
            set;
        }
         Int16 BasePriceListID
        {
            get;
            set;
        }
         int InventoryPurchaseGroupMasterId
        {
            get;
            set;
        }
         bool IsInventoryItem
        {
            get;
            set;
        }
         bool IsSalesItem
        {
            get;
            set;
        }
         bool IsPurchaseItem
        {
            get;
            set;
        }
         bool IsFixedAssetItem
        {
            get;
            set;
        }
         string UoMGroupCode
        {
            get;
            set;
        }
         byte ItemType
        {
            get;
            set;
        }
        //GeneralItemCode
         int GeneralItemCodeID
        {
            get;
            set;
        }
         string BarCode
        {
            get;
            set;
        }
         bool IsDefault
        {
            get;
            set;
        }
         bool IsBaseUom
        {
            get;
            set;
        }
         string BaseUomCode
        {
            get;
            set;
        }
         string UomCode
        {
            get;
            set;
        }
        //GeneralItemSupliersData
         int GeneralItemSupliersDataID
        {
            get;
            set;
        }
         int GeneralVendorID
        {
            get;
            set;
        }
         string ManufacturCatalogNumber
        {
            get;
            set;
        }
         string PurchaseUoMCode
        {
            get;
            set;
        }
         byte GeneralPurchaseGroupMasterID
        {
            get;
            set;
        }
         Int16 GenTaxGroupMasterID
        {
            get;
            set;
        }
         string PackageType
        {
            get;
            set;
        }
        //methods of GeneralItemGeneralData
         int GeneralItemGeneralDataID
        {
            get;
            set;
        }
         byte ShippingTypeId
        {
            get;
            set;
        }
         Int16 ManufacturerID
        {
            get;
            set;
        }
         byte SerialAndBatchManagedBy
        {
            get;
            set;
        }
         byte ManagementMethod
        {
            get;
            set;
        }
         byte IssueMethod
        {
            get;
            set;
        }
        //GeneralItemSalesData
         int GeneralItemSalesDataID
        {
            get;
            set;
        }
         string SaleUoMCode
        {
            get;
            set;
        }
         byte ItemPerSaleUnit
        {
            get;
            set;
        }
         string PackingUnitSale
        {
            get;
            set;
        }
         byte QuantityPerPackingUnitSale
        {
            get;
            set;
        }
        //GeneralItemStockData
         int GeneralItemStockDataID
        {
            get;
            set;
        }
         byte GLAccountBy
        {
            get;
            set;
        }

         string StockUoMCode
        {
            get;
            set;
        }
         byte ValuationMethod
        {
            get;
            set;
        }
         string UoMCode
        {
            get;
            set;
        }
         Int16 MinStock
        {
            get;
            set;
        }
         decimal MaxStock
        {
            get;
            set;
        }

         //store specific information fields

         string CentreCode
         {
             get;
             set;
         }
          Byte RPType
         {
             get;
             set;
         }
          Byte OrderingDay
         {
             get;
             set;
         }
          Byte DeliveryDay
         {
             get;
             set;
         }
          double Quantity
         {
             get;
             set;
         }
          double RoundingProfile
         {
             get;
             set;
         }
         // double LeadTime
         //{
         //    get;
         //    set;
         //}
          double GRProccessingTime
         {
             get;
             set;
         }
          string PlannerCode
         {
             get;
             set;
         }
          string leadTimeUom
         {
             get;
             set;
         }
          string SupplySource
         {
             get;
             set;
         }
          bool BlockforProcurutment
         {
             get;
             set;
         }
          string GRPUomCode
         {
             get;
             set;
         }
        //Common Properties
         bool IsDeleted
        {
            get;
            set;
        }
         int CreatedBy
        {
            get;
            set;
        }
         DateTime CreatedDate
        {
            get;
            set;
        }
         int ModifiedBy
        {
            get;
            set;
        }
         DateTime ModifiedDate
        {
            get;
            set;
        }
         int DeletedBy
        {
            get;
            set;
        }
         DateTime DeletedDate
        {
            get;
            set;
        }
         string ShelfLife { get; set; }
         string errorMessage { get; set; }
         string ListingDate { get; set; }
         string DeListingDate { get; set; }
         int InventoryItemCodeCentreLevelSpecificInfoID
         {
             get;
             set;
         }
         int InventoryItemStoreSpecificInfoID
         {
             get;
             set;
         }
          string GeneralItemStoreSpecificDetailsXml
         {
             get;
             set;
         }
    }
}
