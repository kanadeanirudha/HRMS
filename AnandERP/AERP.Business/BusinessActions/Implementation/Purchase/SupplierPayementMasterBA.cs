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
    public class SupplierPayementMasterBA : ISupplierPayementMasterBA
    {
        ISupplierPayementMasterDataProvider _SupplierPayementMasterDataProvider;
        ISupplierPayementMasterBR _SupplierPayementMasterBR;
        private ILogger _logException;
        public SupplierPayementMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SupplierPayementMasterBR = new SupplierPayementMasterBR();
            _SupplierPayementMasterDataProvider = new SupplierPayementMasterDataProvider();
        }
        /// <summary>
        /// Create new record of SupplierPayementMaster.s
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SupplierPayementMaster> InsertSupplierPayementMaster(SupplierPayementMaster item)
        {
            IBaseEntityResponse<SupplierPayementMaster> entityResponse = new BaseEntityResponse<SupplierPayementMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SupplierPayementMasterBR.InsertSupplierPayementMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SupplierPayementMasterDataProvider.InsertSupplierPayementMaster(item);
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
        /// Update a specific record  of SupplierPayementMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SupplierPayementMaster> UpdateSupplierPayementMaster(SupplierPayementMaster item)
        {
            IBaseEntityResponse<SupplierPayementMaster> entityResponse = new BaseEntityResponse<SupplierPayementMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SupplierPayementMasterBR.UpdateSupplierPayementMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SupplierPayementMasterDataProvider.UpdateSupplierPayementMaster(item);
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
        /// Delete a selected record from SupplierPayementMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SupplierPayementMaster> DeleteSupplierPayementMaster(SupplierPayementMaster item)
        {
            IBaseEntityResponse<SupplierPayementMaster> entityResponse = new BaseEntityResponse<SupplierPayementMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SupplierPayementMasterBR.DeleteSupplierPayementMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SupplierPayementMasterDataProvider.DeleteSupplierPayementMaster(item);
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
        /// Select all record from SupplierPayementMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SupplierPayementMaster> GetBySearch(SupplierPayementMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SupplierPayementMaster> SupplierPayementMasterCollection = new BaseEntityCollectionResponse<SupplierPayementMaster>();
            try
            {
                if (_SupplierPayementMasterDataProvider != null)
                    SupplierPayementMasterCollection = _SupplierPayementMasterDataProvider.GetSupplierPayementMasterBySearch(searchRequest);
                else
                {
                    SupplierPayementMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SupplierPayementMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SupplierPayementMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SupplierPayementMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SupplierPayementMasterCollection;
        }
        /// <summary>
        /// Select a record from SupplierPayementMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SupplierPayementMaster> SelectByID(SupplierPayementMaster item)
        {
            IBaseEntityResponse<SupplierPayementMaster> entityResponse = new BaseEntityResponse<SupplierPayementMaster>();
            try
            {
                entityResponse = _SupplierPayementMasterDataProvider.GetSupplierPayementMasterByID(item);
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
        /// Select a record from SupplierPayementMaster table by PurchaseRequisitionMasterID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SupplierPayementMaster> GetVendorWiseInvoiceDetailsForPayement(SupplierPayementMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SupplierPayementMaster> SupplierPayementMasterCollection = new BaseEntityCollectionResponse<SupplierPayementMaster>();
            try
            {
                if (_SupplierPayementMasterDataProvider != null)
                    SupplierPayementMasterCollection = _SupplierPayementMasterDataProvider.GetVendorWiseInvoiceDetailsForPayement(searchRequest);
                else
                {
                    SupplierPayementMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SupplierPayementMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SupplierPayementMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SupplierPayementMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SupplierPayementMasterCollection;
        }


        public IBaseEntityCollectionResponse<SupplierPayementMaster> GetRecordForPurchaseOrderPDF(SupplierPayementMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SupplierPayementMaster> SupplierPayementMasterCollection = new BaseEntityCollectionResponse<SupplierPayementMaster>();
            try
            {
                if (_SupplierPayementMasterDataProvider != null)
                    SupplierPayementMasterCollection = _SupplierPayementMasterDataProvider.GetRecordForPurchaseOrderPDF(searchRequest);
                else
                {
                    SupplierPayementMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SupplierPayementMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SupplierPayementMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SupplierPayementMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SupplierPayementMasterCollection;
        }
    }
}
