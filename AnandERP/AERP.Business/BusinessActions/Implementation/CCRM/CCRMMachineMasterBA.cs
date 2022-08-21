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
  public  class CCRMMachineMasterBA :ICCRMMachineMasterBA
    {
        ICCRMMachineMasterDataProvider _CCRMMachineMasterDataProvider;
        ICCRMMachineMasterBR _CCRMMachineMasterBR;
        private ILogger _logException;

        public CCRMMachineMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMMachineMasterBR = new CCRMMachineMasterBR();
            _CCRMMachineMasterDataProvider = new CCRMMachineMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMMachineMaster> InsertCCRMMachineMaster(CCRMMachineMaster item)
        {
            IBaseEntityResponse<CCRMMachineMaster> entityResponse = new BaseEntityResponse<CCRMMachineMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMachineMasterBR.InsertCCRMMachineMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMachineMasterDataProvider.InsertCCRMMachineMaster(item);
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
        public IBaseEntityResponse<CCRMMachineMaster> UpdateCCRMMachineMaster(CCRMMachineMaster item)
        {
            IBaseEntityResponse<CCRMMachineMaster> entityResponse = new BaseEntityResponse<CCRMMachineMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMachineMasterBR.UpdateCCRMMachineMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMachineMasterDataProvider.UpdateCCRMMachineMaster(item);
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
        public IBaseEntityResponse<CCRMMachineMaster> SelectByID(CCRMMachineMaster item)
        {

            IBaseEntityResponse<CCRMMachineMaster> entityResponse = new BaseEntityResponse<CCRMMachineMaster>();
            try
            {
                entityResponse = _CCRMMachineMasterDataProvider.GetCCRMMachineMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMMachineMaster> GetBySearch(CCRMMachineMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMachineMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMMachineMaster>();
            try
            {
                if (_CCRMMachineMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMMachineMasterDataProvider.GetCCRMMachineMasterBySearch(searchRequest);
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
