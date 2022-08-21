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
namespace AMS.Business.BusinessAction
{
    public class OrganisationSessionCryrAllocationBA : IOrganisationSessionCryrAllocationBA
    {
        IOrganisationSessionCryrAllocationDataProvider _organisationSessionCryrAllocationDataProvider;
        IOrganisationSessionCryrAllocationBR _organisationSessionCryrAllocationBR;
        private ILogger _logException;
        public OrganisationSessionCryrAllocationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSessionCryrAllocationBR = new OrganisationSessionCryrAllocationBR();
            _organisationSessionCryrAllocationDataProvider = new OrganisationSessionCryrAllocationDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSessionCryrAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> InsertOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> entityResponse = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSessionCryrAllocationBR.InsertOrganisationSessionCryrAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSessionCryrAllocationDataProvider.InsertOrganisationSessionCryrAllocation(item);
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
        /// Update a specific record  of OrganisationSessionCryrAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> UpdateOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> entityResponse = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSessionCryrAllocationBR.UpdateOrganisationSessionCryrAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSessionCryrAllocationDataProvider.UpdateOrganisationSessionCryrAllocation(item);
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
        /// Delete a selected record from OrganisationSessionCryrAllocation.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> DeleteOrganisationSessionCryrAllocation(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> entityResponse = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSessionCryrAllocationBR.DeleteOrganisationSessionCryrAllocationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSessionCryrAllocationDataProvider.DeleteOrganisationSessionCryrAllocation(item);
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
        /// Select all record from OrganisationSessionCryrAllocation table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> GetBySearch(OrganisationSessionCryrAllocationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSessionCryrAllocation> OrganisationSessionCryrAllocationCollection = new BaseEntityCollectionResponse<OrganisationSessionCryrAllocation>();
            try
            {
                if (_organisationSessionCryrAllocationDataProvider != null)
                    OrganisationSessionCryrAllocationCollection = _organisationSessionCryrAllocationDataProvider.GetOrganisationSessionCryrAllocationBySearch(searchRequest);
                else
                {
                    OrganisationSessionCryrAllocationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSessionCryrAllocationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSessionCryrAllocationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSessionCryrAllocationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSessionCryrAllocationCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSessionCryrAllocation table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> SelectByID(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> entityResponse = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
            try
            {
                entityResponse = _organisationSessionCryrAllocationDataProvider.GetOrganisationSessionCryrAllocationByID(item);
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
        /// Select a record from OrganisationSessionCryrAllocation table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSessionCryrAllocation> GetCurrentSession(OrganisationSessionCryrAllocation item)
        {
            IBaseEntityResponse<OrganisationSessionCryrAllocation> entityResponse = new BaseEntityResponse<OrganisationSessionCryrAllocation>();
            try
            {
                entityResponse = _organisationSessionCryrAllocationDataProvider.GetCurrentSession(item);
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
