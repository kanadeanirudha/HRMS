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
    public class UserModuleMasterBA : IUserModuleMasterBA
    {
        IUserModuleMasterDataProvider _userModuleMasterDataProvider;
        IUserModuleMasterBR _userModuleMasterBR;
        private ILogger _logException;
        public UserModuleMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userModuleMasterBR = new UserModuleMasterBR();
            _userModuleMasterDataProvider = new UserModuleMasterDataProvider();
        }
        /// <summary>
        /// Create new record of UserModuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserModuleMaster> InsertUserModuleMaster(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> entityResponse = new BaseEntityResponse<UserModuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userModuleMasterBR.InsertUserModuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userModuleMasterDataProvider.InsertUserModuleMaster(item);
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
        /// Update a specific record  of UserModuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserModuleMaster> UpdateUserModuleMaster(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> entityResponse = new BaseEntityResponse<UserModuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userModuleMasterBR.UpdateUserModuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userModuleMasterDataProvider.UpdateUserModuleMaster(item);
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
        /// Delete a selected record from UserModuleMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserModuleMaster> DeleteUserModuleMaster(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> entityResponse = new BaseEntityResponse<UserModuleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userModuleMasterBR.DeleteUserModuleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userModuleMasterDataProvider.DeleteUserModuleMaster(item);
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
        /// Select all record from UserModuleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserModuleMaster> GetBySearch(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> UserModuleMasterCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
            try
            {
                if (_userModuleMasterDataProvider != null)
                    UserModuleMasterCollection = _userModuleMasterDataProvider.GetUserModuleMasterBySearch(searchRequest);
                else
                {
                    UserModuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserModuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserModuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserModuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserModuleMasterCollection;
        }
        /// <summary>
        /// Select a record from UserModuleMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<UserModuleMaster> SelectByID(UserModuleMaster item)
        {
            IBaseEntityResponse<UserModuleMaster> entityResponse = new BaseEntityResponse<UserModuleMaster>();
            try
            {
                entityResponse = _userModuleMasterDataProvider.GetUserModuleMasterByID(item);
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
        /// Select all record from UserModuleMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForLoginUserIDByRoleID(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> UserModuleMasterCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
            try
            {
                if (_userModuleMasterDataProvider != null)
                    UserModuleMasterCollection = _userModuleMasterDataProvider.GetModuleListForLoginUserIDByRoleID(searchRequest);
                else
                {
                    UserModuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserModuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserModuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserModuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserModuleMasterCollection;
        }

        /// <summary>
        /// Select all record from UserModuleMaster table .
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        /// 
        public IBaseEntityCollectionResponse<UserModuleMaster> GetUserModuleList(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> UserModuleMasterCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
            try
            {
                if (_userModuleMasterDataProvider != null)
                    UserModuleMasterCollection = _userModuleMasterDataProvider.GetUserModuleList(searchRequest);
                else
                {
                    UserModuleMasterCollection.Message.Add(new MessageDTO
                    { 
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserModuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserModuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserModuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserModuleMasterCollection;
        }
        public IBaseEntityCollectionResponse<UserModuleMaster> GetModuleListForAdmin(UserModuleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserModuleMaster> UserModuleMasterCollection = new BaseEntityCollectionResponse<UserModuleMaster>();
            try
            {
                if (_userModuleMasterDataProvider != null)
                    UserModuleMasterCollection = _userModuleMasterDataProvider.GetModuleListForAdmin(searchRequest);
                else
                {
                    UserModuleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserModuleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserModuleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                UserModuleMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserModuleMasterCollection;
        }
    }
}
