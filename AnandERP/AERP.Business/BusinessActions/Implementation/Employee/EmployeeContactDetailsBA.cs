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
    public class EmployeeContactDetailsBA : IEmployeeContactDetailsBA
    {
        IEmployeeContactDetailsDataProvider _employeeContactDetailsDataProvider;
        IEmployeeContactDetailsBR _employeeContactDetailsBR;
        private ILogger _logException;
        public EmployeeContactDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeContactDetailsBR = new EmployeeContactDetailsBR();
            _employeeContactDetailsDataProvider = new EmployeeContactDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeContactDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeContactDetails> InsertEmployeeContactDetails(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> entityResponse = new BaseEntityResponse<EmployeeContactDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeContactDetailsBR.InsertEmployeeContactDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeContactDetailsDataProvider.InsertEmployeeContactDetails(item);
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
        /// Update a specific record  of EmployeeContactDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeContactDetails> UpdateEmployeeContactDetails(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> entityResponse = new BaseEntityResponse<EmployeeContactDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeContactDetailsBR.UpdateEmployeeContactDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeContactDetailsDataProvider.UpdateEmployeeContactDetails(item);
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
        /// Delete a selected record from EmployeeContactDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeContactDetails> DeleteEmployeeContactDetails(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> entityResponse = new BaseEntityResponse<EmployeeContactDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeContactDetailsBR.DeleteEmployeeContactDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeContactDetailsDataProvider.DeleteEmployeeContactDetails(item);
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
        /// Select all record from EmployeeContactDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeContactDetails> GetBySearch(EmployeeContactDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeContactDetails> EmployeeContactDetailsCollection = new BaseEntityCollectionResponse<EmployeeContactDetails>();
            try
            {
                if (_employeeContactDetailsDataProvider != null)
                    EmployeeContactDetailsCollection = _employeeContactDetailsDataProvider.GetEmployeeContactDetailsBySearch(searchRequest);
                else
                {
                    EmployeeContactDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeContactDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeContactDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeContactDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeContactDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeContactDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeContactDetails> SelectByID(EmployeeContactDetails item)
        {
            IBaseEntityResponse<EmployeeContactDetails> entityResponse = new BaseEntityResponse<EmployeeContactDetails>();
            try
            {
                entityResponse = _employeeContactDetailsDataProvider.GetEmployeeContactDetailsByID(item);
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
