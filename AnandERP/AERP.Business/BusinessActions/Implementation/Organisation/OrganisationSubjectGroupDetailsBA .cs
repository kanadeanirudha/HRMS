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
    public class OrganisationSubjectGroupDetailsBA : IOrganisationSubjectGroupDetailsBA
    {
        IOrganisationSubjectGroupDetailsDataProvider _organisationSubjectGroupDetailsDataProvider;
        IOrganisationSubjectGroupDetailsBR _organisationSubjectGroupDetailsBR;
        private ILogger _logException;
        public OrganisationSubjectGroupDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSubjectGroupDetailsBR = new OrganisationSubjectGroupDetailsBR();
            _organisationSubjectGroupDetailsDataProvider = new OrganisationSubjectGroupDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSubjectGroupDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> InsertOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> entityResponse = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGroupDetailsBR.InsertOrganisationSubjectGroupDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGroupDetailsDataProvider.InsertOrganisationSubjectGroupDetails(item);
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
        /// Update a specific record  of OrganisationSubjectGroupDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> UpdateOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> entityResponse = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGroupDetailsBR.UpdateOrganisationSubjectGroupDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGroupDetailsDataProvider.UpdateOrganisationSubjectGroupDetails(item);
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
        /// Delete a selected record from OrganisationSubjectGroupDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> DeleteOrganisationSubjectGroupDetails(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> entityResponse = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGroupDetailsBR.DeleteOrganisationSubjectGroupDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGroupDetailsDataProvider.DeleteOrganisationSubjectGroupDetails(item);
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
        /// Select all record from OrganisationSubjectGroupDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySearch(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> OrganisationSubjectGroupDetailsCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
            try
            {
                if (_organisationSubjectGroupDetailsDataProvider != null)
                    OrganisationSubjectGroupDetailsCollection = _organisationSubjectGroupDetailsDataProvider.GetOrganisationSubjectGroupDetailsBySearch(searchRequest);
                else
                {
                    OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGroupDetailsCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSubjectGroupDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGroupDetails> SelectByID(OrganisationSubjectGroupDetails item)
        {
            IBaseEntityResponse<OrganisationSubjectGroupDetails> entityResponse = new BaseEntityResponse<OrganisationSubjectGroupDetails>();
            try
            {
                entityResponse = _organisationSubjectGroupDetailsDataProvider.GetOrganisationSubjectGroupDetailsByID(item);
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
        /// Select all record from OrganisationSubjectGroupDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubjectTypeMaterList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> OrganisationSubjectGroupDetailsCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
            try
            {
                if (_organisationSubjectGroupDetailsDataProvider != null)
                    OrganisationSubjectGroupDetailsCollection = _organisationSubjectGroupDetailsDataProvider.GetOrganisationSubjectTypeMasterBySearchList(searchRequest);
                else
                {
                    OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGroupDetailsCollection;
        }


        /// <summary>
        /// Select all record from OrganisationSubjectGroupDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> OrganisationSubjectGroupDetailsCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
            try
            {
                if (_organisationSubjectGroupDetailsDataProvider != null)
                    OrganisationSubjectGroupDetailsCollection = _organisationSubjectGroupDetailsDataProvider.GetOrganisationElectiveGroupBySearchList(searchRequest);
                else
                {
                    OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGroupDetailsCollection;
        }

        /// <summary>
        /// Select all record from OrganisationSubjectGroupDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetBySubElectiveGroupSearchList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> OrganisationSubjectGroupDetailsCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
            try
            {
                if (_organisationSubjectGroupDetailsDataProvider != null)
                    OrganisationSubjectGroupDetailsCollection = _organisationSubjectGroupDetailsDataProvider.GetSubOrganisationElectiveGroupBySearchList(searchRequest);
                else
                {
                    OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGroupDetailsCollection;
        }

        /// <summary>
        /// Select all record from OrganisationSubjectGroupDetails table with search parameters.///OnlineExam
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> GetByDescriptionList(OrganisationSubjectGroupDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGroupDetails> OrganisationSubjectGroupDetailsCollection = new BaseEntityCollectionResponse<OrganisationSubjectGroupDetails>();
            try
            {
                if (_organisationSubjectGroupDetailsDataProvider != null)
                    OrganisationSubjectGroupDetailsCollection = _organisationSubjectGroupDetailsDataProvider.GetByDescriptionList(searchRequest);
                else
                {
                    OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGroupDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGroupDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGroupDetailsCollection;
        }


    }
}
