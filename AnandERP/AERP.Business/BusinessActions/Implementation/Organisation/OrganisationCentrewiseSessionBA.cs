using AMS.Base.DTO;
using AMS.Business.BusinessRules;
using AMS.Common;
using AMS.DataProvider;
using AMS.DTO;
using AMS.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessActions
{
    public class OrganisationCentrewiseSessionBA : IOrganisationCentrewiseSessionBA
    {
        IOrganisationCentrewiseSessionDataProvider _organisationCentrewiseSessionDataProvider;
        IOrganisationCentrewiseSessionBR _organisationCentrewiseSessionBR;
        private ILogger _logException;
        public OrganisationCentrewiseSessionBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationCentrewiseSessionBR = new OrganisationCentrewiseSessionBR();
            _organisationCentrewiseSessionDataProvider = new OrganisationCentrewiseSessionDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationCentrewiseSession.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseSession> InsertOrganisationCentrewiseSession(OrganisationCentrewiseSession item)
        {
            IBaseEntityResponse<OrganisationCentrewiseSession> entityResponse = new BaseEntityResponse<OrganisationCentrewiseSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseSessionBR.InsertOrganisationCentrewiseSessionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseSessionDataProvider.InsertOrganisationCentrewiseSession(item);
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
        /// Update a specific record  of OrganisationCentrewiseSession.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseSession> UpdateOrganisationCentrewiseSession(OrganisationCentrewiseSession item)
        {
            IBaseEntityResponse<OrganisationCentrewiseSession> entityResponse = new BaseEntityResponse<OrganisationCentrewiseSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseSessionBR.UpdateOrganisationCentrewiseSessionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseSessionDataProvider.UpdateOrganisationCentrewiseSession(item);
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
        /// Delete a selected record from OrganisationCentrewiseSession.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseSession> DeleteOrganisationCentrewiseSession(OrganisationCentrewiseSession item)
        {
            IBaseEntityResponse<OrganisationCentrewiseSession> entityResponse = new BaseEntityResponse<OrganisationCentrewiseSession>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseSessionBR.DeleteOrganisationCentrewiseSessionValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseSessionDataProvider.DeleteOrganisationCentrewiseSession(item);
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
        /// Select all record from OrganisationCentrewiseSession table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetBySearch(OrganisationCentrewiseSessionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCentrewiseSession> OrganisationCentrewiseSessionCollection = new BaseEntityCollectionResponse<OrganisationCentrewiseSession>();
            try
            {
                if (_organisationCentrewiseSessionDataProvider != null)
                    OrganisationCentrewiseSessionCollection = _organisationCentrewiseSessionDataProvider.GetOrganisationCentrewiseSessionBySearch(searchRequest);
                else
                {
                    OrganisationCentrewiseSessionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCentrewiseSessionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCentrewiseSessionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCentrewiseSessionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCentrewiseSessionCollection;
        }
        /// <summary>
        /// Select a record from OrganisationCentrewiseSession table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseSession> SelectByID(OrganisationCentrewiseSession item)
        {
            IBaseEntityResponse<OrganisationCentrewiseSession> entityResponse = new BaseEntityResponse<OrganisationCentrewiseSession>();
            try
            {
                entityResponse = _organisationCentrewiseSessionDataProvider.GetOrganisationCentrewiseSessionByID(item);
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
        /// Select a record from OrganisationCentrewiseSession table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCurrentSession(OrganisationCentrewiseSessionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCentrewiseSession> OrganisationCentrewiseSessionCollection = new BaseEntityCollectionResponse<OrganisationCentrewiseSession>();
            try
            {
                if (_organisationCentrewiseSessionDataProvider != null)
                    OrganisationCentrewiseSessionCollection = _organisationCentrewiseSessionDataProvider.GetCurrentSession(searchRequest);
                else
                {
                    OrganisationCentrewiseSessionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCentrewiseSessionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCentrewiseSessionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCentrewiseSessionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCentrewiseSessionCollection;

        }

        /// <summary>
        /// Select a record from OrganisationCentrewiseSession table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCentrewiseSession> GetCentreWiseSessionListRoleWise(OrganisationCentrewiseSessionSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCentrewiseSession> OrganisationCentrewiseSessionCollection = new BaseEntityCollectionResponse<OrganisationCentrewiseSession>();
            try
            {
                if (_organisationCentrewiseSessionDataProvider != null)
                    OrganisationCentrewiseSessionCollection = _organisationCentrewiseSessionDataProvider.GetCentreWiseSessionListRoleWise(searchRequest);
                else
                {
                    OrganisationCentrewiseSessionCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCentrewiseSessionCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCentrewiseSessionCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCentrewiseSessionCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCentrewiseSessionCollection;

        }
    }
}
