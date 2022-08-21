using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountHeadMasterReportBR
    {
        /// <summary>
        /// business rule interface of insert new record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountHeadMasterReportValidate(AccountHeadMasterReport item);

        /// <summary>
        /// business rule interface of update record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountHeadMasterReportValidate(AccountHeadMasterReport item);

        /// <summary>
        /// business rule interface of dalete record of account head master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountHeadMasterReportValidate(AccountHeadMasterReport item);
    }
}
