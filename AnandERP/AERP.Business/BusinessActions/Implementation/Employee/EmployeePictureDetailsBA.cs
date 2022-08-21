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
    public class EmployeePictureDetailsBA : IEmployeePictureDetailsBA
    {
        IEmployeePictureDetailsDataProvider _employeePictureDetailsDataProvider;
        IEmployeePictureDetailsBR _employeePictureDetailsBR;
        private ILogger _logException;
        public EmployeePictureDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeePictureDetailsBR = new EmployeePictureDetailsBR();
            _employeePictureDetailsDataProvider = new EmployeePictureDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeePictureDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePictureDetails> InsertEmployeePictureDetails(EmployeePictureDetails item)
        {
            IBaseEntityResponse<EmployeePictureDetails> entityResponse = new BaseEntityResponse<EmployeePictureDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePictureDetailsBR.InsertEmployeePictureDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePictureDetailsDataProvider.InsertEmployeePictureDetails(item);
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
        /// Update a specific record  of EmployeePictureDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePictureDetails> UpdateEmployeePictureDetails(EmployeePictureDetails item)
        {
            IBaseEntityResponse<EmployeePictureDetails> entityResponse = new BaseEntityResponse<EmployeePictureDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePictureDetailsBR.UpdateEmployeePictureDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePictureDetailsDataProvider.UpdateEmployeePictureDetails(item);
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
        /// Delete a selected record from EmployeePictureDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePictureDetails> DeleteEmployeePictureDetails(EmployeePictureDetails item)
        {
            IBaseEntityResponse<EmployeePictureDetails> entityResponse = new BaseEntityResponse<EmployeePictureDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePictureDetailsBR.DeleteEmployeePictureDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePictureDetailsDataProvider.DeleteEmployeePictureDetails(item);
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
        /// Select all record from EmployeePictureDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePictureDetails> GetBySearch(EmployeePictureDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePictureDetails> EmployeePictureDetailsCollection = new BaseEntityCollectionResponse<EmployeePictureDetails>();
            try
            {
                if (_employeePictureDetailsDataProvider != null)
                    EmployeePictureDetailsCollection = _employeePictureDetailsDataProvider.GetEmployeePictureDetailsBySearch(searchRequest);
                else
                {
                    EmployeePictureDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePictureDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePictureDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePictureDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePictureDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeePictureDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePictureDetails> SelectByID(EmployeePictureDetails item)
        {
            IBaseEntityResponse<EmployeePictureDetails> entityResponse = new BaseEntityResponse<EmployeePictureDetails>();
            try
            {
                entityResponse = _employeePictureDetailsDataProvider.GetEmployeePictureDetailsByID(item);
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
