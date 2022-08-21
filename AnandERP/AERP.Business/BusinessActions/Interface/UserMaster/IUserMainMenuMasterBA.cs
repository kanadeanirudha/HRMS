using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IUserMainMenuMasterBA
    {
        IBaseEntityResponse<UserMainMenuMaster> InsertUserMainMenuMaster(UserMainMenuMaster item);
        IBaseEntityResponse<UserMainMenuMaster> UpdateUserMainMenuMaster(UserMainMenuMaster item);
        IBaseEntityResponse<UserMainMenuMaster> DeleteUserMainMenuMaster(UserMainMenuMaster item);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetBySearch(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityResponse<UserMainMenuMaster> SelectByID(UserMainMenuMaster item);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetByModuleID(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetByModuleCode(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetParentMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserMainMenuMaster> GetCentrewiseMenuListForStudent(UserMainMenuMasterSearchRequest searchRequest); 
    }
}
