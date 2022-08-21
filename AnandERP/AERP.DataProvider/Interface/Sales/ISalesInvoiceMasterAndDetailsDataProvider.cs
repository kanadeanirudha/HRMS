using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesInvoiceMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertDirectSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> UpdateSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> DeleteSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceMasterAndDetailsBySearch(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetServiceInvoiceMasterAndDetailsBySearch(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceMasterAndDetailsByID(SalesInvoiceMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SelectBySalesOrderMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> ViewDetailsBySalesInvoiceMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest); IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForSalesinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForServiceinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> CancelSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceNumberSearchList(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
    }
}
