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
    public class OrganisationSectionMasterBA : IOrganisationSectionMasterBA
    {
        IOrganisationSectionMasterDataProvider _organisationSectionMasterDataProvider;
        IOrganisationSectionMasterBR _organisationSectionMasterBR;
        private ILogger _logException;
        public OrganisationSectionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSectionMasterBR = new OrganisationSectionMasterBR();
            _organisationSectionMasterDataProvider = new OrganisationSectionMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSectionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionMaster> InsertOrganisationSectionMaster(OrganisationSectionMaster item)
        {
            IBaseEntityResponse<OrganisationSectionMaster> entityResponse = new BaseEntityResponse<OrganisationSectionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionMasterBR.InsertOrganisationSectionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionMasterDataProvider.InsertOrganisationSectionMaster(item);
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
        /// Update a specific record  of OrganisationSectionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionMaster> UpdateOrganisationSectionMaster(OrganisationSectionMaster item)
        {
            IBaseEntityResponse<OrganisationSectionMaster> entityResponse = new BaseEntityResponse<OrganisationSectionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionMasterBR.UpdateOrganisationSectionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionMasterDataProvider.UpdateOrganisationSectionMaster(item);
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
        /// Delete a selected record from OrganisationSectionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionMaster> DeleteOrganisationSectionMaster(OrganisationSectionMaster item)
        {
            IBaseEntityResponse<OrganisationSectionMaster> entityResponse = new BaseEntityResponse<OrganisationSectionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionMasterBR.DeleteOrganisationSectionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionMasterDataProvider.DeleteOrganisationSectionMaster(item);
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
        /// Select all record from OrganisationSectionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionMaster> GetBySearch(OrganisationSectionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionMaster> OrganisationSectionMasterCollection = new BaseEntityCollectionResponse<OrganisationSectionMaster>();
            try
            {
                if (_organisationSectionMasterDataProvider != null)
                    OrganisationSectionMasterCollection = _organisationSectionMasterDataProvider.GetOrganisationSectionMasterBySearch(searchRequest);
                else
                {
                    OrganisationSectionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSectionMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionMaster> SelectByID(OrganisationSectionMaster item)
        {
            IBaseEntityResponse<OrganisationSectionMaster> entityResponse = new BaseEntityResponse<OrganisationSectionMaster>();
            try
            {
                entityResponse = _organisationSectionMasterDataProvider.GetOrganisationSectionMasterByID(item);
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
        /// Select all record from OrganisationSectionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionMaster> GetBySearchList(OrganisationSectionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionMaster> OrganisationSectionMasterCollection = new BaseEntityCollectionResponse<OrganisationSectionMaster>();
            try
            {
                if (_organisationSectionMasterDataProvider != null)
                    OrganisationSectionMasterCollection = _organisationSectionMasterDataProvider.GetOrganisationSectionMasterBySearchList(searchRequest);
                else
                {
                    OrganisationSectionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionMasterCollection;
        }
    }
}
