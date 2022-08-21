using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeShiftMasterSearchRequest : Request
    {
        public int EmployeeShiftMasterID                                                 // EmployeeShiftMaster ID
        {
            get;
            set;
        }                               
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
        public string IsShiftLocked
        {
            get;
            set;
        }
        public DateTime ShiftLockedDate
        {
            get;
            set;
        }
        public bool IsActive
        {
            get;
            set;
        }
        public string SortOrder
        {
            get;
            set;
        }
        public string SortBy
        {
            get;
            set;
        }
        public int StartRow
        {
            get;
            set;
        }
        public int RowLength
        {
            get;
            set;
        }
        public int EndRow
        {
            get;
            set;
        }

        public string SearchBy { get; set; }
        public string SortDirection { get; set; }


        //EmployeeShiftMasterDetails DTO 

        public int EmployeeShiftMasterDetailsID
        {
            get;
            set;
        }                                      //EmployeeShiftMasterDetails ID
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
        public string WeeklyOffStatus
        {
            get;
            set;
        }
        public string ShiftTimeFrom
        {
            get;
            set;
        }
        public string ShiftTimeUpto
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
        public string ConsiderLateMarkUpto
        {
            get;
            set;
        }
        public string SecondHalfFrom
        {
            get;
            set;
        }
        public string FirstHalfUpto
        {
            get;
            set;
        }
        public string LunchTimeFrom
        {
            get;
            set;
        }
        public string LunchTimeUpto
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
    }
}
