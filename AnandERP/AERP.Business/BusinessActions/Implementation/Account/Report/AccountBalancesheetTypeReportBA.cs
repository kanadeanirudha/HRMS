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
    public class AccountBalancesheetTypeReportBA: IAccountBalancesheetTypeReportBA
    {
        IAccountBalancesheetTypeReportDataProvider _accountBalancesheetTypeReportDataProvider;
        //IAccountBalancesheetTypeReportBR _accountBalancesheetTypeReportBR;
        private ILogger _logException;

        public AccountBalancesheetTypeReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //_accountBalancesheetTypeReportBR = new AccountBalancesheetTypeReportBR();
            _accountBalancesheetTypeReportDataProvider = new AccountBalancesheetTypeReportDataProvider();
        }

        /// <summary>
        /// Select all record from Account Balance Sheet Type Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> GetBySearch(AccountBalancesheetTypeReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountBalancesheetTypeReport> AccountBalancesheetTypeReportCollection = new BaseEntityCollectionResponse<AccountBalancesheetTypeReport>();
            try
            {
                if (_accountBalancesheetTypeReportDataProvider != null)
                {
                    AccountBalancesheetTypeReportCollection = _accountBalancesheetTypeReportDataProvider.GetAccountBalancesheetTypeReportBySearch(searchRequest);
                }
                else
                {
                    AccountBalancesheetTypeReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountBalancesheetTypeReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountBalancesheetTypeReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountBalancesheetTypeReportCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountBalancesheetTypeReportCollection;
        }

    }
}
