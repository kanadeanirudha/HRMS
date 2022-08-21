using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.Business.BusinessActions;
using AERP.DTO;
using AERP.ExceptionManager;
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
    public class LeaveMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ILeaveMaster_Web_API_BA _ILeaveMaster_Web_API_BA = null;
        IAttendenceMonitoringSystemBA _attendenceMonitoringSystemBA = null;
        private readonly ILogger _logException;
        public LeaveMasterWebAPIController()
        {
            _ILeaveMaster_Web_API_BA = new LeaveMaster_Web_API_BA();
            _attendenceMonitoringSystemBA = new AttendenceMonitoringSystemBA();
        }

        [HttpPost]
        [AllowAnonymous]
       // [BasicAuthorization]
        public object GetLeaves(LeaveMasterViewModelWebAPI model)
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModel = new LeaveMasterViewModelWebAPI();
            if (model != null)
            {
                _LeaveMasterViewModel.LeaveMasterDTO = new LeaveMaster();

                _LeaveMasterViewModel.LeaveMasterDTO.LastSyncDate = model.LastSyncDate;
                _LeaveMasterViewModel.LeaveMasterDTO.SyncType = model.SyncType;
                _LeaveMasterViewModel.LeaveMasterDTO.VersionNumber = model.VersionNumber;
                _LeaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.getLeaves(_LeaveMasterViewModel.LeaveMasterDTO);
                List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
                List<object> ItemsRecord = new List<object>();
                int statusCode;
                string URL= "";
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    URL = MessageList[0].Title;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listLeaveMaster = response.CollectionResponse.ToList();
                        foreach (LeaveMaster item in listLeaveMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("LeaveID", item.ID);
                            Data.Add("LeaveCode", item.LeaveCode);
                            Data.Add("LeaveDescription", item.LeaveDescription);
                            Data.Add("NumberOfLeaves", item.NumberOfLeaves);
                            Data.Add("MaxLeaveAtTime", item.MaxLeaveAtTime);
                            Data.Add("DaysBeforeApplicationSubmitted", item.DaysBeforeApplicationSubmitted);
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
                             {"URL", URL},
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
        public object InsertManualAttendance(LeaveManualAttendanceViewModel model)
        {
            LeaveManualAttendanceViewModel _LeaveManualAttendanceViewModel = new LeaveManualAttendanceViewModel();
            if (model != null)
            {
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.ConnectionString = _connectioString;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.EmployeeID = model.EmployeeID;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.AttendanceDate = model.AttendanceDate;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.AttendenceFor = model.AttendenceFor;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.CheckInTime = model.CheckInTime;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.CheckOutTime = model.CheckOutTime;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.Reason = model.Reason;
                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.VersionNumber = model.VersionNumber;

                _LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO.CreatedBy = model.CreatedBy;
                IBaseEntityResponse<LeaveManualAttendance> response = _ILeaveMaster_Web_API_BA.InsertLeaveManualAttendance(_LeaveManualAttendanceViewModel.LeaveManualAttendanceDTO);

                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"URL",response.Entity.URL },
                        {"Message", CheckError(response.Entity.ErrorCode)},
                        {"Data", Data }
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
        public object InserSpecialLeaveRequest(LeaveAttendanceSpecialRequestViewModel model)
        {
            LeaveAttendanceSpecialRequestViewModel _LeaveAttendanceSpecialRequestViewModel = new LeaveAttendanceSpecialRequestViewModel();
            if (model != null)
            {
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.ConnectionString = _connectioString;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.ID = model.ID;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.EmployeeID = model.EmployeeID;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.StatusFlag = model.StatusFlag;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.RequestedDate = model.RequestedDate;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.CentreCode = model.CentreCode;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.Reason = model.Reason;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.CommingTime = model.CommingTime;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.LeavingTime = model.LeavingTime;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.CreatedBy = model.CreatedBy;
                _LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO.VersionNumber = model.VersionNumber;

                IBaseEntityResponse<LeaveAttendanceSpecialRequest> response = _ILeaveMaster_Web_API_BA.InsertSpecialLeaveAttendance(_LeaveAttendanceSpecialRequestViewModel.LeaveAttendanceSpecialRequestDTO);


                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"URL",response.Entity.URL },
                        {"Message", CheckError(response.Entity.ErrorCode)},
                        {"Data", Data }
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
        // [BasicAuthorization]
        public object GetManualAttendance(LeaveMasterViewModelWebAPI model)
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModel = new LeaveMasterViewModelWebAPI();
            if (model != null)
            {
                _LeaveMasterViewModel.LeaveMasterDTO = new LeaveMaster();

                _LeaveMasterViewModel.LeaveMasterDTO.EmployeeID = model.EmployeeID;
                _LeaveMasterViewModel.LeaveMasterDTO.CentreCode = model.CentreCode;
                _LeaveMasterViewModel.LeaveMasterDTO.VersionNumber = model.VersionNumber;
                _LeaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.GetManualAttendance(_LeaveMasterViewModel.LeaveMasterDTO);
                List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
                List<object> ItemsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";
                string URL = "";
                
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    URL = MessageList[0].Title;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listLeaveMaster = response.CollectionResponse.ToList();
                        foreach (LeaveMaster item in listLeaveMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("EmployeeName", item.EmployeeName);
                            Data.Add("AttendanceDate", item.AttendanceDate);
                            Data.Add("CheckInTime", item.CheckInTime);
                            Data.Add("CheckOutTime", item.CheckOutTime);
                            Data.Add("Reason", item.Reason);
                            Data.Add("Status", item.Status);

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
                        { "URL",URL},
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
        // [BasicAuthorization]
        public object GetSpecialLeave(LeaveMasterViewModelWebAPI model)
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModel = new LeaveMasterViewModelWebAPI();
            if (model != null)
            {
                _LeaveMasterViewModel.LeaveMasterDTO = new LeaveMaster();

                _LeaveMasterViewModel.LeaveMasterDTO.EmployeeID = model.EmployeeID;
                _LeaveMasterViewModel.LeaveMasterDTO.CentreCode = model.CentreCode;
                _LeaveMasterViewModel.LeaveMasterDTO.VersionNumber = model.VersionNumber;
                _LeaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.GetSpecialLeave(_LeaveMasterViewModel.LeaveMasterDTO);
                List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
                List<object> ItemsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "",URL = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    URL = MessageList[0].Title;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listLeaveMaster = response.CollectionResponse.ToList();
                        foreach (LeaveMaster item in listLeaveMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("EmployeeName", item.EmployeeName);
                            Data.Add("ComingTime", item.CommingTime);
                            Data.Add("LeavingTime", item.LeavingTime);
                            Data.Add("RequestedDate", item.AttendanceDate);
                            Data.Add("Reason", item.Reason);
                            Data.Add("Status", item.Status);

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
                        { "URL",URL},
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
        // [BasicAuthorization]
        public object CalenderInfo(AttendenceMonitoringSystemViewModel model)// DateTime fromDate, DateTime toDate, int employeeID)
        {
                AttendenceMonitoringSystemSearchRequest searchRequest = new AttendenceMonitoringSystemSearchRequest();
                searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
                searchRequest.EmployeeID = model.EmployeeID;
                searchRequest.FromDate = ConvertFromMiliSecondsToDate(model.StartTime);
                searchRequest.UptoDate = ConvertFromMiliSecondsToDate(model.EndTime);
                searchRequest.VersionNumber = model.VersionNumber;

                List<AttendenceMonitoringSystem> listAttendenceMonitoringSystem = new List<AttendenceMonitoringSystem>();
                IBaseEntityCollectionResponse<AttendenceMonitoringSystem> response = _attendenceMonitoringSystemBA.GetAttendenceDetailsByEmployeeID_WebAPI(searchRequest);
                List<object> Records = new List<object>();

            int statusCode;
                string ErrorMessage = "",URL = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                URL = MessageList[0].Title;
                if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listAttendenceMonitoringSystem = response.CollectionResponse.ToList();
                        foreach (AttendenceMonitoringSystem item in listAttendenceMonitoringSystem)
                        {
                             List<object> ItemsRecord = new List<object>();

                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("AttendanceDate", item.AttendanceDate);
                            Data.Add("holidayDescription", item.HolidayDescription);
                            Data.Add("WeeklyOffStatus", item.WeeklyOffStatus);
                            Data.Add("LeaveDescription", item.LeaveCode);
                            Data.Add("AttendanceDescription", item.AttendanceDescription);
                            Data.Add("CheckInTime", item.CheckInTime);
                            Data.Add("CheckOutTime", item.CheckOutTime);
                            Data.Add("WorkingHour", item.WorkingHour);
                            Data.Add("HalfLeaveStatus", item.HalfLeaveStatus);
                    
                            
                            ItemsRecord.Add(Data);
                        Dictionary<String, object> Data1 = new Dictionary<string, object>();
                        Data1.Add(Convert.ToString(item.AttendanceDate), Data);
                        Records.Add(Data1);

                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? Records.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                        { "URL",URL},
                             {"Message", CheckError(statusCode)},
                             {"Data", Records }
                        };
                    return _dict;
                }
                else
                {
                    return new Dictionary<string, object>
                    {
                        {"StatusCode", 417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
                }
        }

        [HttpPost]
        [AllowAnonymous]
        public object InsertAttendance(AddAttendanceViewModel model)
        {
            AddAttendanceViewModel _AddAttendanceViewModel = new AddAttendanceViewModel();
            if (model != null)
            {
                _AddAttendanceViewModel.AddAttendanceDTO.ConnectionString = _connectioString;
                _AddAttendanceViewModel.AddAttendanceDTO.XML = model.XML;
                _AddAttendanceViewModel.AddAttendanceDTO.VersionNumber = model.VersionNumber;

                IBaseEntityResponse<AddAttendance> response = _ILeaveMaster_Web_API_BA.AddAttendance(_AddAttendanceViewModel.AddAttendanceDTO);


                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"URL",response.Entity.URL },
                        {"Message", CheckError(response.Entity.ErrorCode)},
                        {"Data", Data }
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
        // [BasicAuthorization]
        public object BalanceLeaves(LeaveMasterViewModelWebAPI model)// DateTime fromDate, DateTime toDate, int employeeID)
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModelWebAPI = new LeaveMasterViewModelWebAPI();
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.ID = model.ID;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.EmployeeID = model.EmployeeID;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.LeaveSessionID = model.LeaveSessionID;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.VersionNumber = model.VersionNumber;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.CreatedBy = model.CreatedBy;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.ConnectionString = _connectioString;
            List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
            IBaseEntityCollectionResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.GetLeaveDetails(_LeaveMasterViewModelWebAPI.LeaveMasterDTO);
            List<object> ItemsRecord = new List<object>();

            int statusCode;
            string ErrorMessage = "",URL = "";
            if (response != null)
            {
                List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                statusCode = MessageList[0].ErrorID;
                ErrorMessage = MessageList[0].ErrorMessage;
                URL = MessageList[0].Title;
                if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                {
                    listLeaveMaster = response.CollectionResponse.ToList();
                    foreach (LeaveMaster item in listLeaveMaster)
                    {
                        Dictionary<String, object> Data = new Dictionary<string, object>();
                        Data.Add("LeaveRuleMasterID", item.ID);
                        Data.Add("NumberOfLeaves", item.NumberOfLeaves);
                        Data.Add("BalanceLeave", item.BalanceLeave);
                        Data.Add("MaxLeaveAtTime", item.MaxLeaveAtTime);
                        Data.Add("DaysBeforeApplicationSubmitted", item.DaysBeforeApplicationSubmitted);
                      
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
            else
            {
                return new Dictionary<string, object>
                    {
                        {"StatusCode", 417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
            }
        }

        [HttpPost]
        [AllowAnonymous]
        // [BasicAuthorization]
        public object AppliedLeaves(LeaveMasterViewModelWebAPI model)// DateTime fromDate, DateTime toDate, int employeeID)
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModelWebAPI = new LeaveMasterViewModelWebAPI();
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.EmployeeID = model.EmployeeID;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.VersionNumber = model.VersionNumber;
            _LeaveMasterViewModelWebAPI.LeaveMasterDTO.ConnectionString = _connectioString;
            List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
            IBaseEntityCollectionResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.GetLeaveApplicationApprocedPendingStatus_SearchList(_LeaveMasterViewModelWebAPI.LeaveMasterDTO);
            List<object> ItemsRecord = new List<object>();

            int statusCode;
            string ErrorMessage = "",URL="";
            if (response != null)
            {
                List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                statusCode = MessageList[0].ErrorID;
                ErrorMessage = MessageList[0].ErrorMessage;
                URL = MessageList[0].Title;
                if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                {
                    listLeaveMaster = response.CollectionResponse.ToList();
                    foreach (LeaveMaster item in listLeaveMaster)
                    {
                        Dictionary<String, object> Data = new Dictionary<string, object>();
                        Data.Add("LeaveMasterID", item.ID);
                        Data.Add("ApplicationCode", item.ApplicationCode);
                        Data.Add("ApplicationDate", item.ApplicationDate);
                        Data.Add("LeaveDate", item.LeaveDate);
                        Data.Add("FullDayHalfDayDetails", item.FullDayHalfDayDetails);
                        Data.Add("LeaveApprovalStatus", item.LeaveApprovalStatus);
                        Data.Add("LeaveDescription", item.LeaveDescription);
                        Data.Add("LeaveSessionID", item.LeaveSessionID);
                        Data.Add("LeaveCode", item.LeaveCode);
                        Data.Add("LeaveApplicationID", item.LeaveApplicationID);
                        Data.Add("LeaveApplicationTransactionID", item.LeaveApplicationTransactionID);
                        
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
                    { "URL",URL},
                             {"Message", CheckError(statusCode)},
                             {"Data", ItemsRecord }
                        };
                return _dict;
            }
            else
            {
                return new Dictionary<string, object>
                    {
                        {"StatusCode", 417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public object CancelLeaves(LeaveMasterViewModelWebAPI model)
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModelWebAPI = new LeaveMasterViewModelWebAPI();
            if (model != null)
            {
                _LeaveMasterViewModelWebAPI.LeaveMasterDTO.ConnectionString = _connectioString;
                _LeaveMasterViewModelWebAPI.LeaveMasterDTO.EmployeeID = model.EmployeeID;
                _LeaveMasterViewModelWebAPI.LeaveMasterDTO.XML = model.XML;
                _LeaveMasterViewModelWebAPI.LeaveMasterDTO.VersionNumber = model.VersionNumber;

                _LeaveMasterViewModelWebAPI.LeaveMasterDTO.CreatedBy = model.CreatedBy;
                IBaseEntityResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.InsertLeaveApplicationCancel(_LeaveMasterViewModelWebAPI.LeaveMasterDTO);

                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"URL",response.Entity.URL },
                        {"Message", CheckError(response.Entity.ErrorCode)},
                        {"Data", Data }
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

        [HttpGet]
        [AllowAnonymous]
        // [BasicAuthorization]
        public object GetVersion()
        {
            LeaveMasterViewModelWebAPI _LeaveMasterViewModel = new LeaveMasterViewModelWebAPI();
          //  if (model != null)
            {
                _LeaveMasterViewModel.LeaveMasterDTO = new LeaveMaster();
                _LeaveMasterViewModel.LeaveMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<LeaveMaster> response = _ILeaveMaster_Web_API_BA.getVersionNumber(_LeaveMasterViewModel.LeaveMasterDTO);
                List<LeaveMaster> listLeaveMaster = new List<LeaveMaster>();
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
                        listLeaveMaster = response.CollectionResponse.ToList();
                        foreach (LeaveMaster item in listLeaveMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("VersionNumber", item.VersionNumber);
                            Data.Add("URL", item.URL);

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