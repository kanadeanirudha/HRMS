using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IUserMasterBR
    {
        IValidateBusinessRuleResponse InsertUserMasterValidate(UserMaster item);

        IValidateBusinessRuleResponse UpdateUserMasterValidate(UserMaster item);

        IValidateBusinessRuleResponse DeleteUserMasterValidate(UserMaster item);
    }
}
