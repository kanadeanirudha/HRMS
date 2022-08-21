using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public interface IAccountBankTransactionBA
    {
        IBaseEntityResponse<AccountBankTransaction> InsertAccountBankTransaction(AccountBankTransaction item);
        IBaseEntityResponse<AccountBankTransaction> UpdateAccountBankTransaction(AccountBankTransaction item);
        IBaseEntityResponse<AccountBankTransaction> DeleteAccountBankTransaction(AccountBankTransaction item);
        IBaseEntityCollectionResponse<AccountBankTransaction> GetBySearch(AccountBankTransactionSearchRequest searchRequest);
        IBaseEntityResponse<AccountBankTransaction> SelectByID(AccountBankTransaction item);
    }
}
