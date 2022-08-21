using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IInventoryUoMMasterBA
    {
        IBaseEntityResponse<InventoryUoMMaster> InsertInventoryUoMMaster(InventoryUoMMaster item);
        IBaseEntityResponse<InventoryUoMMaster> UpdateInventoryUoMMaster(InventoryUoMMaster item);
        IBaseEntityResponse<InventoryUoMMaster> DeleteInventoryUoMMaster(InventoryUoMMaster item);
        IBaseEntityCollectionResponse<InventoryUoMMaster> GetBySearch(InventoryUoMMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterSearchList(InventoryUoMMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryUoMMaster> SelectByID(InventoryUoMMaster item);
        IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforUomCode(InventoryUoMMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforSaleUomCode(InventoryUoMMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryUoMMaster> GetInventoryUoMMasterDropDownforPurchaseUomCode(InventoryUoMMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryUoMMaster> GetBySearchList(InventoryUoMMasterSearchRequest searchRequest);
    }
}

