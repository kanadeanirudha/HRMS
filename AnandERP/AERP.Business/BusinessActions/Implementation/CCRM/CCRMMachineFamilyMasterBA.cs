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
   public class CCRMMachineFamilyMasterBA :ICCRMMachineFamilyMasterBA
    {
        ICCRMMachineFamilyMasterDataProvider _CCRMMachineFamilyMasterDataProvider;
        ICCRMMachineFamilyMasterBR _CCRMMachineFamilyMasterBR;
        private ILogger _logException;

        public CCRMMachineFamilyMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMMachineFamilyMasterBR = new CCRMMachineFamilyMasterBR();
            _CCRMMachineFamilyMasterDataProvider = new CCRMMachineFamilyMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMMachineFamilyMaster> InsertCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item)
        {
            IBaseEntityResponse<CCRMMachineFamilyMaster> entityResponse = new BaseEntityResponse<CCRMMachineFamilyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMachineFamilyMasterBR.InsertCCRMMachineFamilyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMachineFamilyMasterDataProvider.InsertCCRMMachineFamilyMaster(item);
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
        public IBaseEntityResponse<CCRMMachineFamilyMaster> UpdateCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item)
        {
            IBaseEntityResponse<CCRMMachineFamilyMaster> entityResponse = new BaseEntityResponse<CCRMMachineFamilyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMachineFamilyMasterBR.UpdateCCRMMachineFamilyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMachineFamilyMasterDataProvider.UpdateCCRMMachineFamilyMaster(item);
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
        public IBaseEntityResponse<CCRMMachineFamilyMaster> DeleteCCRMMachineFamilyMaster(CCRMMachineFamilyMaster item)
        {
            IBaseEntityResponse<CCRMMachineFamilyMaster> entityResponse = new BaseEntityResponse<CCRMMachineFamilyMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMMachineFamilyMasterBR.DeleteCCRMMachineFamilyMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMMachineFamilyMasterDataProvider.DeleteCCRMMachineFamilyMaster(item);
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
        public IBaseEntityResponse<CCRMMachineFamilyMaster> SelectByID(CCRMMachineFamilyMaster item)
        {

            IBaseEntityResponse<CCRMMachineFamilyMaster> entityResponse = new BaseEntityResponse<CCRMMachineFamilyMaster>();
            try
            {
                entityResponse = _CCRMMachineFamilyMasterDataProvider.GetCCRMMachineFamilyMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> GetBySearch(CCRMMachineFamilyMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMMachineFamilyMaster>();
            try
            {
                if (_CCRMMachineFamilyMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMMachineFamilyMasterDataProvider.GetCCRMMachineFamilyMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> GetCCRMMachineFamilyMasterList(CCRMMachineFamilyMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMMachineFamilyMaster> CCRMMachineFamilyMasterCollection = new BaseEntityCollectionResponse<CCRMMachineFamilyMaster>();
            try
            {
                if (_CCRMMachineFamilyMasterDataProvider != null)
                {
                    CCRMMachineFamilyMasterCollection = _CCRMMachineFamilyMasterDataProvider.GetCCRMMachineFamilyMasterList(searchRequest);
                }
                else
                {
                    CCRMMachineFamilyMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMMachineFamilyMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMMachineFamilyMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMMachineFamilyMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMMachineFamilyMasterCollection;
        }
    }
}
