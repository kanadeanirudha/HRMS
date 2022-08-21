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

namespace AERP.Web.UI.Controllers.WebAPI.CCRM
{
    public class CCRMMIFMasterController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        ICCRMMIFMaster_Web_API_BA _ICCRMMIFMaster_Web_API_BA = null;
        public CCRMMIFMasterController()
        {
            _ICCRMMIFMaster_Web_API_BA = new CCRMMIFMaster_Web_API_BA();
        }

        #region MIF DETAILS
        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetMIF(MIFMasterViewModel model)
        {
            MIFMasterViewModel _MIFMasterViewModel = new MIFMasterViewModel();
            if (model != null)
            {
                _MIFMasterViewModel.MIFMasterDTO = new MIFMaster();

                _MIFMasterViewModel.MIFMasterDTO.VersionNumber = model.VersionNumber;
                _MIFMasterViewModel.MIFMasterDTO.SyncType = model.SyncType;
                _MIFMasterViewModel.MIFMasterDTO.LastSyncDate = model.LastSyncDate;
                _MIFMasterViewModel.MIFMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<MIFMaster> response = _ICCRMMIFMaster_Web_API_BA.getMIFMaster(_MIFMasterViewModel.MIFMasterDTO);
                List<MIFMaster> listMIFMaster = new List<MIFMaster>();
                List<object> LogsRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";

                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listMIFMaster = response.CollectionResponse.ToList();
                        foreach (MIFMaster item in listMIFMaster)
                        {

                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("MIFNumber", item.MIFNumber);
                            Data.Add("SerialNumber", item.SerialNumber);
                            Data.Add("CustomerName", item.CustomerName);
                            Data.Add("InstallationAddress", item.InstallationAddress);
                            Data.Add("ContractType", item.ContractType);
                            Data.Add("ContractNumber", item.ContractNumber);
                            Data.Add("KeyOperator", item.KeyOperator);
                            Data.Add("ModelNumber", item.ModelNumber);
                            Data.Add("EngineerName", item.EngineerName);
                            Data.Add("PhoneNumber", item.PhoneNumber);
                            Data.Add("MobileNumber", item.MobileNumber);
                            Data.Add("EngineerContactNumber", item.EngineerContactNumber);
                            Data.Add("ID", item.ID);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            LogsRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? LogsRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", LogsRecord }
                        };
                    return _dict;
                }
            }
            return new Dictionary<string, object>
                    {
                        {"StatusCode",417},//417 Expectation Failed
                        {"Message", CheckError(417)}
                    };
        }
        #endregion
    }
}
