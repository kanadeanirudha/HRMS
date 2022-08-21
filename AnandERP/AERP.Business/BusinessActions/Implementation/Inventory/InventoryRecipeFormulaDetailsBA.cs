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
    public class InventoryRecipeFormulaDetailsBA : IInventoryRecipeFormulaDetailsBA
    {
        IInventoryRecipeFormulaDetailsDataProvider _InventoryRecipeFormulaDetailsDataProvider;
        IInventoryRecipeFormulaDetailsBR _InventoryRecipeFormulaDetailsBR;
        private ILogger _logException;
        public InventoryRecipeFormulaDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _InventoryRecipeFormulaDetailsBR = new InventoryRecipeFormulaDetailsBR();
            _InventoryRecipeFormulaDetailsDataProvider = new InventoryRecipeFormulaDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryRecipeFormulaDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> InsertInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item)
        {
            IBaseEntityResponse<InventoryRecipeFormulaDetails> entityResponse = new BaseEntityResponse<InventoryRecipeFormulaDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRecipeFormulaDetailsBR.InsertInventoryRecipeFormulaDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRecipeFormulaDetailsDataProvider.InsertInventoryRecipeFormulaDetails(item);
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
        /// Update a specific record  of InventoryRecipeFormulaDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> UpdateInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item)
        {
            IBaseEntityResponse<InventoryRecipeFormulaDetails> entityResponse = new BaseEntityResponse<InventoryRecipeFormulaDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRecipeFormulaDetailsBR.UpdateInventoryRecipeFormulaDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRecipeFormulaDetailsDataProvider.UpdateInventoryRecipeFormulaDetails(item);
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
        /// Delete a selected record from InventoryRecipeFormulaDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> DeleteInventoryRecipeFormulaDetails(InventoryRecipeFormulaDetails item)
        {
            IBaseEntityResponse<InventoryRecipeFormulaDetails> entityResponse = new BaseEntityResponse<InventoryRecipeFormulaDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _InventoryRecipeFormulaDetailsBR.DeleteInventoryRecipeFormulaDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _InventoryRecipeFormulaDetailsDataProvider.DeleteInventoryRecipeFormulaDetails(item);
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
        /// Select all record from InventoryRecipeFormulaDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetBySearch(InventoryRecipeFormulaDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> InventoryRecipeFormulaDetailsCollection = new BaseEntityCollectionResponse<InventoryRecipeFormulaDetails>();
            try
            {
                if (_InventoryRecipeFormulaDetailsDataProvider != null)
                    InventoryRecipeFormulaDetailsCollection = _InventoryRecipeFormulaDetailsDataProvider.GetInventoryRecipeFormulaDetailsBySearch(searchRequest);
                else
                {
                    InventoryRecipeFormulaDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRecipeFormulaDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRecipeFormulaDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRecipeFormulaDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRecipeFormulaDetailsCollection;
        }

        public IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> GetInventoryRecipeFormulaDetailsSearchList(InventoryRecipeFormulaDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeFormulaDetails> InventoryRecipeFormulaDetailsCollection = new BaseEntityCollectionResponse<InventoryRecipeFormulaDetails>();
            try
            {
                if (_InventoryRecipeFormulaDetailsDataProvider != null)
                    InventoryRecipeFormulaDetailsCollection = _InventoryRecipeFormulaDetailsDataProvider.GetInventoryRecipeFormulaDetailsSearchList(searchRequest);
                else
                {
                    InventoryRecipeFormulaDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRecipeFormulaDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRecipeFormulaDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRecipeFormulaDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRecipeFormulaDetailsCollection;
        }
        /// <summary>
        /// Select a record from InventoryRecipeFormulaDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeFormulaDetails> SelectByID(InventoryRecipeFormulaDetails item)
        {
            IBaseEntityResponse<InventoryRecipeFormulaDetails> entityResponse = new BaseEntityResponse<InventoryRecipeFormulaDetails>();
            try
            {
                entityResponse = _InventoryRecipeFormulaDetailsDataProvider.GetInventoryRecipeFormulaDetailsByID(item);
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
