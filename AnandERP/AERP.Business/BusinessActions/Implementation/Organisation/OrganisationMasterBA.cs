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
    public class OrganisationMasterBA : IOrganisationMasterBA
    {
        IOrganisationMasterDataProvider _organisationMasterDataProvider;
        IOrganisationMasterBR _organisationMasterBR;
        private ILogger _logException;
        public OrganisationMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationMasterBR = new OrganisationMasterBR();
            _organisationMasterDataProvider = new OrganisationMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMaster> InsertOrganisationMaster(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> entityResponse = new BaseEntityResponse<OrganisationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationMasterBR.InsertOrganisationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationMasterDataProvider.InsertOrganisationMaster(item);
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
        /// Update a specific record  of OrganisationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMaster> UpdateOrganisationMaster(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> entityResponse = new BaseEntityResponse<OrganisationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationMasterBR.UpdateOrganisationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationMasterDataProvider.UpdateOrganisationMaster(item);
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
        /// Delete a selected record from OrganisationMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMaster> DeleteOrganisationMaster(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> entityResponse = new BaseEntityResponse<OrganisationMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationMasterBR.DeleteOrganisationMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationMasterDataProvider.DeleteOrganisationMaster(item);
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
        /// Select all record from OrganisationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationMaster> GetBySearch(OrganisationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMaster> OrganisationMasterCollection = new BaseEntityCollectionResponse<OrganisationMaster>();
            try
            {
                if (_organisationMasterDataProvider != null)
                    OrganisationMasterCollection = _organisationMasterDataProvider.GetOrganisationMasterBySearch(searchRequest);
                else
                {
                    OrganisationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationMasterCollection;
        }
        /// <summary>
        /// Select all record from OrganisationMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationMaster> GetBySearchList(OrganisationMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMaster> OrganisationMasterCollection = new BaseEntityCollectionResponse<OrganisationMaster>();
            try
            {
                if (_organisationMasterDataProvider != null)
                    OrganisationMasterCollection = _organisationMasterDataProvider.GetOrganisationMasterGetBySearchList(searchRequest);
                else
                {
                    OrganisationMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMaster> SelectByID(OrganisationMaster item)
        {
            IBaseEntityResponse<OrganisationMaster> entityResponse = new BaseEntityResponse<OrganisationMaster>();
            try
            {
                entityResponse = _organisationMasterDataProvider.GetOrganisationMasterByID(item);
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
