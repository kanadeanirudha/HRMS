using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.DTO;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AERP.Web.UI
{
    public class CCRMComplaintLoggingMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMComplaintLoggingMaster_WebAPI_BA _ICCRMComplaintLoggingMaster_WebAPI_BA = null;
        public CCRMComplaintLoggingMasterWebAPIController()
        {
            _ICCRMComplaintLoggingMaster_WebAPI_BA = new CCRMComplaintLoggingMaster_WebAPI_BA();
        }

        #region Engineer
        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetComplaintCallLogs(CCRMComplaintLoggingMasterViewModel model)
        {
            CCRMComplaintLoggingMasterViewModel _CCRMComplaintLoggingMasterViewModel = new CCRMComplaintLoggingMasterViewModel();
            if (model != null && model.EngineerID > 0)
            {
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();

                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.EngineerID = model.EngineerID;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.SyncType = model.SyncType;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.LastSyncDate = model.LastSyncDate;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> response = _ICCRMComplaintLoggingMaster_WebAPI_BA.getComplaintLogsApi(_CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO);
                List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
                List<object> LogsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMComplaintLoggingMaster = response.CollectionResponse.ToList();
                        foreach (CCRMComplaintLoggingMaster item in listCCRMComplaintLoggingMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("CallTicketNumber", item.CallTktNo);
                            Data.Add("CallCharges", item.CallCharges);
                            Data.Add("CallDate", item.CallDate);
                            Data.Add("SerialNo", item.SerialNo);
                            Data.Add("MIFName", item.MIFName);
                            Data.Add("ModelNo", item.ModelNo);
                            Data.Add("AreaPatchName", item.AreaPatchName);
                            Data.Add("SymptomTitle", item.SymptomTitle);
                            Data.Add("ContractType", item.ContractType);
                            Data.Add("CustomerContact", item.Phoneno);
                            Data.Add("MachineLocation", item.MCAddress);
                            Data.Add("CustomerName", item.CustomerName);
                            Data.Add("CallTypeName", item.CallTypeName);
                            Data.Add("ServiceCallTypeID", item.CallTypeID);
                            Data.Add("Allotment", item.Allotment);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);
                            Data.Add("TrackType", item.TrackType);
                            Data.Add("CallStatus", item.CallStatus);
                            Data.Add("ComplaintNumberString", item.ComplaintNumberString);
                            Data.Add("PreviousA4Mono", item.A4Mono);
                            Data.Add("PreviousA4Col", item.A4Col);
                            Data.Add("PreviousA3Mono", item.A3Mono);
                            Data.Add("PreviousA3Col", item.A3Col);
                            Data.Add("ContractClosingDate", item.ContractClosingDate);

                            LogsRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? LogsRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", LogsRecord }
                        };
                    return _dict;
                }
            }
            return new Dictionary<string, object>
                    {
                        {"StatusCode",417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
        }
        #endregion

        #region Manager

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetComplaintLogs(CCRMComplaintLoggingMasterViewModel model)
        {
            CCRMComplaintLoggingMasterViewModel _CCRMComplaintLoggingMasterViewModel = new CCRMComplaintLoggingMasterViewModel();
            if (model != null)
            {
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();

                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.Allotment = model.Allotment;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> response = _ICCRMComplaintLoggingMaster_WebAPI_BA.getComplaints(_CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO);
                List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
                List<object> LogsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMComplaintLoggingMaster = response.CollectionResponse.ToList();
                        foreach (CCRMComplaintLoggingMaster item in listCCRMComplaintLoggingMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("CallTicketNumber", item.CallTktNo);
                            Data.Add("CallDate", item.CallDate);
                            Data.Add("SerialNo", item.SerialNo);
                            Data.Add("MIFName", item.MIFName);
                            Data.Add("ModelNo", item.ModelNo);
                            Data.Add("ContractType", item.ContractType);
                            Data.Add("CustomerContact", item.Phoneno);
                            Data.Add("MachineLocation", item.MCAddress);
                            Data.Add("CustomerName", item.CustomerName);
                            Data.Add("AllotedEngineer", item.SerEnggName);
                            Data.Add("EngineerID", item.EngineerID);
                            Data.Add("Allotment", item.Allotment);
                            Data.Add("TrackType", item.TrackType);
                            Data.Add("CallStatus", item.CallStatus);

                            LogsRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? LogsRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", LogsRecord }
                        };
                    return _dict;
                }
            }
            return new Dictionary<string, object>
                    {
                        {"StatusCode",417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
        }

        [HttpPost]
        [AllowAnonymous]
        //[BasicAuthorization]
        public object GetAllComplaints(CCRMComplaintLoggingMasterViewModel model)
        {
            CCRMComplaintLoggingMasterViewModel _CCRMComplaintLoggingMasterViewModel = new CCRMComplaintLoggingMasterViewModel();
            if (model != null)
            {
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();

                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.SyncType = model.SyncType;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.LastSyncDate = model.LastSyncDate;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> response = _ICCRMComplaintLoggingMaster_WebAPI_BA.getAllComplaints(_CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO);
                List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
                List<object> LogsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMComplaintLoggingMaster = response.CollectionResponse.ToList();
                        foreach (CCRMComplaintLoggingMaster item in listCCRMComplaintLoggingMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("CallTicketNumber", item.CallTktNo);
                            Data.Add("CallCharges", item.CallCharges);
                            Data.Add("CallDate", item.CallDate);
                            Data.Add("SerialNo", item.SerialNo);
                            Data.Add("MIFName", item.MIFName);
                            Data.Add("ModelNo", item.ModelNo);
                            Data.Add("AreaPatchName", item.AreaPatchName);
                            Data.Add("SymptomTitle", item.SymptomTitle);
                            Data.Add("ContractType", item.ContractType);
                            Data.Add("CustomerContact", item.Phoneno);
                            Data.Add("MachineLocation", item.MCAddress);
                            Data.Add("CustomerName", item.CustomerName);
                            Data.Add("CallTypeName", item.CallTypeName);
                            Data.Add("ServiceCallTypeID", item.CallTypeID);
                            Data.Add("Allotment", item.Allotment);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);
                            Data.Add("TrackType", item.TrackType);
                            Data.Add("CallStatus", item.CallStatus);
                           // Data.Add("ComplaintNumberString", item.ComplaintNumberString);
                            Data.Add("PreviousA4Mono", item.A4Mono);
                            Data.Add("PreviousA4Col", item.A4Col);
                            Data.Add("PreviousA3Mono", item.A3Mono);
                            Data.Add("PreviousA3Col", item.A3Col);
                            Data.Add("JSON", item.JSON);
                            Data.Add("AllotEnggId", item.EngineerID);
                            Data.Add("BrokenReason", item.BrokenReason);

                            LogsRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? LogsRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", LogsRecord }
                        };
                    return _dict;
                }
            }
            return new Dictionary<string, object>
                    {
                        {"StatusCode",417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
        }
        #endregion
    }
}