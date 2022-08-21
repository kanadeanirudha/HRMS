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
    public class OrganisationCourseYearDetailsBA : IOrganisationCourseYearDetailsBA
    {
        IOrganisationCourseYearDetailsDataProvider _organisationCourseYearDetailsDataProvider;
        IOrganisationCourseYearDetailsBR _organisationCourseYearDetailsBR;
        private ILogger _logException;
        public OrganisationCourseYearDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationCourseYearDetailsBR = new OrganisationCourseYearDetailsBR();
            _organisationCourseYearDetailsDataProvider = new OrganisationCourseYearDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationCourseYearDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> InsertOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> entityResponse = new BaseEntityResponse<OrganisationCourseYearDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCourseYearDetailsBR.InsertOrganisationCourseYearDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCourseYearDetailsDataProvider.InsertOrganisationCourseYearDetails(item);
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
        /// Update a specific record  of OrganisationCourseYearDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> UpdateOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> entityResponse = new BaseEntityResponse<OrganisationCourseYearDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCourseYearDetailsBR.UpdateOrganisationCourseYearDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCourseYearDetailsDataProvider.UpdateOrganisationCourseYearDetails(item);
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
        /// Delete a selected record from OrganisationCourseYearDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> DeleteOrganisationCourseYearDetails(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> entityResponse = new BaseEntityResponse<OrganisationCourseYearDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCourseYearDetailsBR.DeleteOrganisationCourseYearDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCourseYearDetailsDataProvider.DeleteOrganisationCourseYearDetails(item);
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
        /// Select all record from OrganisationCourseYearDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetBySearch(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> OrganisationCourseYearDetailsCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    OrganisationCourseYearDetailsCollection = _organisationCourseYearDetailsDataProvider.GetOrganisationCourseYearDetailsBySearch(searchRequest);
                else
                {
                    OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearDetailsCollection;
        }
        /// <summary>
        /// Select a record from OrganisationCourseYearDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByID(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> entityResponse = new BaseEntityResponse<OrganisationCourseYearDetails>();
            try
            {
                entityResponse = _organisationCourseYearDetailsDataProvider.GetOrganisationCourseYearDetailsByID(item);
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
        /// Select a record from OrganisationCourseYearDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByID_For_CourseDescription(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> entityResponse = new BaseEntityResponse<OrganisationCourseYearDetails>();
            try
            {
                entityResponse = _organisationCourseYearDetailsDataProvider.GetOrganisationCourseYearDetailsByID_For_CourseDescription(item);
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
        /// Select all record from OrganisationSemesterCourseYear table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetByApplicableSemester(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> OrganisationCourseYearDetailsCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    OrganisationCourseYearDetailsCollection = _organisationCourseYearDetailsDataProvider.GetSemesterApplicableBySearch(searchRequest);
                else
                {
                    OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearDetailsCollection;
        }
        public IBaseEntityResponse<OrganisationCourseYearDetails> SelectByBranchDetIDAndStandardNumber(OrganisationCourseYearDetails item)
        {
            IBaseEntityResponse<OrganisationCourseYearDetails> entityResponse = new BaseEntityResponse<OrganisationCourseYearDetails>();
            try
            {
                entityResponse = _organisationCourseYearDetailsDataProvider.SelectByBranchDetIDAndStandardNumber(item);
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
        /// Select all record from OrganisationSemesterCourseYear table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRoleWise(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> OrganisationCourseYearDetailsCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    OrganisationCourseYearDetailsCollection = _organisationCourseYearDetailsDataProvider.GetCourseYearListRoleWise(searchRequest);
                else
                {
                    OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearDetailsCollection;
        }
        /// <summary>
        /// Select all record from OrganisationSemesterCourseYear table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetNextCourseYearForPromotion(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> OrganisationCourseYearDetailsCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    OrganisationCourseYearDetailsCollection = _organisationCourseYearDetailsDataProvider.GetNextCourseYearForPromotion(searchRequest);
                else
                {
                    OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearDetailsCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearListRole_CentreCode_UniversityWise(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> OrganisationCourseYearDetailsCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    OrganisationCourseYearDetailsCollection = _organisationCourseYearDetailsDataProvider.GetCourseYearListRole_CentreCode_UniversityWise(searchRequest);
                else
                {
                    OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearDetailsCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailsByCentreCode(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> OrganisationCourseYearDetailsCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    OrganisationCourseYearDetailsCollection = _organisationCourseYearDetailsDataProvider.GetCourseYearDetailsByCentreCode(searchRequest);
                else
                {
                    OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearDetailsCollection;
        }


        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailSearchList(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> CourseYearDetailCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    CourseYearDetailCollection = _organisationCourseYearDetailsDataProvider.GetCourseYearDetailSearchList(searchRequest);
                else
                {
                    CourseYearDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CourseYearDetailCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CourseYearDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CourseYearDetailCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CourseYearDetailCollection;
        }
 


        ///
        public IBaseEntityCollectionResponse<OrganisationCourseYearDetails> GetCourseYearDetailDescription(OrganisationCourseYearDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearDetails> CourseYearDetailCollection = new BaseEntityCollectionResponse<OrganisationCourseYearDetails>();
            try
            {
                if (_organisationCourseYearDetailsDataProvider != null)
                    CourseYearDetailCollection = _organisationCourseYearDetailsDataProvider.GetCourseYearDetailDescription(searchRequest);
                else
                {
                    CourseYearDetailCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CourseYearDetailCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CourseYearDetailCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CourseYearDetailCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CourseYearDetailCollection;
        }
 
    }
}
