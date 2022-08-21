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
    public class Admin_BA_Web_API : IAdmin_BA_Web_API
    {
        private ILogger _logException;
        private IAdmin_DataProvider_Web_API _IAdmin_DataProvider_Web_API;
        public Admin_BA_Web_API()
        {
            _logException = new ExceptionManager.ExceptionManager();
            _IAdmin_DataProvider_Web_API = new Admin_DataProvider_Web_API();
        }
        public IBaseEntityCollectionResponse<AdminRoleMenuDetails> getAdminMenu(AdminRoleMenuDetails item)
        {
            IBaseEntityCollectionResponse<AdminRoleMenuDetails> LeaveMasterCollection = new BaseEntityCollectionResponse<AdminRoleMenuDetails>();
            try
            {
                if (_IAdmin_DataProvider_Web_API != null)
                    LeaveMasterCollection = _IAdmin_DataProvider_Web_API.getAdminMenu(item);
                else
                {
                    LeaveMasterCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveMasterCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveMasterCollection.Message.Add(new MessageDTO
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
            return LeaveMasterCollection;
        }

    }
}
