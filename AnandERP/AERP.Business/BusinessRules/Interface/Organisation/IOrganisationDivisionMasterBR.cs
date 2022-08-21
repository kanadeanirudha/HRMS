using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOrganisationDivisionMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationDivisionMasterValidate(OrganisationDivisionMaster item);

        IValidateBusinessRuleResponse UpdateOrganisationDivisionMasterValidate(OrganisationDivisionMaster item);

        IValidateBusinessRuleResponse DeleteOrganisationDivisionMasterValidate(OrganisationDivisionMaster item);
    }
}
