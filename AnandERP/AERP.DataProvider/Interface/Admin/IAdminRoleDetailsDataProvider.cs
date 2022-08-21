using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAdminRoleDetailsDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleDetails> GetAdminRoleDetailsBySearch(AdminRoleDetailsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleDetails> GetAdminRoleDetailsByID(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> InsertAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> UpdateAdminRoleDetails(AdminRoleDetails item);

        IBaseEntityResponse<AdminRoleDetails> DeleteAdminRoleDetails(AdminRoleDetails item);
    }
}
