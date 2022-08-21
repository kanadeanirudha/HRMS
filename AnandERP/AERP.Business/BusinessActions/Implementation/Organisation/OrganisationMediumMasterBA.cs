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
    public class OrganisationMediumMasterBA : IOrganisationMediumMasterBA
    {
        IOrganisationMediumMasterDataProvider _organisationMediumMasterDataProvider;
        IOrganisationMediumMasterBR _organisationMediumMasterBR;
        private ILogger _logException;
        public OrganisationMediumMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationMediumMasterBR = new OrganisationMediumMasterBR();
            _organisationMediumMasterDataProvider = new OrganisationMediumMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationMediumMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMediumMaster> InsertOrganisationMediumMaster(OrganisationMediumMaster item)
        {
            IBaseEntityResponse<OrganisationMediumMaster> entityResponse = new BaseEntityResponse<OrganisationMediumMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationMediumMasterBR.InsertOrganisationMediumMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationMediumMasterDataProvider.InsertOrganisationMediumMaster(item);
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
        /// Update a specific record  of OrganisationMediumMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMediumMaster> UpdateOrganisationMediumMaster(OrganisationMediumMaster item)
        {
            IBaseEntityResponse<OrganisationMediumMaster> entityResponse = new BaseEntityResponse<OrganisationMediumMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationMediumMasterBR.UpdateOrganisationMediumMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationMediumMasterDataProvider.UpdateOrganisationMediumMaster(item);
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
        /// Delete a selected record from OrganisationMediumMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMediumMaster> DeleteOrganisationMediumMaster(OrganisationMediumMaster item)
        {
            IBaseEntityResponse<OrganisationMediumMaster> entityResponse = new BaseEntityResponse<OrganisationMediumMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationMediumMasterBR.DeleteOrganisationMediumMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationMediumMasterDataProvider.DeleteOrganisationMediumMaster(item);
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
        /// Select all record from OrganisationMediumMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationMediumMaster> GetBySearch(OrganisationMediumMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMediumMaster> OrganisationMediumMasterCollection = new BaseEntityCollectionResponse<OrganisationMediumMaster>();
            try
            {
                if (_organisationMediumMasterDataProvider != null)
                    OrganisationMediumMasterCollection = _organisationMediumMasterDataProvider.GetOrganisationMediumMasterBySearch(searchRequest);
                else
                {
                    OrganisationMediumMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationMediumMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationMediumMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationMediumMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationMediumMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationMediumMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationMediumMaster> SelectByID(OrganisationMediumMaster item)
        {
            IBaseEntityResponse<OrganisationMediumMaster> entityResponse = new BaseEntityResponse<OrganisationMediumMaster>();
            try
            {
                entityResponse = _organisationMediumMasterDataProvider.GetOrganisationMediumMasterByID(item);
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
        /// Select all record from OrganisationMediumMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationMediumMaster> GetBySearchList(OrganisationMediumMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationMediumMaster> MediumMasterCollection = new BaseEntityCollectionResponse<OrganisationMediumMaster>();
            try
            {
                if (_organisationMediumMasterDataProvider != null)
                {
                    MediumMasterCollection = _organisationMediumMasterDataProvider.GetOrganisationMediumMasterGetBySearchList(searchRequest);
                }
                else
                {
                    MediumMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    MediumMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                MediumMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                MediumMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return MediumMasterCollection;
        }

    }
}
