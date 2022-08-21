using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IAccountBankTransactionBR
    {
        IValidateBusinessRuleResponse InsertAccountBankTransactionValidate(AccountBankTransaction item);
        IValidateBusinessRuleResponse UpdateAccountBankTransactionValidate(AccountBankTransaction item);
        IValidateBusinessRuleResponse DeleteAccountBankTransactionValidate(AccountBankTransaction item);
    }
}
