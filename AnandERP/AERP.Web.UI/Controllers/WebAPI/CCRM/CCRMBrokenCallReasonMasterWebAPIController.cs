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
    public class CCRMBrokenCallReasonMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMBrokenCallReasonMaster_Web_API_BA _ICCRMBrokenCallReasonMaster_Web_API_BA = null;
        public CCRMBrokenCallReasonMasterWebAPIController()
        {
            _ICCRMBrokenCallReasonMaster_Web_API_BA = new CCRMBrokenCallReasonMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetBrokenCallReasons(CCRMBrokenCallReasonMasterViewModel model)
        {
            CCRMBrokenCallReasonMasterViewModel _CCRMBrokenCallReasonMasterViewModel = new CCRMBrokenCallReasonMasterViewModel();
            if (model != null)
            {
                _CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO = new CCRMBrokenCallReasonMaster();

                _CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO.SyncType = model.SyncType;
                _CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO.LastSyncDate = model.LastSyncDate; _CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMBrokenCallReasonMaster> response = _ICCRMBrokenCallReasonMaster_Web_API_BA.getBrokenCallReasonOnSearchApi(_CCRMBrokenCallReasonMasterViewModel.CCRMBrokenCallReasonMasterDTO);
                List<CCRMBrokenCallReasonMaster> listCCRMBrokenCallReasonMaster = new List<CCRMBrokenCallReasonMaster>();
                List<object> brokenCallReasonRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMBrokenCallReasonMaster = response.CollectionResponse.ToList();
                        foreach (CCRMBrokenCallReasonMaster item in listCCRMBrokenCallReasonMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ReasonID", item.ID);
                            Data.Add("ReasonCode", item.ReasonCode);
                            Data.Add("ReasonDescription", item.ReasonDescription);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            brokenCallReasonRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? brokenCallReasonRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", brokenCallReasonRecord }
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
