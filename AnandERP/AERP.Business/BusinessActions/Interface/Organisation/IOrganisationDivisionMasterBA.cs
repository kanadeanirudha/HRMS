using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public interface IOrganisationDivisionMasterBA
    {
        IBaseEntityResponse<OrganisationDivisionMaster> InsertOrganisationDivisionMaster(OrganisationDivisionMaster item);

        IBaseEntityResponse<OrganisationDivisionMaster> UpdateOrganisationDivisionMaster(OrganisationDivisionMaster item);

        IBaseEntityResponse<OrganisationDivisionMaster> DeleteOrganisationDivisionMaster(OrganisationDivisionMaster item);

        IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetBySearch(OrganisationDivisionMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetBySearchList(OrganisationDivisionMasterSearchRequest searchRequest);

        IBaseEntityResponse<OrganisationDivisionMaster> SelectByID(OrganisationDivisionMaster item);
    }
}
