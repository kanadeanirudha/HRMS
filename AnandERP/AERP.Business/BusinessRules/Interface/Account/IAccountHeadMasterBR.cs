using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountHeadMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountHeadMasterValidate(AccountHeadMaster item);

        /// <summary>
        /// business rule interface of update record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountHeadMasterValidate(AccountHeadMaster item);

        /// <summary>
        /// business rule interface of dalete record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountHeadMasterValidate(AccountHeadMaster item);
    }
}
