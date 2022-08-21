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
    public class OrganisationSubjectMasterBA : IOrganisationSubjectMasterBA
    {
        IOrganisationSubjectMasterDataProvider _organisationSubjectMasterDataProvider;
        IOrganisationSubjectMasterBR _organisationSubjectMasterBR;
        private ILogger _logException;
        public OrganisationSubjectMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSubjectMasterBR = new OrganisationSubjectMasterBR();
            _organisationSubjectMasterDataProvider = new OrganisationSubjectMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSubjectMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectMaster> InsertOrganisationSubjectMaster(OrganisationSubjectMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectMasterBR.InsertOrganisationSubjectMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectMasterDataProvider.InsertOrganisationSubjectMaster(item);
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
        /// Update a specific record  of OrganisationSubjectMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectMaster> UpdateOrganisationSubjectMaster(OrganisationSubjectMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectMasterBR.UpdateOrganisationSubjectMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectMasterDataProvider.UpdateOrganisationSubjectMaster(item);
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
        /// Delete a selected record from OrganisationSubjectMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectMaster> DeleteOrganisationSubjectMaster(OrganisationSubjectMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectMasterBR.DeleteOrganisationSubjectMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectMasterDataProvider.DeleteOrganisationSubjectMaster(item);
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
        /// Select all record from OrganisationSubjectMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetBySearch(OrganisationSubjectMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectMaster> OrganisationSubjectMasterCollection = new BaseEntityCollectionResponse<OrganisationSubjectMaster>();
            try
            {
                if (_organisationSubjectMasterDataProvider != null)
                    OrganisationSubjectMasterCollection = _organisationSubjectMasterDataProvider.GetOrganisationSubjectMasterBySearch(searchRequest);
                else
                {
                    OrganisationSubjectMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectMasterCollection;
        }

        /// <summary>
        /// Select all record from OrganisationSubjectMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetSubjectList(OrganisationSubjectMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectMaster> OrganisationSubjectMasterCollection = new BaseEntityCollectionResponse<OrganisationSubjectMaster>();
            try
            {
                if (_organisationSubjectMasterDataProvider != null)
                    OrganisationSubjectMasterCollection = _organisationSubjectMasterDataProvider.GetSubjectList(searchRequest);
                else
                {
                    OrganisationSubjectMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectMasterCollection;
        }        
        /// <summary>
        /// Select a record from OrganisationSubjectMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectMaster> SelectByID(OrganisationSubjectMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectMaster>();
            try
            {
                entityResponse = _organisationSubjectMasterDataProvider.GetOrganisationSubjectMasterByID(item);
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
        /// Select all record from OrganisationSubjectMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectMaster> GetBySearchList(OrganisationSubjectMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectMaster> OrganisationSubjectMasterCollection = new BaseEntityCollectionResponse<OrganisationSubjectMaster>();
            try
            {
                if (_organisationSubjectMasterDataProvider != null)
                    OrganisationSubjectMasterCollection = _organisationSubjectMasterDataProvider.GetOrganisationSubjectMasterBySearchList(searchRequest);
                else
                {
                    OrganisationSubjectMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectMasterCollection;
        }
    }
}
