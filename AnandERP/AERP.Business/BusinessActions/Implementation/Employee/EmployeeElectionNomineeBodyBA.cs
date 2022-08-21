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
    public class EmployeeElectionNomineeBodyBA : IEmployeeElectionNomineeBodyBA
    {
        IEmployeeElectionNomineeBodyDataProvider _employeeElectionNomineeBodyDataProvider;
        IEmployeeElectionNomineeBodyBR _employeeElectionNomineeBodyBR;
        private ILogger _logException;
        public EmployeeElectionNomineeBodyBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeElectionNomineeBodyBR = new EmployeeElectionNomineeBodyBR();
            _employeeElectionNomineeBodyDataProvider = new EmployeeElectionNomineeBodyDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeElectionNomineeBody.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeElectionNomineeBody> InsertEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item)
        {
            IBaseEntityResponse<EmployeeElectionNomineeBody> entityResponse = new BaseEntityResponse<EmployeeElectionNomineeBody>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeElectionNomineeBodyBR.InsertEmployeeElectionNomineeBodyValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeElectionNomineeBodyDataProvider.InsertEmployeeElectionNomineeBody(item);
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
        /// Update a specific record  of EmployeeElectionNomineeBody.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeElectionNomineeBody> UpdateEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item)
        {
            IBaseEntityResponse<EmployeeElectionNomineeBody> entityResponse = new BaseEntityResponse<EmployeeElectionNomineeBody>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeElectionNomineeBodyBR.UpdateEmployeeElectionNomineeBodyValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeElectionNomineeBodyDataProvider.UpdateEmployeeElectionNomineeBody(item);
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
        /// Delete a selected record from EmployeeElectionNomineeBody.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeElectionNomineeBody> DeleteEmployeeElectionNomineeBody(EmployeeElectionNomineeBody item)
        {
            IBaseEntityResponse<EmployeeElectionNomineeBody> entityResponse = new BaseEntityResponse<EmployeeElectionNomineeBody>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeElectionNomineeBodyBR.DeleteEmployeeElectionNomineeBodyValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeElectionNomineeBodyDataProvider.DeleteEmployeeElectionNomineeBody(item);
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
        /// Select all record from EmployeeElectionNomineeBody table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> GetBySearch(EmployeeElectionNomineeBodySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeElectionNomineeBody> EmployeeElectionNomineeBodyCollection = new BaseEntityCollectionResponse<EmployeeElectionNomineeBody>();
            try
            {
                if (_employeeElectionNomineeBodyDataProvider != null)
                    EmployeeElectionNomineeBodyCollection = _employeeElectionNomineeBodyDataProvider.GetEmployeeElectionNomineeBodyBySearch(searchRequest);
                else
                {
                    EmployeeElectionNomineeBodyCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeElectionNomineeBodyCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeElectionNomineeBodyCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeElectionNomineeBodyCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeElectionNomineeBodyCollection;
        }
        /// <summary>
        /// Select a record from EmployeeElectionNomineeBody table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeElectionNomineeBody> SelectByID(EmployeeElectionNomineeBody item)
        {
            IBaseEntityResponse<EmployeeElectionNomineeBody> entityResponse = new BaseEntityResponse<EmployeeElectionNomineeBody>();
            try
            {
                entityResponse = _employeeElectionNomineeBodyDataProvider.GetEmployeeElectionNomineeBodyByID(item);
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
