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
    public class PurchaseInvoiceBA : IPurchaseInvoiceBA
    {
        IPurchaseInvoiceDataProvider _PurchaseInvoiceDataProvider;
        IPurchaseInvoiceBR _PurchaseInvoiceBR;
        private ILogger _logException;
        public PurchaseInvoiceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PurchaseInvoiceBR = new PurchaseInvoiceBR();
            _PurchaseInvoiceDataProvider = new PurchaseInvoiceDataProvider();
        }
        /// <summary>
        /// Create new record of PurchaseInvoice.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseInvoice> InsertPurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> entityResponse = new BaseEntityResponse<PurchaseInvoice>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseInvoiceBR.InsertPurchaseInvoiceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseInvoiceDataProvider.InsertPurchaseInvoice(item);
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
        /// Update a specific record  of PurchaseInvoice.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseInvoice> UpdatePurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> entityResponse = new BaseEntityResponse<PurchaseInvoice>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseInvoiceBR.UpdatePurchaseInvoiceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseInvoiceDataProvider.UpdatePurchaseInvoice(item);
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
        /// Delete a selected record from PurchaseInvoice.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseInvoice> DeletePurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> entityResponse = new BaseEntityResponse<PurchaseInvoice>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseInvoiceBR.DeletePurchaseInvoiceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseInvoiceDataProvider.DeletePurchaseInvoice(item);
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
        /// Select all record from PurchaseInvoice table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseInvoice> GetBySearch(PurchaseInvoiceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseInvoice> PurchaseInvoiceCollection = new BaseEntityCollectionResponse<PurchaseInvoice>();
            try
            {
                if (_PurchaseInvoiceDataProvider != null)
                    PurchaseInvoiceCollection = _PurchaseInvoiceDataProvider.GetPurchaseInvoiceBySearch(searchRequest);
                else
                {
                    PurchaseInvoiceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseInvoiceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseInvoiceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseInvoiceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseInvoiceCollection;
        }
        /// <summary>
        /// Select a record from PurchaseInvoice table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseInvoice> SelectByID(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> entityResponse = new BaseEntityResponse<PurchaseInvoice>();
            try
            {
                entityResponse = _PurchaseInvoiceDataProvider.GetPurchaseInvoiceByID(item);
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
        /// Select a record from PurchaseInvoice table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseInvoice> SelectByPurchaseGRNMasterID(PurchaseInvoiceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseInvoice> PurchaseInvoiceCollection = new BaseEntityCollectionResponse<PurchaseInvoice>();
            try
            {
                if (_PurchaseInvoiceDataProvider != null)
                    PurchaseInvoiceCollection = _PurchaseInvoiceDataProvider.GetPurchaseInvoiceByPurchaseGRNMasterID(searchRequest);
                else
                {
                    PurchaseInvoiceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseInvoiceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseInvoiceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseInvoiceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseInvoiceCollection;
        }


        public IBaseEntityCollectionResponse<PurchaseInvoice> GetRecordForPurchaseOrderPDF(PurchaseInvoiceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseInvoice> PurchaseInvoiceCollection = new BaseEntityCollectionResponse<PurchaseInvoice>();
            try
            {
                if (_PurchaseInvoiceDataProvider != null)
                    PurchaseInvoiceCollection = _PurchaseInvoiceDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    PurchaseInvoiceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseInvoiceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseInvoiceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseInvoiceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseInvoiceCollection;
        }
        public IBaseEntityResponse<PurchaseInvoice> InsertManualPurchaseInvoice(PurchaseInvoice item)
        {
            IBaseEntityResponse<PurchaseInvoice> entityResponse = new BaseEntityResponse<PurchaseInvoice>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseInvoiceBR.InsertPurchaseInvoiceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseInvoiceDataProvider.InsertManualPurchaseInvoice(item);
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
    }
}
