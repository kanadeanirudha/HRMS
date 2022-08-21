using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public class AccountVoucherSettingMasterReportBA : IAccountVoucherSettingMasterReportBA
    {
        IAccountVoucherSettingMasterReportDataProvider _accVoucherSettingMasterDataProvider;
       // IAccountVoucherSettingMasterReportBR _accVoucherSettingMasterBR;
        private ILogger _logException;
        public AccountVoucherSettingMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
         //   _accVoucherSettingMasterBR = new AccountVoucherSettingMasterReportBR();
            _accVoucherSettingMasterDataProvider = new AccountVoucherSettingMasterReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountVoucherSettingMasterReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountVoucherSettingMasterReport> GetBySearch(AccountVoucherSettingMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountVoucherSettingMasterReport> AccountVoucherSettingMasterReportCollection = new BaseEntityCollectionResponse<AccountVoucherSettingMasterReport>();
            try
            {
                if (_accVoucherSettingMasterDataProvider != null)
                    AccountVoucherSettingMasterReportCollection = _accVoucherSettingMasterDataProvider.GetAccountVoucherSettingMasterReportBySearch(searchRequest);
                else
                {
                    AccountVoucherSettingMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountVoucherSettingMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountVoucherSettingMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountVoucherSettingMasterReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountVoucherSettingMasterReportCollection;
        }
        /// <summary>
        /// Select a record from AccountVoucherSettingMasterReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountVoucherSettingMasterReport> SelectByID(AccountVoucherSettingMasterReport item)
        {
            IBaseEntityResponse<AccountVoucherSettingMasterReport> entityResponse = new BaseEntityResponse<AccountVoucherSettingMasterReport>();
            try
            {
                entityResponse = _accVoucherSettingMasterDataProvider.GetAccountVoucherSettingMasterReportByID(item);
            }
            catch (Exception ex)
            {
                entityResponse.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                entityResponse.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return entityResponse;
        }
    }
}
