using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationBranchMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationBranchMasterValidate(OrganisationBranchMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationBranchMasterValidate(OrganisationBranchMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationBranchMasterValidate(OrganisationBranchMaster item);
    }
}
