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
    public class EmployeeDocumentRequiredBA : IEmployeeDocumentRequiredBA
    {
        IEmployeeDocumentRequiredDataProvider _employeeDocumentRequiredDataProvider;
        IEmployeeDocumentRequiredBR _employeeDocumentRequiredBR;
        private ILogger _logException;
        public EmployeeDocumentRequiredBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeDocumentRequiredBR = new EmployeeDocumentRequiredBR();
            _employeeDocumentRequiredDataProvider = new EmployeeDocumentRequiredDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeDocumentRequired.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDocumentRequired> InsertEmployeeDocumentRequired(EmployeeDocumentRequired item)
        {
            IBaseEntityResponse<EmployeeDocumentRequired> entityResponse = new BaseEntityResponse<EmployeeDocumentRequired>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeDocumentRequiredBR.InsertEmployeeDocumentRequiredValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeDocumentRequiredDataProvider.InsertEmployeeDocumentRequired(item);
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
        /// Update a specific record  of EmployeeDocumentRequired.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDocumentRequired> UpdateEmployeeDocumentRequired(EmployeeDocumentRequired item)
        {
            IBaseEntityResponse<EmployeeDocumentRequired> entityResponse = new BaseEntityResponse<EmployeeDocumentRequired>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeDocumentRequiredBR.UpdateEmployeeDocumentRequiredValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeDocumentRequiredDataProvider.UpdateEmployeeDocumentRequired(item);
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
        /// Delete a selected record from EmployeeDocumentRequired.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDocumentRequired> DeleteEmployeeDocumentRequired(EmployeeDocumentRequired item)
        {
            IBaseEntityResponse<EmployeeDocumentRequired> entityResponse = new BaseEntityResponse<EmployeeDocumentRequired>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeDocumentRequiredBR.DeleteEmployeeDocumentRequiredValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeDocumentRequiredDataProvider.DeleteEmployeeDocumentRequired(item);
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
        /// Select all record from EmployeeDocumentRequired table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeDocumentRequired> GetBySearch(EmployeeDocumentRequiredSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeDocumentRequired> EmployeeDocumentRequiredCollection = new BaseEntityCollectionResponse<EmployeeDocumentRequired>();
            try
            {
                if (_employeeDocumentRequiredDataProvider != null)
                    EmployeeDocumentRequiredCollection = _employeeDocumentRequiredDataProvider.GetEmployeeDocumentRequiredBySearch(searchRequest);
                else
                {
                    EmployeeDocumentRequiredCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeDocumentRequiredCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeDocumentRequiredCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeDocumentRequiredCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeDocumentRequiredCollection;
        }
        /// <summary>
        /// Select a record from EmployeeDocumentRequired table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeDocumentRequired> SelectByID(EmployeeDocumentRequired item)
        {
            IBaseEntityResponse<EmployeeDocumentRequired> entityResponse = new BaseEntityResponse<EmployeeDocumentRequired>();
            try
            {
                entityResponse = _employeeDocumentRequiredDataProvider.GetEmployeeDocumentRequiredByID(item);
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
        /// Select all record from EmployeeDocumentRequired table with search parameters LeaveRuleMasterID.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeDocumentRequired> SelectByLeaveRuleMasterID(EmployeeDocumentRequiredSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeDocumentRequired> EmployeeDocumentRequiredCollection = new BaseEntityCollectionResponse<EmployeeDocumentRequired>();
            try
            {
                if (_employeeDocumentRequiredDataProvider != null)
                    EmployeeDocumentRequiredCollection = _employeeDocumentRequiredDataProvider.SelectByLeaveRuleMasterID(searchRequest);
                else
                {
                    EmployeeDocumentRequiredCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeDocumentRequiredCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeDocumentRequiredCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeDocumentRequiredCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeDocumentRequiredCollection;
        }
        
    }
}
