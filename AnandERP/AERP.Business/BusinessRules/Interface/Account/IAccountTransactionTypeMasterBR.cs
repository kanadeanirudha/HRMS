using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IAccountTransactionTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertAccountTransactionTypeMasterValidate(AccountTransactionTypeMaster item);
        IValidateBusinessRuleResponse UpdateAccountTransactionTypeMasterValidate(AccountTransactionTypeMaster item);
        IValidateBusinessRuleResponse DeleteAccountTransactionTypeMasterValidate(AccountTransactionTypeMaster item);
    }
}
