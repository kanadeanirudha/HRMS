using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IOrganisationSubjectGrpCombinationBA
    {
        IBaseEntityResponse<OrganisationSubjectGrpCombination> InsertOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item);
        IBaseEntityResponse<OrganisationSubjectGrpCombination> UpdateOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item);
        IBaseEntityResponse<OrganisationSubjectGrpCombination> DeleteOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item);
        IBaseEntityCollectionResponse<OrganisationSubjectGrpCombination> GetBySearch(OrganisationSubjectGrpCombinationSearchRequest searchRequest);
        IBaseEntityResponse<OrganisationSubjectGrpCombination> SelectByID(OrganisationSubjectGrpCombination item);
    }
}
