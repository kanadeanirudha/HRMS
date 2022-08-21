using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
	public interface IAccountChequeBookDetailsBA
	{
		IBaseEntityResponse<AccountChequeBookDetails> InsertAccountChequeBookDetails(AccountChequeBookDetails item);
		IBaseEntityResponse<AccountChequeBookDetails> UpdateAccountChequeBookDetails(AccountChequeBookDetails item);
		IBaseEntityResponse<AccountChequeBookDetails> DeleteAccountChequeBookDetails(AccountChequeBookDetails item);
		IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearch(AccountChequeBookDetailsSearchRequest searchRequest);
        IBaseEntityCollectionResponse<AccountChequeBookDetails> GetBySearchForEditView(AccountChequeBookDetailsSearchRequest searchRequest);
		IBaseEntityResponse<AccountChequeBookDetails> SelectByID(AccountChequeBookDetails item);
	}
}
