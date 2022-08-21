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
    public class OrganisationAdmissionTypeMasterBA : IOrganisationAdmissionTypeMasterBA
    {
        IOrganisationAdmissionTypeMasterDataProvider _OrganisationAdmissionTypeMasterDataProvider;
        IOrganisationAdmissionTypeMasterBR _OrganisationAdmissionTypeMasterBR;
        private ILogger _logException;
        public OrganisationAdmissionTypeMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _OrganisationAdmissionTypeMasterBR = new OrganisationAdmissionTypeMasterBR();
            _OrganisationAdmissionTypeMasterDataProvider = new OrganisationAdmissionTypeMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationAdmissionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> InsertOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item)
        {
            IBaseEntityResponse<OrganisationAdmissionTypeMaster> entityResponse = new BaseEntityResponse<OrganisationAdmissionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrganisationAdmissionTypeMasterBR.InsertOrganisationAdmissionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrganisationAdmissionTypeMasterDataProvider.InsertOrganisationAdmissionTypeMaster(item);
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
        /// Update a specific record  of OrganisationAdmissionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> UpdateOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item)
        {
            IBaseEntityResponse<OrganisationAdmissionTypeMaster> entityResponse = new BaseEntityResponse<OrganisationAdmissionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrganisationAdmissionTypeMasterBR.UpdateOrganisationAdmissionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrganisationAdmissionTypeMasterDataProvider.UpdateOrganisationAdmissionTypeMaster(item);
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
        /// Delete a selected record from OrganisationAdmissionTypeMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> DeleteOrganisationAdmissionTypeMaster(OrganisationAdmissionTypeMaster item)
        {
            IBaseEntityResponse<OrganisationAdmissionTypeMaster> entityResponse = new BaseEntityResponse<OrganisationAdmissionTypeMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _OrganisationAdmissionTypeMasterBR.DeleteOrganisationAdmissionTypeMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _OrganisationAdmissionTypeMasterDataProvider.DeleteOrganisationAdmissionTypeMaster(item);
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
        /// Select all record from OrganisationAdmissionTypeMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetBySearch(OrganisationAdmissionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> OrganisationAdmissionTypeMasterCollection = new BaseEntityCollectionResponse<OrganisationAdmissionTypeMaster>();
            try
            {
                if (_OrganisationAdmissionTypeMasterDataProvider != null)
                    OrganisationAdmissionTypeMasterCollection = _OrganisationAdmissionTypeMasterDataProvider.GetOrganisationAdmissionTypeMasterBySearch(searchRequest);
                else
                {
                    OrganisationAdmissionTypeMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationAdmissionTypeMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationAdmissionTypeMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationAdmissionTypeMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationAdmissionTypeMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationAdmissionTypeMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationAdmissionTypeMaster> SelectByID(OrganisationAdmissionTypeMaster item)
        {
            IBaseEntityResponse<OrganisationAdmissionTypeMaster> entityResponse = new BaseEntityResponse<OrganisationAdmissionTypeMaster>();
            try
            {
                entityResponse = _OrganisationAdmissionTypeMasterDataProvider.GetOrganisationAdmissionTypeMasterByID(item);
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
        /// Select all record from OrganisationAdmissionTypeMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> GetBySearchList(OrganisationAdmissionTypeMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationAdmissionTypeMaster> MediumMasterCollection = new BaseEntityCollectionResponse<OrganisationAdmissionTypeMaster>();
            try
            {
                if (_OrganisationAdmissionTypeMasterDataProvider != null)
                {
                    MediumMasterCollection = _OrganisationAdmissionTypeMasterDataProvider.GetOrganisationAdmissionTypeMasterGetBySearchList(searchRequest);
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
