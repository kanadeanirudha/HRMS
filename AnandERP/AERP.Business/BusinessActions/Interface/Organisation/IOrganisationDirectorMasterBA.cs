using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationDirectorMasterBA
    {
        IBaseEntityResponse<OrganisationDirectorMaster> InsertOrganisationDirectorMaster(OrganisationDirectorMaster item);
        IBaseEntityResponse<OrganisationDirectorMaster> UpdateOrganisationDirectorMaster(OrganisationDirectorMaster item);
        IBaseEntityResponse<OrganisationDirectorMaster> DeleteOrganisationDirectorMaster(OrganisationDirectorMaster item);
        IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetBySearch(OrganisationDirectorMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationDirectorMaster> SelectByID(OrganisationDirectorMaster item);

        IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetUserEntityCentrewiseSearchList(OrganisationDirectorMasterSearchRequest searchRequest);
    }
}
