using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IOrganisationCentrewiseDepartmentBR
    {
        IValidateBusinessRuleResponse InsertOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
        IValidateBusinessRuleResponse UpdateOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
        IValidateBusinessRuleResponse InsertUpdateOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
        IValidateBusinessRuleResponse DeleteOrganisationCentrewiseDepartmentValidate(OrganisationCentrewiseDepartment item);
    }
}
