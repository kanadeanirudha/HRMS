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
    public class EmployeeChildrenDetailsBA : IEmployeeChildrenDetailsBA
    {
        IEmployeeChildrenDetailsDataProvider _employeeChildrenDetailsDataProvider;
        IEmployeeChildrenDetailsBR _employeeChildrenDetailsBR;
        private ILogger _logException;
        public EmployeeChildrenDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeChildrenDetailsBR = new EmployeeChildrenDetailsBR();
            _employeeChildrenDetailsDataProvider = new EmployeeChildrenDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeChildrenDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeChildrenDetails> InsertEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> entityResponse = new BaseEntityResponse<EmployeeChildrenDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeChildrenDetailsBR.InsertEmployeeChildrenDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeChildrenDetailsDataProvider.InsertEmployeeChildrenDetails(item);
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
        /// Update a specific record  of EmployeeChildrenDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeChildrenDetails> UpdateEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> entityResponse = new BaseEntityResponse<EmployeeChildrenDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeChildrenDetailsBR.UpdateEmployeeChildrenDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeChildrenDetailsDataProvider.UpdateEmployeeChildrenDetails(item);
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
        /// Delete a selected record from EmployeeChildrenDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeChildrenDetails> DeleteEmployeeChildrenDetails(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> entityResponse = new BaseEntityResponse<EmployeeChildrenDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeChildrenDetailsBR.DeleteEmployeeChildrenDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeChildrenDetailsDataProvider.DeleteEmployeeChildrenDetails(item);
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
        /// Select all record from EmployeeChildrenDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeChildrenDetails> GetBySearch(EmployeeChildrenDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeChildrenDetails> EmployeeChildrenDetailsCollection = new BaseEntityCollectionResponse<EmployeeChildrenDetails>();
            try
            {
                if (_employeeChildrenDetailsDataProvider != null)
                    EmployeeChildrenDetailsCollection = _employeeChildrenDetailsDataProvider.GetEmployeeChildrenDetailsBySearch(searchRequest);
                else
                {
                    EmployeeChildrenDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeChildrenDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeChildrenDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeChildrenDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeChildrenDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeChildrenDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeChildrenDetails> SelectByID(EmployeeChildrenDetails item)
        {
            IBaseEntityResponse<EmployeeChildrenDetails> entityResponse = new BaseEntityResponse<EmployeeChildrenDetails>();
            try
            {
                entityResponse = _employeeChildrenDetailsDataProvider.GetEmployeeChildrenDetailsByID(item);
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
