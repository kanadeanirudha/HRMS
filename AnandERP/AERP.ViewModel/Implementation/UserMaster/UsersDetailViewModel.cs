using AERP.Common;
using AERP.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace AERP.ViewModel
{
    public class UserMasterViewModel : IUserMasterViewModel
    {
        public UserMasterViewModel()
        {
            UserMasterDTO = new UserMaster();
        }

        public UserMaster UserMasterDTO
        {
            get;
            set;
        }

        public int ID
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.ID > 0) ? UserMasterDTO.ID : new int();
            }
            set
            {
                UserMasterDTO.ID = value;
            }
        }

        [Display(Name = "DisplayName_IsDeleted")]
        public bool IsDeleted
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.IsDeleted : false;
            }
            set
            {
                UserMasterDTO.IsDeleted = value;
            }
        }

        [Display(Name = "DisplayName_CreatedBy")]
        public int CreatedBy
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.CreatedBy > 0) ? UserMasterDTO.CreatedBy : new int();
            }
            set
            {
                UserMasterDTO.CreatedBy = value;
            }
        }

        [Display(Name = "DisplayName_CreatedDate")]
        public DateTime CreatedDate
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.CreatedDate : DateTime.Now;
            }
            set
            {
                UserMasterDTO.CreatedDate = value;
            }
        }

        [Display(Name = "DisplayName_ModifiedBy")]
        public int? ModifiedBy
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.ModifiedBy.HasValue) ? UserMasterDTO.ModifiedBy : new int();
            }
            set
            {
                UserMasterDTO.ModifiedBy = value;
            }
        }

        [Display(Name = "DisplayName_ModifiedDate")]
        public DateTime? ModifiedDate
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.ModifiedDate.HasValue) ? UserMasterDTO.ModifiedDate : DateTime.Now;
            }
            set
            {
                UserMasterDTO.ModifiedDate = value;
            }
        }

        [Display(Name = "DisplayName_DeletedBy")]
        public int? DeletedBy
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.DeletedBy.HasValue) ? UserMasterDTO.DeletedBy : new int();
            }
            set
            {
                UserMasterDTO.DeletedBy = value;
            }
        }

        [Display(Name = "DisplayName_DeletedDate")]
        public DateTime? DeletedDate
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.DeletedDate.HasValue) ? UserMasterDTO.DeletedDate : DateTime.Now;
            }
            set
            {
                UserMasterDTO.DeletedDate = value;
            }
        }

        //[Display(Name = "DisplayName_EmailID", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_EmailIDForAccountRequired")]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@[a-z0-9-]+(\\.[a-z0-9-]+)*(\\.[a-z]{2,15})$", ErrorMessage = "Please enter your email address in the format someone@example.com.")]
       // [Required(ErrorMessage = "Please enter the E-mail ID for your account")]       
        public string EmailID
        {
            get
            {
                return UserMasterDTO.EmailID;
            }
            set
            {
                UserMasterDTO.EmailID = value;
            }
        }

        [Display(Name = "DisplayName_Password", ResourceType = typeof(AERP.Common.Resources))]
        [Required(ErrorMessageResourceType = typeof(AERP.Common.Resources), ErrorMessageResourceName = "ValidationMessage_PasswordForAccountRequired")]
       // [Display(Description = "Password")
       // [Required(ErrorMessage = "Please enter the password for your account")]       
        public string Password
        {
            get
            {
                return UserMasterDTO.Password;
            }
            set
            {
                UserMasterDTO.Password = value;
            }
        }

        public string OldPassword
        {
            get
            {
                return UserMasterDTO.OldPassword;
            }
            set
            {
                UserMasterDTO.OldPassword = value;
            }
        }

        public string FirstName
        {
            get
            {
                return UserMasterDTO.FirstName;
            }
            set
            {
                UserMasterDTO.FirstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return UserMasterDTO.MiddleName;
            }
            set
            {
                UserMasterDTO.MiddleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return UserMasterDTO.LastName;
            }
            set
            {
                UserMasterDTO.LastName = value;
            }
        }

        public string Gender
        {
            get
            {
                return UserMasterDTO.Gender;
            }
            set
            {
                UserMasterDTO.Gender = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return UserMasterDTO.DateOfBirth;
            }
            set
            {
                UserMasterDTO.DateOfBirth = value;
            }
        }

        [Display(Description = "Remember Me")]
        public bool RememberMe
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public int UserTypeID
        {
            get
            {
                return UserMasterDTO.UserTypeID;
            }
            set
            {
                UserMasterDTO.UserTypeID = value;
            }
        }

        public int PersonID
        {
            get
            {
                return UserMasterDTO.PersonID;
            }
            set
            {
                UserMasterDTO.PersonID = value;
            }
        }

        public string MachinName
        {
            get
            {
                return UserMasterDTO.MachinName;
            }
            set
            {
                UserMasterDTO.MachinName = value;
            }
        }

        public string IP
        {
            get
            {
                return UserMasterDTO.IP;
            }
            set
            {
                UserMasterDTO.IP = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return UserMasterDTO.ErrorMessage;
            }
            set
            {
                UserMasterDTO.ErrorMessage = value;
            }
        }

        public char UserType
        {
            get
            {
                return UserMasterDTO.UserType;
            }
            set
            {
                UserMasterDTO.UserType = value;
            }
        }
        public string LogoutType
        {
            get
            {
                return UserMasterDTO.LogoutType;
            }
            set
            {
                UserMasterDTO.LogoutType = value;
            }
        }
        public string Latitude
        {
            get
            {
                return UserMasterDTO.Latitude;
            }
            set
            {
                UserMasterDTO.Latitude = value;
            }
        }
        public string Longitude
        {
            get
            {
                return UserMasterDTO.Longitude;
            }
            set
            {
                UserMasterDTO.Longitude = value;
            }
        }

        public string IMEI
        {
            get
            {
                return (UserMasterDTO.IMEI != null) ? UserMasterDTO.IMEI : string.Empty; ;
            }
            set
            {
                UserMasterDTO.IMEI = value;
            }
        }

        public bool DistanceFlag
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.DistanceFlag : false;
            }
            set
            {
                UserMasterDTO.DistanceFlag = value;
            }
        }

        public bool AttendanceFlag
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.AttendanceFlag : false;
            }
            set
            {
                UserMasterDTO.AttendanceFlag = value;
            }
        }

        public bool LoginFlag
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.LoginFlag : false;
            }
            set
            {
                UserMasterDTO.LoginFlag = value;
            }
        }
        public Int16 AttendanceStatus
        {
            get
            {
                return UserMasterDTO.AttendanceStatus;
            }
            set
            {
                UserMasterDTO.AttendanceStatus = value;
            }
        }
        public bool MarkAttendanceCheckInTime
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.MarkAttendanceCheckInTime : false;
            }
            set
            {
                UserMasterDTO.MarkAttendanceCheckInTime = value;
            }
        }
        public bool MarkAttendanceCheckOutTime
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.MarkAttendanceCheckOutTime : false;
            }
            set
            {
                UserMasterDTO.MarkAttendanceCheckOutTime = value;
            }
        }
        public int Status
        {
            get
            {
                return UserMasterDTO.Status;
            }
            set
            {
                UserMasterDTO.Status = value;
            }
        }
        public bool IsPosted
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.IsPosted : false;
            }
            set
            {
                UserMasterDTO.IsPosted = value;
            }
        }

        public string VersionNumber
        {
            get
            {
                return UserMasterDTO.VersionNumber;
            }
            set
            {
                UserMasterDTO.VersionNumber = value;
            }
        }

        public string DeviceToken
        {
            get
            {
                return UserMasterDTO.DeviceToken;
            }
            set
            {
                UserMasterDTO.DeviceToken = value;
            }
        }
        public int GeneralCounterMasterID
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.GeneralCounterMasterID : new Int32();
            }
            set
            {
                UserMasterDTO.GeneralCounterMasterID = value;
            }
        }
        public int GeneralPOSMasterID
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.GeneralPOSMasterID : new Int32();
            }
            set
            {
                UserMasterDTO.GeneralPOSMasterID = value;
            }
        }
        public string MobileNumber
        {
            get
            {
                return (UserMasterDTO.MobileNumber != null) ? UserMasterDTO.MobileNumber :  string.Empty;
            }
            set
            {
                UserMasterDTO.MobileNumber = value;
            }
        }

        public string EmployeeDesignation
        {
            get
            {
                return (UserMasterDTO.EmployeeDesignation != null) ? UserMasterDTO.EmployeeDesignation : string.Empty;
            }
            set
            {
                MobileNumber = value;
            }
        }

        public int EmployeeDesignationID
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.EmployeeDesignationID : new Int32();
            }
            set
            {
                UserMasterDTO.EmployeeDesignationID = value;
            }
        }
        public bool IsServiceEnginner
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.IsServiceEnginner : false;
            }
            set
            {
                UserMasterDTO.IsServiceEnginner = value;
            }
        }
        public bool IsServiceManager
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.IsServiceManager : false;
            }
            set
            {
                UserMasterDTO.IsServiceManager = value;
            }
        }
        public bool IsCollectionExecutive
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.IsCollectionExecutive : false;
            }
            set
            {
                UserMasterDTO.IsCollectionExecutive = value;
            }
        }
        public int EmployeeMasterID
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.EmployeeMasterID : new Int32();
            }
            set
            {
                UserMasterDTO.EmployeeMasterID = value;
            }
        }

        public DateTime? LastSyncDate
        {
            get
            {
                return (UserMasterDTO != null && UserMasterDTO.LastSyncDate.HasValue) ? UserMasterDTO.LastSyncDate : null;
            }
            set
            {
                UserMasterDTO.LastSyncDate = value;
            }
        }
        public string SyncType
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.SyncType : string.Empty;
            }
            set
            {
                UserMasterDTO.SyncType = value;
            }
        }
        public string Entity
        {
            get
            {
                return (UserMasterDTO != null) ? UserMasterDTO.Entity : string.Empty;
            }
            set
            {
                UserMasterDTO.Entity = value;
            }
        }
    }
}
