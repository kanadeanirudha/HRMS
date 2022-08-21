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
    public class UserDetailBA : IUserDetailBA
    {
        IUserDetailDataProvider _userDetailDataProvider;
        IUserDetailBR _userDetailBR;
        private ILogger _logException;

        public UserDetailBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _userDetailBR = new UserDetailBR();
            _userDetailDataProvider = new UserDetailDataProvider();
        }

        public IBaseEntityResponse<UserDetail> InsertUserDetail(UserDetail item)
        {
            IBaseEntityResponse<UserDetail> entityResponse = new BaseEntityResponse<UserDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userDetailBR.InsertUserDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userDetailDataProvider.InsertUserDetail(item);
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

        public IBaseEntityResponse<UserDetail> UpdateUserDetail(UserDetail item)
        {
            IBaseEntityResponse<UserDetail> entityResponse = new BaseEntityResponse<UserDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userDetailBR.UpdateUserDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userDetailDataProvider.UpdateUserDetail(item);
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

        public IBaseEntityResponse<UserDetail> DeleteUserDetail(UserDetail item)
        {
            IBaseEntityResponse<UserDetail> entityResponse = new BaseEntityResponse<UserDetail>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _userDetailBR.DeleteUserDetailValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _userDetailDataProvider.DeleteUserDetail(item);
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

        public IBaseEntityCollectionResponse<UserDetail> GetBySearch(UserDetailSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<UserDetail> userDetailCollection = new BaseEntityCollectionResponse<UserDetail>();
            try
            {
                if (_userDetailDataProvider != null)
                {
                    userDetailCollection = _userDetailDataProvider.GetUserDetailBySearch(searchRequest);
                }
                else
                {
                    userDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    userDetailCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                userDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                userDetailCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return userDetailCollection;
        }

    }
}
