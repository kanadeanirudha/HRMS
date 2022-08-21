using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationSubElectiveGrpMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationSubElectiveGrpMasterValidate(OrganisationSubElectiveGrpMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationSubElectiveGrpMasterValidate(OrganisationSubElectiveGrpMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationSubElectiveGrpMasterValidate(OrganisationSubElectiveGrpMaster item);
    }
}
