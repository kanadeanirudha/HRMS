using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessActions
{
    public interface IInventoryConsumptionDetailDrillReportBA
    {

        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        //IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchantiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
       // IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventoryConsumptionDetailDrillReportBySearch_DescriptionWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetGeneralUnitsDropdownForProccesingUnit(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        //-------------------------------------Sale and Wastage----------------------------------------------
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_GroupDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseDepartmentNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseSubCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_MerchandiseBaseCategoryNameWise(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryConsumptionDetailDrillReport> GetInventorySaleandWastageReportBySearch_ItemDescription(InventoryConsumptionDetailDrillReportSearchRequest searchRequest);
    }
} 
