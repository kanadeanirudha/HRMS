using AERP.Base.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DTO
{ 
    public class EmployeeBulkAttendenceMasterSearchRequest:Request
    {
        public int ID
        {
            get;
            set;
        }

        public string EmployeeCode
        {
            get;
            set;
        }

        public string EmployeeName
        {
            get;
            set;
        }

        public int TotalAttendence
        {
            get;
            set;
        }

        public int TotalOvertime
        {
            get;
            set;
        }

        public string CentreCode
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
        public string DepartmentID { get; set; }
        public int SpanID { get; set; }
    }
}
