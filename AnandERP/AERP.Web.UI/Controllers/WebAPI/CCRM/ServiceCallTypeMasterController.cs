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
    public class ServiceCallTypeMasterController : BaseAPIController
    {
        private string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        IServiceCallTypeMaster_Web_API_BA _IServiceCallTypeMaster_Web_API_BA = null;
        public ServiceCallTypeMasterController()
        {
            _IServiceCallTypeMaster_Web_API_BA = new ServiceCallTypeMaster_Web_API_BA();
        }

        #region MIF DETAILS
        [HttpPost]
        [AllowAnonymous]
        [BasicAuthorization]
        public object GetServiceCallTypes(CCRMServiceCallTypesViewModel model)
        {
            CCRMServiceCallTypesViewModel _CCRMServiceCallTypesViewModel = new CCRMServiceCallTypesViewModel();
            if (model != null)
            {
                _CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO = new CCRMServiceCallTypes();

                _CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO.VersionNumber = model.VersionNumber;
                _CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO.SyncType = model.SyncType;
                _CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO.LastSyncDate = model.LastSyncDate;
                _CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<CCRMServiceCallTypes> response = _IServiceCallTypeMaster_Web_API_BA.getServiceCallTypes(_CCRMServiceCallTypesViewModel.CCRMServiceCallTypesDTO);
                List<CCRMServiceCallTypes> listCCRMServiceCallTypesMaster = new List<CCRMServiceCallTypes>();
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
                        listCCRMServiceCallTypesMaster = response.CollectionResponse.ToList();
                        foreach (CCRMServiceCallTypes item in listCCRMServiceCallTypesMaster)
                        {

                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("ID", item.ID);
                            Data.Add("CallTypeCode", item.CallTypeCode);
                            Data.Add("CallTypeName", item.CallTypeName);
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
