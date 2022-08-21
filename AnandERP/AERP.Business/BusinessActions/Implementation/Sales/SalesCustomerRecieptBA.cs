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
    public class SalesCustomerRecieptBA : ISalesCustomerRecieptBA
    {
        ISalesCustomerRecieptDataProvider _SalesCustomerRecieptDataProvider;
        ISalesCustomerRecieptBR _SalesCustomerRecieptBR;
        private ILogger _logException;
        public SalesCustomerRecieptBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalesCustomerRecieptBR = new SalesCustomerRecieptBR();
            _SalesCustomerRecieptDataProvider = new SalesCustomerRecieptDataProvider();
        }
        /// <summary>
        /// Create new record of SalesCustomerReciept.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesCustomerReciept> InsertSalesCustomerReciept(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> entityResponse = new BaseEntityResponse<SalesCustomerReciept>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesCustomerRecieptBR.InsertSalesCustomerRecieptValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesCustomerRecieptDataProvider.InsertSalesCustomerReciept(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// Update a specific record  of SalesCustomerReciept.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesCustomerReciept> UpdateSalesCustomerReciept(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> entityResponse = new BaseEntityResponse<SalesCustomerReciept>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesCustomerRecieptBR.UpdateSalesCustomerRecieptValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesCustomerRecieptDataProvider.UpdateSalesCustomerReciept(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// Delete a selected record from SalesCustomerReciept.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesCustomerReciept> DeleteSalesCustomerReciept(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> entityResponse = new BaseEntityResponse<SalesCustomerReciept>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalesCustomerRecieptBR.DeleteSalesCustomerRecieptValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalesCustomerRecieptDataProvider.DeleteSalesCustomerReciept(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null; ;
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
        /// Select all record from SalesCustomerReciept table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesCustomerReciept> GetBySearch(SalesCustomerRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesCustomerReciept> SalesCustomerRecieptCollection = new BaseEntityCollectionResponse<SalesCustomerReciept>();
            try
            {
                if (_SalesCustomerRecieptDataProvider != null)
                    SalesCustomerRecieptCollection = _SalesCustomerRecieptDataProvider.GetSalesCustomerRecieptBySearch(searchRequest);
                else
                {
                    SalesCustomerRecieptCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesCustomerRecieptCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesCustomerRecieptCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesCustomerRecieptCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesCustomerRecieptCollection;
        }
        /// <summary>
        /// Select a record from SalesCustomerReciept table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalesCustomerReciept> SelectByID(SalesCustomerReciept item)
        {
            IBaseEntityResponse<SalesCustomerReciept> entityResponse = new BaseEntityResponse<SalesCustomerReciept>();
            try
            {
                entityResponse = _SalesCustomerRecieptDataProvider.GetSalesCustomerRecieptByID(item);
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
        /// Select a record from SalesCustomerReciept table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalesCustomerReciept> GetCustomerWiseInvoiceDetailsForCustomerRecieptList(SalesCustomerRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesCustomerReciept> SalesCustomerRecieptCollection = new BaseEntityCollectionResponse<SalesCustomerReciept>();
            try
            {
                if (_SalesCustomerRecieptDataProvider != null)
                    SalesCustomerRecieptCollection = _SalesCustomerRecieptDataProvider.GetCustomerWiseInvoiceDetailsForCustomerRecieptList(searchRequest);
                else
                {
                    SalesCustomerRecieptCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesCustomerRecieptCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesCustomerRecieptCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesCustomerRecieptCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesCustomerRecieptCollection;
        }


        public IBaseEntityCollectionResponse<SalesCustomerReciept> GetRecordForPurchaseOrderPDF(SalesCustomerRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalesCustomerReciept> SalesCustomerRecieptCollection = new BaseEntityCollectionResponse<SalesCustomerReciept>();
            try
            {
                if (_SalesCustomerRecieptDataProvider != null)
                    SalesCustomerRecieptCollection = _SalesCustomerRecieptDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    SalesCustomerRecieptCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalesCustomerRecieptCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalesCustomerRecieptCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalesCustomerRecieptCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalesCustomerRecieptCollection;
        }
    }
}
