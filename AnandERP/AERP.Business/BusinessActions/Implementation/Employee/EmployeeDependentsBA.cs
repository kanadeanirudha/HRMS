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
    public class EmployeeDependentsBA : IEmployeeDependentsBA
    {
        IEmployeeDependentsDataProvider _employeeDependentsDataProvider;
        IEmployeeDependentsBR _employeeDependentsBR;
        private ILogger _logException;
        public EmployeeDependentsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeDependentsBR = new EmployeeDependentsBR();
            _employeeDependentsDataProvider = new EmployeeDependentsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeDependents.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> InsertEmployeeDependents(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> entityResponse = new BaseEntityResponse<EmployeeDependents>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeDependentsBR.InsertEmployeeDependentsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeDependentsDataProvider.InsertEmployeeDependents(item);
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
        /// Update a specific record  of EmployeeDependents.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> UpdateEmployeeDependents(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> entityResponse = new BaseEntityResponse<EmployeeDependents>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeDependentsBR.UpdateEmployeeDependentsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeDependentsDataProvider.UpdateEmployeeDependents(item);
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
        /// Delete a selected record from EmployeeDependents.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> DeleteEmployeeDependents(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> entityResponse = new BaseEntityResponse<EmployeeDependents>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeDependentsBR.DeleteEmployeeDependentsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeDependentsDataProvider.DeleteEmployeeDependents(item);
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
        /// Select all record from EmployeeDependents table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeDependents> GetBySearch(EmployeeDependentsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeDependents> EmployeeDependentsCollection = new BaseEntityCollectionResponse<EmployeeDependents>();
            try
            {
                if (_employeeDependentsDataProvider != null)
                    EmployeeDependentsCollection = _employeeDependentsDataProvider.GetEmployeeDependentsBySearch(searchRequest);
                else
                {
                    EmployeeDependentsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeDependentsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeDependentsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeDependentsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeDependentsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeDependents table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDependents> SelectByID(EmployeeDependents item)
        {
            IBaseEntityResponse<EmployeeDependents> entityResponse = new BaseEntityResponse<EmployeeDependents>();
            try
            {
                entityResponse = _employeeDependentsDataProvider.GetEmployeeDependentsByID(item);
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
