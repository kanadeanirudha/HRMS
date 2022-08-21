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
    public class SelfLeaveApplicationController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ISelfLeaveApplicationBA _ISelfLeaveApplicationBA = null;
        public SelfLeaveApplicationController()
        {
            _ISelfLeaveApplicationBA = new SelfLeaveApplicationBA();
        }
        [HttpPost]
        public object InsertSelfLeave(SelfLeaveApplicationViewModel model)
        {
            SelfLeaveApplicationViewModel _SelfLeaveApplicationViewModel = new SelfLeaveApplicationViewModel();
            if (model != null)
            {
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO = new SelfLeaveApplication();
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.EmployeeID = model.EmployeeID;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.LeaveMasterID = model.LeaveMasterID;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.FromDate = model.FromDate;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.UptoDate = model.UptoDate;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.LeaveReason = model.LeaveReason;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.LeaveRuleMasterID = model.LeaveRuleMasterID;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.CentreCode = model.CentreCode;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.VersionNumber = model.VersionNumber;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.IsFirstHalf = model.IsFirstHalf;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.IsSecondHalf = model.IsSecondHalf;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.TotalfullDaysLeave = model.TotalfullDaysLeave;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.TotalHalfDayLeave = model.TotalHalfDayLeave;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.LeaveSessionID = model.LeaveSessionID;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.ConnectionString = _connectioString;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.ApplicationStatus = "PENDING";

                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.CreatedBy = model.CreatedBy;
                IBaseEntityResponse<SelfLeaveApplication> response = _ISelfLeaveApplicationBA.InsertSelfLeave(_SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO);

                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"Message", CheckError(response.Entity.ErrorCode)},
                        {"URL", response.Entity.URL},
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
        public object GetSelfLeaves(SelfLeaveApplicationViewModel model)
        {
            SelfLeaveApplicationViewModel _SelfLeaveApplicationViewModel = new SelfLeaveApplicationViewModel();
            if (model != null)
            {
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO = new SelfLeaveApplication();

                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.VersionNumber = model.VersionNumber;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.LeaveSessionFromDate = model.LeaveSessionFromDate;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.LeaveSessionUptoDate = model.LeaveSessionUptoDate;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.EmployeeID = model.EmployeeID;
                _SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO.ConnectionString = _connectioString;

                IBaseEntityCollectionResponse<SelfLeaveApplication> response = _ISelfLeaveApplicationBA.getSelfLeaves(_SelfLeaveApplicationViewModel.SelfLeaveApplicationDTO);
                List<SelfLeaveApplication> listLeaveMaster = new List<SelfLeaveApplication>();
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
                        foreach (SelfLeaveApplication item in listLeaveMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                           // Data.Add("LeaveID", item.ID);
                            Data.Add("AttendanceDate", item.AttendanceDate);
                            Data.Add("AttendanceDescription", item.AttendanceDescription);
                            Data.Add("AttendanceStatus", item.AttendanceStatus);
                            Data.Add("CheckInTime", item.CheckInTime);
                            Data.Add("CheckOutTime", item.CheckOutTime);
                            Data.Add("workingHour", item.workingHour);
                            //  Data.Add("Entity", item.Entity);

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
