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
    public class EmployeePrizesWonDetailsBA : IEmployeePrizesWonDetailsBA
    {
        IEmployeePrizesWonDetailsDataProvider _employeePrizesWonDetailsDataProvider;
        IEmployeePrizesWonDetailsBR _employeePrizesWonDetailsBR;
        private ILogger _logException;
        public EmployeePrizesWonDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeePrizesWonDetailsBR = new EmployeePrizesWonDetailsBR();
            _employeePrizesWonDetailsDataProvider = new EmployeePrizesWonDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeePrizesWonDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePrizesWonDetails> InsertEmployeePrizesWonDetails(EmployeePrizesWonDetails item)
        {
            IBaseEntityResponse<EmployeePrizesWonDetails> entityResponse = new BaseEntityResponse<EmployeePrizesWonDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePrizesWonDetailsBR.InsertEmployeePrizesWonDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePrizesWonDetailsDataProvider.InsertEmployeePrizesWonDetails(item);
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
        /// Update a specific record  of EmployeePrizesWonDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePrizesWonDetails> UpdateEmployeePrizesWonDetails(EmployeePrizesWonDetails item)
        {
            IBaseEntityResponse<EmployeePrizesWonDetails> entityResponse = new BaseEntityResponse<EmployeePrizesWonDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePrizesWonDetailsBR.UpdateEmployeePrizesWonDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePrizesWonDetailsDataProvider.UpdateEmployeePrizesWonDetails(item);
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
        /// Delete a selected record from EmployeePrizesWonDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePrizesWonDetails> DeleteEmployeePrizesWonDetails(EmployeePrizesWonDetails item)
        {
            IBaseEntityResponse<EmployeePrizesWonDetails> entityResponse = new BaseEntityResponse<EmployeePrizesWonDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePrizesWonDetailsBR.DeleteEmployeePrizesWonDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePrizesWonDetailsDataProvider.DeleteEmployeePrizesWonDetails(item);
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
        /// Select all record from EmployeePrizesWonDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePrizesWonDetails> GetBySearch(EmployeePrizesWonDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePrizesWonDetails> EmployeePrizesWonDetailsCollection = new BaseEntityCollectionResponse<EmployeePrizesWonDetails>();
            try
            {
                if (_employeePrizesWonDetailsDataProvider != null)
                    EmployeePrizesWonDetailsCollection = _employeePrizesWonDetailsDataProvider.GetEmployeePrizesWonDetailsBySearch(searchRequest);
                else
                {
                    EmployeePrizesWonDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePrizesWonDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePrizesWonDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePrizesWonDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePrizesWonDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeePrizesWonDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePrizesWonDetails> SelectByID(EmployeePrizesWonDetails item)
        {
            IBaseEntityResponse<EmployeePrizesWonDetails> entityResponse = new BaseEntityResponse<EmployeePrizesWonDetails>();
            try
            {
                entityResponse = _employeePrizesWonDetailsDataProvider.GetEmployeePrizesWonDetailsByID(item);
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
