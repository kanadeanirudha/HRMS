using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationSubjectGrpCombinationBR
    {
        IValidateBusinessRuleResponse InsertOrganisationSubjectGrpCombinationValidate(OrganisationSubjectGrpCombination item);
        IValidateBusinessRuleResponse UpdateOrganisationSubjectGrpCombinationValidate(OrganisationSubjectGrpCombination item);
        IValidateBusinessRuleResponse DeleteOrganisationSubjectGrpCombinationValidate(OrganisationSubjectGrpCombination item);
    }
}
