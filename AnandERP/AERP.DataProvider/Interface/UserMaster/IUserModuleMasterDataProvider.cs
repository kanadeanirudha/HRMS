using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IUserModuleMasterDataProvider
    {
        IBaseEntityResponse<UserModuleMaster> InsertUserModuleMaster(UserModuleMaster item);
        IBaseEntityResponse<UserModuleMaster> UpdateUserModuleMaster(UserModuleMaster item);
        IBaseEntityResponse<UserModuleMaster> DeleteUserModuleMaster(UserModuleMaster item);
        IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleMasterBySearch(UserModuleMasterSearchRequest searchRequest);
        IBaseEntityResponse<UserModuleMaster> GetUserModuleMasterByID(UserModuleMaster item);
        IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForLoginUserIDByRoleID(UserModuleMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForAdmin(UserModuleMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleList(UserModuleMasterSearchRequest searchRequest);

    }
}
