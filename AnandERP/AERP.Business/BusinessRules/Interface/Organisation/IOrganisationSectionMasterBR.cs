using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationSectionMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationSectionMasterValidate(OrganisationSectionMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationSectionMasterValidate(OrganisationSectionMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationSectionMasterValidate(OrganisationSectionMaster item);
    }
}
