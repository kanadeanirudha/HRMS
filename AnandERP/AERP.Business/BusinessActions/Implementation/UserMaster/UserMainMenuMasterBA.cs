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
    public class UserMainMenuMasterBA : IUserMainMenuMasterBA
    {
        IUserMainMenuMasterDataProvider _userMainMenuMasterDataProvider;
        IUserMainMenuMasterBR _userMainMenuMasterBR;
        private ILogger _logException;
        public UserMainMenuMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMainMenuMasterBR = new UserMainMenuMasterBR();
            _userMainMenuMasterDataProvider = new UserMainMenuMasterDataProvider();
        }
        /// <summary>
        /// Create new record of UserMainMenuMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserMainMenuMaster> InsertUserMainMenuMaster(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> entityResponse = new BaseEntityResponse<UserMainMenuMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userMainMenuMasterBR.InsertUserMainMenuMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userMainMenuMasterDataProvider.InsertUserMainMenuMaster(item);
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
        /// Update a specific record  of UserMainMenuMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserMainMenuMaster> UpdateUserMainMenuMaster(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> entityResponse = new BaseEntityResponse<UserMainMenuMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userMainMenuMasterBR.UpdateUserMainMenuMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userMainMenuMasterDataProvider.UpdateUserMainMenuMaster(item);
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
        /// Delete a selected record from UserMainMenuMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserMainMenuMaster> DeleteUserMainMenuMaster(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> entityResponse = new BaseEntityResponse<UserMainMenuMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userMainMenuMasterBR.DeleteUserMainMenuMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userMainMenuMasterDataProvider.DeleteUserMainMenuMaster(item);
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
        /// Select all record from UserMainMenuMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetBySearch(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> UserMainMenuMasterCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
            try
            {
                if (_userMainMenuMasterDataProvider != null)
                    UserMainMenuMasterCollection = _userMainMenuMasterDataProvider.GetUserMainMenuMasterBySearch(searchRequest);
                else
                {
                    UserMainMenuMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMainMenuMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMainMenuMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMainMenuMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMainMenuMasterCollection;
        }
        /// <summary>
        /// Select a record from UserMainMenuMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserMainMenuMaster> SelectByID(UserMainMenuMaster item)
        {
            IBaseEntityResponse<UserMainMenuMaster> entityResponse = new BaseEntityResponse<UserMainMenuMaster>();
            try
            {
                entityResponse = _userMainMenuMasterDataProvider.GetUserMainMenuMasterByID(item);
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
        /// Select all record from UserMainMenuMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetByModuleID(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> UserMainMenuMasterCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
            try
            {
                if (_userMainMenuMasterDataProvider != null)
                    UserMainMenuMasterCollection = _userMainMenuMasterDataProvider.GetMenuByModuleID(searchRequest);
                else
                {
                    UserMainMenuMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMainMenuMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMainMenuMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMainMenuMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMainMenuMasterCollection;
        }        
          /// <summary>
        /// Select record from UserMainMenuMaster table with search parameters ModuleID.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetParentMenuByModuleID(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> UserMainMenuMasterCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
            try
            {
                if (_userMainMenuMasterDataProvider != null)
                    UserMainMenuMasterCollection = _userMainMenuMasterDataProvider.GetParentMenuByModuleID(searchRequest);
                else
                {
                    UserMainMenuMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMainMenuMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMainMenuMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMainMenuMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMainMenuMasterCollection;
        }

        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetByModuleCode(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> UserMainMenuMasterCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
            try
            {
                if (_userMainMenuMasterDataProvider != null)
                    UserMainMenuMasterCollection = _userMainMenuMasterDataProvider.GetMenuByModuleCode(searchRequest);
                else
                {
                    UserMainMenuMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMainMenuMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMainMenuMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMainMenuMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMainMenuMasterCollection;
        }

        public IBaseEntityCollectionResponse<UserMainMenuMaster> GetCentrewiseMenuListForStudent(UserMainMenuMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMainMenuMaster> UserMainMenuMasterCollection = new BaseEntityCollectionResponse<UserMainMenuMaster>();
            try
            {
                if (_userMainMenuMasterDataProvider != null)
                    UserMainMenuMasterCollection = _userMainMenuMasterDataProvider.GetCentrewiseMenuListForStudent(searchRequest);
                else
                {
                    UserMainMenuMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMainMenuMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMainMenuMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserMainMenuMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMainMenuMasterCollection;
        }        
        
    }
}
