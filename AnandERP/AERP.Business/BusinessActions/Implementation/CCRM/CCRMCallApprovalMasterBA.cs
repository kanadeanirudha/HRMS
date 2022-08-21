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
  public  class CCRMCallApprovalMasterBA :ICCRMCallApprovalMasterBA
    {
        ICCRMCallApprovalMasterDataProvider _CCRMCallApprovalMasterDataProvider;
        ICCRMCallApprovalMasterBR _CCRMCallApprovalMasterBR;
        private ILogger _logException;

        public CCRMCallApprovalMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMCallApprovalMasterBR = new CCRMCallApprovalMasterBR();
            _CCRMCallApprovalMasterDataProvider = new CCRMCallApprovalMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMCallApprovalMaster> UpdateCCRMCallApprovalMaster(CCRMCallApprovalMaster item)
        {
            IBaseEntityResponse<CCRMCallApprovalMaster> entityResponse = new BaseEntityResponse<CCRMCallApprovalMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCallApprovalMasterBR.UpdateCCRMCallApprovalMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCallApprovalMasterDataProvider.UpdateCCRMCallApprovalMaster(item);
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
        public IBaseEntityResponse<CCRMCallApprovalMaster> DeleteCCRMCallApprovalMaster(CCRMCallApprovalMaster item)
        {
            IBaseEntityResponse<CCRMCallApprovalMaster> entityResponse = new BaseEntityResponse<CCRMCallApprovalMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCallApprovalMasterBR.DeleteCCRMCallApprovalMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCallApprovalMasterDataProvider.DeleteCCRMCallApprovalMaster(item);
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
        public IBaseEntityResponse<CCRMCallApprovalMaster> SelectByID(CCRMCallApprovalMaster item)
        {

            IBaseEntityResponse<CCRMCallApprovalMaster> entityResponse = new BaseEntityResponse<CCRMCallApprovalMaster>();
            try
            {
                entityResponse = _CCRMCallApprovalMasterDataProvider.GetCCRMCallApprovalMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMCallApprovalMaster> GetBySearch(CCRMCallApprovalMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCallApprovalMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMCallApprovalMaster>();
            try
            {
                if (_CCRMCallApprovalMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMCallApprovalMasterDataProvider.GetCCRMCallApprovalMasterBySearch(searchRequest);
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
