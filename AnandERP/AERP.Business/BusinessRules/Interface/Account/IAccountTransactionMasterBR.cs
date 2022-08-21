using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IAccountTransactionMasterBR
    {
        IValidateBusinessRuleResponse InsertAccountTransactionMasterValidate(AccountTransactionMaster item);
        IValidateBusinessRuleResponse UpdateAccountTransactionMasterValidate(AccountTransactionMaster item);
        IValidateBusinessRuleResponse DeleteAccountTransactionMasterValidate(AccountTransactionMaster item);
    }
}
