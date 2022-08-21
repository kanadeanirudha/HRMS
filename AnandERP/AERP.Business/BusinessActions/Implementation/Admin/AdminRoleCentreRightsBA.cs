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
    public class AdminRoleCentreRightsBA : IAdminRoleCentreRightsBA
    {
        IAdminRoleCentreRightsDataProvider _adminRoleCentreRightsDataProvider;
        IAdminRoleCentreRightsBR _adminRoleCentreRightsBR;
        private ILogger _logException;

        public AdminRoleCentreRightsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminRoleCentreRightsBR = new AdminRoleCentreRightsBR();
            _adminRoleCentreRightsDataProvider = new AdminRoleCentreRightsDataProvider();
        }

        /// <summary>
        /// Create new record of AdminRoleCentreRights.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleCentreRights> InsertAdminRoleCentreRights(AdminRoleCentreRights item)
        {
            IBaseEntityResponse<AdminRoleCentreRights> entityResponse = new BaseEntityResponse<AdminRoleCentreRights>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleCentreRightsBR.InsertAdminRoleCentreRightsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleCentreRightsDataProvider.InsertAdminRoleCentreRights(item);
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
        /// Update a specific record of AdminRoleCentreRights.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleCentreRights> UpdateAdminRoleCentreRights(AdminRoleCentreRights item)
        {
            IBaseEntityResponse<AdminRoleCentreRights> entityResponse = new BaseEntityResponse<AdminRoleCentreRights>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleCentreRightsBR.UpdateAdminRoleCentreRightsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleCentreRightsDataProvider.UpdateAdminRoleCentreRights(item);
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
        /// Delete a selected record from AdminRoleCentreRights.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleCentreRights> DeleteAdminRoleCentreRights(AdminRoleCentreRights item)
        {
            IBaseEntityResponse<AdminRoleCentreRights> entityResponse = new BaseEntityResponse<AdminRoleCentreRights>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminRoleCentreRightsBR.DeleteAdminRoleCentreRightsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminRoleCentreRightsDataProvider.DeleteAdminRoleCentreRights(item);
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
        /// Select all record from AdminRoleCentreRights table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleCentreRights> GetBySearch(AdminRoleCentreRightsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminRoleCentreRights> AdminRoleCentreRightsCollection = new BaseEntityCollectionResponse<AdminRoleCentreRights>();
            try
            {
                if (_adminRoleCentreRightsDataProvider != null)
                {
                    AdminRoleCentreRightsCollection = _adminRoleCentreRightsDataProvider.GetAdminRoleCentreRightsBySearch(searchRequest);
                }
                else
                {
                    AdminRoleCentreRightsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminRoleCentreRightsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminRoleCentreRightsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleCentreRightsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleCentreRightsCollection;
        }


        /// <summary>
        /// Select a record from AdminRoleCentreRights table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminRoleCentreRights> SelectByID(AdminRoleCentreRights item)
        {

            IBaseEntityResponse<AdminRoleCentreRights> entityResponse = new BaseEntityResponse<AdminRoleCentreRights>();
            try
            {
                entityResponse = _adminRoleCentreRightsDataProvider.GetAdminRoleCentreRightsByID(item);
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
        /// Select a record from AdminRoleCentreRights table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminRoleCentreRights> GetCentreLevelManagerRights(AdminRoleCentreRightsSearchRequest searchRequest)
        {

            IBaseEntityCollectionResponse<AdminRoleCentreRights> AdminRoleCentreRightsCollection = new BaseEntityCollectionResponse<AdminRoleCentreRights>();
            try
            {
                AdminRoleCentreRightsCollection = _adminRoleCentreRightsDataProvider.GetCentreLevelManagerRights(searchRequest);
            }
            catch (Exception ex)
            {
                AdminRoleCentreRightsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminRoleCentreRightsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminRoleCentreRightsCollection;
        }
        
    }
}
