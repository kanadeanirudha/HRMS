using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IOrganisationSemesterMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationSemesterMasterValidate(OrganisationSemesterMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationSemesterMasterValidate(OrganisationSemesterMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationSemesterMasterValidate(OrganisationSemesterMaster item);
    }
}
