using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IAccountChequeBookMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertAccountChequeBookMasterValidate(AccountChequeBookMaster item);

        /// <summary>
        /// business rule interface of update record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateAccountChequeBookMasterValidate(AccountChequeBookMaster item);

        /// <summary>
        /// business rule interface of dalete record of account cheque book master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteAccountChequeBookMasterValidate(AccountChequeBookMaster item);
    }
}

