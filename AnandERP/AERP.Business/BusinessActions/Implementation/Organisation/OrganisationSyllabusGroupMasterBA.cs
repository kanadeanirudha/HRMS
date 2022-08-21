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
    public class OrganisationSyllabusGroupMasterBA : IOrganisationSyllabusGroupMasterBA
    {
        IOrganisationSyllabusGroupMasterDataProvider _organisationSyllabusGroupMasterDataProvider;
        IOrganisationSyllabusGroupMasterBR _organisationSyllabusGroupMasterBR;
        private ILogger _logException;
        public OrganisationSyllabusGroupMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationSyllabusGroupMasterBR = new OrganisationSyllabusGroupMasterBR();
            _organisationSyllabusGroupMasterDataProvider = new OrganisationSyllabusGroupMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.InsertOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.InsertOrganisationSyllabusGroupMaster(item);
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
        /// Update a specific record  of OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.UpdateOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.UpdateOrganisationSyllabusGroupMaster(item);
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
        /// Delete a selected record from OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> DeleteOrganisationSyllabusGroupMaster(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.DeleteOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.DeleteOrganisationSyllabusGroupMaster(item);
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
        /// Select all record from OrganisationSyllabusGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> OrganisationSyllabusGroupMasterCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                if (_organisationSyllabusGroupMasterDataProvider != null)
                    OrganisationSyllabusGroupMasterCollection = _organisationSyllabusGroupMasterDataProvider.GetOrganisationSyllabusGroupMasterBySearch(searchRequest);
                else
                {
                    OrganisationSyllabusGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSyllabusGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSyllabusGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSyllabusGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSyllabusGroupMasterCollection;
        }
        /// <summary>
        /// Select a record from OrganisationSyllabusGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectByID(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                entityResponse = _organisationSyllabusGroupMasterDataProvider.GetOrganisationSyllabusGroupMasterByID(item);
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




        //Interface methods for table OrgSyllabusGroupDetails

       
        /// <summary>
        /// Create new record of OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusDetails(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.InsertOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.InsertOrganisationSyllabusDetails(item);
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
        /// Update a specific record  of OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusDetails(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.UpdateOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.UpdateOrganisationSyllabusDetails(item);
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
        /// Select all record from OrganisationSyllabusGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusDetailsBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> OrganisationSyllabusGroupMasterCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                if (_organisationSyllabusGroupMasterDataProvider != null)
                    OrganisationSyllabusGroupMasterCollection = _organisationSyllabusGroupMasterDataProvider.GetOrganisationSyllabusDetailsBySearch(searchRequest);
                else
                {
                    OrganisationSyllabusGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSyllabusGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSyllabusGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSyllabusGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSyllabusGroupMasterCollection;
        }

        /// <summary>
        /// Select a record from OrganisationSyllabusGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectOrganisationSyllabusDetailsByID(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                entityResponse = _organisationSyllabusGroupMasterDataProvider.SelectOrganisationSyllabusDetailsByID(item);
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



        //Interface methods for table OrgSyllabusGroupTopics


        /// <summary>
        /// Create new record of OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> InsertOrganisationSyllabusTopics(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.InsertOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.InsertOrganisationSyllabusTopics(item);
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
        /// Update a specific record  of OrganisationSyllabusGroupMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> UpdateOrganisationSyllabusTopics(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationSyllabusGroupMasterBR.UpdateOrganisationSyllabusGroupMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationSyllabusGroupMasterDataProvider.UpdateOrganisationSyllabusTopics(item);
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
        /// Select all record from OrganisationSyllabusGroupMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> GetOrganisationSyllabusTopicsBySearch(OrganisationSyllabusGroupMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationSyllabusGroupMaster> OrganisationSyllabusGroupMasterCollection = new BaseEntityCollectionResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                if (_organisationSyllabusGroupMasterDataProvider != null)
                    OrganisationSyllabusGroupMasterCollection = _organisationSyllabusGroupMasterDataProvider.GetOrganisationSyllabusTopicsBySearch(searchRequest);
                else
                {
                    OrganisationSyllabusGroupMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationSyllabusGroupMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationSyllabusGroupMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationSyllabusGroupMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationSyllabusGroupMasterCollection;
        }
       
        /// <summary>
        /// Select a record from OrganisationSyllabusGroupMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationSyllabusGroupMaster> SelectOrganisationSyllabusTopicsByID(OrganisationSyllabusGroupMaster item)
        {
            IBaseEntityResponse<OrganisationSyllabusGroupMaster> entityResponse = new BaseEntityResponse<OrganisationSyllabusGroupMaster>();
            try
            {
                entityResponse = _organisationSyllabusGroupMasterDataProvider.SelectOrganisationSyllabusTopicsByID(item);
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
