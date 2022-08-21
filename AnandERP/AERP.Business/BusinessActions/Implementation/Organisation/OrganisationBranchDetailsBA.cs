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
    public class OrganisationBranchDetailsBA : IOrganisationBranchDetailsBA
    {
        IOrganisationBranchDetailsDataProvider _organisationBranchDetailsDataProvider;
        IOrganisationBranchDetailsBR _organisationBranchDetailsBR;
        private ILogger _logException;
        public OrganisationBranchDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationBranchDetailsBR = new OrganisationBranchDetailsBR();
            _organisationBranchDetailsDataProvider = new OrganisationBranchDetailsDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationBranchDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchDetails> InsertOrganisationBranchDetails(OrganisationBranchDetails item)
        {
            IBaseEntityResponse<OrganisationBranchDetails> entityResponse = new BaseEntityResponse<OrganisationBranchDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationBranchDetailsBR.InsertOrganisationBranchDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationBranchDetailsDataProvider.InsertOrganisationBranchDetails(item);
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
        /// Update a specific record  of OrganisationBranchDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchDetails> UpdateOrganisationBranchDetails(OrganisationBranchDetails item)
        {
            IBaseEntityResponse<OrganisationBranchDetails> entityResponse = new BaseEntityResponse<OrganisationBranchDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationBranchDetailsBR.UpdateOrganisationBranchDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationBranchDetailsDataProvider.UpdateOrganisationBranchDetails(item);
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
        /// Delete a selected record from OrganisationBranchDetails.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchDetails> DeleteOrganisationBranchDetails(OrganisationBranchDetails item)
        {
            IBaseEntityResponse<OrganisationBranchDetails> entityResponse = new BaseEntityResponse<OrganisationBranchDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationBranchDetailsBR.DeleteOrganisationBranchDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationBranchDetailsDataProvider.DeleteOrganisationBranchDetails(item);
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
        /// Select all record from OrganisationBranchDetails table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationBranchDetails> GetBySearch(OrganisationBranchDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationBranchDetails> OrganisationBranchDetailsCollection = new BaseEntityCollectionResponse<OrganisationBranchDetails>();
            try
            {
                if (_organisationBranchDetailsDataProvider != null)
                    OrganisationBranchDetailsCollection = _organisationBranchDetailsDataProvider.GetOrganisationBranchDetailsBySearch(searchRequest);
                else
                {
                    OrganisationBranchDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationBranchDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationBranchDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationBranchDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationBranchDetailsCollection;
        }
        /// <summary>
        /// Select a record from OrganisationBranchDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchDetails> SelectByID(OrganisationBranchDetails item)
        {
            IBaseEntityResponse<OrganisationBranchDetails> entityResponse = new BaseEntityResponse<OrganisationBranchDetails>();
            try
            {
                entityResponse = _organisationBranchDetailsDataProvider.GetOrganisationBranchDetailsByID(item);
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
        /// Select a record from OrganisationBranchDetails table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationBranchDetails> SelectByID_For_CourseDescription(OrganisationBranchDetails item)
        {
            IBaseEntityResponse<OrganisationBranchDetails> entityResponse = new BaseEntityResponse<OrganisationBranchDetails>();
            try
            {
                entityResponse = _organisationBranchDetailsDataProvider.GetOrganisationBranchDetailsByID_For_CourseDescription(item);
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
