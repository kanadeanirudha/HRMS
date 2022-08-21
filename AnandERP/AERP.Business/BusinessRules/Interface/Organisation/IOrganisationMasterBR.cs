using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IOrganisationMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationMasterValidate(OrganisationMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationMasterValidate(OrganisationMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationMasterValidate(OrganisationMaster item);
    }
}
