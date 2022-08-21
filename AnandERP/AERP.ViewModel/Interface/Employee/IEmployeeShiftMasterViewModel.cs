using AERP.DTO;
using System;
using System.Collections.Generic;

namespace AERP.ViewModel
{
    public interface IEmployeeShiftMasterViewModel
    {
        EmployeeShiftMaster EmployeeShiftMasterDTO
        {
            get;
            set;
        }
         int EmployeeShiftMasterID
        {
            get;
            set;
        }                                               // EmployeeShiftMaster ID
         string EmployeeShiftDescription
        {
            get;
            set;
        }
         string EmployeeShiftCode
        {
            get;
            set;
        }
         string CentreCode
        {
            get;
            set;
        }
         string CentreName
         {
             get;
             set;
         }
         bool IsShiftLocked
        {
            get;
            set;
        }
         string ShiftLockedDate
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
        string errorMessage { get; set; }
        List<AdminRoleApplicableDetails> ListGetAdminRoleApplicableCentre
        {
            get;
            set;
        }
       

        //EmployeeShiftMasterDetails ViewModelInterface properties

         int EmployeeShiftMasterDetailsID
        {
            get;
            set;
        }                                              //EmployeeShiftMasterDetails ID
        // int EmployeeShiftMasterID
        //{
        //    get;
        //    set;
        //}
         int GeneralWeekDaysID
        {
            get;
            set;
        }
         string WeekDay
         {
             get;
             set;
         }
         string WeeklyOffStatus
        {
            get;
            set;
        }
         TimeSpan ShiftTimeFrom
        {
            get;
            set;
        }
         TimeSpan ShiftTimeUpto
        {
            get;
            set;
        }
         Int16 ShiftTimeMargin
        {
            get;
            set;
        }
         Int16 ShiftEndBuffer
        {
            get;
            set;
        }
         TimeSpan ConsiderLateMarkUpto
        {
            get;
            set;
        }
         TimeSpan SecondHalfFrom
        {
            get;
            set;
        }
         TimeSpan FirstHalfUpto
        {
            get;
            set;
        }
         TimeSpan LunchTimeFrom
        {
            get;
            set;
        }
         TimeSpan LunchTimeUpto
        {
            get;
            set;
        }
         string EmployeeShiftMasterDetailsCentreCode
        {
            get;
            set;
        }
         string WeeklyOffType
        {
            get;
            set;
        }

    }
}
