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

namespace AERP.Web.UI.Controllers
{
    public class TD_StatusMasterController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITD_StatusMaster_Web_API_BA _ITD_StatusMaster_Web_API_BA = null;
        public TD_StatusMasterController()
        {
            _ITD_StatusMaster_Web_API_BA = new TD_StatusMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetStatus(StatusMasterViewModel model)
        {
            StatusMasterViewModel _StatusMasterViewModel = new StatusMasterViewModel();
            if (model != null)
            {
                _StatusMasterViewModel.StatusMasterDTO = new StatusMaster();

                _StatusMasterViewModel.StatusMasterDTO.LastSyncDate = model.LastSyncDate;
                _StatusMasterViewModel.StatusMasterDTO.SyncType = model.SyncType;
                _StatusMasterViewModel.StatusMasterDTO.VersionNumber = model.VersionNumber;
                _StatusMasterViewModel.StatusMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<StatusMaster> response = _ITD_StatusMaster_Web_API_BA.getStatus(_StatusMasterViewModel.StatusMasterDTO);
                List<StatusMaster> listStatusMaster = new List<StatusMaster>();
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
                        listStatusMaster = response.CollectionResponse.ToList();
                        foreach (StatusMaster item in listStatusMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("StatusID", item.ID);
                            Data.Add("StatusCode", item.StatusCode);
                            Data.Add("Status", item.Status);
                            Data.Add("Weightage", item.Weightage);
                            Data.Add("ParentDisplayStatus", item.ParentDisplayStatus);
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
        public object getBrokenReason(StatusMasterViewModel model)
        {
            StatusMasterViewModel _StatusMasterViewModel = new StatusMasterViewModel();
            if (model != null)
            {
                _StatusMasterViewModel.StatusMasterDTO = new StatusMaster();

                _StatusMasterViewModel.StatusMasterDTO.LastSyncDate = model.LastSyncDate;
                _StatusMasterViewModel.StatusMasterDTO.SyncType = model.SyncType;
                _StatusMasterViewModel.StatusMasterDTO.VersionNumber = model.VersionNumber;
                _StatusMasterViewModel.StatusMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<StatusMaster> response = _ITD_StatusMaster_Web_API_BA.getBrokenReason(_StatusMasterViewModel.StatusMasterDTO);
                List<StatusMaster> listStatusMaster = new List<StatusMaster>();
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
                        listStatusMaster = response.CollectionResponse.ToList();
                        foreach (StatusMaster item in listStatusMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("BrokenStatusReasonID", item.BrokenStatusReasonID);
                            Data.Add("BrokenReasonCode", item.BrokenReasonCode);
                            Data.Add("Reason", item.Reason);
                            Data.Add("Flag", item.Flag);
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
