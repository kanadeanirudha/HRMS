using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.DTO;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace AERP.Web.UI
{
    public class CCRMCallAllotmentWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMCallAllotment_WebAPI_BA _ICCRMCallAllotment_WebAPI_BA = null;
        ICCRMComplaintLoggingMasterBA _CCRMComplaintLoggingMasterBA = null;

        public CCRMCallAllotmentWebAPIController()
        {
            _ICCRMCallAllotment_WebAPI_BA = new CCRMCallAllotment_Web_API_BA();
            _CCRMComplaintLoggingMasterBA = new CCRMComplaintLoggingMasterBA();
        }
        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object InsertCallAllotment(CCRMComplaintLoggingMasterViewModel model)
        {
            CCRMComplaintLoggingMasterViewModel _CCRMComplaintLoggingMasterViewModel = new CCRMComplaintLoggingMasterViewModel();
            if (model != null)
            {
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO = new CCRMComplaintLoggingMaster();
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.CallTktNo = model.CallTktNo;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.CreatedBy = model.CreatedBy;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<CCRMComplaintLoggingMaster> response = _ICCRMCallAllotment_WebAPI_BA.InsertCallAllotment(_CCRMComplaintLoggingMasterViewModel.CCRMComplaintLoggingMasterDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null && response.Entity != null)
                {
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"Message", CheckError(response.Entity.ErrorCode)},
                        {"Data", Data }
                    };

                    if (response.Entity.ErrorCode == 200)
                    {
                        List<CCRMComplaintLoggingMaster> list = getDeviceToken();
                        foreach (CCRMComplaintLoggingMaster ComplaintMaster in list)
                        {
                             if (ComplaintMaster.DeviceToken != string.Empty)
                             {
                                if (model.CreatedBy == ComplaintMaster.EngineerID)
                                {
                                   // RunningBackgroundThread(ComplaintMaster.DeviceToken);
                                }
                            }
                        }
                    }
                    return _dict;
                }
            }
            return new Dictionary<string, object>
                    {
                        {"StatusCode", 417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
        }

        void SendNotification(string DeviceToken)
        {
            SendGCMNotification(DeviceToken);
        }

        void RunningBackgroundThread(string DeviceToken)
        {
            Thread background = new Thread(() => SendNotification(DeviceToken));
            background.IsBackground = true;
            background.Start();
        }

        private List<CCRMComplaintLoggingMaster> getDeviceToken()
        {
            CCRMComplaintLoggingMasterSearchRequest searchRequest = new CCRMComplaintLoggingMasterSearchRequest();
            searchRequest.ConnectionString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);

            List<CCRMComplaintLoggingMaster> listCCRMComplaintLoggingMaster = new List<CCRMComplaintLoggingMaster>();
            IBaseEntityCollectionResponse<CCRMComplaintLoggingMaster> baseEntityCollectionResponse = _CCRMComplaintLoggingMasterBA.GetDeviceToken(searchRequest);
            if (baseEntityCollectionResponse != null)
            {
                if (baseEntityCollectionResponse.CollectionResponse != null && baseEntityCollectionResponse.CollectionResponse.Count > 0)
                {
                    listCCRMComplaintLoggingMaster = baseEntityCollectionResponse.CollectionResponse.ToList();
                }
            }
            return listCCRMComplaintLoggingMaster;
        }
    }
}