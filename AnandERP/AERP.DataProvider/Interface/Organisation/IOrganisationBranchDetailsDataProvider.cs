using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationBranchDetailsDataProvider
    {
        IBaseEntityResponse<OrganisationBranchDetails> InsertOrganisationBranchDetails(OrganisationBranchDetails item);
        IBaseEntityResponse<OrganisationBranchDetails> UpdateOrganisationBranchDetails(OrganisationBranchDetails item);
        IBaseEntityResponse<OrganisationBranchDetails> DeleteOrganisationBranchDetails(OrganisationBranchDetails item);
        IBaseEntityCollectionResponse<OrganisationBranchDetails> GetOrganisationBranchDetailsBySearch(OrganisationBranchDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationBranchDetails> GetOrganisationBranchDetailsByID(OrganisationBranchDetails item);
        IBaseEntityResponse<OrganisationBranchDetails> GetOrganisationBranchDetailsByID_For_CourseDescription(OrganisationBranchDetails item);
    }
}
