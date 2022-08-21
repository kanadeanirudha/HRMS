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
   public  class OrganisationStandardMasterBA :IOrganisationStandardMasterBA
    {
         IOrganisationStandardMasterDataProvider _orgStandardMasterDataProvider;
        IOrganisationStandardMasterBR _orgStandardMasterBR;
        private ILogger _logException;

        public OrganisationStandardMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _orgStandardMasterBR = new OrganisationStandardMasterBR();
            _orgStandardMasterDataProvider = new OrganisationStandardMasterDataProvider();
        }

        public IBaseEntityResponse<OrganisationStandardMaster> InsertOrganisationStandardMaster(OrganisationStandardMaster item)
        {
            IBaseEntityResponse<OrganisationStandardMaster> entityResponse = new BaseEntityResponse<OrganisationStandardMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgStandardMasterBR.InsertOrganisationStandardMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgStandardMasterDataProvider.InsertOrganisationStandardMaster(item);
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

        public IBaseEntityResponse<OrganisationStandardMaster> UpdateOrganisationStandardMaster(OrganisationStandardMaster item)
        {
            IBaseEntityResponse<OrganisationStandardMaster> entityResponse = new BaseEntityResponse<OrganisationStandardMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgStandardMasterBR.UpdateOrganisationStandardMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgStandardMasterDataProvider.UpdateOrganisationStandardMaster(item);
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

        public IBaseEntityResponse<OrganisationStandardMaster> DeleteOrganisationStandardMaster(OrganisationStandardMaster item)
        {
            IBaseEntityResponse<OrganisationStandardMaster> entityResponse = new BaseEntityResponse<OrganisationStandardMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgStandardMasterBR.DeleteOrganisationStandardMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgStandardMasterDataProvider.DeleteOrganisationStandardMaster(item);
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

        public IBaseEntityCollectionResponse<OrganisationStandardMaster> GetBySearch(OrganisationStandardMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStandardMaster> OrganisationStandardMasterCollection = new BaseEntityCollectionResponse<OrganisationStandardMaster>();
            try
            {
                if (_orgStandardMasterDataProvider != null)
                {
                    OrganisationStandardMasterCollection = _orgStandardMasterDataProvider.GetOrganisationStandardMasterBySearch(searchRequest);
                }
                else
                {
                    OrganisationStandardMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationStandardMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationStandardMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationStandardMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationStandardMasterCollection;
        }



        public IBaseEntityResponse<OrganisationStandardMaster> SelectByID(OrganisationStandardMaster item)
        {

            IBaseEntityResponse<OrganisationStandardMaster> entityResponse = new BaseEntityResponse<OrganisationStandardMaster>();
            try
            {
                entityResponse = _orgStandardMasterDataProvider.GetOrganisationStandardMasterByID(item);
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
        /// Select all record from OrganisationStandardMaster table with search parameters.
        /// </summary>
        /// <param name="searchRequest"></param>
        /// <returns></returns>

        public IBaseEntityCollectionResponse<OrganisationStandardMaster> GetBySearchList(OrganisationStandardMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationStandardMaster> standardMasterCollection = new BaseEntityCollectionResponse<OrganisationStandardMaster>();
            try
            {
                if (_orgStandardMasterDataProvider != null)
                {
                    standardMasterCollection = _orgStandardMasterDataProvider.GetOrganisationStandardMasterGetBySearchList(searchRequest);
                }
                else
                {
                    standardMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    standardMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                standardMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                standardMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return standardMasterCollection;
        }


    }
}
