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
    public class EmployeeAssociatesProfessionalBodiesBA : IEmployeeAssociatesProfessionalBodiesBA
    {
        IEmployeeAssociatesProfessionalBodiesDataProvider _employeeAssociatesProfessionalBodiesDataProvider;
        IEmployeeAssociatesProfessionalBodiesBR _employeeAssociatesProfessionalBodiesBR;
        private ILogger _logException;
        public EmployeeAssociatesProfessionalBodiesBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _employeeAssociatesProfessionalBodiesBR = new EmployeeAssociatesProfessionalBodiesBR();
            _employeeAssociatesProfessionalBodiesDataProvider = new EmployeeAssociatesProfessionalBodiesDataProvider();
        }
        /// <summary>
        /// Create new record of EmployeeAssociatesProfessionalBodies.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> InsertEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item)
        {
            IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> entityResponse = new BaseEntityResponse<EmployeeAssociatesProfessionalBodies>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeAssociatesProfessionalBodiesBR.InsertEmployeeAssociatesProfessionalBodiesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeAssociatesProfessionalBodiesDataProvider.InsertEmployeeAssociatesProfessionalBodies(item);
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
        /// Update a specific record  of EmployeeAssociatesProfessionalBodies.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> UpdateEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item)
        {
            IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> entityResponse = new BaseEntityResponse<EmployeeAssociatesProfessionalBodies>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeAssociatesProfessionalBodiesBR.UpdateEmployeeAssociatesProfessionalBodiesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeAssociatesProfessionalBodiesDataProvider.UpdateEmployeeAssociatesProfessionalBodies(item);
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
        /// Delete a selected record from EmployeeAssociatesProfessionalBodies.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> DeleteEmployeeAssociatesProfessionalBodies(EmployeeAssociatesProfessionalBodies item)
        {
            IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> entityResponse = new BaseEntityResponse<EmployeeAssociatesProfessionalBodies>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _employeeAssociatesProfessionalBodiesBR.DeleteEmployeeAssociatesProfessionalBodiesValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _employeeAssociatesProfessionalBodiesDataProvider.DeleteEmployeeAssociatesProfessionalBodies(item);
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
        /// Select all record from EmployeeAssociatesProfessionalBodies table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies> GetBySearch(EmployeeAssociatesProfessionalBodiesSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies> EmployeeAssociatesProfessionalBodiesCollection = new BaseEntityCollectionResponse<EmployeeAssociatesProfessionalBodies>();
            try
            {
                if (_employeeAssociatesProfessionalBodiesDataProvider != null)
                    EmployeeAssociatesProfessionalBodiesCollection = _employeeAssociatesProfessionalBodiesDataProvider.GetEmployeeAssociatesProfessionalBodiesBySearch(searchRequest);
                else
                {
                    EmployeeAssociatesProfessionalBodiesCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeAssociatesProfessionalBodiesCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeAssociatesProfessionalBodiesCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeAssociatesProfessionalBodiesCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeAssociatesProfessionalBodiesCollection;
        }
        /// <summary>
        /// Select a record from EmployeeAssociatesProfessionalBodies table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> SelectByID(EmployeeAssociatesProfessionalBodies item)
        {
            IBaseEntityResponse<EmployeeAssociatesProfessionalBodies> entityResponse = new BaseEntityResponse<EmployeeAssociatesProfessionalBodies>();
            try
            {
                entityResponse = _employeeAssociatesProfessionalBodiesDataProvider.GetEmployeeAssociatesProfessionalBodiesByID(item);
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
