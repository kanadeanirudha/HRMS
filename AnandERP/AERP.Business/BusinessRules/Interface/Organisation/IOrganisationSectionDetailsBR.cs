using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationSectionDetailsBR
    {
        IValidateBusinessRuleResponse InsertOrganisationSectionDetailsValidate(OrganisationSectionDetails item);
        IValidateBusinessRuleResponse UpdateOrganisationSectionDetailsValidate(OrganisationSectionDetails item);
        IValidateBusinessRuleResponse DeleteOrganisationSectionDetailsValidate(OrganisationSectionDetails item);
        IValidateBusinessRuleResponse UpdateOrganisationSectionDetailsValidateAdd(OrganisationSectionDetails item);
    }
}
