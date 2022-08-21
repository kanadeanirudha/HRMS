using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ISupplierPayementMasterBA
    {
        IBaseEntityResponse<SupplierPayementMaster> InsertSupplierPayementMaster(SupplierPayementMaster item);
        IBaseEntityResponse<SupplierPayementMaster> UpdateSupplierPayementMaster(SupplierPayementMaster item);
        IBaseEntityResponse<SupplierPayementMaster> DeleteSupplierPayementMaster(SupplierPayementMaster item);
        IBaseEntityCollectionResponse<SupplierPayementMaster> GetBySearch(SupplierPayementMasterSearchRequest searchRequest);
        IBaseEntityResponse<SupplierPayementMaster> SelectByID(SupplierPayementMaster item);
        IBaseEntityCollectionResponse<SupplierPayementMaster> GetVendorWiseInvoiceDetailsForPayement(SupplierPayementMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SupplierPayementMaster> GetRecordForPurchaseOrderPDF(SupplierPayementMasterSearchRequest searchRequest);

    }
}
