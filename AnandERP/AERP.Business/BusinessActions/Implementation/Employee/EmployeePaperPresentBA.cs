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
    public class EmployeePaperPresentBA : IEmployeePaperPresentBA
    {
        IEmployeePaperPresentDataProvider _employeePaperPresentDataProvider;
        IEmployeePaperPresentBR _employeePaperPresentBR;
        private ILogger _logException;
        public EmployeePaperPresentBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeePaperPresentBR = new EmployeePaperPresentBR();
            _employeePaperPresentDataProvider = new EmployeePaperPresentDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeePaperPresent.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresent(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePaperPresentBR.InsertEmployeePaperPresentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePaperPresentDataProvider.InsertEmployeePaperPresent(item);
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
        /// Update a specific record  of EmployeePaperPresent.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresent(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePaperPresentBR.UpdateEmployeePaperPresentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePaperPresentDataProvider.UpdateEmployeePaperPresent(item);
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
        /// Delete a selected record from EmployeePaperPresent.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresent(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePaperPresentBR.DeleteEmployeePaperPresentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePaperPresentDataProvider.DeleteEmployeePaperPresent(item);
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
        /// Select all record from EmployeePaperPresent table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetBySearch(EmployeePaperPresentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePaperPresent> EmployeePaperPresentCollection = new BaseEntityCollectionResponse<EmployeePaperPresent>();
            try
            {
                if (_employeePaperPresentDataProvider != null)
                    EmployeePaperPresentCollection = _employeePaperPresentDataProvider.GetEmployeePaperPresentBySearch(searchRequest);
                else
                {
                    EmployeePaperPresentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePaperPresentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePaperPresentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePaperPresentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePaperPresentCollection;
        }
        /// <summary>
        /// Select a record from EmployeePaperPresent table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> SelectByID(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                entityResponse = _employeePaperPresentDataProvider.GetEmployeePaperPresentByID(item);
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
        /// Select all record from EmployeePaperPresent table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetAppliedDetails(EmployeePaperPresentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePaperPresent> EmployeePaperPresentCollection = new BaseEntityCollectionResponse<EmployeePaperPresent>();
            try
            {
                if (_employeePaperPresentDataProvider != null)
                    EmployeePaperPresentCollection = _employeePaperPresentDataProvider.GetEmployeePaperPresentAppliedDetails(searchRequest);
                else
                {
                    EmployeePaperPresentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePaperPresentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePaperPresentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePaperPresentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePaperPresentCollection;
        }
        


        /// <summary>
        /// Create new record of EmployeePaperPresenter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> InsertEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePaperPresentBR.InsertEmployeePaperPresenterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePaperPresentDataProvider.InsertEmployeePaperPresenter(item);
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
        /// Update a specific record  of EmployeePaperPresenter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> UpdateEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePaperPresentBR.UpdateEmployeePaperPresenterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePaperPresentDataProvider.UpdateEmployeePaperPresenter(item);
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
        /// Delete a selected record from EmployeePaperPresenter.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> DeleteEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeePaperPresentBR.DeleteEmployeePaperPresenterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeePaperPresentDataProvider.DeleteEmployeePaperPresenter(item);
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
        /// Select all record from EmployeePaperPresenter table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeePaperPresent> GetBySearchEmployeePaperPresenter(EmployeePaperPresentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePaperPresent> EmployeePaperPresenterCollection = new BaseEntityCollectionResponse<EmployeePaperPresent>();
            try
            {
                if (_employeePaperPresentDataProvider != null)
                    EmployeePaperPresenterCollection = _employeePaperPresentDataProvider.GetEmployeePaperPresenterBySearch(searchRequest);
                else
                {
                    EmployeePaperPresenterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePaperPresenterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePaperPresenterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePaperPresenterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePaperPresenterCollection;
        }
        /// <summary>
        /// Select a record from EmployeePaperPresenter table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeePaperPresent> SelectByIDEmployeePaperPresenter(EmployeePaperPresent item)
        {
            IBaseEntityResponse<EmployeePaperPresent> entityResponse = new BaseEntityResponse<EmployeePaperPresent>();
            try
            {
                entityResponse = _employeePaperPresentDataProvider.GetEmployeePaperPresenterByID(item);
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
