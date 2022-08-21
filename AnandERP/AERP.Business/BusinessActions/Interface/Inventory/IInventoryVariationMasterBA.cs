
using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryVariationMasterBA
    {
        IBaseEntityResponse<InventoryVariationMaster> InsertInventoryVariationMaster(InventoryVariationMaster item);
        IBaseEntityResponse<InventoryVariationMaster> UpdateInventoryVariationMaster(InventoryVariationMaster item);
        IBaseEntityResponse<InventoryVariationMaster> DeleteInventoryVariationMaster(InventoryVariationMaster item);
        IBaseEntityCollectionResponse<InventoryVariationMaster> GetBySearch(InventoryVariationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryVariationMaster> GetInventoryVariationMasterSearchList(InventoryVariationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryVariationMaster> SelectByID(InventoryVariationMaster item);
    }
}

