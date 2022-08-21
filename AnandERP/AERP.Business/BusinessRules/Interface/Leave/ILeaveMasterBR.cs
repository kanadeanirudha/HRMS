using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ILeaveMasterBR
    {
        IValidateBusinessRuleResponse InsertLeaveMasterValidate(LeaveMaster item);
        IValidateBusinessRuleResponse UpdateLeaveMasterValidate(LeaveMaster item);
        IValidateBusinessRuleResponse DeleteLeaveMasterValidate(LeaveMaster item);
    }
}
