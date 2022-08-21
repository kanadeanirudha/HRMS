
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAdminRoleCentreRightsBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleCentreRightsValidate(AdminRoleCentreRights item);

        IValidateBusinessRuleResponse UpdateAdminRoleCentreRightsValidate(AdminRoleCentreRights item);

        IValidateBusinessRuleResponse DeleteAdminRoleCentreRightsValidate(AdminRoleCentreRights item);
    }
}
