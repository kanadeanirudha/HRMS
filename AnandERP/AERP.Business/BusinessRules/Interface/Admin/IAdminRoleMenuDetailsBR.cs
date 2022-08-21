using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAdminRoleMenuDetailsBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleMenuDetailsValidate(AdminRoleMenuDetails item);

        IValidateBusinessRuleResponse UpdateAdminRoleMenuDetailsValidate(AdminRoleMenuDetails item);

        IValidateBusinessRuleResponse DeleteAdminRoleMenuDetailsValidate(AdminRoleMenuDetails item);
    }
}
