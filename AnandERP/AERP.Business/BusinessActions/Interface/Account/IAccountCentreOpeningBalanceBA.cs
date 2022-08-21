using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IAccountCentreOpeningBalanceBA
    {
        IBaseEntityResponse<AccountCentreOpeningBalance> InsertAccountCentreOpeningBalance(AccountCentreOpeningBalance item);
        IBaseEntityResponse<AccountCentreOpeningBalance> UpdateAccountCentreOpeningBalance(AccountCentreOpeningBalance item);
        IBaseEntityResponse<AccountCentreOpeningBalance> DeleteAccountCentreOpeningBalance(AccountCentreOpeningBalance item);
        IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearch(AccountCentreOpeningBalanceSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountCentreOpeningBalance> GetBySearchIndividualAccount(AccountCentreOpeningBalanceSearchRequest searchRequest);
        IBaseEntityResponse<AccountCentreOpeningBalance> SelectByID(AccountCentreOpeningBalance item);
    }
}
