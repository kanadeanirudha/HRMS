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
   public class CCRMBankMasterBA : ICCRMBankMasterBA
    {
        ICCRMBankMasterDataProvider _CCRMBankMasterDataProvider;
        ICCRMBankMasterBR _CCRMBankMasterBR;
        private ILogger _logException;

        public CCRMBankMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMBankMasterBR = new CCRMBankMasterBR();
            _CCRMBankMasterDataProvider = new CCRMBankMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMBankMaster> InsertCCRMBankMaster(CCRMBankMaster item)
        {
            IBaseEntityResponse<CCRMBankMaster> entityResponse = new BaseEntityResponse<CCRMBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBankMasterBR.InsertCCRMBankMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBankMasterDataProvider.InsertCCRMBankMaster(item);
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
        public IBaseEntityResponse<CCRMBankMaster> UpdateCCRMBankMaster(CCRMBankMaster item)
        {
            IBaseEntityResponse<CCRMBankMaster> entityResponse = new BaseEntityResponse<CCRMBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBankMasterBR.UpdateCCRMBankMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBankMasterDataProvider.UpdateCCRMBankMaster(item);
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
        public IBaseEntityResponse<CCRMBankMaster> DeleteCCRMBankMaster(CCRMBankMaster item)
        {
            IBaseEntityResponse<CCRMBankMaster> entityResponse = new BaseEntityResponse<CCRMBankMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMBankMasterBR.DeleteCCRMBankMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMBankMasterDataProvider.DeleteCCRMBankMaster(item);
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
        public IBaseEntityResponse<CCRMBankMaster> SelectByID(CCRMBankMaster item)
        {

            IBaseEntityResponse<CCRMBankMaster> entityResponse = new BaseEntityResponse<CCRMBankMaster>();
            try
            {
                entityResponse = _CCRMBankMasterDataProvider.GetCCRMBankMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMBankMaster> GetBySearch(CCRMBankMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMBankMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMBankMaster>();
            try
            {
                if (_CCRMBankMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMBankMasterDataProvider.GetCCRMBankMasterBySearch(searchRequest);
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
