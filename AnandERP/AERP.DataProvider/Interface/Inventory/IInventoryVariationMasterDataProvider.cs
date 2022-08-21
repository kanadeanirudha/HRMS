using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryVariationMasterDataProvider
    {
        IBaseEntityResponse<InventoryVariationMaster> InsertInventoryVariationMaster(InventoryVariationMaster item);
        IBaseEntityResponse<InventoryVariationMaster> UpdateInventoryVariationMaster(InventoryVariationMaster item);
        IBaseEntityResponse<InventoryVariationMaster> DeleteInventoryVariationMaster(InventoryVariationMaster item);
        IBaseEntityCollectionResponse<InventoryVariationMaster> GetInventoryVariationMasterBySearch(InventoryVariationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryVariationMaster> GetInventoryVariationMasterSearchList(InventoryVariationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryVariationMaster> GetInventoryVariationMasterByID(InventoryVariationMaster item);
    }
}
