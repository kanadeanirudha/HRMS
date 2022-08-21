using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IGeneralGroupMasterDataProvider
    {
        IBaseEntityResponse<GeneralGroupMaster> InsertGeneralGroupMaster(GeneralGroupMaster item);
        IBaseEntityResponse<GeneralGroupMaster> UpdateGeneralGroupMaster(GeneralGroupMaster item);
        IBaseEntityResponse<GeneralGroupMaster> DeleteGeneralGroupMaster(GeneralGroupMaster item);
        IBaseEntityCollectionResponse<GeneralGroupMaster> GetGeneralGroupMasterBySearch(GeneralGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralGroupMaster> GetGeneralGroupMasterByID(GeneralGroupMaster item);
        IBaseEntityResponse<GeneralGroupMaster> InsertGroupDetails(GeneralGroupMaster item);
        IBaseEntityCollectionResponse<GeneralGroupMaster> GetEmployeeGroupDetailsBySearch(GeneralGroupMasterSearchRequest searchRequest);
        IBaseEntityResponse<GeneralGroupMaster> GetEmployeeGroupDetailsByID(GeneralGroupMaster item);
        IBaseEntityResponse<GeneralGroupMaster> UpdateGroupDetails(GeneralGroupMaster item);
    }
}
