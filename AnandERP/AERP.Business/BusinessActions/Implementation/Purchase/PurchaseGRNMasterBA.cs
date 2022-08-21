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
    public class PurchaseGRNMasterBA : IPurchaseGRNMasterBA
    {
        IPurchaseGRNMasterDataProvider _PurchaseGRNMasterDataProvider;
        IPurchaseGRNMasterBR _generalRegionMasterBR;
        private ILogger _logException;

        public PurchaseGRNMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _generalRegionMasterBR = new PurchaseGRNMasterBR();
            _PurchaseGRNMasterDataProvider = new PurchaseGRNMasterDataProvider();
        }

        /// <summary>
        /// Create new record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> InsertPurchaseGRNMaster(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> entityResponse = new BaseEntityResponse<PurchaseGRNMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.InsertPurchaseGRNMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseGRNMasterDataProvider.InsertPurchaseGRNMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> UpdatePurchaseGRNMaster(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> entityResponse = new BaseEntityResponse<PurchaseGRNMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.UpdatePurchaseGRNMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseGRNMasterDataProvider.UpdatePurchaseGRNMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> DeletePurchaseGRNMaster(PurchaseGRNMaster item)
        {
            IBaseEntityResponse<PurchaseGRNMaster> entityResponse = new BaseEntityResponse<PurchaseGRNMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _generalRegionMasterBR.DeletePurchaseGRNMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _PurchaseGRNMasterDataProvider.DeletePurchaseGRNMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Select all record from PurchaseGRNMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBySearch(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> categoryMasterCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
            try
            {
                if (_PurchaseGRNMasterDataProvider != null)
                {
                    categoryMasterCollection = _PurchaseGRNMasterDataProvider.GetPurchaseGRNMasterBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from PurchaseGRNMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBySearchList(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> categoryMasterCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
            try
            {
                if (_PurchaseGRNMasterDataProvider != null)
                {
                    categoryMasterCollection = _PurchaseGRNMasterDataProvider.GetPurchaseGRNMasterGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from PurchaseGRNMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<PurchaseGRNMaster> SelectByID(PurchaseGRNMaster item)
        {

            IBaseEntityResponse<PurchaseGRNMaster> entityResponse = new BaseEntityResponse<PurchaseGRNMaster>();
            try
            {
                entityResponse = _PurchaseGRNMasterDataProvider.GetPurchaseGRNMasterByID(item);
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

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseOrderMasterListForGRN(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> PurchaseGRNMasterCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
            try
            {
                if (_PurchaseGRNMasterDataProvider != null)
                {
                    PurchaseGRNMasterCollection = _PurchaseGRNMasterDataProvider.GetPurchaseOrderMasterListForGRN(searchRequest);
                }
                else
                {
                    PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseGRNMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                PurchaseGRNMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseGRNMasterCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBatchList(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> PurchaseGRNMasterCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
            try
            {
                if (_PurchaseGRNMasterDataProvider != null)
                {
                    PurchaseGRNMasterCollection = _PurchaseGRNMasterDataProvider.GetBatchList(searchRequest);
                }
                else
                {
                    PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseGRNMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                PurchaseGRNMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseGRNMasterCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNDetailsByID(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> PurchaseGRNMasterCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
            try
            {
                if (_PurchaseGRNMasterDataProvider != null)
                {
                    PurchaseGRNMasterCollection = _PurchaseGRNMasterDataProvider.GetPurchaseGRNDetailsByID(searchRequest);
                }
                else
                {
                    PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseGRNMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                PurchaseGRNMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseGRNMasterCollection;
        }

        public IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGrnMasterListForPDF(PurchaseGRNMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<PurchaseGRNMaster> PurchaseGRNMasterCollection = new BaseEntityCollectionResponse<PurchaseGRNMaster>();
            try
            {
                if (_PurchaseGRNMasterDataProvider != null)
                {
                    PurchaseGRNMasterCollection = _PurchaseGRNMasterDataProvider.GetPurchaseGrnMasterListForPDF(searchRequest);
                }
                else
                {
                    PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    PurchaseGRNMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                PurchaseGRNMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                PurchaseGRNMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return PurchaseGRNMasterCollection;
        }
    }
}