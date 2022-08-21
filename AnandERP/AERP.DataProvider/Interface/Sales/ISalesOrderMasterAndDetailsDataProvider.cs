using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesOrderMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalesOrderMasterAndDetails> InsertSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item);
        IBaseEntityResponse<SalesOrderMasterAndDetails> UpdateSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item);
        IBaseEntityResponse<SalesOrderMasterAndDetails> DeleteSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsBySearch(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsSearchList(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetDropDownListForSalesOrderMasterAndDetails(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsByID(SalesOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetRecordForSaleseOrderPDF(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> ViewSalesOrderMasterDetailsListBySalesOrderMasterID(SalesOrderMasterAndDetailsSearchRequest searchRequest);


    }
}
