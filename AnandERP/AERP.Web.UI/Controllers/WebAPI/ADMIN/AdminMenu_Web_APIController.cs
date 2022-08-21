using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.DTO;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AERP.Web.UI
{
    public class AdminMenu_Web_APIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IAdmin_BA_Web_API _IAdmin_BA_Web_API = null;
        public AdminMenu_Web_APIController()
        {
            _IAdmin_BA_Web_API = new Admin_BA_Web_API();
        }

        [HttpPost]
        [AllowAnonymous]
        // [BasicAuthorization]
        public object GetAdmin(AdminMenuViewModel model)
        {
            AdminMenuViewModel _AdminMenuViewModel = new AdminMenuViewModel();
            if (model != null)
            {
                _AdminMenuViewModel.AdminRoleMenuDetailsDTO = new AdminRoleMenuDetails();

                _AdminMenuViewModel.AdminRoleMenuDetailsDTO.LastSyncDate = model.LastSyncDate;
                _AdminMenuViewModel.AdminRoleMenuDetailsDTO.SyncType = model.SyncType;
                _AdminMenuViewModel.AdminRoleMenuDetailsDTO.VersionNumber = model.VersionNumber;
                _AdminMenuViewModel.AdminRoleMenuDetailsDTO.EmployeeID = model.EmployeeID;

                _AdminMenuViewModel.AdminRoleMenuDetailsDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<AdminRoleMenuDetails> response = _IAdmin_BA_Web_API.getAdminMenu(_AdminMenuViewModel.AdminRoleMenuDetailsDTO);
                List<AdminRoleMenuDetails> listAdminRoleMenuDetails = new List<AdminRoleMenuDetails>();
                List<object> ItemsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "",URL ="";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    URL = MessageList[0].Title;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listAdminRoleMenuDetails = response.CollectionResponse.ToList();
                        foreach (AdminRoleMenuDetails item in listAdminRoleMenuDetails)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("LeaveID", item.ID);
                            Data.Add("AdminRoleMasterID", item.AdminRoleMasterID);
                            Data.Add("MenuCode", item.MenuCode);
                            Data.Add("MenuName", item.MenuName);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            ItemsRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? ItemsRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"URL",URL },
                             {"Message", CheckError(statusCode)},
                             {"Data", ItemsRecord }
                        };
                    return _dict;
                }
            }
            return new Dictionary<string, object>
                    {
                        {"StatusCode", 417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
        }
    }
}