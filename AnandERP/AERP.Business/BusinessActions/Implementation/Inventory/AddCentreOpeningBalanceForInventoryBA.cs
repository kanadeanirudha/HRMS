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
    public class AddCentreOpeningBalanceForInventoryBA : IAddCentreOpeningBalanceForInventoryBA
    {
        IAddCentreOpeningBalanceForInventoryDataProvider _AddCentreOpeningBalanceForInventoryDataProvider;
        IAddCentreOpeningBalanceForInventoryBR _AddCentreOpeningBalanceForInventoryBR;

        private ILogger _logException;
        public AddCentreOpeningBalanceForInventoryBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _AddCentreOpeningBalanceForInventoryBR = new AddCentreOpeningBalanceForInventoryBR();
            _AddCentreOpeningBalanceForInventoryDataProvider = new AddCentreOpeningBalanceForInventoryDataProvider();
        }

        /// Create new record of AddCentreOpeningBalanceForInventory.
        public IBaseEntityResponse<AddCentreOpeningBalanceForInventory> InsertAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item)
        {
            IBaseEntityResponse<AddCentreOpeningBalanceForInventory> entityResponse = new BaseEntityResponse<AddCentreOpeningBalanceForInventory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AddCentreOpeningBalanceForInventoryBR.InsertAddCentreOpeningBalanceForInventoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AddCentreOpeningBalanceForInventoryDataProvider.InsertAddCentreOpeningBalanceForInventory(item);
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

        /// Update a specific record  of AddCentreOpeningBalanceForInventory.
        public IBaseEntityResponse<AddCentreOpeningBalanceForInventory> UpdateAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item)
        {
            IBaseEntityResponse<AddCentreOpeningBalanceForInventory> entityResponse = new BaseEntityResponse<AddCentreOpeningBalanceForInventory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AddCentreOpeningBalanceForInventoryBR.UpdateAddCentreOpeningBalanceForInventoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AddCentreOpeningBalanceForInventoryDataProvider.UpdateAddCentreOpeningBalanceForInventory(item);
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

        /// Delete a selected record from AddCentreOpeningBalanceForInventory.
        public IBaseEntityResponse<AddCentreOpeningBalanceForInventory> DeleteAddCentreOpeningBalanceForInventory(AddCentreOpeningBalanceForInventory item)
        {
            IBaseEntityResponse<AddCentreOpeningBalanceForInventory> entityResponse = new BaseEntityResponse<AddCentreOpeningBalanceForInventory>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _AddCentreOpeningBalanceForInventoryBR.DeleteAddCentreOpeningBalanceForInventoryValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _AddCentreOpeningBalanceForInventoryDataProvider.DeleteAddCentreOpeningBalanceForInventory(item);
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

        /// Select all record from AddCentreOpeningBalanceForInventory table with search parameters.
        public IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> GetBySearch(AddCentreOpeningBalanceForInventorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> AddCentreOpeningBalanceForInventoryCollection = new BaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory>();
            try
            {
                if (_AddCentreOpeningBalanceForInventoryDataProvider != null)
                    AddCentreOpeningBalanceForInventoryCollection = _AddCentreOpeningBalanceForInventoryDataProvider.GetAddCentreOpeningBalanceForInventoryBySearch(searchRequest);
                else
                {
                    AddCentreOpeningBalanceForInventoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AddCentreOpeningBalanceForInventoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AddCentreOpeningBalanceForInventoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AddCentreOpeningBalanceForInventoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AddCentreOpeningBalanceForInventoryCollection;
        }

        /// Select a record from AddCentreOpeningBalanceForInventory table by ID.
        public IBaseEntityResponse<AddCentreOpeningBalanceForInventory> SelectByID(AddCentreOpeningBalanceForInventory item)
        {
            IBaseEntityResponse<AddCentreOpeningBalanceForInventory> entityResponse = new BaseEntityResponse<AddCentreOpeningBalanceForInventory>();
            try
            {
                entityResponse = _AddCentreOpeningBalanceForInventoryDataProvider.GetAddCentreOpeningBalanceForInventoryByID(item);
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

        public IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> GetAddCentreOpeningBalanceForInventorySearchList(AddCentreOpeningBalanceForInventorySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory> AddCentreOpeningBalanceForInventoryCollection = new BaseEntityCollectionResponse<AddCentreOpeningBalanceForInventory>();
            try
            {
                if (_AddCentreOpeningBalanceForInventoryDataProvider != null)
                    AddCentreOpeningBalanceForInventoryCollection = _AddCentreOpeningBalanceForInventoryDataProvider.GetAddCentreOpeningBalanceForInventorySearchList(searchRequest);
                else
                {
                    AddCentreOpeningBalanceForInventoryCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AddCentreOpeningBalanceForInventoryCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AddCentreOpeningBalanceForInventoryCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AddCentreOpeningBalanceForInventoryCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AddCentreOpeningBalanceForInventoryCollection;
        }
    }
}
