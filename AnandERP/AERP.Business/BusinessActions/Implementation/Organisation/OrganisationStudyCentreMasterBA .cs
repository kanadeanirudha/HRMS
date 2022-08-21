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
    public class OrganisationStudyCentreMasterBA : IOrganisationStudyCentreMasterBA
    {
        IOrganisationStudyCentreMasterDataProvider _organisationStudyCentreMasterDataProvider;
        IOrganisationStudyCentreMasterBR _organisationStudyCentreMasterBR;
        private ILogger _logException;
        public OrganisationStudyCentreMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _organisationStudyCentreMasterBR = new OrganisationStudyCentreMasterBR();
            _organisationStudyCentreMasterDataProvider = new OrganisationStudyCentreMasterDataProvider();
        }
        /// <summary>
        /// Create new record of OrganisationStudyCentreMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentreMaster> InsertOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> entityResponse = new BaseEntityResponse<OrganisationStudyCentreMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationStudyCentreMasterBR.InsertOrganisationStudyCentreMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationStudyCentreMasterDataProvider.InsertOrganisationStudyCentreMaster(item);
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
        /// Update a specific record  of OrganisationStudyCentreMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentreMaster> UpdateOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> entityResponse = new BaseEntityResponse<OrganisationStudyCentreMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationStudyCentreMasterBR.UpdateOrganisationStudyCentreMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationStudyCentreMasterDataProvider.UpdateOrganisationStudyCentreMaster(item);
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
        /// Delete a selected record from OrganisationStudyCentreMaster.
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentreMaster> DeleteOrganisationStudyCentreMaster(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> entityResponse = new BaseEntityResponse<OrganisationStudyCentreMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _organisationStudyCentreMasterBR.DeleteOrganisationStudyCentreMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _organisationStudyCentreMasterDataProvider.DeleteOrganisationStudyCentreMaster(item);
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
        /// Select all record from OrganisationStudyCentreMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetBySearch(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> OrganisationStudyCentreMasterCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
            try
            {
                if (_organisationStudyCentreMasterDataProvider != null)
                    OrganisationStudyCentreMasterCollection = _organisationStudyCentreMasterDataProvider.GetOrganisationStudyCentreMasterBySearch(searchRequest);
                else
                {
                    OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStudyCentreMasterCollection;
        }
        /// <summary>
        /// Select all record from OrganisationStudyCentreMaster table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetListHORO(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> OrganisationStudyCentreMasterCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
            try
            {
                if (_organisationStudyCentreMasterDataProvider != null)
                    OrganisationStudyCentreMasterCollection = _organisationStudyCentreMasterDataProvider.GetOrganisationStudyCentreMasterGetListHORO(searchRequest);
                else
                {
                    OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStudyCentreMasterCollection;
        }
        /// <summary>
        /// Select all record from OrganisationStudyCentreList table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetOrganisationStudyCentreList(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> OrganisationStudyCentreMasterCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
            try
            {
                if (_organisationStudyCentreMasterDataProvider != null)
                    OrganisationStudyCentreMasterCollection = _organisationStudyCentreMasterDataProvider.GetOrganisationStudyCentreListBySearch(searchRequest);
                else
                {
                    OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStudyCentreMasterCollection;
        }
        
         /// <summary>
        /// Select all record from OrganisationStudyCentreList table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreListRoleWise(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> OrganisationStudyCentreMasterCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
            try
            {
                if (_organisationStudyCentreMasterDataProvider != null)
                {
                    OrganisationStudyCentreMasterCollection = _organisationStudyCentreMasterDataProvider.GetStudyCentreListRoleWise(searchRequest);
                }
                else
                {
                    OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStudyCentreMasterCollection;
        }

         /// <summary>
        /// Select all record from OrganisationStudyCentreList table with search parameters.
        /// <summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>
        public IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> GetStudyCentreDetailsForReports(OrganisationStudyCentreMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStudyCentreMaster> OrganisationStudyCentreMasterCollection = new BaseEntityCollectionResponse<OrganisationStudyCentreMaster>();
            try
            {
                if (_organisationStudyCentreMasterDataProvider != null)
                {
                    OrganisationStudyCentreMasterCollection = _organisationStudyCentreMasterDataProvider.GetStudyCentreDetailsForReports(searchRequest);
                }
                else
                {
                    OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStudyCentreMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                OrganisationStudyCentreMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStudyCentreMasterCollection;
        }        
        /// <summary>
        /// Select a record from OrganisationStudyCentreMaster table by ID
        /// <summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public IBaseEntityResponse<OrganisationStudyCentreMaster> SelectByID(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> entityResponse = new BaseEntityResponse<OrganisationStudyCentreMaster>();
            try
            {
                entityResponse = _organisationStudyCentreMasterDataProvider.GetOrganisationStudyCentreMasterByID(item);
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


        public IBaseEntityResponse<OrganisationStudyCentreMaster> SelectHOROCount(OrganisationStudyCentreMaster item)
        {
            IBaseEntityResponse<OrganisationStudyCentreMaster> entityResponse = new BaseEntityResponse<OrganisationStudyCentreMaster>();
            try
            {
                entityResponse = _organisationStudyCentreMasterDataProvider.GetOrganisationStudyCentreMasterHOROCount(item);
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
