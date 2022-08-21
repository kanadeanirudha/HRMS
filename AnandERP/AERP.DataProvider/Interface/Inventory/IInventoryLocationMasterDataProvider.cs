using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IInventoryLocationMasterDataProvider
    {
        IBaseEntityResponse<InventoryLocationMaster> InsertInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> UpdateInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityResponse<InventoryLocationMaster> DeleteInventoryLocationMaster(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterBySearch(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterList(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster> GetInventoryLocationMasterByID(InventoryLocationMaster item);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterSearchList(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterlistCenterCodeWise(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryLocationMasterlistByAdminRole(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<InventoryLocationMaster> GetInventoryStorageLocationByCentreCodeAndUnitsID(InventoryLocationMasterSearchRequest searchRequest);
        IBaseEntityResponse<InventoryLocationMaster> GetUnitsNameByLocationID(InventoryLocationMaster item);
    }
}
