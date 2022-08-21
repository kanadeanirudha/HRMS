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
    public class TD_ItemMasterController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ITD_ItemMaster_Web_API_BA _ITD_ItemMaster_Web_API_BA = null;
        public TD_ItemMasterController()
        {
            _ITD_ItemMaster_Web_API_BA = new TD_ItemMaster_Web_API_BA();
        }

        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetItems(ItemMasterViewModel model)
        {
            ItemMasterViewModel _ItemMasterViewModel = new ItemMasterViewModel();
            if (model != null)
            {
                _ItemMasterViewModel.ItemMasterDTO = new ItemMaster();

                _ItemMasterViewModel.ItemMasterDTO.LastSyncDate = model.LastSyncDate;
                _ItemMasterViewModel.ItemMasterDTO.SyncType = model.SyncType;
                _ItemMasterViewModel.ItemMasterDTO.VersionNumber = model.VersionNumber;
                _ItemMasterViewModel.ItemMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<ItemMaster> response = _ITD_ItemMaster_Web_API_BA.getItems(_ItemMasterViewModel.ItemMasterDTO);
                List<ItemMaster> listItemMaster = new List<ItemMaster>();
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
                        listItemMaster = response.CollectionResponse.ToList();
                        foreach (ItemMaster item in listItemMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ItemID", item.ID);
                            Data.Add("ItemName", item.Item);
                            Data.Add("Quantity", item.Quantity);
                            Data.Add("Size", item.Size);
                            Data.Add("Unit", item.Unit);
                            Data.Add("Weight_IN_KG", item.Weight_In_KG);
                            Data.Add("CategoryID", item.CategoryID);
                            Data.Add("CategoryTitle", item.Category);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

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
    }
}
