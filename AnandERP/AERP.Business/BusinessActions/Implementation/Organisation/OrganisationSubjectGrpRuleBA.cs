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
    public class OrganisationSubjectGrpRuleBA : IOrganisationSubjectGrpRuleBA
    {
        IOrganisationSubjectGrpRuleDataProvider _organisationSubjectGrpRuleDataProvider;
        IOrganisationSubjectGrpRuleBR _organisationSubjectGrpRuleBR;
        private ILogger _logException;
        public OrganisationSubjectGrpRuleBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSubjectGrpRuleBR = new OrganisationSubjectGrpRuleBR();
            _organisationSubjectGrpRuleDataProvider = new OrganisationSubjectGrpRuleDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.InsertOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.InsertOrganisationSubjectGrpRule(item);
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
        /// Update a specific record  of OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.UpdateOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.UpdateOrganisationSubjectGrpRule(item);
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
        /// Delete a selected record from OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> DeleteOrganisationSubjectGrpRule(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.DeleteOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.DeleteOrganisationSubjectGrpRule(item);
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
        /// Select all record from OrganisationSubjectGrpRule table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
            try
            {
                if (_organisationSubjectGrpRuleDataProvider != null)
                    OrganisationSubjectGrpRuleCollection = _organisationSubjectGrpRuleDataProvider.GetOrganisationSubjectGrpRuleBySearch(searchRequest);
                else
                {
                    OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGrpRuleCollection;
        }
        
        /// <summary>
        /// Select all record from OrganisationSubjectGrpRule table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetForOrgSubGrpRuleSessionwise(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
            try
            {
                if (_organisationSubjectGrpRuleDataProvider != null)
                    OrganisationSubjectGrpRuleCollection = _organisationSubjectGrpRuleDataProvider.GetForOrgSubGrpRuleSessionwise(searchRequest);
                else
                {
                    OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGrpRuleCollection;
        }          
        /// <summary>
        /// Select a record from OrganisationSubjectGrpRule table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectByID(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                entityResponse = _organisationSubjectGrpRuleDataProvider.GetOrganisationSubjectGrpRuleByID(item);
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





        // Methods for table OrgElectiveGrpRule

        /// <summary>
        /// Create new record of OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.InsertOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.InsertOrgElectiveGrpMaster(item);
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
        /// Update a specific record  of OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.UpdateOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.UpdateOrgElectiveGrpMaster(item);
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
        /// Select all record from OrganisationSubjectGrpRule table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
            try
            {
                if (_organisationSubjectGrpRuleDataProvider != null)
                    OrganisationSubjectGrpRuleCollection = _organisationSubjectGrpRuleDataProvider.GetOrgElectiveGrpMasterBySearch(searchRequest);
                else
                {
                    OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGrpRuleCollection;
        }

        /// <summary>
        /// Select a record from OrganisationSubjectGrpRule table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgElectiveGrpMasterByID(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                entityResponse = _organisationSubjectGrpRuleDataProvider.SelectOrgElectiveGrpMasterByID(item);
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



        // Methods for table OrgSubElectiveGrpRule

        /// <summary>
        /// Create new record of OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> InsertOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.InsertOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.InsertOrgSubElectiveGrpMaster(item);
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
        /// Update a specific record  of OrganisationSubjectGrpRule.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> UpdateOrgSubElectiveGrpMaster(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSubjectGrpRuleBR.UpdateOrganisationSubjectGrpRuleValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSubjectGrpRuleDataProvider.UpdateOrgSubElectiveGrpMaster(item);
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
        /// Select all record from OrganisationSubjectGrpRule table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubElectiveGrpMasterBySearch(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
            try
            {
                if (_organisationSubjectGrpRuleDataProvider != null)
                    OrganisationSubjectGrpRuleCollection = _organisationSubjectGrpRuleDataProvider.GetOrgSubElectiveGrpMasterBySearch(searchRequest);
                else
                {
                    OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGrpRuleCollection;
        }

        /// <summary>
        /// Select all record from OrganisationSubjectGrpRule table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> GetOrgSubjectGroupRuleSearchList(OrganisationSubjectGrpRuleSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSubjectGrpRule> OrganisationSubjectGrpRuleCollection = new BaseEntityCollectionResponse<OrganisationSubjectGrpRule>();
            try
            {
                if (_organisationSubjectGrpRuleDataProvider != null)
                    OrganisationSubjectGrpRuleCollection = _organisationSubjectGrpRuleDataProvider.GetOrgSubjectGroupRuleSearchList(searchRequest);
                else
                {
                    OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSubjectGrpRuleCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSubjectGrpRuleCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSubjectGrpRuleCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSubjectGrpRule table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSubjectGrpRule> SelectOrgSubElectiveGrpMasterByID(OrganisationSubjectGrpRule item)
        {
            IBaseEntityResponse<OrganisationSubjectGrpRule> entityResponse = new BaseEntityResponse<OrganisationSubjectGrpRule>();
            try
            {
                entityResponse = _organisationSubjectGrpRuleDataProvider.SelectOrgSubElectiveGrpMasterByID(item);
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
