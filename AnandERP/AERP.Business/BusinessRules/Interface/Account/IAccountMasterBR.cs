using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountMasterValidate(AccountMaster item);

        /// <summary>
        /// business rule interface of update record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountMasterValidate(AccountMaster item);

        /// <summary>
        /// business rule interface of dalete record of account master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountMasterValidate(AccountMaster item);
    }
}
