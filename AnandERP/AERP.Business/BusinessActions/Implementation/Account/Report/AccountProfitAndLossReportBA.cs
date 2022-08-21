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
    public class AccountProfitAndLossReportBA : IAccountProfitAndLossReportBA
    {
        IAccountProfitAndLossReportDataProvider _accountProfitAndLossReportDataProvider;
        //     IAccountProfitAndLossReportBR _accountProfitAndLossReportBR;
        private ILogger _logException;
        public AccountProfitAndLossReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //   _accountProfitAndLossReportBR = new AccountProfitAndLossReportBR();
            _accountProfitAndLossReportDataProvider = new AccountProfitAndLossReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountProfitAndLossReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountProfitAndLossReport> GetBySearch(AccountProfitAndLossReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountProfitAndLossReport> AccountProfitAndLossReportCollection = new BaseEntityCollectionResponse<AccountProfitAndLossReport>();
            try
            {
                if (_accountProfitAndLossReportDataProvider != null)
                    AccountProfitAndLossReportCollection = _accountProfitAndLossReportDataProvider.GetAccountProfitAndLossReportBySearch(searchRequest);
                else
                {
                    AccountProfitAndLossReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountProfitAndLossReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountProfitAndLossReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountProfitAndLossReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountProfitAndLossReportCollection;
        }
        /// <summary>
        /// Select a record from AccountProfitAndLossReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountProfitAndLossReport> SelectByID(AccountProfitAndLossReport item)
        {
            IBaseEntityResponse<AccountProfitAndLossReport> entityResponse = new BaseEntityResponse<AccountProfitAndLossReport>();
            try
            {
                entityResponse = _accountProfitAndLossReportDataProvider.GetAccountProfitAndLossReportByID(item);
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
