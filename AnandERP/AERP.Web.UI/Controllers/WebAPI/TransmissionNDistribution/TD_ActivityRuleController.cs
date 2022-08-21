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
    public class TD_ActivityRuleController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITD_ActivityRule_Web_API_BA _ITD_ActivityRule_Web_API_BA = null;
        public TD_ActivityRuleController()
        {
            _ITD_ActivityRule_Web_API_BA = new TD_ActivityRule_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetActivityRules(ActivityRuleViewModel model)
        {
            ActivityRuleViewModel _ActivityRuleViewModel = new ActivityRuleViewModel();
            if (model != null)
            {
                _ActivityRuleViewModel.ActivityRuleDTO = new ActivityRule();

                _ActivityRuleViewModel.ActivityRuleDTO.LastSyncDate = model.LastSyncDate;
                _ActivityRuleViewModel.ActivityRuleDTO.SyncType = model.SyncType;
                _ActivityRuleViewModel.ActivityRuleDTO.VersionNumber = model.VersionNumber;
                _ActivityRuleViewModel.ActivityRuleDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<ActivityRule> response = _ITD_ActivityRule_Web_API_BA.getActivityRule(_ActivityRuleViewModel.ActivityRuleDTO);
                List<ActivityRule> listActivityRule = new List<ActivityRule>();
                List<object> ItemsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listActivityRule = response.CollectionResponse.ToList();
                        foreach (ActivityRule item in listActivityRule)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ID", item.ID);
                            Data.Add("ActivityID", item.ActivityID);
                            Data.Add("SubActivityID", item.SubActivityID);
                            Data.Add("IsFixedValue", item.IsFixedValue);
                            Data.Add("IsPresent", item.IsPresent);
                            Data.Add("Value", item.Value);
                            Data.Add("ActivityType", item.ActivityType);
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
