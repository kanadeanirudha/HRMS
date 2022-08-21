using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAdminRoleMasterDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleMasterBySearch(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleMaster> GetAdminRoleMasterByID(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> InsertAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> UpdateAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> DeleteAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleMasterBySearchForAdminRoleDetailsBySPD(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminCentreRightsByRole(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetDefaultRoleRightsType(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleDomainList(AdminRoleMasterSearchRequest searchRequest); 
    }
}
