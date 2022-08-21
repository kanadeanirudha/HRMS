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
    public class PurchaseReplenishmentBA : IPurchaseReplenishmentBA
    {
        IPurchaseReplenishmentDataProvider _PurchaseReplenishmentDataProvider;
        IPurchaseReplenishmentBR _PurchaseReplenishmentBR;
        private ILogger _logException;
        public PurchaseReplenishmentBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PurchaseReplenishmentBR = new PurchaseReplenishmentBR();
            _PurchaseReplenishmentDataProvider = new PurchaseReplenishmentDataProvider();
        }
        /// <summary>
        /// Create new record of PurchaseReplenishment.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReplenishment> InsertPurchaseReplenishment(PurchaseReplenishment item)
        {
            IBaseEntityResponse<PurchaseReplenishment> entityResponse = new BaseEntityResponse<PurchaseReplenishment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReplenishmentBR.InsertPurchaseReplenishmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReplenishmentDataProvider.InsertPurchaseReplenishment(item);
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
        /// Update a specific record  of PurchaseReplenishment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReplenishment> UpdatePurchaseReplenishment(PurchaseReplenishment item)
        {
            IBaseEntityResponse<PurchaseReplenishment> entityResponse = new BaseEntityResponse<PurchaseReplenishment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReplenishmentBR.UpdatePurchaseReplenishmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReplenishmentDataProvider.UpdatePurchaseReplenishment(item);
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
        /// Delete a selected record from PurchaseReplenishment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReplenishment> DeletePurchaseReplenishment(PurchaseReplenishment item)
        {
            IBaseEntityResponse<PurchaseReplenishment> entityResponse = new BaseEntityResponse<PurchaseReplenishment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseReplenishmentBR.DeletePurchaseReplenishmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseReplenishmentDataProvider.DeletePurchaseReplenishment(item);
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
        /// Select all record from PurchaseReplenishment table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseReplenishment> GetBySearch(PurchaseReplenishmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReplenishment> PurchaseReplenishmentCollection = new BaseEntityCollectionResponse<PurchaseReplenishment>();
            try
            {
                if (_PurchaseReplenishmentDataProvider != null)
                    PurchaseReplenishmentCollection = _PurchaseReplenishmentDataProvider.GetPurchaseReplenishmentBySearch(searchRequest);
                else
                {
                    PurchaseReplenishmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReplenishmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReplenishmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReplenishmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReplenishmentCollection;
        }
        /// <summary>
        /// Select a record from PurchaseReplenishment table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseReplenishment> SelectByID(PurchaseReplenishment item)
        {
            IBaseEntityResponse<PurchaseReplenishment> entityResponse = new BaseEntityResponse<PurchaseReplenishment>();
            try
            {
                entityResponse = _PurchaseReplenishmentDataProvider.GetPurchaseReplenishmentByID(item);
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
        /// Select a record from PurchaseReplenishment table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseReplenishment> SelectByPurchaseGRNMasterID(PurchaseReplenishmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReplenishment> PurchaseReplenishmentCollection = new BaseEntityCollectionResponse<PurchaseReplenishment>();
            try
            {
                if (_PurchaseReplenishmentDataProvider != null)
                    PurchaseReplenishmentCollection = _PurchaseReplenishmentDataProvider.GetPurchaseReplenishmentByPurchaseGRNMasterID(searchRequest);
                else
                {
                    PurchaseReplenishmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReplenishmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReplenishmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReplenishmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReplenishmentCollection;
        }


        public IBaseEntityCollectionResponse<PurchaseReplenishment> GetRecordForPurchaseOrderPDF(PurchaseReplenishmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseReplenishment> PurchaseReplenishmentCollection = new BaseEntityCollectionResponse<PurchaseReplenishment>();
            try
            {
                if (_PurchaseReplenishmentDataProvider != null)
                    PurchaseReplenishmentCollection = _PurchaseReplenishmentDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    PurchaseReplenishmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseReplenishmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseReplenishmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseReplenishmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseReplenishmentCollection;
        }
    }
}
