using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSessionCryrAllocationBA
    {
        IBaseEntityResponse<OrganisationSessionCryrAllocation> InsertOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> UpdateOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> DeleteOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item);
        IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> GetBySearch(OrganisationSessionCryrAllocationSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> SelectByID(OrganisationSessionCryrAllocation item);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> GetCurrentSession(OrganisationSessionCryrAllocation item);
    }
}
