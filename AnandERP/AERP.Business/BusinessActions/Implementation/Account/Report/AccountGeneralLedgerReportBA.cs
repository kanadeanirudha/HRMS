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
    public class AccountGeneralLedgerReportBA : IAccountGeneralLedgerReportBA
    {
        IAccountGeneralLedgerReportDataProvider _accountGeneralLedgerReportDataProvider;
      //  IAccountGeneralLedgerReportBR _accountGeneralLedgerReportBR;
        private ILogger _logException;
        public AccountGeneralLedgerReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
        //    _accountGeneralLedgerReportBR = new AccountGeneralLedgerReportBR();
            _accountGeneralLedgerReportDataProvider = new AccountGeneralLedgerReportDataProvider();
        }
       
        /// <summary>
        /// Select all record from AccountGeneralLedgerReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetBySearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> AccountGeneralLedgerReportCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
            try
            {
                if (_accountGeneralLedgerReportDataProvider != null)
                    AccountGeneralLedgerReportCollection = _accountGeneralLedgerReportDataProvider.GetAccountGeneralLedgerReportBySearch(searchRequest);
                else
                {
                    AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGeneralLedgerReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountGeneralLedgerReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGeneralLedgerReportCollection;
        }

        /// <summary>
        /// Select all record from AccountGeneralLedgerReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetOtherLedgerBySearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> AccountGeneralLedgerReportCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
            try
            {
                if (_accountGeneralLedgerReportDataProvider != null)
                    AccountGeneralLedgerReportCollection = _accountGeneralLedgerReportDataProvider.GetOtherLedgerBySearch(searchRequest);
                else
                {
                    AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGeneralLedgerReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountGeneralLedgerReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGeneralLedgerReportCollection;
        }
        /// <summary>
        /// Select a record from AccountGeneralLedgerReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountGeneralLedgerReport> SelectByID(AccountGeneralLedgerReport item)
        {
            IBaseEntityResponse<AccountGeneralLedgerReport> entityResponse = new BaseEntityResponse<AccountGeneralLedgerReport>();
            try
            {
                entityResponse = _accountGeneralLedgerReportDataProvider.GetAccountGeneralLedgerReportByID(item);
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


        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetPersonNameListByPersonTypeAndAccountId(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> AccountGeneralLedgerReportCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
            try
            {
                if (_accountGeneralLedgerReportDataProvider != null)
                    AccountGeneralLedgerReportCollection = _accountGeneralLedgerReportDataProvider.GetPersonNameListByPersonTypeAndAccountId(searchRequest);
                else
                {
                    AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGeneralLedgerReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountGeneralLedgerReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGeneralLedgerReportCollection;
        }



        public IBaseEntityCollectionResponse<AccountGeneralLedgerReport> GetByIndividualBalanceReportSearch(AccountGeneralLedgerReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountGeneralLedgerReport> AccountGeneralLedgerReportCollection = new BaseEntityCollectionResponse<AccountGeneralLedgerReport>();
            try
            {
                if (_accountGeneralLedgerReportDataProvider != null)
                    AccountGeneralLedgerReportCollection = _accountGeneralLedgerReportDataProvider.GetByIndividualBalanceReportSearch(searchRequest);
                else
                {
                    AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountGeneralLedgerReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountGeneralLedgerReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountGeneralLedgerReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountGeneralLedgerReportCollection;
        }
    }
}
