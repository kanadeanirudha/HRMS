using AERP.DTO;
using System;

namespace AERP.ViewModel
{
    public interface IUserMasterViewModel
    {

        int ID
        {
            get;
            set;
        }

        int UserTypeID
        {
            get;
            set;
        }

        string EmailID
        {
            get;
            set;
        }
       

        string Password
        {
            get;
            set;
        }

        int PersonID
        {
            get;
            set;
        }

        string FirstName
        {
            get;
            set;
        }

        string MiddleName
        {
            get;
            set;
        }

        string LastName
        {
            get;
            set;
        }

        string Gender
        {
            get;
            set;
        }

        DateTime DateOfBirth
        {
            get;
            set;
        }

        bool IsActive
        {
            get;
            set;
        }

        bool IsDeleted
        {
            get;
            set;
        }

        int CreatedBy
        {
            get;
            set;
        }

        DateTime CreatedDate
        {
            get;
            set;
        }

        int? ModifiedBy
        {
            get;
            set;
        }

        DateTime? ModifiedDate
        {
            get;
            set;
        }

        int? DeletedBy
        {
            get;
            set;
        }

        DateTime? DeletedDate
        {
            get;
            set;
        }
        string Longitude
        {
            get;
            set;
        }
        string Latitude
        {
            get;
            set;
        }
        bool DistanceFlag
        {
            get;
            set;
        }
        bool AttendanceFlag
        {
            get;
            set;
        }
        bool LoginFlag
        {
            get;
            set;
        }
        Int16 AttendanceStatus
        {
            get;
            set;
        }
        bool MarkAttendanceCheckInTime
        {
            get;
            set;
        }
        bool MarkAttendanceCheckOutTime
        {
            get;
            set;
        }
        int Status
        {
            get;
            set;
        }
    }
}
