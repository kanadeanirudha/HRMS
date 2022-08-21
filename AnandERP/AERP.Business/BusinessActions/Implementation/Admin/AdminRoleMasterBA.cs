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
    public class AdminRoleMasterBA : IAdminRoleMasterBA
    {
        IAdminRoleMasterDataProvider _adminRoleMasterDataProvider;
        IAdminRoleMasterBR _adminRoleMasterBR;
        private ILogger _logException;

        public AdminRoleMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminRoleMasterBR = new AdminRoleMasterBR();
            _adminRoleMasterDataProvider = new AdminRoleMasterDataProvider();
        }

        /// <summary>
        /// Create new record of AdminRoleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMaster> InsertAdminRoleMaster(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> entityResponse = new BaseEntityResponse<AdminRoleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleMasterBR.InsertAdminRoleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleMasterDataProvider.InsertAdminRoleMaster(item);
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
        /// Update a specific record of AdminRoleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMaster> UpdateAdminRoleMaster(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> entityResponse = new BaseEntityResponse<AdminRoleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleMasterBR.UpdateAdminRoleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleMasterDataProvider.UpdateAdminRoleMaster(item);
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
        /// Delete a selected record from AdminRoleMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMaster> DeleteAdminRoleMaster(AdminRoleMaster item)
        {
            IBaseEntityResponse<AdminRoleMaster> entityResponse = new BaseEntityResponse<AdminRoleMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleMasterBR.DeleteAdminRoleMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleMasterDataProvider.DeleteAdminRoleMaster(item);
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
        /// Select all record from AdminRoleMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleMaster> GetBySearch(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> AdminRoleMasterCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
            try
            {
                if (_adminRoleMasterDataProvider != null)
                {
                    AdminRoleMasterCollection = _adminRoleMasterDataProvider.GetAdminRoleMasterBySearch(searchRequest);
                }
                else
                {
                    AdminRoleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMasterCollection;
        }


        /// <summary>
        /// Select a record from AdminRoleMaster table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleMaster> SelectByID(AdminRoleMaster item)
        {

            IBaseEntityResponse<AdminRoleMaster> entityResponse = new BaseEntityResponse<AdminRoleMaster>();
            try
            {
                entityResponse = _adminRoleMasterDataProvider.GetAdminRoleMasterByID(item);
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
      
        public IBaseEntityCollectionResponse<AdminRoleMaster> GetBySearchForAdminRoleDetailsBySPD(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> AdminRoleMasterCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
            try
            {
                if (_adminRoleMasterDataProvider != null)
                {
                    AdminRoleMasterCollection = _adminRoleMasterDataProvider.GetAdminRoleMasterBySearchForAdminRoleDetailsBySPD(searchRequest);
                }
                else
                {
                    AdminRoleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMasterCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetCentreRightsByRole(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> AdminRoleMasterCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
            try
            {
                if (_adminRoleMasterDataProvider != null)
                {
                    AdminRoleMasterCollection = _adminRoleMasterDataProvider.GetAdminCentreRightsByRole(searchRequest);
                }
                else
                {
                    AdminRoleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMasterCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetDefaultRoleRightsType(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> AdminRoleMasterCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
            try
            {
                if (_adminRoleMasterDataProvider != null)
                {
                    AdminRoleMasterCollection = _adminRoleMasterDataProvider.GetDefaultRoleRightsType(searchRequest);
                }
                else
                {
                    AdminRoleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMasterCollection;
        }

        public IBaseEntityCollectionResponse<AdminRoleMaster> GetAdminRoleDomainList(AdminRoleMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleMaster> AdminRoleMasterCollection = new BaseEntityCollectionResponse<AdminRoleMaster>();
            try
            {
                if (_adminRoleMasterDataProvider != null)
                {
                    AdminRoleMasterCollection = _adminRoleMasterDataProvider.GetAdminRoleDomainList(searchRequest);
                }
                else
                {
                    AdminRoleMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleMasterCollection;
        }
    }
}
