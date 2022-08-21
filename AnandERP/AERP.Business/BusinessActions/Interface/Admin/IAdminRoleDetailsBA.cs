using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAdminRoleDetailsBA
    {
        IBaseEntityResponse<AdminRoleDetails> InsertAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> UpdateAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> DeleteAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityCollectionResponse<AdminRoleDetails> GetBySearch(AdminRoleDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleDetails> SelectByID(AdminRoleDetails item);
    }
}
