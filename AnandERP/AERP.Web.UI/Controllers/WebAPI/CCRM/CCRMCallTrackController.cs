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
    public class CCRMCallTrackController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMCallTrack_Web_API_BA _ICCRMCallTrack_Web_API_BA = null;
        public CCRMCallTrackController()
        {
            _ICCRMCallTrack_Web_API_BA = new CCRMCallTrack_Web_API_BA();
        }
        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object InsertCallArrival(CCRMCallTrackViewModel model)
        {
            CCRMCallTrackViewModel _CCRMCallTrackViewModel = new CCRMCallTrackViewModel();
            if (model != null)
            {
                _CCRMCallTrackViewModel.CCRMCallTrackDTO = new CCRMCallTrack();
                _CCRMCallTrackViewModel.CCRMCallTrackDTO.CallTicketNumber = model.CallTicketNumber;
                _CCRMCallTrackViewModel.CCRMCallTrackDTO.TrackStatus = model.TrackStatus;
                _CCRMCallTrackViewModel.CCRMCallTrackDTO.Latitude = model.Latitude;
                _CCRMCallTrackViewModel.CCRMCallTrackDTO.Longitude = model.Longitude;
                _CCRMCallTrackViewModel.CCRMCallTrackDTO.UserId = model.UserID;
                _CCRMCallTrackViewModel.CCRMCallTrackDTO.VersionNumber = model.VersionNumber;

                _CCRMCallTrackViewModel.CCRMCallTrackDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<CCRMCallTrack> response = _ICCRMCallTrack_Web_API_BA.InsertCallTrack(_CCRMCallTrackViewModel.CCRMCallTrackDTO);
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
