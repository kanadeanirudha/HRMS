using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IOrganisationStreamMasterDataProvider
    {
        IBaseEntityCollectionResponse<OrganisationStreamMaster> GetOrganisationStreamMasterBySearch(OrganisationStreamMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationStreamMaster> GetOrganisationStreamMasterBySearchList(OrganisationStreamMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationStreamMaster> GetOrganisationStreamMasterByID(OrganisationStreamMaster item);

        IBaseEntityResponse<OrganisationStreamMaster> InsertOrganisationStreamMaster(OrganisationStreamMaster item);

        IBaseEntityResponse<OrganisationStreamMaster> UpdateOrganisationStreamMaster(OrganisationStreamMaster item);

        IBaseEntityResponse<OrganisationStreamMaster> DeleteOrganisationStreamMaster(OrganisationStreamMaster item);
    }
}
