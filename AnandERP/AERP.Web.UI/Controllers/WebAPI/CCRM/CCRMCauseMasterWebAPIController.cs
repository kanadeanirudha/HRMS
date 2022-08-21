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
    public class CCRMCauseMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMCauseMaster_Web_API_BA _ICCRMCauseMaster_Web_API_BA = null;
        public CCRMCauseMasterWebAPIController()
        {
            _ICCRMCauseMaster_Web_API_BA = new CCRMCauseMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetCauseLogs(CCRMCauseMasterViewModel model)
        {
            CCRMCauseMasterViewModel _CCRMCauseMasterViewModel = new CCRMCauseMasterViewModel();
            if (model != null)
            {
                _CCRMCauseMasterViewModel.CCRMCauseMasterDTO = new CCRMCauseMaster();

                _CCRMCauseMasterViewModel.CCRMCauseMasterDTO.LastSyncDate = model.LastSyncDate;
                _CCRMCauseMasterViewModel.CCRMCauseMasterDTO.SyncType = model.SyncType;
                _CCRMCauseMasterViewModel.CCRMCauseMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMCauseMasterViewModel.CCRMCauseMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMCauseMaster> response = _ICCRMCauseMaster_Web_API_BA.getCauseOnSearchApi(_CCRMCauseMasterViewModel.CCRMCauseMasterDTO);
                List<CCRMCauseMaster> listCCRMCauseMaster = new List<CCRMCauseMaster>();
                List<object> CauseRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;

                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMCauseMaster = response.CollectionResponse.ToList();
                        foreach (CCRMCauseMaster item in listCCRMCauseMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("CauseID", item.ID);
                            Data.Add("CauseTitle", item.CauseTitle);
                            Data.Add("CauseCode", item.CauseCode);
                            Data.Add("CauseDescription", item.CauseDescription);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            CauseRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == 200 ? listCCRMCauseMaster.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", CauseRecord }
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
