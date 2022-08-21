using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IBankMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<BankMaster> GetBankMasterBySearch(BankMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<BankMaster> GetBankMasterGetBySearchList(BankMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> GetBankMasterByID(BankMaster item);

        /// <summary>
        /// data provider interface of insert new record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> InsertBankMaster(BankMaster item);

        /// <summary>
        /// data provider interface of update record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> UpdateBankMaster(BankMaster item);

        /// <summary>
        /// data provider interface of dalete record of BankMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<BankMaster> DeleteBankMaster(BankMaster item);
    }
}
