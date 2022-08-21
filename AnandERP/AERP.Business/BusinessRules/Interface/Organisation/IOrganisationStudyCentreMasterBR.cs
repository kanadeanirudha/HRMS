using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IOrganisationStudyCentreMasterBR
    {
        IValidateBusinessRuleResponse InsertOrganisationStudyCentreMasterValidate(OrganisationStudyCentreMaster item);
        IValidateBusinessRuleResponse UpdateOrganisationStudyCentreMasterValidate(OrganisationStudyCentreMaster item);
        IValidateBusinessRuleResponse DeleteOrganisationStudyCentreMasterValidate(OrganisationStudyCentreMaster item);
    }
}
