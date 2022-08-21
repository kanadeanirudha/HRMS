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
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace AERP.Web.UI
{
    public class CCRMCallClosureWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMCallClosure_Web_API_BA _ICCRMCallClosure_Web_API_BA = null;
        public CCRMCallClosureWebAPIController()
        {
            _ICCRMCallClosure_Web_API_BA = new CCRMCallClosure_Web_API_BA();
        }
        
        [HttpPost]
        [AllowAnonymous]
        //[BasicAuthorization]
        public object InsertServiceReport(CCRMServiceReportMasterViewModel model)
        {
            CCRMServiceReportMasterViewModel _CCRMServiceReportMasterViewModel = new CCRMServiceReportMasterViewModel();
            if (model != null)
            {

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO = new CCRMServiceReportMaster();

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CurrentReadA4Mono = model.CurrentReadA4Mono;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CurrentReadA4Col  = model.CurrentReadA4Col;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CurrentReadA3Mono = model.CurrentReadA3Mono;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CurrentReadA3Col  = model.CurrentReadA3Col;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CallTktNo         = model.CallTktNo;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.BrokenReason      = model.BrokenReason;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ReasonCode        = model.ReasonCode;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.SymptomID         = model.SymptomID;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.SymptomCode       = model.SymptomCode;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.SymptomTitle      = model.SymptomTitle;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CauseID           = model.CauseID;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CauseCode         = model.CauseCode;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CauseTitle        = model.CauseTitle;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ActionID          = model.ActionID;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ActionCode        = model.ActionCode;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ActionTitle       = model.ActionTitle;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.SymptomDescrip    = model.SymptomDescrip;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CauseDescrip      = model.CauseDescrip;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ActionDescrip     = model.ActionDescrip;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.Remarks           = model.Remarks;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.SCNSubmitted      = model.SCNSubmitted;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CallStatus        = model.CallStatus;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CreatedBy         = model.CreatedBy;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.VersionNumber     = model.VersionNumber;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.XmlString = model.XmlString;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ConnectionString  = _connectioString;

                IBaseEntityResponse<CCRMServiceReportMaster> response = _ICCRMCallClosure_Web_API_BA.InsertServiceReport(_CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    if (response.Entity.ID > 0)
                    {
                        Data.Add("ServiceReportID", response.Entity.ID);
                    }
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

        public async Task<object> ServiceReportImageUplaod()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return new Dictionary<string, object>
                    {
                        {"StatusCode", HttpStatusCode.UnsupportedMediaType},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
            }
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/Content/UploadedFiles/CCRMWebAPI/ServiceReport/");

            var _ImageUpload = new ImageUpload(fileuploadPath);
            var provider = await Request.Content.ReadAsMultipartAsync(_ImageUpload);
            string[] keys = provider.FormData.AllKeys;

            string uploadingFileName = _ImageUpload.FileData.Select(x => x.LocalFileName).FirstOrDefault();

            CCRMServiceReportMasterViewModel _CCRMServiceReportMasterViewModel = new CCRMServiceReportMasterViewModel();
            if (keys.Length > 0)
            {
                foreach (string key in keys)
                {
                    switch (key)
                    {
                        case "ServiceReportID":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ID = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                        break;

                        case "VersionNumber":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.VersionNumber = provider.FormData.GetValues(key)[0];
                        break;

                        case "ImageName":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.FileName = provider.FormData.GetValues(key)[0];
                        break;

                        case "CreatedBy":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CreatedBy = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                        break;
                    }
                }

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMServiceReportMaster> response =  _ICCRMCallClosure_Web_API_BA.InsertServiceReportImage(_CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO);
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

        public async Task<object> FeedBackImageUplaod()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return new Dictionary<string, object>
                    {
                        {"StatusCode", HttpStatusCode.UnsupportedMediaType},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
            }
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/Content/UploadedFiles/CCRMWebAPI/ServiceReport/");

            var _ImageUpload = new ImageUpload(fileuploadPath);
            var provider = await Request.Content.ReadAsMultipartAsync(_ImageUpload);
            string[] keys = provider.FormData.AllKeys;

            string uploadingFileName = _ImageUpload.FileData.Select(x => x.LocalFileName).FirstOrDefault();

            CCRMServiceReportMasterViewModel _CCRMServiceReportMasterViewModel = new CCRMServiceReportMasterViewModel();
            if (keys.Length > 0)
            {
                foreach (string key in keys)
                {
                    switch (key)
                    {
                        case "ServiceReportID":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ID = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                            break;

                        case "VersionNumber":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.VersionNumber = provider.FormData.GetValues(key)[0];
                            break;

                        case "ImageName":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.FileName = provider.FormData.GetValues(key)[0];
                            break;

                        case "CreatedBy":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CreatedBy = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                            break;

                        case "Feedback":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.FeedbackID = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                            break;

                        case "Remarks":
                            _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.Remarks = provider.FormData.GetValues(key)[0];
                            break;
                    }
                }

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<CCRMServiceReportMaster> response = _ICCRMCallClosure_Web_API_BA.InsertFeedBackImage(_CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO);
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
        public object itemHistory(CCRMServiceReportMasterViewModel model)
        {
            CCRMServiceReportMasterViewModel _CCRMServiceReportMasterViewModel = new CCRMServiceReportMasterViewModel();
            if (model != null)
            {

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO = new CCRMServiceReportMaster();

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.CallTktNo = model.CallTktNo;
                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.VersionNumber = model.VersionNumber;

                _CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO.ConnectionString = _connectioString;

                IBaseEntityCollectionResponse<CCRMServiceReportMaster> response = _ICCRMCallClosure_Web_API_BA.itemHistory(_CCRMServiceReportMasterViewModel.CCRMServiceReportMasterDTO);
                List<CCRMServiceReportMaster> listItemHistory = new List<CCRMServiceReportMaster>();
                List<object> ItemHistoryRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listItemHistory = response.CollectionResponse.ToList();
                        foreach (CCRMServiceReportMaster item in listItemHistory)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ItemCode", item.ItemCategoryCode);
                            Data.Add("ItemName", item.ItemName);
                            Data.Add("Quantity", item.Quantity);
                            Data.Add("RequiredFlag", item.Requierd);

                            ItemHistoryRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? ItemHistoryRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", ItemHistoryRecord }
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
