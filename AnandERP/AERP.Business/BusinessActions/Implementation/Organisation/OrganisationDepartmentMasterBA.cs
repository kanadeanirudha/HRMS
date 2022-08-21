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
    public class OrganisationDepartmentMasterBA : IOrganisationDepartmentMasterBA
    {
        IOrganisationDepartmentMasterDataProvider _orgnisationDepartmentMasterDataProvider;
        IOrganisationDepartmentMasterBR _orgnisationDepartmentMasterBR;
        private ILogger _logException;

        public OrganisationDepartmentMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _orgnisationDepartmentMasterBR = new OrganisationDepartmentMasterBR();
            _orgnisationDepartmentMasterDataProvider = new OrganisationDepartmentMasterDataProvider();
        }

        public IBaseEntityResponse<OrganisationDepartmentMaster> InsertOrganisationDepartmentMaster(OrganisationDepartmentMaster item)
        {
            IBaseEntityResponse<OrganisationDepartmentMaster> entityResponse = new BaseEntityResponse<OrganisationDepartmentMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgnisationDepartmentMasterBR.InsertOrganisationDepartmentMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgnisationDepartmentMasterDataProvider.InsertOrganisationDepartmentMaster(item);
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

        public IBaseEntityResponse<OrganisationDepartmentMaster> UpdateOrganisationDepartmentMaster(OrganisationDepartmentMaster item)
        {
            IBaseEntityResponse<OrganisationDepartmentMaster> entityResponse = new BaseEntityResponse<OrganisationDepartmentMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgnisationDepartmentMasterBR.UpdateOrganisationDepartmentMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgnisationDepartmentMasterDataProvider.UpdateOrganisationDepartmentMaster(item);
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

        public IBaseEntityResponse<OrganisationDepartmentMaster> DeleteOrganisationDepartmentMaster(OrganisationDepartmentMaster item)
        {
            IBaseEntityResponse<OrganisationDepartmentMaster> entityResponse = new BaseEntityResponse<OrganisationDepartmentMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _orgnisationDepartmentMasterBR.DeleteOrganisationDepartmentMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _orgnisationDepartmentMasterDataProvider.DeleteOrganisationDepartmentMaster(item);
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

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetBySearch(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetOrganisationDepartmentMasterBySearch(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }


        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetBySearchList(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetOrganisationDepartmentMasterGetBySearchList(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }


        public IBaseEntityResponse<OrganisationDepartmentMaster> SelectByID(OrganisationDepartmentMaster item)
        {

            IBaseEntityResponse<OrganisationDepartmentMaster> entityResponse = new BaseEntityResponse<OrganisationDepartmentMaster>();
            try
            {
                entityResponse = _orgnisationDepartmentMasterDataProvider.GetOrganisationDepartmentMasterByID(item);
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

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByCentreCode(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetOrganisationDepartmentMasterByCentreCode(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByCentrewise(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetOrganisationDepartmentMasterByCentrewise(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetDepartmentListRoleWise(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartmentListCentreAndRoleWise(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetDepartmentListCentreAndRoleWise(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }

        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetByDepartmentNameSearchList_ForPurchase(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetOrganisationDepartmentMasterGetBySearchList_ForPurchase(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }
        //Department
        public IBaseEntityCollectionResponse<OrganisationDepartmentMaster> GetDepartment(OrganisationDepartmentMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<OrganisationDepartmentMaster> OrganisationDepartmentMasterCollection = new BaseEntityCollectionResponse<OrganisationDepartmentMaster>();
            try
            {
                if (_orgnisationDepartmentMasterDataProvider != null)
                {
                    OrganisationDepartmentMasterCollection = _orgnisationDepartmentMasterDataProvider.GetDepartment(searchRequest);
                }
                else
                {
                    OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    OrganisationDepartmentMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                OrganisationDepartmentMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                OrganisationDepartmentMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return OrganisationDepartmentMasterCollection;
        }
    }
}
