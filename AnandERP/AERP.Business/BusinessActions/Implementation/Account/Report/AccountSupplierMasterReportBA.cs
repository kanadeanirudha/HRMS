using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessAction
{
    public class AccountSupplierMasterReportBA : IAccountSupplierMasterReportBA
    {
        IAccountSupplierMasterReportDataProvider _accountSupplierMasterReportDataProvider;
        //     IAccountSupplierMasterReportBR _accountSupplierMasterReportBR;
        private ILogger _logException;
        public AccountSupplierMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            //   _accountSupplierMasterReportBR = new AccountSupplierMasterReportBR();
            _accountSupplierMasterReportDataProvider = new AccountSupplierMasterReportDataProvider();
        }

        /// <summary>
        /// Select all record from AccountSupplierMasterReport table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountSupplierMasterReport> GetBySearch(AccountSupplierMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountSupplierMasterReport> AccountSupplierMasterReportCollection = new BaseEntityCollectionResponse<AccountSupplierMasterReport>();
            try
            {
                if (_accountSupplierMasterReportDataProvider != null)
                    AccountSupplierMasterReportCollection = _accountSupplierMasterReportDataProvider.GetAccountSupplierMasterReportBySearch(searchRequest);
                else
                {
                    AccountSupplierMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountSupplierMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountSupplierMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AccountSupplierMasterReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountSupplierMasterReportCollection;
        }
        /// <summary>
        /// Select a record from AccountSupplierMasterReport table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountSupplierMasterReport> SelectByID(AccountSupplierMasterReport item)
        {
            IBaseEntityResponse<AccountSupplierMasterReport> entityResponse = new BaseEntityResponse<AccountSupplierMasterReport>();
            try
            {
                entityResponse = _accountSupplierMasterReportDataProvider.GetAccountSupplierMasterReportByID(item);
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
