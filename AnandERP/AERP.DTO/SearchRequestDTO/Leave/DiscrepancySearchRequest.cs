using AERP.Base.DTO;
using System;
namespace AERP.DTO
{
    public class DiscrepancySearchRequest : Request
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
        public int SalarySpanID
        {
            get;
            set;
        }
        public string EmployeeFirstName
        {
            get;
            set;
        }
        public string EmployeeMiddleName
        {
            get;
            set;
        }
        public string EmployeeLastName
        {
            get;
            set;
        }
        public string CentreCode
        {
            get;
            set;
        }
        public int DepartmentID
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
    }
}
