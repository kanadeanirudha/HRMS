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
    public class EmployeeSpecializationResearchAreaDetailsBA : IEmployeeSpecializationResearchAreaDetailsBA
    {
        IEmployeeSpecializationResearchAreaDetailsDataProvider _employeeSpecializationResearchAreaDetailsDataProvider;
        IEmployeeSpecializationResearchAreaDetailsBR _employeeSpecializationResearchAreaDetailsBR;
        private ILogger _logException;
        public EmployeeSpecializationResearchAreaDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeSpecializationResearchAreaDetailsBR = new EmployeeSpecializationResearchAreaDetailsBR();
            _employeeSpecializationResearchAreaDetailsDataProvider = new EmployeeSpecializationResearchAreaDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeSpecializationResearchAreaDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> InsertEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item)
        {
            IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> entityResponse = new BaseEntityResponse<EmployeeSpecializationResearchAreaDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeSpecializationResearchAreaDetailsBR.InsertEmployeeSpecializationResearchAreaDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeSpecializationResearchAreaDetailsDataProvider.InsertEmployeeSpecializationResearchAreaDetails(item);
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
        /// Update a specific record  of EmployeeSpecializationResearchAreaDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> UpdateEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item)
        {
            IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> entityResponse = new BaseEntityResponse<EmployeeSpecializationResearchAreaDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeSpecializationResearchAreaDetailsBR.UpdateEmployeeSpecializationResearchAreaDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeSpecializationResearchAreaDetailsDataProvider.UpdateEmployeeSpecializationResearchAreaDetails(item);
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
        /// Delete a selected record from EmployeeSpecializationResearchAreaDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> DeleteEmployeeSpecializationResearchAreaDetails(EmployeeSpecializationResearchAreaDetails item)
        {
            IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> entityResponse = new BaseEntityResponse<EmployeeSpecializationResearchAreaDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeSpecializationResearchAreaDetailsBR.DeleteEmployeeSpecializationResearchAreaDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeSpecializationResearchAreaDetailsDataProvider.DeleteEmployeeSpecializationResearchAreaDetails(item);
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
        /// Select all record from EmployeeSpecializationResearchAreaDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> GetBySearch(EmployeeSpecializationResearchAreaDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails> EmployeeSpecializationResearchAreaDetailsCollection = new BaseEntityCollectionResponse<EmployeeSpecializationResearchAreaDetails>();
            try
            {
                if (_employeeSpecializationResearchAreaDetailsDataProvider != null)
                    EmployeeSpecializationResearchAreaDetailsCollection = _employeeSpecializationResearchAreaDetailsDataProvider.GetEmployeeSpecializationResearchAreaDetailsBySearch(searchRequest);
                else
                {
                    EmployeeSpecializationResearchAreaDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeSpecializationResearchAreaDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeSpecializationResearchAreaDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeSpecializationResearchAreaDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeSpecializationResearchAreaDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeSpecializationResearchAreaDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> SelectByID(EmployeeSpecializationResearchAreaDetails item)
        {
            IBaseEntityResponse<EmployeeSpecializationResearchAreaDetails> entityResponse = new BaseEntityResponse<EmployeeSpecializationResearchAreaDetails>();
            try
            {
                entityResponse = _employeeSpecializationResearchAreaDetailsDataProvider.GetEmployeeSpecializationResearchAreaDetailsByID(item);
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
