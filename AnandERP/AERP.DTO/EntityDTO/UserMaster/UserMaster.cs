using AERP.Base.DTO;
using System;

namespace AERP.DTO
{
    public class UserMaster : BaseDTO
    {
        public int ID
        {
            get;
            set;
        }
        public bool IsAllowPunchFromOutSide
        {
            get;
            set;
        }
           public int BiomatrixID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public int UserTypeID
        {
            get;
            set;
        }
        public string EmployeeCode
        {
            get;
            set;
        }
        public string OldPassword
        {
            get;
            set;
        }
    public string URL
        {
            get;
            set;
        }

        public string IMEI
        {
            get;
            set;
        }

        public string CentreCode
        {
            get;
            set;
        }
        public string EmailID
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }

        public int PersonID
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string MiddleName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string Gender
        {
            get;
            set;
        }

        public DateTime DateOfBirth
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public bool IsMailSentForLoginReset
        {
            get;
            set;
        }    
        public bool IsDeleted
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int? ModifiedBy
        {
            get;
            set;
        }

        public DateTime? ModifiedDate
        {
            get;
            set;
        }

        public int? DeletedBy
        {
            get;
            set;
        }

        public DateTime? DeletedDate
        {
            get;
            set;
        }

        public string MachinName
        {
            get;
            set;
        }

        public string IP
        {
            get;
            set;
        }

        public string ErrorMessage
        {
            get;
            set;
        }

        public string VersionNumber
        {
            get;
            set;
        }

        public int ErrorCode
        {
            get;
            set;
        }


        public int Status
        {
            get;
            set;
        }

        public char UserType
        {
            get;
            set;
        }
        public string UserDescription
        {
            get;
            set;
        }

        public string LogoutType
        {
            get;
            set;
        }
        public string exists
        {
            get;
            set;
        }
        public string Longitude
        {
            get;
            set;
        }
        public string Latitude
        {
            get;
            set;
        }
        public bool DistanceFlag
        {
            get;
            set;
        }
        public bool AttendanceFlag
        {
            get;
            set;
        }
        public bool LoginFlag
        {
            get;
            set;
        }
        public Int16 AttendanceStatus
        {
            get;
            set;
        }
        public bool MarkAttendanceCheckInTime
        {
            get;
            set;
        }
        public bool MarkAttendanceCheckOutTime
        {
            get;
            set;
        }

        public string UserCode { get; set; }
        public string UserName { get; set; }
        public bool IsPosted { get; set; }
       
        public string SystemStatus { get; set; }
        public string UserStatus { get; set; }
        public string LastActivity { get; set; }
        public byte[] ProfilePhoto
        {
            get;
            set;
        }
        public string ProfilePhotoSize
        {
            get;
            set;
        }
        public string DeviceToken
        {
            get;
            set;
        }
        public int GeneralPOSMasterID
        {
            get;
            set;
        }
        public int GeneralCounterMasterID
        {
            get;
            set;
        }
        public int GeneralUnitsID
        {
            get;
            set;
        }
        public string LastModuleCode
        {
            get;set;
        }
        public string MobileNumber
        {
            get;
            set;
        }
        public string EmployeeDesignation
        {
            get;
            set;
        }
        public int EmployeeDesignationID
        {
            get;
            set;
        }
        public bool IsServiceEnginner
        {
            get;
            set;
        }
        public bool IsServiceManager
        {
            get;
            set;
        }
        public bool IsCollectionExecutive
        {
            get;
            set;
        }
        public int EmployeeMasterID
        {
            get;
            set;
        }
        public Nullable<System.DateTime> LastSyncDate { get; set; }
        public string SyncType
        {
            get; set;
        }
        public string Entity
        {
            get; set;
        }
    }
}
