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
    public class AdminMenuApplicableBA : IAdminMenuApplicableBA
    {
        IAdminMenuApplicableDataProvider _adminMenuApplicableDataProvider;
        IAdminMenuApplicableBR _adminMenuApplicableBR;
        private ILogger _logException;

        public AdminMenuApplicableBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _adminMenuApplicableBR = new AdminMenuApplicableBR();
            _adminMenuApplicableDataProvider = new AdminMenuApplicableDataProvider();
        }

        /// <summary>
        /// Create new record of AdminMenuApplicable.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminMenuApplicable> InsertAdminMenuApplicable(AdminMenuApplicable item)
        {
            IBaseEntityResponse<AdminMenuApplicable> entityResponse = new BaseEntityResponse<AdminMenuApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminMenuApplicableBR.InsertAdminMenuApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminMenuApplicableDataProvider.InsertAdminMenuApplicable(item);
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
        /// Update a specific record of AdminMenuApplicable.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminMenuApplicable> UpdateAdminMenuApplicable(AdminMenuApplicable item)
        {
            IBaseEntityResponse<AdminMenuApplicable> entityResponse = new BaseEntityResponse<AdminMenuApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminMenuApplicableBR.UpdateAdminMenuApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminMenuApplicableDataProvider.UpdateAdminMenuApplicable(item);
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
        /// Delete a selected record from AdminMenuApplicable.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<AdminMenuApplicable> DeleteAdminMenuApplicable(AdminMenuApplicable item)
        {
            IBaseEntityResponse<AdminMenuApplicable> entityResponse = new BaseEntityResponse<AdminMenuApplicable>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _adminMenuApplicableBR.DeleteAdminMenuApplicableValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _adminMenuApplicableDataProvider.DeleteAdminMenuApplicable(item);
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
        /// Select all record from AdminMenuApplicable table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<AdminMenuApplicable> GetBySearch(AdminMenuApplicableSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<AdminMenuApplicable> AdminMenuApplicableCollection = new BaseEntityCollectionResponse<AdminMenuApplicable>();
            try
            {
                if (_adminMenuApplicableDataProvider != null)
                {
                    AdminMenuApplicableCollection = _adminMenuApplicableDataProvider.GetAdminMenuApplicableBySearch(searchRequest);
                }
                else
                {
                    AdminMenuApplicableCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    AdminMenuApplicableCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                AdminMenuApplicableCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                AdminMenuApplicableCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return AdminMenuApplicableCollection;
        }

    }
}
