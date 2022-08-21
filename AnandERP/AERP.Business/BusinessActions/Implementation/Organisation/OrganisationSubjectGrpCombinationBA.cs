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
    public class OrganisationSubjectGrpCombinationBA : IOrganisationSubjectGrpCombinationBA
    {
        IOrganisationSubjectGrpCombinationDataProvider _organisationSubjectGrpCombinationDataProvider;
        IOrganisationSubjectGrpCombinationBR _organisationSubjectGrpCombinationBR;
        private ILogger _logException;
        public OrganisationSubjectGrpCombinationBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSubjectGrpCombinationBR = new OrganisationSubjectGrpCombinationBR();
            _organisationSubjectGrpCombinationDataProvider = new OrganisationSubjectGrpCombinationDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSubjectGrpCombination.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> InsertOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpCombination> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpCombination>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpCombinationBR.InsertOrganisationSubjectGrpCombinationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpCombinationDataProvider.InsertOrganisationSubjectGrpCombination(item);
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
        /// Update a specific record  of OrganisationSubjectGrpCombination.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> UpdateOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpCombination> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpCombination>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpCombinationBR.UpdateOrganisationSubjectGrpCombinationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpCombinationDataProvider.UpdateOrganisationSubjectGrpCombination(item);
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
        /// Delete a selected record from OrganisationSubjectGrpCombination.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> DeleteOrganisationSubjectGrpCombination(OrganisationSubjectGrpCombination item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpCombination> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpCombination>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpCombinationBR.DeleteOrganisationSubjectGrpCombinationValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpCombinationDataProvider.DeleteOrganisationSubjectGrpCombination(item);
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
        /// Select all record from OrganisationSubjectGrpCombination table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpCombination> GetBySearch(OrganisationSubjectGrpCombinationSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpCombination> OrganisationSubjectGrpCombinationCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpCombination>();
            try
            {
                if (_organisationSubjectGrpCombinationDataProvider != null)
                    OrganisationSubjectGrpCombinationCollection = _organisationSubjectGrpCombinationDataProvider.GetOrganisationSubjectGrpCombinationBySearch(searchRequest);
                else
                {
                    OrganisationSubjectGrpCombinationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGrpCombinationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGrpCombinationCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGrpCombinationCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGrpCombinationCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSubjectGrpCombination table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpCombination> SelectByID(OrganisationSubjectGrpCombination item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpCombination> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpCombination>();
            try
            {
                entityResponse = _organisationSubjectGrpCombinationDataProvider.GetOrganisationSubjectGrpCombinationByID(item);
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
