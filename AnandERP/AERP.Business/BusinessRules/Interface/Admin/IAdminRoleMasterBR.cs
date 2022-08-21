using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAdminRoleMasterBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleMasterValidate(AdminRoleMaster item);

        IValidateBusinessRuleResponse UpdateAdminRoleMasterValidate(AdminRoleMaster item);

        IValidateBusinessRuleResponse DeleteAdminRoleMasterValidate(AdminRoleMaster item);
    }
}
