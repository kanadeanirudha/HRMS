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
    public class AdminSnPostsBA : IAdminSnPostsBA
    {
        IAdminSnPostsDataProvider _adminSnPostsDataProvider;
        IAdminSnPostsBR _adminSnPostsBR;
        private ILogger _logException;

        public AdminSnPostsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminSnPostsBR = new AdminSnPostsBR();
            _adminSnPostsDataProvider = new AdminSnPostsDataProvider();
        }

        /// <summary>
        /// Create new record of AdminSnPosts.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
       
        public IBaseEntityResponse<AdminSnPosts> InsertAdminSnPosts(AdminSnPosts item)
        {
            IBaseEntityResponse<AdminSnPosts> entityResponse = new BaseEntityResponse<AdminSnPosts>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminSnPostsBR.InsertAdminSnPostsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminSnPostsDataProvider.InsertAdminSnPosts(item);
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
        /// Update a specific record of AdminSnPosts.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminSnPosts> UpdateAdminSnPosts(AdminSnPosts item)
        {
            IBaseEntityResponse<AdminSnPosts> entityResponse = new BaseEntityResponse<AdminSnPosts>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminSnPostsBR.UpdateAdminSnPostsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminSnPostsDataProvider.UpdateAdminSnPosts(item);
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
        /// Delete a selected record from AdminSnPosts.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminSnPosts> DeleteAdminSnPosts(AdminSnPosts item)
        {
            IBaseEntityResponse<AdminSnPosts> entityResponse = new BaseEntityResponse<AdminSnPosts>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminSnPostsBR.DeleteAdminSnPostsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminSnPostsDataProvider.DeleteAdminSnPosts(item);
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
        /// Select all record from AdminSnPosts table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminSnPosts> GetBySearch(AdminSnPostsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminSnPosts> adminSnPostsCollection = new BaseEntityCollectionResponse<AdminSnPosts>();
            try
            {
                if (_adminSnPostsDataProvider != null)
                {
                    adminSnPostsCollection = _adminSnPostsDataProvider.GetAdminSnPostsBySearch(searchRequest);
                }
                else
                {
                    adminSnPostsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    adminSnPostsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                adminSnPostsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                adminSnPostsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return adminSnPostsCollection;
        }

        /// <summary>
        /// Select a record from AdminSnPosts table by CentreCode and DepartmentID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentID(AdminSnPostsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminSnPosts> adminSnPostsCollection = new BaseEntityCollectionResponse<AdminSnPosts>();
            try
            {
                if (_adminSnPostsDataProvider != null)
                {
                    adminSnPostsCollection = _adminSnPostsDataProvider.GetAdminSnPostsBySearchCentreCodeAndDepartmentID(searchRequest);
                }
                else
                {
                    adminSnPostsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    adminSnPostsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                adminSnPostsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                adminSnPostsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return adminSnPostsCollection;
        }

        /// <summary>
        /// Select a record from AdminSnPosts table by CentreCode and DepartmentID for SanctionPostDescription
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminSnPosts> GetBySearchCentreCodeAndDepartmentIDForSPD(AdminSnPostsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminSnPosts> adminSnPostsCollection = new BaseEntityCollectionResponse<AdminSnPosts>();
            try
            {
                if (_adminSnPostsDataProvider != null)
                {
                    adminSnPostsCollection = _adminSnPostsDataProvider.GetAdminSnPostsBySearchCentreCodeAndDepartmentIDForSPD(searchRequest);
                }
                else
                {
                    adminSnPostsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    adminSnPostsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                adminSnPostsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                adminSnPostsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return adminSnPostsCollection;
        }

        /// <summary>
        /// Select a record from AdminSnPosts table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminSnPosts> SelectByID(AdminSnPosts item)
        {

            IBaseEntityResponse<AdminSnPosts> entityResponse = new BaseEntityResponse<AdminSnPosts>();
            try
            {
                entityResponse = _adminSnPostsDataProvider.GetAdminSnPostsByID(item);
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
