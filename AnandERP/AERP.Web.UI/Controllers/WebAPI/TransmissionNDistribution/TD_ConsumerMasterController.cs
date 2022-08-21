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
    public class TD_ConsumerMasterController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITD_ConsumerMaster_Web_API_BA _ITD_ConsumerMaster_Web_API_BA = null;
        public TD_ConsumerMasterController()
        {
            _ITD_ConsumerMaster_Web_API_BA = new TD_ConsumerMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetConsumers(ConsumerMasterViewModel model)
        {
            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (model != null)
            {
                _ConsumerMasterViewModel.ConsumerMasterDTO = new ConsumerMaster();

                _ConsumerMasterViewModel.ConsumerMasterDTO.LastSyncDate = model.LastSyncDate;
                _ConsumerMasterViewModel.ConsumerMasterDTO.SyncType = model.SyncType;
                _ConsumerMasterViewModel.ConsumerMasterDTO.VersionNumber = model.VersionNumber;
                _ConsumerMasterViewModel.ConsumerMasterDTO.EngineerID = model.EngineerID;

                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.getConsumers(_ConsumerMasterViewModel.ConsumerMasterDTO);
                List<ConsumerMaster> listConsumerMaster = new List<ConsumerMaster>();
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
                        listConsumerMaster = response.CollectionResponse.ToList();
                        foreach (ConsumerMaster item in listConsumerMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ConsumerID", item.ID);
                            Data.Add("ConsumerNumber", item.ConsumerNumber);
                            Data.Add("ConsumerName", item.ConsumerName);
                            Data.Add("SectionID", item.SectionID);
                            Data.Add("Section", item.Section);
                            Data.Add("CityID", item.CityID);
                            Data.Add("City", item.City);
                            Data.Add("Address", item.Address);
                            Data.Add("ActualSurvey_In_Meters", item.ActualSurvey_In_Meters);
                            Data.Add("Phase", item.Phase);
                            Data.Add("Latitude", item.Latitude);
                            Data.Add("Longitude", item.Longitude);
                            Data.Add("Remark", item.Remark);
                            Data.Add("DTCNumber", item.DTCNumber);
                            Data.Add("MobileNumber", item.MobileNumber);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);
                            Data.Add("IsAdd", item.ISAdd);
                            Data.Add("Status", item.WorkStatus);
                            Data.Add("BillingStatus", item.BillingStatus);
                            Data.Add("ReasonStatus", item.ReasonStatus);
                            Data.Add("isPreviousDateAllowed", item.IsPreviousDateAllowed ? 1 : 0);


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
        public object DeleteConsumer(ConsumerMasterViewModel model)
        {
            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (model != null)
            {
                _ConsumerMasterViewModel.ConsumerMasterDTO = new ConsumerMaster();
                _ConsumerMasterViewModel.ConsumerMasterDTO.ID = model.ID;
                _ConsumerMasterViewModel.ConsumerMasterDTO.Reason = model.Reason;
                _ConsumerMasterViewModel.ConsumerMasterDTO.DeletedBy = model.DeletedBy;
                _ConsumerMasterViewModel.ConsumerMasterDTO.VersionNumber = model.VersionNumber;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.DeleteConsumer(_ConsumerMasterViewModel.ConsumerMasterDTO);
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
        public object UpdateConsumerDetails(ConsumerMasterViewModel model)
        {
            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (model != null)
            {
                _ConsumerMasterViewModel.ConsumerMasterDTO = new ConsumerMaster();
                _ConsumerMasterViewModel.ConsumerMasterDTO.ID = model.ID;
                _ConsumerMasterViewModel.ConsumerMasterDTO.Latitude = model.Latitude;
                _ConsumerMasterViewModel.ConsumerMasterDTO.Longitude = model.Longitude;
                _ConsumerMasterViewModel.ConsumerMasterDTO.CreatedBy = model.CreatedBy;
                _ConsumerMasterViewModel.ConsumerMasterDTO.VersionNumber = model.VersionNumber;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.UpdateConsumerLatLong(_ConsumerMasterViewModel.ConsumerMasterDTO);
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
        public object UpdateTappingPointLatLong(ConsumerMasterViewModel model)
        {
            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (model != null)
            {
                _ConsumerMasterViewModel.ConsumerMasterDTO = new ConsumerMaster();
                _ConsumerMasterViewModel.ConsumerMasterDTO.ID = model.ID;
                _ConsumerMasterViewModel.ConsumerMasterDTO.Latitude = model.Latitude;
                _ConsumerMasterViewModel.ConsumerMasterDTO.Longitude = model.Longitude;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ModifiedBy = model.ModifiedBy;
                _ConsumerMasterViewModel.ConsumerMasterDTO.VersionNumber = model.VersionNumber;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.UpdateTappingPointLatLong(_ConsumerMasterViewModel.ConsumerMasterDTO);
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

        public async Task<object> ImageUplaod()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return new Dictionary<string, object>
                    {
                        {"StatusCode", HttpStatusCode.UnsupportedMediaType},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
            }
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/Content/UploadedFiles/Consumer/");

            var _ImageUpload = new ImageUpload(fileuploadPath);
            var provider = await Request.Content.ReadAsMultipartAsync(_ImageUpload);
            string[] keys = provider.FormData.AllKeys;

            string uploadingFileName = _ImageUpload.FileData.Select(x => x.LocalFileName).FirstOrDefault();

            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (keys.Length > 0)
            {
                foreach (string key in keys)
                {
                    switch (key)
                    {
                        case "ConsumerID":
                            _ConsumerMasterViewModel.ConsumerMasterDTO.ID = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                            break;

                        case "VersionNumber":
                            _ConsumerMasterViewModel.ConsumerMasterDTO.VersionNumber = provider.FormData.GetValues(key)[0];
                            break;

                        case "ImageName":
                            _ConsumerMasterViewModel.ConsumerMasterDTO.FileName = provider.FormData.GetValues(key)[0];
                            break;

                        case "CreatedBy":
                            _ConsumerMasterViewModel.ConsumerMasterDTO.CreatedBy = Convert.ToInt32(provider.FormData.GetValues(key)[0]);
                            break;
                    }
                }

                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.InsertImage(_ConsumerMasterViewModel.ConsumerMasterDTO);
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
        public object AddRequirment(ConsumerMasterViewModel model)
        {
            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (model != null)
            {
                _ConsumerMasterViewModel.ConsumerMasterDTO = new ConsumerMaster();
                _ConsumerMasterViewModel.ConsumerMasterDTO.ID = model.ID;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ActualSurvey_In_KMeters = model.ActualSurvey_In_KMeters;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ActualSurvey_In_Meters = model.ActualSurvey_In_Meters;
                _ConsumerMasterViewModel.ConsumerMasterDTO.GaurdingNeeded = model.GaurdingNeeded;
                _ConsumerMasterViewModel.ConsumerMasterDTO.GaurdingSpanNeeded = model.GaurdingSpanNeeded;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ExtensionOfServiceConnection = model.ExtensionOfServiceConnection;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ServiceConnection = model.ServiceConnection;
                _ConsumerMasterViewModel.ConsumerMasterDTO.TappingFrom_ActivityID = model.TappingFrom_ActivityID;
                _ConsumerMasterViewModel.ConsumerMasterDTO.TappingLocationDetails = model.TappingLocationDetails;
                _ConsumerMasterViewModel.ConsumerMasterDTO.TappingMaterials = model.TappingMaterials;
                _ConsumerMasterViewModel.ConsumerMasterDTO.No_Of_Poles = model.No_Of_Poles;
                _ConsumerMasterViewModel.ConsumerMasterDTO.No_Of_CutPoints = model.No_Of_CutPoints;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ConsumersGroup = model.ConsumersGroup;
                _ConsumerMasterViewModel.ConsumerMasterDTO.isCommunicateWithFarmer = model.isCommunicateWithFarmer;
                _ConsumerMasterViewModel.ConsumerMasterDTO.FarmerCommunication = model.FarmerCommunication;
                _ConsumerMasterViewModel.ConsumerMasterDTO.PresentCrop = model.PresentCrop;
                _ConsumerMasterViewModel.ConsumerMasterDTO.FutureCrop = model.FutureCrop;
                _ConsumerMasterViewModel.ConsumerMasterDTO.PresentCropCuttingDate = model.PresentCropCuttingDate;
                _ConsumerMasterViewModel.ConsumerMasterDTO.FutureCropPlantationDate = model.FutureCropPlantationDate;
                _ConsumerMasterViewModel.ConsumerMasterDTO.AdharCardNumber = model.AdharCardNumber;
                _ConsumerMasterViewModel.ConsumerMasterDTO.CreatedBy = model.CreatedBy;
                _ConsumerMasterViewModel.ConsumerMasterDTO.OtherIssues = model.OtherIssues;
                _ConsumerMasterViewModel.ConsumerMasterDTO.VersionNumber = model.VersionNumber;
                _ConsumerMasterViewModel.ConsumerMasterDTO.StayLine = model.StayLine;
                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;

                IBaseEntityResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.AddConsumerRequirment(_ConsumerMasterViewModel.ConsumerMasterDTO);
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
        public object GenerateGroups(ConsumerMasterViewModel model)
        {
            ConsumerMasterViewModel _ConsumerMasterViewModel = new ConsumerMasterViewModel();
            if (model != null)
            {
                _ConsumerMasterViewModel.ConsumerMasterDTO = new ConsumerMaster();

                _ConsumerMasterViewModel.ConsumerMasterDTO.CreatedBy = model.CreatedBy;
               
                _ConsumerMasterViewModel.ConsumerMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<ConsumerMaster> response = _ITD_ConsumerMaster_Web_API_BA.generateGroups(_ConsumerMasterViewModel.ConsumerMasterDTO);
                List<ConsumerMaster> listConsumerMaster = new List<ConsumerMaster>();
                List<object> ItemsRecord = new List<object>();

                int statusCode;
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    Boolean flag = false;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        Dictionary<String, object> TempData = new Dictionary<string, object>();
                        Dictionary<String, object> Data = new Dictionary<string, object>();
                        Dictionary<String, object> FilterData = new Dictionary<string, object>();

                        HashSet<object> ItemsSets = new HashSet<object>();

                        listConsumerMaster = response.CollectionResponse.ToList();
                        HashSet<Object> listIgnoreList = new HashSet<object>();
                        int i = 0;
                       
                            foreach (ConsumerMaster item in listConsumerMaster)
                            {
                                ItemsSets.Clear();

                                foreach (ConsumerMaster innerItem in listConsumerMaster)
                                {
                                    if (item.Source == innerItem.Source || item.Source == innerItem.Destination)
                                    {
                                    
                                        if (!listIgnoreList.Contains(innerItem.Source) || !listIgnoreList.Contains  (innerItem.Destination))
                                        {
                                            if (item.Destination == 0)
                                            {
                                                listIgnoreList.Add(innerItem.Source);
                                                ItemsSets.Add(innerItem.Source);
                                                break;
                                            }
                                            else
                                            {
                                                listIgnoreList.Add(innerItem.Source);
                                                listIgnoreList.Add(innerItem.Destination);
                                                ItemsSets.Add(innerItem.Source);
                                                ItemsSets.Add(innerItem.Destination);
                                            }
                                       }  
                                    }
                                }
                            if (ItemsSets.Count > 0)
                                TempData.Add("Group" + ++i, ItemsSets.ToList());

                             }
                        do
                        {
                            TempData = filterGroups(TempData);
                            ItemsRecord.Clear();
                            ItemsRecord.Add(TempData);
                        }
                        while (checkContainsDuplicate(TempData));

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

        private Dictionary<string, object> filterGroups(Dictionary<string, object> TempData)
        {
            int i = 0;
            Dictionary<string, object> Data = new Dictionary<string, object>();
            List<string> tempKeys = new List<string>();
            foreach (string key in TempData.Keys.ToArray())
            {
                List<object> list = (List<object>)TempData[key];
                HashSet<object> tempList = new HashSet<object>(list);

                foreach (string innerkey in TempData.Keys)
                {
                    if (!key.Equals(innerkey))
                    {
                        List<object> innerList = (List<object>)TempData[innerkey];
                        foreach (object obj in list)
                        {
                            if (innerList.Contains(obj))
                            {
                                tempList.UnionWith(innerList);
                                if (!tempKeys.Contains(innerkey) && !tempKeys.Contains(key))
                                    tempKeys.Add(innerkey);
                            }
                        }
                    }
                }
                Data.Add("Group" + ++i, tempList.ToList());
            }
            foreach (string key in tempKeys)
            {
                Data.Remove(key);
            }
            return Data;
        }

        private bool checkContainsDuplicate(Dictionary<string, object> TempData)
        {
            int i = 0;
            Dictionary<string, object> Data = new Dictionary<string, object>();
            List<string> tempKeys = new List<string>();
            foreach (string key in TempData.Keys.ToArray())
            {
                List<object> list = (List<object>)TempData[key];
                HashSet<object> tempList = new HashSet<object>(list);

                foreach (string innerkey in TempData.Keys)
                {
                    if (!key.Equals(innerkey))
                    {
                        List<object> innerList = (List<object>)TempData[innerkey];
                        foreach (object obj in list)
                        {
                            if (innerList.Contains(obj))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
          
            return false;
        }
    }
}
