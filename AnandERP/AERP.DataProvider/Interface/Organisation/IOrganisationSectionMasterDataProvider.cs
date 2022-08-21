using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSectionMasterDataProvider
    {
        IBaseEntityResponse<OrganisationSectionMaster> InsertOrganisationSectionMaster(OrganisationSectionMaster item);
        IBaseEntityResponse<OrganisationSectionMaster> UpdateOrganisationSectionMaster(OrganisationSectionMaster item);
        IBaseEntityResponse<OrganisationSectionMaster> DeleteOrganisationSectionMaster(OrganisationSectionMaster item);
        IBaseEntityCollectionResponse<OrganisationSectionMaster> GetOrganisationSectionMasterBySearch(OrganisationSectionMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSectionMaster> GetOrganisationSectionMasterByID(OrganisationSectionMaster item);
        IBaseEntityCollectionResponse<OrganisationSectionMaster> GetOrganisationSectionMasterBySearchList(OrganisationSectionMasterSearchRequest searchRequest);
    }
}
