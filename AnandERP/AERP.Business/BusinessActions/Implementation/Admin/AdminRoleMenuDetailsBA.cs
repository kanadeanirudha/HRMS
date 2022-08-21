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
    public class AdminRoleMenuDetailsBA : IAdminRoleMenuDetailsBA
    {
        IAdminRoleMenuDetailsDataProvider _adminRoleMenuDetailsDataProvider;
        IAdminRoleMenuDetailsBR _adminRoleMenuDetailsBR;
        private ILogger _logException;
        public AdminRoleMenuDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminRoleMenuDetailsBR = new AdminRoleMenuDetailsBR();
            _adminRoleMenuDetailsDataProvider = new AdminRoleMenuDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of AdminRoleMenuDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMenuDetails> InsertAdminRoleMenuDetails(AdminRoleMenuDetails item)
        {
            IBaseEntityResponse<AdminRoleMenuDetails> entityResponse = new BaseEntityResponse<AdminRoleMenuDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleMenuDetailsBR.InsertAdminRoleMenuDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleMenuDetailsDataProvider.InsertAdminRoleMenuDetails(item);
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
        /// Update a specific record  of AdminRoleMenuDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMenuDetails> UpdateAdminRoleMenuDetails(AdminRoleMenuDetails item)
        {
            IBaseEntityResponse<AdminRoleMenuDetails> entityResponse = new BaseEntityResponse<AdminRoleMenuDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleMenuDetailsBR.UpdateAdminRoleMenuDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleMenuDetailsDataProvider.UpdateAdminRoleMenuDetails(item);
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
        /// Delete a selected record from AdminRoleMenuDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMenuDetails> DeleteAdminRoleMenuDetails(AdminRoleMenuDetails item)
        {
            IBaseEntityResponse<AdminRoleMenuDetails> entityResponse = new BaseEntityResponse<AdminRoleMenuDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleMenuDetailsBR.DeleteAdminRoleMenuDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleMenuDetailsDataProvider.DeleteAdminRoleMenuDetails(item);
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
        /// Select all record from AdminRoleMenuDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearch(AdminRoleMenuDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMenuDetails> AdminRoleMenuDetailsCollection = new BaseEntityCollectionResponse<AdminRoleMenuDetails>();
            try
            {
                if (_adminRoleMenuDetailsDataProvider != null)
                    AdminRoleMenuDetailsCollection = _adminRoleMenuDetailsDataProvider.GetAdminRoleMenuDetailsBySearch(searchRequest);
                else
                {
                    AdminRoleMenuDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMenuDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMenuDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AdminRoleMenuDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMenuDetailsCollection;
        }
        /// <summary>
        /// Select a record from AdminRoleMenuDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMenuDetails> SelectByID(AdminRoleMenuDetails item)
        {
            IBaseEntityResponse<AdminRoleMenuDetails> entityResponse = new BaseEntityResponse<AdminRoleMenuDetails>();
            try
            {
                entityResponse = _adminRoleMenuDetailsDataProvider.GetAdminRoleMenuDetailsByID(item);
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
        /// Select all record from AdminRoleMenuDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchModuleList(AdminRoleMenuDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMenuDetails> AdminRoleMenuDetailsCollection = new BaseEntityCollectionResponse<AdminRoleMenuDetails>();
            try
            {
                if (_adminRoleMenuDetailsDataProvider != null)
                    AdminRoleMenuDetailsCollection = _adminRoleMenuDetailsDataProvider.GetAdminModuleBySearch(searchRequest);
                else
                {
                    AdminRoleMenuDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMenuDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMenuDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AdminRoleMenuDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMenuDetailsCollection;
        }



        /// <summary>
        /// Select all record from AdminRoleMenuDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> GetBySearchAdminMenuList(AdminRoleMenuDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMenuDetails> AdminRoleMenuDetailsCollection = new BaseEntityCollectionResponse<AdminRoleMenuDetails>();
            try
            {
                if (_adminRoleMenuDetailsDataProvider != null)
                    AdminRoleMenuDetailsCollection = _adminRoleMenuDetailsDataProvider.GetAdminMenuBySearch(searchRequest);
                else
                {
                    AdminRoleMenuDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMenuDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMenuDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                AdminRoleMenuDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMenuDetailsCollection;
        }

        public IBaseEntityResponse<AdminRoleMenuDetails> CheckMenuApplicableOrNotByAdminRoleID(AdminRoleMenuDetails item)
        {
            IBaseEntityResponse<AdminRoleMenuDetails> entityResponse = new BaseEntityResponse<AdminRoleMenuDetails>();
            try
            {
                if (_adminRoleMenuDetailsDataProvider!=null)
                {
                    entityResponse = _adminRoleMenuDetailsDataProvider.CheckMenuApplicableOrNotByAdminRoleID(item);
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
    }
}
