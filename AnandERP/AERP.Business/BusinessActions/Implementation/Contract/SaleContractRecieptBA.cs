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
    public class SaleContractRecieptBA : ISaleContractRecieptBA
    {
        ISaleContractRecieptDataProvider _SaleContractRecieptDataProvider;
        ISaleContractRecieptBR _SaleContractRecieptBR;
        private ILogger _logException;
        public SaleContractRecieptBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractRecieptBR = new SaleContractRecieptBR();
            _SaleContractRecieptDataProvider = new SaleContractRecieptDataProvider();
        }
        /// <summary>
        /// Create new record of SaleContractReciept.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractReciept> InsertSaleContractReciept(SaleContractReciept item)
        {
            IBaseEntityResponse<SaleContractReciept> entityResponse = new BaseEntityResponse<SaleContractReciept>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractRecieptBR.InsertSaleContractRecieptValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractRecieptDataProvider.InsertSaleContractReciept(item);
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
        /// Update a specific record  of SaleContractReciept.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractReciept> UpdateSaleContractReciept(SaleContractReciept item)
        {
            IBaseEntityResponse<SaleContractReciept> entityResponse = new BaseEntityResponse<SaleContractReciept>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractRecieptBR.UpdateSaleContractRecieptValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractRecieptDataProvider.UpdateSaleContractReciept(item);
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
        /// Delete a selected record from SaleContractReciept.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractReciept> DeleteSaleContractReciept(SaleContractReciept item)
        {
            IBaseEntityResponse<SaleContractReciept> entityResponse = new BaseEntityResponse<SaleContractReciept>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractRecieptBR.DeleteSaleContractRecieptValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractRecieptDataProvider.DeleteSaleContractReciept(item);
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
        /// Select all record from SaleContractReciept table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SaleContractReciept> GetBySearch(SaleContractRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractReciept> SaleContractRecieptCollection = new BaseEntityCollectionResponse<SaleContractReciept>();
            try
            {
                if (_SaleContractRecieptDataProvider != null)
                    SaleContractRecieptCollection = _SaleContractRecieptDataProvider.GetSaleContractRecieptBySearch(searchRequest);
                else
                {
                    SaleContractRecieptCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractRecieptCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractRecieptCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractRecieptCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractRecieptCollection;
        }
        /// <summary>
        /// Select a record from SaleContractReciept table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractReciept> SelectByID(SaleContractReciept item)
        {
            IBaseEntityResponse<SaleContractReciept> entityResponse = new BaseEntityResponse<SaleContractReciept>();
            try
            {
                entityResponse = _SaleContractRecieptDataProvider.GetSaleContractRecieptByID(item);
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
        /// Select a record from SaleContractReciept table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SaleContractReciept> GetCustomerWiseContractDetailsForReciept(SaleContractRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractReciept> SaleContractRecieptCollection = new BaseEntityCollectionResponse<SaleContractReciept>();
            try
            {
                if (_SaleContractRecieptDataProvider != null)
                    SaleContractRecieptCollection = _SaleContractRecieptDataProvider.GetCustomerWiseContractDetailsForReciept(searchRequest);
                else
                {
                    SaleContractRecieptCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractRecieptCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractRecieptCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractRecieptCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractRecieptCollection;
        }


        public IBaseEntityCollectionResponse<SaleContractReciept> GetRecordForPurchaseOrderPDF(SaleContractRecieptSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractReciept> SaleContractRecieptCollection = new BaseEntityCollectionResponse<SaleContractReciept>();
            try
            {
                if (_SaleContractRecieptDataProvider != null)
                    SaleContractRecieptCollection = _SaleContractRecieptDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    SaleContractRecieptCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractRecieptCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractRecieptCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractRecieptCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractRecieptCollection;
        }
    }
}
