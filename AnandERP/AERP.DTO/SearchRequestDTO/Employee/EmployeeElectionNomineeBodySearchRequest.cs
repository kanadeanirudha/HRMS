using AMS.Base.DTO;
using System;
namespace AMS.DTO
{
    public class EmployeeElectionNomineeBodySearchRequest : Request
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
        public int GeneralBoardUniversityID
        {
            get;
            set;
        }
        public string NameOfBoardBody
        {
            get;
            set;
        }
        public string PostHeld
        {
            get;
            set;
        }
        public string FromDate
        {
            get;
            set;
        }
        public string ToDate
        {
            get;
            set;
        }
        public string Remarks
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
    }
}
