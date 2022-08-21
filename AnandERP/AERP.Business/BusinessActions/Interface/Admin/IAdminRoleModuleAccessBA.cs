using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAdminRoleModuleAccessBA 
    {
        IBaseEntityResponse<AdminRoleModuleAccess> InsertAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> UpdateAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> DeleteAdminRoleModuleAccess(AdminRoleModuleAccess item);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetBySearch(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleModuleAccess> SelectByID(AdminRoleModuleAccess item);

        IBaseEntityResponse<AdminRoleModuleAccess> SelectByAdminRoleMasterID(AdminRoleModuleAccess item);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAccessibleCentreListByID(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetEntityByID(AdminRoleModuleAccessSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAdminEntityInduvidualListBySearch(AdminRoleModuleAccessSearchRequest searchRequest);
    }
}
