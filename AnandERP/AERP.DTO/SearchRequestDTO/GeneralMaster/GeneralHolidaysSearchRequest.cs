using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class GeneralHolidaysSearchRequest : Request
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
        public string CentreCode
        {
            get;
            set;
        }
        public string Date
        {
            get;
            set;
        }
        public int LeaveSessionID
        {
            get;
            set;
        }
        public string Description
        {
            get;
            set;
        }
        public bool IsFixHoliday
        {
            get;
            set;
        }
        public string Type
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
        public string SearchBy 
        { get; set; }
        public string SortDirection 
        { get; set; }
    }
}
