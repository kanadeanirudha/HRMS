using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IPurchaseReplenishmentBA
    {
        IBaseEntityResponse<PurchaseReplenishment> InsertPurchaseReplenishment(PurchaseReplenishment item);
        IBaseEntityResponse<PurchaseReplenishment> UpdatePurchaseReplenishment(PurchaseReplenishment item);
        IBaseEntityResponse<PurchaseReplenishment> DeletePurchaseReplenishment(PurchaseReplenishment item);
        IBaseEntityCollectionResponse<PurchaseReplenishment> GetBySearch(PurchaseReplenishmentSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseReplenishment> SelectByID(PurchaseReplenishment item);
        IBaseEntityCollectionResponse<PurchaseReplenishment> SelectByPurchaseGRNMasterID(PurchaseReplenishmentSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReplenishment> GetRecordForPurchaseOrderPDF(PurchaseReplenishmentSearchRequest searchRequest);

    }
}
