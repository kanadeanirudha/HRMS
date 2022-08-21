using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IUserDetailBA
    {
        IBaseEntityResponse<UserDetail> InsertUserDetail(UserDetail item);

        IBaseEntityResponse<UserDetail> UpdateUserDetail(UserDetail item);

        IBaseEntityResponse<UserDetail> DeleteUserDetail(UserDetail item);

        IBaseEntityCollectionResponse<UserDetail> GetBySearch(UserDetailSearchRequest searchRequest);
        
    }
}
