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
    public class LeaveRuleExemptedEmployeeBA : ILeaveRuleExemptedEmployeeBA
    {
        ILeaveRuleExemptedEmployeeDataProvider _leaveRuleExemptedEmployeeDataProvider;
        ILeaveRuleExemptedEmployeeBR _leaveRuleExemptedEmployeeBR;
        private ILogger _logException;
        public LeaveRuleExemptedEmployeeBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _leaveRuleExemptedEmployeeBR = new LeaveRuleExemptedEmployeeBR();
            _leaveRuleExemptedEmployeeDataProvider = new LeaveRuleExemptedEmployeeDataProvider();
        }
        /// <summary>
        /// Create new record of LeaveRuleExemptedEmployee.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> InsertLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item)
        {
            IBaseEntityResponse<LeaveRuleExemptedEmployee> entityResponse = new BaseEntityResponse<LeaveRuleExemptedEmployee>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleExemptedEmployeeBR.InsertLeaveRuleExemptedEmployeeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleExemptedEmployeeDataProvider.InsertLeaveRuleExemptedEmployee(item);
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
        /// Update a specific record  of LeaveRuleExemptedEmployee.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> UpdateLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item)
        {
            IBaseEntityResponse<LeaveRuleExemptedEmployee> entityResponse = new BaseEntityResponse<LeaveRuleExemptedEmployee>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleExemptedEmployeeBR.UpdateLeaveRuleExemptedEmployeeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleExemptedEmployeeDataProvider.UpdateLeaveRuleExemptedEmployee(item);
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
        /// Delete a selected record from LeaveRuleExemptedEmployee.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> DeleteLeaveRuleExemptedEmployee(LeaveRuleExemptedEmployee item)
        {
            IBaseEntityResponse<LeaveRuleExemptedEmployee> entityResponse = new BaseEntityResponse<LeaveRuleExemptedEmployee>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _leaveRuleExemptedEmployeeBR.DeleteLeaveRuleExemptedEmployeeValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _leaveRuleExemptedEmployeeDataProvider.DeleteLeaveRuleExemptedEmployee(item);
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
        /// Select all record from LeaveRuleExemptedEmployee table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> GetBySearch(LeaveRuleExemptedEmployeeSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveRuleExemptedEmployee> LeaveRuleExemptedEmployeeCollection = new BaseEntityCollectionResponse<LeaveRuleExemptedEmployee>();
            try
            {
                if (_leaveRuleExemptedEmployeeDataProvider != null)
                    LeaveRuleExemptedEmployeeCollection = _leaveRuleExemptedEmployeeDataProvider.GetLeaveRuleExemptedEmployeeBySearch(searchRequest);
                else
                {
                    LeaveRuleExemptedEmployeeCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveRuleExemptedEmployeeCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveRuleExemptedEmployeeCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveRuleExemptedEmployeeCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveRuleExemptedEmployeeCollection;
        }
        /// <summary>
        /// Select a record from LeaveRuleExemptedEmployee table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<LeaveRuleExemptedEmployee> SelectByID(LeaveRuleExemptedEmployee item)
        {
            IBaseEntityResponse<LeaveRuleExemptedEmployee> entityResponse = new BaseEntityResponse<LeaveRuleExemptedEmployee>();
            try
            {
                entityResponse = _leaveRuleExemptedEmployeeDataProvider.GetLeaveRuleExemptedEmployeeByID(item);
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
