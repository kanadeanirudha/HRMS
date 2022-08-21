using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISalesOrderMasterAndDetailsBA
    {
        IBaseEntityResponse<SalesOrderMasterAndDetails> InsertSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item);
        IBaseEntityResponse<SalesOrderMasterAndDetails> UpdateSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item);
        IBaseEntityResponse<SalesOrderMasterAndDetails> DeleteSalesOrderMasterAndDetails(SalesOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetBySearch(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetSalesOrderMasterAndDetailsSearchList(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetDropDownListForSalesOrderMasterAndDetails(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> GetRecordForSaleseOrderPDF(SalesOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesOrderMasterAndDetails> SelectByID(SalesOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesOrderMasterAndDetails> ViewSalesOrderMasterDetailsListBySalesOrderMasterID(SalesOrderMasterAndDetailsSearchRequest searchRequest);
    }
}

