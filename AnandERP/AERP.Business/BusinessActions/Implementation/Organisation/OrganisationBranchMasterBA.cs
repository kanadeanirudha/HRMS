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
    public class OrganisationBranchMasterBA : IOrganisationBranchMasterBA
    {
        IOrganisationBranchMasterDataProvider _organisationBranchMasterDataProvider;
        IOrganisationBranchMasterBR _organisationBranchMasterBR;
        private ILogger _logException;
        public OrganisationBranchMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationBranchMasterBR = new OrganisationBranchMasterBR();
            _organisationBranchMasterDataProvider = new OrganisationBranchMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationBranchMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchMaster> InsertOrganisationBranchMaster(OrganisationBranchMaster item)
        {
            IBaseEntityResponse<OrganisationBranchMaster> entityResponse = new BaseEntityResponse<OrganisationBranchMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationBranchMasterBR.InsertOrganisationBranchMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationBranchMasterDataProvider.InsertOrganisationBranchMaster(item);
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
        /// Update a specific record  of OrganisationBranchMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchMaster> UpdateOrganisationBranchMaster(OrganisationBranchMaster item)
        {
            IBaseEntityResponse<OrganisationBranchMaster> entityResponse = new BaseEntityResponse<OrganisationBranchMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationBranchMasterBR.UpdateOrganisationBranchMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationBranchMasterDataProvider.UpdateOrganisationBranchMaster(item);
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
        /// Delete a selected record from OrganisationBranchMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchMaster> DeleteOrganisationBranchMaster(OrganisationBranchMaster item)
        {
            IBaseEntityResponse<OrganisationBranchMaster> entityResponse = new BaseEntityResponse<OrganisationBranchMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationBranchMasterBR.DeleteOrganisationBranchMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationBranchMasterDataProvider.DeleteOrganisationBranchMaster(item);
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
        /// Select all record from OrganisationBranchMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBySearch(OrganisationBranchMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationBranchMaster> OrganisationBranchMasterCollection = new BaseEntityCollectionResponse<OrganisationBranchMaster>();
            try
            {
                if (_organisationBranchMasterDataProvider != null)
                    OrganisationBranchMasterCollection = _organisationBranchMasterDataProvider.GetOrganisationBranchMasterBySearch(searchRequest);
                else
                {
                    OrganisationBranchMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationBranchMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationBranchMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationBranchMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationBranchMasterCollection;
        }
        
        /// <summary>
        /// Select all record from OrganisationBranchMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationBranchMaster> GetBranchListRoleWise(OrganisationBranchMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationBranchMaster> OrganisationBranchMasterCollection = new BaseEntityCollectionResponse<OrganisationBranchMaster>();
            try
            {
                if (_organisationBranchMasterDataProvider != null)
                    OrganisationBranchMasterCollection = _organisationBranchMasterDataProvider.GetBranchListRoleWise(searchRequest);
                else
                {
                    OrganisationBranchMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationBranchMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationBranchMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationBranchMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationBranchMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationBranchMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchMaster> SelectByID(OrganisationBranchMaster item)
        {
            IBaseEntityResponse<OrganisationBranchMaster> entityResponse = new BaseEntityResponse<OrganisationBranchMaster>();
            try
            {
                entityResponse = _organisationBranchMasterDataProvider.GetOrganisationBranchMasterByID(item);
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
