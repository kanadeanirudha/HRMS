using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IPurchaseReturnBA
    {
        IBaseEntityResponse<PurchaseReturn> InsertPurchaseReturn(PurchaseReturn item);
        IBaseEntityResponse<PurchaseReturn> UpdatePurchaseReturn(PurchaseReturn item);
        IBaseEntityResponse<PurchaseReturn> DeletePurchaseReturn(PurchaseReturn item);
        IBaseEntityCollectionResponse<PurchaseReturn> GetBySearch(PurchaseReturnSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReturn> GetVendorSearchList(PurchaseReturnSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseReturn> GetPurchaseReturnDetailLists(PurchaseReturnSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseReturn> SelectByID(PurchaseReturn item);
        IBaseEntityCollectionResponse<PurchaseReturn> GetUomWisePurchasePrice(PurchaseReturnSearchRequest searchRequest);

    }
}

