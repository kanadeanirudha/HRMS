using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Base.DTO;
using AMS.DTO;

namespace AMS.DataProvider
{
    public interface IOrganisationDivisionMasterDataProvider
    {
        IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetOrganisationDivisionMasterBySearch(OrganisationDivisionMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationDivisionMaster> GetOrganisationDivisionMasterByID(OrganisationDivisionMaster item);

        IBaseEntityResponse<OrganisationDivisionMaster> InsertOrganisationDivisionMaster(OrganisationDivisionMaster item);

        IBaseEntityResponse<OrganisationDivisionMaster> UpdateOrganisationDivisionMaster(OrganisationDivisionMaster item);

        IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetOrganisationDivisionMasterGetBySearchList(OrganisationDivisionMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationDivisionMaster> DeleteOrganisationDivisionMaster(OrganisationDivisionMaster item);
    }
}
