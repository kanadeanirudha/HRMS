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
    public class PurchaseRequisitionMasterBA : IPurchaseRequisitionMasterBA
    {
        IPurchaseRequisitionMasterDataProvider _PurchaseRequisitionMasterDataProvider;
        IPurchaseRequisitionMasterBR _PurchaseRequisitionMasterBR;
        private ILogger _logException;
        public PurchaseRequisitionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _PurchaseRequisitionMasterBR = new PurchaseRequisitionMasterBR();
            _PurchaseRequisitionMasterDataProvider = new PurchaseRequisitionMasterDataProvider();
        }
        /// <summary>
        /// Create new record of PurchaseRequisitionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseRequisitionMaster> InsertPurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> entityResponse = new BaseEntityResponse<PurchaseRequisitionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseRequisitionMasterBR.InsertPurchaseRequisitionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseRequisitionMasterDataProvider.InsertPurchaseRequisitionMaster(item);
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
        /// Update a specific record  of PurchaseRequisitionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityResponse<PurchaseRequisitionMaster> InsertApprovedPurchaseRequisitionRecord(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> entityResponse = new BaseEntityResponse<PurchaseRequisitionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseRequisitionMasterBR.InsertPurchaseRequisitionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseRequisitionMasterDataProvider.InsertApprovedPurchaseRequisitionRecord(item);
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
        public IBaseEntityResponse<PurchaseRequisitionMaster> UpdatePurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> entityResponse = new BaseEntityResponse<PurchaseRequisitionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseRequisitionMasterBR.UpdatePurchaseRequisitionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseRequisitionMasterDataProvider.UpdatePurchaseRequisitionMaster(item);
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
        /// Delete a selected record from PurchaseRequisitionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseRequisitionMaster> DeletePurchaseRequisitionMaster(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> entityResponse = new BaseEntityResponse<PurchaseRequisitionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _PurchaseRequisitionMasterBR.DeletePurchaseRequisitionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseRequisitionMasterDataProvider.DeletePurchaseRequisitionMaster(item);
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
        /// Select all record from PurchaseRequisitionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetBySearch(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetPurchaseRequisitionMasterBySearch(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetPurchaseRequisitionMasterList(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }
        /// <summary>
        /// Select a record from PurchaseRequisitionMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseRequisitionMaster> SelectByID(PurchaseRequisitionMaster item)
        {
            IBaseEntityResponse<PurchaseRequisitionMaster> entityResponse = new BaseEntityResponse<PurchaseRequisitionMaster>();
            try
            {
                entityResponse = _PurchaseRequisitionMasterDataProvider.GetPurchaseRequisitionMasterByID(item);
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


        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterListForBelowSafetyLevel(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetPurchaseRequisitionMasterListForBelowSafetyLevel(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterDetailLists(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetPurchaseRequisitionMasterDetailLists(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }


        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionForApproval(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetPurchaseRequisitionForApproval(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }

        //Method For Get UoM details with Its Purchase Price 
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomDetailsForSTOWithPurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetUomDetailsForSTOWithPurchasePrice(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }


        //Method For Get UoMWisePurchasePrice on change of UOM Drop down
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomWisePurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetUomWisePurchasePrice(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }


        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemAndLocationWiseBatchQuantity(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetItemAndLocationWiseBatchQuantity(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }
        public IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemwiseRequirmentForDataList(PurchaseRequisitionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseRequisitionMaster> PurchaseRequisitionMasterCollection = new BaseEntityCollectionResponse<PurchaseRequisitionMaster>();
            try
            {
                if (_PurchaseRequisitionMasterDataProvider != null)
                    PurchaseRequisitionMasterCollection = _PurchaseRequisitionMasterDataProvider.GetItemwiseRequirmentForDataList(searchRequest);
                else
                {
                    PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseRequisitionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseRequisitionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                PurchaseRequisitionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseRequisitionMasterCollection;
        }
        

    }
}
