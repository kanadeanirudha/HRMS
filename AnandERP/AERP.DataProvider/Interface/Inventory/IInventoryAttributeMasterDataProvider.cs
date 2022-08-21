using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IInventoryAttributeMasterDataProvider
    {
        IBaseEntityResponse<InventoryAttributeMaster> InsertInventoryAttributeMaster(InventoryAttributeMaster item);
        IBaseEntityResponse<InventoryAttributeMaster> UpdateInventoryAttributeMaster(InventoryAttributeMaster item);
        IBaseEntityResponse<InventoryAttributeMaster> DeleteInventoryAttributeMaster(InventoryAttributeMaster item);
        IBaseEntityCollectionResponse<InventoryAttributeMaster> GetInventoryAttributeMasterBySearch(InventoryAttributeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryAttributeMaster> GetInventoryAttributeMasterSearchList(InventoryAttributeMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryAttributeMaster> GetInventoryAttributeMasterByID(InventoryAttributeMaster item);
    }
}
