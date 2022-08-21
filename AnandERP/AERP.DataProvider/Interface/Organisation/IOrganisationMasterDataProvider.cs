using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IOrganisationMasterDataProvider
    {
        IBaseEntityResponse<OrganisationMaster> InsertOrganisationMaster(OrganisationMaster item);
        IBaseEntityResponse<OrganisationMaster> UpdateOrganisationMaster(OrganisationMaster item);
        IBaseEntityResponse<OrganisationMaster> DeleteOrganisationMaster(OrganisationMaster item);
        IBaseEntityCollectionResponse<OrganisationMaster> GetOrganisationMasterBySearch(OrganisationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationMaster> GetOrganisationMasterGetBySearchList(OrganisationMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationMaster> GetOrganisationMasterByID(OrganisationMaster item);
    }
}
