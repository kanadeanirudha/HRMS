using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IDashboardBR
    {
        IValidateBusinessRuleResponse InsertDashboardValidate(Dashboard item);
        IValidateBusinessRuleResponse UpdateDashboardValidate(Dashboard item);
        IValidateBusinessRuleResponse DeleteDashboardValidate(Dashboard item);

        IValidateBusinessRuleResponse InsertContaintAllocateStatusValidate(Dashboard item);
        IValidateBusinessRuleResponse DeleteContaintAllocateStatusValidate(Dashboard item);
    }
}
