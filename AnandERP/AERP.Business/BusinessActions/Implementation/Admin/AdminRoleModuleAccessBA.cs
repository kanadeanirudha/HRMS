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
    public class AdminRoleModuleAccessBA : IAdminRoleModuleAccessBA
    {
        IAdminRoleModuleAccessDataProvider _adminRoleModuleAccessDataProvider;
        IAdminRoleModuleAccessBR _adminRoleModuleAccessBR;
        private ILogger _logException;

        public AdminRoleModuleAccessBA() 
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminRoleModuleAccessBR = new AdminRoleModuleAccessBR();
            _adminRoleModuleAccessDataProvider = new AdminRoleModuleAccessDataProvider();
        }

        /// <summary>
        /// Create new record of AdminRoleModuleAccess.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleModuleAccess> InsertAdminRoleModuleAccess(AdminRoleModuleAccess item)
        {
            IBaseEntityResponse<AdminRoleModuleAccess> entityResponse = new BaseEntityResponse<AdminRoleModuleAccess>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleModuleAccessBR.InsertAdminRoleModuleAccessValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleModuleAccessDataProvider.InsertAdminRoleModuleAccess(item);
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

        /// <summary>
        /// Update a specific record of AdminRoleModuleAccess.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleModuleAccess> UpdateAdminRoleModuleAccess(AdminRoleModuleAccess item)
        {
            IBaseEntityResponse<AdminRoleModuleAccess> entityResponse = new BaseEntityResponse<AdminRoleModuleAccess>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleModuleAccessBR.UpdateAdminRoleModuleAccessValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleModuleAccessDataProvider.UpdateAdminRoleModuleAccess(item);
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

        /// <summary>
        /// Delete a selected record from AdminRoleModuleAccess.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleModuleAccess> DeleteAdminRoleModuleAccess(AdminRoleModuleAccess item)
        {
            IBaseEntityResponse<AdminRoleModuleAccess> entityResponse = new BaseEntityResponse<AdminRoleModuleAccess>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleModuleAccessBR.DeleteAdminRoleModuleAccessValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleModuleAccessDataProvider.DeleteAdminRoleModuleAccess(item);
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

        /// <summary>
        /// Select all record from AdminRoleModuleAccess table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetBySearch(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleModuleAccess> AdminRoleModuleAccessCollection = new BaseEntityCollectionResponse<AdminRoleModuleAccess>();
            try
            {
                if (_adminRoleModuleAccessDataProvider != null)
                {
                    AdminRoleModuleAccessCollection = _adminRoleModuleAccessDataProvider.GetAdminRoleModuleAccessBySearch(searchRequest);
                }
                else
                {
                    AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleModuleAccessCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleModuleAccessCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleModuleAccessCollection;
        }


        /// <summary>
        /// Select a record from AdminRoleModuleAccess table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleModuleAccess> SelectByID(AdminRoleModuleAccess item)
        {

            IBaseEntityResponse<AdminRoleModuleAccess> entityResponse = new BaseEntityResponse<AdminRoleModuleAccess>();
            try
            {
                entityResponse = _adminRoleModuleAccessDataProvider.GetAdminRoleModuleAccessByID(item);
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
        /// Select a record from VwAdminSnPostsRoleMaster view by AdminRoleMasterID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleModuleAccess> SelectByAdminRoleMasterID(AdminRoleModuleAccess item)
        {

            IBaseEntityResponse<AdminRoleModuleAccess> entityResponse = new BaseEntityResponse<AdminRoleModuleAccess>();
            try
            {
                entityResponse = _adminRoleModuleAccessDataProvider.GetVwAdminSnPostsRoleMasterDetalisByID(item);
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


        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAccessibleCentreListByID(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleModuleAccess> AdminRoleModuleAccessCollection = new BaseEntityCollectionResponse<AdminRoleModuleAccess>();
            try
            {
                if (_adminRoleModuleAccessDataProvider != null)
                {
                    AdminRoleModuleAccessCollection = _adminRoleModuleAccessDataProvider.GetAccessibleCentreListByID(searchRequest);
                }
                else
                {
                    AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleModuleAccessCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleModuleAccessCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleModuleAccessCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetEntityByID(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleModuleAccess> AdminRoleModuleAccessCollection = new BaseEntityCollectionResponse<AdminRoleModuleAccess>();
            try
            {
                if (_adminRoleModuleAccessDataProvider != null)
                {
                    AdminRoleModuleAccessCollection = _adminRoleModuleAccessDataProvider.GetEntityByID(searchRequest);
                }
                else
                {
                    AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleModuleAccessCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleModuleAccessCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleModuleAccessCollection;
        }


        public IBaseEntityCollectionResponse<AdminRoleModuleAccess> GetAdminEntityInduvidualListBySearch(AdminRoleModuleAccessSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleModuleAccess> AdminRoleModuleAccessCollection = new BaseEntityCollectionResponse<AdminRoleModuleAccess>();
            try
            {
                if (_adminRoleModuleAccessDataProvider != null)
                {
                    AdminRoleModuleAccessCollection = _adminRoleModuleAccessDataProvider.GetAdminEntityInduvidualListBySearch(searchRequest);
                }
                else
                {
                    AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleModuleAccessCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleModuleAccessCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleModuleAccessCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleModuleAccessCollection;
        }
        
    }


}
