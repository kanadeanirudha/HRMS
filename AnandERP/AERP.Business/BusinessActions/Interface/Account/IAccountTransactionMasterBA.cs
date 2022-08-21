using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IAccountTransactionMasterBA
    {
        IBaseEntityResponse<AccountTransactionMaster> InsertAccountTransactionMaster(AccountTransactionMaster item);
        IBaseEntityResponse<AccountTransactionMaster> UpdateAccountTransactionMaster(AccountTransactionMaster item);
        IBaseEntityResponse<AccountTransactionMaster> DeleteAccountTransactionMaster(AccountTransactionMaster item);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearch(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetBySearchForEditView(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetAccountList(AccountTransactionMasterSearchRequest searchRequest);
        IBaseEntityResponse<AccountTransactionMaster> SelectByID(AccountTransactionMaster item);
        IBaseEntityResponse<AccountTransactionMaster> InsertAccountVoucherRequest(AccountTransactionMaster item);
        IBaseEntityCollectionResponse<AccountTransactionMaster> GetVoucherDetailsForApproval(AccountTransactionMasterSearchRequest searchRequest);     
    }
}
