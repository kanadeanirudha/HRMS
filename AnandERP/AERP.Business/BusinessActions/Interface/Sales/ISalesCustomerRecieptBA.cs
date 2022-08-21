using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ISalesCustomerRecieptBA
    {
        IBaseEntityResponse<SalesCustomerReciept> InsertSalesCustomerReciept(SalesCustomerReciept item);
        IBaseEntityResponse<SalesCustomerReciept> UpdateSalesCustomerReciept(SalesCustomerReciept item);
        IBaseEntityResponse<SalesCustomerReciept> DeleteSalesCustomerReciept(SalesCustomerReciept item);
        IBaseEntityCollectionResponse<SalesCustomerReciept> GetBySearch(SalesCustomerRecieptSearchRequest searchRequest);
        IBaseEntityResponse<SalesCustomerReciept> SelectByID(SalesCustomerReciept item);
        IBaseEntityCollectionResponse<SalesCustomerReciept> GetCustomerWiseInvoiceDetailsForCustomerRecieptList(SalesCustomerRecieptSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SalesCustomerReciept> GetRecordForPurchaseOrderPDF(SalesCustomerRecieptSearchRequest searchRequest);

    }
}
