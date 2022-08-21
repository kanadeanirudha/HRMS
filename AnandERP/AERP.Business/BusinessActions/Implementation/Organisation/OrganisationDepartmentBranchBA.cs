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
    public class OrganisationDepartmentBranchBA : IOrganisationDepartmentBranchBA
    {
        IOrganisationDepartmentBranchDataProvider _organisationDepartmentBranchDataProvider;
        IOrganisationDepartmentBranchBR _organisationDepartmentBranchBR;
        private ILogger _logException;
        public OrganisationDepartmentBranchBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationDepartmentBranchBR = new OrganisationDepartmentBranchBR();
            _organisationDepartmentBranchDataProvider = new OrganisationDepartmentBranchDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationDepartmentBranch.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDepartmentBranch> InsertOrganisationDepartmentBranch(OrganisationDepartmentBranch item)
        {
            IBaseEntityResponse<OrganisationDepartmentBranch> entityResponse = new BaseEntityResponse<OrganisationDepartmentBranch>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationDepartmentBranchBR.InsertOrganisationDepartmentBranchValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationDepartmentBranchDataProvider.InsertOrganisationDepartmentBranch(item);
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
        /// Update a specific record  of OrganisationDepartmentBranch.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDepartmentBranch> UpdateOrganisationDepartmentBranch(OrganisationDepartmentBranch item)
        {
            IBaseEntityResponse<OrganisationDepartmentBranch> entityResponse = new BaseEntityResponse<OrganisationDepartmentBranch>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationDepartmentBranchBR.UpdateOrganisationDepartmentBranchValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationDepartmentBranchDataProvider.UpdateOrganisationDepartmentBranch(item);
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
        /// Delete a selected record from OrganisationDepartmentBranch.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDepartmentBranch> DeleteOrganisationDepartmentBranch(OrganisationDepartmentBranch item)
        {
            IBaseEntityResponse<OrganisationDepartmentBranch> entityResponse = new BaseEntityResponse<OrganisationDepartmentBranch>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationDepartmentBranchBR.DeleteOrganisationDepartmentBranchValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationDepartmentBranchDataProvider.DeleteOrganisationDepartmentBranch(item);
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
        /// Select all record from OrganisationDepartmentBranch table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationDepartmentBranch> GetBySearch(OrganisationDepartmentBranchSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentBranch> OrganisationDepartmentBranchCollection = new BaseEntityCollectionResponse<OrganisationDepartmentBranch>();
            try
            {
                if (_organisationDepartmentBranchDataProvider != null)
                    OrganisationDepartmentBranchCollection = _organisationDepartmentBranchDataProvider.GetOrganisationDepartmentBranchBySearch(searchRequest);
                else
                {
                    OrganisationDepartmentBranchCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentBranchCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentBranchCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationDepartmentBranchCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentBranchCollection;
        }
        /// <summary>
        /// Select a record from OrganisationDepartmentBranch table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationDepartmentBranch> SelectByID(OrganisationDepartmentBranch item)
        {
            IBaseEntityResponse<OrganisationDepartmentBranch> entityResponse = new BaseEntityResponse<OrganisationDepartmentBranch>();
            try
            {
                entityResponse = _organisationDepartmentBranchDataProvider.GetOrganisationDepartmentBranchByID(item);
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
