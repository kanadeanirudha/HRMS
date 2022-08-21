using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IAccountTransactionTypeMasterBA
    {
        IBaseEntityResponse<AccountTransactionTypeMaster> InsertAccountTransactionTypeMaster(AccountTransactionTypeMaster item);
        IBaseEntityResponse<AccountTransactionTypeMaster> UpdateAccountTransactionTypeMaster(AccountTransactionTypeMaster item);
        IBaseEntityResponse<AccountTransactionTypeMaster> DeleteAccountTransactionTypeMaster(AccountTransactionTypeMaster item);
        IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetBySearch(AccountTransactionTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeSearchList(AccountTransactionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<AccountTransactionTypeMaster> SelectByID(AccountTransactionTypeMaster item);
        IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeList(AccountTransactionTypeMasterSearchRequest searchRequest);


    }
}
