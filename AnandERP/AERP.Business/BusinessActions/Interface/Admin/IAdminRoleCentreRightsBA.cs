using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IAdminRoleCentreRightsBA
    {
        IBaseEntityResponse<AdminRoleCentreRights> InsertAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> UpdateAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityResponse<AdminRoleCentreRights> DeleteAdminRoleCentreRights(AdminRoleCentreRights item);

        IBaseEntityCollectionResponse<AdminRoleCentreRights> GetBySearch(AdminRoleCentreRightsSearchRequest searchRequest);

        IBaseEntityResponse<AdminRoleCentreRights> SelectByID(AdminRoleCentreRights item);

        IBaseEntityCollectionResponse<AdminRoleCentreRights> GetCentreLevelManagerRights(AdminRoleCentreRightsSearchRequest searchRequest);         
    }
}
