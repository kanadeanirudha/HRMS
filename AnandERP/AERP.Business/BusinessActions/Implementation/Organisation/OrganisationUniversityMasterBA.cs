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
namespace AMS.Business.BusinessActions
{
    public class OrganisationUniversityMasterBA : IOrganisationUniversityMasterBA
    {

        IOrganisationUniversityMasterDataProvider _organisationUniversityMasterDataProvider;
        IOrganisationUniversityMasterBR _organisationUniversityMasterBR;
        private ILogger _logException;

        public OrganisationUniversityMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationUniversityMasterBR = new OrganisationUniversityMasterBR();
            _organisationUniversityMasterDataProvider = new OrganisationUniversityMasterDataProvider();
        }

        /// <summary>
        /// Create new record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> InsertOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> entityResponse = new BaseEntityResponse<OrganisationUniversityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationUniversityMasterBR.InsertOrganisationUniversityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationUniversityMasterDataProvider.InsertOrganisationUniversityMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Update a specific record of OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> UpdateOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> entityResponse = new BaseEntityResponse<OrganisationUniversityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationUniversityMasterBR.UpdateOrganisationUniversityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationUniversityMasterDataProvider.UpdateOrganisationUniversityMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Delete a selected record from OrganisationUniversityMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> DeleteOrganisationUniversityMaster(OrganisationUniversityMaster item)
        {
            IBaseEntityResponse<OrganisationUniversityMaster> entityResponse = new BaseEntityResponse<OrganisationUniversityMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationUniversityMasterBR.DeleteOrganisationUniversityMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationUniversityMasterDataProvider.DeleteOrganisationUniversityMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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
        /// Select all record from OrganisationUniversityMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearch(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> categoryMasterCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
            try
            {
                if (_organisationUniversityMasterDataProvider != null)
                {
                    categoryMasterCollection = _organisationUniversityMasterDataProvider.GetOrganisationUniversityMasterBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

        /// <summary>
        /// Select all record from OrganisationUniversityMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearchList(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> categoryMasterCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
            try
            {
                if (_organisationUniversityMasterDataProvider != null)
                {
                    categoryMasterCollection = _organisationUniversityMasterDataProvider.GetOrganisationUniversityMasterGetBySearchList(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }


        /// <summary>
        /// Select a record from OrganisationUniversityMaster Master table by ID
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationUniversityMaster> SelectByID(OrganisationUniversityMaster item)
        {

            IBaseEntityResponse<OrganisationUniversityMaster> entityResponse = new BaseEntityResponse<OrganisationUniversityMaster>();
            try
            {
                entityResponse = _organisationUniversityMasterDataProvider.GetOrganisationUniversityMasterByID(item);
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

        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetByCentreCode(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> OrganisationUniversityMasterCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
            try
            {
                if (_organisationUniversityMasterDataProvider != null)
                {
                    OrganisationUniversityMasterCollection = _organisationUniversityMasterDataProvider.GetOrganisationUniversityMasterByCentreCode(searchRequest);
                }
                else
                {
                    OrganisationUniversityMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationUniversityMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationUniversityMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationUniversityMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationUniversityMasterCollection;
        }

        /// <summary>
        /// Select all record from OrganisationUniversityMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationUniversityMaster> GetBySearchListWithoutCenterCode(OrganisationUniversityMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationUniversityMaster> categoryMasterCollection = new BaseEntityCollectionResponse<OrganisationUniversityMaster>();
            try
            {
                if (_organisationUniversityMasterDataProvider != null)
                {
                    categoryMasterCollection = _organisationUniversityMasterDataProvider.GetOrganisationUniversityMasterGetBySearchListWithoutCenterCode(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }

    }
}