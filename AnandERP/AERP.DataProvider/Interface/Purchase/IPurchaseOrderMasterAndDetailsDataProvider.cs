using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IPurchaseOrderMasterAndDetailsDataProvider
    {
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertPurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> UpdatePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> DeletePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderMasterAndDetailsBySearch(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderMasterAndDetailsByID(PurchaseOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderMasterAndDetailsByPurchaseRequisitionMasterID(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetRecordForPurchaseOrderPDF(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertApprovedPurchaseOrderRecord(PurchaseOrderMasterAndDetails item);
        IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderForApproval(PurchaseOrderMasterAndDetailsSearchRequest searchRequest);
    }
}
