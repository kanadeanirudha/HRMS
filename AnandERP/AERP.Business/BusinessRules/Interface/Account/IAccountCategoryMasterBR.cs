using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountCategoryMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountCategoryMasterValidate(AccountCategoryMaster item);

        /// <summary>
        /// business rule interface of update record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountCategoryMasterValidate(AccountCategoryMaster item);

        /// <summary>
        /// business rule interface of dalete record of account category master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountCategoryMasterValidate(AccountCategoryMaster item);
    }
}
