using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface IAdminRoleCentreRightsDataProvider
    {
        IBaseEntityCollectionResponse<AdminRoleCentreRights> GetAdminRoleCentreRightsBySearch(AdminRoleCentreRightsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleCentreRights> GetAdminRoleCentreRightsByID(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> InsertAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> UpdateAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> DeleteAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityCollectionResponse<AdminRoleCentreRights> GetCentreLevelManagerRights(AdminRoleCentreRightsSearchRequest searchRequest);        
    }
}
