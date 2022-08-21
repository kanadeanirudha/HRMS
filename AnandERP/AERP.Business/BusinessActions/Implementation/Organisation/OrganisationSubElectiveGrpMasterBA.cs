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
    public class OrganisationSubElectiveGrpMasterBA : IOrganisationSubElectiveGrpMasterBA
    {
        IOrganisationSubElectiveGrpMasterDataProvider _organisationSubElectiveGrpMasterDataProvider;
        IOrganisationSubElectiveGrpMasterBR _organisationSubElectiveGrpMasterBR;
        private ILogger _logException;
        public OrganisationSubElectiveGrpMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSubElectiveGrpMasterBR = new OrganisationSubElectiveGrpMasterBR();
            _organisationSubElectiveGrpMasterDataProvider = new OrganisationSubElectiveGrpMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSubElectiveGrpMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> InsertOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationSubElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubElectiveGrpMasterBR.InsertOrganisationSubElectiveGrpMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubElectiveGrpMasterDataProvider.InsertOrganisationSubElectiveGrpMaster(item);
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
        /// Update a specific record  of OrganisationSubElectiveGrpMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> UpdateOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationSubElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubElectiveGrpMasterBR.UpdateOrganisationSubElectiveGrpMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubElectiveGrpMasterDataProvider.UpdateOrganisationSubElectiveGrpMaster(item);
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
        /// Delete a selected record from OrganisationSubElectiveGrpMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> DeleteOrganisationSubElectiveGrpMaster(OrganisationSubElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationSubElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubElectiveGrpMasterBR.DeleteOrganisationSubElectiveGrpMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubElectiveGrpMasterDataProvider.DeleteOrganisationSubElectiveGrpMaster(item);
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
        /// Select all record from OrganisationSubElectiveGrpMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster> GetBySearch(OrganisationSubElectiveGrpMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster> OrganisationSubElectiveGrpMasterCollection = new BaseEntityCollectionResponse<OrganisationSubElectiveGrpMaster>();
            try
            {
                if (_organisationSubElectiveGrpMasterDataProvider != null)
                    OrganisationSubElectiveGrpMasterCollection = _organisationSubElectiveGrpMasterDataProvider.GetOrganisationSubElectiveGrpMasterBySearch(searchRequest);
                else
                {
                    OrganisationSubElectiveGrpMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubElectiveGrpMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubElectiveGrpMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubElectiveGrpMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubElectiveGrpMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSubElectiveGrpMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubElectiveGrpMaster> SelectByID(OrganisationSubElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationSubElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationSubElectiveGrpMaster>();
            try
            {
                entityResponse = _organisationSubElectiveGrpMasterDataProvider.GetOrganisationSubElectiveGrpMasterByID(item);
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
