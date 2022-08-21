using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationMediumMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationMediumMasterValidate(OrganisationMediumMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationMediumMasterValidate(OrganisationMediumMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationMediumMasterValidate(OrganisationMediumMaster item);
    }
}
