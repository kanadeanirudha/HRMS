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
    public class CCRMSymptomMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMSymptomMaster_WebAPI_BA _ICCRMSymptomMaster_WebAPI_BA = null;
        public CCRMSymptomMasterWebAPIController()
        {
            _ICCRMSymptomMaster_WebAPI_BA = new CCRMSymptomMaster_WebAPI_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetSymptoms(CCRMSymptomMasterViewModel model)
        {
            CCRMSymptomMasterViewModel _CCRMSymptomMasterViewModel = new CCRMSymptomMasterViewModel();
            if (model != null)
            {
                _CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO = new CCRMSymptomMaster();

                _CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO.LastSyncDate = model.LastSyncDate;
                _CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO.SyncType = model.SyncType;
                _CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO.VersionNumber = model.VersionNumber;
                _CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMSymptomMaster> response = _ICCRMSymptomMaster_WebAPI_BA.getSymptom_SelectAll(_CCRMSymptomMasterViewModel.CCRMSymptomMasterDTO);
                List<CCRMSymptomMaster> listCCRMSymptomMaster = new List<CCRMSymptomMaster>();
                List<object> SymptomsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;

                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMSymptomMaster = response.CollectionResponse.ToList();
                        foreach (CCRMSymptomMaster item in listCCRMSymptomMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("SymptomTypeID", item.CCRMSymptomMasterID);
                            Data.Add("SymptomTitle", item.SymptomTitle);
                            Data.Add("SymptomCode", item.SymptomCode);
                            Data.Add("SymptomDescription", item.SymptomDescription);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            SymptomsRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == 200 ? listCCRMSymptomMaster.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", SymptomsRecord }
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
