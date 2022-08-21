using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.Business.BusinessRules;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;

namespace AERP.Business.BusinessAction
{
   public class CCRMContractMasterBA :ICCRMContractMasterBA
    {
        ICCRMContractMasterDataProvider _CCRMContractMasterDataProvider;
        ICCRMContractMasterBR _CCRMContractMasterBR;
        private ILogger _logException;

        public CCRMContractMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMContractMasterBR = new CCRMContractMasterBR();
            _CCRMContractMasterDataProvider = new CCRMContractMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMContractMaster> InsertCCRMContractMaster(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> entityResponse = new BaseEntityResponse<CCRMContractMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractMasterBR.InsertCCRMContractMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractMasterDataProvider.InsertCCRMContractMaster(item);
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
        public IBaseEntityResponse<CCRMContractMaster> UpdateCCRMContractMaster(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> entityResponse = new BaseEntityResponse<CCRMContractMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractMasterBR.UpdateCCRMContractMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractMasterDataProvider.UpdateCCRMContractMaster(item);
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
        public IBaseEntityResponse<CCRMContractMaster> DeleteCCRMContractMaster(CCRMContractMaster item)
        {
            IBaseEntityResponse<CCRMContractMaster> entityResponse = new BaseEntityResponse<CCRMContractMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMContractMasterBR.DeleteCCRMContractMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMContractMasterDataProvider.DeleteCCRMContractMaster(item);
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
        public IBaseEntityResponse<CCRMContractMaster> SelectByID(CCRMContractMaster item)
        {

            IBaseEntityResponse<CCRMContractMaster> entityResponse = new BaseEntityResponse<CCRMContractMaster>();
            try
            {
                entityResponse = _CCRMContractMasterDataProvider.GetCCRMContractMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMContractMaster> GetBySearch(CCRMContractMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMContractMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMContractMaster>();
            try
            {
                if (_CCRMContractMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMContractMasterDataProvider.GetCCRMContractMasterBySearch(searchRequest);
                }
                else
                {
                    categoryMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    categoryMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                categoryMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                categoryMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return categoryMasterCollection;
        }
    }
}
