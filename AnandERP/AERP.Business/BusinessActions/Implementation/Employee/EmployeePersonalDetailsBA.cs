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
    public class EmployeePersonalDetailsBA : IEmployeePersonalDetailsBA
    {
        IEmployeePersonalDetailsDataProvider _employeePersonalDetailsDataProvider;
        IEmployeePersonalDetailsBR _employeePersonalDetailsBR;
        private ILogger _logException;
        public EmployeePersonalDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeePersonalDetailsBR = new EmployeePersonalDetailsBR();
            _employeePersonalDetailsDataProvider = new EmployeePersonalDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeePersonalDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePersonalDetails> InsertEmployeePersonalDetails(EmployeePersonalDetails item)
        {
            IBaseEntityResponse<EmployeePersonalDetails> entityResponse = new BaseEntityResponse<EmployeePersonalDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePersonalDetailsBR.InsertEmployeePersonalDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePersonalDetailsDataProvider.InsertEmployeePersonalDetails(item);
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
        /// Update a specific record  of EmployeePersonalDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePersonalDetails> UpdateEmployeePersonalDetails(EmployeePersonalDetails item)
        {
            IBaseEntityResponse<EmployeePersonalDetails> entityResponse = new BaseEntityResponse<EmployeePersonalDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePersonalDetailsBR.UpdateEmployeePersonalDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePersonalDetailsDataProvider.UpdateEmployeePersonalDetails(item);
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
        /// Delete a selected record from EmployeePersonalDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePersonalDetails> DeleteEmployeePersonalDetails(EmployeePersonalDetails item)
        {
            IBaseEntityResponse<EmployeePersonalDetails> entityResponse = new BaseEntityResponse<EmployeePersonalDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePersonalDetailsBR.DeleteEmployeePersonalDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePersonalDetailsDataProvider.DeleteEmployeePersonalDetails(item);
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
        /// Select all record from EmployeePersonalDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePersonalDetails> GetBySearch(EmployeePersonalDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePersonalDetails> EmployeePersonalDetailsCollection = new BaseEntityCollectionResponse<EmployeePersonalDetails>();
            try
            {
                if (_employeePersonalDetailsDataProvider != null)
                    EmployeePersonalDetailsCollection = _employeePersonalDetailsDataProvider.GetEmployeePersonalDetailsBySearch(searchRequest);
                else
                {
                    EmployeePersonalDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePersonalDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePersonalDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePersonalDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePersonalDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeePersonalDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePersonalDetails> SelectByID(EmployeePersonalDetails item)
        {
            IBaseEntityResponse<EmployeePersonalDetails> entityResponse = new BaseEntityResponse<EmployeePersonalDetails>();
            try
            {
                entityResponse = _employeePersonalDetailsDataProvider.GetEmployeePersonalDetailsByID(item);
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
