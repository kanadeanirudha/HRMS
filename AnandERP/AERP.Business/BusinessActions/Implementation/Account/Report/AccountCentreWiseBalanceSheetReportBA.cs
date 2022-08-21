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
    public class AccountCentreWiseBalanceSheetReportBA : IAccountCentreWiseBalanceSheetReportBA
    {
        IAccountCentreWiseBalanceSheetReportDataProvider _accountCentreWiseBalanceSheetReportDataProvider;
        //     IAccountCentreWiseBalanceSheetReportBR _accountCentreWiseBalanceSheetReportBR;
        private ILogger _logException;
        public AccountCentreWiseBalanceSheetReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //   _accountCentreWiseBalanceSheetReportBR = new AccountCentreWiseBalanceSheetReportBR();
            _accountCentreWiseBalanceSheetReportDataProvider = new AccountCentreWiseBalanceSheetReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountCentreWiseBalanceSheetReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> GetBySearch(AccountCentreWiseBalanceSheetReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport> AccountCentreWiseBalanceSheetReportCollection = new BaseEntityCollectionResponse<AccountCentreWiseBalanceSheetReport>();
            try
            {
                if (_accountCentreWiseBalanceSheetReportDataProvider != null)
                    AccountCentreWiseBalanceSheetReportCollection = _accountCentreWiseBalanceSheetReportDataProvider.GetAccountCentreWiseBalanceSheetReportBySearch(searchRequest);
                else
                {
                    AccountCentreWiseBalanceSheetReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCentreWiseBalanceSheetReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCentreWiseBalanceSheetReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountCentreWiseBalanceSheetReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCentreWiseBalanceSheetReportCollection;
        }
        /// <summary>
        /// Select a record from AccountCentreWiseBalanceSheetReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCentreWiseBalanceSheetReport> SelectByID(AccountCentreWiseBalanceSheetReport item)
        {
            IBaseEntityResponse<AccountCentreWiseBalanceSheetReport> entityResponse = new BaseEntityResponse<AccountCentreWiseBalanceSheetReport>();
            try
            {
                entityResponse = _accountCentreWiseBalanceSheetReportDataProvider.GetAccountCentreWiseBalanceSheetReportByID(item);
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
