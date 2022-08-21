using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOrganisationStreamMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationStreamMasterValidate(OrganisationStreamMaster item);

        IValidateBusinessRuleResponse UpdateOrganisationStreamMasterValidate(OrganisationStreamMaster item);

        IValidateBusinessRuleResponse DeleteOrganisationStreamMasterValidate(OrganisationStreamMaster item);
    }
}
