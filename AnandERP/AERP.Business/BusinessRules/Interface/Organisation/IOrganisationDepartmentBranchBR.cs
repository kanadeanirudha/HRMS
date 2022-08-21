using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationDepartmentBranchBR
    {
        IValidateBusinessRuleResponse InsertOrganisationDepartmentBranchValidate(OrganisationDepartmentBranch item);
        IValidateBusinessRuleResponse UpdateOrganisationDepartmentBranchValidate(OrganisationDepartmentBranch item);
        IValidateBusinessRuleResponse DeleteOrganisationDepartmentBranchValidate(OrganisationDepartmentBranch item);
    }
}
