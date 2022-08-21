using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationSessionCryrAllocationBR
    {
        IValidateBusinessRuleResponse InsertOrganisationSessionCryrAllocationValidate(OrganisationSessionCryrAllocation item);
        IValidateBusinessRuleResponse UpdateOrganisationSessionCryrAllocationValidate(OrganisationSessionCryrAllocation item);
        IValidateBusinessRuleResponse DeleteOrganisationSessionCryrAllocationValidate(OrganisationSessionCryrAllocation item);
    }
}
