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
    public class EmployeeShiftMasterBA : IEmployeeShiftMasterBA
    {
        IEmployeeShiftMasterDataProvider _employeeShiftMasterDataProvider;
        IEmployeeShiftMasterBR _employeeShiftMasterBR;
        private ILogger _logException;
        public EmployeeShiftMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeShiftMasterBR = new EmployeeShiftMasterBR();
            _employeeShiftMasterDataProvider = new EmployeeShiftMasterDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeShiftMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftMasterBR.InsertEmployeeShiftMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftMasterDataProvider.InsertEmployeeShiftMaster(item);
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
        /// Update a specific record  of EmployeeShiftMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftMasterBR.UpdateEmployeeShiftMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftMasterDataProvider.UpdateEmployeeShiftMaster(item);
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
        /// Delete a selected record from EmployeeShiftMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> DeleteEmployeeShiftMaster(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftMasterBR.DeleteEmployeeShiftMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftMasterDataProvider.DeleteEmployeeShiftMaster(item);
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
        /// Select all record from EmployeeShiftMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetBySearch(EmployeeShiftMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftMaster> EmployeeShiftMasterCollection = new BaseEntityCollectionResponse<EmployeeShiftMaster>();
            try
            {
                if (_employeeShiftMasterDataProvider != null)
                    EmployeeShiftMasterCollection = _employeeShiftMasterDataProvider.GetEmployeeShiftMasterBySearch(searchRequest);
                else
                {
                    EmployeeShiftMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeShiftMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeShiftMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeShiftMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeShiftMasterCollection;
        }


        /// <summary>
        /// Select records from EmployeeShiftMaster table with search parameters for dropdown.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetBySearchList(EmployeeShiftMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftMaster> EmployeeShiftMasterCollection = new BaseEntityCollectionResponse<EmployeeShiftMaster>();
            try
            {
                if (_employeeShiftMasterDataProvider != null)
                    EmployeeShiftMasterCollection = _employeeShiftMasterDataProvider.GetEmployeeShiftMasterBySearchList(searchRequest);
                else
                {
                    EmployeeShiftMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeShiftMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeShiftMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeShiftMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeShiftMasterCollection;
        }
        /// <summary>
        /// Select a record from EmployeeShiftMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> SelectByEmployeeShiftMasterID(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                entityResponse = _employeeShiftMasterDataProvider.GetEmployeeShiftMasterBySelectByEmployeeShiftMasterID(item);
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
        /// Select all record from EmployeeShiftMasterDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeShiftMaster> GetEmployeeShiftMasterDetailsBySearch(EmployeeShiftMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftMaster> EmployeeShiftMasterCollection = new BaseEntityCollectionResponse<EmployeeShiftMaster>();
            try
            {
                if (_employeeShiftMasterDataProvider != null)
                    EmployeeShiftMasterCollection = _employeeShiftMasterDataProvider.GetEmployeeShiftMasterDetailsBySearch(searchRequest);
                else
                {
                    EmployeeShiftMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeShiftMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeShiftMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeShiftMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeShiftMasterCollection;
        }

        /// <summary>
        /// Create new record of EmployeeShiftMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> InsertEmployeeShiftMasterDetails(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftMasterBR.InsertEmployeeShiftMasterDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftMasterDataProvider.InsertEmployeeShiftMasterDetails(item);
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
        /// Select a record from EmployeeShiftMasterDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> SelectByEmployeeShiftMasterDetailsID(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                entityResponse = _employeeShiftMasterDataProvider.GetEmployeeShiftMasterDetailsBySelectByEmployeeShiftMasterDetailsID(item);
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
        /// Update record of EmployeeShiftMasterDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftMaster> UpdateEmployeeShiftMasterDetails(EmployeeShiftMaster item)
        {
            IBaseEntityResponse<EmployeeShiftMaster> entityResponse = new BaseEntityResponse<EmployeeShiftMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftMasterBR.UpdateEmployeeShiftMasterDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftMasterDataProvider.UpdateEmployeeShiftMasterDetails(item);
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
        
    }
}
