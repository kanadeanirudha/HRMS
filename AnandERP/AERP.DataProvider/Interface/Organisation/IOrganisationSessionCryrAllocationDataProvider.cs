using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSessionCryrAllocationDataProvider
    {
        IBaseEntityResponse<OrganisationSessionCryrAllocation> InsertOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> UpdateOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> DeleteOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item);
        IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> GetOrganisationSessionCryrAllocationBySearch(OrganisationSessionCryrAllocationSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> GetOrganisationSessionCryrAllocationByID(OrganisationSessionCryrAllocation item);
        IBaseEntityResponse<OrganisationSessionCryrAllocation> GetCurrentSession(OrganisationSessionCryrAllocation item);
    }
}
