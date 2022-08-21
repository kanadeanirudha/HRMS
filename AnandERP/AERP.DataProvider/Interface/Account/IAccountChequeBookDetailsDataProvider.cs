using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
   public interface IAccountChequeBookDetailsDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account cheque book details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountChequeBookDetails> GetAccountChequeBookDetailsBySearch(AccountChequeBookDetailsSearchRequest searchRequest);
       
        /// <summary>
        /// data provider interface of select all record of account cheque book details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountChequeBookDetails> GetAccountChequeBookDetailsBySearchForEditView(AccountChequeBookDetailsSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of account cheque book details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookDetails> GetAccountChequeBookDetailsByID(AccountChequeBookDetails item);

        /// <summary>
        /// data provider interface of insert new record of account cheque book details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookDetails> InsertAccountChequeBookDetails(AccountChequeBookDetails item);

        /// <summary>
        /// data provider interface of update record of account cheque book details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookDetails> UpdateAccountChequeBookDetails(AccountChequeBookDetails item);

        /// <summary>
        /// data provider interface of dalete record of account cheque book details.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountChequeBookDetails> DeleteAccountChequeBookDetails(AccountChequeBookDetails item);
    }
}
