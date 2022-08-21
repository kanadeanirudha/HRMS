using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IOrganisationDirectorMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationDirectorMasterValidate(OrganisationDirectorMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationDirectorMasterValidate(OrganisationDirectorMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationDirectorMasterValidate(OrganisationDirectorMaster item);
    }
}
