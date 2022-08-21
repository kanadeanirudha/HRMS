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
    public class PurchaseOrderMasterAndDetailsBA : IPurchaseOrderMasterAndDetailsBA
    {
        IPurchaseOrderMasterAndDetailsDataProvider _PurchaseOrderMasterAndDetailsDataProvider;
        IPurchaseOrderMasterAndDetailsBR _PurchaseOrderMasterAndDetailsBR;
        private ILogger _logException;
        public PurchaseOrderMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PurchaseOrderMasterAndDetailsBR = new PurchaseOrderMasterAndDetailsBR();
            _PurchaseOrderMasterAndDetailsDataProvider = new PurchaseOrderMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of PurchaseOrderMasterAndDetails.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertPurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> entityResponse = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseOrderMasterAndDetailsBR.InsertPurchaseOrderMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseOrderMasterAndDetailsDataProvider.InsertPurchaseOrderMasterAndDetails(item);
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
        /// Update a specific record  of PurchaseOrderMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> UpdatePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> entityResponse = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseOrderMasterAndDetailsBR.UpdatePurchaseOrderMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseOrderMasterAndDetailsDataProvider.UpdatePurchaseOrderMasterAndDetails(item);
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
        /// Delete a selected record from PurchaseOrderMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> DeletePurchaseOrderMasterAndDetails(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> entityResponse = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseOrderMasterAndDetailsBR.DeletePurchaseOrderMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseOrderMasterAndDetailsDataProvider.DeletePurchaseOrderMasterAndDetails(item);
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
        /// Select all record from PurchaseOrderMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetBySearch(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> PurchaseOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                if (_PurchaseOrderMasterAndDetailsDataProvider != null)
                    PurchaseOrderMasterAndDetailsCollection = _PurchaseOrderMasterAndDetailsDataProvider.GetPurchaseOrderMasterAndDetailsBySearch(searchRequest);
                else
                {
                    PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseOrderMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from PurchaseOrderMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> SelectByID(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> entityResponse = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                entityResponse = _PurchaseOrderMasterAndDetailsDataProvider.GetPurchaseOrderMasterAndDetailsByID(item);
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
        /// Select a record from PurchaseOrderMasterAndDetails table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> SelectByPurchaseRequisitionMasterID(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> PurchaseOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                if (_PurchaseOrderMasterAndDetailsDataProvider != null)
                    PurchaseOrderMasterAndDetailsCollection = _PurchaseOrderMasterAndDetailsDataProvider.GetPurchaseOrderMasterAndDetailsByPurchaseRequisitionMasterID(searchRequest);
                else
                {
                    PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseOrderMasterAndDetailsCollection;
        }


        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetRecordForPurchaseOrderPDF(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> PurchaseOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                if (_PurchaseOrderMasterAndDetailsDataProvider != null)
                    PurchaseOrderMasterAndDetailsCollection = _PurchaseOrderMasterAndDetailsDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseOrderMasterAndDetailsCollection;
        }

        public IBaseEntityResponse<PurchaseOrderMasterAndDetails> InsertApprovedPurchaseOrderRecord(PurchaseOrderMasterAndDetails item)
        {
            IBaseEntityResponse<PurchaseOrderMasterAndDetails> entityResponse = new BaseEntityResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                entityResponse = _PurchaseOrderMasterAndDetailsDataProvider.InsertApprovedPurchaseOrderRecord(item);
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
        /// Select a record from PurchaseOrderMasterAndDetails table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> GetPurchaseOrderForApproval(PurchaseOrderMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseOrderMasterAndDetails> PurchaseOrderMasterAndDetailsCollection = new BaseEntityCollectionResponse<PurchaseOrderMasterAndDetails>();
            try
            {
                if (_PurchaseOrderMasterAndDetailsDataProvider != null)
                    PurchaseOrderMasterAndDetailsCollection = _PurchaseOrderMasterAndDetailsDataProvider.GetPurchaseOrderForApproval(searchRequest);
                else
                {
                    PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseOrderMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseOrderMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseOrderMasterAndDetailsCollection;
        }
    }
}
