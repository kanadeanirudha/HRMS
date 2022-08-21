using System;
using AERP.Base.DTO;
using AERP.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralPurchaseGroupMasterBA
    {
        IBaseEntityResponse<GeneralPurchaseGroupMaster> InsertGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> UpdateGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> DeleteGeneralPurchaseGroupMaster(GeneralPurchaseGroupMaster item);
        IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetBySearch(GeneralPurchaseGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralPurchaseGroupMaster> SelectByID(GeneralPurchaseGroupMaster item);
        IBaseEntityCollectionResponse<GeneralPurchaseGroupMaster> GetGeneralPurchaseGroupMasterSearchList(GeneralPurchaseGroupMasterSearchRequest searchRequest);

    }
}
