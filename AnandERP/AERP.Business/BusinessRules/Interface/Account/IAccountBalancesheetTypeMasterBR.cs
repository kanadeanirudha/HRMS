using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountBalancesheetTypeMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account balance sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountBalancesheetTypeMasterValidate(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// business rule interface of update record of account balance sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountBalancesheetTypeMasterValidate(AccountBalancesheetTypeMaster item);

        /// <summary>
        /// business rule interface of dalete record of account balance sheet type master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountBalancesheetTypeMasterValidate(AccountBalancesheetTypeMaster item);
    }
}
