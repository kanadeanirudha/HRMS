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
    public class TelematicsController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITelematics_WEB_API_BA _ITelematics_WEB_API_BA = null;
        public TelematicsController()
        {
            _ITelematics_WEB_API_BA = new Telematics_WEB_API_BA();
        }
        [HttpPost]
        [AllowAnonymous]
        //[BasicAuthorization]
        public object SensorData(SensorDataViewModel model)
        {
            SensorDataViewModel _SensorDataViewModel = new SensorDataViewModel();
            if (model != null)
            {
                _SensorDataViewModel.SensorDataDTO = new SensorData();
                _SensorDataViewModel.SensorDataDTO.veh_id = model.veh_id;
                _SensorDataViewModel.SensorDataDTO.TS = model.TS;
                _SensorDataViewModel.SensorDataDTO.p1 = model.p1;
                _SensorDataViewModel.SensorDataDTO.p2 = model.p2;
                _SensorDataViewModel.SensorDataDTO.p3 = model.p3;
                _SensorDataViewModel.SensorDataDTO.p4 = model.p4;
                _SensorDataViewModel.SensorDataDTO.p5 = model.p5;
                _SensorDataViewModel.SensorDataDTO.p6 = model.p6;
                _SensorDataViewModel.SensorDataDTO.t1 = model.t1;
                _SensorDataViewModel.SensorDataDTO.t2 = model.t2;
                _SensorDataViewModel.SensorDataDTO.t3 = model.t3;
                _SensorDataViewModel.SensorDataDTO.t4 = model.t4;
                _SensorDataViewModel.SensorDataDTO.t5 = model.t5;
                _SensorDataViewModel.SensorDataDTO.t6 = model.t6;
                _SensorDataViewModel.SensorDataDTO.Eng = model.Eng;
                _SensorDataViewModel.SensorDataDTO.Battery = model.Battery;
                _SensorDataViewModel.SensorDataDTO.Lat = model.Lat;
                _SensorDataViewModel.SensorDataDTO.Lon = model.Lon;
                _SensorDataViewModel.SensorDataDTO.Power = model.Power;
                _SensorDataViewModel.SensorDataDTO.BLE = model.BLE;
                _SensorDataViewModel.SensorDataDTO.X_axis = model.X_axis;
                _SensorDataViewModel.SensorDataDTO.Y_axis = model.Y_axis;
                _SensorDataViewModel.SensorDataDTO.Z_axis = model.Z_axis;
                _SensorDataViewModel.SensorDataDTO.Mem = model.Mem;

                _SensorDataViewModel.SensorDataDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<SensorData> response = _ITelematics_WEB_API_BA.InsertTelematics(_SensorDataViewModel.SensorDataDTO);
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
