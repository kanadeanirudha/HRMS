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
    public class AccountTrialBalanceReportBA : IAccountTrialBalanceReportBA
    {
        IAccountTrialBalanceReportDataProvider _accountTrialBalanceReportDataProvider;
        //     IAccountTrialBalanceReportBR _accountTrialBalanceReportBR;
        private ILogger _logException;
        public AccountTrialBalanceReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //   _accountTrialBalanceReportBR = new AccountTrialBalanceReportBR();
            _accountTrialBalanceReportDataProvider = new AccountTrialBalanceReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountTrialBalanceReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountTrialBalanceReport> GetBySearch(AccountTrialBalanceReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountTrialBalanceReport> AccountTrialBalanceReportCollection = new BaseEntityCollectionResponse<AccountTrialBalanceReport>();
            try
            {
                if (_accountTrialBalanceReportDataProvider != null)
                    AccountTrialBalanceReportCollection = _accountTrialBalanceReportDataProvider.GetAccountTrialBalanceReportBySearch(searchRequest);
                else
                {
                    AccountTrialBalanceReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountTrialBalanceReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountTrialBalanceReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountTrialBalanceReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountTrialBalanceReportCollection;
        }
        /// <summary>
        /// Select a record from AccountTrialBalanceReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountTrialBalanceReport> SelectByID(AccountTrialBalanceReport item)
        {
            IBaseEntityResponse<AccountTrialBalanceReport> entityResponse = new BaseEntityResponse<AccountTrialBalanceReport>();
            try
            {
                entityResponse = _accountTrialBalanceReportDataProvider.GetAccountTrialBalanceReportByID(item);
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
