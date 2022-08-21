using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AMS.Business.BusinessRules
{
    public interface IOrganisationStandardMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationStandardMasterValidate(OrganisationStandardMaster item);

        IValidateBusinessRuleResponse UpdateOrganisationStandardMasterValidate(OrganisationStandardMaster item);

        IValidateBusinessRuleResponse DeleteOrganisationStandardMasterValidate(OrganisationStandardMaster item);
    }
}
