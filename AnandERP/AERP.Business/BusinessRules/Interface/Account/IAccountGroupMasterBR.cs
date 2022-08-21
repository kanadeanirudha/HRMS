using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountGroupMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountGroupMasterValidate(AccountGroupMaster item);

        /// <summary>
        /// business rule interface of update record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountGroupMasterValidate(AccountGroupMaster item);

        /// <summary>
        /// business rule interface of dalete record of account group master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountGroupMasterValidate(AccountGroupMaster item);
    }
}
