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
    public class OrganisationSubjectTypeMasterBA : IOrganisationSubjectTypeMasterBA
    {
        IOrganisationSubjectTypeMasterDataProvider _organisationSubjectTypeMasterDataProvider;
        IOrganisationSubjectTypeMasterBR _organisationSubjectTypeMasterBR;
        private ILogger _logException;
        public OrganisationSubjectTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSubjectTypeMasterBR = new OrganisationSubjectTypeMasterBR();
            _organisationSubjectTypeMasterDataProvider = new OrganisationSubjectTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSubjectTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> InsertOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectTypeMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectTypeMasterBR.InsertOrganisationSubjectTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectTypeMasterDataProvider.InsertOrganisationSubjectTypeMaster(item);
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
        /// Update a specific record  of OrganisationSubjectTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> UpdateOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectTypeMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectTypeMasterBR.UpdateOrganisationSubjectTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectTypeMasterDataProvider.UpdateOrganisationSubjectTypeMaster(item);
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
        /// Delete a selected record from OrganisationSubjectTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> DeleteOrganisationSubjectTypeMaster(OrganisationSubjectTypeMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectTypeMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectTypeMasterBR.DeleteOrganisationSubjectTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectTypeMasterDataProvider.DeleteOrganisationSubjectTypeMaster(item);
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
        /// Select all record from OrganisationSubjectTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetBySearch(OrganisationSubjectTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> OrganisationSubjectTypeMasterCollection = new BaseEntityCollectionResponse<OrganisationSubjectTypeMaster>();
            try
            {
                if (_organisationSubjectTypeMasterDataProvider != null)
                    OrganisationSubjectTypeMasterCollection = _organisationSubjectTypeMasterDataProvider.GetOrganisationSubjectTypeMasterBySearch(searchRequest);
                else
                {
                    OrganisationSubjectTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectTypeMasterCollection;
        }


        /// <summary>
        /// Select all record from OrganisationSubjectTypeMaster table with search List parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> GetBySubjectTypeMaterList(OrganisationSubjectTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectTypeMaster> OrganisationSubjectTypeMasterCollection = new BaseEntityCollectionResponse<OrganisationSubjectTypeMaster>();
            try
            {
                if (_organisationSubjectTypeMasterDataProvider != null)
                    OrganisationSubjectTypeMasterCollection = _organisationSubjectTypeMasterDataProvider.GetOrganisationSubjectTypeMasterBySearchList(searchRequest);
                else
                {
                    OrganisationSubjectTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectTypeMasterCollection;
        }

        /// <summary>
        /// Select a record from OrganisationSubjectTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectTypeMaster> SelectByID(OrganisationSubjectTypeMaster item)
        {
            IBaseEntityResponse<OrganisationSubjectTypeMaster> entityResponse = new BaseEntityResponse<OrganisationSubjectTypeMaster>();
            try
            {
                entityResponse = _organisationSubjectTypeMasterDataProvider.GetOrganisationSubjectTypeMasterByID(item);
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
