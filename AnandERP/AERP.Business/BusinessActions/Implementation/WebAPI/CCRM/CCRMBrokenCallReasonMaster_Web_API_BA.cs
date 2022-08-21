using AERP.Base.DTO;
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
    public class CCRMBrokenCallReasonMaster_Web_API_BA : ICCRMBrokenCallReasonMaster_Web_API_BA
    {
        private ILogger _logException;
        private ICCRMBrokenCallReasonMaster_Web_API_DataProvider _ICCRMBrokenCallReasonMaster_Web_API_DataProvider;
        public CCRMBrokenCallReasonMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMBrokenCallReasonMaster_Web_API_DataProvider = new CCRMBrokenCallReasonMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> getBrokenCallReasonOnSearchApi(CCRMBrokenCallReasonMaster item)
        {
            IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> BrokenCallReasonMasterCollection = new BaseEntityCollectionResponse<CCRMBrokenCallReasonMaster>();
            try
            {
                if (_ICCRMBrokenCallReasonMaster_Web_API_DataProvider != null)
                    BrokenCallReasonMasterCollection = _ICCRMBrokenCallReasonMaster_Web_API_DataProvider.getBrokenCallReasonOnSearchApi(item);
                else
                {
                    BrokenCallReasonMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    BrokenCallReasonMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                BrokenCallReasonMasterCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                // UserMasterCollection.Entity = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return BrokenCallReasonMasterCollection;
        }
    }
}
