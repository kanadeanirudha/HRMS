using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IPurchaseReplenishmentDataProvider
    {
        IBaseEntityResponse<PurchaseReplenishment> InsertPurchaseReplenishment(PurchaseReplenishment item);
        IBaseEntityResponse<PurchaseReplenishment> UpdatePurchaseReplenishment(PurchaseReplenishment item);
        IBaseEntityResponse<PurchaseReplenishment> DeletePurchaseReplenishment(PurchaseReplenishment item);
        IBaseEntityCollectionResponse<PurchaseReplenishment> GetPurchaseReplenishmentBySearch(PurchaseReplenishmentSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseReplenishment> GetPurchaseReplenishmentByID(PurchaseReplenishment item);
        IBaseEntityCollectionResponse<PurchaseReplenishment> GetPurchaseReplenishmentByPurchaseGRNMasterID(PurchaseReplenishmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReplenishment> GetRecordForPurchaseOrderPDF(PurchaseReplenishmentSearchRequest searchRequest);

    }
}
