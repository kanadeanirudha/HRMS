using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public class EmployeeExperienceBA : IEmployeeExperienceBA
    {
        IEmployeeExperienceDataProvider _employeeExperienceDataProvider;
        IEmployeeExperienceBR _employeeExperienceBR;
        private ILogger _logException;
        public EmployeeExperienceBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeExperienceBR = new EmployeeExperienceBR();
            _employeeExperienceDataProvider = new EmployeeExperienceDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeExperience.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> InsertEmployeeExperience(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> entityResponse = new BaseEntityResponse<EmployeeExperience>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeExperienceBR.InsertEmployeeExperienceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeExperienceDataProvider.InsertEmployeeExperience(item);
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
        /// Update a specific record  of EmployeeExperience.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> UpdateEmployeeExperience(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> entityResponse = new BaseEntityResponse<EmployeeExperience>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeExperienceBR.UpdateEmployeeExperienceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeExperienceDataProvider.UpdateEmployeeExperience(item);
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
        /// Delete a selected record from EmployeeExperience.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> DeleteEmployeeExperience(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> entityResponse = new BaseEntityResponse<EmployeeExperience>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeExperienceBR.DeleteEmployeeExperienceValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeExperienceDataProvider.DeleteEmployeeExperience(item);
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
        /// Select all record from EmployeeExperience table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeExperience> GetBySearch(EmployeeExperienceSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeExperience> EmployeeExperienceCollection = new BaseEntityCollectionResponse<EmployeeExperience>();
            try
            {
                if (_employeeExperienceDataProvider != null)
                    EmployeeExperienceCollection = _employeeExperienceDataProvider.GetEmployeeExperienceBySearch(searchRequest);
                else
                {
                    EmployeeExperienceCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeExperienceCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeExperienceCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeExperienceCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeExperienceCollection;
        }
        /// <summary>
        /// Select a record from EmployeeExperience table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeExperience> SelectByID(EmployeeExperience item)
        {
            IBaseEntityResponse<EmployeeExperience> entityResponse = new BaseEntityResponse<EmployeeExperience>();
            try
            {
                entityResponse = _employeeExperienceDataProvider.GetEmployeeExperienceByID(item);
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
