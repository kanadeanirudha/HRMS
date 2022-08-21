using System;
using System.Collections.Generic;
using AERP.Base.DTO;
using AERP.DTO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IInventoryLocationMasterBA
    {
        IBaseEntityResponse<InventoryLocationMaster> InsertInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> UpdateInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> DeleteInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetBySearch(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterList(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster> SelectByID(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterSearchList(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryStorageLocationByCentreCodeAndUnitsID(InventoryLocationMasterSearchRequest searchRequest);

        IBaseEntityResponse<InventoryLocationMaster> GetUnitsNameByLocationID(InventoryLocationMaster item);
    }
}
