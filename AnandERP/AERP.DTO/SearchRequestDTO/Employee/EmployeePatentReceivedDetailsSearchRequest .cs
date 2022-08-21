using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeePatentReceivedDetailsSearchRequest : Request
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
        public string SubjectOfPatent
        {
            get;
            set;
        }
        public DateTime DateOfApplication
        {
            get;
            set;
        }
        public string PatentApprovalStatus
        {
            get;
            set;
        }
        public DateTime DateOfApproval
        {
            get;
            set;
        }
        public string Remarks
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
        public string SortDirection
        {
            get;
            set;
        }
    }
}