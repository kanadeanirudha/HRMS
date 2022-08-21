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
    public class SaleContractPayementBA : ISaleContractPayementBA
    {
        ISaleContractPayementDataProvider _SaleContractPayementDataProvider;
        ISaleContractPayementBR _SaleContractPayementBR;
        private ILogger _logException;
        public SaleContractPayementBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SaleContractPayementBR = new SaleContractPayementBR();
            _SaleContractPayementDataProvider = new SaleContractPayementDataProvider();
        }
        /// <summary>
        /// Create new record of SaleContractPayement.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractPayement> InsertSaleContractPayement(SaleContractPayement item)
        {
            IBaseEntityResponse<SaleContractPayement> entityResponse = new BaseEntityResponse<SaleContractPayement>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractPayementBR.InsertSaleContractPayementValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractPayementDataProvider.InsertSaleContractPayement(item);
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
        /// Update a specific record  of SaleContractPayement.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractPayement> UpdateSaleContractPayement(SaleContractPayement item)
        {
            IBaseEntityResponse<SaleContractPayement> entityResponse = new BaseEntityResponse<SaleContractPayement>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractPayementBR.UpdateSaleContractPayementValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractPayementDataProvider.UpdateSaleContractPayement(item);
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
        /// Delete a selected record from SaleContractPayement.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractPayement> DeleteSaleContractPayement(SaleContractPayement item)
        {
            IBaseEntityResponse<SaleContractPayement> entityResponse = new BaseEntityResponse<SaleContractPayement>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SaleContractPayementBR.DeleteSaleContractPayementValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SaleContractPayementDataProvider.DeleteSaleContractPayement(item);
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
        /// Select all record from SaleContractPayement table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SaleContractPayement> GetBySearch(SaleContractPayementSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractPayement> SaleContractPayementCollection = new BaseEntityCollectionResponse<SaleContractPayement>();
            try
            {
                if (_SaleContractPayementDataProvider != null)
                    SaleContractPayementCollection = _SaleContractPayementDataProvider.GetSaleContractPayementBySearch(searchRequest);
                else
                {
                    SaleContractPayementCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractPayementCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractPayementCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractPayementCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractPayementCollection;
        }
        /// <summary>
        /// Select a record from SaleContractPayement table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SaleContractPayement> SelectByID(SaleContractPayement item)
        {
            IBaseEntityResponse<SaleContractPayement> entityResponse = new BaseEntityResponse<SaleContractPayement>();
            try
            {
                entityResponse = _SaleContractPayementDataProvider.GetSaleContractPayementByID(item);
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
        /// Select a record from SaleContractPayement table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SaleContractPayement> GetSaleContractEmployeeByBillingSpanForPayement(SaleContractPayementSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractPayement> SaleContractPayementCollection = new BaseEntityCollectionResponse<SaleContractPayement>();
            try
            {
                if (_SaleContractPayementDataProvider != null)
                    SaleContractPayementCollection = _SaleContractPayementDataProvider.GetSaleContractEmployeeByBillingSpanForPayement(searchRequest);
                else
                {
                    SaleContractPayementCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractPayementCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractPayementCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractPayementCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractPayementCollection;
        }


        public IBaseEntityCollectionResponse<SaleContractPayement> GetRecordForPurchaseOrderPDF(SaleContractPayementSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SaleContractPayement> SaleContractPayementCollection = new BaseEntityCollectionResponse<SaleContractPayement>();
            try
            {
                if (_SaleContractPayementDataProvider != null)
                    SaleContractPayementCollection = _SaleContractPayementDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    SaleContractPayementCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SaleContractPayementCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SaleContractPayementCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SaleContractPayementCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SaleContractPayementCollection;
        }
    }
}
