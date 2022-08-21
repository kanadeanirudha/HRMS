using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IUserMasterDataProvider
    {
        IBaseEntityCollectionResponse<UserMaster> GetUserMasterBySearch(UserMasterSearchRequest searchRequest);

        IBaseEntityResponse<UserMaster> GetUserMasterByID(UserMaster item);

        IBaseEntityResponse<UserMaster> SelectByEmailID(UserMaster item);

        IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item);

        IBaseEntityResponse<UserMaster> UserLogoutApi(UserMaster item);     

        IBaseEntityResponse<UserMaster> GetUserMasterByEmailIDPassword(UserMaster item);

        IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item);

        IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item);

        IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetRolesBySearch(UserMasterSearchRequest searchRequest);
        
        IBaseEntityCollectionResponse<UserMaster> GetUserType(UserMasterSearchRequest searchRequest);


        IBaseEntityResponse<UserMaster> LogOffByUserID(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetActiveUserBySearch(UserMasterSearchRequest searchRequest);
        IBaseEntityResponse<UserMaster> UserLoginReset(UserMaster item);
    }
}
