using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IPurchaseInvoiceDataProvider
    {
        IBaseEntityResponse<PurchaseInvoice> InsertPurchaseInvoice(PurchaseInvoice item);
        IBaseEntityResponse<PurchaseInvoice> UpdatePurchaseInvoice(PurchaseInvoice item);
        IBaseEntityResponse<PurchaseInvoice> DeletePurchaseInvoice(PurchaseInvoice item);
        IBaseEntityCollectionResponse<PurchaseInvoice> GetPurchaseInvoiceBySearch(PurchaseInvoiceSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseInvoice> GetPurchaseInvoiceByID(PurchaseInvoice item);
        IBaseEntityCollectionResponse<PurchaseInvoice> GetPurchaseInvoiceByPurchaseGRNMasterID(PurchaseInvoiceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseInvoice> GetRecordForPurchaseOrderPDF(PurchaseInvoiceSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseInvoice> InsertManualPurchaseInvoice(PurchaseInvoice item);

    }
}
