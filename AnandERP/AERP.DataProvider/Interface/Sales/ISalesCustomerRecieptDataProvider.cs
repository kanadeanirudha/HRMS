using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISalesCustomerRecieptDataProvider
    {
        IBaseEntityResponse<SalesCustomerReciept> InsertSalesCustomerReciept(SalesCustomerReciept item);
        IBaseEntityResponse<SalesCustomerReciept> UpdateSalesCustomerReciept(SalesCustomerReciept item);
        IBaseEntityResponse<SalesCustomerReciept> DeleteSalesCustomerReciept(SalesCustomerReciept item);
        IBaseEntityCollectionResponse<SalesCustomerReciept> GetSalesCustomerRecieptBySearch(SalesCustomerRecieptSearchRequest searchRequest);
        IBaseEntityResponse<SalesCustomerReciept> GetSalesCustomerRecieptByID(SalesCustomerReciept item);
        IBaseEntityCollectionResponse<SalesCustomerReciept> GetCustomerWiseInvoiceDetailsForCustomerRecieptList(SalesCustomerRecieptSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesCustomerReciept> GetRecordForPurchaseOrderPDF(SalesCustomerRecieptSearchRequest searchRequest);

    }
}
