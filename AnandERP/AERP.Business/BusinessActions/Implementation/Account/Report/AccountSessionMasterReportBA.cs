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
    public class AccountSessionMasterReportBA : IAccountSessionMasterReportBA
    {
        IAccountSessionMasterReportDataProvider _accountSessionMasterReportDataProvider;
   //     IAccountSessionMasterReportBR _accountSessionMasterReportBR;
        private ILogger _logException;
        public AccountSessionMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
         //   _accountSessionMasterReportBR = new AccountSessionMasterReportBR();
            _accountSessionMasterReportDataProvider = new AccountSessionMasterReportDataProvider();
        }
       
        /// <summary>
        /// Select all record from AccountSessionMasterReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountSessionMasterReport> GetBySearch(AccountSessionMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountSessionMasterReport> AccountSessionMasterReportCollection = new BaseEntityCollectionResponse<AccountSessionMasterReport>();
            try
            {
                if (_accountSessionMasterReportDataProvider != null)
                    AccountSessionMasterReportCollection = _accountSessionMasterReportDataProvider.GetAccountSessionMasterReportBySearch(searchRequest);
                else
                {
                    AccountSessionMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountSessionMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountSessionMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountSessionMasterReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountSessionMasterReportCollection;
        }
        /// <summary>
        /// Select a record from AccountSessionMasterReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountSessionMasterReport> SelectByID(AccountSessionMasterReport item)
        {
            IBaseEntityResponse<AccountSessionMasterReport> entityResponse = new BaseEntityResponse<AccountSessionMasterReport>();
            try
            {
                entityResponse = _accountSessionMasterReportDataProvider.GetAccountSessionMasterReportByID(item);
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
