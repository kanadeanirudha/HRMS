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
    public class EmployeeOtherCollegeSpecialLectureDetailsBA : IEmployeeOtherCollegeSpecialLectureDetailsBA
    {
        IEmployeeOtherCollegeSpecialLectureDetailsDataProvider _employeeOtherCollegeSpecialLectureDetailsDataProvider;
        IEmployeeOtherCollegeSpecialLectureDetailsBR _employeeOtherCollegeSpecialLectureDetailsBR;
        private ILogger _logException;
        public EmployeeOtherCollegeSpecialLectureDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeOtherCollegeSpecialLectureDetailsBR = new EmployeeOtherCollegeSpecialLectureDetailsBR();
            _employeeOtherCollegeSpecialLectureDetailsDataProvider = new EmployeeOtherCollegeSpecialLectureDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeOtherCollegeSpecialLectureDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> InsertEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeOtherCollegeSpecialLectureDetailsBR.InsertEmployeeOtherCollegeSpecialLectureDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeOtherCollegeSpecialLectureDetailsDataProvider.InsertEmployeeOtherCollegeSpecialLectureDetails(item);
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
        /// Update a specific record  of EmployeeOtherCollegeSpecialLectureDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> UpdateEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeOtherCollegeSpecialLectureDetailsBR.UpdateEmployeeOtherCollegeSpecialLectureDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeOtherCollegeSpecialLectureDetailsDataProvider.UpdateEmployeeOtherCollegeSpecialLectureDetails(item);
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
        /// Delete a selected record from EmployeeOtherCollegeSpecialLectureDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> DeleteEmployeeOtherCollegeSpecialLectureDetails(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeOtherCollegeSpecialLectureDetailsBR.DeleteEmployeeOtherCollegeSpecialLectureDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeOtherCollegeSpecialLectureDetailsDataProvider.DeleteEmployeeOtherCollegeSpecialLectureDetails(item);
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
        /// Select all record from EmployeeOtherCollegeSpecialLectureDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> GetBySearch(EmployeeOtherCollegeSpecialLectureDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails> EmployeeOtherCollegeSpecialLectureDetailsCollection = new BaseEntityCollectionResponse<EmployeeOtherCollegeSpecialLectureDetails>();
            try
            {
                if (_employeeOtherCollegeSpecialLectureDetailsDataProvider != null)
                    EmployeeOtherCollegeSpecialLectureDetailsCollection = _employeeOtherCollegeSpecialLectureDetailsDataProvider.GetEmployeeOtherCollegeSpecialLectureDetailsBySearch(searchRequest);
                else
                {
                    EmployeeOtherCollegeSpecialLectureDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeOtherCollegeSpecialLectureDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeOtherCollegeSpecialLectureDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeOtherCollegeSpecialLectureDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeOtherCollegeSpecialLectureDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeOtherCollegeSpecialLectureDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> SelectByID(EmployeeOtherCollegeSpecialLectureDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeSpecialLectureDetails>();
            try
            {
                entityResponse = _employeeOtherCollegeSpecialLectureDetailsDataProvider.GetEmployeeOtherCollegeSpecialLectureDetailsByID(item);
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
