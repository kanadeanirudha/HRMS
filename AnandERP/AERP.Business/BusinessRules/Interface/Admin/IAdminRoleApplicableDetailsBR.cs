using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAdminRoleApplicableDetailsBR
    {
        IValidateBusinessRuleResponse InsertAdminRoleApplicableDetailsValidate(AdminRoleApplicableDetails item);

        IValidateBusinessRuleResponse UpdateAdminRoleApplicableDetailsValidate(AdminRoleApplicableDetails item);

        IValidateBusinessRuleResponse DeleteAdminRoleApplicableDetailsValidate(AdminRoleApplicableDetails item);
    }
}
