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
  public  class CCRMMIFMasterAndDetailsBA :ICCRMMIFMasterAndDetailsBA
    {
        ICCRMMIFMasterAndDetailsDataProvider _CCRMMIFMasterAndDetailsDataProvider;
        ICCRMMIFMasterAndDetailsBR _CCRMMIFMasterAndDetailsBR;
        IEmpEmployeeMasterDataProvider _EmpEmployeeMasterDataProvider;
        private ILogger _logException;
        public CCRMMIFMasterAndDetailsBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _CCRMMIFMasterAndDetailsBR = new CCRMMIFMasterAndDetailsBR();
            _CCRMMIFMasterAndDetailsDataProvider = new CCRMMIFMasterAndDetailsDataProvider();
            _EmpEmployeeMasterDataProvider = new EmpEmployeeMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> InsertCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> entityResponse = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMIFMasterAndDetailsBR.InsertCCRMMIFMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMIFMasterAndDetailsDataProvider.InsertCCRMMIFMasterAndDetails(item);
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> UpdateCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> entityResponse = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMIFMasterAndDetailsBR.UpdateCCRMMIFMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMIFMasterAndDetailsDataProvider.UpdateCCRMMIFMasterAndDetails(item);
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
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> DeleteCCRMMIFMasterAndDetails(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> entityResponse = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMIFMasterAndDetailsBR.DeleteCCRMMIFMasterAndDetailsValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMIFMasterAndDetailsDataProvider.DeleteCCRMMIFMasterAndDetails(item);
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetBySearch(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetailsCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
            try
            {
                if (_CCRMMIFMasterAndDetailsDataProvider != null)
                    CCRMMIFMasterAndDetailsCollection = _CCRMMIFMasterAndDetailsDataProvider.GetCCRMMIFMasterAndDetailsBySearch(searchRequest);
                else
                {
                    CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFMasterAndDetailsCollection;
        }
        public IBaseEntityResponse<CCRMMIFMasterAndDetails> SelectByID(CCRMMIFMasterAndDetails item)
        {
            IBaseEntityResponse<CCRMMIFMasterAndDetails> entityResponse = new BaseEntityResponse<CCRMMIFMasterAndDetails>();
            try
            {
                entityResponse = _CCRMMIFMasterAndDetailsDataProvider.GetCCRMMIFMasterAndDetailsByID(item);
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
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFMasterAndDetailsSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetailsCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
            try
            {
                if (_CCRMMIFMasterAndDetailsDataProvider != null)
                    CCRMMIFMasterAndDetailsCollection = _CCRMMIFMasterAndDetailsDataProvider.GetCCRMMIFMasterAndDetailsSearchList(searchRequest);
                else
                {
                    CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetListOfOperatorByID(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetailsCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
            try
            {
                if (_CCRMMIFMasterAndDetailsDataProvider != null)
                    CCRMMIFMasterAndDetailsCollection = _CCRMMIFMasterAndDetailsDataProvider.GetListOfOperatorByID(searchRequest);
                else
                {
                    CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetailsCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
            try
            {
                if (_CCRMMIFMasterAndDetailsDataProvider != null)
                    CCRMMIFMasterAndDetailsCollection = _CCRMMIFMasterAndDetailsDataProvider.GetCCRMMIFSerialNoSearchList(searchRequest);
                else
                {
                    CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMMIFCallerNameSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetailsCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
            try
            {
                if (_CCRMMIFMasterAndDetailsDataProvider != null)
                {
                    CCRMMIFMasterAndDetailsCollection = _CCRMMIFMasterAndDetailsDataProvider.GetCCRMMIFCallerNameSearchList(searchRequest);
                }
                else
                {
                    CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFMasterAndDetailsCollection;
        }
        public IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> GetCCRMContractMasterSerialNoSearchList(CCRMMIFMasterAndDetailsSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMIFMasterAndDetails> CCRMMIFMasterAndDetailsCollection = new BaseEntityCollectionResponse<CCRMMIFMasterAndDetails>();
            try
            {
                if (_CCRMMIFMasterAndDetailsDataProvider != null)
                    CCRMMIFMasterAndDetailsCollection = _CCRMMIFMasterAndDetailsDataProvider.GetCCRMContractMasterSerialNoSearchList(searchRequest);
                else
                {
                    CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMIFMasterAndDetailsCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMMIFMasterAndDetailsCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMIFMasterAndDetailsCollection;
        }

    }
}
