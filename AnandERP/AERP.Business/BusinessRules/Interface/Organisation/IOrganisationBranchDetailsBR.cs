using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationBranchDetailsBR
    {
        IValidateBusinessRuleResponse InsertOrganisationBranchDetailsValidate(OrganisationBranchDetails item);
        IValidateBusinessRuleResponse UpdateOrganisationBranchDetailsValidate(OrganisationBranchDetails item);
        IValidateBusinessRuleResponse DeleteOrganisationBranchDetailsValidate(OrganisationBranchDetails item);
    }
}
