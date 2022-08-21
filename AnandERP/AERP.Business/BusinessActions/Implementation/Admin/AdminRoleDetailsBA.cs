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
    public class AdminRoleDetailsBA : IAdminRoleDetailsBA
    {
        IAdminRoleDetailsDataProvider _adminRoleDetailsDataProvider;
        IAdminRoleDetailsBR _adminRoleDetailsBR;
        private ILogger _logException;

        public AdminRoleDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminRoleDetailsBR = new AdminRoleDetailsBR();
            _adminRoleDetailsDataProvider = new AdminRoleDetailsDataProvider();
        }

        /// <summary>
        /// Create new record of AdminRoleDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>       
        public IBaseEntityResponse<AdminRoleDetails> InsertAdminRoleDetails(AdminRoleDetails item)
        {
            IBaseEntityResponse<AdminRoleDetails> entityResponse = new BaseEntityResponse<AdminRoleDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleDetailsBR.InsertAdminRoleDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleDetailsDataProvider.InsertAdminRoleDetails(item);
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
        /// Update a specific record of AdminRoleDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleDetails> UpdateAdminRoleDetails(AdminRoleDetails item)
        {
            IBaseEntityResponse<AdminRoleDetails> entityResponse = new BaseEntityResponse<AdminRoleDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleDetailsBR.UpdateAdminRoleDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleDetailsDataProvider.UpdateAdminRoleDetails(item);
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
        /// Delete a selected record from AdminRoleDetails.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleDetails> DeleteAdminRoleDetails(AdminRoleDetails item)
        {
            IBaseEntityResponse<AdminRoleDetails> entityResponse = new BaseEntityResponse<AdminRoleDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleDetailsBR.DeleteAdminRoleDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleDetailsDataProvider.DeleteAdminRoleDetails(item);
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
        /// Select all record from AdminRoleDetails table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleDetails> GetBySearch(AdminRoleDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleDetails> adminRoleDetailsCollection = new BaseEntityCollectionResponse<AdminRoleDetails>();
            try
            {
                if (_adminRoleDetailsDataProvider != null)
                {
                    adminRoleDetailsCollection = _adminRoleDetailsDataProvider.GetAdminRoleDetailsBySearch(searchRequest);
                }
                else
                {
                    adminRoleDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    adminRoleDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                adminRoleDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                adminRoleDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return adminRoleDetailsCollection;
        }


        /// <summary>
        /// Select a record from AdminRoleDetails table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleDetails> SelectByID(AdminRoleDetails item)
        {

            IBaseEntityResponse<AdminRoleDetails> entityResponse = new BaseEntityResponse<AdminRoleDetails>();
            try
            {
                entityResponse = _adminRoleDetailsDataProvider.GetAdminRoleDetailsByID(item);
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
