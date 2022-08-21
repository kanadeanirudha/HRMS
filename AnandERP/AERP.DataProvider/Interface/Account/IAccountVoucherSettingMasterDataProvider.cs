using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.DataProvider
{
    public interface IAccountVoucherSettingMasterDataProvider
    {
        /// <summary>
        /// data provider interface of select all record of account voucher setting master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<AccountVoucherSettingMaster> GetAccountVoucherSettingMasterBySearch(AccountVoucherSettingMasterSearchRequest searchRequest);
        
        /// <summary>
        /// data provider interface of select one record of account voucher setting master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountVoucherSettingMaster> GetAccountVoucherSettingMasterByID(AccountVoucherSettingMaster item);

        /// <summary>
        /// data provider interface of insert new record of account voucher setting master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountVoucherSettingMaster> InsertAccountVoucherSettingMaster(AccountVoucherSettingMaster item);

        /// <summary>
        /// data provider interface of update record of account voucher setting master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountVoucherSettingMaster> UpdateAccountVoucherSettingMaster(AccountVoucherSettingMaster item);

        /// <summary>
        /// data provider interface of dalete record of account voucher setting master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<AccountVoucherSettingMaster> DeleteAccountVoucherSettingMaster(AccountVoucherSettingMaster item);
    }
}
