using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAdminRoleModuleAccessDataProvider
    { 
        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAdminRoleModuleAccessBySearch(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleModuleAccess> GetAdminRoleModuleAccessByID(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> InsertAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> UpdateAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> DeleteAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> GetVwAdminSnPostsRoleMasterDetalisByID(AdminRoleModuleAccess item);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAccessibleCentreListByID(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetEntityByID(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAdminEntityInduvidualListBySearch(AdminRoleModuleAccessSearchRequest searchRequest);
    }
}
