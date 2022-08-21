using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationElectiveGrpMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationElectiveGrpMasterValidate(OrganisationElectiveGrpMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationElectiveGrpMasterValidate(OrganisationElectiveGrpMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationElectiveGrpMasterValidate(OrganisationElectiveGrpMaster item);
    }
}
