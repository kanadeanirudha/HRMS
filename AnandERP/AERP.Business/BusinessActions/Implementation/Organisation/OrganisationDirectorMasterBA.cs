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
    public class OrganisationDirectorMasterBA : IOrganisationDirectorMasterBA
    {
        IOrganisationDirectorMasterDataProvider _organisationDirectorMasterDataProvider;
        IOrganisationDirectorMasterBR _organisationDirectorMasterBR;
        private ILogger _logException;
        public OrganisationDirectorMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationDirectorMasterBR = new OrganisationDirectorMasterBR();
            _organisationDirectorMasterDataProvider = new OrganisationDirectorMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationDirectorMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDirectorMaster> InsertOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> entityResponse = new BaseEntityResponse<OrganisationDirectorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationDirectorMasterBR.InsertOrganisationDirectorMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationDirectorMasterDataProvider.InsertOrganisationDirectorMaster(item);
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
        /// Update a specific record  of OrganisationDirectorMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDirectorMaster> UpdateOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> entityResponse = new BaseEntityResponse<OrganisationDirectorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationDirectorMasterBR.UpdateOrganisationDirectorMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationDirectorMasterDataProvider.UpdateOrganisationDirectorMaster(item);
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
        /// Delete a selected record from OrganisationDirectorMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDirectorMaster> DeleteOrganisationDirectorMaster(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> entityResponse = new BaseEntityResponse<OrganisationDirectorMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationDirectorMasterBR.DeleteOrganisationDirectorMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationDirectorMasterDataProvider.DeleteOrganisationDirectorMaster(item);
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
        /// Select all record from OrganisationDirectorMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetBySearch(OrganisationDirectorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDirectorMaster> OrganisationDirectorMasterCollection = new BaseEntityCollectionResponse<OrganisationDirectorMaster>();
            try
            {
                if (_organisationDirectorMasterDataProvider != null)
                    OrganisationDirectorMasterCollection = _organisationDirectorMasterDataProvider.GetOrganisationDirectorMasterBySearch(searchRequest);
                else
                {
                    OrganisationDirectorMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDirectorMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDirectorMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationDirectorMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDirectorMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationDirectorMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDirectorMaster> SelectByID(OrganisationDirectorMaster item)
        {
            IBaseEntityResponse<OrganisationDirectorMaster> entityResponse = new BaseEntityResponse<OrganisationDirectorMaster>();
            try
            {
                entityResponse = _organisationDirectorMasterDataProvider.GetOrganisationDirectorMasterByID(item);
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
        /// Select all record from OrganisationMemberMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationDirectorMaster> GetUserEntityCentrewiseSearchList(OrganisationDirectorMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDirectorMaster> OrganisationDirectorMasterCollection = new BaseEntityCollectionResponse<OrganisationDirectorMaster>();
            try
            {
                if (_organisationDirectorMasterDataProvider != null)
                    OrganisationDirectorMasterCollection = _organisationDirectorMasterDataProvider.GetUserEntityCentrewiseSearchList(searchRequest);
                else
                {
                    OrganisationDirectorMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDirectorMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDirectorMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationDirectorMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDirectorMasterCollection;
        }
    }
}
