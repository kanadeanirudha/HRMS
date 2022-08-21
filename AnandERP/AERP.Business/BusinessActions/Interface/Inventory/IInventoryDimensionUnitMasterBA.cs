using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IInventoryDimensionUnitMasterBA
    {
        IBaseEntityResponse<InventoryDimensionUnitMaster> InsertInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityResponse<InventoryDimensionUnitMaster> UpdateInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityResponse<InventoryDimensionUnitMaster> DeleteInventoryDimensionUnitMaster(InventoryDimensionUnitMaster item);
        IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetBySearch(InventoryDimensionUnitMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryDimensionUnitMaster> GetInventoryDimensionUnitMasterSearchList(InventoryDimensionUnitMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryDimensionUnitMaster> SelectByID(InventoryDimensionUnitMaster item);
    }
}

