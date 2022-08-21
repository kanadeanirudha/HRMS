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


namespace AMS.Business.BusinessActions
{
    public class OrganisationStreamMasterBA : IOrganisationStreamMasterBA
    {
        IOrganisationStreamMasterDataProvider _orgStreamMasterDataProvider;
        IOrganisationStreamMasterBR _orgStreamMasterBR;
        private ILogger _logException;

        public OrganisationStreamMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _orgStreamMasterBR = new OrganisationStreamMasterBR();
            _orgStreamMasterDataProvider = new OrganisationStreamMasterDataProvider();
        }

        public IBaseEntityResponse<OrganisationStreamMaster> InsertOrganisationStreamMaster(OrganisationStreamMaster item)
        {
            IBaseEntityResponse<OrganisationStreamMaster> entityResponse = new BaseEntityResponse<OrganisationStreamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgStreamMasterBR.InsertOrganisationStreamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgStreamMasterDataProvider.InsertOrganisationStreamMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityResponse<OrganisationStreamMaster> UpdateOrganisationStreamMaster(OrganisationStreamMaster item)
        {
            IBaseEntityResponse<OrganisationStreamMaster> entityResponse = new BaseEntityResponse<OrganisationStreamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgStreamMasterBR.UpdateOrganisationStreamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgStreamMasterDataProvider.UpdateOrganisationStreamMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityResponse<OrganisationStreamMaster> DeleteOrganisationStreamMaster(OrganisationStreamMaster item)
        {
            IBaseEntityResponse<OrganisationStreamMaster> entityResponse = new BaseEntityResponse<OrganisationStreamMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgStreamMasterBR.DeleteOrganisationStreamMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgStreamMasterDataProvider.DeleteOrganisationStreamMaster(item);
                }
                else
                {
                    entityResponse.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    entityResponse.Entity = null;
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

        public IBaseEntityCollectionResponse<OrganisationStreamMaster> GetBySearch(OrganisationStreamMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStreamMaster> OrganisationStreamMasterCollection = new BaseEntityCollectionResponse<OrganisationStreamMaster>();
            try
            {
                if (_orgStreamMasterDataProvider != null)
                {
                    OrganisationStreamMasterCollection = _orgStreamMasterDataProvider.GetOrganisationStreamMasterBySearch(searchRequest);
                }
                else
                {
                    OrganisationStreamMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStreamMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStreamMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationStreamMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStreamMasterCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationStreamMaster> GetBySearchList(OrganisationStreamMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStreamMaster> OrganisationStreamMasterCollection = new BaseEntityCollectionResponse<OrganisationStreamMaster>();
            try
            {
                if (_orgStreamMasterDataProvider != null)
                {
                    OrganisationStreamMasterCollection = _orgStreamMasterDataProvider.GetOrganisationStreamMasterBySearchList(searchRequest);
                }
                else
                {
                    OrganisationStreamMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStreamMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStreamMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationStreamMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStreamMasterCollection;
        }

        public IBaseEntityResponse<OrganisationStreamMaster> SelectByID(OrganisationStreamMaster item)
        {

            IBaseEntityResponse<OrganisationStreamMaster> entityResponse = new BaseEntityResponse<OrganisationStreamMaster>();
            try
            {
                entityResponse = _orgStreamMasterDataProvider.GetOrganisationStreamMasterByID(item);
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