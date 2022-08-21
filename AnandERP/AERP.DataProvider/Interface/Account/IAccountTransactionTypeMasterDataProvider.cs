using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IAccountTransactionTypeMasterDataProvider
    {
        IBaseEntityResponse<AccountTransactionTypeMaster> InsertAccountTransactionTypeMaster(AccountTransactionTypeMaster item);
        IBaseEntityResponse<AccountTransactionTypeMaster> UpdateAccountTransactionTypeMaster(AccountTransactionTypeMaster item);
        IBaseEntityResponse<AccountTransactionTypeMaster> DeleteAccountTransactionTypeMaster(AccountTransactionTypeMaster item);
        IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetAccountTransactionTypeMasterBySearch(AccountTransactionTypeMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeSearchList(AccountTransactionTypeMasterSearchRequest searchRequest);
        IBaseEntityResponse<AccountTransactionTypeMaster> GetAccountTransactionTypeMasterByID(AccountTransactionTypeMaster item);
        IBaseEntityCollectionResponse<AccountTransactionTypeMaster> GetTransactionTypeList(AccountTransactionTypeMasterSearchRequest searchRequest);
    }
}
