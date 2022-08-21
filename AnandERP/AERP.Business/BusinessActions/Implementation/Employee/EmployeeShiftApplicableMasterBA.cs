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
    public class EmployeeShiftApplicableMasterBA : IEmployeeShiftApplicableMasterBA
    {
        IEmployeeShiftApplicableMasterDataProvider _employeeShiftApplicableMasterDataProvider;
        IEmployeeShiftApplicableMasterBR _employeeShiftApplicableMasterBR;
        private ILogger _logException;
        public EmployeeShiftApplicableMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeShiftApplicableMasterBR = new EmployeeShiftApplicableMasterBR();
            _employeeShiftApplicableMasterDataProvider = new EmployeeShiftApplicableMasterDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeShiftApplicableMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> InsertEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item)
        {
            IBaseEntityResponse<EmployeeShiftApplicableMaster> entityResponse = new BaseEntityResponse<EmployeeShiftApplicableMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftApplicableMasterBR.InsertEmployeeShiftApplicableMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftApplicableMasterDataProvider.InsertEmployeeShiftApplicableMaster(item);
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
        /// Update a specific record  of EmployeeShiftApplicableMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> UpdateEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item)
        {
            IBaseEntityResponse<EmployeeShiftApplicableMaster> entityResponse = new BaseEntityResponse<EmployeeShiftApplicableMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftApplicableMasterBR.UpdateEmployeeShiftApplicableMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftApplicableMasterDataProvider.UpdateEmployeeShiftApplicableMaster(item);
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
        /// Delete a selected record from EmployeeShiftApplicableMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> DeleteEmployeeShiftApplicableMaster(EmployeeShiftApplicableMaster item)
        {
            IBaseEntityResponse<EmployeeShiftApplicableMaster> entityResponse = new BaseEntityResponse<EmployeeShiftApplicableMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeShiftApplicableMasterBR.DeleteEmployeeShiftApplicableMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeShiftApplicableMasterDataProvider.DeleteEmployeeShiftApplicableMaster(item);
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
        /// Select all record from EmployeeShiftApplicableMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeShiftApplicableMaster> GetBySearch(EmployeeShiftApplicableMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeShiftApplicableMaster> EmployeeShiftApplicableMasterCollection = new BaseEntityCollectionResponse<EmployeeShiftApplicableMaster>();
            try
            {
                if (_employeeShiftApplicableMasterDataProvider != null)
                    EmployeeShiftApplicableMasterCollection = _employeeShiftApplicableMasterDataProvider.GetEmployeeShiftApplicableMasterBySearch(searchRequest);
                else
                {
                    EmployeeShiftApplicableMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeShiftApplicableMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeShiftApplicableMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeShiftApplicableMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeShiftApplicableMasterCollection;
        }
        /// <summary>
        /// Select a record from EmployeeShiftApplicableMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeShiftApplicableMaster> SelectByID(EmployeeShiftApplicableMaster item)
        {
            IBaseEntityResponse<EmployeeShiftApplicableMaster> entityResponse = new BaseEntityResponse<EmployeeShiftApplicableMaster>();
            try
            {
                entityResponse = _employeeShiftApplicableMasterDataProvider.GetEmployeeShiftApplicableMasterByID(item);
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
