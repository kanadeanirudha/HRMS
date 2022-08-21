using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationMediumMasterBA
    {
        IBaseEntityResponse<OrganisationMediumMaster> InsertOrganisationMediumMaster(OrganisationMediumMaster item);
        IBaseEntityResponse<OrganisationMediumMaster> UpdateOrganisationMediumMaster(OrganisationMediumMaster item);
        IBaseEntityResponse<OrganisationMediumMaster> DeleteOrganisationMediumMaster(OrganisationMediumMaster item);
        IBaseEntityCollectionResponse<OrganisationMediumMaster> GetBySearch(OrganisationMediumMasterSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationMediumMaster> SelectByID(OrganisationMediumMaster item);
        IBaseEntityCollectionResponse<OrganisationMediumMaster> GetBySearchList(OrganisationMediumMasterSearchRequest searchRequest);
    }
}
