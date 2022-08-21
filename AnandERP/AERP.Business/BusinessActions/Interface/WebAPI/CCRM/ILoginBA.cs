using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ILoginBA
    {
        IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item);
        IBaseEntityResponse<UserMaster> ChangePassword(UserMaster item);

        IBaseEntityResponse<UserMaster> IsValidate(UserMaster item);
        IBaseEntityCollectionResponse<UserMaster> EngineerList(UserMaster item);

        IBaseEntityResponse<UserMaster> SelectByEmailIDPassword(UserMaster item);

    }
}
