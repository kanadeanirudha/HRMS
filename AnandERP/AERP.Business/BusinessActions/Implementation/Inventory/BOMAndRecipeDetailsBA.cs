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
    public class BOMAndRecipeDetailsBA : IBOMAndRecipeDetailsBA
    {
        IBOMAndRecipeDetailsDataProvider _BOMAndRecipeDetailsDataProvider;
        IBOMAndRecipeDetailsBR _BOMAndRecipeDetailsBR;
        private ILogger _logException;
        public BOMAndRecipeDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _BOMAndRecipeDetailsBR = new BOMAndRecipeDetailsBR();
            _BOMAndRecipeDetailsDataProvider = new BOMAndRecipeDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of BOMAndRecipeDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BOMAndRecipeDetails> InsertBOMAndRecipeDetails(BOMAndRecipeDetails item)
        {
            IBaseEntityResponse<BOMAndRecipeDetails> entityResponse = new BaseEntityResponse<BOMAndRecipeDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _BOMAndRecipeDetailsBR.InsertBOMAndRecipeDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _BOMAndRecipeDetailsDataProvider.InsertBOMAndRecipeDetails(item);
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
        /// Update a specific record  of BOMAndRecipeDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BOMAndRecipeDetails> UpdateBOMAndRecipeDetails(BOMAndRecipeDetails item)
        {
            IBaseEntityResponse<BOMAndRecipeDetails> entityResponse = new BaseEntityResponse<BOMAndRecipeDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _BOMAndRecipeDetailsBR.UpdateBOMAndRecipeDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _BOMAndRecipeDetailsDataProvider.UpdateBOMAndRecipeDetails(item);
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
        /// Delete a selected record from BOMAndRecipeDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BOMAndRecipeDetails> DeleteBOMAndRecipeDetails(BOMAndRecipeDetails item)
        {
            IBaseEntityResponse<BOMAndRecipeDetails> entityResponse = new BaseEntityResponse<BOMAndRecipeDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _BOMAndRecipeDetailsBR.DeleteBOMAndRecipeDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _BOMAndRecipeDetailsDataProvider.DeleteBOMAndRecipeDetails(item);
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
        /// Select all record from BOMAndRecipeDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBySearch(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> BOMAndRecipeDetailsCollection = new BaseEntityCollectionResponse<BOMAndRecipeDetails>();
            try
            {
                if (_BOMAndRecipeDetailsDataProvider != null)
                    BOMAndRecipeDetailsCollection = _BOMAndRecipeDetailsDataProvider.GetBOMAndRecipeDetailsBySearch(searchRequest);
                else
                {
                    BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BOMAndRecipeDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BOMAndRecipeDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BOMAndRecipeDetailsCollection;
        }

        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetBOMAndRecipeDetailsSearchList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> BOMAndRecipeDetailsCollection = new BaseEntityCollectionResponse<BOMAndRecipeDetails>();
            try
            {
                if (_BOMAndRecipeDetailsDataProvider != null)
                    BOMAndRecipeDetailsCollection = _BOMAndRecipeDetailsDataProvider.GetBOMAndRecipeDetailsSearchList(searchRequest);
                else
                {
                    BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BOMAndRecipeDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BOMAndRecipeDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BOMAndRecipeDetailsCollection;
        }
        /// <summary>
        /// Select a record from BOMAndRecipeDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<BOMAndRecipeDetails> SelectByID(BOMAndRecipeDetails item)
        {
            IBaseEntityResponse<BOMAndRecipeDetails> entityResponse = new BaseEntityResponse<BOMAndRecipeDetails>();
            try
            {
                entityResponse = _BOMAndRecipeDetailsDataProvider.GetBOMAndRecipeDetailsByID(item);
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

        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> SelectIngridentsByVarients(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> BOMAndRecipeDetailsCollection = new BaseEntityCollectionResponse<BOMAndRecipeDetails>();
            try
            {
                if (_BOMAndRecipeDetailsDataProvider != null)
                    BOMAndRecipeDetailsCollection = _BOMAndRecipeDetailsDataProvider.GetIngridentsListByVarients(searchRequest);
                else
                {
                    BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BOMAndRecipeDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BOMAndRecipeDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BOMAndRecipeDetailsCollection;
        }
        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetConsumptionUnitList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> BOMAndRecipeDetailsCollection = new BaseEntityCollectionResponse<BOMAndRecipeDetails>();
            try
            {
                if (_BOMAndRecipeDetailsDataProvider != null)
                    BOMAndRecipeDetailsCollection = _BOMAndRecipeDetailsDataProvider.GetConsumptionUnitList(searchRequest);
                else
                {
                    BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BOMAndRecipeDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BOMAndRecipeDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BOMAndRecipeDetailsCollection;
        }

        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetItemsList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> BOMAndRecipeDetailsCollection = new BaseEntityCollectionResponse<BOMAndRecipeDetails>();
            try
            {
                if (_BOMAndRecipeDetailsDataProvider != null)
                    BOMAndRecipeDetailsCollection = _BOMAndRecipeDetailsDataProvider.GetItemsList(searchRequest);
                else
                {
                    BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BOMAndRecipeDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BOMAndRecipeDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BOMAndRecipeDetailsCollection;
        }

        public IBaseEntityCollectionResponse<BOMAndRecipeDetails> GetUoMCodeWisePurchasePriceList(BOMAndRecipeDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<BOMAndRecipeDetails> BOMAndRecipeDetailsCollection = new BaseEntityCollectionResponse<BOMAndRecipeDetails>();
            try
            {
                if (_BOMAndRecipeDetailsDataProvider != null)
                    BOMAndRecipeDetailsCollection = _BOMAndRecipeDetailsDataProvider.GetUoMCodeWisePurchasePriceList(searchRequest);
                else
                {
                    BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BOMAndRecipeDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BOMAndRecipeDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                BOMAndRecipeDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BOMAndRecipeDetailsCollection;
        }
    }
}
