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
namespace AMS.Business.BusinessAction
{
    public class InventoryRecipeMenuCategoryBA : IInventoryRecipeMenuCategoryBA
    {
        IInventoryRecipeMenuCategoryDataProvider _inventoryRecipeMenuCategoryDataProvider;
        IInventoryRecipeMenuCategoryBR _inventoryRecipeMenuCategoryBR;
        private ILogger _logException;
        public InventoryRecipeMenuCategoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _inventoryRecipeMenuCategoryBR = new InventoryRecipeMenuCategoryBR();
            _inventoryRecipeMenuCategoryDataProvider = new InventoryRecipeMenuCategoryDataProvider();
        }
        /// <summary>
        /// Create new record of InventoryRecipeMenuCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMenuCategory> InsertInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item)
        {
            IBaseEntityResponse<InventoryRecipeMenuCategory> entityResponse = new BaseEntityResponse<InventoryRecipeMenuCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryRecipeMenuCategoryBR.InsertInventoryRecipeMenuCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryRecipeMenuCategoryDataProvider.InsertInventoryRecipeMenuCategory(item);
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
        /// Update a specific record  of InventoryRecipeMenuCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMenuCategory> UpdateInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item)
        {
            IBaseEntityResponse<InventoryRecipeMenuCategory> entityResponse = new BaseEntityResponse<InventoryRecipeMenuCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryRecipeMenuCategoryBR.UpdateInventoryRecipeMenuCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryRecipeMenuCategoryDataProvider.UpdateInventoryRecipeMenuCategory(item);
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
        /// Delete a selected record from InventoryRecipeMenuCategory.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMenuCategory> DeleteInventoryRecipeMenuCategory(InventoryRecipeMenuCategory item)
        {
            IBaseEntityResponse<InventoryRecipeMenuCategory> entityResponse = new BaseEntityResponse<InventoryRecipeMenuCategory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _inventoryRecipeMenuCategoryBR.DeleteInventoryRecipeMenuCategoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _inventoryRecipeMenuCategoryDataProvider.DeleteInventoryRecipeMenuCategory(item);
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
        /// Select all record from InventoryRecipeMenuCategory table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetBySearch(InventoryRecipeMenuCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> InventoryRecipeMenuCategoryCollection = new BaseEntityCollectionResponse<InventoryRecipeMenuCategory>();
            try
            {
                if (_inventoryRecipeMenuCategoryDataProvider != null)
                    InventoryRecipeMenuCategoryCollection = _inventoryRecipeMenuCategoryDataProvider.GetInventoryRecipeMenuCategoryBySearch(searchRequest);
                else
                {
                    InventoryRecipeMenuCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRecipeMenuCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRecipeMenuCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRecipeMenuCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRecipeMenuCategoryCollection;
        }
        /// <summary>
        /// Select a record from InventoryRecipeMenuCategory table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<InventoryRecipeMenuCategory> SelectByID(InventoryRecipeMenuCategory item)
        {
            IBaseEntityResponse<InventoryRecipeMenuCategory> entityResponse = new BaseEntityResponse<InventoryRecipeMenuCategory>();
            try
            {
                entityResponse = _inventoryRecipeMenuCategoryDataProvider.GetInventoryRecipeMenuCategoryByID(item);
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

        public IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> GetRestaurantCategory(InventoryRecipeMenuCategorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<InventoryRecipeMenuCategory> InventoryRecipeMenuCategoryCollection = new BaseEntityCollectionResponse<InventoryRecipeMenuCategory>();
            try
            {
                if (_inventoryRecipeMenuCategoryDataProvider != null)
                    InventoryRecipeMenuCategoryCollection = _inventoryRecipeMenuCategoryDataProvider.GetRestaurantCategory(searchRequest);
                else
                {
                    InventoryRecipeMenuCategoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    InventoryRecipeMenuCategoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                InventoryRecipeMenuCategoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                InventoryRecipeMenuCategoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return InventoryRecipeMenuCategoryCollection;
        }
    }
}
