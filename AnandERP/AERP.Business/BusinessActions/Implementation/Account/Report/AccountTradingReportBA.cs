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
    public class AccountTradingReportBA : IAccountTradingReportBA
    {
        IAccountTradingReportDataProvider _AccountTradingReportDataProvider;
        //     IAccountTradingReportBR _AccountTradingReportBR;
        private ILogger _logException;
        public AccountTradingReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //   _AccountTradingReportBR = new AccountTradingReportBR();
            _AccountTradingReportDataProvider = new AccountTradingReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountTradingReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTradingReport> GetBySearch(AccountTradingReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTradingReport> AccountTradingReportCollection = new BaseEntityCollectionResponse<AccountTradingReport>();
            try
            {
                if (_AccountTradingReportDataProvider != null)
                    AccountTradingReportCollection = _AccountTradingReportDataProvider.GetAccountTradingReportBySearch(searchRequest);
                else
                {
                    AccountTradingReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTradingReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTradingReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTradingReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTradingReportCollection;
        }
        /// <summary>
        /// Select a record from AccountTradingReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTradingReport> SelectByID(AccountTradingReport item)
        {
            IBaseEntityResponse<AccountTradingReport> entityResponse = new BaseEntityResponse<AccountTradingReport>();
            try
            {
                entityResponse = _AccountTradingReportDataProvider.GetAccountTradingReportByID(item);
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
