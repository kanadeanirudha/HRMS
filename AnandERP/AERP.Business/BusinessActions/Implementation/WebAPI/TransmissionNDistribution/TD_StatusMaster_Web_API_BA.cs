using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
using AERP.ExceptionManager;
using AERP.DataProvider;
using AERP.Common;

namespace AERP.Business.BusinessAction
{
    public class TD_StatusMaster_Web_API_BA : ITD_StatusMaster_Web_API_BA
    {
        private ILogger _logException;
        private ITD_StatusMaster_Web_API_DataProvider _ITD_StatusMaster_Web_API_DataProvider;
        public TD_StatusMaster_Web_API_BA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ITD_StatusMaster_Web_API_DataProvider = new TD_StatusMaster_Web_API_DatatProvider();
        }

        public IBaseEntityCollectionResponse<StatusMaster> getStatus(StatusMaster item)
        {
            IBaseEntityCollectionResponse<StatusMaster> StatusMasterCollection = new BaseEntityCollectionResponse<StatusMaster>();
            try
            {
                if (_ITD_StatusMaster_Web_API_DataProvider != null)
                    StatusMasterCollection = _ITD_StatusMaster_Web_API_DataProvider.getStatus(item);
                else
                {
                    StatusMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StatusMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StatusMasterCollection.Message.Add(new MessageDTO
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
            return StatusMasterCollection;
        }

        public IBaseEntityCollectionResponse<StatusMaster> getBrokenReason(StatusMaster item)
        {
            IBaseEntityCollectionResponse<StatusMaster> StatusMasterCollection = new BaseEntityCollectionResponse<StatusMaster>();
            try
            {
                if (_ITD_StatusMaster_Web_API_DataProvider != null)
                    StatusMasterCollection = _ITD_StatusMaster_Web_API_DataProvider.getBrokenReason(item);
                else
                {
                    StatusMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    StatusMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                StatusMasterCollection.Message.Add(new MessageDTO
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
            return StatusMasterCollection;
        }

    }
}
