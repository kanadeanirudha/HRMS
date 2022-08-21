using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesOrderDeliveryMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> InsertSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item);
        IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> InsertSalesOrderDeliveryMasterAndDetailsForDirectDM(SalesOrderDeliveryMasterAndDetails item);
        IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> UpdateSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item);
        IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> DeleteSalesOrderDeliveryMasterAndDetails(SalesOrderDeliveryMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsBySearch(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsSearchList(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesOrderDeliveryMasterAndDetails> GetSalesOrderDeliveryMasterAndDetailsByID(SalesOrderDeliveryMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoListBySalesOrder(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoDetailsByID(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetRecordForSaleseOrderDeliveryMemoPDF(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderDeliveryMasterAndDetails> GetDeliveryMemoNumberSearchList_ForSaleContract(SalesOrderDeliveryMasterAndDetailsSearchRequest searchRequest);

    }
}
