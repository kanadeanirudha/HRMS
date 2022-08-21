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
    public class AccountDayBookReportBA : IAccountDayBookReportBA
    {
      IAccountDayBookReportDataProvider   _accountDayBookReportDataProvider;
     // IAccountDayBookReportBR _accountDayBookReportBR;
        private ILogger _logException;
        public AccountDayBookReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
           // _accountDayBookReportBR = new AccountDayBookReportBR();
            _accountDayBookReportDataProvider = new AccountDayBookReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountDayBookReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountDayBookReport> GetBySearch(AccountDayBookReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountDayBookReport> AccountDayBookReportCollection = new BaseEntityCollectionResponse<AccountDayBookReport>();
            try
            {
                if (_accountDayBookReportDataProvider != null)
                    AccountDayBookReportCollection = _accountDayBookReportDataProvider.GetAccountDayBookReportBySearch(searchRequest);
                else
                {
                    AccountDayBookReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountDayBookReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountDayBookReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountDayBookReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountDayBookReportCollection;
        }
    }
}
