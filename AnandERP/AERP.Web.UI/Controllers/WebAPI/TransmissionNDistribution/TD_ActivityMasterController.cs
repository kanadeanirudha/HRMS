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

namespace AERP.Web.UI.Controllers.WebAPI.TransmissionNDistribution
{
    public class TD_ActivityMasterController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITD_ActivityMaster_Web_API_BA _ITD_ActivityMaster_Web_API_BA = null;
        public TD_ActivityMasterController()
        {
            _ITD_ActivityMaster_Web_API_BA = new TD_ActivityMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetActivities(ActivityMasterViewModel model)
        {
            ActivityMasterViewModel _ActivityMasterViewModel = new ActivityMasterViewModel();
            if (model != null)
            {
                _ActivityMasterViewModel.ActivityMasterDTO = new ActivityMaster();

                _ActivityMasterViewModel.ActivityMasterDTO.LastSyncDate = model.LastSyncDate;
                _ActivityMasterViewModel.ActivityMasterDTO.SyncType = model.SyncType;
                _ActivityMasterViewModel.ActivityMasterDTO.VersionNumber = model.VersionNumber;
                _ActivityMasterViewModel.ActivityMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<ActivityMaster> response = _ITD_ActivityMaster_Web_API_BA.getActivities(_ActivityMasterViewModel.ActivityMasterDTO);
                List<ActivityMaster> listActivityMaster = new List<ActivityMaster>();
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
                        listActivityMaster = response.CollectionResponse.ToList();
                        foreach (ActivityMaster item in listActivityMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ActivityID", item.ID);
                            Data.Add("Activity", item.Activity);
                            Data.Add("ActivityCode", item.ActivityCode);
                            Data.Add("ActivityDescription", item.ActivityDescription);
                            Data.Add("Category", item.Category);
                            Data.Add("CategoryID", item.CategoryID);
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

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetSubActivities(SubActivityMasterViewModel model)
        {
            SubActivityMasterViewModel _SubActivityMasterViewModel = new SubActivityMasterViewModel();
            if (model != null)
            {
                _SubActivityMasterViewModel.SubActivitymasterDTO = new SubActivitymaster();

                _SubActivityMasterViewModel.SubActivitymasterDTO.LastSyncDate = model.LastSyncDate;
                _SubActivityMasterViewModel.SubActivitymasterDTO.SyncType = model.SyncType;
                _SubActivityMasterViewModel.SubActivitymasterDTO.VersionNumber = model.VersionNumber;
                _SubActivityMasterViewModel.SubActivitymasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<SubActivitymaster> response = _ITD_ActivityMaster_Web_API_BA.getSubActivities(_SubActivityMasterViewModel.SubActivitymasterDTO);
                List<SubActivitymaster> listSubActivitymaster = new List<SubActivitymaster>();
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
                        listSubActivitymaster = response.CollectionResponse.ToList();
                        foreach (SubActivitymaster item in listSubActivitymaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("SubActivityID", item.ID);
                            Data.Add("SubActivity", item.SubActivity);
                            Data.Add("SubActivityCode", item.SubActivityCode);
                            Data.Add("SubActivityDescription", item.SubActivityDescription);
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
