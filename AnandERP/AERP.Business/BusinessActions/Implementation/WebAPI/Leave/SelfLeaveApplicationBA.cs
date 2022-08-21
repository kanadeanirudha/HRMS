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
    public class SelfLeaveApplicationBA : ISelfLeaveApplicationBA
    {
        private ILogger _logException;
        private ISelfLeaveApplicationDataProvider _ISelfLeaveApplicationDataProvider;

        public SelfLeaveApplicationBA()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _ISelfLeaveApplicationDataProvider = new SelfLeaveApplicationDataProvider();
        }

        public IBaseEntityResponse<SelfLeaveApplication> InsertSelfLeave(SelfLeaveApplication item)
        {
            IBaseEntityResponse<SelfLeaveApplication> entityResponse = new BaseEntityResponse<SelfLeaveApplication>();
            try
            {
                entityResponse = _ISelfLeaveApplicationDataProvider.InsertSelfLeave(item);
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

        public IBaseEntityCollectionResponse<SelfLeaveApplication> getSelfLeaves(SelfLeaveApplication item)
        {
            IBaseEntityCollectionResponse<SelfLeaveApplication> SelfLeaveApplicationCollection = new BaseEntityCollectionResponse<SelfLeaveApplication>();
            try
            {
                if (_ISelfLeaveApplicationDataProvider != null)
                    SelfLeaveApplicationCollection = _ISelfLeaveApplicationDataProvider.getSelfLeaves(item);
                else
                {
                    SelfLeaveApplicationCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    SelfLeaveApplicationCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                SelfLeaveApplicationCollection.Message.Add(new MessageDTO
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
            return SelfLeaveApplicationCollection;
        }

        
    }
}

