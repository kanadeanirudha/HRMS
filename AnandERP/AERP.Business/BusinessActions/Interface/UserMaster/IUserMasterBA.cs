using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IUserMasterBA
    {
        IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item);

        IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item);

        IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetBySearch(UserMasterSearchRequest searchRequest);

        IBaseEntityResponse<UserMaster> SelectByID(UserMaster item);

        IBaseEntityResponse<UserMaster> SelectByEmailID(UserMaster item);

        IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item);

        IBaseEntityResponse<UserMaster> UserLogoutApi(UserMaster item);

        IBaseEntityResponse<UserMaster> SelectByEmailIDPassword(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetRoleByID(UserMasterSearchRequest searchRequest);
       
        IBaseEntityCollectionResponse<UserMaster> GetUserType(UserMasterSearchRequest searchRequest);


        IBaseEntityResponse<UserMaster> LogOffByUserID(UserMaster item);

        IBaseEntityCollectionResponse<UserMaster> GetActiveUserBySearch(UserMasterSearchRequest searchRequest);
        IBaseEntityResponse<UserMaster> UserLoginReset(UserMaster item);
    }
}
