using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IUserMainMenuMasterDataProvider
    {
        IBaseEntityResponse<UserMainMenuMaster> InsertUserMainMenuMaster(UserMainMenuMaster item);
        IBaseEntityResponse<UserMainMenuMaster> UpdateUserMainMenuMaster(UserMainMenuMaster item);
        IBaseEntityResponse<UserMainMenuMaster> DeleteUserMainMenuMaster(UserMainMenuMaster item);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetUserMainMenuMasterBySearch(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityResponse<UserMainMenuMaster> GetUserMainMenuMasterByID(UserMainMenuMaster item);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetParentMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetMenuByModuleCode(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetCentrewiseMenuListForStudent(UserMainMenuMasterSearchRequest searchRequest);
        
    }
}
