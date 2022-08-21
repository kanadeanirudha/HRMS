using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationBranchDetailsBA
    {
        IBaseEntityResponse<OrganisationBranchDetails> InsertOrganisationBranchDetails(OrganisationBranchDetails item);
        IBaseEntityResponse<OrganisationBranchDetails> UpdateOrganisationBranchDetails(OrganisationBranchDetails item);
        IBaseEntityResponse<OrganisationBranchDetails> DeleteOrganisationBranchDetails(OrganisationBranchDetails item);
        IBaseEntityCollectionResponse<OrganisationBranchDetails> GetBySearch(OrganisationBranchDetailsSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationBranchDetails> SelectByID(OrganisationBranchDetails item);
         IBaseEntityResponse<OrganisationBranchDetails> SelectByID_For_CourseDescription(OrganisationBranchDetails item);
    }
}
