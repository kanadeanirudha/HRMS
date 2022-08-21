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
    public class OrganisationSectionDetailsBA : IOrganisationSectionDetailsBA
    {
        IOrganisationSectionDetailsDataProvider _organisationSectionDetailsDataProvider;
        IOrganisationSectionDetailsBR _organisationSectionDetailsBR;
        private ILogger _logException;
        public OrganisationSectionDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSectionDetailsBR = new OrganisationSectionDetailsBR();
            _organisationSectionDetailsDataProvider = new OrganisationSectionDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSectionDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> InsertOrganisationSectionDetails(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> entityResponse = new BaseEntityResponse<OrganisationSectionDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionDetailsBR.InsertOrganisationSectionDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionDetailsDataProvider.InsertOrganisationSectionDetails(item);
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
        /// Update a specific record  of OrganisationSectionDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetails(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> entityResponse = new BaseEntityResponse<OrganisationSectionDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionDetailsBR.UpdateOrganisationSectionDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionDetailsDataProvider.UpdateOrganisationSectionDetails(item);
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
        /// Delete a selected record from OrganisationSectionDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> DeleteOrganisationSectionDetails(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> entityResponse = new BaseEntityResponse<OrganisationSectionDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionDetailsBR.DeleteOrganisationSectionDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionDetailsDataProvider.DeleteOrganisationSectionDetails(item);
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
        /// Select all record from OrganisationSectionDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetBySearch(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> OrganisationSectionDetailsCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
            try
            {
                if (_organisationSectionDetailsDataProvider != null)
                    OrganisationSectionDetailsCollection = _organisationSectionDetailsDataProvider.GetOrganisationSectionDetailsBySearch(searchRequest);
                else
                {
                    OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionDetailsCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSectionDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> SelectByID(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> entityResponse = new BaseEntityResponse<OrganisationSectionDetails>();
            try
            {
                entityResponse = _organisationSectionDetailsDataProvider.GetSearchOrganisationSectionDetailsByID(item);
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

        public IBaseEntityCollectionResponse<OrganisationSectionDetails> SelectByBranchDetID(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> OrganisationSectionDetailsCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
            try
            {
                if (_organisationSectionDetailsDataProvider != null)
                    OrganisationSectionDetailsCollection = _organisationSectionDetailsDataProvider.GetOrganisationSectionDetailsByID(searchRequest);
                else
                {
                    OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionDetailsCollection;
        }

        /// <summary>
        /// Select all record from OrganisationSectionDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetBySearchForSectionDetailsAdd(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> OrganisationSectionDetailsCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
            try
            {
                if (_organisationSectionDetailsDataProvider != null)
                    OrganisationSectionDetailsCollection = _organisationSectionDetailsDataProvider.GetOrganisationSectionDetailsBySearchForSectionDetailsAdd(searchRequest);
                else
                {
                    OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionDetailsCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSectionDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> SelectByID_OR_CourseYearID(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> entityResponse = new BaseEntityResponse<OrganisationSectionDetails>();
            try
            {
                entityResponse = _organisationSectionDetailsDataProvider.GetSearchOrganisationSectionDetailsByID_OR_CourseYearID(item);
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
        /// Update a specific record  of OrganisationSectionDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSectionDetails> UpdateOrganisationSectionDetailsAdd(OrganisationSectionDetails item)
        {
            IBaseEntityResponse<OrganisationSectionDetails> entityResponse = new BaseEntityResponse<OrganisationSectionDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSectionDetailsBR.UpdateOrganisationSectionDetailsValidateAdd(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSectionDetailsDataProvider.UpdateOrganisationSectionDetailsAdd(item);
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
        /// Select all record from OrganisationSectionDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRoleWise(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> OrganisationSectionDetailsCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
            try
            {
                if (_organisationSectionDetailsDataProvider != null)
                    OrganisationSectionDetailsCollection = _organisationSectionDetailsDataProvider.GetSectionDetailsRoleWise(searchRequest);
                else
                {
                    OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionDetailsCollection;
        }
        /// <summary>
        /// Select all record from OrganisationSectionDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsForPromotion(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> OrganisationSectionDetailsCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
            try
            {
                if (_organisationSectionDetailsDataProvider != null)
                    OrganisationSectionDetailsCollection = _organisationSectionDetailsDataProvider.GetSectionDetailsForPromotion(searchRequest);
                else
                {
                    OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionDetailsCollection;
        }


        public IBaseEntityCollectionResponse<OrganisationSectionDetails> GetSectionDetailsRole_CentreCode_UniversityWise(OrganisationSectionDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSectionDetails> OrganisationSectionDetailsCollection = new BaseEntityCollectionResponse<OrganisationSectionDetails>();
            try
            {
                if (_organisationSectionDetailsDataProvider != null)
                    OrganisationSectionDetailsCollection = _organisationSectionDetailsDataProvider.GetSectionDetailsRole_CentreCode_UniversityWise(searchRequest);
                else
                {
                    OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSectionDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSectionDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSectionDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSectionDetailsCollection;
        }
    }
}
