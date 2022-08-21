using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.DataProvider
{
    public interface IOrganisationSubjectGrpCombinationDataProvider
    {
        IBaseEntityResponse<OrganisationSubjectGrpCombination> InsertOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item);
        IBaseEntityResponse<OrganisationSubjectGrpCombination> UpdateOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item);
        IBaseEntityResponse<OrganisationSubjectGrpCombination> DeleteOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpCombination> GetOrganisationSubjectGrpCombinationBySearch(OrganisationSubjectGrpCombinationSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGrpCombination> GetOrganisationSubjectGrpCombinationByID(OrganisationSubjectGrpCombination item);
    }
}
