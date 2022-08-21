using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IOrganisationDepartmentMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationDepartmentMasterValidate(OrganisationDepartmentMaster item);

        IValidateBusinessRuleResponse UpdateOrganisationDepartmentMasterValidate(OrganisationDepartmentMaster item);

        IValidateBusinessRuleResponse DeleteOrganisationDepartmentMasterValidate(OrganisationDepartmentMaster item);
    }
}
