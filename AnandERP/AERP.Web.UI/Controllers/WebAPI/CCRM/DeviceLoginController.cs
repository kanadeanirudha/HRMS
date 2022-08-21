using AERP.Base.DTO;
using AERP.Business.BusinessAction;
using AERP.DTO;
using AERP.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace AERP.Web.UI
{
    public class DeviceLoginController : BaseAPIController
    {
        private static string _connectioString = Convert.ToString(ConfigurationManager.ConnectionStrings["Main.ConnectionString"]);
        static ILoginBA _ILoginBA = null;
        public DeviceLoginController()
        {
            _ILoginBA = new LoginBA();
        }

        static DeviceLoginController()
        {
            _ILoginBA = new LoginBA();
        }

        [HttpPost]
        [AllowAnonymous]
        public object Login(UserMasterViewModel model)
        {
            UserMasterViewModel userMasterViewModel = new UserMasterViewModel();
            if (ModelState.IsValid && model != null && !string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Password))
            {
                userMasterViewModel.UserMasterDTO = new UserMaster();
                userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                userMasterViewModel.UserMasterDTO.MobileNumber = model.MobileNumber;
                userMasterViewModel.UserMasterDTO.Password = model.Password;
                userMasterViewModel.UserMasterDTO.IP = model.IP;
                userMasterViewModel.UserMasterDTO.VersionNumber = model.VersionNumber;
                userMasterViewModel.UserMasterDTO.MachinName = model.MachinName;
                userMasterViewModel.UserMasterDTO.IMEI = model.IMEI;
                userMasterViewModel.UserMasterDTO.DeviceToken = model.DeviceToken;
                userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<UserMaster> response = _ILoginBA.UserLoginApi(userMasterViewModel.UserMasterDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null)
                {
                    if (response.Entity.exists.ToUpper() == "EXIST")
                    {
                        Data.Add("EmailID", response.Entity.EmailID);
                        Data.Add("UserName", response.Entity.UserName);
                        Data.Add("MobileNumber", response.Entity.MobileNumber);
                        Data.Add("EmployeeDesignation", response.Entity.EmployeeDesignation);
                        Data.Add("EmployeeDesignationID", response.Entity.EmployeeDesignationID);
                        Data.Add("ServiceEnginner", response.Entity.IsServiceEnginner);
                        Data.Add("ServiceManager", response.Entity.IsServiceManager);
                        Data.Add("CollectionExecutive", response.Entity.IsCollectionExecutive);
                        Data.Add("EmployeeMasterID", response.Entity.EmployeeMasterID);
                        Data.Add("UserID", response.Entity.UserID);
                        Data.Add("CentreCode", response.Entity.CentreCode);
                        Data.Add("BioMatrixID", response.Entity.BiomatrixID);
                        Data.Add("IsAllowPunch", response.Entity.IsAllowPunchFromOutSide);

                    }

                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"URL",response.Entity.URL },
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

        public static Boolean IsValidate(UserMasterViewModel model)
        {
            UserMasterViewModel userMasterViewModel = new UserMasterViewModel();
            if (model != null && !string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Password))
            {
                userMasterViewModel.UserMasterDTO = new UserMaster();
                userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                userMasterViewModel.UserMasterDTO.Password = model.Password;
              
                userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<UserMaster> response = _ILoginBA.IsValidate(userMasterViewModel.UserMasterDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null)
                {
                    if (response.Entity.exists.ToUpper() == "EXIST")
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }

        [HttpPost]
        [AllowAnonymous]
        public object EngineerList(UserMasterViewModel model)
        {
            UserMasterViewModel userMasterViewModel = new UserMasterViewModel();
            if (model != null )
            {
                userMasterViewModel.UserMasterDTO = new UserMaster();
                userMasterViewModel.UserMasterDTO.LastSyncDate = model.LastSyncDate;
                userMasterViewModel.UserMasterDTO.SyncType = model.SyncType;
                userMasterViewModel.UserMasterDTO.VersionNumber = model.VersionNumber;

                userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                IBaseEntityCollectionResponse<UserMaster> response = _ILoginBA.EngineerList(userMasterViewModel.UserMasterDTO);

                List<UserMaster> listUserMaster = new List<UserMaster>();
                List<object> ActionRecord = new List<object>();
                int statusCode;
                string ErrorMessage = "";
                if (response != null)
                {
                    List<IMessageDTO> MessageList = new List<IMessageDTO>(response.Message);
                    statusCode = MessageList[0].ErrorID;
                    ErrorMessage = MessageList[0].ErrorMessage;
                    if (response.CollectionResponse != null && response.CollectionResponse.Count > 0)
                    {
                        listUserMaster = response.CollectionResponse.ToList();
                        foreach (UserMaster item in listUserMaster)
                        {
                            Dictionary<String, object> Data = new Dictionary<string, object>();
                            Data.Add("UserID", item.UserID);
                            Data.Add("EmployeeMasterID", item.EmployeeMasterID);
                            Data.Add("EmployeeDesignation", item.EmployeeDesignation);
                            Data.Add("Name", item.UserName);
                            Data.Add("EmailID", item.EmailID);
                            Data.Add("EmployeeCode", item.EmployeeCode);
                            Data.Add("MobileNumber", item.MobileNumber);
                            Data.Add("LastSyncDate", item.LastSyncDate);
                            Data.Add("Entity", item.Entity);

                            ActionRecord.Add(Data);
                        }
                    }
                    if (ErrorMessage == "The network path was not found")
                    {
                        statusCode = -214;
                    }
                    else
                    {
                        statusCode = statusCode == (int)ErrorEnum.Success ? ActionRecord.Count > 0 ? (int)ErrorEnum.Success : (int)ErrorEnum.NotExist : statusCode == 0 ? 417 : statusCode;
                    }
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                        {
                             {"StatusCode",statusCode },
                             {"Message", CheckError(statusCode)},
                             {"Data", ActionRecord }
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

        [HttpPost]
        [AllowAnonymous]
        public object LMSLogin(UserMasterViewModel model)
        {
            UserMasterViewModel userMasterViewModel = new UserMasterViewModel();
            if (model != null && !string.IsNullOrEmpty(model.EmailID) && !string.IsNullOrEmpty(model.Password))
            {
                userMasterViewModel.UserMasterDTO = new UserMaster();
                userMasterViewModel.UserMasterDTO.EmailID = model.EmailID;
                userMasterViewModel.UserMasterDTO.Password = model.Password;
                userMasterViewModel.UserMasterDTO.IP = model.IP;
                userMasterViewModel.UserMasterDTO.VersionNumber = model.VersionNumber;
                userMasterViewModel.UserMasterDTO.MachinName = model.MachinName;
                userMasterViewModel.UserMasterDTO.DeviceToken = model.DeviceToken;
                userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<UserMaster> response = _ILoginBA.SelectByEmailIDPassword(userMasterViewModel.UserMasterDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null)
                {
                   
                        Data.Add("EmailID", response.Entity.EmailID);
                        Data.Add("FirstName", response.Entity.FirstName);
                        Data.Add("MiddleName", response.Entity.MiddleName);
                        Data.Add("LastName", response.Entity.LastName);
                        Data.Add("UserTypeID", response.Entity.UserTypeID);
                        Data.Add("UserType", response.Entity.UserType);
                        Data.Add("DateOfBirth", response.Entity.DateOfBirth);
                        Data.Add("Gender", response.Entity.Gender);
                        Data.Add("PersonID", response.Entity.PersonID);
                        Data.Add("UserID", response.Entity.ID);
                    

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

        [HttpPost]
        [AllowAnonymous]
        public object ChangePassword(UserMasterViewModel model)
        {
            UserMasterViewModel userMasterViewModel = new UserMasterViewModel();
            if (ModelState.IsValid && model != null && !string.IsNullOrEmpty(model.OldPassword) && !string.IsNullOrEmpty(model.Password))
            {
                userMasterViewModel.UserMasterDTO = new UserMaster();
                userMasterViewModel.UserMasterDTO.Password = model.Password;
                userMasterViewModel.UserMasterDTO.OldPassword = model.OldPassword;
                userMasterViewModel.UserMasterDTO.ID = model.ID;
                userMasterViewModel.UserMasterDTO.VersionNumber = model.VersionNumber;
                userMasterViewModel.UserMasterDTO.ModifiedBy = model.ModifiedBy;

                userMasterViewModel.UserMasterDTO.ConnectionString = _connectioString;
                IBaseEntityResponse<UserMaster> response = _ILoginBA.ChangePassword(userMasterViewModel.UserMasterDTO);
                Dictionary<String, object> Data = new Dictionary<string, object>();
                if (response != null)
                {
                    
                    Dictionary<string, object> _dict = new Dictionary<string, object>
                    {
                        {"StatusCode",response.Entity.ErrorCode },
                        {"URL",response.Entity.URL },
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