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
    public class OrganisationElectiveGrpMasterBA : IOrganisationElectiveGrpMasterBA
    {
        IOrganisationElectiveGrpMasterDataProvider _organisationElectiveGrpMasterDataProvider;
        IOrganisationElectiveGrpMasterBR _organisationElectiveGrpMasterBR;
        private ILogger _logException;
        public OrganisationElectiveGrpMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationElectiveGrpMasterBR = new OrganisationElectiveGrpMasterBR();
            _organisationElectiveGrpMasterDataProvider = new OrganisationElectiveGrpMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationElectiveGrpMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> InsertOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationElectiveGrpMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationElectiveGrpMasterBR.InsertOrganisationElectiveGrpMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationElectiveGrpMasterDataProvider.InsertOrganisationElectiveGrpMaster(item);
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
        /// Update a specific record  of OrganisationElectiveGrpMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> UpdateOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationElectiveGrpMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationElectiveGrpMasterBR.UpdateOrganisationElectiveGrpMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationElectiveGrpMasterDataProvider.UpdateOrganisationElectiveGrpMaster(item);
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
        /// Delete a selected record from OrganisationElectiveGrpMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> DeleteOrganisationElectiveGrpMaster(OrganisationElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationElectiveGrpMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationElectiveGrpMasterBR.DeleteOrganisationElectiveGrpMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationElectiveGrpMasterDataProvider.DeleteOrganisationElectiveGrpMaster(item);
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
        /// Select all record from OrganisationElectiveGrpMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationElectiveGrpMaster> GetBySearch(OrganisationElectiveGrpMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationElectiveGrpMaster> OrganisationElectiveGrpMasterCollection = new BaseEntityCollectionResponse<OrganisationElectiveGrpMaster>();
            try
            {
                if (_organisationElectiveGrpMasterDataProvider != null)
                    OrganisationElectiveGrpMasterCollection = _organisationElectiveGrpMasterDataProvider.GetOrganisationElectiveGrpMasterBySearch(searchRequest);
                else
                {
                    OrganisationElectiveGrpMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationElectiveGrpMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationElectiveGrpMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationElectiveGrpMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationElectiveGrpMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationElectiveGrpMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationElectiveGrpMaster> SelectByID(OrganisationElectiveGrpMaster item)
        {
            IBaseEntityResponse<OrganisationElectiveGrpMaster> entityResponse = new BaseEntityResponse<OrganisationElectiveGrpMaster>();
            try
            {
                entityResponse = _organisationElectiveGrpMasterDataProvider.GetOrganisationElectiveGrpMasterByID(item);
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
