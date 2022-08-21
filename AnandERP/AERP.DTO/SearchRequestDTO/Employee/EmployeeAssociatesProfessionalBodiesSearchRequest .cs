using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeAssociatesProfessionalBodiesSearchRequest : Request
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
        public string ActivityName
        {
            get;
            set;
        }
        public DateTime FromPeriod
        {
            get;
            set;
        }
        public DateTime UptoPeriod
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
