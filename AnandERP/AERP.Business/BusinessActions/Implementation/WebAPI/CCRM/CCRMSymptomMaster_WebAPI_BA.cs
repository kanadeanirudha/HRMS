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
    public class CCRMSymptomMaster_WebAPI_BA : ICCRMSymptomMaster_WebAPI_BA
    {
        private ILogger _logException;
        private ICCRMSymptomMaster_Web_API_DataProvider _ICCRMSymptomMaster_Web_API_DataProvider;
        public CCRMSymptomMaster_WebAPI_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ICCRMSymptomMaster_Web_API_DataProvider = new CCRMSymptomMaster_Web_API_DataProvider();
        }
        public IBaseEntityCollectionResponse<CCRMSymptomMaster> getSymptom_SelectAll(CCRMSymptomMaster item)
        {
            IBaseEntityCollectionResponse<CCRMSymptomMaster> SymptomMasterCollection = new BaseEntityCollectionResponse<CCRMSymptomMaster>();
            try
            {
                if (_ICCRMSymptomMaster_Web_API_DataProvider != null)
                    SymptomMasterCollection = _ICCRMSymptomMaster_Web_API_DataProvider.getSymptom_SelectAll(item);
                else
                {
                    SymptomMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SymptomMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SymptomMasterCollection.Message.Add(new MessageDTO
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
            return SymptomMasterCollection;
        }
    }
}
