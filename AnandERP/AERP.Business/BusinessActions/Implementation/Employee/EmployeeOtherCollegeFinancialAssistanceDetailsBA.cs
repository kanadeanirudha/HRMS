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
    public class EmployeeOtherCollegeFinancialAssistanceDetailsBA : IEmployeeOtherCollegeFinancialAssistanceDetailsBA
    {
        IEmployeeOtherCollegeFinancialAssistanceDetailsDataProvider _employeeOtherCollegeFinancialAssistanceDetailsDataProvider;
        IEmployeeOtherCollegeFinancialAssistanceDetailsBR _employeeOtherCollegeFinancialAssistanceDetailsBR;
        private ILogger _logException;
        public EmployeeOtherCollegeFinancialAssistanceDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeOtherCollegeFinancialAssistanceDetailsBR = new EmployeeOtherCollegeFinancialAssistanceDetailsBR();
            _employeeOtherCollegeFinancialAssistanceDetailsDataProvider = new EmployeeOtherCollegeFinancialAssistanceDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeOtherCollegeFinancialAssistanceDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> InsertEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeOtherCollegeFinancialAssistanceDetailsBR.InsertEmployeeOtherCollegeFinancialAssistanceDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeOtherCollegeFinancialAssistanceDetailsDataProvider.InsertEmployeeOtherCollegeFinancialAssistanceDetails(item);
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
        /// Update a specific record  of EmployeeOtherCollegeFinancialAssistanceDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> UpdateEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeOtherCollegeFinancialAssistanceDetailsBR.UpdateEmployeeOtherCollegeFinancialAssistanceDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeOtherCollegeFinancialAssistanceDetailsDataProvider.UpdateEmployeeOtherCollegeFinancialAssistanceDetails(item);
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
        /// Delete a selected record from EmployeeOtherCollegeFinancialAssistanceDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> DeleteEmployeeOtherCollegeFinancialAssistanceDetails(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeOtherCollegeFinancialAssistanceDetailsBR.DeleteEmployeeOtherCollegeFinancialAssistanceDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeOtherCollegeFinancialAssistanceDetailsDataProvider.DeleteEmployeeOtherCollegeFinancialAssistanceDetails(item);
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
        /// Select all record from EmployeeOtherCollegeFinancialAssistanceDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails> GetBySearch(EmployeeOtherCollegeFinancialAssistanceDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails> EmployeeOtherCollegeFinancialAssistanceDetailsCollection = new BaseEntityCollectionResponse<EmployeeOtherCollegeFinancialAssistanceDetails>();
            try
            {
                if (_employeeOtherCollegeFinancialAssistanceDetailsDataProvider != null)
                    EmployeeOtherCollegeFinancialAssistanceDetailsCollection = _employeeOtherCollegeFinancialAssistanceDetailsDataProvider.GetEmployeeOtherCollegeFinancialAssistanceDetailsBySearch(searchRequest);
                else
                {
                    EmployeeOtherCollegeFinancialAssistanceDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeOtherCollegeFinancialAssistanceDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeOtherCollegeFinancialAssistanceDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeOtherCollegeFinancialAssistanceDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeOtherCollegeFinancialAssistanceDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeOtherCollegeFinancialAssistanceDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> SelectByID(EmployeeOtherCollegeFinancialAssistanceDetails item)
        {
            IBaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails> entityResponse = new BaseEntityResponse<EmployeeOtherCollegeFinancialAssistanceDetails>();
            try
            {
                entityResponse = _employeeOtherCollegeFinancialAssistanceDetailsDataProvider.GetEmployeeOtherCollegeFinancialAssistanceDetailsByID(item);
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
