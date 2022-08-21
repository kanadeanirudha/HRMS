using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ISalesInvoiceMasterAndDetailsBA
    {
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> UpdateSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> DeleteSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetBySearch(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetBySearchForServiceItem(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> SelectByID(SalesInvoiceMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> SelectBySalesOrderMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> ViewDetailsBySalesInvoiceMasterID(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForSalesinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetRecordForServiceinvoiceOrderPDF(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> InsertDirectSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityResponse<SalesInvoiceMasterAndDetails> CancelSalesInvoiceMasterAndDetails(SalesInvoiceMasterAndDetails item);
        IBaseEntityCollectionResponse<SalesInvoiceMasterAndDetails> GetSalesInvoiceNumberSearchList(SalesInvoiceMasterAndDetailsSearchRequest searchRequest);
    }
}
