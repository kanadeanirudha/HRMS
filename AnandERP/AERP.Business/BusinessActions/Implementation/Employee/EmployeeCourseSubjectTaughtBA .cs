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
    public class EmployeeCourseSubjectTaughtBA : IEmployeeCourseSubjectTaughtBA
    {
        IEmployeeCourseSubjectTaughtDataProvider _employeeCourseSubjectTaughtDataProvider;
        IEmployeeCourseSubjectTaughtBR _employeeCourseSubjectTaughtBR;
        private ILogger _logException;
        public EmployeeCourseSubjectTaughtBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeCourseSubjectTaughtBR = new EmployeeCourseSubjectTaughtBR();
            _employeeCourseSubjectTaughtDataProvider = new EmployeeCourseSubjectTaughtDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeCourseSubjectTaught.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> InsertEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item)
        {
            IBaseEntityResponse<EmployeeCourseSubjectTaught> entityResponse = new BaseEntityResponse<EmployeeCourseSubjectTaught>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeCourseSubjectTaughtBR.InsertEmployeeCourseSubjectTaughtValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeCourseSubjectTaughtDataProvider.InsertEmployeeCourseSubjectTaught(item);
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
        /// Update a specific record  of EmployeeCourseSubjectTaught.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> UpdateEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item)
        {
            IBaseEntityResponse<EmployeeCourseSubjectTaught> entityResponse = new BaseEntityResponse<EmployeeCourseSubjectTaught>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeCourseSubjectTaughtBR.UpdateEmployeeCourseSubjectTaughtValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeCourseSubjectTaughtDataProvider.UpdateEmployeeCourseSubjectTaught(item);
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
        /// Delete a selected record from EmployeeCourseSubjectTaught.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> DeleteEmployeeCourseSubjectTaught(EmployeeCourseSubjectTaught item)
        {
            IBaseEntityResponse<EmployeeCourseSubjectTaught> entityResponse = new BaseEntityResponse<EmployeeCourseSubjectTaught>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeCourseSubjectTaughtBR.DeleteEmployeeCourseSubjectTaughtValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeCourseSubjectTaughtDataProvider.DeleteEmployeeCourseSubjectTaught(item);
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
        /// Select all record from EmployeeCourseSubjectTaught table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> GetBySearch(EmployeeCourseSubjectTaughtSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeCourseSubjectTaught> EmployeeCourseSubjectTaughtCollection = new BaseEntityCollectionResponse<EmployeeCourseSubjectTaught>();
            try
            {
                if (_employeeCourseSubjectTaughtDataProvider != null)
                    EmployeeCourseSubjectTaughtCollection = _employeeCourseSubjectTaughtDataProvider.GetEmployeeCourseSubjectTaughtBySearch(searchRequest);
                else
                {
                    EmployeeCourseSubjectTaughtCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeCourseSubjectTaughtCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeCourseSubjectTaughtCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeCourseSubjectTaughtCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeCourseSubjectTaughtCollection;
        }
        /// <summary>
        /// Select a record from EmployeeCourseSubjectTaught table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeCourseSubjectTaught> SelectByID(EmployeeCourseSubjectTaught item)
        {
            IBaseEntityResponse<EmployeeCourseSubjectTaught> entityResponse = new BaseEntityResponse<EmployeeCourseSubjectTaught>();
            try
            {
                entityResponse = _employeeCourseSubjectTaughtDataProvider.GetEmployeeCourseSubjectTaughtByID(item);
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
