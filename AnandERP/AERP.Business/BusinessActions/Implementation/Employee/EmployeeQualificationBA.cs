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
    public class EmployeeQualificationBA : IEmployeeQualificationBA
    {
        IEmployeeQualificationDataProvider _employeeQualificationDataProvider;
        IEmployeeQualificationBR _employeeQualificationBR;
        private ILogger _logException;
        public EmployeeQualificationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeQualificationBR = new EmployeeQualificationBR();
            _employeeQualificationDataProvider = new EmployeeQualificationDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeQualification.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeQualification> InsertEmployeeQualification(EmployeeQualification item)
        {
            IBaseEntityResponse<EmployeeQualification> entityResponse = new BaseEntityResponse<EmployeeQualification>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeQualificationBR.InsertEmployeeQualificationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeQualificationDataProvider.InsertEmployeeQualification(item);
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
        /// Update a specific record  of EmployeeQualification.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeQualification> UpdateEmployeeQualification(EmployeeQualification item)
        {
            IBaseEntityResponse<EmployeeQualification> entityResponse = new BaseEntityResponse<EmployeeQualification>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeQualificationBR.UpdateEmployeeQualificationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeQualificationDataProvider.UpdateEmployeeQualification(item);
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
        /// Delete a selected record from EmployeeQualification.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeQualification> DeleteEmployeeQualification(EmployeeQualification item)
        {
            IBaseEntityResponse<EmployeeQualification> entityResponse = new BaseEntityResponse<EmployeeQualification>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeQualificationBR.DeleteEmployeeQualificationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeQualificationDataProvider.DeleteEmployeeQualification(item);
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
        /// Select all record from EmployeeQualification table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeQualification> GetBySearch(EmployeeQualificationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeQualification> EmployeeQualificationCollection = new BaseEntityCollectionResponse<EmployeeQualification>();
            try
            {
                if (_employeeQualificationDataProvider != null)
                    EmployeeQualificationCollection = _employeeQualificationDataProvider.GetEmployeeQualificationBySearch(searchRequest);
                else
                {
                    EmployeeQualificationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeQualificationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeQualificationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeQualificationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeQualificationCollection;
        }
        /// <summary>
        /// Select a record from EmployeeQualification table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeQualification> SelectByID(EmployeeQualification item)
        {
            IBaseEntityResponse<EmployeeQualification> entityResponse = new BaseEntityResponse<EmployeeQualification>();
            try
            {
                entityResponse = _employeeQualificationDataProvider.GetEmployeeQualificationByID(item);
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
