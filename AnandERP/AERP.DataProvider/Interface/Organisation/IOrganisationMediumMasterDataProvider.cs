using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationMediumMasterDataProvider
    {
        IBaseEntityResponse<OrganisationMediumMaster> InsertOrganisationMediumMaster(OrganisationMediumMaster item);
        IBaseEntityResponse<OrganisationMediumMaster> UpdateOrganisationMediumMaster(OrganisationMediumMaster item);
        IBaseEntityResponse<OrganisationMediumMaster> DeleteOrganisationMediumMaster(OrganisationMediumMaster item);
        IBaseEntityCollectionResponse<OrganisationMediumMaster> GetOrganisationMediumMasterBySearch(OrganisationMediumMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationMediumMaster> GetOrganisationMediumMasterByID(OrganisationMediumMaster item);
        IBaseEntityCollectionResponse<OrganisationMediumMaster> GetOrganisationMediumMasterGetBySearchList(OrganisationMediumMasterSearchRequest searchRequest);

    }
}
