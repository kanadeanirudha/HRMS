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
    public class OrganisationAllotAdmissionMasterBA : IOrganisationAllotAdmissionMasterBA
    {
        IOrganisationAllotAdmissionMasterDataProvider _OrganisationAllotAdmissionMasterDataProvider;
        IOrganisationAllotAdmissionMasterBR _OrganisationAllotAdmissionMasterBR;
        private ILogger _logException;
        public OrganisationAllotAdmissionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OrganisationAllotAdmissionMasterBR = new OrganisationAllotAdmissionMasterBR();
            _OrganisationAllotAdmissionMasterDataProvider = new OrganisationAllotAdmissionMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationAllotAdmissionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> InsertOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item)
        {
            IBaseEntityResponse<OrganisationAllotAdmissionMaster> entityResponse = new BaseEntityResponse<OrganisationAllotAdmissionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrganisationAllotAdmissionMasterBR.InsertOrganisationAllotAdmissionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrganisationAllotAdmissionMasterDataProvider.InsertOrganisationAllotAdmissionMaster(item);
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
        /// Update a specific record  of OrganisationAllotAdmissionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> UpdateOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item)
        {
            IBaseEntityResponse<OrganisationAllotAdmissionMaster> entityResponse = new BaseEntityResponse<OrganisationAllotAdmissionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrganisationAllotAdmissionMasterBR.UpdateOrganisationAllotAdmissionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrganisationAllotAdmissionMasterDataProvider.UpdateOrganisationAllotAdmissionMaster(item);
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
        /// Delete a selected record from OrganisationAllotAdmissionMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> DeleteOrganisationAllotAdmissionMaster(OrganisationAllotAdmissionMaster item)
        {
            IBaseEntityResponse<OrganisationAllotAdmissionMaster> entityResponse = new BaseEntityResponse<OrganisationAllotAdmissionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrganisationAllotAdmissionMasterBR.DeleteOrganisationAllotAdmissionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrganisationAllotAdmissionMasterDataProvider.DeleteOrganisationAllotAdmissionMaster(item);
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
        /// Select all record from OrganisationAllotAdmissionMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetBySearch(OrganisationAllotAdmissionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> OrganisationAllotAdmissionMasterCollection = new BaseEntityCollectionResponse<OrganisationAllotAdmissionMaster>();
            try
            {
                if (_OrganisationAllotAdmissionMasterDataProvider != null)
                    OrganisationAllotAdmissionMasterCollection = _OrganisationAllotAdmissionMasterDataProvider.GetOrganisationAllotAdmissionMasterBySearch(searchRequest);
                else
                {
                    OrganisationAllotAdmissionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationAllotAdmissionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationAllotAdmissionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationAllotAdmissionMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationAllotAdmissionMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationAllotAdmissionMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAllotAdmissionMaster> SelectByID(OrganisationAllotAdmissionMaster item)
        {
            IBaseEntityResponse<OrganisationAllotAdmissionMaster> entityResponse = new BaseEntityResponse<OrganisationAllotAdmissionMaster>();
            try
            {
                entityResponse = _OrganisationAllotAdmissionMasterDataProvider.GetOrganisationAllotAdmissionMasterByID(item);
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
        /// Select all record from OrganisationAllotAdmissionMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> GetBySearchList(OrganisationAllotAdmissionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationAllotAdmissionMaster> MediumMasterCollection = new BaseEntityCollectionResponse<OrganisationAllotAdmissionMaster>();
            try
            {
                if (_OrganisationAllotAdmissionMasterDataProvider != null)
                {
                    MediumMasterCollection = _OrganisationAllotAdmissionMasterDataProvider.GetOrganisationAllotAdmissionMasterGetBySearchList(searchRequest);
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
