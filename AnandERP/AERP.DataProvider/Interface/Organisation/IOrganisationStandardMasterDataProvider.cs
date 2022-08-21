using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IOrganisationStandardMasterDataProvider
    {
        IBaseEntityCollectionResponse<OrganisationStandardMaster> GetOrganisationStandardMasterBySearch(OrganisationStandardMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationStandardMaster> GetOrganisationStandardMasterByID(OrganisationStandardMaster item);

        IBaseEntityResponse<OrganisationStandardMaster> InsertOrganisationStandardMaster(OrganisationStandardMaster item);

        IBaseEntityResponse<OrganisationStandardMaster> UpdateOrganisationStandardMaster(OrganisationStandardMaster item);

        IBaseEntityResponse<OrganisationStandardMaster> DeleteOrganisationStandardMaster(OrganisationStandardMaster item);

        IBaseEntityCollectionResponse<OrganisationStandardMaster> GetOrganisationStandardMasterGetBySearchList(OrganisationStandardMasterSearchRequest searchRequest);

    }
}
