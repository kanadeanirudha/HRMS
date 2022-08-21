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
    public class EmployeePatentReceivedDetailsBA : IEmployeePatentReceivedDetailsBA
    {
        IEmployeePatentReceivedDetailsDataProvider _employeePatentReceivedDetailsDataProvider;
        IEmployeePatentReceivedDetailsBR _employeePatentReceivedDetailsBR;
        private ILogger _logException;
        public EmployeePatentReceivedDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeePatentReceivedDetailsBR = new EmployeePatentReceivedDetailsBR();
            _employeePatentReceivedDetailsDataProvider = new EmployeePatentReceivedDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeePatentReceivedDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePatentReceivedDetails> InsertEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item)
        {
            IBaseEntityResponse<EmployeePatentReceivedDetails> entityResponse = new BaseEntityResponse<EmployeePatentReceivedDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePatentReceivedDetailsBR.InsertEmployeePatentReceivedDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePatentReceivedDetailsDataProvider.InsertEmployeePatentReceivedDetails(item);
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
        /// Update a specific record  of EmployeePatentReceivedDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePatentReceivedDetails> UpdateEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item)
        {
            IBaseEntityResponse<EmployeePatentReceivedDetails> entityResponse = new BaseEntityResponse<EmployeePatentReceivedDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePatentReceivedDetailsBR.UpdateEmployeePatentReceivedDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePatentReceivedDetailsDataProvider.UpdateEmployeePatentReceivedDetails(item);
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
        /// Delete a selected record from EmployeePatentReceivedDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePatentReceivedDetails> DeleteEmployeePatentReceivedDetails(EmployeePatentReceivedDetails item)
        {
            IBaseEntityResponse<EmployeePatentReceivedDetails> entityResponse = new BaseEntityResponse<EmployeePatentReceivedDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePatentReceivedDetailsBR.DeleteEmployeePatentReceivedDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePatentReceivedDetailsDataProvider.DeleteEmployeePatentReceivedDetails(item);
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
        /// Select all record from EmployeePatentReceivedDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePatentReceivedDetails> GetBySearch(EmployeePatentReceivedDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePatentReceivedDetails> EmployeePatentReceivedDetailsCollection = new BaseEntityCollectionResponse<EmployeePatentReceivedDetails>();
            try
            {
                if (_employeePatentReceivedDetailsDataProvider != null)
                    EmployeePatentReceivedDetailsCollection = _employeePatentReceivedDetailsDataProvider.GetEmployeePatentReceivedDetailsBySearch(searchRequest);
                else
                {
                    EmployeePatentReceivedDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePatentReceivedDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePatentReceivedDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePatentReceivedDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePatentReceivedDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeePatentReceivedDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePatentReceivedDetails> SelectByID(EmployeePatentReceivedDetails item)
        {
            IBaseEntityResponse<EmployeePatentReceivedDetails> entityResponse = new BaseEntityResponse<EmployeePatentReceivedDetails>();
            try
            {
                entityResponse = _employeePatentReceivedDetailsDataProvider.GetEmployeePatentReceivedDetailsByID(item);
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
