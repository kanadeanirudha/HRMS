using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeShiftMaster : BaseDTO
    {
        public int EmployeeShiftMasterID
        {
            get;
            set;
        }                            // EmployeeShiftMaster ID
        public string EmployeeShiftDescription
        {
            get;
            set;
        }      
        public string EmployeeShiftCode
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string CentreName { get; set; }
        public bool IsShiftLocked
        {
            get;
            set;
        }
        public string ShiftLockedDate
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public int ShiftAllocationCentreID { get; set; }
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


        //EmployeeShiftMasterDetails DTO 

        public int EmployeeShiftMasterDetailsID
        {
            get;
            set;
        }                    //EmployeeShiftMasterDetails ID
        //public int EmployeeShiftMasterID
        //{
        //    get;
        //    set;
        //}
        public int GeneralWeekDaysID
        {
            get;
            set;
        }
        public string WeekDay
        {
            get;
            set;
        }
        public string WeeklyOffStatus
        {
            get;
            set;
        }
        public TimeSpan ShiftTimeFrom
        {
            get;
            set;
        }
        public TimeSpan ShiftTimeUpto
        {
            get;
            set;
        }
        public Int16 ShiftTimeMargin
        {
            get;
            set;
        }
        public Int16 ShiftEndBuffer
        {
            get;
            set;
        }
        public TimeSpan ConsiderLateMarkUpto
        {
            get;
            set;
        }
        public TimeSpan SecondHalfFrom
        {
            get;
            set;
        }
        public TimeSpan FirstHalfUpto
        {
            get;
            set;
        }
        public TimeSpan LunchTimeFrom
        {
            get;
            set;
        }
        public TimeSpan LunchTimeUpto
        {
            get;
            set;
        }
        public string EmployeeShiftMasterDetailsCentreCode
        {
            get;
            set;
        }
        public string WeeklyOffType
        {
            get;
            set;
        }

        public string errorMessage { get; set; }
    }
}
