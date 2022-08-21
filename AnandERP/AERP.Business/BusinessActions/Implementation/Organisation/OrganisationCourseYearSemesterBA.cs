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
    public class OrganisationCourseYearSemesterBA : IOrganisationCourseYearSemesterBA
    {
        IOrganisationCourseYearSemesterDataProvider _organisationCourseYearSemesterDataProvider;
        IOrganisationCourseYearSemesterBR _organisationCourseYearSemesterBR;
        private ILogger _logException;
        public OrganisationCourseYearSemesterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationCourseYearSemesterBR = new OrganisationCourseYearSemesterBR();
            _organisationCourseYearSemesterDataProvider = new OrganisationCourseYearSemesterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationCourseYearSemester.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearSemester> InsertOrganisationCourseYearSemester(OrganisationCourseYearSemester item)
        {
            IBaseEntityResponse<OrganisationCourseYearSemester> entityResponse = new BaseEntityResponse<OrganisationCourseYearSemester>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCourseYearSemesterBR.InsertOrganisationCourseYearSemesterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCourseYearSemesterDataProvider.InsertOrganisationCourseYearSemester(item);
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
        /// Update a specific record  of OrganisationCourseYearSemester.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearSemester> UpdateOrganisationCourseYearSemester(OrganisationCourseYearSemester item)
        {
            IBaseEntityResponse<OrganisationCourseYearSemester> entityResponse = new BaseEntityResponse<OrganisationCourseYearSemester>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCourseYearSemesterBR.UpdateOrganisationCourseYearSemesterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCourseYearSemesterDataProvider.UpdateOrganisationCourseYearSemester(item);
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
        /// Delete a selected record from OrganisationCourseYearSemester.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearSemester> DeleteOrganisationCourseYearSemester(OrganisationCourseYearSemester item)
        {
            IBaseEntityResponse<OrganisationCourseYearSemester> entityResponse = new BaseEntityResponse<OrganisationCourseYearSemester>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCourseYearSemesterBR.DeleteOrganisationCourseYearSemesterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCourseYearSemesterDataProvider.DeleteOrganisationCourseYearSemester(item);
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
        /// Select all record from OrganisationCourseYearSemester table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCourseYearSemester> GetBySearch(OrganisationCourseYearSemesterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCourseYearSemester> OrganisationCourseYearSemesterCollection = new BaseEntityCollectionResponse<OrganisationCourseYearSemester>();
            try
            {
                if (_organisationCourseYearSemesterDataProvider != null)
                    OrganisationCourseYearSemesterCollection = _organisationCourseYearSemesterDataProvider.GetOrganisationCourseYearSemesterBySearch(searchRequest);
                else
                {
                    OrganisationCourseYearSemesterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCourseYearSemesterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCourseYearSemesterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCourseYearSemesterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCourseYearSemesterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationCourseYearSemester table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCourseYearSemester> SelectByID(OrganisationCourseYearSemester item)
        {
            IBaseEntityResponse<OrganisationCourseYearSemester> entityResponse = new BaseEntityResponse<OrganisationCourseYearSemester>();
            try
            {
                entityResponse = _organisationCourseYearSemesterDataProvider.GetOrganisationCourseYearSemesterByID(item);
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
