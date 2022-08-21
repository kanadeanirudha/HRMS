using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralPurchaseGroupMasterDataProvider
    {
        IBaseEntityResponse<GeneralPurchaseGroupMaster> InsertGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> UpdateGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> DeleteGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterBySearch(GeneralPurchaseGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterByID(GeneralPurchaseGroupMaster item);
        IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterSearchList(GeneralPurchaseGroupMasterSearchRequest searchRequest);
    }
}
