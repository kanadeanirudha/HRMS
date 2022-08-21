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
    public class UserMasterBA : IUserMasterBA
    {
        IUserMasterDataProvider _userMasterDataProvider;
        IUserMasterBR _userMasterBR;
        private ILogger _logException;

        public UserMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userMasterBR = new UserMasterBR();
            _userMasterDataProvider = new UserMasterDataProvider();
        }

        public IBaseEntityResponse<UserMaster> InsertUserMaster(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userMasterBR.InsertUserMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userMasterDataProvider.InsertUserMaster(item);
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

        public IBaseEntityResponse<UserMaster> UpdateUserMaster(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userMasterBR.UpdateUserMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userMasterDataProvider.UpdateUserMaster(item);
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

        public IBaseEntityResponse<UserMaster> DeleteUserMaster(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userMasterBR.DeleteUserMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userMasterDataProvider.DeleteUserMaster(item);
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

        public IBaseEntityCollectionResponse<UserMaster> GetBySearch(UserMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMaster> UserMasterCollection = new BaseEntityCollectionResponse<UserMaster>();
            try
            {
                if (_userMasterDataProvider != null)
                {
                    UserMasterCollection = _userMasterDataProvider.GetUserMasterBySearch(searchRequest);
                }
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                UserMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }

        public IBaseEntityResponse<UserMaster> SelectByID(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.GetUserMasterByID(item);
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

        public IBaseEntityResponse<UserMaster> SelectByEmailID(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.SelectByEmailID(item);
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

        public IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.UserLoginApi(item);
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

        public IBaseEntityResponse<UserMaster> UserLogoutApi(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.UserLogoutApi(item);
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
        
        public IBaseEntityResponse<UserMaster> SelectByEmailIDPassword(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.GetUserMasterByEmailIDPassword(item);
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

        public IBaseEntityCollectionResponse<UserMaster> GetRoleByID(UserMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMaster> UserMasterCollection = new BaseEntityCollectionResponse<UserMaster>();
            try
            {
                if (_userMasterDataProvider != null)
                {
                    UserMasterCollection = _userMasterDataProvider.GetRolesBySearch(searchRequest);
                }
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                UserMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }

        public IBaseEntityCollectionResponse<UserMaster> GetUserType(UserMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMaster> UserMasterCollection = new BaseEntityCollectionResponse<UserMaster>();
            try
            {
                if (_userMasterDataProvider != null)
                {
                    UserMasterCollection = _userMasterDataProvider.GetUserType(searchRequest);
                }
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                UserMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }
        public IBaseEntityResponse<UserMaster> LogOffByUserID(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.LogOffByUserID(item);
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


        public IBaseEntityCollectionResponse<UserMaster> GetActiveUserBySearch(UserMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserMaster> ActiveUserCollection = new BaseEntityCollectionResponse<UserMaster>();
            try
            {
                if (_userMasterDataProvider != null)
                {
                    ActiveUserCollection = _userMasterDataProvider.GetActiveUserBySearch(searchRequest);
                }
                else
                {
                    ActiveUserCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    ActiveUserCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                ActiveUserCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                ActiveUserCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return ActiveUserCollection;
        }

        public IBaseEntityResponse<UserMaster> UserLoginReset(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _userMasterDataProvider.UserLoginReset(item);
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
