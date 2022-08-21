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

namespace AMS.Business.BusinessActions
{
    public class RetailDrillDownReportBA : IRetailDrillDownReportBA
    {
        IRetailDrillDownReportDataProvider _RetailDrillDownReportDataProvider;
        private ILogger _logException;
        public RetailDrillDownReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RetailDrillDownReportDataProvider = new RetailDrillDownReportDataProvider();
        }

        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetGroupDescriptionReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetGroupDescriptionReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }
        //Item Master Missing Exaception Report
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseDepartmentReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetMerchantiseDepartmentReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }
       
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetMerchantiseCategoryReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }
        
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseSubCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetMerchantiseSubCategoryReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }
        
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetMerchantiseBaseCategoryReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetMerchantiseBaseCategoryReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }
        
        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetItemDescriptionReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetItemDescriptionReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }

        public IBaseEntityCollectionResponse<RetailDrillDownReport> GetStoresReportBySearch(RetailDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailDrillDownReport> RetailDrillDownReportCollection = new BaseEntityCollectionResponse<RetailDrillDownReport>();
            try
            {
                if (_RetailDrillDownReportDataProvider != null)
                    RetailDrillDownReportCollection = _RetailDrillDownReportDataProvider.GetStoresReportBySearch(searchRequest);
                else
                {
                    RetailDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailDrillDownReportCollection;
        }
    }
}
