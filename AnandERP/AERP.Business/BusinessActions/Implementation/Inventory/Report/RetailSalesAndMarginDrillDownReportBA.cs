
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
    public class RetailSalesAndMarginDrillDownReportBA : IRetailSalesAndMarginDrillDownReportBA
    {
        IRetailSalesAndMarginDrillDownReportDataProvider _RetailSalesAndMarginDrillDownReportDataProvider;
        private ILogger _logException;
        public RetailSalesAndMarginDrillDownReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _RetailSalesAndMarginDrillDownReportDataProvider = new RetailSalesAndMarginDrillDownReportDataProvider();
        }

        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> GetRetailSalesAndMarginDrillDownReportBySearch(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.GetRetailSalesAndMarginDrillDownReportBySearch(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }

        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_GroupDescriptionList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseDepartmentList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseCategoryList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseSubCategoryList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_MerchantiseBaseCategoryList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }
        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_ItemDescriptionList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }

        public IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportBySearch_StoreList(RetailSalesAndMarginDrillDownReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport> RetailSalesAndMarginDrillDownReportCollection = new BaseEntityCollectionResponse<RetailSalesAndMarginDrillDownReport>();
            try
            {
                if (_RetailSalesAndMarginDrillDownReportDataProvider != null)
                    RetailSalesAndMarginDrillDownReportCollection = _RetailSalesAndMarginDrillDownReportDataProvider.RetailSalesAndMarginDrillDownReportBySearch_StoreList(searchRequest);
                else
                {
                    RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                RetailSalesAndMarginDrillDownReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                RetailSalesAndMarginDrillDownReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return RetailSalesAndMarginDrillDownReportCollection;
        }


    }
}

