using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IOrganisationDirectorMasterDataProvider
    {
        IBaseEntityResponse<OrganisationDirectorMaster> InsertOrganisationDirectorMaster(OrganisationDirectorMaster item);
        IBaseEntityResponse<OrganisationDirectorMaster> UpdateOrganisationDirectorMaster(OrganisationDirectorMaster item);
        IBaseEntityResponse<OrganisationDirectorMaster> DeleteOrganisationDirectorMaster(OrganisationDirectorMaster item);
        IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetOrganisationDirectorMasterBySearch(OrganisationDirectorMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationDirectorMaster> GetOrganisationDirectorMasterByID(OrganisationDirectorMaster item);

        IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetUserEntityCentrewiseSearchList(OrganisationDirectorMasterSearchRequest searchRequest);
    }
}
