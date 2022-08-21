using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IOrganisationMasterBA
    {
        IBaseEntityResponse<OrganisationMaster> InsertOrganisationMaster(OrganisationMaster item);
        IBaseEntityResponse<OrganisationMaster> UpdateOrganisationMaster(OrganisationMaster item);
        IBaseEntityResponse<OrganisationMaster> DeleteOrganisationMaster(OrganisationMaster item);
        IBaseEntityCollectionResponse<OrganisationMaster> GetBySearch(OrganisationMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<OrganisationMaster> GetBySearchList(OrganisationMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationMaster> SelectByID(OrganisationMaster item);
    }
}
