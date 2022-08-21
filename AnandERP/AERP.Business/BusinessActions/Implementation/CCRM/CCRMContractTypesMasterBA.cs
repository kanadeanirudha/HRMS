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
  public  class CCRMContractTypesMasterBA :ICCRMContractTypesMasterBA
    {
        ICCRMContractTypesMasterDataProvider _CCRMContractTypesMasterDataProvider;
        ICCRMContractTypesMasterBR _CCRMContractTypesMasterBR;
        private ILogger _logException;
        public CCRMContractTypesMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMContractTypesMasterBR = new CCRMContractTypesMasterBR();
            _CCRMContractTypesMasterDataProvider = new CCRMContractTypesMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypesMaster(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> entityResponse = new BaseEntityResponse<CCRMContractTypesMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractTypesMasterBR.InsertCCRMContractTypesMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractTypesMasterDataProvider.InsertCCRMContractTypesMaster(item);
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
        public IBaseEntityResponse<CCRMContractTypesMaster> InsertCCRMContractTypeDetails(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> entityResponse = new BaseEntityResponse<CCRMContractTypesMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractTypesMasterBR.InsertCCRMContractTypesMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractTypesMasterDataProvider.InsertCCRMContractTypeDetails(item);
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
        public IBaseEntityResponse<CCRMContractTypesMaster> UpdateCCRMContractTypesMaster(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> entityResponse = new BaseEntityResponse<CCRMContractTypesMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractTypesMasterBR.UpdateCCRMContractTypesMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractTypesMasterDataProvider.UpdateCCRMContractTypesMaster(item);
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
        public IBaseEntityResponse<CCRMContractTypesMaster> DeleteCCRMContractTypesMaster(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> entityResponse = new BaseEntityResponse<CCRMContractTypesMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractTypesMasterBR.DeleteCCRMContractTypesMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractTypesMasterDataProvider.DeleteCCRMContractTypesMaster(item);
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
        public IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetBySearch(CCRMContractTypesMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> CCRMContractTypesMasterCollection = new BaseEntityCollectionResponse<CCRMContractTypesMaster>();
            try
            {
                if (_CCRMContractTypesMasterDataProvider != null)
                    CCRMContractTypesMasterCollection = _CCRMContractTypesMasterDataProvider.GetCCRMContractTypesMasterBySearch(searchRequest);
                else
                {
                    CCRMContractTypesMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMContractTypesMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMContractTypesMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMContractTypesMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMContractTypesMasterCollection;
        }
       
        public IBaseEntityResponse<CCRMContractTypesMaster> SelectByID(CCRMContractTypesMaster item)
        {
            IBaseEntityResponse<CCRMContractTypesMaster> entityResponse = new BaseEntityResponse<CCRMContractTypesMaster>();
            try
            {
                entityResponse = _CCRMContractTypesMasterDataProvider.GetCCRMContractTypesMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetCCRMContractTypesMasterList(CCRMContractTypesMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractTypesMaster> CCRMContractTypesMasterCollection = new BaseEntityCollectionResponse<CCRMContractTypesMaster>();
            try
            {
                if (_CCRMContractTypesMasterDataProvider != null)
                {
                    CCRMContractTypesMasterCollection = _CCRMContractTypesMasterDataProvider.GetCCRMContractTypesMasterList(searchRequest);
                }
                else
                {
                    CCRMContractTypesMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMContractTypesMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMContractTypesMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMContractTypesMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMContractTypesMasterCollection;
        }
        //public IBaseEntityCollectionResponse<CCRMContractTypesMaster> GetGeneralCategoryMasterList(CCRMContractTypesMasterSearchRequest searchRequest)
        //{
        //    IBaseEntityCollectionResponse<CCRMContractTypesMaster> CCRMContractTypesMasterCollection = new BaseEntityCollectionResponse<CCRMContractTypesMaster>();
        //    try
        //    {
        //        if (_generalTitleMasterDataProvider != null)
        //            CCRMContractTypesMasterCollection = _generalTitleMasterDataProvider.GetCCRMContractTypesMasterBySearchList(searchRequest);
        //        else
        //        {
        //            CCRMContractTypesMasterCollection.Message.Add(new MessageDTO
        //            {
        //                ErrorMessage = Resources.Null_Object_Exception,
        //                MessageType = MessageTypeEnum.Error
        //            });
        //            CCRMContractTypesMasterCollection.CollectionResponse = null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CCRMContractTypesMasterCollection.Message.Add(new MessageDTO
        //        {
        //            ErrorMessage = ex.Message,
        //            MessageType = MessageTypeEnum.Error
        //        });
        //        CCRMContractTypesMasterCollection.CollectionResponse = null;
        //        if (_logException != null)
        //        {
        //            _logException.Error(ex.Message);
        //        }
        //    }
        //    return CCRMContractTypesMasterCollection;
        //}

    }
}
