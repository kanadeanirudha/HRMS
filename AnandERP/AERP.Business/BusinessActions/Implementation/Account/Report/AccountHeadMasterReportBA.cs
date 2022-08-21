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
    public class AccountHeadMasterReportBA: IAccountHeadMasterReportBA
    {
        IAccountHeadMasterReportDataProvider _AccountHeadMasterReportDataProvider;
        IAccountHeadMasterReportBR _AccountHeadMasterReportBR;
        private ILogger _logException;

        public AccountHeadMasterReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _AccountHeadMasterReportBR = new AccountHeadMasterReportBR();
            _AccountHeadMasterReportDataProvider = new AccountHeadMasterReportDataProvider();
        }

        /// <summary>
        /// Create new record of Account Head Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> InsertAccountHeadMasterReport(AccountHeadMasterReport item)
        {
            IBaseEntityResponse<AccountHeadMasterReport> entityResponse = new BaseEntityResponse<AccountHeadMasterReport>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountHeadMasterReportBR.InsertAccountHeadMasterReportValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountHeadMasterReportDataProvider.InsertAccountHeadMasterReport(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        /// <summary>
        /// Update a specific record of Account Head Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> UpdateAccountHeadMasterReport(AccountHeadMasterReport item)
        {
            IBaseEntityResponse<AccountHeadMasterReport> entityResponse = new BaseEntityResponse<AccountHeadMasterReport>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountHeadMasterReportBR.UpdateAccountHeadMasterReportValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountHeadMasterReportDataProvider.UpdateAccountHeadMasterReport(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        /// <summary>
        /// Delete a selected record from Account Head Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> DeleteAccountHeadMasterReport(AccountHeadMasterReport item)
        {
            IBaseEntityResponse<AccountHeadMasterReport> entityResponse = new BaseEntityResponse<AccountHeadMasterReport>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AccountHeadMasterReportBR.DeleteAccountHeadMasterReportValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AccountHeadMasterReportDataProvider.DeleteAccountHeadMasterReport(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
                }
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

        /// <summary>
        /// Select all record from Account Head Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMasterReport> GetAccountHeadMasterReportBySearch(AccountHeadMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountHeadMasterReport> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<AccountHeadMasterReport>();
            try
            {
                if (_AccountHeadMasterReportDataProvider != null)
                {
                    AdminMenuApplicableCollection = _AccountHeadMasterReportDataProvider.GetAccountHeadMasterReportBySearch(searchRequest);
                }
                else
                {
                    AdminMenuApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminMenuApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminMenuApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminMenuApplicableCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminMenuApplicableCollection;
        }

        /// <summary>
        /// Select all record from Account Head Master table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AccountHeadMasterReport> GetAccountHeadNameList(AccountHeadMasterReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AccountHeadMasterReport> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<AccountHeadMasterReport>();
            try
            {
                if (_AccountHeadMasterReportDataProvider != null)
                {
                    AdminMenuApplicableCollection = _AccountHeadMasterReportDataProvider.GetAccountHeadNameList(searchRequest);
                }
                else
                {
                    AdminMenuApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminMenuApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminMenuApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminMenuApplicableCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminMenuApplicableCollection;
        }

        /// <summary>
        /// Select a record from Account Head Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AccountHeadMasterReport> GetAccountHeadMasterReportByID(AccountHeadMasterReport item)
        {

            IBaseEntityResponse<AccountHeadMasterReport> entityResponse = new BaseEntityResponse<AccountHeadMasterReport>();
            try
            {
                entityResponse = _AccountHeadMasterReportDataProvider.GetAccountHeadMasterReportByID(item);
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
