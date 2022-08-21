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
    public class CCRMActionMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMActionMaster_Web_API_BA _ICCRMActionMaster_Web_API_BA = null;
        public CCRMActionMasterWebAPIController()
        {
            _ICCRMActionMaster_Web_API_BA = new CCRMActionMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetActions(CCRMActionMasterViewModel model)
        {
            CCRMActionMasterViewModel _CCRMActionMasterViewModel = new CCRMActionMasterViewModel();
            if (model != null)
            {
                _CCRMActionMasterViewModel.CCRMActionMasterDTO = new CCRMActionMaster();

                _CCRMActionMasterViewModel.CCRMActionMasterDTO.LastSyncDate = model.LastSyncDate;
                _CCRMActionMasterViewModel.CCRMActionMasterDTO.SyncType = model.SyncType;
                _CCRMActionMasterViewModel.CCRMActionMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMActionMasterViewModel.CCRMActionMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMActionMaster> response = _ICCRMActionMaster_Web_API_BA.getActionOnSearchApi(_CCRMActionMasterViewModel.CCRMActionMasterDTO);
                List<CCRMActionMaster> listCCRMActionMaster = new List<CCRMActionMaster>();
                List<object> ActionRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMActionMaster = response.CollectionResponse.ToList();
                        foreach (CCRMActionMaster item in listCCRMActionMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ActionID", item.ID);
                            Data.Add("ActionTitle", item.ActionTitle);
                            Data.Add("ActionCode", item.ActionCode);
                            Data.Add("ActionDesciption", item.ActionDesciption);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            ActionRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? ActionRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", ActionRecord }
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
