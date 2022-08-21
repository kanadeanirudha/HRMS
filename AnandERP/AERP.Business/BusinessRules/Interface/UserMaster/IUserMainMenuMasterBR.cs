using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IUserMainMenuMasterBR
    {
        IValidateBusinessRuleResponse InsertUserMainMenuMasterValidate(UserMainMenuMaster item);
        IValidateBusinessRuleResponse UpdateUserMainMenuMasterValidate(UserMainMenuMaster item);
        IValidateBusinessRuleResponse DeleteUserMainMenuMasterValidate(UserMainMenuMaster item);
    }
}
