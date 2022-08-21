using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IInventoryDimensionUnitMasterDataProvider
    {
        IBaseEntityResponse<InventoryDimensionUnitMaster> InsertInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityResponse<InventoryDimensionUnitMaster> UpdateInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityResponse<InventoryDimensionUnitMaster> DeleteInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterBySearch(InventoryDimensionUnitMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterSearchList(InventoryDimensionUnitMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterByID(InventoryDimensionUnitMaster item);
    }
}
