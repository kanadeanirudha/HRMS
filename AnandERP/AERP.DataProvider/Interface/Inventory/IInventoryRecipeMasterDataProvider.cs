using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryRecipeMasterDataProvider
    {
        IBaseEntityResponse<InventoryRecipeMaster> InsertInventoryRecipeMaster(InventoryRecipeMaster item);
        IBaseEntityResponse<InventoryRecipeMaster> UpdateInventoryRecipeMaster(InventoryRecipeMaster item);
        IBaseEntityResponse<InventoryRecipeMaster> DeleteInventoryRecipeMaster(InventoryRecipeMaster item);
        IBaseEntityCollectionResponse<InventoryRecipeMaster> GetInventoryRecipeMasterBySearch(InventoryRecipeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryRecipeMaster> GetInventoryRecipeMasterSearchList(InventoryRecipeMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryRecipeMaster> GetInventoryRecipeMasterByID(InventoryRecipeMaster item);
    }
}
