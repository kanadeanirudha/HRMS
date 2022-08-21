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
   public class CCRMCalenderMasterBA :ICCRMCalenderMasterBA
    {
        ICCRMCalenderMasterDataProvider _CCRMCalenderMasterDataProvider;
        ICCRMCalenderMasterBR _CCRMCalenderMasterBR;
        private ILogger _logException;

        public CCRMCalenderMasterBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _CCRMCalenderMasterBR = new CCRMCalenderMasterBR();
            _CCRMCalenderMasterDataProvider = new CCRMCalenderMasterDataProvider();
        }
        public IBaseEntityResponse<CCRMCalenderMaster> InsertCCRMCalenderMaster(CCRMCalenderMaster item)
        {
            IBaseEntityResponse<CCRMCalenderMaster> entityResponse = new BaseEntityResponse<CCRMCalenderMaster>();
            try
            {
                IValidateBusinessRuleResponse brResponse = _CCRMCalenderMasterBR.InsertCCRMCalenderMasterValidate(item);
                if (brResponse.Passed)
                {
                    entityResponse = _CCRMCalenderMasterDataProvider.InsertCCRMCalenderMaster(item);
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
        public IBaseEntityCollectionResponse<CCRMCalenderMaster> GetBySearch(CCRMCalenderMasterSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<CCRMCalenderMaster> categoryMasterCollection = new BaseEntityCollectionResponse<CCRMCalenderMaster>();
            try
            {
                if (_CCRMCalenderMasterDataProvider != null)
                {
                    categoryMasterCollection = _CCRMCalenderMasterDataProvider.GetCCRMCalenderMasterBySearch(searchRequest);
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
