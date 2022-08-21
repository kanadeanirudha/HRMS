using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IBankMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> InsertBankMaster(BankMaster item);

        /// <summary>
        /// business action interface of update record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> UpdateBankMaster(BankMaster item);

        /// <summary>
        /// business action interface of dalete record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> DeleteBankMaster(BankMaster item);

        /// <summary>
        /// business action interface of select all record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<BankMaster> GetBySearch(BankMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<BankMaster> GetBySearchList(BankMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> SelectByID(BankMaster item);
    }
}
