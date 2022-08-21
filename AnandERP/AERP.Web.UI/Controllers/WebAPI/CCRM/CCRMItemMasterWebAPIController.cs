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
    public class CCRMItemMasterWebAPIController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMItemMaster_WebAPI_BA _ICCRMItemMaster_WebAPI_BA = null;
        public CCRMItemMasterWebAPIController()
        {
            _ICCRMItemMaster_WebAPI_BA = new CCRMItemMaster_WebAPI_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetItemOnSearch(GeneralItemMasterViewModel model)
        {
            GeneralItemMasterViewModel _GeneralItemMasterViewModel = new GeneralItemMasterViewModel();
            if (model != null)
            {
                _GeneralItemMasterViewModel.GeneralItemMasterDTO = new GeneralItemMaster();

                _GeneralItemMasterViewModel.GeneralItemMasterDTO.VersionNumber = model.VersionNumber;
                _GeneralItemMasterViewModel.GeneralItemMasterDTO.LastSyncDate = model.LastSyncDate;
                _GeneralItemMasterViewModel.GeneralItemMasterDTO.SyncType = model.SyncType;
                _GeneralItemMasterViewModel.GeneralItemMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<GeneralItemMaster> response = _ICCRMItemMaster_WebAPI_BA.getItemOnSearchApi(_GeneralItemMasterViewModel.GeneralItemMasterDTO);
                List<GeneralItemMaster> listCCRMItemMasterMaster = new List<GeneralItemMaster>();
                List<object> ItemRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;

                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listCCRMItemMasterMaster = response.CollectionResponse.ToList();
                        foreach (GeneralItemMaster item in listCCRMItemMasterMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ID", item.ID);
                            Data.Add("ItemCode", item.ItemCode);
                            Data.Add("ItemDescription", item.ItemDescription);
                            Data.Add("ItemCategoryCode", item.ItemCategoryCode);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);
                            ItemRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == 200 ? ItemRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", ItemRecord }
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
