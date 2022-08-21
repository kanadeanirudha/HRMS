using AERP.Base.DTO;
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
    public class LoginBA : ILoginBA
    {
        private ILogger _logException;
        private ILoginDataProvider _LoginDataProvider;
        public LoginBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _LoginDataProvider = new LoginDataProvider();
        }

        public IBaseEntityResponse<UserMaster> UserLoginApi(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> UserMasterCollection = new BaseEntityResponse<UserMaster>();
            try
            {
                if (_LoginDataProvider != null)
                    UserMasterCollection = _LoginDataProvider.UserLoginApi(item);
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.Entity = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
               // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }


        public IBaseEntityResponse<UserMaster> ChangePassword(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> UserMasterCollection = new BaseEntityResponse<UserMaster>();
            try
            {
                if (_LoginDataProvider != null)
                    UserMasterCollection = _LoginDataProvider.ChangePassword(item);
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.Entity = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }


        public IBaseEntityResponse<UserMaster> IsValidate(UserMaster item)
        {
            IBaseEntityResponse<UserMaster> UserMasterCollection = new BaseEntityResponse<UserMaster>();
            try
            {
                if (_LoginDataProvider != null)
                    UserMasterCollection = _LoginDataProvider.IsValidate(item);
                else
                {
                    UserMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    UserMasterCollection.Entity = null;
                }
            }
            catch (Exception ex)
            {
                UserMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }

        public IBaseEntityCollectionResponse<UserMaster> EngineerList(UserMaster item)
        {
            IBaseEntityCollectionResponse<UserMaster> UserMasterCollection = new BaseEntityCollectionResponse<UserMaster>();
            try
            {
                if (_LoginDataProvider != null)
                    UserMasterCollection = _LoginDataProvider.EngineerList(item);
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
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return UserMasterCollection;
        }

        public IBaseEntityResponse<UserMaster> SelectByEmailIDPassword(UserMaster item)
        {

            IBaseEntityResponse<UserMaster> entityResponse = new BaseEntityResponse<UserMaster>();
            try
            {
                entityResponse = _LoginDataProvider.GetUserMasterByEmailIDPassword(item);
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
