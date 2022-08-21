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
    public class AccountCategoryMasterReportBA: IAccountCategoryMasterReportBA
    {
        IAccountCategoryMasterReportDataProvider _AccountCategoryMasterReportDataProvider;
       
        private ILogger _logException;

        public AccountCategoryMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
          
            _AccountCategoryMasterReportDataProvider = new AccountCategoryMasterReportDataProvider();
        }
        
        /// <summary>
        /// Select all record from Account Category Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetBySearch(AccountCategoryMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCategoryMasterReport> AccountCategoryMasterReportCollection = new BaseEntityCollectionResponse<AccountCategoryMasterReport>();
            try
            {
                if (_AccountCategoryMasterReportDataProvider != null)
                {
                    AccountCategoryMasterReportCollection = _AccountCategoryMasterReportDataProvider.GetAccountCategoryMasterReportBySearch(searchRequest);
                }
                else
                {
                    AccountCategoryMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCategoryMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCategoryMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountCategoryMasterReportCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCategoryMasterReportCollection;
        }


        /// <summary>
        /// Select all category names from Account Category Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountCategoryMasterReport> GetCategoryList(AccountCategoryMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountCategoryMasterReport> AccountCategoryMasterReportCollection = new BaseEntityCollectionResponse<AccountCategoryMasterReport>();
            try
            {
                if (_AccountCategoryMasterReportDataProvider != null)
                {
                    AccountCategoryMasterReportCollection = _AccountCategoryMasterReportDataProvider.GetAccountCategoryNameList(searchRequest);
                }
                else
                {
                    AccountCategoryMasterReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AccountCategoryMasterReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AccountCategoryMasterReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AccountCategoryMasterReportCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AccountCategoryMasterReportCollection;
        }

        /// <summary>
        /// Select a record from Account Category Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountCategoryMasterReport> SelectByID(AccountCategoryMasterReport item)
        {

            IBaseEntityResponse<AccountCategoryMasterReport> entityResponse = new BaseEntityResponse<AccountCategoryMasterReport>();
            try
            {
                entityResponse = _AccountCategoryMasterReportDataProvider.GetAccountCategoryMasterReportByID(item);
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
