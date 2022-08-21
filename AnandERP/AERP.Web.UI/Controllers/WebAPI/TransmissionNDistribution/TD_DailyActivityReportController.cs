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
    public class TD_DailyActivityReportController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITD_DailyActivityReport_Web_API_BA _ITD_DailyActivityReport_Web_API_BA = null;
        public TD_DailyActivityReportController()
        {
            _ITD_DailyActivityReport_Web_API_BA = new TD_DailyActivityReport_Web_API_BA();
        }
        [HttpPost]
        [AllowAnonymous]
    //    [BasicAuthorization]
        public object InsertDailyActivityReport(DailyActivityReportViewModel model)
        {
            DailyActivityReportViewModel _DailyActivityReportViewModel = new DailyActivityReportViewModel();
            if (model != null)
            {
                _DailyActivityReportViewModel.DailyActivityReportDTO = new DailyActivityReport();
                _DailyActivityReportViewModel.DailyActivityReportDTO.ConsumerID = model.ConsumerID;
                _DailyActivityReportViewModel.DailyActivityReportDTO.CityID = model.CityID;
                _DailyActivityReportViewModel.DailyActivityReportDTO.Status = model.Status;
                _DailyActivityReportViewModel.DailyActivityReportDTO.Labours = model.Labours;
                _DailyActivityReportViewModel.DailyActivityReportDTO.Issues = model.Issues;
                _DailyActivityReportViewModel.DailyActivityReportDTO.WorkType = model.WorkType;
                _DailyActivityReportViewModel.DailyActivityReportDTO.CreatedBy = model.CreatedBy;
                _DailyActivityReportViewModel.DailyActivityReportDTO.Latitude = model.Latitude;
                _DailyActivityReportViewModel.DailyActivityReportDTO.Longitude = model.Longitude;
                _DailyActivityReportViewModel.DailyActivityReportDTO.VersionNumber = model.VersionNumber;
                _DailyActivityReportViewModel.DailyActivityReportDTO.CreatedDate = model.CreatedDate;
                _DailyActivityReportViewModel.DailyActivityReportDTO.ConnectionString = _connectioString;
                
                string XML = null;

                if (model.XML.Length > 12)
                {
                    XML = model.XML;
                }
                else
                {
                    XML = null;
                }
                _DailyActivityReportViewModel.DailyActivityReportDTO.XML = XML;


                IBaseEntityResponse<DailyActivityReport> response = _ITD_DailyActivityReport_Web_API_BA.InsertDailyActivityReport(_DailyActivityReportViewModel.DailyActivityReportDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
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
        [BasicAuthorization]
        public object InsertScheduleActivity(DailyActivityReportViewModel model)
        {
            DailyActivityReportViewModel _DailyActivityReportViewModel = new DailyActivityReportViewModel();
            if (model != null)
            {
                _DailyActivityReportViewModel.DailyActivityReportDTO = new DailyActivityReport();
                _DailyActivityReportViewModel.DailyActivityReportDTO.CreatedBy = model.CreatedBy;
                _DailyActivityReportViewModel.DailyActivityReportDTO.VersionNumber = model.VersionNumber;
                _DailyActivityReportViewModel.DailyActivityReportDTO.ConnectionString = _connectioString;

                string XML = null;

                if (model.XML.Length > 12)
                {
                    XML = model.XML;
                }
                else
                {
                    XML = null;
                }
                _DailyActivityReportViewModel.DailyActivityReportDTO.XML = XML;

                IBaseEntityResponse<DailyActivityReport> response = _ITD_DailyActivityReport_Web_API_BA.InsertScheduleActivity(_DailyActivityReportViewModel.DailyActivityReportDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
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
        public object GetWorkHistory(DailyActivityReportViewModel model)
        {
            DailyActivityReportViewModel _DailyActivityReportViewModel = new DailyActivityReportViewModel();
            if (model != null)
            {
                _DailyActivityReportViewModel.DailyActivityReportDTO = new DailyActivityReport();

                _DailyActivityReportViewModel.DailyActivityReportDTO.LastSyncDate = model.LastSyncDate;
                _DailyActivityReportViewModel.DailyActivityReportDTO.EngineerID = model.EngineerID;
                _DailyActivityReportViewModel.DailyActivityReportDTO.VersionNumber = model.VersionNumber;
                _DailyActivityReportViewModel.DailyActivityReportDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<DailyActivityReport> response = _ITD_DailyActivityReport_Web_API_BA.GetWorkHistory(_DailyActivityReportViewModel.DailyActivityReportDTO);
                List<DailyActivityReport> listDailyActivityReport = new List<DailyActivityReport>();
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
                        listDailyActivityReport = response.CollectionResponse.ToList();
                        foreach (DailyActivityReport item in listDailyActivityReport)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ConsumerID", item.ConsumerID);
                            Data.Add("Activity", item.Activity);
                            Data.Add("SubActivity", item.SubActivity);
                            Data.Add("ConsumerName", item.ConsumerName);
                            Data.Add("ConsumerNumber", item.ConsumerNumber);
                            Data.Add("WorkDone", item.WorkDone);
                            Data.Add("ActivityCategory", item.ActivityCategory);


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
        // [BasicAuthorization]
        public object GetWorkDetails(DailyActivityReportViewModel model)
        {
            DailyActivityReportViewModel _DailyActivityReportViewModel = new DailyActivityReportViewModel();
            if (model != null)
            {
                _DailyActivityReportViewModel.DailyActivityReportDTO = new DailyActivityReport();

                _DailyActivityReportViewModel.DailyActivityReportDTO.VersionNumber = model.VersionNumber;
                _DailyActivityReportViewModel.DailyActivityReportDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<DailyActivityReport> response = _ITD_DailyActivityReport_Web_API_BA.GetWorkDetails(_DailyActivityReportViewModel.DailyActivityReportDTO);
                List<DailyActivityReport> listDailyActivityReport = new List<DailyActivityReport>();
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
                        listDailyActivityReport = response.CollectionResponse.ToList();
                        foreach (DailyActivityReport item in listDailyActivityReport)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ConsumerID", item.ConsumerID);
                            Data.Add("Status", item.Status);
                            Data.Add("BillingStatus", item.BillingStatus);
                            Data.Add("ConsumerName", item.ConsumerName);
                            Data.Add("ConsumerNumber", item.ConsumerNumber);
                            Data.Add("ReasonStatus", item.ReasonStatus);
                            Data.Add("EngineerName", item.EngineerName);

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
