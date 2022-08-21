using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class EmployeeShiftApplicableMasterSearchRequest : Request
    {
        public int ID
        {
            get;
            set;
        }
        public int EmployeeID
        {
            get;
            set;
        }
        public int EmployeeShiftMasterID
        {
            get;
            set;
        }
        public string ShiftType
        {
            get;
            set;
        }
        public string ShiftTypeDescription
        {
            get;
            set;
        }
        public string RotationDays
        {
            get;
            set;
        }
        public string ShiftStartDate
        {
            get;
            set;
        }
        public bool CurrentActiveFlag
        {
            get;
            set;
        }
        public string ShiftEndDate
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
        
        public string SortDirection
        {
            get;
            set;
        }
        public string SearchBy
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public string DepartmentID
        {
            get;
            set;
        }
    }
}
