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
    public class CCRMServiceReportMasterBA : ICCRMServiceReportMasterBA
    {
        ICCRMServiceReportMasterDataProvider _CCRMServiceReportMasterDataProvider;
        ICCRMServiceReportMasterBR _CCRMServiceReportMasterBR;
        private ILogger _logException;

        public CCRMServiceReportMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMServiceReportMasterBR = new CCRMServiceReportMasterBR();
            _CCRMServiceReportMasterDataProvider = new CCRMServiceReportMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMServiceReportMaster> UpdateCCRMServiceReportMaster(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityResponse<CCRMServiceReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceReportMasterBR.UpdateCCRMServiceReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceReportMasterDataProvider.UpdateCCRMServiceReportMaster(item);
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
        public IBaseEntityResponse<CCRMServiceReportMaster> DeleteCCRMServiceReportMaster(CCRMServiceReportMaster item)
        {
            IBaseEntityResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityResponse<CCRMServiceReportMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMServiceReportMasterBR.DeleteCCRMServiceReportMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMServiceReportMasterDataProvider.DeleteCCRMServiceReportMaster(item);
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
        public IBaseEntityResponse<CCRMServiceReportMaster> SelectByID(CCRMServiceReportMaster item)
        {

            IBaseEntityResponse<CCRMServiceReportMaster> entityResponse = new BaseEntityResponse<CCRMServiceReportMaster>();
            try
            {
                entityResponse = _CCRMServiceReportMasterDataProvider.GetCCRMServiceReportMasterByID(item);
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
        public IBaseEntityCollectionResponse<CCRMServiceReportMaster> GetBySearch(CCRMServiceReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMServiceReportMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMServiceReportMaster>();
            try
            {
                if (_CCRMServiceReportMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMServiceReportMasterDataProvider.GetCCRMServiceReportMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMServiceReportMaster> GetListOfItemsByID(CCRMServiceReportMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMServiceReportMaster> CCRMServiceReportMasterCollection = new BaseEntityCollectionResponse<CCRMServiceReportMaster>();
            try
            {
                if (_CCRMServiceReportMasterDataProvider != null)
                    CCRMServiceReportMasterCollection = _CCRMServiceReportMasterDataProvider.GetListOfItemsByID(searchRequest);
                else
                {
                    CCRMServiceReportMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMServiceReportMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMServiceReportMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                CCRMServiceReportMasterCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMServiceReportMasterCollection;
        }
    }
}
