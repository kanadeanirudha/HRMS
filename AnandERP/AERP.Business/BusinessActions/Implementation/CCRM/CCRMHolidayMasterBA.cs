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
   public class CCRMHolidayMasterBA :ICCRMHolidayMasterBA
    {
        ICCRMHolidayMasterDataProvider _CCRMHolidayMasterDataProvider;
        ICCRMHolidayMasterBR _CCRMHolidayMasterBR;
        private ILogger _logException;

        public CCRMHolidayMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMHolidayMasterBR = new CCRMHolidayMasterBR();
            _CCRMHolidayMasterDataProvider = new CCRMHolidayMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMHolidayMaster> InsertCCRMHolidayMaster(CCRMHolidayMaster item)
        {
            IBaseEntityResponse<CCRMHolidayMaster> entityResponse = new BaseEntityResponse<CCRMHolidayMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMHolidayMasterBR.InsertCCRMHolidayMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMHolidayMasterDataProvider.InsertCCRMHolidayMaster(item);
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
        public IBaseEntityCollectionResponse<CCRMHolidayMaster> GetBySearch(CCRMHolidayMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMHolidayMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMHolidayMaster>();
            try
            {
                if (_CCRMHolidayMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMHolidayMasterDataProvider.GetCCRMHolidayMasterBySearch(searchRequest);
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
        public IBaseEntityCollectionResponse<CCRMHolidayMaster> GetCCRMHolidayMasterList(CCRMHolidayMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMHolidayMaster> CCRMHolidayMasterCollection = new BaseEntityCollectionResponse<CCRMHolidayMaster>();
            try
            {
                if (_CCRMHolidayMasterDataProvider != null)
                {
                    CCRMHolidayMasterCollection = _CCRMHolidayMasterDataProvider.GetCCRMHolidayMasterList(searchRequest);
                }
                else
                {
                    CCRMHolidayMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    CCRMHolidayMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                CCRMHolidayMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });

                CCRMHolidayMasterCollection.CollectionResponse = null;

                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return CCRMHolidayMasterCollection;
        }
    }
}
