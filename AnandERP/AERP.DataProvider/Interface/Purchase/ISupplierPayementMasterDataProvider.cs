using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISupplierPayementMasterDataProvider
    {
        IBaseEntityResponse<SupplierPayementMaster> InsertSupplierPayementMaster(SupplierPayementMaster item);
        IBaseEntityResponse<SupplierPayementMaster> UpdateSupplierPayementMaster(SupplierPayementMaster item);
        IBaseEntityResponse<SupplierPayementMaster> DeleteSupplierPayementMaster(SupplierPayementMaster item);
        IBaseEntityCollectionResponse<SupplierPayementMaster> GetSupplierPayementMasterBySearch(SupplierPayementMasterSearchRequest searchRequest);
        IBaseEntityResponse<SupplierPayementMaster> GetSupplierPayementMasterByID(SupplierPayementMaster item);
        IBaseEntityCollectionResponse<SupplierPayementMaster> GetVendorWiseInvoiceDetailsForPayement(SupplierPayementMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SupplierPayementMaster> GetRecordForPurchaseOrderPDF(SupplierPayementMasterSearchRequest searchRequest);

    }
}
