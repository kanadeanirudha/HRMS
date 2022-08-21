using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAdminRoleMasterBA
    {
        IBaseEntityResponse<AdminRoleMaster> InsertAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> UpdateAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityResponse<AdminRoleMaster> DeleteAdminRoleMaster(AdminRoleMaster item);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetBySearch(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleMaster> SelectByID(AdminRoleMaster item);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetBySearchForAdminRoleDetailsBySPD(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetCentreRightsByRole(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetDefaultRoleRightsType(AdminRoleMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleDomainList(AdminRoleMasterSearchRequest searchRequest); 
    }
}
