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
    public class LocationTrackingController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ILocationTrackingBA _ILocationTrackingBA = null;
        public LocationTrackingController()
        {
            _ILocationTrackingBA = new LocationTrackingBA();
        }

        [HttpPost]
        [AllowAnonymous]
       // [BasicAuthorization]
        public object GetCurrentLocation(LocationTrackingViewModel model)
        {
            LocationTrackingViewModel _LocationTrackingViewModel = new LocationTrackingViewModel();
            if (model != null)
            {
                _LocationTrackingViewModel.LocationTrackingDTO = new LocationTracking();
                _LocationTrackingViewModel.LocationTrackingDTO.ManagerID = model.ManagerID;
                _LocationTrackingViewModel.LocationTrackingDTO.VersionNumber = model.VersionNumber;

                _LocationTrackingViewModel.LocationTrackingDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<LocationTracking> response = _ILocationTrackingBA.getCurrentLocation(_LocationTrackingViewModel.LocationTrackingDTO);
                List<LocationTracking> listLocationTracking = new List<LocationTracking>();
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
                        listLocationTracking = response.CollectionResponse.ToList();
                        foreach (LocationTracking item in listLocationTracking)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("Name", item.Name);
                            Data.Add("Latitude", item.Latitude);
                            Data.Add("Longitude", item.Longitude);
                            Data.Add("EngineerID", item.CreatedBy);

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
        //[BasicAuthorization]
        public object InsertLocations(LocationTrackingViewModel model)
        {
            LocationTrackingViewModel _LocationTrackingViewModel = new LocationTrackingViewModel();
            if (model != null)
            {
                _LocationTrackingViewModel.LocationTrackingDTO = new LocationTracking();
                
                _LocationTrackingViewModel.LocationTrackingDTO.VersionNumber = model.VersionNumber;
                _LocationTrackingViewModel.LocationTrackingDTO.ConnectionString = _connectioString;

                string XML = null;

                if (model.XML.Length > 6)
                {
                    XML = model.XML;
                }
                else
                {
                    XML = null;
                }
                _LocationTrackingViewModel.LocationTrackingDTO.XML = XML;

                IBaseEntityResponse<LocationTracking> response = _ILocationTrackingBA.InsertLocations(_LocationTrackingViewModel.LocationTrackingDTO);
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
    }
}
