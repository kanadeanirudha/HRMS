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
   public class OrganisationDivisionMasterBA : IOrganisationDivisionMasterBA
    {
        IOrganisationDivisionMasterDataProvider _orgDivisionMasterDataProvider;
        IOrganisationDivisionMasterBR _orgDivisionMasterBR;
        private ILogger _logException;

        public OrganisationDivisionMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _orgDivisionMasterBR = new OrganisationDivisionMasterBR();
            _orgDivisionMasterDataProvider = new OrganisationDivisionMasterDataProvider();
        }

        public IBaseEntityResponse<OrganisationDivisionMaster> InsertOrganisationDivisionMaster(OrganisationDivisionMaster item)
        {
            IBaseEntityResponse<OrganisationDivisionMaster> entityResponse = new BaseEntityResponse<OrganisationDivisionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgDivisionMasterBR.InsertOrganisationDivisionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgDivisionMasterDataProvider.InsertOrganisationDivisionMaster(item);
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

        public IBaseEntityResponse<OrganisationDivisionMaster> UpdateOrganisationDivisionMaster(OrganisationDivisionMaster item)
        {
            IBaseEntityResponse<OrganisationDivisionMaster> entityResponse = new BaseEntityResponse<OrganisationDivisionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgDivisionMasterBR.UpdateOrganisationDivisionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgDivisionMasterDataProvider.UpdateOrganisationDivisionMaster(item);
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

        public IBaseEntityResponse<OrganisationDivisionMaster> DeleteOrganisationDivisionMaster(OrganisationDivisionMaster item)
        {
            IBaseEntityResponse<OrganisationDivisionMaster> entityResponse = new BaseEntityResponse<OrganisationDivisionMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgDivisionMasterBR.DeleteOrganisationDivisionMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgDivisionMasterDataProvider.DeleteOrganisationDivisionMaster(item);
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

        public IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetBySearch(OrganisationDivisionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDivisionMaster> OrganisationDivisionMasterCollection = new BaseEntityCollectionResponse<OrganisationDivisionMaster>();
            try
            {
                if (_orgDivisionMasterDataProvider != null)
                {
                    OrganisationDivisionMasterCollection = _orgDivisionMasterDataProvider.GetOrganisationDivisionMasterBySearch(searchRequest);
                }
                else
                {
                    OrganisationDivisionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDivisionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDivisionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDivisionMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDivisionMasterCollection;
        }


        public IBaseEntityCollectionResponse<OrganisationDivisionMaster> GetBySearchList(OrganisationDivisionMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDivisionMaster> OrganisationDivisionMasterCollection = new BaseEntityCollectionResponse<OrganisationDivisionMaster>();
            try
            {
                if (_orgDivisionMasterDataProvider != null)
                {
                    OrganisationDivisionMasterCollection = _orgDivisionMasterDataProvider.GetOrganisationDivisionMasterGetBySearchList(searchRequest);
                }
                else
                {
                    OrganisationDivisionMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDivisionMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDivisionMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDivisionMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDivisionMasterCollection;
        }



        public IBaseEntityResponse<OrganisationDivisionMaster> SelectByID(OrganisationDivisionMaster item)
        {

            IBaseEntityResponse<OrganisationDivisionMaster> entityResponse = new BaseEntityResponse<OrganisationDivisionMaster>();
            try
            {
                entityResponse = _orgDivisionMasterDataProvider.GetOrganisationDivisionMasterByID(item);
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
