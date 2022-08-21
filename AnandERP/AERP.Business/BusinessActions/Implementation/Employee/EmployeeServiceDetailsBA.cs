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
    public class EmployeeServiceDetailsBA : IEmployeeServiceDetailsBA
    {
        IEmployeeServiceDetailsDataProvider _EmployeeServiceDetailsDataProvider;
        IEmployeeServiceDetailsBR _EmployeeServiceDetailsBR;
        private ILogger _logException;
        public EmployeeServiceDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeServiceDetailsBR = new EmployeeServiceDetailsBR();
            _EmployeeServiceDetailsDataProvider = new EmployeeServiceDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeServiceDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> InsertEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> entityResponse = new BaseEntityResponse<EmployeeServiceDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EmployeeServiceDetailsBR.InsertEmployeeServiceDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EmployeeServiceDetailsDataProvider.InsertEmployeeServiceDetails(item);
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
        /// Update a specific record  of EmployeeServiceDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> UpdateEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> entityResponse = new BaseEntityResponse<EmployeeServiceDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EmployeeServiceDetailsBR.UpdateEmployeeServiceDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EmployeeServiceDetailsDataProvider.UpdateEmployeeServiceDetails(item);
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
        /// Delete a selected record from EmployeeServiceDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> DeleteEmployeeServiceDetails(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> entityResponse = new BaseEntityResponse<EmployeeServiceDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _EmployeeServiceDetailsBR.DeleteEmployeeServiceDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _EmployeeServiceDetailsDataProvider.DeleteEmployeeServiceDetails(item);
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
        /// Select all record from EmployeeServiceDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeServiceDetails> GetBySearch(EmployeeServiceDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeServiceDetails> EmployeeServiceDetailsCollection = new BaseEntityCollectionResponse<EmployeeServiceDetails>();
            try
            {
                if (_EmployeeServiceDetailsDataProvider != null)
                    EmployeeServiceDetailsCollection = _EmployeeServiceDetailsDataProvider.GetEmployeeServiceDetailsBySearch(searchRequest);
                else
                {
                    EmployeeServiceDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeServiceDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeServiceDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeServiceDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeServiceDetailsCollection;
        }

        /// <summary>
        /// Select all record from EmployeeServiceDetails table with search List.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeServiceDetails> GetBySearchList(EmployeeServiceDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeServiceDetails> EmployeeServiceDetailsCollection = new BaseEntityCollectionResponse<EmployeeServiceDetails>();
            try
            {
                if (_EmployeeServiceDetailsDataProvider != null)
                    //EmployeeServiceDetailsCollection = _EmployeeServiceDetailsDataProvider.GetEmployeeServiceDetailsBySearchLists(searchRequest);
                    EmployeeServiceDetailsCollection = _EmployeeServiceDetailsDataProvider.GetEmployeeServiceDetailsBySearchList(searchRequest);
                else
                {
                    EmployeeServiceDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeServiceDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeServiceDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeServiceDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeServiceDetailsCollection;
        }
        /// <summary>
        /// Select a record from EmployeeServiceDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> SelectByID(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> entityResponse = new BaseEntityResponse<EmployeeServiceDetails>();
            try
            {
                entityResponse = _EmployeeServiceDetailsDataProvider.GetEmployeeServiceDetailsByID(item);
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
        /// Select a record from EmployeeServiceDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeServiceDetails> SelectByEmployeeID(EmployeeServiceDetails item)
        {
            IBaseEntityResponse<EmployeeServiceDetails> entityResponse = new BaseEntityResponse<EmployeeServiceDetails>();
            try
            {
                entityResponse = _EmployeeServiceDetailsDataProvider.GetEmployeeServiceDetailsByEmployeeID(item);
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


