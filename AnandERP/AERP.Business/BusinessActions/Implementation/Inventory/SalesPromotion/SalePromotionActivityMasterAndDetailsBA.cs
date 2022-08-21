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
    public class SalePromotionActivityMasterAndDetailsBA : ISalePromotionActivityMasterAndDetailsBA
    {
        ISalePromotionActivityMasterAndDetailsDataProvider _SalePromotionActivityMasterAndDetailsDataProvider;
        ISalePromotionActivityMasterAndDetailsBR _SalePromotionActivityMasterAndDetailsBR;
        private ILogger _logException;
        public SalePromotionActivityMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _SalePromotionActivityMasterAndDetailsBR = new SalePromotionActivityMasterAndDetailsBR();
            _SalePromotionActivityMasterAndDetailsDataProvider = new SalePromotionActivityMasterAndDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of SalePromotionActivityMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.InsertSalePromotionActivityMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.InsertSalePromotionActivityMasterAndDetails(item);
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
        /// Update a specific record  of SalePromotionActivityMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.UpdateSalePromotionActivityMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.UpdateSalePromotionActivityMasterAndDetails(item);
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
        /// Delete a selected record from SalePromotionActivityMasterAndDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeleteSalePromotionActivityMasterAndDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.DeleteSalePromotionActivityMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.DeleteSalePromotionActivityMasterAndDetails(item);
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
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> DeletePromotionActivityDiscounteItemList(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.DeletePromotionActivityDiscounteItemListValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.DeletePromotionActivityDiscounteItemList(item);
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
        /// Select all record from SalePromotionActivityMasterAndDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetBySearch(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetSalePromotionActivityMasterAndDetailsBySearch(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionActivityMasterAndDetailsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetSalePromotionActivityMasterAndDetailsSearchList(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }
        /// <summary>
        /// Select a record from SalePromotionActivityMasterAndDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> SelectByID(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.GetSalePromotionActivityMasterAndDetailsByID(item);
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

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionActivityMasterAndDetailsRules(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.InsertSalePromotionActivityMasterAndDetailsRulesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.InsertSalePromotionActivityMasterAndDetailsRules(item);
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

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetPlanForFixedAmount(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetPlanForFixedAmount(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetItemList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetItemList(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetFixAmountDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetFixAmountDetails(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertItemDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.InsertItemDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.InsertItemDetails(item);
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


        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetConcessionfreeItemsSearchList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetConcessionfreeItemsSearchList(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemFreeConcessionTypeList(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetSelectedItemFreeConcessionTypeList(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }

        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetSelectedItemOfConcessionType(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> UpdateSelectedItemOfConcessionType(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.UpdateSelectedItemOfConcessionTypeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.UpdateSelectedItemOfConcessionType(item);
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

        public IBaseEntityResponse<SalePromotionActivityMasterAndDetails> InsertSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetails item)
        {
            IBaseEntityResponse<SalePromotionActivityMasterAndDetails> entityResponse = new BaseEntityResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _SalePromotionActivityMasterAndDetailsBR.InsertSalePromotionGiftVocherDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _SalePromotionActivityMasterAndDetailsDataProvider.InsertSalePromotionGiftVocherDetails(item);
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
        public IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> GetSalePromotionGiftVocherDetails(SalePromotionActivityMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails> SalePromotionActivityMasterAndDetailsCollection = new BaseEntityCollectionResponse<SalePromotionActivityMasterAndDetails>();
            try
            {
                if (_SalePromotionActivityMasterAndDetailsDataProvider != null)
                    SalePromotionActivityMasterAndDetailsCollection = _SalePromotionActivityMasterAndDetailsDataProvider.GetSalePromotionGiftVocherDetails(searchRequest);
                else
                {
                    SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SalePromotionActivityMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                SalePromotionActivityMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return SalePromotionActivityMasterAndDetailsCollection;
        }
    }
}
