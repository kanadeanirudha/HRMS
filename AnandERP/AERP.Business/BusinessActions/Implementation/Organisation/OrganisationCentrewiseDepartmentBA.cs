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
    public class OrganisationCentrewiseDepartmentBA : IOrganisationCentrewiseDepartmentBA
    {
        IOrganisationCentrewiseDepartmentDataProvider _organisationCentrewiseDepartmentDataProvider;
        IOrganisationCentrewiseDepartmentBR _organisationCentrewiseDepartmentBR;
        private ILogger _logException;
        public OrganisationCentrewiseDepartmentBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationCentrewiseDepartmentBR = new OrganisationCentrewiseDepartmentBR();
            _organisationCentrewiseDepartmentDataProvider = new OrganisationCentrewiseDepartmentDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationCentrewiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            IBaseEntityResponse<OrganisationCentrewiseDepartment> entityResponse = new BaseEntityResponse<OrganisationCentrewiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseDepartmentBR.InsertOrganisationCentrewiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseDepartmentDataProvider.InsertOrganisationCentrewiseDepartment(item);
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
        /// Update a specific record  of OrganisationCentrewiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> UpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            IBaseEntityResponse<OrganisationCentrewiseDepartment> entityResponse = new BaseEntityResponse<OrganisationCentrewiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseDepartmentBR.UpdateOrganisationCentrewiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseDepartmentDataProvider.UpdateOrganisationCentrewiseDepartment(item);
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
        /// Insert and Update a specific record  of OrganisationCentrewiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> InsertUpdateOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            IBaseEntityResponse<OrganisationCentrewiseDepartment> entityResponse = new BaseEntityResponse<OrganisationCentrewiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseDepartmentBR.InsertUpdateOrganisationCentrewiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseDepartmentDataProvider.InsertUpdateOrganisationCentrewiseDepartment(item);
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
        /// Delete a selected record from OrganisationCentrewiseDepartment.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> DeleteOrganisationCentrewiseDepartment(OrganisationCentrewiseDepartment item)
        {
            IBaseEntityResponse<OrganisationCentrewiseDepartment> entityResponse = new BaseEntityResponse<OrganisationCentrewiseDepartment>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationCentrewiseDepartmentBR.DeleteOrganisationCentrewiseDepartmentValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationCentrewiseDepartmentDataProvider.DeleteOrganisationCentrewiseDepartment(item);
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
        /// Select all record from OrganisationCentrewiseDepartment table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationCentrewiseDepartment> GetBySearch(OrganisationCentrewiseDepartmentSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationCentrewiseDepartment> OrganisationCentrewiseDepartmentCollection = new BaseEntityCollectionResponse<OrganisationCentrewiseDepartment>();
            try
            {
                if (_organisationCentrewiseDepartmentDataProvider != null)
                    OrganisationCentrewiseDepartmentCollection = _organisationCentrewiseDepartmentDataProvider.GetOrganisationCentrewiseDepartmentBySearch(searchRequest);
                else
                {
                    OrganisationCentrewiseDepartmentCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationCentrewiseDepartmentCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationCentrewiseDepartmentCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationCentrewiseDepartmentCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationCentrewiseDepartmentCollection;
        }
        /// <summary>
        /// Select a record from OrganisationCentrewiseDepartment table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationCentrewiseDepartment> SelectByID(OrganisationCentrewiseDepartment item)
        {
            IBaseEntityResponse<OrganisationCentrewiseDepartment> entityResponse = new BaseEntityResponse<OrganisationCentrewiseDepartment>();
            try
            {
                entityResponse = _organisationCentrewiseDepartmentDataProvider.GetOrganisationCentrewiseDepartmentByID(item);
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
