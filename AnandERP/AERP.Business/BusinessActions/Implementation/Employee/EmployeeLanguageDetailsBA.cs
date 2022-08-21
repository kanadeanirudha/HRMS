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
    public class EmployeeLanguageDetailsBA : IEmployeeLanguageDetailsBA
    {
        IEmployeeLanguageDetailsDataProvider _employeeLanguageDetailsDataProvider;
        IEmployeeLanguageDetailsBR _employeeLanguageDetailsBR;
        private ILogger _logException;
        public EmployeeLanguageDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeLanguageDetailsBR = new EmployeeLanguageDetailsBR();
            _employeeLanguageDetailsDataProvider = new EmployeeLanguageDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeLanguageDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeLanguageDetails> InsertEmployeeLanguageDetails(EmployeeLanguageDetails item)
        {
            IBaseEntityResponse<EmployeeLanguageDetails> entityResponse = new BaseEntityResponse<EmployeeLanguageDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeLanguageDetailsBR.InsertEmployeeLanguageDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeLanguageDetailsDataProvider.InsertEmployeeLanguageDetails(item);
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
        /// Update a specific record  of EmployeeLanguageDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeLanguageDetails> UpdateEmployeeLanguageDetails(EmployeeLanguageDetails item)
        {
            IBaseEntityResponse<EmployeeLanguageDetails> entityResponse = new BaseEntityResponse<EmployeeLanguageDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeLanguageDetailsBR.UpdateEmployeeLanguageDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeLanguageDetailsDataProvider.UpdateEmployeeLanguageDetails(item);
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
        /// Delete a selected record from EmployeeLanguageDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeLanguageDetails> DeleteEmployeeLanguageDetails(EmployeeLanguageDetails item)
        {
            IBaseEntityResponse<EmployeeLanguageDetails> entityResponse = new BaseEntityResponse<EmployeeLanguageDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeLanguageDetailsBR.DeleteEmployeeLanguageDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeLanguageDetailsDataProvider.DeleteEmployeeLanguageDetails(item);
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
        /// Select all record from EmployeeLanguageDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetBySearch(EmployeeLanguageDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeLanguageDetails> EmployeeLanguageDetailsCollection = new BaseEntityCollectionResponse<EmployeeLanguageDetails>();
            try
            {
                if (_employeeLanguageDetailsDataProvider != null)
                    EmployeeLanguageDetailsCollection = _employeeLanguageDetailsDataProvider.GetEmployeeLanguageDetailsBySearch(searchRequest);
                else
                {
                    EmployeeLanguageDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeLanguageDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeLanguageDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeLanguageDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeLanguageDetailsCollection;
        }


        /// <summary>
        /// Select all record from EmployeeLanguageDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetBySearchList(EmployeeLanguageDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeLanguageDetails> EmployeeLanguageDetailsCollection = new BaseEntityCollectionResponse<EmployeeLanguageDetails>();
            try
            {
                if (_employeeLanguageDetailsDataProvider != null)
                    EmployeeLanguageDetailsCollection = _employeeLanguageDetailsDataProvider.GetEmployeeLanguageDetailsBySearch(searchRequest);
                      // EmployeeLanguageDetailsCollection = _employeeLanguageDetailsDataProvider.GetEmployeeLanguageDetailsBySearchList(searchRequest);
                else
                {
                    EmployeeLanguageDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeLanguageDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeLanguageDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeLanguageDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeLanguageDetailsCollection;
        }


         /// <summary>
        /// Select all record from EmployeeLanguageDetails and language master tables by emolpyee id  
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeLanguageDetails> GetEmployeeLanguageDetailsByID(EmployeeLanguageDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeLanguageDetails> EmployeeLanguageDetailsCollection = new BaseEntityCollectionResponse<EmployeeLanguageDetails>();
            try
            {
                if (_employeeLanguageDetailsDataProvider != null)
                    EmployeeLanguageDetailsCollection = _employeeLanguageDetailsDataProvider.GetEmployeeLanguageDetailsByID(searchRequest);
                    
                else
                {
                    EmployeeLanguageDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeLanguageDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeLanguageDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeLanguageDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeLanguageDetailsCollection;
        }
        
        /// <summary>
        /// Select a record from EmployeeLanguageDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// 

        public IBaseEntityResponse<EmployeeLanguageDetails> SelectByID(EmployeeLanguageDetails item)
        {
            IBaseEntityResponse<EmployeeLanguageDetails> entityResponse = new BaseEntityResponse<EmployeeLanguageDetails>();
            try
            {
                entityResponse = _employeeLanguageDetailsDataProvider.GetEmployeeLanguageDetailsByID(item);
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
