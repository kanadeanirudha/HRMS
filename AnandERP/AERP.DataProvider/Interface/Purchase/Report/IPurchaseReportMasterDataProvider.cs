using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IPurchaseReportMasterDataProvider
    {
        // PurchaseReportMaster Method
        IBaseEntityResponse<PurchaseReportMaster> InsertPurchaseReportMaster(PurchaseReportMaster item);
        IBaseEntityResponse<PurchaseReportMaster> UpdatePurchaseReportMaster(PurchaseReportMaster item);
        IBaseEntityResponse<PurchaseReportMaster> DeletePurchaseReportMaster(PurchaseReportMaster item);        
        IBaseEntityResponse<PurchaseReportMaster> GetPurchaseReportMasterByID(PurchaseReportMaster item);

        //Search PurchaseReportMaster List
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetPurchaseReportMasterSearchList(PurchaseReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<PurchaseReportMaster> GetArticalMovementReport(PurchaseReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<PurchaseReportMaster> GetLocationWiseCurrentStockReport(PurchaseReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<PurchaseReportMaster> GetStockConsumptionReport(PurchaseReportMasterSearchRequest searchRequest);

        //For DailyItemRateChange Report
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetDailyItemRateChangeReportBySearch(PurchaseReportMasterSearchRequest searchRequest);

        //For Below Indend Level Report.
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetBelowIndendLevelReportBySearch(PurchaseReportMasterSearchRequest searchRequest);

        //For Item Order Status Report
        //For Below Indend Level Report.
        IBaseEntityCollectionResponse<PurchaseReportMaster> GetItemOrderStatusList(PurchaseReportMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<PurchaseReportMaster> GetInventoryPurchaseStockReport(PurchaseReportMasterSearchRequest searchRequest);
    }
}
